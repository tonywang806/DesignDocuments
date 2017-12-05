Public Class CheckListItem
    Private strFileName As String
    Private strSaveFileName As String
    Private blnIsNewFile As Boolean

    Public Property FileName As String
        Get
            Return strFileName
        End Get
        Set(value As String)
            strFileName = value
        End Set
    End Property

    Public Property SaveFileName As String
        Get
            Return strSaveFileName
        End Get
        Set(value As String)
            strSaveFileName = value
        End Set
    End Property

    Public Property IsNewFile As Boolean
        Get
            Return blnIsNewFile
        End Get
        Set(value As Boolean)
            blnIsNewFile = value
        End Set
    End Property
End Class
