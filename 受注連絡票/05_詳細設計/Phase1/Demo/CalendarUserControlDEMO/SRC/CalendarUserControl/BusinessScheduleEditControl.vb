Imports C1.Win.C1FlexGrid

Public Class BusinessScheduleEditControl
    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BusinessScheduleEditControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not DesignMode Then
            With C1FlexGrid1
                .Cols.Count = 18
                .Rows.Count = 7
                For i As Integer = 0 To .Rows.Count - 1
                    .Rows(i).Height = 30
                Next
                .Height = 30 * 7 + 5
            End With

            InitializeDateLabelList()
            InitializeScheduleBoxList()
            InitializedayNameLableList()

            ReDrawCalendar()

        End If
    End Sub
    ''' <summary>
    ''' 予定情報編集後処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FlexGrid1_CellChanged(sender As Object, e As RowColEventArgs) Handles C1FlexGrid1.CellChanged
        Dim taskDateCell As Date = CType(C1FlexGrid1.GetData(e.Row, e.Col - 2), Date)
        Dim taskCell As String = CType(C1FlexGrid1.GetDataDisplay(e.Row, e.Col), String)

        Dim rs As DataRow() = DataSource.Tables(DataMember).Select(String.Format("{0}='{1}'", TaskDateColumn, taskDateCell.ToShortDateString))
        If rs.Count > 0 Then
            If String.IsNullOrEmpty(taskCell) Then
                '予定内容が空白になる場合、削除と見なす
                SavDeletedTaskNo(rs(0))
                rs(0).Delete()
            Else
                '更新
                rs(0).Item(TaskColumn) = taskCell
            End If
        Else
            '新規
            Dim dr As DataRow = DataSource.Tables(DataMember).NewRow
            dr.Item(TaskDateColumn) = taskDateCell.ToShortDateString
            dr.Item(TaskColumn) = taskCell
            DataSource.Tables(DataMember).Rows.Add(dr)
        End If
        '
        DataSource.AcceptChanges()

        '編集結果より、セルのスタイルも合わせて変更します。
        SetScheduleCellStyle(C1FlexGrid1.GetCellRange(e.Row, e.Col), taskDateCell)
    End Sub
    ''' <summary>
    ''' Drag＆Drop操作開始処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FlexGrid1_MouseMove(sender As Object, e As MouseEventArgs) Handles C1FlexGrid1.MouseMove
        If e.Button = MouseButtons.Left Then
            With C1FlexGrid1
                If String.IsNullOrEmpty(.GetData(.RowSel, GetTaskCellColumnIndex(.ColSel))) Then
                    '予定情報がない場合、処理中止。
                    Return
                Else
                    If Control.ModifierKeys = Keys.Control Then
                        'Ctrlキーも押したら、コピーモードでDrag＆Drop操作を開始します。
                        .DoDragDrop({ .RowSel, .ColSel}, DragDropEffects.Copy)
                    Else
                        '上記以外、移動モードでDrag＆Drop操作を開始します。
                        .DoDragDrop({ .RowSel, .ColSel}, DragDropEffects.Move)
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub C1FlexGrid1_DragEnter(sender As Object, e As DragEventArgs) Handles C1FlexGrid1.DragEnter
        If Control.ModifierKeys = Keys.Control Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.Move
        End If
    End Sub
    ''' <summary>
    ''' Drag＆Drop操作終了処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FlexGrid1_DragDrop(sender As Object, e As DragEventArgs) Handles C1FlexGrid1.DragDrop
        With C1FlexGrid1
            Dim targetRow As Integer = .MouseRow
            Dim targetCol As Integer = .MouseCol

            Dim srcCell As Integer() = e.Data.GetData(GetType(Integer()))
            Dim targetTaskDateCell As Date = CType(.GetData(.MouseRow,
                                                         GetTaskDateColumnIndex(.MouseCol)), Date)

            Dim rs As DataRow() = DataSource.Tables(DataMember).Select(String.Format("{0}='{1}'",
                                                                                     TaskDateColumn,
                                                                                     targetTaskDateCell.ToShortDateString))
            If rs.Count > 0 Then
                '移動先に予定情報も存在している場合、
                Dim result As Integer = MessageBox.Show("指定日に予定がありました、上書してもよろしいでしょうか。",
                                                         "予定日重複",
                                                         MessageBoxButtons.OKCancel)
                If result = DialogResult.OK Then
                    SavDeletedTaskNo(rs(0))
                    rs(0).Delete()
                Else
                    Return
                End If

            End If

            '移動先に予定情報をセットします。
            .BeginUpdate()
            If Control.ModifierKeys = Keys.Control Then
                CopyTaskData(srcCell(0), srcCell(1), targetRow, targetCol)
            Else
                MoveTaskData(srcCell(0), srcCell(1), targetRow, targetCol)
            End If

            ReDrawCalendar()

            .EndUpdate()
        End With
    End Sub


End Class
