<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Blotter_Report
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton5 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.DataGridView7 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MetroPanel4 = New MetroFramework.Controls.MetroPanel()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.RichTextBox4 = New System.Windows.Forms.RichTextBox()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.MetroTextBox9 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox10 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel12 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel13 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.MetroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton6 = New MetroFramework.Controls.MetroButton()
        Me.MetroComboBox1 = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel14 = New MetroFramework.Controls.MetroLabel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.MetroTextBox3 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel15 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox2 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel16 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel17 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel18 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox4 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel19 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel1.SuspendLayout()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MetroPanel4.SuspendLayout()
        Me.MetroPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.MetroButton4)
        Me.MetroPanel1.Controls.Add(Me.MetroButton5)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel7)
        Me.MetroPanel1.Controls.Add(Me.DataGridView7)
        Me.MetroPanel1.Controls.Add(Me.MetroPanel4)
        Me.MetroPanel1.Controls.Add(Me.MetroPanel2)
        Me.MetroPanel1.Controls.Add(Me.MetroTextBox4)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel19)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 6
        Me.MetroPanel1.Location = New System.Drawing.Point(0, 0)
        Me.MetroPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(1219, 609)
        Me.MetroPanel1.TabIndex = 17
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 7
        '
        'MetroButton4
        '
        Me.MetroButton4.Location = New System.Drawing.Point(762, 561)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(105, 32)
        Me.MetroButton4.TabIndex = 24
        Me.MetroButton4.Text = "Publish"
        Me.MetroButton4.UseSelectable = True
        '
        'MetroButton5
        '
        Me.MetroButton5.Location = New System.Drawing.Point(651, 561)
        Me.MetroButton5.Name = "MetroButton5"
        Me.MetroButton5.Size = New System.Drawing.Size(105, 32)
        Me.MetroButton5.TabIndex = 23
        Me.MetroButton5.Text = "Cancel"
        Me.MetroButton5.UseSelectable = True
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel7.Location = New System.Drawing.Point(652, 18)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(104, 19)
        Me.MetroLabel7.TabIndex = 17
        Me.MetroLabel7.Text = "People Involved:"
        '
        'DataGridView7
        '
        Me.DataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView7.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.Age, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36})
        Me.DataGridView7.Location = New System.Drawing.Point(652, 55)
        Me.DataGridView7.Name = "DataGridView7"
        Me.DataGridView7.Size = New System.Drawing.Size(555, 502)
        Me.DataGridView7.TabIndex = 22
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn32.HeaderText = "#"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.Width = 39
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn33.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn34.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'Age
        '
        Me.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Age.HeaderText = "Age"
        Me.Age.Name = "Age"
        Me.Age.Width = 51
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn35.HeaderText = "Contact Number"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn36.HeaderText = "Classification"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.Width = 93
        '
        'MetroPanel4
        '
        Me.MetroPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel8)
        Me.MetroPanel4.Controls.Add(Me.RichTextBox4)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel10)
        Me.MetroPanel4.Controls.Add(Me.RichTextBox3)
        Me.MetroPanel4.Controls.Add(Me.MetroTextBox9)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel11)
        Me.MetroPanel4.Controls.Add(Me.MetroTextBox10)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel12)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel13)
        Me.MetroPanel4.HorizontalScrollbarBarColor = True
        Me.MetroPanel4.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel4.HorizontalScrollbarSize = 6
        Me.MetroPanel4.Location = New System.Drawing.Point(13, 313)
        Me.MetroPanel4.Margin = New System.Windows.Forms.Padding(2)
        Me.MetroPanel4.Name = "MetroPanel4"
        Me.MetroPanel4.Size = New System.Drawing.Size(630, 294)
        Me.MetroPanel4.TabIndex = 21
        Me.MetroPanel4.Tag = ""
        Me.MetroPanel4.VerticalScrollbarBarColor = True
        Me.MetroPanel4.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel4.VerticalScrollbarSize = 7
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = True
        Me.MetroLabel8.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroLabel8.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel8.Location = New System.Drawing.Point(0, 0)
        Me.MetroLabel8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(95, 15)
        Me.MetroLabel8.TabIndex = 18
        Me.MetroLabel8.Text = "Incident Report"
        '
        'RichTextBox4
        '
        Me.RichTextBox4.Location = New System.Drawing.Point(10, 181)
        Me.RichTextBox4.Name = "RichTextBox4"
        Me.RichTextBox4.Size = New System.Drawing.Size(608, 99)
        Me.RichTextBox4.TabIndex = 16
        Me.RichTextBox4.Text = ""
        '
        'MetroLabel10
        '
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(7, 159)
        Me.MetroLabel10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(179, 19)
        Me.MetroLabel10.TabIndex = 15
        Me.MetroLabel10.Text = "Address/Place of the Incident"
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(10, 73)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(608, 81)
        Me.RichTextBox3.TabIndex = 14
        Me.RichTextBox3.Text = ""
        '
        'MetroTextBox9
        '
        Me.MetroTextBox9.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.MetroTextBox9.CustomButton.Image = Nothing
        Me.MetroTextBox9.CustomButton.Location = New System.Drawing.Point(135, 1)
        Me.MetroTextBox9.CustomButton.Name = ""
        Me.MetroTextBox9.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox9.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox9.CustomButton.TabIndex = 1
        Me.MetroTextBox9.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox9.CustomButton.UseSelectable = True
        Me.MetroTextBox9.CustomButton.Visible = False
        Me.MetroTextBox9.Lines = New String(-1) {}
        Me.MetroTextBox9.Location = New System.Drawing.Point(460, 22)
        Me.MetroTextBox9.MaxLength = 32767
        Me.MetroTextBox9.Name = "MetroTextBox9"
        Me.MetroTextBox9.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox9.SelectedText = ""
        Me.MetroTextBox9.SelectionLength = 0
        Me.MetroTextBox9.SelectionStart = 0
        Me.MetroTextBox9.ShortcutsEnabled = True
        Me.MetroTextBox9.Size = New System.Drawing.Size(157, 23)
        Me.MetroTextBox9.TabIndex = 11
        Me.MetroTextBox9.UseSelectable = True
        Me.MetroTextBox9.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox9.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel11
        '
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel11.Location = New System.Drawing.Point(414, 24)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(41, 19)
        Me.MetroLabel11.TabIndex = 10
        Me.MetroLabel11.Text = "Time:"
        '
        'MetroTextBox10
        '
        Me.MetroTextBox10.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.MetroTextBox10.CustomButton.Image = Nothing
        Me.MetroTextBox10.CustomButton.Location = New System.Drawing.Point(135, 1)
        Me.MetroTextBox10.CustomButton.Name = ""
        Me.MetroTextBox10.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox10.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox10.CustomButton.TabIndex = 1
        Me.MetroTextBox10.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox10.CustomButton.UseSelectable = True
        Me.MetroTextBox10.CustomButton.Visible = False
        Me.MetroTextBox10.Lines = New String(-1) {}
        Me.MetroTextBox10.Location = New System.Drawing.Point(47, 21)
        Me.MetroTextBox10.MaxLength = 32767
        Me.MetroTextBox10.Name = "MetroTextBox10"
        Me.MetroTextBox10.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox10.SelectedText = ""
        Me.MetroTextBox10.SelectionLength = 0
        Me.MetroTextBox10.SelectionStart = 0
        Me.MetroTextBox10.ShortcutsEnabled = True
        Me.MetroTextBox10.Size = New System.Drawing.Size(157, 23)
        Me.MetroTextBox10.TabIndex = 9
        Me.MetroTextBox10.UseSelectable = True
        Me.MetroTextBox10.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox10.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel12
        '
        Me.MetroLabel12.AutoSize = True
        Me.MetroLabel12.Location = New System.Drawing.Point(7, 51)
        Me.MetroLabel12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel12.Name = "MetroLabel12"
        Me.MetroLabel12.Size = New System.Drawing.Size(166, 19)
        Me.MetroLabel12.TabIndex = 7
        Me.MetroLabel12.Text = "Statement of Complainant:"
        '
        'MetroLabel13
        '
        Me.MetroLabel13.AutoSize = True
        Me.MetroLabel13.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel13.Location = New System.Drawing.Point(7, 21)
        Me.MetroLabel13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel13.Name = "MetroLabel13"
        Me.MetroLabel13.Size = New System.Drawing.Size(39, 19)
        Me.MetroLabel13.TabIndex = 5
        Me.MetroLabel13.Text = "Date:"
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel9)
        Me.MetroPanel2.Controls.Add(Me.MetroButton6)
        Me.MetroPanel2.Controls.Add(Me.MetroComboBox1)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel14)
        Me.MetroPanel2.Controls.Add(Me.RichTextBox1)
        Me.MetroPanel2.Controls.Add(Me.MetroTextBox3)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel15)
        Me.MetroPanel2.Controls.Add(Me.MetroTextBox2)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel16)
        Me.MetroPanel2.Controls.Add(Me.MetroTextBox1)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel17)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel18)
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 6
        Me.MetroPanel2.Location = New System.Drawing.Point(13, 55)
        Me.MetroPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(630, 254)
        Me.MetroPanel2.TabIndex = 20
        Me.MetroPanel2.Tag = ""
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 7
        '
        'MetroLabel9
        '
        Me.MetroLabel9.AutoSize = True
        Me.MetroLabel9.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroLabel9.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel9.Location = New System.Drawing.Point(0, 0)
        Me.MetroLabel9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel9.Name = "MetroLabel9"
        Me.MetroLabel9.Size = New System.Drawing.Size(138, 15)
        Me.MetroLabel9.TabIndex = 26
        Me.MetroLabel9.Text = "Person Involved Details"
        '
        'MetroButton6
        '
        Me.MetroButton6.Location = New System.Drawing.Point(512, 203)
        Me.MetroButton6.Name = "MetroButton6"
        Me.MetroButton6.Size = New System.Drawing.Size(105, 32)
        Me.MetroButton6.TabIndex = 25
        Me.MetroButton6.Text = "Add"
        Me.MetroButton6.UseSelectable = True
        '
        'MetroComboBox1
        '
        Me.MetroComboBox1.FormattingEnabled = True
        Me.MetroComboBox1.ItemHeight = 23
        Me.MetroComboBox1.Items.AddRange(New Object() {"Complainant", "Defendant", "Witness"})
        Me.MetroComboBox1.Location = New System.Drawing.Point(97, 204)
        Me.MetroComboBox1.Name = "MetroComboBox1"
        Me.MetroComboBox1.Size = New System.Drawing.Size(121, 29)
        Me.MetroComboBox1.TabIndex = 16
        Me.MetroComboBox1.UseSelectable = True
        '
        'MetroLabel14
        '
        Me.MetroLabel14.AutoSize = True
        Me.MetroLabel14.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel14.Location = New System.Drawing.Point(10, 207)
        Me.MetroLabel14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel14.Name = "MetroLabel14"
        Me.MetroLabel14.Size = New System.Drawing.Size(90, 19)
        Me.MetroLabel14.TabIndex = 15
        Me.MetroLabel14.Text = "Classification: "
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(10, 73)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(608, 119)
        Me.RichTextBox1.TabIndex = 14
        Me.RichTextBox1.Text = ""
        '
        'MetroTextBox3
        '
        Me.MetroTextBox3.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.MetroTextBox3.CustomButton.Image = Nothing
        Me.MetroTextBox3.CustomButton.Location = New System.Drawing.Point(12, 1)
        Me.MetroTextBox3.CustomButton.Name = ""
        Me.MetroTextBox3.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox3.CustomButton.TabIndex = 1
        Me.MetroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox3.CustomButton.UseSelectable = True
        Me.MetroTextBox3.CustomButton.Visible = False
        Me.MetroTextBox3.Lines = New String(-1) {}
        Me.MetroTextBox3.Location = New System.Drawing.Point(581, 21)
        Me.MetroTextBox3.MaxLength = 32767
        Me.MetroTextBox3.Name = "MetroTextBox3"
        Me.MetroTextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox3.SelectedText = ""
        Me.MetroTextBox3.SelectionLength = 0
        Me.MetroTextBox3.SelectionStart = 0
        Me.MetroTextBox3.ShortcutsEnabled = True
        Me.MetroTextBox3.Size = New System.Drawing.Size(34, 23)
        Me.MetroTextBox3.TabIndex = 13
        Me.MetroTextBox3.UseSelectable = True
        Me.MetroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox3.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel15
        '
        Me.MetroLabel15.AutoSize = True
        Me.MetroLabel15.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel15.Location = New System.Drawing.Point(543, 23)
        Me.MetroLabel15.Name = "MetroLabel15"
        Me.MetroLabel15.Size = New System.Drawing.Size(36, 19)
        Me.MetroLabel15.TabIndex = 12
        Me.MetroLabel15.Text = "Age:"
        '
        'MetroTextBox2
        '
        Me.MetroTextBox2.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.MetroTextBox2.CustomButton.Image = Nothing
        Me.MetroTextBox2.CustomButton.Location = New System.Drawing.Point(135, 1)
        Me.MetroTextBox2.CustomButton.Name = ""
        Me.MetroTextBox2.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox2.CustomButton.TabIndex = 1
        Me.MetroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox2.CustomButton.UseSelectable = True
        Me.MetroTextBox2.CustomButton.Visible = False
        Me.MetroTextBox2.Lines = New String(-1) {}
        Me.MetroTextBox2.Location = New System.Drawing.Point(355, 22)
        Me.MetroTextBox2.MaxLength = 32767
        Me.MetroTextBox2.Name = "MetroTextBox2"
        Me.MetroTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox2.SelectedText = ""
        Me.MetroTextBox2.SelectionLength = 0
        Me.MetroTextBox2.SelectionStart = 0
        Me.MetroTextBox2.ShortcutsEnabled = True
        Me.MetroTextBox2.Size = New System.Drawing.Size(157, 23)
        Me.MetroTextBox2.TabIndex = 11
        Me.MetroTextBox2.UseSelectable = True
        Me.MetroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox2.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel16
        '
        Me.MetroLabel16.AutoSize = True
        Me.MetroLabel16.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel16.Location = New System.Drawing.Point(242, 24)
        Me.MetroLabel16.Name = "MetroLabel16"
        Me.MetroLabel16.Size = New System.Drawing.Size(111, 19)
        Me.MetroLabel16.TabIndex = 10
        Me.MetroLabel16.Text = "Contact Number:"
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.MetroTextBox1.CustomButton.Image = Nothing
        Me.MetroTextBox1.CustomButton.Location = New System.Drawing.Point(135, 1)
        Me.MetroTextBox1.CustomButton.Name = ""
        Me.MetroTextBox1.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox1.CustomButton.TabIndex = 1
        Me.MetroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox1.CustomButton.UseSelectable = True
        Me.MetroTextBox1.CustomButton.Visible = False
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(56, 21)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.SelectionLength = 0
        Me.MetroTextBox1.SelectionStart = 0
        Me.MetroTextBox1.ShortcutsEnabled = True
        Me.MetroTextBox1.Size = New System.Drawing.Size(157, 23)
        Me.MetroTextBox1.TabIndex = 9
        Me.MetroTextBox1.UseSelectable = True
        Me.MetroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel17
        '
        Me.MetroLabel17.AutoSize = True
        Me.MetroLabel17.Location = New System.Drawing.Point(7, 51)
        Me.MetroLabel17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel17.Name = "MetroLabel17"
        Me.MetroLabel17.Size = New System.Drawing.Size(83, 19)
        Me.MetroLabel17.TabIndex = 7
        Me.MetroLabel17.Text = "Full Address:"
        '
        'MetroLabel18
        '
        Me.MetroLabel18.AutoSize = True
        Me.MetroLabel18.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel18.Location = New System.Drawing.Point(7, 21)
        Me.MetroLabel18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel18.Name = "MetroLabel18"
        Me.MetroLabel18.Size = New System.Drawing.Size(48, 19)
        Me.MetroLabel18.TabIndex = 5
        Me.MetroLabel18.Text = "Name:"
        '
        'MetroTextBox4
        '
        Me.MetroTextBox4.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.MetroTextBox4.CustomButton.Image = Nothing
        Me.MetroTextBox4.CustomButton.Location = New System.Drawing.Point(135, 1)
        Me.MetroTextBox4.CustomButton.Name = ""
        Me.MetroTextBox4.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox4.CustomButton.TabIndex = 1
        Me.MetroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox4.CustomButton.UseSelectable = True
        Me.MetroTextBox4.CustomButton.Visible = False
        Me.MetroTextBox4.Lines = New String(-1) {}
        Me.MetroTextBox4.Location = New System.Drawing.Point(58, 17)
        Me.MetroTextBox4.MaxLength = 32767
        Me.MetroTextBox4.Name = "MetroTextBox4"
        Me.MetroTextBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox4.SelectedText = ""
        Me.MetroTextBox4.SelectionLength = 0
        Me.MetroTextBox4.SelectionStart = 0
        Me.MetroTextBox4.ShortcutsEnabled = True
        Me.MetroTextBox4.Size = New System.Drawing.Size(157, 23)
        Me.MetroTextBox4.TabIndex = 15
        Me.MetroTextBox4.UseSelectable = True
        Me.MetroTextBox4.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox4.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel19
        '
        Me.MetroLabel19.AutoSize = True
        Me.MetroLabel19.Location = New System.Drawing.Point(10, 18)
        Me.MetroLabel19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MetroLabel19.Name = "MetroLabel19"
        Me.MetroLabel19.Size = New System.Drawing.Size(33, 19)
        Me.MetroLabel19.TabIndex = 3
        Me.MetroLabel19.Text = "No.:"
        '
        'Blotter_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MetroPanel1)
        Me.Name = "Blotter_Report"
        Me.Size = New System.Drawing.Size(1219, 609)
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MetroPanel4.ResumeLayout(False)
        Me.MetroPanel4.PerformLayout()
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroButton4 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton5 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel7 As MetroFramework.Controls.MetroLabel
    Friend WithEvents DataGridView7 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
    Friend WithEvents Age As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
    Friend WithEvents MetroPanel4 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel8 As MetroFramework.Controls.MetroLabel
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents MetroLabel10 As MetroFramework.Controls.MetroLabel
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents MetroTextBox9 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel11 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox10 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel12 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel13 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroPanel2 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel9 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton6 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroComboBox1 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel14 As MetroFramework.Controls.MetroLabel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents MetroTextBox3 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel15 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox2 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel16 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel17 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel18 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox4 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel19 As MetroFramework.Controls.MetroLabel
End Class
