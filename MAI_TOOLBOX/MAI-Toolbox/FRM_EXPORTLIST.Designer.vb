<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_EXPORTLIST
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
        Me.LB_FILES = New System.Windows.Forms.ListBox()
        Me.BT_ListeLoeschen = New System.Windows.Forms.Button()
        Me.BT_ZeileLoeschen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LB_FILES
        '
        Me.LB_FILES.FormattingEnabled = True
        Me.LB_FILES.ItemHeight = 16
        Me.LB_FILES.Location = New System.Drawing.Point(16, 15)
        Me.LB_FILES.Margin = New System.Windows.Forms.Padding(4)
        Me.LB_FILES.Name = "LB_FILES"
        Me.LB_FILES.ScrollAlwaysVisible = True
        Me.LB_FILES.Size = New System.Drawing.Size(345, 228)
        Me.LB_FILES.TabIndex = 0
        '
        'BT_ListeLoeschen
        '
        Me.BT_ListeLoeschen.Location = New System.Drawing.Point(244, 251)
        Me.BT_ListeLoeschen.Margin = New System.Windows.Forms.Padding(4)
        Me.BT_ListeLoeschen.Name = "BT_ListeLoeschen"
        Me.BT_ListeLoeschen.Size = New System.Drawing.Size(117, 28)
        Me.BT_ListeLoeschen.TabIndex = 1
        Me.BT_ListeLoeschen.Text = "Liste Löschen"
        Me.BT_ListeLoeschen.UseVisualStyleBackColor = True
        '
        'BT_ZeileLoeschen
        '
        Me.BT_ZeileLoeschen.Location = New System.Drawing.Point(16, 251)
        Me.BT_ZeileLoeschen.Margin = New System.Windows.Forms.Padding(4)
        Me.BT_ZeileLoeschen.Name = "BT_ZeileLoeschen"
        Me.BT_ZeileLoeschen.Size = New System.Drawing.Size(117, 28)
        Me.BT_ZeileLoeschen.TabIndex = 2
        Me.BT_ZeileLoeschen.Text = "Zeile Löschen"
        Me.BT_ZeileLoeschen.UseVisualStyleBackColor = True
        '
        'FRM_EXPORTLIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 285)
        Me.Controls.Add(Me.BT_ZeileLoeschen)
        Me.Controls.Add(Me.BT_ListeLoeschen)
        Me.Controls.Add(Me.LB_FILES)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FRM_EXPORTLIST"
        Me.Text = "Exportliste"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LB_FILES As System.Windows.Forms.ListBox
    Friend WithEvents BT_ListeLoeschen As System.Windows.Forms.Button
    Friend WithEvents BT_ZeileLoeschen As System.Windows.Forms.Button
End Class
