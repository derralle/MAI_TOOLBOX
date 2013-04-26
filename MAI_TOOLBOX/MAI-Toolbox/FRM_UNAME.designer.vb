<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_UNAME
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
        Me.BTN_EXEC = New System.Windows.Forms.Button()
        Me.BTN_EXIT = New System.Windows.Forms.Button()
        Me.TB_NAME = New System.Windows.Forms.TextBox()
        Me.CB_Zeichnung = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BTN_EXEC
        '
        Me.BTN_EXEC.Location = New System.Drawing.Point(10, 96)
        Me.BTN_EXEC.Name = "BTN_EXEC"
        Me.BTN_EXEC.Size = New System.Drawing.Size(123, 38)
        Me.BTN_EXEC.TabIndex = 0
        Me.BTN_EXEC.Text = "Umbenennen"
        Me.BTN_EXEC.UseVisualStyleBackColor = True
        '
        'BTN_EXIT
        '
        Me.BTN_EXIT.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_EXIT.Location = New System.Drawing.Point(240, 96)
        Me.BTN_EXIT.Name = "BTN_EXIT"
        Me.BTN_EXIT.Size = New System.Drawing.Size(123, 38)
        Me.BTN_EXIT.TabIndex = 1
        Me.BTN_EXIT.Text = "Beenden"
        Me.BTN_EXIT.UseVisualStyleBackColor = True
        '
        'TB_NAME
        '
        Me.TB_NAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_NAME.Location = New System.Drawing.Point(10, 24)
        Me.TB_NAME.Name = "TB_NAME"
        Me.TB_NAME.Size = New System.Drawing.Size(353, 26)
        Me.TB_NAME.TabIndex = 2
        '
        'CB_Zeichnung
        '
        Me.CB_Zeichnung.AutoSize = True
        Me.CB_Zeichnung.Checked = True
        Me.CB_Zeichnung.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_Zeichnung.Location = New System.Drawing.Point(12, 56)
        Me.CB_Zeichnung.Name = "CB_Zeichnung"
        Me.CB_Zeichnung.Size = New System.Drawing.Size(158, 17)
        Me.CB_Zeichnung.TabIndex = 3
        Me.CB_Zeichnung.Text = "Zeichnung mit umbenennen"
        Me.CB_Zeichnung.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "TEXTLAENGE"
        '
        'FRM_UNAME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BTN_EXIT
        Me.ClientSize = New System.Drawing.Size(371, 146)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB_Zeichnung)
        Me.Controls.Add(Me.TB_NAME)
        Me.Controls.Add(Me.BTN_EXIT)
        Me.Controls.Add(Me.BTN_EXEC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FRM_UNAME"
        Me.Text = "Umbenennen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_EXEC As System.Windows.Forms.Button
    Friend WithEvents BTN_EXIT As System.Windows.Forms.Button
    Friend WithEvents TB_NAME As System.Windows.Forms.TextBox
    Friend WithEvents CB_Zeichnung As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
