<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG_OCU_NAME
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BTN_EXEC
        '
        Me.BTN_EXEC.Location = New System.Drawing.Point(12, 113)
        Me.BTN_EXEC.Name = "BTN_EXEC"
        Me.BTN_EXEC.Size = New System.Drawing.Size(120, 46)
        Me.BTN_EXEC.TabIndex = 0
        Me.BTN_EXEC.Text = "Übernehmen"
        Me.BTN_EXEC.UseVisualStyleBackColor = True
        '
        'BTN_EXIT
        '
        Me.BTN_EXIT.Location = New System.Drawing.Point(141, 113)
        Me.BTN_EXIT.Name = "BTN_EXIT"
        Me.BTN_EXIT.Size = New System.Drawing.Size(120, 46)
        Me.BTN_EXIT.TabIndex = 1
        Me.BTN_EXIT.Text = "Doch nicht"
        Me.BTN_EXIT.UseVisualStyleBackColor = True
        '
        'TB_NAME
        '
        Me.TB_NAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_NAME.Location = New System.Drawing.Point(12, 55)
        Me.TB_NAME.Name = "TB_NAME"
        Me.TB_NAME.Size = New System.Drawing.Size(249, 26)
        Me.TB_NAME.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Neuen Konstrukteur für Baugruppe und" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "alle Unterkomponenten  eintragen."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BG_OCU_NAME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 171)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_NAME)
        Me.Controls.Add(Me.BTN_EXIT)
        Me.Controls.Add(Me.BTN_EXEC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "BG_OCU_NAME"
        Me.Text = "Konstrukteur für BG"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_EXEC As System.Windows.Forms.Button
    Friend WithEvents BTN_EXIT As System.Windows.Forms.Button
    Friend WithEvents TB_NAME As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
