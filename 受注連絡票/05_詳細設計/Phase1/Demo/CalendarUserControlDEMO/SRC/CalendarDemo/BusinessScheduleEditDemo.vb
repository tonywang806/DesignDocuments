Imports System.Globalization
Imports System.Text
Imports C1.Win.C1List


Public Class BusinessScheduleEditDemo
    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#Region "データソースの初期化"
        Dim ds As DataSet = New DataSet
        Dim dt As DataTable = New DataTable("ScheduleTable")
        dt.Columns.Add(New DataColumn("TaskDate", GetType(String)))
        dt.Columns.Add(New DataColumn("Task", GetType(String)))
        dt.Columns.Add(New DataColumn("TaskNo", GetType(String)))

        ds.Tables.Add(dt)

        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = "2017/03/01"
        dr.Item(1) = "入稿"
        dr.Item(2) = "00001"
        dt.Rows.Add(dr)

        ds.AcceptChanges()
#End Region

#Region "カレンダーの初期化"
        With CalendarDayControl31
            '先にデータソースをバンディングしてください！！
            .DataSource = ds
            .DataMember = "ScheduleTable"
            .TaskDateColumn = "TaskDate"
            .TaskColumn = "Task"
            .TaskNoColumn = "TaskNo"

            '休暇日を追加します。
            .AddHoliday(New Date(2017, 2, 11))
            .AddHoliday(New Date(2017, 3, 20))
            .AddHoliday(New Date(2017, 3, 20))
            .AddHoliday(New Date(2017, 5, 3))
            .AddHoliday(New Date(2017, 5, 4))
            .AddHoliday(New Date(2017, 5, 5))

            'カレンダーの開始日を設定します。
            .StartDay = New Date(2017, 2, 11)
        End With

        SetTimeSpanText()
#End Region

#Region "予定一覧リストの初期化"
        C1List1.DataSource = ds
        C1List1.DataMember = "ScheduleTable"
        C1List1.DisplayMember = "TaskDate"
        C1List1.ValueMember = "Task"
        C1List1.Columns.Item(0).Caption = "予定日"
        C1List1.Columns.Item(1).Caption = "予定内容"
        C1List1.Sort(0, SortDirEnum.ASC)
#End Region

    End Sub
    ''' <summary>
    ''' カレンダーが先週に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        With CalendarDayControl31
            .StartDay = .StartDay.AddDays(-7)
        End With

        SetTimeSpanText()
    End Sub
    ''' <summary>
    ''' カレンダーが来週に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        With CalendarDayControl31
            .StartDay = .StartDay.AddDays(7)
        End With

        SetTimeSpanText()

    End Sub
    ''' <summary>
    ''' カレンダーの期間を表示
    ''' </summary>
    Private Sub SetTimeSpanText()
        With CalendarDayControl31
            lblTimeSpan.Text = String.Format("表示期間： {0} ～ {1}", .StartDay.ToShortDateString, .EndDay.ToShortDateString)
        End With
    End Sub
    ''' <summary>
    ''' 予定情報一覧に指定される予定情報が目の前に表示します。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1List1_Click(sender As Object, e As EventArgs) Handles C1List1.Click
        Console.WriteLine("C1List1_Click:{0}", C1List1.Row)
        If C1List1.Row < 0 Then
            Return
        End If

        Dim sa As CultureInfo = New CultureInfo("ja-JP")
        CalendarDayControl31.StartDay = Date.ParseExact(C1List1.GetItemText(C1List1.Row, 0), "yyyy/MM/dd", sa)
    End Sub
    ''' <summary>
    ''' 削除した予定の番号を表示します。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim deletedTaskRow As List(Of String) = CalendarDayControl31.DeleteRows
        C1TextBox1.Value = String.Empty
        Dim result As New StringBuilder
        For Each s As String In deletedTaskRow
            result.AppendLine(s)
        Next
        C1TextBox1.Value = result.ToString
    End Sub
End Class