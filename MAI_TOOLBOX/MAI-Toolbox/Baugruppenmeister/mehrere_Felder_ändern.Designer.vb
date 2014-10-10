<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mehrere_Felder_ändern
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
        Me.EingabeTextBox = New System.Windows.Forms.TextBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'EingabeTextBox
        '
        Me.EingabeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EingabeTextBox.Location = New System.Drawing.Point(12, 14)
        Me.EingabeTextBox.Name = "EingabeTextBox"
        Me.EingabeTextBox.Size = New System.Drawing.Size(196, 26)
        Me.EingabeTextBox.TabIndex = 0
        '
        'OkButton
        '
        Me.OkButton.Location = New System.Drawing.Point(239, 9)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(118, 38)
        Me.OkButton.TabIndex = 1
        Me.OkButton.Text = "Übernehmen"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'mehrere_Felder_ändern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 54)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.EingabeTextBox)
        Me.MaximizeBox = False
        Me.Name = "mehrere_Felder_ändern"
        Me.Text = "mehrere Felder ändern"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EingabeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OkButton As System.Windows.Forms.Button
End Class
