<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ofdPDFSelector = New System.Windows.Forms.OpenFileDialog()
        Me.btnFileSelect = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnInverse = New System.Windows.Forms.Button()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.clbPDFFileList = New System.Windows.Forms.CheckedListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pdfViewer = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pdfViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClose.Location = New System.Drawing.Point(937, 633)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSave.Location = New System.Drawing.Point(856, 633)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "登録"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ofdPDFSelector
        '
        Me.ofdPDFSelector.Filter = "PDFファイル|*.PDF"
        Me.ofdPDFSelector.Multiselect = True
        Me.ofdPDFSelector.Title = "納入先情報"
        '
        'btnFileSelect
        '
        Me.btnFileSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileSelect.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFileSelect.Location = New System.Drawing.Point(184, 495)
        Me.btnFileSelect.Name = "btnFileSelect"
        Me.btnFileSelect.Size = New System.Drawing.Size(70, 23)
        Me.btnFileSelect.TabIndex = 0
        Me.btnFileSelect.Text = "追加"
        Me.btnFileSelect.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 92)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.pdfViewer)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnInverse)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFileSelect)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDelete)
        Me.SplitContainer1.Panel2MinSize = 150
        Me.SplitContainer1.Size = New System.Drawing.Size(1000, 521)
        Me.SplitContainer1.SplitterDistance = 664
        Me.SplitContainer1.TabIndex = 6
        '
        'btnInverse
        '
        Me.btnInverse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInverse.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInverse.Location = New System.Drawing.Point(85, 494)
        Me.btnInverse.Name = "btnInverse"
        Me.btnInverse.Size = New System.Drawing.Size(70, 23)
        Me.btnInverse.TabIndex = 8
        Me.btnInverse.Text = "Inverse"
        Me.btnInverse.UseVisualStyleBackColor = True
        '
        'btnAll
        '
        Me.btnAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAll.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAll.Location = New System.Drawing.Point(10, 494)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(70, 23)
        Me.btnAll.TabIndex = 8
        Me.btnAll.Text = "All"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.clbPDFFileList)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(332, 491)
        Me.Panel1.TabIndex = 1
        '
        'clbPDFFileList
        '
        Me.clbPDFFileList.CheckOnClick = True
        Me.clbPDFFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbPDFFileList.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.clbPDFFileList.FormattingEnabled = True
        Me.clbPDFFileList.HorizontalScrollbar = True
        Me.clbPDFFileList.Location = New System.Drawing.Point(0, 0)
        Me.clbPDFFileList.Margin = New System.Windows.Forms.Padding(0)
        Me.clbPDFFileList.Name = "clbPDFFileList"
        Me.clbPDFFileList.Size = New System.Drawing.Size(332, 491)
        Me.clbPDFFileList.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(259, 495)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(70, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 633)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(294, 23)
        Me.ProgressBar1.TabIndex = 7
        Me.ProgressBar1.Visible = False
        '
        'pdfViewer
        '
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Enabled = True
        Me.pdfViewer.Location = New System.Drawing.Point(0, 0)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.OcxState = CType(resources.GetObject("pdfViewer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfViewer.Size = New System.Drawing.Size(664, 521)
        Me.pdfViewer.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1024, 672)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.MinimumSize = New System.Drawing.Size(1040, 710)
        Me.Name = "Form1"
        Me.Text = "納入先情報入力Demo"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pdfViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents ofdPDFSelector As OpenFileDialog
    Friend WithEvents btnFileSelect As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents clbPDFFileList As CheckedListBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAll As Button
    Friend WithEvents btnInverse As Button
    Friend WithEvents pdfViewer As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
