<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Zylinderkonfig
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
        Me.SuspendLayout()
        '
        'BTN_Abort
        '
        Me.BTN_Abort.Location = New System.Drawing.Point(112, 137)
        Me.BTN_Abort.Name = "BTN_Abort"
        Me.BTN_Abort.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Abort.TabIndex = 0
        Me.BTN_Abort.Text = "Abbrechen"
        Me.BTN_Abort.UseVisualStyleBackColor = True
        '
        'BTN_OK
        '
        Me.BTN_OK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BTN_OK.Location = New System.Drawing.Point(19, 137)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(87, 23)
        Me.BTN_OK.TabIndex = 1
        Me.BTN_OK.Text = "Übernehmen"
        Me.BTN_OK.UseVisualStyleBackColor = True
        '
        'TB_Hubges
        '
        Me.TB_Hubges.Location = New System.Drawing.Point(87, 48)
        Me.TB_Hubges.Name = "TB_Hubges"
        Me.TB_Hubges.Size = New System.Drawing.Size(100, 20)
        Me.TB_Hubges.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Gesamthub"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "eingefahren"
        '
        'TB_Hubein
        '
        Me.TB_Hubein.Location = New System.Drawing.Point(87, 74)
        Me.TB_Hubein.Name = "TB_Hubein"
        Me.TB_Hubein.Size = New System.Drawing.Size(100, 20)
        Me.TB_Hubein.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ausgefahren"
        '
        'TB_Hubaus
        '
        Me.TB_Hubaus.Location = New System.Drawing.Point(87, 100)
        Me.TB_Hubaus.Name = "TB_Hubaus"
        Me.TB_Hubaus.Size = New System.Drawing.Size(100, 20)
        Me.TB_Hubaus.TabIndex = 6
        '
        'LBL_abs
        '
        Me.LBL_abs.AutoSize = True
        Me.LBL_abs.Location = New System.Drawing.Point(22, 9)
        Me.LBL_abs.Name = "LBL_abs"
        Me.LBL_abs.Size = New System.Drawing.Size(46, 13)
        Me.LBL_abs.TabIndex = 8
        Me.LBL_abs.Text = "Abstand"
        '
        'FRM_Zylinderkonfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(199, 176)
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
        Me.Name = "FRM_Zylinderkonfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FRM_Zylinderkonfig"
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
End Class
