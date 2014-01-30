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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Stueckzahl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TeilenummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HerstellerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IstFertigungsteilDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IstKaufteilDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IstHilfsteilDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ZeichnerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KonstrukteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestellnummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bemerkung1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bemerkung2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bemerkung3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NotizDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BaugruppeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BG_Dataset = New MAI_TOOLBOX.BG_Dataset()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BaugruppeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BG_Dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Stueckzahl, Me.NameDataGridViewTextBoxColumn, Me.TeilenummerDataGridViewTextBoxColumn, Me.HerstellerDataGridViewTextBoxColumn, Me.IstFertigungsteilDataGridViewCheckBoxColumn, Me.IstKaufteilDataGridViewTextBoxColumn, Me.IstHilfsteilDataGridViewTextBoxColumn, Me.ZeichnerDataGridViewTextBoxColumn, Me.KonstrukteurDataGridViewTextBoxColumn, Me.BestellnummerDataGridViewTextBoxColumn, Me.Bemerkung1DataGridViewTextBoxColumn, Me.Bemerkung2DataGridViewTextBoxColumn, Me.Bemerkung3DataGridViewTextBoxColumn, Me.NotizDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BaugruppeBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1186, 468)
        Me.DataGridView1.TabIndex = 0
        '
        'Stueckzahl
        '
        Me.Stueckzahl.DataPropertyName = "Stueckzahl"
        Me.Stueckzahl.HeaderText = "Stückzahl"
        Me.Stueckzahl.Name = "Stueckzahl"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(87, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1186, 557)
        Me.Panel1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 474)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1186, 83)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        '
        'TeilenummerDataGridViewTextBoxColumn
        '
        Me.TeilenummerDataGridViewTextBoxColumn.DataPropertyName = "Teilenummer"
        Me.TeilenummerDataGridViewTextBoxColumn.HeaderText = "Teilenummer"
        Me.TeilenummerDataGridViewTextBoxColumn.Name = "TeilenummerDataGridViewTextBoxColumn"
        '
        'HerstellerDataGridViewTextBoxColumn
        '
        Me.HerstellerDataGridViewTextBoxColumn.DataPropertyName = "Hersteller"
        Me.HerstellerDataGridViewTextBoxColumn.HeaderText = "Hersteller"
        Me.HerstellerDataGridViewTextBoxColumn.Name = "HerstellerDataGridViewTextBoxColumn"
        '
        'IstFertigungsteilDataGridViewCheckBoxColumn
        '
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.DataPropertyName = "IstFertigungsteil"
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.HeaderText = "IstFertigungsteil"
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.Name = "IstFertigungsteilDataGridViewCheckBoxColumn"
        Me.IstFertigungsteilDataGridViewCheckBoxColumn.Width = 86
        '
        'IstKaufteilDataGridViewTextBoxColumn
        '
        Me.IstKaufteilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IstKaufteilDataGridViewTextBoxColumn.DataPropertyName = "IstKaufteil"
        Me.IstKaufteilDataGridViewTextBoxColumn.HeaderText = "IstKaufteil"
        Me.IstKaufteilDataGridViewTextBoxColumn.Name = "IstKaufteilDataGridViewTextBoxColumn"
        Me.IstKaufteilDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IstKaufteilDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IstKaufteilDataGridViewTextBoxColumn.Width = 78
        '
        'IstHilfsteilDataGridViewTextBoxColumn
        '
        Me.IstHilfsteilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IstHilfsteilDataGridViewTextBoxColumn.DataPropertyName = "IstHilfsteil"
        Me.IstHilfsteilDataGridViewTextBoxColumn.HeaderText = "IstHilfsteil"
        Me.IstHilfsteilDataGridViewTextBoxColumn.Name = "IstHilfsteilDataGridViewTextBoxColumn"
        Me.IstHilfsteilDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IstHilfsteilDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IstHilfsteilDataGridViewTextBoxColumn.Width = 76
        '
        'ZeichnerDataGridViewTextBoxColumn
        '
        Me.ZeichnerDataGridViewTextBoxColumn.DataPropertyName = "Zeichner"
        Me.ZeichnerDataGridViewTextBoxColumn.HeaderText = "Zeichner"
        Me.ZeichnerDataGridViewTextBoxColumn.Name = "ZeichnerDataGridViewTextBoxColumn"
        '
        'KonstrukteurDataGridViewTextBoxColumn
        '
        Me.KonstrukteurDataGridViewTextBoxColumn.DataPropertyName = "Konstrukteur"
        Me.KonstrukteurDataGridViewTextBoxColumn.HeaderText = "Konstrukteur"
        Me.KonstrukteurDataGridViewTextBoxColumn.Name = "KonstrukteurDataGridViewTextBoxColumn"
        '
        'BestellnummerDataGridViewTextBoxColumn
        '
        Me.BestellnummerDataGridViewTextBoxColumn.DataPropertyName = "Bestellnummer"
        Me.BestellnummerDataGridViewTextBoxColumn.HeaderText = "Bestellnummer"
        Me.BestellnummerDataGridViewTextBoxColumn.Name = "BestellnummerDataGridViewTextBoxColumn"
        '
        'Bemerkung1DataGridViewTextBoxColumn
        '
        Me.Bemerkung1DataGridViewTextBoxColumn.DataPropertyName = "Bemerkung1"
        Me.Bemerkung1DataGridViewTextBoxColumn.HeaderText = "Bemerkung1"
        Me.Bemerkung1DataGridViewTextBoxColumn.Name = "Bemerkung1DataGridViewTextBoxColumn"
        '
        'Bemerkung2DataGridViewTextBoxColumn
        '
        Me.Bemerkung2DataGridViewTextBoxColumn.DataPropertyName = "Bemerkung2"
        Me.Bemerkung2DataGridViewTextBoxColumn.HeaderText = "Bemerkung2"
        Me.Bemerkung2DataGridViewTextBoxColumn.Name = "Bemerkung2DataGridViewTextBoxColumn"
        '
        'Bemerkung3DataGridViewTextBoxColumn
        '
        Me.Bemerkung3DataGridViewTextBoxColumn.DataPropertyName = "Bemerkung3"
        Me.Bemerkung3DataGridViewTextBoxColumn.HeaderText = "Bemerkung3"
        Me.Bemerkung3DataGridViewTextBoxColumn.Name = "Bemerkung3DataGridViewTextBoxColumn"
        '
        'NotizDataGridViewTextBoxColumn
        '
        Me.NotizDataGridViewTextBoxColumn.DataPropertyName = "Notiz"
        Me.NotizDataGridViewTextBoxColumn.HeaderText = "Notiz"
        Me.NotizDataGridViewTextBoxColumn.Name = "NotizDataGridViewTextBoxColumn"
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
        'FRM_Baugruppenmeister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 557)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FRM_Baugruppenmeister"
        Me.Text = "FRM_Baugruppenmeister"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.BaugruppeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BG_Dataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BaugruppeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BG_Dataset As MAI_TOOLBOX.BG_Dataset
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Stueckzahl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeilenummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HerstellerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IstFertigungsteilDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IstKaufteilDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IstHilfsteilDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ZeichnerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KonstrukteurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestellnummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bemerkung1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bemerkung2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bemerkung3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NotizDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
