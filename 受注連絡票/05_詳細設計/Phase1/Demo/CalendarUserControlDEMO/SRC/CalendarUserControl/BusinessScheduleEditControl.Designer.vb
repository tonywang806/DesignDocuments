<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusinessScheduleEditControl
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusinessScheduleEditControl))
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
        Me.C1FlexGrid1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 3)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 7
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.Rows.Fixed = 0
        Me.C1FlexGrid1.Size = New System.Drawing.Size(905, 165)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 0
        Me.C1FlexGrid1.UseCompatibleTextRendering = True
        '
        'BusinessScheduleEditControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Name = "BusinessScheduleEditControl"
        Me.Size = New System.Drawing.Size(906, 192)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
