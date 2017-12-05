Imports C1.Win.C1FlexGrid
Partial Public Class BusinessScheduleEditControl

#Region "初期化関連"
    Private Sub InitializeDateLabelList()
        For startColumn As Integer = 0 To 17
            'Console.WriteLine("InitializeDateLabelList:{0}", startColumn)
            dateLabelList.Add(C1FlexGrid1.GetCellRange(0, startColumn))
            dateLabelList.Add(C1FlexGrid1.GetCellRange(1, startColumn))
            dateLabelList.Add(C1FlexGrid1.GetCellRange(2, startColumn))
            dateLabelList.Add(C1FlexGrid1.GetCellRange(3, startColumn))
            dateLabelList.Add(C1FlexGrid1.GetCellRange(4, startColumn))
            dateLabelList.Add(C1FlexGrid1.GetCellRange(5, startColumn))
            dateLabelList.Add(C1FlexGrid1.GetCellRange(6, startColumn))
            startColumn = startColumn + 2
        Next
    End Sub

    Private Sub InitializeScheduleBoxList()
        For startColumn As Integer = 2 To 17
            'Console.WriteLine("InitializeScheduleBoxList:{0}", startColumn)
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(0, startColumn))
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(1, startColumn))
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(2, startColumn))
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(3, startColumn))
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(4, startColumn))
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(5, startColumn))
            scheduleBoxList.Add(C1FlexGrid1.GetCellRange(6, startColumn))
            startColumn = startColumn + 2
        Next

    End Sub

    Private Sub InitializedayNameLableList()
        For startColumn As Integer = 1 To 17
            'Console.WriteLine("InitializedayNameLableList:{0}", startColumn)
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(0, startColumn))
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(1, startColumn))
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(2, startColumn))
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(3, startColumn))
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(4, startColumn))
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(5, startColumn))
            dayNameLableList.Add(C1FlexGrid1.GetCellRange(6, startColumn))
            startColumn = startColumn + 2
        Next
    End Sub
#End Region

    ''' <summary>
    ''' カレンダーRefreshメソッド
    ''' </summary>
    Private Sub ReDrawCalendar()
        RemoveHandler C1FlexGrid1.CellChanged, AddressOf C1FlexGrid1_CellChanged
        For i As Integer = 0 To 41
            SetCalendarInfo(StartDay.AddDays(i), dateLabelList.Item(i), dayNameLableList.Item(i), scheduleBoxList(i))
        Next
        AddHandler C1FlexGrid1.CellChanged, AddressOf C1FlexGrid1_CellChanged
    End Sub
    ''' <summary>
    ''' カレンダーのセルに情報やスタイルを設定する方法です。
    ''' </summary>
    ''' <param name="day">予定日</param>
    ''' <param name="lblDay">予定日セル</param>
    ''' <param name="lblDayName">曜日セル</param>
    ''' <param name="txtSchedule">予定情報セル</param>
    Private Sub SetCalendarInfo(day As Date, lblDay As CellRange, lblDayName As CellRange, txtSchedule As CellRange)
        '予定日設定
        lblDay.Data = day
        '曜日設定
        lblDayName.Data = GetDayName(day)

        'スタイル設定
        If IsHoliday(day) Then
            lblDay.Style = C1FlexGrid1.Styles("HolidayStyle")
            lblDayName.Style = C1FlexGrid1.Styles("HolidayStyle")
            txtSchedule.Style = C1FlexGrid1.Styles("HolidayTaskStyle")
        Else
            lblDay.Style = C1FlexGrid1.Styles("TitleNormal")
            lblDayName.Style = C1FlexGrid1.Styles("TitleNormal")
            txtSchedule.Style = C1FlexGrid1.Styles("Normal")
        End If

        '予定情報設定
        txtSchedule.Data = String.Empty
        If DataSource Is Nothing Then
            'バンディングされない場合、処理中止
            Return
        End If
        If Not DataSource.Tables.Contains(DataMember) Then
            'バンディングされない場合、処理中止
            Return
        End If

        With DataSource.Tables(DataMember)
            If Not .Columns.Contains(TaskDateColumn) Then
                'バンディングされない場合、処理中止
                Return
            End If
            If Not .Columns.Contains(TaskColumn) Then
                'バンディングされない場合、処理中止
                Return
            End If

            Dim MatchRow As DataRow() = .Select(String.Format("{0} = '{1}'",
                                                              TaskDateColumn, day.ToShortDateString))
            If MatchRow.Count > 0 Then
                txtSchedule.Data = MatchRow(0).Item(TaskColumn)
                txtSchedule.Style = C1FlexGrid1.Styles("TaskStyle")
            End If
        End With
    End Sub
    ''' <summary>
    ''' 漢字曜日を戻ります。
    ''' </summary>
    ''' <param name="day">予定日</param>
    ''' <returns>String</returns>
    Private Function GetDayName(day As Date) As String
        Select Case day.DayOfWeek
            Case DayOfWeek.Monday
                Return "月"
            Case DayOfWeek.Tuesday
                Return "火"
            Case DayOfWeek.Wednesday
                Return "木"
            Case DayOfWeek.Thursday
                Return "水"
            Case DayOfWeek.Friday
                Return "金"
            Case DayOfWeek.Saturday
                Return "土"
            Case DayOfWeek.Sunday
                Return "日"
        End Select
        Return ""
    End Function
    ''' <summary>
    ''' カレンダーの最初日が変わる次第、カレンダーを再描く
    ''' </summary>
    Private Sub StartDayChanged()

        If dateLabelList.Count = 0 Then
            'Gridが初期化しない場合、中止
            Return
        End If

        'カレンダーを再描く
        ReDrawCalendar()
    End Sub
    ''' <summary>
    ''' 予定情報編集結果より、セルのスタイルをセットします。
    ''' </summary>
    ''' <param name="c">予定情報セル</param>
    ''' <param name="day">予定日</param>
    Private Sub SetScheduleCellStyle(c As CellRange, day As Date)
        If String.IsNullOrEmpty(c.DataDisplay.Trim) Then
            '予定がなくなる場合
            If IsHoliday(day) Then
                '休日の場合
                c.Style = C1FlexGrid1.Styles("HolidayTaskStyle")
            Else
                c.Style = C1FlexGrid1.Styles("Normal")
            End If
        Else
            '予定がある場合
            c.Style = C1FlexGrid1.Styles("TaskStyle")
        End If
    End Sub
    ''' <summary>
    '''指定されたコラムインディクスより、関連の予定情報コラムインディクスを計算します。 
    ''' </summary>
    ''' <param name="currentCol">指定されたコラムインディクス</param>
    ''' <returns>関連の予定情報コラムインディクス</returns>
    Private Function GetTaskCellColumnIndex(currentCol As Integer) As Integer
        Dim intWeekNo As Integer = Math.Floor(currentCol / 3)
        Return (intWeekNo * 3) + 2
    End Function
    ''' <summary>
    ''' 指定されたコラムインディクスより、関連の予定日コラムインディクスを計算します。 
    ''' </summary>
    ''' <param name="currentCol">指定されたコラムインディクス</param>
    ''' <returns>関連の予定日コラムインディクス</returns>
    Private Function GetTaskDateColumnIndex(currentCol As Integer) As Integer
        Dim intWeekNo As Integer = Math.Floor(currentCol / 3)
        Return intWeekNo * 3
    End Function
    ''' <summary>
    ''' DragAndDrop操作で予定情報移動します。
    ''' </summary>
    ''' <param name="srcRow">移動先の行インディクス</param>
    ''' <param name="srcCol">移動先の列インディクス</param>
    Private Sub MoveTaskData(srcRow As Integer, srcCol As Integer, targetRow As Integer, targetCol As Integer)
        With C1FlexGrid1
            Dim srcTaskDateCell As Date = CType(.GetData(srcRow,
                                                     GetTaskDateColumnIndex(srcCol)), Date)
            Dim targetTaskDateCell As Date = CType(.GetData(targetRow,
                                                     GetTaskDateColumnIndex(targetCol)), Date)
            Dim rs As DataRow() = DataSource.Tables(DataMember).Select(String.Format("{0}='{1}'",
                                                                                     TaskDateColumn,
                                                                                     srcTaskDateCell.ToShortDateString))
            rs(0).Item(TaskDateColumn) = targetTaskDateCell.ToShortDateString

            DataSource.AcceptChanges()
        End With
    End Sub
    ''' <summary>
    ''' DragAndDrop操作で予定情報コピーします。
    ''' </summary>
    ''' <param name="srcRow">コピー先の行インディクス</param>
    ''' <param name="srcCol">コピー先の列インディクス</param>
    Private Sub CopyTaskData(srcRow As Integer, srcCol As Integer, targetRow As Integer, targetCol As Integer)
        With C1FlexGrid1
            Dim srcTaskCell As String = CType(.GetData(srcRow,
                                                     GetTaskCellColumnIndex(srcCol)), String)
            Dim targetTaskDateCell As Date = CType(.GetData(targetRow,
                                                     GetTaskDateColumnIndex(targetCol)), Date)
            'insert
            Dim dr As DataRow = DataSource.Tables(DataMember).NewRow
            dr.Item(TaskDateColumn) = targetTaskDateCell.ToShortDateString
            dr.Item(TaskColumn) = srcTaskCell
            DataSource.Tables(DataMember).Rows.Add(dr)
            DataSource.AcceptChanges()
        End With
    End Sub

    Public Sub AddHoliday(day As Date)
        If Not holidayList.Contains(day) Then
            holidayList.Add(day)
        End If
    End Sub
    Public Function IsHoliday(day As Date) As Boolean
        Dim ret As Boolean = False

        If day.DayOfWeek = DayOfWeek.Saturday OrElse
           day.DayOfWeek = DayOfWeek.Sunday OrElse
           holidayList.Contains(day) Then
            ret = True
        End If
        Return ret
    End Function

    Private Sub SavDeletedTaskNo(dr As DataRow)
        If dr.Item(TaskNoColumn) Is DBNull.Value Then
            '登録されない予定情報を削除される場合、退避必要がないです。
            Return
        End If

        DeleteRows.Add(CType(dr.Item(TaskNoColumn), String))
    End Sub
End Class
