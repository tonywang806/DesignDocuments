Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions
Imports System.IO
Partial Class Form1


#Region "　　Server　File　Operate　Delegate"
    Public Delegate Sub OperateDelegate()

    <DllImport("advapi32.DLL", SetLastError:=True)>
    Public Shared Function LogonUser(ByVal lpszUsername As String, ByVal lpszDomain As String,
        ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer,
        ByRef phToken As IntPtr) As Integer
    End Function

    Private Sub AccessServerDelegate(d As OperateDelegate)
        Dim admin_token As IntPtr
        Dim wid_current As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim wid_admin As WindowsIdentity = Nothing
        Dim wic As WindowsImpersonationContext = Nothing
        Try


            If LogonUser(ServerAdmin, Domain, ServerPassword, 9, 0, admin_token) <> 0 Then
                wid_admin = New WindowsIdentity(admin_token)
                wic = wid_admin.Impersonate()

                d.Invoke
                'MessageBox.Show("Copy succeeded")
                'Else
                '    MessageBox.Show("Copy Failed")
            End If
        Catch se As System.Exception
            Dim ret As Integer = Marshal.GetLastWin32Error()
            MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString())
            MessageBox.Show(se.Message)
        Finally
            If wic IsNot Nothing Then
                wic.Undo()
            End If
        End Try
    End Sub
#End Region
    Private Sub AddFileNametoList(fileName As String, saveFileName As String, Optional isNew As Boolean = False)

        Try

            Dim item As New CheckListItem
            item.FileName = fileName

            If isNew Then
                item.SaveFileName = String.Format("* {0}", saveFileName)
            Else
                item.SaveFileName = saveFileName
            End If

            clbPDFFileList.Items.Add(item)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub ShowPDFFile(fileName As String)
        Try
            'Dim tabViewer As New C1DockingTabPage
            'Dim pdfViewer As New AxAcroPDFLib.AxAcroPDF

            'pdfViewer.Dock = DockStyle.Fill
            'tabViewer.Controls.Add(pdfViewer)


            'tabFileViewerGroup.TabPages.Add(tabViewer)


            If pdfViewer.src = String.Format("file://{0}", fileName) Then
                Return
            End If

            'Dim t As Threading.Thread = New Threading.Thread(AddressOf threadWork)
            't.Start()


            pdfViewer.SuspendLayout()

            pdfViewer.src = fileName

            'pdfViewer.setShowToolbar(False)
            pdfViewer.setPageMode("none")
            pdfViewer.setView("fitH")
            pdfViewer.setLayoutMode("SinglePage")
            pdfViewer.gotoFirstPage()

            pdfViewer.ResumeLayout()

            'pdfViewer.Show()
            'pdfViewer.EndInit()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub UploadPDFFile()
        Dim fileCount As Integer = newFileList.Count
        Dim currentIndex As Integer = 0
        For Each item As String In newFileList
            currentIndex += 1
            System.IO.File.Copy(item, String.Format("{0}\{1}", pdfServerPath, GetSafeFileName(item)), True)
            SetProgressBar(currentIndex, fileCount)
        Next
    End Sub

    Private Sub DeletePDFFile()
        Dim fileCount As Integer = DeleteFileList.Count
        Dim currentIndex As Integer = 0
        For Each item As String In DeleteFileList
            currentIndex += 1
            System.IO.File.Delete(String.Format("{0}\{1}", pdfServerPath, GetSafeFileName(item)))
            SetProgressBar(currentIndex, fileCount)
        Next
    End Sub

    Private Sub GetServerPDFList()

        If Directory.Exists(pdfServerPath) Then
            Dim fileEnumerate As IEnumerable(Of String) = Directory.EnumerateFiles(pdfServerPath, "*.pdf")
            For Each file As String In fileEnumerate
                beSavedFileList.Add(file)
            Next
        Else
            Directory.CreateDirectory(pdfServerPath)
        End If
    End Sub

    Private Sub InitializeListContent()
        clbPDFFileList.Items.Clear()
        beSavedFileList.Clear()
        newFileList.Clear()
        DeleteFileList.Clear()

        Me.AccessServerDelegate(AddressOf GetServerPDFList)
        For Each f As String In beSavedFileList
            AddFileNametoList(f, GetSafeFileName(f))
        Next
        InitializePdfViewer()
    End Sub

    Private Sub InitializePdfViewer()
        If clbPDFFileList.Items.Count > 0 Then
            If clbPDFFileList.SelectedItem Is Nothing Then
                clbPDFFileList.SetSelected(0, True)
                ShowPDFFile(CType(clbPDFFileList.Items(0), CheckListItem).FileName)
            Else
                ShowPDFFile(CType(clbPDFFileList.SelectedItem, CheckListItem).FileName)
            End If
        Else
            pdfViewer.src = "none"
        End If
    End Sub

    Private Function GetSafeFileName(filename As String) As String
        Dim NameContext As String() = filename.Split("\")

        If NameContext.Count = 0 Then
            Return String.Empty
        End If

        Return NameContext(NameContext.Count - 1)
    End Function

    Private Sub SetProgressBar(progress As Integer, MaxValue As Integer)
        ProgressBar1.Value = Math.Floor((progress / MaxValue) * 100)
    End Sub

    Private Sub ThreadWork()
        Threading.Thread.Sleep(1000)
        ProgressBar1.Visible = False
    End Sub
End Class
