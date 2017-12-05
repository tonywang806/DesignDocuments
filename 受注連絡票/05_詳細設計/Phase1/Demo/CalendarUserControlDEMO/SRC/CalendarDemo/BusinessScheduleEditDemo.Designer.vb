<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BusinessScheduleEditDemo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusinessScheduleEditDemo))
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblTimeSpan = New System.Windows.Forms.Label()
        Me.C1List1 = New C1.Win.C1List.C1List()
        Me.C1TextBox1 = New C1.Win.C1Input.C1TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CalendarDayControl31 = New CalendarUserControl.BusinessScheduleEditControl()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(747, 308)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(842, 308)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(75, 23)
        Me.btnForward.TabIndex = 1
        Me.btnForward.Text = "Forward"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'lblTimeSpan
        '
        Me.lblTimeSpan.AutoSize = True
        Me.lblTimeSpan.Location = New System.Drawing.Point(12, 71)
        Me.lblTimeSpan.Name = "lblTimeSpan"
        Me.lblTimeSpan.Size = New System.Drawing.Size(38, 12)
        Me.lblTimeSpan.TabIndex = 2
        Me.lblTimeSpan.Text = "Label1"
        '
        'C1List1
        '
        Me.C1List1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowColSelect = False
        Me.C1List1.AllowSort = False
        Me.C1List1.Caption = ""
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.C1List1.DefColWidth = 80
        Me.C1List1.FlatStyle = C1.Win.C1List.FlatModeEnum.Flat
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.Location = New System.Drawing.Point(740, 337)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.PrintInfo.PageSettings = CType(resources.GetObject("C1List1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1List1.ShowHeaderCheckBox = False
        Me.C1List1.Size = New System.Drawing.Size(177, 115)
        Me.C1List1.TabIndex = 3
        Me.C1List1.Text = "C1List1"
        Me.C1List1.VisualStyle = C1.Win.C1List.VisualStyle.System
        '
        'C1TextBox1
        '
        Me.C1TextBox1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.C1TextBox1.Location = New System.Drawing.Point(14, 337)
        Me.C1TextBox1.MaxLengthUnit = C1.Win.C1Input.LengthUnit.[Byte]
        Me.C1TextBox1.Multiline = True
        Me.C1TextBox1.Name = "C1TextBox1"
        Me.C1TextBox1.Size = New System.Drawing.Size(702, 115)
        Me.C1TextBox1.TabIndex = 4
        Me.C1TextBox1.Tag = Nothing
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(747, 466)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "登録"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(842, 466)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "閉じる"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(652, 466)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "詳細入力"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 322)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "備考"
        '
        'CalendarDayControl31
        '
        Me.CalendarDayControl31.DataMember = Nothing
        Me.CalendarDayControl31.DataSource = Nothing
        Me.CalendarDayControl31.Location = New System.Drawing.Point(12, 86)
        Me.CalendarDayControl31.Name = "CalendarDayControl31"
        Me.CalendarDayControl31.Size = New System.Drawing.Size(907, 216)
        Me.CalendarDayControl31.StartDay = New Date(2016, 12, 26, 0, 0, 0, 0)
        Me.CalendarDayControl31.TabIndex = 0
        Me.CalendarDayControl31.TaskColumn = Nothing
        Me.CalendarDayControl31.TaskDateColumn = Nothing
        Me.CalendarDayControl31.TaskNoColumn = Nothing
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 466)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "削除した予定Noを表示"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'BusinessScheduleEditDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 501)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.C1TextBox1)
        Me.Controls.Add(Me.C1List1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTimeSpan)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnForward)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.CalendarDayControl31)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BusinessScheduleEditDemo"
        Me.Text = "スケジュール入力画面Demo"
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CalendarDayControl31 As CalendarUserControl.BusinessScheduleEditControl
    Friend WithEvents btnBack As Button
    Friend WithEvents btnForward As Button
    Friend WithEvents lblTimeSpan As Label
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
    Friend WithEvents C1TextBox1 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
End Class
