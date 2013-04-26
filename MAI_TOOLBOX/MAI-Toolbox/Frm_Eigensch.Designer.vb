<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Eigensch
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_Exec = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.TB_Tnr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Name = New System.Windows.Forms.TextBox()
        Me.LBL_Pos = New System.Windows.Forms.Label()
        Me.LBL_Warn = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_Exec
        '
        Me.Btn_Exec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Exec.Location = New System.Drawing.Point(9, 155)
        Me.Btn_Exec.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_Exec.Name = "Btn_Exec"
        Me.Btn_Exec.Size = New System.Drawing.Size(112, 41)
        Me.Btn_Exec.TabIndex = 0
        Me.Btn_Exec.Text = "Übernehmen"
        Me.Btn_Exec.UseVisualStyleBackColor = True
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Exit.Location = New System.Drawing.Point(140, 155)
        Me.Btn_Exit.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(112, 41)
        Me.Btn_Exit.TabIndex = 1
        Me.Btn_Exit.Text = "Abbrechen"
        Me.Btn_Exit.UseVisualStyleBackColor = True
        '
        'TB_Tnr
        '
        Me.TB_Tnr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Tnr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Tnr.Location = New System.Drawing.Point(11, 24)
        Me.TB_Tnr.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Tnr.Name = "TB_Tnr"
        Me.TB_Tnr.Size = New System.Drawing.Size(242, 26)
        Me.TB_Tnr.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Teilenummer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Name"
        '
        'TB_Name
        '
        Me.TB_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Name.Location = New System.Drawing.Point(9, 89)
        Me.TB_Name.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(245, 26)
        Me.TB_Name.TabIndex = 5
        '
        'LBL_Pos
        '
        Me.LBL_Pos.AutoSize = True
        Me.LBL_Pos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Pos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBL_Pos.Location = New System.Drawing.Point(12, 52)
        Me.LBL_Pos.Name = "LBL_Pos"
        Me.LBL_Pos.Size = New System.Drawing.Size(49, 16)
        Me.LBL_Pos.TabIndex = 6
        Me.LBL_Pos.Text = "Label3"
        '
        'LBL_Warn
        '
        Me.LBL_Warn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Warn.ForeColor = System.Drawing.Color.Red
        Me.LBL_Warn.Location = New System.Drawing.Point(12, 117)
        Me.LBL_Warn.Name = "LBL_Warn"
        Me.LBL_Warn.Size = New System.Drawing.Size(240, 36)
        Me.LBL_Warn.TabIndex = 7
        '
        'Frm_Eigensch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 206)
        Me.Controls.Add(Me.LBL_Warn)
        Me.Controls.Add(Me.LBL_Pos)
        Me.Controls.Add(Me.TB_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_Tnr)
        Me.Controls.Add(Me.Btn_Exit)
        Me.Controls.Add(Me.Btn_Exec)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Eigensch"
        Me.Text = "Eigenschaften übernehmen"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Exec As System.Windows.Forms.Button
    Friend WithEvents Btn_Exit As System.Windows.Forms.Button
    Friend WithEvents TB_Tnr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents LBL_Pos As System.Windows.Forms.Label
    Friend WithEvents LBL_Warn As System.Windows.Forms.Label
End Class
