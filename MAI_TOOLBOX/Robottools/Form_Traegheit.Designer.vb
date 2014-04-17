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
        Me.Button_Uebertragen = New System.Windows.Forms.Button()
        Me.TextBox_Ergebniss = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label_Select
        '
        Me.Label_Select.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label_Select.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Select.Location = New System.Drawing.Point(10, 9)
        Me.Label_Select.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Select.Name = "Label_Select"
        Me.Label_Select.Size = New System.Drawing.Size(379, 50)
        Me.Label_Select.TabIndex = 0
        Me.Label_Select.Text = "Label_Select"
        Me.Label_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_Uebertragen
        '
        Me.Button_Uebertragen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Uebertragen.Location = New System.Drawing.Point(10, 437)
        Me.Button_Uebertragen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_Uebertragen.Name = "Button_Uebertragen"
        Me.Button_Uebertragen.Size = New System.Drawing.Size(379, 50)
        Me.Button_Uebertragen.TabIndex = 1
        Me.Button_Uebertragen.Text = "Auf Zeichnung Übertragen"
        Me.Button_Uebertragen.UseMnemonic = False
        Me.Button_Uebertragen.UseVisualStyleBackColor = True
        '
        'TextBox_Ergebniss
        '
        Me.TextBox_Ergebniss.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox_Ergebniss.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Ergebniss.Location = New System.Drawing.Point(10, 63)
        Me.TextBox_Ergebniss.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_Ergebniss.Multiline = True
        Me.TextBox_Ergebniss.Name = "TextBox_Ergebniss"
        Me.TextBox_Ergebniss.ReadOnly = True
        Me.TextBox_Ergebniss.Size = New System.Drawing.Size(379, 367)
        Me.TextBox_Ergebniss.TabIndex = 2
        '
        'Form_Traegheit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 499)
        Me.Controls.Add(Me.TextBox_Ergebniss)
        Me.Controls.Add(Me.Button_Uebertragen)
        Me.Controls.Add(Me.Label_Select)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Form_Traegheit"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form_Traegheit"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Select As System.Windows.Forms.Label
    Friend WithEvents Button_Uebertragen As System.Windows.Forms.Button
    Friend WithEvents TextBox_Ergebniss As System.Windows.Forms.TextBox
End Class
