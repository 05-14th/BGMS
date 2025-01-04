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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgv_person = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_publish = New MetroFramework.Controls.MetroButton()
        Me.btn_cancel = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel3 = New MetroFramework.Controls.MetroPanel()
        Me.MetroPanel4 = New MetroFramework.Controls.MetroPanel()
        Me.dt_time = New System.Windows.Forms.DateTimePicker()
        Me.blotter_date = New System.Windows.Forms.DateTimePicker()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.blotter_address = New System.Windows.Forms.RichTextBox()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.blotter_complaint = New System.Windows.Forms.RichTextBox()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel12 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel13 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.cb_classification = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel14 = New MetroFramework.Controls.MetroLabel()
        Me.txtbox_address = New System.Windows.Forms.RichTextBox()
        Me.txtbox_age = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel15 = New MetroFramework.Controls.MetroLabel()
        Me.txtbox_contact = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel16 = New MetroFramework.Controls.MetroLabel()
        Me.txtbox_name = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel17 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel18 = New MetroFramework.Controls.MetroLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtbox_no = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel19 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv_person, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.MetroPanel3.SuspendLayout()
        Me.MetroPanel4.SuspendLayout()
        Me.MetroPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.Panel3)
        Me.MetroPanel1.Controls.Add(Me.MetroPanel3)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 9
        Me.MetroPanel1.Location = New System.Drawing.Point(0, 0)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(1828, 937)
        Me.MetroPanel1.TabIndex = 17
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.dgv_person)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.MetroLabel7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(916, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2, 2, 4, 2)
        Me.Panel3.Size = New System.Drawing.Size(912, 937)
        Me.Panel3.TabIndex = 26
        '
        'dgv_person
        '
        Me.dgv_person.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_person.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.Age, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36})
        Me.dgv_person.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_person.Location = New System.Drawing.Point(2, 21)
        Me.dgv_person.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgv_person.Name = "dgv_person"
        Me.dgv_person.RowHeadersWidth = 62
        Me.dgv_person.Size = New System.Drawing.Size(906, 852)
        Me.dgv_person.TabIndex = 32
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn33.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn33.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn34.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn34.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'Age
        '
        Me.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Age.HeaderText = "Age"
        Me.Age.MinimumWidth = 8
        Me.Age.Name = "Age"
        Me.Age.Width = 74
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn35.HeaderText = "Contact Number"
        Me.DataGridViewTextBoxColumn35.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.Width = 148
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn36.HeaderText = "Classification"
        Me.DataGridViewTextBoxColumn36.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.Width = 138
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_publish)
        Me.Panel2.Controls.Add(Me.btn_cancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(2, 873)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(906, 62)
        Me.Panel2.TabIndex = 30
        '
        'btn_publish
        '
        Me.btn_publish.Location = New System.Drawing.Point(152, 8)
        Me.btn_publish.Name = "btn_publish"
        Me.btn_publish.Size = New System.Drawing.Size(146, 48)
        Me.btn_publish.TabIndex = 30
        Me.btn_publish.Text = "PUBLISH"
        Me.btn_publish.UseSelectable = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(0, 8)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(146, 48)
        Me.btn_cancel.TabIndex = 29
        Me.btn_cancel.Text = "CANCEL"
        Me.btn_cancel.UseSelectable = True
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroLabel7.Location = New System.Drawing.Point(2, 2)
        Me.MetroLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(104, 19)
        Me.MetroLabel7.TabIndex = 25
        Me.MetroLabel7.Text = "People Involved:"
        '
        'MetroPanel3
        '
        Me.MetroPanel3.Controls.Add(Me.MetroPanel4)
        Me.MetroPanel3.Controls.Add(Me.MetroPanel2)
        Me.MetroPanel3.Controls.Add(Me.Panel1)
        Me.MetroPanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.MetroPanel3.HorizontalScrollbarBarColor = True
        Me.MetroPanel3.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel3.HorizontalScrollbarSize = 10
        Me.MetroPanel3.Location = New System.Drawing.Point(0, 0)
        Me.MetroPanel3.Name = "MetroPanel3"
        Me.MetroPanel3.Padding = New System.Windows.Forms.Padding(2)
        Me.MetroPanel3.Size = New System.Drawing.Size(916, 937)
        Me.MetroPanel3.TabIndex = 25
        Me.MetroPanel3.VerticalScrollbarBarColor = True
        Me.MetroPanel3.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel3.VerticalScrollbarSize = 10
        '
        'MetroPanel4
        '
        Me.MetroPanel4.AutoScroll = True
        Me.MetroPanel4.Controls.Add(Me.dt_time)
        Me.MetroPanel4.Controls.Add(Me.blotter_date)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel8)
        Me.MetroPanel4.Controls.Add(Me.blotter_address)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel10)
        Me.MetroPanel4.Controls.Add(Me.blotter_complaint)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel11)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel12)
        Me.MetroPanel4.Controls.Add(Me.MetroLabel13)
        Me.MetroPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel4.HorizontalScrollbar = True
        Me.MetroPanel4.HorizontalScrollbarBarColor = True
        Me.MetroPanel4.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel4.HorizontalScrollbarSize = 9
        Me.MetroPanel4.Location = New System.Drawing.Point(2, 444)
        Me.MetroPanel4.Name = "MetroPanel4"
        Me.MetroPanel4.Size = New System.Drawing.Size(912, 491)
        Me.MetroPanel4.TabIndex = 34
        Me.MetroPanel4.Tag = ""
        Me.MetroPanel4.VerticalScrollbar = True
        Me.MetroPanel4.VerticalScrollbarBarColor = True
        Me.MetroPanel4.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel4.VerticalScrollbarSize = 10
        '
        'dt_time
        '
        Me.dt_time.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dt_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dt_time.Location = New System.Drawing.Point(677, 41)
        Me.dt_time.Name = "dt_time"
        Me.dt_time.Size = New System.Drawing.Size(190, 26)
        Me.dt_time.TabIndex = 20
        '
        'blotter_date
        '
        Me.blotter_date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.blotter_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.blotter_date.Location = New System.Drawing.Point(75, 43)
        Me.blotter_date.Name = "blotter_date"
        Me.blotter_date.Size = New System.Drawing.Size(303, 26)
        Me.blotter_date.TabIndex = 19
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = True
        Me.MetroLabel8.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroLabel8.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel8.Location = New System.Drawing.Point(0, 0)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(95, 15)
        Me.MetroLabel8.TabIndex = 18
        Me.MetroLabel8.Text = "Incident Report"
        '
        'blotter_address
        '
        Me.blotter_address.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.blotter_address.Location = New System.Drawing.Point(15, 307)
        Me.blotter_address.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.blotter_address.Name = "blotter_address"
        Me.blotter_address.Size = New System.Drawing.Size(877, 150)
        Me.blotter_address.TabIndex = 16
        Me.blotter_address.Text = ""
        '
        'MetroLabel10
        '
        Me.MetroLabel10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(15, 274)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(182, 19)
        Me.MetroLabel10.TabIndex = 15
        Me.MetroLabel10.Text = "Address/Place of the Incident:"
        '
        'blotter_complaint
        '
        Me.blotter_complaint.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.blotter_complaint.Location = New System.Drawing.Point(15, 125)
        Me.blotter_complaint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.blotter_complaint.Name = "blotter_complaint"
        Me.blotter_complaint.Size = New System.Drawing.Size(877, 144)
        Me.blotter_complaint.TabIndex = 14
        Me.blotter_complaint.Text = ""
        '
        'MetroLabel11
        '
        Me.MetroLabel11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel11.Location = New System.Drawing.Point(587, 41)
        Me.MetroLabel11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(41, 19)
        Me.MetroLabel11.TabIndex = 10
        Me.MetroLabel11.Text = "Time:"
        '
        'MetroLabel12
        '
        Me.MetroLabel12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel12.AutoSize = True
        Me.MetroLabel12.Location = New System.Drawing.Point(15, 89)
        Me.MetroLabel12.Name = "MetroLabel12"
        Me.MetroLabel12.Size = New System.Drawing.Size(166, 19)
        Me.MetroLabel12.TabIndex = 7
        Me.MetroLabel12.Text = "Statement of Complainant:"
        '
        'MetroLabel13
        '
        Me.MetroLabel13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel13.AutoSize = True
        Me.MetroLabel13.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel13.Location = New System.Drawing.Point(9, 41)
        Me.MetroLabel13.Name = "MetroLabel13"
        Me.MetroLabel13.Size = New System.Drawing.Size(39, 19)
        Me.MetroLabel13.TabIndex = 5
        Me.MetroLabel13.Text = "Date:"
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Controls.Add(Me.MetroButton1)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel9)
        Me.MetroPanel2.Controls.Add(Me.cb_classification)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel14)
        Me.MetroPanel2.Controls.Add(Me.txtbox_address)
        Me.MetroPanel2.Controls.Add(Me.txtbox_age)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel15)
        Me.MetroPanel2.Controls.Add(Me.txtbox_contact)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel16)
        Me.MetroPanel2.Controls.Add(Me.txtbox_name)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel17)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel18)
        Me.MetroPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 9
        Me.MetroPanel2.Location = New System.Drawing.Point(2, 53)
        Me.MetroPanel2.MinimumSize = New System.Drawing.Size(844, 0)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(912, 391)
        Me.MetroPanel2.TabIndex = 22
        Me.MetroPanel2.Tag = ""
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 10
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(730, 301)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(164, 51)
        Me.MetroButton1.TabIndex = 27
        Me.MetroButton1.Text = "ADD"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroLabel9
        '
        Me.MetroLabel9.AutoSize = True
        Me.MetroLabel9.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroLabel9.FontSize = MetroFramework.MetroLabelSize.Small
        Me.MetroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel9.Location = New System.Drawing.Point(0, 0)
        Me.MetroLabel9.Name = "MetroLabel9"
        Me.MetroLabel9.Size = New System.Drawing.Size(138, 15)
        Me.MetroLabel9.TabIndex = 26
        Me.MetroLabel9.Text = "Person Involved Details"
        '
        'cb_classification
        '
        Me.cb_classification.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_classification.FormattingEnabled = True
        Me.cb_classification.ItemHeight = 23
        Me.cb_classification.Items.AddRange(New Object() {"Complainant", "Defendant", "Witness"})
        Me.cb_classification.Location = New System.Drawing.Point(160, 311)
        Me.cb_classification.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cb_classification.Name = "cb_classification"
        Me.cb_classification.Size = New System.Drawing.Size(180, 29)
        Me.cb_classification.TabIndex = 16
        Me.cb_classification.UseSelectable = True
        '
        'MetroLabel14
        '
        Me.MetroLabel14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel14.AutoSize = True
        Me.MetroLabel14.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel14.Location = New System.Drawing.Point(10, 315)
        Me.MetroLabel14.Name = "MetroLabel14"
        Me.MetroLabel14.Size = New System.Drawing.Size(90, 19)
        Me.MetroLabel14.TabIndex = 15
        Me.MetroLabel14.Text = "Classification: "
        '
        'txtbox_address
        '
        Me.txtbox_address.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbox_address.Location = New System.Drawing.Point(15, 112)
        Me.txtbox_address.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_address.Name = "txtbox_address"
        Me.txtbox_address.Size = New System.Drawing.Size(877, 181)
        Me.txtbox_address.TabIndex = 14
        Me.txtbox_address.Text = ""
        '
        'txtbox_age
        '
        Me.txtbox_age.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtbox_age.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.txtbox_age.CustomButton.Image = Nothing
        Me.txtbox_age.CustomButton.Location = New System.Drawing.Point(17, 1)
        Me.txtbox_age.CustomButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_age.CustomButton.Name = ""
        Me.txtbox_age.CustomButton.Size = New System.Drawing.Size(33, 33)
        Me.txtbox_age.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtbox_age.CustomButton.TabIndex = 1
        Me.txtbox_age.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtbox_age.CustomButton.UseSelectable = True
        Me.txtbox_age.CustomButton.Visible = False
        Me.txtbox_age.Lines = New String(-1) {}
        Me.txtbox_age.Location = New System.Drawing.Point(839, 32)
        Me.txtbox_age.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_age.MaxLength = 3
        Me.txtbox_age.Name = "txtbox_age"
        Me.txtbox_age.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtbox_age.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtbox_age.SelectedText = ""
        Me.txtbox_age.SelectionLength = 0
        Me.txtbox_age.SelectionStart = 0
        Me.txtbox_age.ShortcutsEnabled = True
        Me.txtbox_age.Size = New System.Drawing.Size(51, 35)
        Me.txtbox_age.TabIndex = 13
        Me.txtbox_age.UseSelectable = True
        Me.txtbox_age.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtbox_age.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel15
        '
        Me.MetroLabel15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.MetroLabel15.AutoSize = True
        Me.MetroLabel15.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel15.Location = New System.Drawing.Point(762, 32)
        Me.MetroLabel15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MetroLabel15.Name = "MetroLabel15"
        Me.MetroLabel15.Size = New System.Drawing.Size(36, 19)
        Me.MetroLabel15.TabIndex = 12
        Me.MetroLabel15.Text = "Age:"
        '
        'txtbox_contact
        '
        Me.txtbox_contact.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtbox_contact.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.txtbox_contact.CustomButton.Image = Nothing
        Me.txtbox_contact.CustomButton.Location = New System.Drawing.Point(147, 1)
        Me.txtbox_contact.CustomButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_contact.CustomButton.Name = ""
        Me.txtbox_contact.CustomButton.Size = New System.Drawing.Size(33, 33)
        Me.txtbox_contact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtbox_contact.CustomButton.TabIndex = 1
        Me.txtbox_contact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtbox_contact.CustomButton.UseSelectable = True
        Me.txtbox_contact.CustomButton.Visible = False
        Me.txtbox_contact.Lines = New String(-1) {}
        Me.txtbox_contact.Location = New System.Drawing.Point(531, 32)
        Me.txtbox_contact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_contact.MaxLength = 11
        Me.txtbox_contact.Name = "txtbox_contact"
        Me.txtbox_contact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtbox_contact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtbox_contact.SelectedText = ""
        Me.txtbox_contact.SelectionLength = 0
        Me.txtbox_contact.SelectionStart = 0
        Me.txtbox_contact.ShortcutsEnabled = True
        Me.txtbox_contact.Size = New System.Drawing.Size(181, 35)
        Me.txtbox_contact.TabIndex = 11
        Me.txtbox_contact.UseSelectable = True
        Me.txtbox_contact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtbox_contact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel16
        '
        Me.MetroLabel16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel16.AutoSize = True
        Me.MetroLabel16.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel16.Location = New System.Drawing.Point(346, 32)
        Me.MetroLabel16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MetroLabel16.Name = "MetroLabel16"
        Me.MetroLabel16.Size = New System.Drawing.Size(111, 19)
        Me.MetroLabel16.TabIndex = 10
        Me.MetroLabel16.Text = "Contact Number:"
        '
        'txtbox_name
        '
        Me.txtbox_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtbox_name.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.txtbox_name.CustomButton.Image = Nothing
        Me.txtbox_name.CustomButton.Location = New System.Drawing.Point(187, 1)
        Me.txtbox_name.CustomButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_name.CustomButton.Name = ""
        Me.txtbox_name.CustomButton.Size = New System.Drawing.Size(33, 33)
        Me.txtbox_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtbox_name.CustomButton.TabIndex = 1
        Me.txtbox_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtbox_name.CustomButton.UseSelectable = True
        Me.txtbox_name.CustomButton.Visible = False
        Me.txtbox_name.Lines = New String(-1) {}
        Me.txtbox_name.Location = New System.Drawing.Point(102, 32)
        Me.txtbox_name.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_name.MaxLength = 255
        Me.txtbox_name.Name = "txtbox_name"
        Me.txtbox_name.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtbox_name.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtbox_name.SelectedText = ""
        Me.txtbox_name.SelectionLength = 0
        Me.txtbox_name.SelectionStart = 0
        Me.txtbox_name.ShortcutsEnabled = True
        Me.txtbox_name.Size = New System.Drawing.Size(221, 35)
        Me.txtbox_name.TabIndex = 9
        Me.txtbox_name.UseSelectable = True
        Me.txtbox_name.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtbox_name.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel17
        '
        Me.MetroLabel17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel17.AutoSize = True
        Me.MetroLabel17.Location = New System.Drawing.Point(10, 78)
        Me.MetroLabel17.Name = "MetroLabel17"
        Me.MetroLabel17.Size = New System.Drawing.Size(83, 19)
        Me.MetroLabel17.TabIndex = 7
        Me.MetroLabel17.Text = "Full Address:"
        '
        'MetroLabel18
        '
        Me.MetroLabel18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MetroLabel18.AutoSize = True
        Me.MetroLabel18.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MetroLabel18.Location = New System.Drawing.Point(10, 32)
        Me.MetroLabel18.Name = "MetroLabel18"
        Me.MetroLabel18.Size = New System.Drawing.Size(48, 19)
        Me.MetroLabel18.TabIndex = 5
        Me.MetroLabel18.Text = "Name:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtbox_no)
        Me.Panel1.Controls.Add(Me.MetroLabel19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 51)
        Me.Panel1.TabIndex = 2
        '
        'txtbox_no
        '
        Me.txtbox_no.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtbox_no.BackColor = System.Drawing.SystemColors.ControlDark
        '
        '
        '
        Me.txtbox_no.CustomButton.Image = Nothing
        Me.txtbox_no.CustomButton.Location = New System.Drawing.Point(202, 1)
        Me.txtbox_no.CustomButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_no.CustomButton.Name = ""
        Me.txtbox_no.CustomButton.Size = New System.Drawing.Size(33, 33)
        Me.txtbox_no.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtbox_no.CustomButton.TabIndex = 1
        Me.txtbox_no.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtbox_no.CustomButton.UseSelectable = True
        Me.txtbox_no.CustomButton.Visible = False
        Me.txtbox_no.Lines = New String(-1) {}
        Me.txtbox_no.Location = New System.Drawing.Point(51, 8)
        Me.txtbox_no.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbox_no.MaxLength = 32767
        Me.txtbox_no.Name = "txtbox_no"
        Me.txtbox_no.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtbox_no.ReadOnly = True
        Me.txtbox_no.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtbox_no.SelectedText = ""
        Me.txtbox_no.SelectionLength = 0
        Me.txtbox_no.SelectionStart = 0
        Me.txtbox_no.ShortcutsEnabled = True
        Me.txtbox_no.Size = New System.Drawing.Size(236, 35)
        Me.txtbox_no.TabIndex = 17
        Me.txtbox_no.UseSelectable = True
        Me.txtbox_no.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtbox_no.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel19
        '
        Me.MetroLabel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MetroLabel19.AutoSize = True
        Me.MetroLabel19.Location = New System.Drawing.Point(0, 8)
        Me.MetroLabel19.Name = "MetroLabel19"
        Me.MetroLabel19.Size = New System.Drawing.Size(33, 19)
        Me.MetroLabel19.TabIndex = 16
        Me.MetroLabel19.Text = "No.:"
        '
        'Blotter_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MetroPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Blotter_Report"
        Me.Size = New System.Drawing.Size(1828, 937)
        Me.MetroPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgv_person, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.MetroPanel3.ResumeLayout(False)
        Me.MetroPanel4.ResumeLayout(False)
        Me.MetroPanel4.PerformLayout()
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroPanel3 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroPanel2 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroLabel9 As MetroFramework.Controls.MetroLabel
    Friend WithEvents cb_classification As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel14 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtbox_address As RichTextBox
    Friend WithEvents txtbox_age As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel15 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtbox_contact As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel16 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtbox_name As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel17 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel18 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtbox_no As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel19 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents MetroLabel7 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_publish As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_cancel As MetroFramework.Controls.MetroButton
    Friend WithEvents dgv_person As DataGridView
    Friend WithEvents MetroPanel4 As MetroFramework.Controls.MetroPanel
    Friend WithEvents blotter_date As DateTimePicker
    Friend WithEvents MetroLabel8 As MetroFramework.Controls.MetroLabel
    Friend WithEvents blotter_address As RichTextBox
    Friend WithEvents MetroLabel10 As MetroFramework.Controls.MetroLabel
    Friend WithEvents blotter_complaint As RichTextBox
    Friend WithEvents MetroLabel11 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel12 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel13 As MetroFramework.Controls.MetroLabel
    Friend WithEvents dt_time As DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
    Friend WithEvents Age As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
End Class
