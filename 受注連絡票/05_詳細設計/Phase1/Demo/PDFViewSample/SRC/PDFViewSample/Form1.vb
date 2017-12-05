Public Class Form1

    Private beSavedFileList As New List(Of String)
    Private newFileList As New List(Of String)
    Private DeleteFileList As New List(Of String)

    Private pdfServerPath As String = "\\fileserver\02_プロジェクト共有\022_CPM進捗管理システムPJ\PDFSaveTest"
    Private ServerAdmin As String = "ectuser002"
    Private ServerPassword As String = "ectuser002"
    Private Domain As String = "chiyodagravure.local"

    Private Sub btnFileSelect_Click(sender As Object, e As EventArgs) Handles btnFileSelect.Click
        If ofdPDFSelector.ShowDialog = DialogResult.OK Then
            With ofdPDFSelector

                'pbFileLoadProgressBar.Value = 0
                'pbFileLoadProgressBar.Visible = True

                clbPDFFileList.BeginUpdate()


                For i As Integer = 0 To .FileNames.Count - 1
                    If Not newFileList.Contains(.FileNames(i)) AndAlso
                        Not beSavedFileList.Contains(.SafeFileName(i)) Then
                        AddFileNametoList(.FileNames(i), .SafeFileNames(i), True)
                        newFileList.Add(.FileNames(i))
                    End If

                    'pbFileLoadProgressBar.Value = Math.Floor(((i + 1) / .FileNames.Count) * pbFileLoadProgressBar.Maximum)
                Next

                'End If
                clbPDFFileList.EndUpdate()

                InitializePdfViewer()
            End With
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If newFileList.Count = 0 AndAlso DeleteFileList.Count = 0 Then
            Return
        End If

        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        Try
            Me.AccessServerDelegate(AddressOf DeletePDFFile)
            Me.AccessServerDelegate(AddressOf UploadPDFFile)
            MessageBox.Show(Me, String.Format("添付ファイル更新成功！{2}＜Upload:{0},Delete:{1}＞ ",
                                          newFileList.Count, DeleteFileList.Count, vbNewLine))

            InitializeListContent()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Dim t As Threading.Thread = New Threading.Thread(AddressOf ThreadWork)
            t.Start()
        End Try
    End Sub

    Private Sub clbPDFFileList_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbPDFFileList.ItemCheck
        Console.WriteLine("{0} Start", "clbPDFFileList_ItemCheck")
        'If Not Control.ModifierKeys = Keys.Control Then
        '    e.NewValue = e.CurrentValue
        'End If
        'Console.WriteLine("Selected Item:{0}", clbPDFFileList.SelectedIndex)
        'Console.WriteLine("MousePosition:{0}", MousePosition)
        'Console.WriteLine("Client MousePosition:{0}", clbPDFFileList.PointToClient(MousePosition))

        'Console.WriteLine("Control.ModifierKeys:{0}  Checkbox Current value :{1}  Checkbox New Value:{2}",
        '                  Control.ModifierKeys,
        '                  e.CurrentValue,
        '                  e.NewValue)

        'Dim clickPoint As Point = clbPDFFileList.PointToClient(MousePosition)

        If clbPDFFileList.PointToClient(MousePosition).X > 15 Then
            e.NewValue = e.CurrentValue
        End If

        ShowPDFFile(CType(clbPDFFileList.SelectedItem, CheckListItem).FileName)

        Console.WriteLine("{0} End", "clbPDFFileList_ItemCheck")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Console.WriteLine("{0} Start", "btnDelete_Click")

        If clbPDFFileList.CheckedItems.Count < 1 Then
            Return
        End If

        clbPDFFileList.BeginUpdate()
        Dim checkedList() As CheckListItem = New CheckListItem(clbPDFFileList.CheckedItems.Count - 1) {}
        clbPDFFileList.CheckedItems.CopyTo(checkedList, 0)

        For Each item As CheckListItem In checkedList
            If newFileList.Contains(item.FileName) Then
                newFileList.Remove(item.FileName)
            End If

            If Not DeleteFileList.Contains(item.FileName) Then
                DeleteFileList.Add(item.FileName)
            End If

            clbPDFFileList.Items.Remove(item)
        Next

        InitializePdfViewer()

        clbPDFFileList.EndUpdate()

        Console.WriteLine("{0} End", "btnDelete_Click")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clbPDFFileList.DisplayMember = "SaveFileName"
        clbPDFFileList.ValueMember = "FileName"
        Control.CheckForIllegalCrossThreadCalls = False

        InitializeListContent()
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        'clbPDFFileList.BeginUpdate()
        RemoveHandler clbPDFFileList.ItemCheck, AddressOf clbPDFFileList_ItemCheck

        For i As Integer = 0 To clbPDFFileList.Items.Count - 1
            clbPDFFileList.SetItemCheckState(i, CheckState.Checked)
        Next

        AddHandler clbPDFFileList.ItemCheck, AddressOf clbPDFFileList_ItemCheck
        'clbPDFFileList.EndUpdate()
    End Sub

    Private Sub btnInverse_Click(sender As Object, e As EventArgs) Handles btnInverse.Click
        'clbPDFFileList.BeginUpdate()
        RemoveHandler clbPDFFileList.ItemCheck, AddressOf clbPDFFileList_ItemCheck

        For i As Integer = 0 To clbPDFFileList.Items.Count - 1
            clbPDFFileList.SetItemChecked(i, Not clbPDFFileList.GetItemChecked(i))
        Next

        AddHandler clbPDFFileList.ItemCheck, AddressOf clbPDFFileList_ItemCheck
        'clbPDFFileList.EndUpdate()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class
