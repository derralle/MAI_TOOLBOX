<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Baugruppenmeister
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BTN_Refresh = New System.Windows.Forms.Button()
        Me.BTN_Changed = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CB_HBG_einbeziehen = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Stueckzahl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TeilenummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestellnummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HerstellerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IstFertigungsteilDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IstKaufteilDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IstHilfsteilDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IstHilfsBG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.KonstrukteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bemerkung1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bemerkung2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bemerkung3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NotizDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dateiname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Konfiguration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BaugruppeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BG_Dataset = New MAI_TOOLBOX.BG_Dataset()
        Me.DGV_CTMS1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_oeffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Baugruppennummer = New System.Windows.Forms.TextBox()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripTextBox()
        Me.TSMI_mehrere = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BaugruppeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BG_Dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DGV_CTMS1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_Refresh
        '
        Me.BTN_Refresh.Location = New System.Drawing.Point(8, 23)
        Me.BTN_Refresh.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_Refresh.Name = "BTN_Refresh"
        Me.BTN_Refresh.Size = New System.Drawing.Size(116, 54)
        Me.BTN_Refresh.TabIndex = 2
        Me.BTN_Refresh.Text = "Refresh"
        Me.BTN_Refresh.UseVisualStyleBackColor = True
        '
        'BTN_Changed
        '
        Me.BTN_Changed.Location = New System.Drawing.Point(132, 23)
        Me.BTN_Changed.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_Changed.Name = "BTN_Changed"
        Me.BTN_Changed.Size = New System.Drawing.Size(121, 54)
        Me.BTN_Changed.TabIndex = 3
        Me.BTN_Changed.Text = "Änderungen übernehmen"
        Me.BTN_Changed.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.CB_HBG_einbeziehen)
        Me.GroupBox1.Controls.Add(Me.BTN_Changed)
        Me.GroupBox1.Controls.Add(Me.BTN_Refresh)
        Me.GroupBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 539)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1587, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'CB_HBG_einbeziehen
        '
        Me.CB_HBG_einbeziehen.AutoSize = True
        Me.CB_HBG_einbeziehen.Location = New System.Drawing.Point(261, 23)
        Me.CB_HBG_einbeziehen.Margin = New System.Windows.Forms.Padding(4)
        Me.CB_HBG_einbeziehen.Name = "CB_HBG_einbeziehen"
        Me.CB_HBG_einbeziehen.Size = New System.Drawing.Size(215, 21)
        Me.CB_HBG_einbeziehen.TabIndex = 4
        Me.CB_HBG_einbeziehen.Text = "Hilfsbaugruppen einbeziehen"
        Me.CB_HBG_einbeziehen.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Stueckzahl, Me.TeilenummerDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.BestellnummerDataGridViewTextBoxColumn, Me.HerstellerDataGridViewTextBoxColumn, Me.IstFertigungsteilDataGridViewCheckBoxColumn, Me.IstKaufteilDataGridViewTextBoxColumn, Me.IstHilfsteilDataGridViewTextBoxColumn, Me.IstHilfsBG, Me.KonstrukteurDataGridViewTextBoxColumn, Me.Bemerkung1DataGridViewTextBoxColumn, Me.Bemerkung2DataGridViewTextBoxColumn, Me.Bemerkung3DataGridViewTextBoxColumn, Me.NotizDataGridViewTextBoxColumn, Me.Dateiname, Me.Konfiguration})
        Me.DataGridView1.DataSource = Me.BaugruppeBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(13, 90)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.ContextMenuStrip = Me.DGV_CTMS1
        Me.DataGridView1.Size = New System.Drawing.Size(1560, 441)
        Me.DataGridView1.TabIndex = 0
        '
        'Stueckzahl
        '
        Me.Stueckzahl.DataPropertyName = "Stueckzahl"
        Me.Stueckzahl.HeaderText = "Stückzahl"
        Me.Stueckzahl.Name = "Stueckzahl"
        Me.Stueckzahl.ReadOnly = True
        Me.Stueckzahl.Width = 94
        '
        'TeilenummerDataGridViewTextBoxColumn
        '
        Me.TeilenummerDataGridViewTextBoxColumn.DataPropertyName = "Teilenummer"
        Me.TeilenummerDataGridViewTextBoxColumn.HeaderText = "Teilenummer"
        Me.TeilenummerDataGridViewTextBoxColumn.Name = "TeilenummerDataGridViewTextBoxColumn"
        Me.TeilenummerDataGridViewTextBoxColumn.Width = 115
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 70
        '
        'BestellnummerDataGridViewTextBoxColumn
        '
        Me.BestellnummerDataGridViewTextBoxColumn.DataPropertyName = "Bestellnummer"
        Me.BestellnummerDataGridViewTextBoxColumn.HeaderText = "Bestellnummer"
        Me.BestellnummerDataGridViewTextBoxColumn.Name = "BestellnummerDataGridViewTextBoxColumn"
        Me.BestellnummerDataGridViewTextBoxColumn.Width = 126
        '
        'HerstellerDataGridViewTextBoxColumn
        '
        Me.HerstellerDataGridViewTextBoxColumn.DataPropertyName = "Hersteller"
        Me.HerstellerDataGridViewTextBoxColumn.HeaderText = "Hersteller"
        Me.HerstellerDataGridViewTextBoxColumn.Name = "HerstellerDataGridViewTextBoxColumn"
        Me.HerstellerDataGridViewTextBoxColumn.Width = 94
        '
        'IstFertigungsteilDataGridViewCheckBoxColumn
        '
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.DataPropertyName = "IstFertigungsteil"
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.HeaderText = "FT"
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.Name = "IstFertigungsteilDataGridViewCheckBoxColumn"
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.Width = 26
        '
        'IstKaufteilDataGridViewTextBoxColumn
        '
        Me.IstKaufteilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IstKaufteilDataGridViewTextBoxColumn.DataPropertyName = "IstKaufteil"
        Me.IstKaufteilDataGridViewTextBoxColumn.HeaderText = "KT"
        Me.IstKaufteilDataGridViewTextBoxColumn.Name = "IstKaufteilDataGridViewTextBoxColumn"
        Me.IstKaufteilDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IstKaufteilDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IstKaufteilDataGridViewTextBoxColumn.Width = 26
        '
        'IstHilfsteilDataGridViewTextBoxColumn
        '
        Me.IstHilfsteilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IstHilfsteilDataGridViewTextBoxColumn.DataPropertyName = "IstHilfsteil"
        Me.IstHilfsteilDataGridViewTextBoxColumn.HeaderText = "HT"
        Me.IstHilfsteilDataGridViewTextBoxColumn.Name = "IstHilfsteilDataGridViewTextBoxColumn"
        Me.IstHilfsteilDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IstHilfsteilDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IstHilfsteilDataGridViewTextBoxColumn.Width = 26
        '
        'IstHilfsBG
        '
        Me.IstHilfsBG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IstHilfsBG.DataPropertyName = "IstHilfsBG"
        Me.IstHilfsBG.HeaderText = "HBG"
        Me.IstHilfsBG.Name = "IstHilfsBG"
        Me.IstHilfsBG.Width = 32
        '
        'KonstrukteurDataGridViewTextBoxColumn
        '
        Me.KonstrukteurDataGridViewTextBoxColumn.DataPropertyName = "Konstrukteur"
        Me.KonstrukteurDataGridViewTextBoxColumn.HeaderText = "Konstrukteur"
        Me.KonstrukteurDataGridViewTextBoxColumn.Name = "KonstrukteurDataGridViewTextBoxColumn"
        Me.KonstrukteurDataGridViewTextBoxColumn.Width = 114
        '
        'Bemerkung1DataGridViewTextBoxColumn
        '
        Me.Bemerkung1DataGridViewTextBoxColumn.DataPropertyName = "Bemerkung1"
        Me.Bemerkung1DataGridViewTextBoxColumn.HeaderText = "Bemerkung1"
        Me.Bemerkung1DataGridViewTextBoxColumn.Name = "Bemerkung1DataGridViewTextBoxColumn"
        Me.Bemerkung1DataGridViewTextBoxColumn.Width = 113
        '
        'Bemerkung2DataGridViewTextBoxColumn
        '
        Me.Bemerkung2DataGridViewTextBoxColumn.DataPropertyName = "Bemerkung2"
        Me.Bemerkung2DataGridViewTextBoxColumn.HeaderText = "Bemerkung2"
        Me.Bemerkung2DataGridViewTextBoxColumn.Name = "Bemerkung2DataGridViewTextBoxColumn"
        Me.Bemerkung2DataGridViewTextBoxColumn.Width = 113
        '
        'Bemerkung3DataGridViewTextBoxColumn
        '
        Me.Bemerkung3DataGridViewTextBoxColumn.DataPropertyName = "Bemerkung3"
        Me.Bemerkung3DataGridViewTextBoxColumn.HeaderText = "Bemerkung3"
        Me.Bemerkung3DataGridViewTextBoxColumn.Name = "Bemerkung3DataGridViewTextBoxColumn"
        Me.Bemerkung3DataGridViewTextBoxColumn.Width = 113
        '
        'NotizDataGridViewTextBoxColumn
        '
        Me.NotizDataGridViewTextBoxColumn.DataPropertyName = "Notiz"
        Me.NotizDataGridViewTextBoxColumn.HeaderText = "Notiz"
        Me.NotizDataGridViewTextBoxColumn.Name = "NotizDataGridViewTextBoxColumn"
        Me.NotizDataGridViewTextBoxColumn.Width = 65
        '
        'Dateiname
        '
        Me.Dateiname.DataPropertyName = "Dateiname"
        Me.Dateiname.HeaderText = "Dateiname"
        Me.Dateiname.Name = "Dateiname"
        Me.Dateiname.Width = 101
        '
        'Konfiguration
        '
        Me.Konfiguration.DataPropertyName = "Konfiguration"
        Me.Konfiguration.HeaderText = "Konfiguration"
        Me.Konfiguration.Name = "Konfiguration"
        Me.Konfiguration.Width = 117
        '
        'BaugruppeBindingSource
        '
        Me.BaugruppeBindingSource.DataMember = "Baugruppe"
        Me.BaugruppeBindingSource.DataSource = Me.BG_Dataset
        '
        'BG_Dataset
        '
        Me.BG_Dataset.DataSetName = "BG_Dataset"
        Me.BG_Dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DGV_CTMS1
        '
        Me.DGV_CTMS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_oeffnen, Me.TSMI_mehrere})
        Me.DGV_CTMS1.Name = "DGV_CTMS1"
        Me.DGV_CTMS1.Size = New System.Drawing.Size(282, 74)
        '
        'TSMI_oeffnen
        '
        Me.TSMI_oeffnen.Name = "TSMI_oeffnen"
        Me.TSMI_oeffnen.Size = New System.Drawing.Size(281, 24)
        Me.TSMI_oeffnen.Text = "Teil öffnen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox_Baugruppennummer)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 1)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1580, 81)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Baugruppe"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button2.Location = New System.Drawing.Point(1419, 14)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(148, 59)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "alle Fertigungsteile in BG-Verzeichnis verschieben"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(320, 14)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 60)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "für alle Teile ändern"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(8, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nummer der Baugruppe"
        '
        'TextBox_Baugruppennummer
        '
        Me.TextBox_Baugruppennummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Baugruppennummer.Location = New System.Drawing.Point(8, 46)
        Me.TextBox_Baugruppennummer.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Baugruppennummer.Name = "TextBox_Baugruppennummer"
        Me.TextBox_Baugruppennummer.Size = New System.Drawing.Size(303, 26)
        Me.TextBox_Baugruppennummer.TabIndex = 2
        Me.TextBox_Baugruppennummer.Text = "00.00.00"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(160, 23)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'TSMI_mehrere
        '
        Me.TSMI_mehrere.Name = "TSMI_mehrere"
        Me.TSMI_mehrere.Size = New System.Drawing.Size(281, 24)
        Me.TSMI_mehrere.Text = "mehrere Einträge bearbeiten ..."
        '
        'FRM_Baugruppenmeister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1587, 639)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FRM_Baugruppenmeister"
        Me.Text = "Baugruppenmeister"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BaugruppeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BG_Dataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DGV_CTMS1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BaugruppeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BG_Dataset As MAI_TOOLBOX.BG_Dataset
    Friend WithEvents BTN_Refresh As System.Windows.Forms.Button
    Friend WithEvents BTN_Changed As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV_CTMS1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_oeffnen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CB_HBG_einbeziehen As System.Windows.Forms.CheckBox
    Friend WithEvents Stueckzahl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeilenummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestellnummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HerstellerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IstFertigungsteilDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IstKaufteilDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IstHilfsteilDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IstHilfsBG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents KonstrukteurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bemerkung1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bemerkung2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bemerkung3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NotizDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dateiname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Konfiguration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Baugruppennummer As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TSMI_mehrere As System.Windows.Forms.ToolStripMenuItem
End Class
