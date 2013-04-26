<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_IMPORT_EIGENSCH
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_Bezeichnung = New System.Windows.Forms.ComboBox()
        Me.CB_Bestellnummer = New System.Windows.Forms.ComboBox()
        Me.CB_Hersteller = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LBL_Info = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bezeichnung"
        '
        'CB_Bezeichnung
        '
        Me.CB_Bezeichnung.FormattingEnabled = True
        Me.CB_Bezeichnung.Location = New System.Drawing.Point(127, 47)
        Me.CB_Bezeichnung.Name = "CB_Bezeichnung"
        Me.CB_Bezeichnung.Size = New System.Drawing.Size(279, 21)
        Me.CB_Bezeichnung.TabIndex = 1
        '
        'CB_Bestellnummer
        '
        Me.CB_Bestellnummer.FormattingEnabled = True
        Me.CB_Bestellnummer.Location = New System.Drawing.Point(127, 74)
        Me.CB_Bestellnummer.Name = "CB_Bestellnummer"
        Me.CB_Bestellnummer.Size = New System.Drawing.Size(279, 21)
        Me.CB_Bestellnummer.TabIndex = 9
        '
        'CB_Hersteller
        '
        Me.CB_Hersteller.FormattingEnabled = True
        Me.CB_Hersteller.Location = New System.Drawing.Point(127, 101)
        Me.CB_Hersteller.Name = "CB_Hersteller"
        Me.CB_Hersteller.Size = New System.Drawing.Size(279, 21)
        Me.CB_Hersteller.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Bestellnummer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Hersteller"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(10, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 55)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Abbrechen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(214, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(194, 55)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Übernehmen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LBL_Info
        '
        Me.LBL_Info.AutoSize = True
        Me.LBL_Info.Location = New System.Drawing.Point(188, 153)
        Me.LBL_Info.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBL_Info.Name = "LBL_Info"
        Me.LBL_Info.Size = New System.Drawing.Size(39, 13)
        Me.LBL_Info.TabIndex = 17
        Me.LBL_Info.Text = "Label4"
        Me.LBL_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FRM_IMPORT_EIGENSCH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 274)
        Me.Controls.Add(Me.LBL_Info)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CB_Hersteller)
        Me.Controls.Add(Me.CB_Bestellnummer)
        Me.Controls.Add(Me.CB_Bezeichnung)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_IMPORT_EIGENSCH"
        Me.Text = "Kaufteileigenschaften"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_Bezeichnung As System.Windows.Forms.ComboBox
    Friend WithEvents CB_Bestellnummer As System.Windows.Forms.ComboBox
    Friend WithEvents CB_Hersteller As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LBL_Info As System.Windows.Forms.Label
End Class
