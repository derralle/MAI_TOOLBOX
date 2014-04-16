<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Traegheit
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
        Me.Label_Select = New System.Windows.Forms.Label()
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.TextBox_Ergebniss = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label_Select
        '
        Me.Label_Select.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label_Select.Location = New System.Drawing.Point(12, 12)
        Me.Label_Select.Name = "Label_Select"
        Me.Label_Select.Size = New System.Drawing.Size(284, 41)
        Me.Label_Select.TabIndex = 0
        Me.Label_Select.Text = "Label_Select"
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(12, 365)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(283, 41)
        Me.Button_Start.TabIndex = 1
        Me.Button_Start.Text = "Start"
        Me.Button_Start.UseMnemonic = False
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'TextBox_Ergebniss
        '
        Me.TextBox_Ergebniss.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox_Ergebniss.Enabled = False
        Me.TextBox_Ergebniss.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Ergebniss.Location = New System.Drawing.Point(13, 56)
        Me.TextBox_Ergebniss.Multiline = True
        Me.TextBox_Ergebniss.Name = "TextBox_Ergebniss"
        Me.TextBox_Ergebniss.Size = New System.Drawing.Size(281, 299)
        Me.TextBox_Ergebniss.TabIndex = 2
        '
        'Form_Traegheit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 418)
        Me.Controls.Add(Me.TextBox_Ergebniss)
        Me.Controls.Add(Me.Button_Start)
        Me.Controls.Add(Me.Label_Select)
        Me.Name = "Form_Traegheit"
        Me.Text = "Form_Traegheit"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Select As System.Windows.Forms.Label
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents TextBox_Ergebniss As System.Windows.Forms.TextBox
End Class
