<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_HubEinstellen
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
        Me.BTN_Abort = New System.Windows.Forms.Button()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.TB_Hubges = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Hubein = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_Hubaus = New System.Windows.Forms.TextBox()
        Me.LBL_abs = New System.Windows.Forms.Label()
        Me.Label_Select1 = New System.Windows.Forms.Label()
        Me.Label_Select2 = New System.Windows.Forms.Label()
        Me.ListBox_Konfigurationen = New System.Windows.Forms.ListBox()
        Me.TextBox_hub = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BTN_Abort
        '
        Me.BTN_Abort.Location = New System.Drawing.Point(143, 499)
        Me.BTN_Abort.Name = "BTN_Abort"
        Me.BTN_Abort.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Abort.TabIndex = 0
        Me.BTN_Abort.Text = "Abbrechen"
        Me.BTN_Abort.UseVisualStyleBackColor = True
        '
        'BTN_OK
        '
        Me.BTN_OK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BTN_OK.Location = New System.Drawing.Point(50, 499)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(87, 23)
        Me.BTN_OK.TabIndex = 1
        Me.BTN_OK.Text = "Übernehmen"
        Me.BTN_OK.UseVisualStyleBackColor = True
        '
        'TB_Hubges
        '
        Me.TB_Hubges.Location = New System.Drawing.Point(118, 410)
        Me.TB_Hubges.Name = "TB_Hubges"
        Me.TB_Hubges.Size = New System.Drawing.Size(100, 20)
        Me.TB_Hubges.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 413)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Gesamthub"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 439)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "eingefahren"
        '
        'TB_Hubein
        '
        Me.TB_Hubein.Location = New System.Drawing.Point(118, 436)
        Me.TB_Hubein.Name = "TB_Hubein"
        Me.TB_Hubein.Size = New System.Drawing.Size(100, 20)
        Me.TB_Hubein.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 465)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ausgefahren"
        '
        'TB_Hubaus
        '
        Me.TB_Hubaus.Location = New System.Drawing.Point(118, 462)
        Me.TB_Hubaus.Name = "TB_Hubaus"
        Me.TB_Hubaus.Size = New System.Drawing.Size(100, 20)
        Me.TB_Hubaus.TabIndex = 6
        '
        'LBL_abs
        '
        Me.LBL_abs.AutoSize = True
        Me.LBL_abs.Location = New System.Drawing.Point(140, 136)
        Me.LBL_abs.Name = "LBL_abs"
        Me.LBL_abs.Size = New System.Drawing.Size(46, 13)
        Me.LBL_abs.TabIndex = 8
        Me.LBL_abs.Text = "Abstand"
        '
        'Label_Select1
        '
        Me.Label_Select1.BackColor = System.Drawing.Color.Salmon
        Me.Label_Select1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_Select1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Select1.Location = New System.Drawing.Point(12, 9)
        Me.Label_Select1.Name = "Label_Select1"
        Me.Label_Select1.Size = New System.Drawing.Size(325, 54)
        Me.Label_Select1.TabIndex = 9
        Me.Label_Select1.Text = "Label_Select1"
        Me.Label_Select1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Select2
        '
        Me.Label_Select2.BackColor = System.Drawing.Color.Salmon
        Me.Label_Select2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_Select2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Select2.Location = New System.Drawing.Point(12, 72)
        Me.Label_Select2.Name = "Label_Select2"
        Me.Label_Select2.Size = New System.Drawing.Size(325, 54)
        Me.Label_Select2.TabIndex = 10
        Me.Label_Select2.Text = "Label_Select2"
        Me.Label_Select2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListBox_Konfigurationen
        '
        Me.ListBox_Konfigurationen.FormattingEnabled = True
        Me.ListBox_Konfigurationen.Location = New System.Drawing.Point(12, 172)
        Me.ListBox_Konfigurationen.Name = "ListBox_Konfigurationen"
        Me.ListBox_Konfigurationen.Size = New System.Drawing.Size(156, 95)
        Me.ListBox_Konfigurationen.TabIndex = 11
        '
        'TextBox_hub
        '
        Me.TextBox_hub.Location = New System.Drawing.Point(226, 209)
        Me.TextBox_hub.Name = "TextBox_hub"
        Me.TextBox_hub.Size = New System.Drawing.Size(111, 20)
        Me.TextBox_hub.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Hub"
        '
        'Form_HubEinstellen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 600)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_hub)
        Me.Controls.Add(Me.ListBox_Konfigurationen)
        Me.Controls.Add(Me.Label_Select2)
        Me.Controls.Add(Me.Label_Select1)
        Me.Controls.Add(Me.LBL_abs)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB_Hubaus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_Hubein)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_Hubges)
        Me.Controls.Add(Me.BTN_OK)
        Me.Controls.Add(Me.BTN_Abort)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_HubEinstellen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hub Einstellen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_Abort As System.Windows.Forms.Button
    Friend WithEvents BTN_OK As System.Windows.Forms.Button
    Friend WithEvents TB_Hubges As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Hubein As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Hubaus As System.Windows.Forms.TextBox
    Friend WithEvents LBL_abs As System.Windows.Forms.Label
    Friend WithEvents Label_Select1 As System.Windows.Forms.Label
    Friend WithEvents Label_Select2 As System.Windows.Forms.Label
    Friend WithEvents ListBox_Konfigurationen As System.Windows.Forms.ListBox
    Friend WithEvents TextBox_hub As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
