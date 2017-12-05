Imports C1.Win.C1FlexGrid
Partial Public Class BusinessScheduleEditControl
    'カレンダーの最初日
    Private dteStartDay As DateTime = DateTime.Now

    '予定情報データソース
    Private ds As DataSet
    '予定情報データテーブル名
    Private strTalbeName As String
    '予定日を格納する列名
    Private strTaskDateColumn As String
    '予定情報を格納する列名
    Private strTaskColumn As String
    '予定番号を格納する列名
    Private strTaskNoColumn As String

    '削除した予定情報退避用データソース
    Private ds_Delete As New List(Of String)

    '日付セルのVector
    Private dateLabelList As New List(Of CellRange)
    '曜日セルのVector
    Private dayNameLableList As New List(Of CellRange)
    '予定情報セルのVector
    Private scheduleBoxList As New List(Of CellRange)

    '休暇日のVector
    Private holidayList As New HashSet(Of Date)

    ''' <summary>
    ''' カレンダーの最初日を取得及び設定します。
    ''' </summary>
    ''' <returns>Date</returns>
    Public Property StartDay As Date
        Get
            Return dteStartDay
        End Get
        Set(value As Date)

            '日付が任意指定できます。
            Dim dayOfWeek As Integer = CInt(value.DayOfWeek)

            If dayOfWeek = 0 Then
                dayOfWeek = 7
            End If

            '下のロジックで該当週の月曜日を求めます。
            dteStartDay = value.AddDays((dayOfWeek - 1) * -1)

            '開始日が変わると、画面Refreshします。
            StartDayChanged()
        End Set
    End Property
    ''' <summary>
    ''' カレンダーの最終日を取得します。
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property EndDay As Date
        Get
            'カレンダーの最終日を戻ります。
            Return dteStartDay.AddDays(41)
        End Get
    End Property

    Public Property DataSource As DataSet
        Get
            Return ds
        End Get
        Set(value As DataSet)
            ds = value
        End Set
    End Property

    Public Property DataMember As String
        Get
            Return strTalbeName
        End Get
        Set(value As String)
            strTalbeName = value
        End Set
    End Property

    Public Property TaskDateColumn As String
        Get
            Return strTaskDateColumn
        End Get
        Set(value As String)
            strTaskDateColumn = value
        End Set
    End Property

    Public Property TaskColumn As String
        Get
            Return strTaskColumn
        End Get
        Set(value As String)
            strTaskColumn = value
        End Set
    End Property
    Public Property TaskNoColumn As String
        Get
            Return strTaskNoColumn
        End Get
        Set(value As String)
            strTaskNoColumn = value
        End Set
    End Property
    ''' <summary>
    ''' 削除した予定情報を取得
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property DeleteRows As List(Of String)
        Get
            Return ds_Delete
        End Get
    End Property
End Class
