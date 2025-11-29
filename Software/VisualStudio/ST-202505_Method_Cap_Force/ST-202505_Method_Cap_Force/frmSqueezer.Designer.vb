<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSqueezer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSqueezer))
        Me.tmrSerialPortScan = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.lnkPortStatus = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbComPorts = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btnExtend = New System.Windows.Forms.Button()
        Me.btnRetract = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_QuickExtend = New System.Windows.Forms.Button()
        Me.btn_QuickRetract = New System.Windows.Forms.Button()
        Me.btnStartCycle = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumOfCycles = New System.Windows.Forms.MaskedTextBox()
        Me.txtStartPosition = New System.Windows.Forms.MaskedTextBox()
        Me.txtStopPosition = New System.Windows.Forms.MaskedTextBox()
        Me.btnPollUpdate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtStartHoldTime = New System.Windows.Forms.MaskedTextBox()
        Me.txtStopHoldTime = New System.Windows.Forms.MaskedTextBox()
        Me.txtmCurrentInchesFromHome = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnGoToFullExtend = New System.Windows.Forms.Button()
        Me.btnGoToFullRetract = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSetFullExtended = New System.Windows.Forms.Button()
        Me.btnSetFullRetracted = New System.Windows.Forms.Button()
        Me.chkCalibrate = New System.Windows.Forms.CheckBox()
        Me.btnGoToCycleHome = New System.Windows.Forms.Button()
        Me.btnGoToCycle = New System.Windows.Forms.Button()
        Me.setCycleHome = New System.Windows.Forms.Button()
        Me.btnSetCycle = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMARK10Units = New System.Windows.Forms.TextBox()
        Me.btnMARK10Clear = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMARK10Reading = New System.Windows.Forms.TextBox()
        Me.txtMARK10ReceiveIn = New System.Windows.Forms.TextBox()
        Me.lblMARK10Status = New System.Windows.Forms.Label()
        Me.lnkMARK10PortStatus = New System.Windows.Forms.LinkLabel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbMARK10ComPorts = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtExtendRateDelay = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMARK10ForceUnits = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMARK10ForceData = New System.Windows.Forms.TextBox()
        Me.btnSaveMARK10 = New System.Windows.Forms.Button()
        Me.btnClearMARK10 = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tabGraph = New System.Windows.Forms.TabPage()
        Me.chrtMARK10 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabData = New System.Windows.Forms.TabPage()
        Me.txtMARK10Data = New System.Windows.Forms.TextBox()
        Me.lnklblUnitSerialNumber = New System.Windows.Forms.LinkLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbl_TestStatus2 = New System.Windows.Forms.Label()
        Me.lnk_CycleHoldTime = New System.Windows.Forms.LinkLabel()
        Me.lnk_NumOfCycles = New System.Windows.Forms.LinkLabel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lbl_TestStatus = New System.Windows.Forms.Label()
        Me.lnk_CycleHomeHoldTime = New System.Windows.Forms.LinkLabel()
        Me.lbl_Running = New System.Windows.Forms.Label()
        Me.btn_Stop = New System.Windows.Forms.Button()
        Me.btn_StartCycle = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_Squeezer = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lnk_Distance = New System.Windows.Forms.LinkLabel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btn_SetSqueeze = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btn_GotoSqueeze = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btn_SetHome = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_usr_QuickRetract = New System.Windows.Forms.Button()
        Me.btn_usr_Retract = New System.Windows.Forms.Button()
        Me.btn_usr_QuickExtend = New System.Windows.Forms.Button()
        Me.btn_usr_Extend = New System.Windows.Forms.Button()
        Me.btn_usr_FullExtend = New System.Windows.Forms.Button()
        Me.btn_usr_FullRetract = New System.Windows.Forms.Button()
        Me.btn_GotoHome = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkbxDebugMessages = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chkbxDirectDriveToTarget = New System.Windows.Forms.CheckBox()
        Me.txtDirectDriveRange = New System.Windows.Forms.MaskedTextBox()
        Me.txtCurrentMillimetersFromHome = New System.Windows.Forms.TextBox()
        Me.txtCurrentMillimetersFullMap = New System.Windows.Forms.TextBox()
        Me.txtCyclePositionMillimetersFromHome = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblFullRetractA2D = New System.Windows.Forms.Label()
        Me.lblFullExtendA2D = New System.Windows.Forms.Label()
        Me.lblCycleA2D = New System.Windows.Forms.Label()
        Me.lblHomeA2D = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblDistanceA2DFromHome = New System.Windows.Forms.Label()
        Me.lblAcutalA2DPostion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtReceiveIn = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.tmrMARK10Data = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileMARK10 = New System.Windows.Forms.SaveFileDialog()
        Me.pnlCamera = New System.Windows.Forms.Panel()
        Me.txtbxProjectFileName = New System.Windows.Forms.TextBox()
        Me.lblProjectFileName = New System.Windows.Forms.Label()
        Me.lblWorkingDirectory = New System.Windows.Forms.Label()
        Me.rdobtnRecording = New System.Windows.Forms.RadioButton()
        Me.btnSavePhoto = New System.Windows.Forms.Button()
        Me.btnStopRecord = New System.Windows.Forms.Button()
        Me.btnStartRecord = New System.Windows.Forms.Button()
        Me.btnOverlay = New System.Windows.Forms.Button()
        Me.lnkWorkingDirectory = New System.Windows.Forms.LinkLabel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbxCameraVideoCapabilties = New System.Windows.Forms.ComboBox()
        Me.cmbxCameraList = New System.Windows.Forms.ComboBox()
        Me.pbxCameraLive = New System.Windows.Forms.PictureBox()
        Me.tmrSavePhoto = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFilePhoto = New System.Windows.Forms.SaveFileDialog()
        Me.baseImageOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.overleyImageOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.recordOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.recordSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tabGraph.SuspendLayout()
        CType(Me.chrtMARK10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabData.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCamera.SuspendLayout()
        CType(Me.pbxCameraLive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrSerialPortScan
        '
        Me.tmrSerialPortScan.Interval = 250
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(934, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Baud"
        Me.Label3.Visible = False
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"115200", "115200"})
        Me.cbBaudRate.Location = New System.Drawing.Point(871, 74)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(59, 21)
        Me.cbBaudRate.TabIndex = 86
        Me.ToolTip1.SetToolTip(Me.cbBaudRate, "Select Port to Communicate Over")
        Me.cbBaudRate.Visible = False
        '
        'lnkPortStatus
        '
        Me.lnkPortStatus.AutoSize = True
        Me.lnkPortStatus.LinkColor = System.Drawing.Color.Red
        Me.lnkPortStatus.Location = New System.Drawing.Point(896, 52)
        Me.lnkPortStatus.Name = "lnkPortStatus"
        Me.lnkPortStatus.Size = New System.Drawing.Size(38, 13)
        Me.lnkPortStatus.TabIndex = 85
        Me.lnkPortStatus.TabStop = True
        Me.lnkPortStatus.Text = "closed"
        Me.ToolTip1.SetToolTip(Me.lnkPortStatus, "Open / Close Port")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(857, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Status:"
        '
        'cbComPorts
        '
        Me.cbComPorts.FormattingEnabled = True
        Me.cbComPorts.Location = New System.Drawing.Point(860, 28)
        Me.cbComPorts.Name = "cbComPorts"
        Me.cbComPorts.Size = New System.Drawing.Size(67, 21)
        Me.cbComPorts.TabIndex = 82
        Me.ToolTip1.SetToolTip(Me.cbComPorts, "Select Port to Communicate Over")
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(940, 22)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 41)
        Me.btnExit.TabIndex = 81
        Me.btnExit.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.btnExit, "Exit Program")
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(857, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Use Port"
        '
        'SerialPort1
        '
        Me.SerialPort1.DtrEnable = True
        Me.SerialPort1.ReadBufferSize = 80096
        Me.SerialPort1.ReadTimeout = 500
        Me.SerialPort1.RtsEnable = True
        '
        'btnExtend
        '
        Me.btnExtend.Location = New System.Drawing.Point(235, 34)
        Me.btnExtend.Name = "btnExtend"
        Me.btnExtend.Size = New System.Drawing.Size(87, 29)
        Me.btnExtend.TabIndex = 98
        Me.btnExtend.Tag = "f"
        Me.btnExtend.Text = "Step Extend"
        Me.ToolTip1.SetToolTip(Me.btnExtend, "Extend")
        Me.btnExtend.UseVisualStyleBackColor = True
        Me.btnExtend.Visible = False
        '
        'btnRetract
        '
        Me.btnRetract.Location = New System.Drawing.Point(49, 34)
        Me.btnRetract.Name = "btnRetract"
        Me.btnRetract.Size = New System.Drawing.Size(87, 29)
        Me.btnRetract.TabIndex = 99
        Me.btnRetract.Tag = "r"
        Me.btnRetract.Text = "Step Retract"
        Me.ToolTip1.SetToolTip(Me.btnRetract, "Retract")
        Me.btnRetract.UseVisualStyleBackColor = True
        Me.btnRetract.Visible = False
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(142, 34)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(87, 29)
        Me.btnStop.TabIndex = 102
        Me.btnStop.Tag = "s"
        Me.btnStop.Text = "Stop"
        Me.ToolTip1.SetToolTip(Me.btnStop, "Stop the Test Cycle")
        Me.btnStop.UseVisualStyleBackColor = True
        Me.btnStop.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(414, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Cycle Hold Time In Seconds"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(414, 361)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Cycle Home Hold Time In Seconds"
        Me.Label5.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_QuickExtend)
        Me.GroupBox1.Controls.Add(Me.btn_QuickRetract)
        Me.GroupBox1.Controls.Add(Me.btnExtend)
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnRetract)
        Me.GroupBox1.Location = New System.Drawing.Point(424, 496)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 83)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manual Control"
        '
        'btn_QuickExtend
        '
        Me.btn_QuickExtend.Location = New System.Drawing.Point(327, 34)
        Me.btn_QuickExtend.Name = "btn_QuickExtend"
        Me.btn_QuickExtend.Size = New System.Drawing.Size(29, 29)
        Me.btn_QuickExtend.TabIndex = 152
        Me.btn_QuickExtend.Tag = ">"
        Me.btn_QuickExtend.Text = ">"
        Me.ToolTip1.SetToolTip(Me.btn_QuickExtend, "Quick Step Extend")
        Me.btn_QuickExtend.UseVisualStyleBackColor = True
        '
        'btn_QuickRetract
        '
        Me.btn_QuickRetract.Location = New System.Drawing.Point(14, 35)
        Me.btn_QuickRetract.Name = "btn_QuickRetract"
        Me.btn_QuickRetract.Size = New System.Drawing.Size(29, 29)
        Me.btn_QuickRetract.TabIndex = 151
        Me.btn_QuickRetract.Tag = "<"
        Me.btn_QuickRetract.Text = "<"
        Me.ToolTip1.SetToolTip(Me.btn_QuickRetract, "Quick Step Retract")
        Me.btn_QuickRetract.UseVisualStyleBackColor = True
        '
        'btnStartCycle
        '
        Me.btnStartCycle.Location = New System.Drawing.Point(414, 416)
        Me.btnStartCycle.Name = "btnStartCycle"
        Me.btnStartCycle.Size = New System.Drawing.Size(98, 36)
        Me.btnStartCycle.TabIndex = 112
        Me.btnStartCycle.Tag = "c"
        Me.btnStartCycle.Text = "Start Cycle"
        Me.ToolTip1.SetToolTip(Me.btnStartCycle, "Start the Test Cycle")
        Me.btnStartCycle.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Number of Cycles to Run"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(414, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Current Positon"
        Me.Label7.Visible = False
        '
        'txtNumOfCycles
        '
        Me.txtNumOfCycles.AsciiOnly = True
        Me.txtNumOfCycles.BeepOnError = True
        Me.txtNumOfCycles.Location = New System.Drawing.Point(621, 281)
        Me.txtNumOfCycles.Mask = "0000"
        Me.txtNumOfCycles.Name = "txtNumOfCycles"
        Me.txtNumOfCycles.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumOfCycles.Size = New System.Drawing.Size(55, 20)
        Me.txtNumOfCycles.TabIndex = 120
        Me.txtNumOfCycles.Text = "0000"
        Me.ToolTip1.SetToolTip(Me.txtNumOfCycles, "Test Setting - Number of Cycles")
        Me.txtNumOfCycles.Visible = False
        '
        'txtStartPosition
        '
        Me.txtStartPosition.Location = New System.Drawing.Point(532, 124)
        Me.txtStartPosition.Mask = "00000"
        Me.txtStartPosition.Name = "txtStartPosition"
        Me.txtStartPosition.ReadOnly = True
        Me.txtStartPosition.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStartPosition.Size = New System.Drawing.Size(44, 20)
        Me.txtStartPosition.TabIndex = 121
        Me.ToolTip1.SetToolTip(Me.txtStartPosition, "Millimeters  - Cycle Home Position on Full 0mm to 90mm Scale")
        Me.txtStartPosition.Visible = False
        '
        'txtStopPosition
        '
        Me.txtStopPosition.Location = New System.Drawing.Point(534, 159)
        Me.txtStopPosition.Mask = "00000"
        Me.txtStopPosition.Name = "txtStopPosition"
        Me.txtStopPosition.ReadOnly = True
        Me.txtStopPosition.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStopPosition.Size = New System.Drawing.Size(42, 20)
        Me.txtStopPosition.TabIndex = 122
        Me.ToolTip1.SetToolTip(Me.txtStopPosition, "Millimeters  - Cycle Position on Full 0mm to 90mm Scale")
        Me.txtStopPosition.Visible = False
        '
        'btnPollUpdate
        '
        Me.btnPollUpdate.Location = New System.Drawing.Point(864, 103)
        Me.btnPollUpdate.Name = "btnPollUpdate"
        Me.btnPollUpdate.Size = New System.Drawing.Size(137, 53)
        Me.btnPollUpdate.TabIndex = 124
        Me.btnPollUpdate.Tag = "?"
        Me.btnPollUpdate.Text = "Poll Update" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Refresh)"
        Me.ToolTip1.SetToolTip(Me.btnPollUpdate, "Querry Data Update From LAC")
        Me.btnPollUpdate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(295, 550)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(85, 29)
        Me.btnClear.TabIndex = 126
        Me.btnClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.btnClear, "Clear Comm Window")
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtStartHoldTime
        '
        Me.txtStartHoldTime.Location = New System.Drawing.Point(621, 357)
        Me.txtStartHoldTime.Mask = "0000"
        Me.txtStartHoldTime.Name = "txtStartHoldTime"
        Me.txtStartHoldTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStartHoldTime.Size = New System.Drawing.Size(55, 20)
        Me.txtStartHoldTime.TabIndex = 127
        Me.ToolTip1.SetToolTip(Me.txtStartHoldTime, "Test Setting - Hold Time in Home Position")
        Me.txtStartHoldTime.Visible = False
        '
        'txtStopHoldTime
        '
        Me.txtStopHoldTime.Location = New System.Drawing.Point(621, 315)
        Me.txtStopHoldTime.Mask = "0000"
        Me.txtStopHoldTime.Name = "txtStopHoldTime"
        Me.txtStopHoldTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStopHoldTime.Size = New System.Drawing.Size(55, 20)
        Me.txtStopHoldTime.TabIndex = 128
        Me.ToolTip1.SetToolTip(Me.txtStopHoldTime, "Test Setting - Hold Time in Cycle Position")
        Me.txtStopHoldTime.Visible = False
        '
        'txtmCurrentInchesFromHome
        '
        Me.txtmCurrentInchesFromHome.Location = New System.Drawing.Point(582, 223)
        Me.txtmCurrentInchesFromHome.Mask = "0.00"
        Me.txtmCurrentInchesFromHome.Name = "txtmCurrentInchesFromHome"
        Me.txtmCurrentInchesFromHome.ReadOnly = True
        Me.txtmCurrentInchesFromHome.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtmCurrentInchesFromHome.Size = New System.Drawing.Size(42, 20)
        Me.txtmCurrentInchesFromHome.TabIndex = 129
        Me.txtmCurrentInchesFromHome.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(414, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 13)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "Fully Extended Postion"
        Me.Label9.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(414, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 13)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "Fully Retracted Position"
        Me.Label11.Visible = False
        '
        'btnGoToFullExtend
        '
        Me.btnGoToFullExtend.Location = New System.Drawing.Point(659, 34)
        Me.btnGoToFullExtend.Name = "btnGoToFullExtend"
        Me.btnGoToFullExtend.Size = New System.Drawing.Size(52, 22)
        Me.btnGoToFullExtend.TabIndex = 133
        Me.btnGoToFullExtend.Tag = ">"
        Me.btnGoToFullExtend.Text = "Go to"
        Me.ToolTip1.SetToolTip(Me.btnGoToFullExtend, "Move to Fullly Extended Position")
        Me.btnGoToFullExtend.UseVisualStyleBackColor = True
        Me.btnGoToFullExtend.Visible = False
        '
        'btnGoToFullRetract
        '
        Me.btnGoToFullRetract.Location = New System.Drawing.Point(659, 69)
        Me.btnGoToFullRetract.Name = "btnGoToFullRetract"
        Me.btnGoToFullRetract.Size = New System.Drawing.Size(52, 22)
        Me.btnGoToFullRetract.TabIndex = 134
        Me.btnGoToFullRetract.Tag = "<"
        Me.btnGoToFullRetract.Text = "Go to"
        Me.ToolTip1.SetToolTip(Me.btnGoToFullRetract, "Move to Fully Retracted Position")
        Me.btnGoToFullRetract.UseVisualStyleBackColor = True
        Me.btnGoToFullRetract.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(414, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = " Cycle Position"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(414, 127)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 136
        Me.Label13.Text = "Cycle Home Position"
        Me.Label13.Visible = False
        '
        'btnSetFullExtended
        '
        Me.btnSetFullExtended.Location = New System.Drawing.Point(717, 34)
        Me.btnSetFullExtended.Name = "btnSetFullExtended"
        Me.btnSetFullExtended.Size = New System.Drawing.Size(85, 22)
        Me.btnSetFullExtended.TabIndex = 137
        Me.btnSetFullExtended.Tag = "o"
        Me.btnSetFullExtended.Text = "Set as current"
        Me.ToolTip1.SetToolTip(Me.btnSetFullExtended, "Set Current Position as Fully Extended Position")
        Me.btnSetFullExtended.UseVisualStyleBackColor = True
        Me.btnSetFullExtended.Visible = False
        '
        'btnSetFullRetracted
        '
        Me.btnSetFullRetracted.Location = New System.Drawing.Point(717, 69)
        Me.btnSetFullRetracted.Name = "btnSetFullRetracted"
        Me.btnSetFullRetracted.Size = New System.Drawing.Size(85, 22)
        Me.btnSetFullRetracted.TabIndex = 138
        Me.btnSetFullRetracted.Tag = "O"
        Me.btnSetFullRetracted.Text = "Set as current"
        Me.ToolTip1.SetToolTip(Me.btnSetFullRetracted, "Set Current Postion as Fully Retracted Position")
        Me.btnSetFullRetracted.UseVisualStyleBackColor = True
        Me.btnSetFullRetracted.Visible = False
        '
        'chkCalibrate
        '
        Me.chkCalibrate.AutoSize = True
        Me.chkCalibrate.Location = New System.Drawing.Point(39, 557)
        Me.chkCalibrate.Name = "chkCalibrate"
        Me.chkCalibrate.Size = New System.Drawing.Size(150, 17)
        Me.chkCalibrate.TabIndex = 139
        Me.chkCalibrate.Text = "Advanced User (Calibrate)"
        Me.ToolTip1.SetToolTip(Me.chkCalibrate, "Calibrate the Full 3.60"" Range")
        Me.chkCalibrate.UseVisualStyleBackColor = True
        Me.chkCalibrate.Visible = False
        '
        'btnGoToCycleHome
        '
        Me.btnGoToCycleHome.Location = New System.Drawing.Point(659, 122)
        Me.btnGoToCycleHome.Name = "btnGoToCycleHome"
        Me.btnGoToCycleHome.Size = New System.Drawing.Size(52, 22)
        Me.btnGoToCycleHome.TabIndex = 141
        Me.btnGoToCycleHome.Tag = "h"
        Me.btnGoToCycleHome.Text = "Go to"
        Me.ToolTip1.SetToolTip(Me.btnGoToCycleHome, "Move to Home Position")
        Me.btnGoToCycleHome.UseVisualStyleBackColor = True
        Me.btnGoToCycleHome.Visible = False
        '
        'btnGoToCycle
        '
        Me.btnGoToCycle.Location = New System.Drawing.Point(659, 161)
        Me.btnGoToCycle.Name = "btnGoToCycle"
        Me.btnGoToCycle.Size = New System.Drawing.Size(52, 22)
        Me.btnGoToCycle.TabIndex = 140
        Me.btnGoToCycle.Tag = "c"
        Me.btnGoToCycle.Text = "Go to"
        Me.ToolTip1.SetToolTip(Me.btnGoToCycle, "Move to Cycle Position")
        Me.btnGoToCycle.UseVisualStyleBackColor = True
        Me.btnGoToCycle.Visible = False
        '
        'setCycleHome
        '
        Me.setCycleHome.Location = New System.Drawing.Point(717, 122)
        Me.setCycleHome.Name = "setCycleHome"
        Me.setCycleHome.Size = New System.Drawing.Size(85, 22)
        Me.setCycleHome.TabIndex = 143
        Me.setCycleHome.Tag = "H"
        Me.setCycleHome.Text = "Set as current"
        Me.ToolTip1.SetToolTip(Me.setCycleHome, "Set Current Position as Home Position")
        Me.setCycleHome.UseVisualStyleBackColor = True
        Me.setCycleHome.Visible = False
        '
        'btnSetCycle
        '
        Me.btnSetCycle.Location = New System.Drawing.Point(717, 161)
        Me.btnSetCycle.Name = "btnSetCycle"
        Me.btnSetCycle.Size = New System.Drawing.Size(85, 22)
        Me.btnSetCycle.TabIndex = 142
        Me.btnSetCycle.Tag = "C"
        Me.btnSetCycle.Text = "Set as current"
        Me.ToolTip1.SetToolTip(Me.btnSetCycle, "Set Current Position as Cycle Position")
        Me.btnSetCycle.UseVisualStyleBackColor = True
        Me.btnSetCycle.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtMARK10Units)
        Me.GroupBox2.Controls.Add(Me.btnMARK10Clear)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtMARK10Reading)
        Me.GroupBox2.Controls.Add(Me.txtMARK10ReceiveIn)
        Me.GroupBox2.Controls.Add(Me.lblMARK10Status)
        Me.GroupBox2.Controls.Add(Me.lnkMARK10PortStatus)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.cbMARK10ComPorts)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(198, 296)
        Me.GroupBox2.TabIndex = 147
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MARK-10 Interface Settings"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 251)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 187
        Me.Label14.Text = "Units"
        '
        'txtMARK10Units
        '
        Me.txtMARK10Units.Location = New System.Drawing.Point(34, 265)
        Me.txtMARK10Units.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMARK10Units.Name = "txtMARK10Units"
        Me.txtMARK10Units.ReadOnly = True
        Me.txtMARK10Units.Size = New System.Drawing.Size(54, 20)
        Me.txtMARK10Units.TabIndex = 186
        '
        'btnMARK10Clear
        '
        Me.btnMARK10Clear.Location = New System.Drawing.Point(112, 263)
        Me.btnMARK10Clear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMARK10Clear.Name = "btnMARK10Clear"
        Me.btnMARK10Clear.Size = New System.Drawing.Size(56, 19)
        Me.btnMARK10Clear.TabIndex = 185
        Me.btnMARK10Clear.Text = "Clear"
        Me.btnMARK10Clear.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 214)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "Reading"
        '
        'txtMARK10Reading
        '
        Me.txtMARK10Reading.Location = New System.Drawing.Point(32, 228)
        Me.txtMARK10Reading.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMARK10Reading.Name = "txtMARK10Reading"
        Me.txtMARK10Reading.ReadOnly = True
        Me.txtMARK10Reading.Size = New System.Drawing.Size(54, 20)
        Me.txtMARK10Reading.TabIndex = 183
        '
        'txtMARK10ReceiveIn
        '
        Me.txtMARK10ReceiveIn.Location = New System.Drawing.Point(105, 119)
        Me.txtMARK10ReceiveIn.Multiline = True
        Me.txtMARK10ReceiveIn.Name = "txtMARK10ReceiveIn"
        Me.txtMARK10ReceiveIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMARK10ReceiveIn.Size = New System.Drawing.Size(81, 139)
        Me.txtMARK10ReceiveIn.TabIndex = 182
        '
        'lblMARK10Status
        '
        Me.lblMARK10Status.AutoSize = True
        Me.lblMARK10Status.Location = New System.Drawing.Point(66, 136)
        Me.lblMARK10Status.Name = "lblMARK10Status"
        Me.lblMARK10Status.Size = New System.Drawing.Size(37, 13)
        Me.lblMARK10Status.TabIndex = 181
        Me.lblMARK10Status.Text = "Status"
        Me.lblMARK10Status.Visible = False
        '
        'lnkMARK10PortStatus
        '
        Me.lnkMARK10PortStatus.AutoSize = True
        Me.lnkMARK10PortStatus.LinkColor = System.Drawing.Color.Red
        Me.lnkMARK10PortStatus.Location = New System.Drawing.Point(54, 176)
        Me.lnkMARK10PortStatus.Name = "lnkMARK10PortStatus"
        Me.lnkMARK10PortStatus.Size = New System.Drawing.Size(38, 13)
        Me.lnkMARK10PortStatus.TabIndex = 180
        Me.lnkMARK10PortStatus.TabStop = True
        Me.lnkMARK10PortStatus.Text = "closed"
        Me.ToolTip1.SetToolTip(Me.lnkMARK10PortStatus, "Open / Close Port")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 177)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 13)
        Me.Label27.TabIndex = 179
        Me.Label27.Text = "Status:"
        '
        'cbMARK10ComPorts
        '
        Me.cbMARK10ComPorts.FormattingEnabled = True
        Me.cbMARK10ComPorts.Location = New System.Drawing.Point(18, 152)
        Me.cbMARK10ComPorts.Name = "cbMARK10ComPorts"
        Me.cbMARK10ComPorts.Size = New System.Drawing.Size(67, 21)
        Me.cbMARK10ComPorts.TabIndex = 177
        Me.ToolTip1.SetToolTip(Me.cbMARK10ComPorts, "Select Port to Communicate Over")
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(15, 136)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 13)
        Me.Label31.TabIndex = 178
        Me.Label31.Text = "Use Port"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(206, 91)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "MARK-10 Serial/USB Settings" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "USB Selected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "BAUD Rate:115200" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Data Format: Numeric" &
    " + Units" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AUTO Output - Enabled - 125 redings/sec" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DATA Key - USB/RS232 Output" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(871, 238)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 33)
        Me.Button2.TabIndex = 148
        Me.Button2.Text = "SERIAL PORT CLEAR"
        Me.ToolTip1.SetToolTip(Me.Button2, "Clear the Serial Port Buffer")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtExtendRateDelay
        '
        Me.txtExtendRateDelay.Location = New System.Drawing.Point(621, 245)
        Me.txtExtendRateDelay.Mask = "0"
        Me.txtExtendRateDelay.Name = "txtExtendRateDelay"
        Me.txtExtendRateDelay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtExtendRateDelay.Size = New System.Drawing.Size(55, 20)
        Me.txtExtendRateDelay.TabIndex = 149
        Me.txtExtendRateDelay.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(414, 249)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(160, 13)
        Me.Label17.TabIndex = 150
        Me.Label17.Text = "Rate to Move to Extend Position"
        Me.Label17.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1028, 611)
        Me.TabControl1.TabIndex = 151
        Me.ToolTip1.SetToolTip(Me.TabControl1, "Select Page")
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.lnklblUnitSerialNumber)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.lbl_Squeezer)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1020, 585)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Operator"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.txtMARK10ForceUnits)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.txtMARK10ForceData)
        Me.GroupBox6.Controls.Add(Me.btnSaveMARK10)
        Me.GroupBox6.Controls.Add(Me.btnClearMARK10)
        Me.GroupBox6.Controls.Add(Me.TabControl2)
        Me.GroupBox6.Location = New System.Drawing.Point(609, 15)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Size = New System.Drawing.Size(405, 288)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "MARK10 Force Data"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(86, 250)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 191
        Me.Label15.Text = "Units"
        '
        'txtMARK10ForceUnits
        '
        Me.txtMARK10ForceUnits.Location = New System.Drawing.Point(80, 266)
        Me.txtMARK10ForceUnits.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMARK10ForceUnits.Name = "txtMARK10ForceUnits"
        Me.txtMARK10ForceUnits.ReadOnly = True
        Me.txtMARK10ForceUnits.Size = New System.Drawing.Size(54, 20)
        Me.txtMARK10ForceUnits.TabIndex = 190
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 250)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 189
        Me.Label16.Text = "Reading"
        '
        'txtMARK10ForceData
        '
        Me.txtMARK10ForceData.Location = New System.Drawing.Point(12, 265)
        Me.txtMARK10ForceData.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMARK10ForceData.Name = "txtMARK10ForceData"
        Me.txtMARK10ForceData.ReadOnly = True
        Me.txtMARK10ForceData.Size = New System.Drawing.Size(54, 20)
        Me.txtMARK10ForceData.TabIndex = 188
        '
        'btnSaveMARK10
        '
        Me.btnSaveMARK10.Enabled = False
        Me.btnSaveMARK10.Location = New System.Drawing.Point(274, 250)
        Me.btnSaveMARK10.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSaveMARK10.Name = "btnSaveMARK10"
        Me.btnSaveMARK10.Size = New System.Drawing.Size(127, 32)
        Me.btnSaveMARK10.TabIndex = 15
        Me.btnSaveMARK10.Text = "Save to CSV Flie"
        Me.btnSaveMARK10.UseVisualStyleBackColor = True
        '
        'btnClearMARK10
        '
        Me.btnClearMARK10.Location = New System.Drawing.Point(149, 250)
        Me.btnClearMARK10.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearMARK10.Name = "btnClearMARK10"
        Me.btnClearMARK10.Size = New System.Drawing.Size(104, 32)
        Me.btnClearMARK10.TabIndex = 14
        Me.btnClearMARK10.Text = "Clear"
        Me.btnClearMARK10.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tabGraph)
        Me.TabControl2.Controls.Add(Me.tabData)
        Me.TabControl2.Location = New System.Drawing.Point(9, 17)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(396, 228)
        Me.TabControl2.TabIndex = 13
        '
        'tabGraph
        '
        Me.tabGraph.Controls.Add(Me.chrtMARK10)
        Me.tabGraph.Location = New System.Drawing.Point(4, 22)
        Me.tabGraph.Margin = New System.Windows.Forms.Padding(2)
        Me.tabGraph.Name = "tabGraph"
        Me.tabGraph.Padding = New System.Windows.Forms.Padding(2)
        Me.tabGraph.Size = New System.Drawing.Size(388, 202)
        Me.tabGraph.TabIndex = 0
        Me.tabGraph.Text = "Graph"
        Me.tabGraph.UseVisualStyleBackColor = True
        '
        'chrtMARK10
        '
        ChartArea5.Name = "MARK10ChartArea"
        Me.chrtMARK10.ChartAreas.Add(ChartArea5)
        Legend5.Enabled = False
        Legend5.Name = "Legend1"
        Me.chrtMARK10.Legends.Add(Legend5)
        Me.chrtMARK10.Location = New System.Drawing.Point(4, 2)
        Me.chrtMARK10.Margin = New System.Windows.Forms.Padding(2)
        Me.chrtMARK10.Name = "chrtMARK10"
        Series5.ChartArea = "MARK10ChartArea"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Legend = "Legend1"
        Series5.Name = "Force"
        Me.chrtMARK10.Series.Add(Series5)
        Me.chrtMARK10.Size = New System.Drawing.Size(380, 197)
        Me.chrtMARK10.TabIndex = 12
        Me.chrtMARK10.Text = "MARK10 Chart"
        '
        'tabData
        '
        Me.tabData.Controls.Add(Me.txtMARK10Data)
        Me.tabData.Location = New System.Drawing.Point(4, 22)
        Me.tabData.Margin = New System.Windows.Forms.Padding(2)
        Me.tabData.Name = "tabData"
        Me.tabData.Padding = New System.Windows.Forms.Padding(2)
        Me.tabData.Size = New System.Drawing.Size(388, 202)
        Me.tabData.TabIndex = 1
        Me.tabData.Text = "Data"
        Me.tabData.UseVisualStyleBackColor = True
        '
        'txtMARK10Data
        '
        Me.txtMARK10Data.Location = New System.Drawing.Point(11, 10)
        Me.txtMARK10Data.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMARK10Data.Multiline = True
        Me.txtMARK10Data.Name = "txtMARK10Data"
        Me.txtMARK10Data.ReadOnly = True
        Me.txtMARK10Data.Size = New System.Drawing.Size(202, 188)
        Me.txtMARK10Data.TabIndex = 0
        '
        'lnklblUnitSerialNumber
        '
        Me.lnklblUnitSerialNumber.AutoSize = True
        Me.lnklblUnitSerialNumber.Location = New System.Drawing.Point(260, 102)
        Me.lnklblUnitSerialNumber.Name = "lnklblUnitSerialNumber"
        Me.lnklblUnitSerialNumber.Size = New System.Drawing.Size(25, 13)
        Me.lnklblUnitSerialNumber.TabIndex = 11
        Me.lnklblUnitSerialNumber.TabStop = True
        Me.lnklblUnitSerialNumber.Text = "SN:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_TestStatus2)
        Me.GroupBox4.Controls.Add(Me.lnk_CycleHoldTime)
        Me.GroupBox4.Controls.Add(Me.lnk_NumOfCycles)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.lbl_TestStatus)
        Me.GroupBox4.Controls.Add(Me.lnk_CycleHomeHoldTime)
        Me.GroupBox4.Controls.Add(Me.lbl_Running)
        Me.GroupBox4.Controls.Add(Me.btn_Stop)
        Me.GroupBox4.Controls.Add(Me.btn_StartCycle)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 139)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(596, 437)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Squeeze Cycle Test"
        '
        'lbl_TestStatus2
        '
        Me.lbl_TestStatus2.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TestStatus2.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_TestStatus2.Location = New System.Drawing.Point(178, 356)
        Me.lbl_TestStatus2.Name = "lbl_TestStatus2"
        Me.lbl_TestStatus2.Size = New System.Drawing.Size(412, 40)
        Me.lbl_TestStatus2.TabIndex = 13
        Me.lbl_TestStatus2.Text = "STATUS LINE 2"
        Me.lbl_TestStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_TestStatus2.Visible = False
        '
        'lnk_CycleHoldTime
        '
        Me.lnk_CycleHoldTime.AutoSize = True
        Me.lnk_CycleHoldTime.Enabled = False
        Me.lnk_CycleHoldTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnk_CycleHoldTime.Location = New System.Drawing.Point(461, 156)
        Me.lnk_CycleHoldTime.Name = "lnk_CycleHoldTime"
        Me.lnk_CycleHoldTime.Size = New System.Drawing.Size(68, 24)
        Me.lnk_CycleHoldTime.TabIndex = 11
        Me.lnk_CycleHoldTime.TabStop = True
        Me.lnk_CycleHoldTime.Text = "waiting"
        Me.ToolTip1.SetToolTip(Me.lnk_CycleHoldTime, "Squeeze Position Hold Time in Test")
        '
        'lnk_NumOfCycles
        '
        Me.lnk_NumOfCycles.AutoSize = True
        Me.lnk_NumOfCycles.Enabled = False
        Me.lnk_NumOfCycles.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnk_NumOfCycles.Location = New System.Drawing.Point(354, 63)
        Me.lnk_NumOfCycles.Name = "lnk_NumOfCycles"
        Me.lnk_NumOfCycles.Size = New System.Drawing.Size(193, 24)
        Me.lnk_NumOfCycles.TabIndex = 10
        Me.lnk_NumOfCycles.TabStop = True
        Me.lnk_NumOfCycles.Text = "waiting for connection"
        Me.ToolTip1.SetToolTip(Me.lnk_NumOfCycles, "Number of Cycles in Test")
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(184, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(406, 38)
        Me.Label26.TabIndex = 12
        Me.Label26.Text = "TEST SETTINGS"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TestStatus
        '
        Me.lbl_TestStatus.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TestStatus.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_TestStatus.Location = New System.Drawing.Point(178, 311)
        Me.lbl_TestStatus.Name = "lbl_TestStatus"
        Me.lbl_TestStatus.Size = New System.Drawing.Size(412, 40)
        Me.lbl_TestStatus.TabIndex = 11
        Me.lbl_TestStatus.Text = "STATUS LINE 1"
        Me.lbl_TestStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_TestStatus.Visible = False
        '
        'lnk_CycleHomeHoldTime
        '
        Me.lnk_CycleHomeHoldTime.AutoSize = True
        Me.lnk_CycleHomeHoldTime.Enabled = False
        Me.lnk_CycleHomeHoldTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnk_CycleHomeHoldTime.Location = New System.Drawing.Point(435, 110)
        Me.lnk_CycleHomeHoldTime.Name = "lnk_CycleHomeHoldTime"
        Me.lnk_CycleHomeHoldTime.Size = New System.Drawing.Size(68, 24)
        Me.lnk_CycleHomeHoldTime.TabIndex = 10
        Me.lnk_CycleHomeHoldTime.TabStop = True
        Me.lnk_CycleHomeHoldTime.Text = "waiting"
        Me.ToolTip1.SetToolTip(Me.lnk_CycleHomeHoldTime, "Home Position Hold Time in Test")
        '
        'lbl_Running
        '
        Me.lbl_Running.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Running.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Running.Location = New System.Drawing.Point(178, 249)
        Me.lbl_Running.Name = "lbl_Running"
        Me.lbl_Running.Size = New System.Drawing.Size(412, 38)
        Me.lbl_Running.TabIndex = 10
        Me.lbl_Running.Text = "TEST RUNNING"
        Me.lbl_Running.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Running.Visible = False
        '
        'btn_Stop
        '
        Me.btn_Stop.BackgroundImage = CType(resources.GetObject("btn_Stop.BackgroundImage"), System.Drawing.Image)
        Me.btn_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Stop.Enabled = False
        Me.btn_Stop.Location = New System.Drawing.Point(22, 249)
        Me.btn_Stop.Name = "btn_Stop"
        Me.btn_Stop.Size = New System.Drawing.Size(150, 150)
        Me.btn_Stop.TabIndex = 9
        Me.btn_Stop.Tag = "s"
        Me.ToolTip1.SetToolTip(Me.btn_Stop, "Stop Test Cycle")
        Me.btn_Stop.UseVisualStyleBackColor = True
        '
        'btn_StartCycle
        '
        Me.btn_StartCycle.BackgroundImage = CType(resources.GetObject("btn_StartCycle.BackgroundImage"), System.Drawing.Image)
        Me.btn_StartCycle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_StartCycle.Location = New System.Drawing.Point(22, 49)
        Me.btn_StartCycle.Name = "btn_StartCycle"
        Me.btn_StartCycle.Size = New System.Drawing.Size(150, 150)
        Me.btn_StartCycle.TabIndex = 5
        Me.btn_StartCycle.Tag = "c"
        Me.btn_StartCycle.Text = "START"
        Me.ToolTip1.SetToolTip(Me.btn_StartCycle, "Start the Test Squeeze Cycle")
        Me.btn_StartCycle.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(193, 63)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(165, 24)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Number of Cycles:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(193, 156)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(274, 24)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "Hold Time at Squeeze Position:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(193, 110)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(250, 24)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "Hold Time at Home Position:"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(2, 70)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(600, 23)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "ST-202405_MTBC_Bottle_Squeezer Tester"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Squeezer
        '
        Me.lbl_Squeezer.Font = New System.Drawing.Font("Comic Sans MS", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Squeezer.ForeColor = System.Drawing.Color.Fuchsia
        Me.lbl_Squeezer.Location = New System.Drawing.Point(3, 3)
        Me.lbl_Squeezer.Name = "lbl_Squeezer"
        Me.lbl_Squeezer.Size = New System.Drawing.Size(605, 67)
        Me.lbl_Squeezer.TabIndex = 3
        Me.lbl_Squeezer.Text = "CAP PULLER"
        Me.lbl_Squeezer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lnk_Distance)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.btn_SetSqueeze)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.btn_GotoSqueeze)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.btn_SetHome)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox3.Controls.Add(Me.btn_GotoHome)
        Me.GroupBox3.Location = New System.Drawing.Point(609, 308)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(405, 271)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Manual Movement"
        '
        'lnk_Distance
        '
        Me.lnk_Distance.Enabled = False
        Me.lnk_Distance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnk_Distance.Location = New System.Drawing.Point(175, 95)
        Me.lnk_Distance.Name = "lnk_Distance"
        Me.lnk_Distance.Size = New System.Drawing.Size(50, 25)
        Me.lnk_Distance.TabIndex = 10
        Me.lnk_Distance.TabStop = True
        Me.lnk_Distance.Text = "wait"
        Me.lnk_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lnk_Distance, "Distance from Home in Millimeters")
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(175, 121)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 15)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "mm"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(175, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 43)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Distance From Home"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_SetSqueeze
        '
        Me.btn_SetSqueeze.Enabled = False
        Me.btn_SetSqueeze.Location = New System.Drawing.Point(252, 142)
        Me.btn_SetSqueeze.Name = "btn_SetSqueeze"
        Me.btn_SetSqueeze.Size = New System.Drawing.Size(100, 25)
        Me.btn_SetSqueeze.TabIndex = 8
        Me.btn_SetSqueeze.Tag = "C"
        Me.btn_SetSqueeze.Text = "Set as Squeeze "
        Me.ToolTip1.SetToolTip(Me.btn_SetSqueeze, "Set Current Position as Squeeze Position")
        Me.btn_SetSqueeze.UseVisualStyleBackColor = True
        Me.btn_SetSqueeze.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(277, 255)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "EXTEND"
        '
        'btn_GotoSqueeze
        '
        Me.btn_GotoSqueeze.BackgroundImage = CType(resources.GetObject("btn_GotoSqueeze.BackgroundImage"), System.Drawing.Image)
        Me.btn_GotoSqueeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_GotoSqueeze.Enabled = False
        Me.btn_GotoSqueeze.Location = New System.Drawing.Point(252, 36)
        Me.btn_GotoSqueeze.Name = "btn_GotoSqueeze"
        Me.btn_GotoSqueeze.Size = New System.Drawing.Size(100, 100)
        Me.btn_GotoSqueeze.TabIndex = 7
        Me.btn_GotoSqueeze.Tag = "c"
        Me.ToolTip1.SetToolTip(Me.btn_GotoSqueeze, "Goto Squeeze Position")
        Me.btn_GotoSqueeze.UseVisualStyleBackColor = True
        Me.btn_GotoSqueeze.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(70, 255)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "RETRACT"
        '
        'btn_SetHome
        '
        Me.btn_SetHome.Enabled = False
        Me.btn_SetHome.Location = New System.Drawing.Point(50, 142)
        Me.btn_SetHome.Name = "btn_SetHome"
        Me.btn_SetHome.Size = New System.Drawing.Size(100, 25)
        Me.btn_SetHome.TabIndex = 6
        Me.btn_SetHome.Tag = "H"
        Me.btn_SetHome.Text = "Set as Home"
        Me.ToolTip1.SetToolTip(Me.btn_SetHome, "Set Current Position as Home Position")
        Me.btn_SetHome.UseVisualStyleBackColor = True
        Me.btn_SetHome.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_usr_QuickRetract, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_usr_Retract, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_usr_QuickExtend, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_usr_Extend, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_usr_FullExtend, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_usr_FullRetract, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 193)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(390, 53)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btn_usr_QuickRetract
        '
        Me.btn_usr_QuickRetract.Enabled = False
        Me.btn_usr_QuickRetract.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_usr_QuickRetract.Location = New System.Drawing.Point(3, 3)
        Me.btn_usr_QuickRetract.Name = "btn_usr_QuickRetract"
        Me.btn_usr_QuickRetract.Size = New System.Drawing.Size(55, 45)
        Me.btn_usr_QuickRetract.TabIndex = 2
        Me.btn_usr_QuickRetract.Tag = "}"
        Me.btn_usr_QuickRetract.Text = "<"
        Me.ToolTip1.SetToolTip(Me.btn_usr_QuickRetract, "Quick Step Retract")
        Me.btn_usr_QuickRetract.UseVisualStyleBackColor = True
        '
        'btn_usr_Retract
        '
        Me.btn_usr_Retract.Enabled = False
        Me.btn_usr_Retract.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_usr_Retract.Location = New System.Drawing.Point(64, 3)
        Me.btn_usr_Retract.Name = "btn_usr_Retract"
        Me.btn_usr_Retract.Size = New System.Drawing.Size(55, 45)
        Me.btn_usr_Retract.TabIndex = 3
        Me.btn_usr_Retract.Tag = "r"
        Me.btn_usr_Retract.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.btn_usr_Retract, "Retract")
        Me.btn_usr_Retract.UseVisualStyleBackColor = True
        Me.btn_usr_Retract.Visible = False
        '
        'btn_usr_QuickExtend
        '
        Me.btn_usr_QuickExtend.Enabled = False
        Me.btn_usr_QuickExtend.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_usr_QuickExtend.Location = New System.Drawing.Point(328, 3)
        Me.btn_usr_QuickExtend.Name = "btn_usr_QuickExtend"
        Me.btn_usr_QuickExtend.Size = New System.Drawing.Size(55, 45)
        Me.btn_usr_QuickExtend.TabIndex = 5
        Me.btn_usr_QuickExtend.Tag = "{"
        Me.btn_usr_QuickExtend.Text = ">"
        Me.ToolTip1.SetToolTip(Me.btn_usr_QuickExtend, "Quick Step Extend")
        Me.btn_usr_QuickExtend.UseVisualStyleBackColor = True
        '
        'btn_usr_Extend
        '
        Me.btn_usr_Extend.Enabled = False
        Me.btn_usr_Extend.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_usr_Extend.Location = New System.Drawing.Point(267, 3)
        Me.btn_usr_Extend.Name = "btn_usr_Extend"
        Me.btn_usr_Extend.Size = New System.Drawing.Size(55, 45)
        Me.btn_usr_Extend.TabIndex = 6
        Me.btn_usr_Extend.Tag = "f"
        Me.btn_usr_Extend.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.btn_usr_Extend, "Extend")
        Me.btn_usr_Extend.UseVisualStyleBackColor = True
        Me.btn_usr_Extend.Visible = False
        '
        'btn_usr_FullExtend
        '
        Me.btn_usr_FullExtend.Enabled = False
        Me.btn_usr_FullExtend.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_usr_FullExtend.Location = New System.Drawing.Point(206, 3)
        Me.btn_usr_FullExtend.Name = "btn_usr_FullExtend"
        Me.btn_usr_FullExtend.Size = New System.Drawing.Size(55, 45)
        Me.btn_usr_FullExtend.TabIndex = 7
        Me.btn_usr_FullExtend.Tag = ">"
        Me.btn_usr_FullExtend.Text = ">|"
        Me.ToolTip1.SetToolTip(Me.btn_usr_FullExtend, "Goto Full Extend Position")
        Me.btn_usr_FullExtend.UseVisualStyleBackColor = True
        Me.btn_usr_FullExtend.Visible = False
        '
        'btn_usr_FullRetract
        '
        Me.btn_usr_FullRetract.Enabled = False
        Me.btn_usr_FullRetract.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_usr_FullRetract.Location = New System.Drawing.Point(125, 3)
        Me.btn_usr_FullRetract.Name = "btn_usr_FullRetract"
        Me.btn_usr_FullRetract.Size = New System.Drawing.Size(55, 45)
        Me.btn_usr_FullRetract.TabIndex = 4
        Me.btn_usr_FullRetract.Tag = "<"
        Me.btn_usr_FullRetract.Text = "|<"
        Me.ToolTip1.SetToolTip(Me.btn_usr_FullRetract, "Goto Full Retract Position")
        Me.btn_usr_FullRetract.UseVisualStyleBackColor = True
        Me.btn_usr_FullRetract.Visible = False
        '
        'btn_GotoHome
        '
        Me.btn_GotoHome.BackgroundImage = CType(resources.GetObject("btn_GotoHome.BackgroundImage"), System.Drawing.Image)
        Me.btn_GotoHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_GotoHome.Enabled = False
        Me.btn_GotoHome.Location = New System.Drawing.Point(50, 36)
        Me.btn_GotoHome.Name = "btn_GotoHome"
        Me.btn_GotoHome.Size = New System.Drawing.Size(100, 100)
        Me.btn_GotoHome.TabIndex = 5
        Me.btn_GotoHome.Tag = "h"
        Me.ToolTip1.SetToolTip(Me.btn_GotoHome, "Goto Home Position")
        Me.btn_GotoHome.UseVisualStyleBackColor = True
        Me.btn_GotoHome.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.txtCurrentMillimetersFromHome)
        Me.TabPage2.Controls.Add(Me.txtCurrentMillimetersFullMap)
        Me.TabPage2.Controls.Add(Me.txtCyclePositionMillimetersFromHome)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.lblFullRetractA2D)
        Me.TabPage2.Controls.Add(Me.lblFullExtendA2D)
        Me.TabPage2.Controls.Add(Me.lblCycleA2D)
        Me.TabPage2.Controls.Add(Me.lblHomeA2D)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.lblDistanceA2DFromHome)
        Me.TabPage2.Controls.Add(Me.lblAcutalA2DPostion)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.txtReceiveIn)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.txtExtendRateDelay)
        Me.TabPage2.Controls.Add(Me.btnPollUpdate)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.lblStatus)
        Me.TabPage2.Controls.Add(Me.btnClear)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.chkCalibrate)
        Me.TabPage2.Controls.Add(Me.cbBaudRate)
        Me.TabPage2.Controls.Add(Me.setCycleHome)
        Me.TabPage2.Controls.Add(Me.lnkPortStatus)
        Me.TabPage2.Controls.Add(Me.btnStartCycle)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.btnSetCycle)
        Me.TabPage2.Controls.Add(Me.cbComPorts)
        Me.TabPage2.Controls.Add(Me.btnSetFullRetracted)
        Me.TabPage2.Controls.Add(Me.btnExit)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.btnSetFullExtended)
        Me.TabPage2.Controls.Add(Me.btnGoToCycleHome)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtStopHoldTime)
        Me.TabPage2.Controls.Add(Me.btnGoToCycle)
        Me.TabPage2.Controls.Add(Me.txtStartHoldTime)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtNumOfCycles)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.btnGoToFullRetract)
        Me.TabPage2.Controls.Add(Me.btnGoToFullExtend)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtmCurrentInchesFromHome)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.txtStartPosition)
        Me.TabPage2.Controls.Add(Me.txtStopPosition)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1020, 585)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Setup"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkbxDebugMessages)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.chkbxDirectDriveToTarget)
        Me.GroupBox5.Controls.Add(Me.txtDirectDriveRange)
        Me.GroupBox5.Location = New System.Drawing.Point(630, 402)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(156, 88)
        Me.GroupBox5.TabIndex = 176
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Options"
        Me.GroupBox5.Visible = False
        '
        'chkbxDebugMessages
        '
        Me.chkbxDebugMessages.AutoSize = True
        Me.chkbxDebugMessages.Location = New System.Drawing.Point(14, 25)
        Me.chkbxDebugMessages.Name = "chkbxDebugMessages"
        Me.chkbxDebugMessages.Size = New System.Drawing.Size(109, 17)
        Me.chkbxDebugMessages.TabIndex = 166
        Me.chkbxDebugMessages.Text = "Debug Messages"
        Me.ToolTip1.SetToolTip(Me.chkbxDebugMessages, "Enable additional messages for debugging")
        Me.chkbxDebugMessages.UseVisualStyleBackColor = True
        Me.chkbxDebugMessages.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(54, 69)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 171
        Me.Label28.Text = "Range"
        Me.Label28.Visible = False
        '
        'chkbxDirectDriveToTarget
        '
        Me.chkbxDirectDriveToTarget.AutoSize = True
        Me.chkbxDirectDriveToTarget.Location = New System.Drawing.Point(14, 46)
        Me.chkbxDirectDriveToTarget.Name = "chkbxDirectDriveToTarget"
        Me.chkbxDirectDriveToTarget.Size = New System.Drawing.Size(128, 17)
        Me.chkbxDirectDriveToTarget.TabIndex = 167
        Me.chkbxDirectDriveToTarget.Text = "Direct Drive to Target"
        Me.ToolTip1.SetToolTip(Me.chkbxDirectDriveToTarget, "Single Driect Drive to Location - No overshoot")
        Me.chkbxDirectDriveToTarget.UseVisualStyleBackColor = True
        Me.chkbxDirectDriveToTarget.Visible = False
        '
        'txtDirectDriveRange
        '
        Me.txtDirectDriveRange.Location = New System.Drawing.Point(99, 66)
        Me.txtDirectDriveRange.Mask = "00"
        Me.txtDirectDriveRange.Name = "txtDirectDriveRange"
        Me.txtDirectDriveRange.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDirectDriveRange.Size = New System.Drawing.Size(24, 20)
        Me.txtDirectDriveRange.TabIndex = 170
        Me.ToolTip1.SetToolTip(Me.txtDirectDriveRange, "+/- Count Range for target location ")
        Me.txtDirectDriveRange.Visible = False
        '
        'txtCurrentMillimetersFromHome
        '
        Me.txtCurrentMillimetersFromHome.Location = New System.Drawing.Point(582, 202)
        Me.txtCurrentMillimetersFromHome.Name = "txtCurrentMillimetersFromHome"
        Me.txtCurrentMillimetersFromHome.ReadOnly = True
        Me.txtCurrentMillimetersFromHome.Size = New System.Drawing.Size(42, 20)
        Me.txtCurrentMillimetersFromHome.TabIndex = 165
        Me.txtCurrentMillimetersFromHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCurrentMillimetersFromHome, "Millimeters  - Current Position Distance From Cycle Home Position")
        Me.txtCurrentMillimetersFromHome.Visible = False
        '
        'txtCurrentMillimetersFullMap
        '
        Me.txtCurrentMillimetersFullMap.Location = New System.Drawing.Point(532, 202)
        Me.txtCurrentMillimetersFullMap.Name = "txtCurrentMillimetersFullMap"
        Me.txtCurrentMillimetersFullMap.ReadOnly = True
        Me.txtCurrentMillimetersFullMap.Size = New System.Drawing.Size(43, 20)
        Me.txtCurrentMillimetersFullMap.TabIndex = 164
        Me.txtCurrentMillimetersFullMap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCurrentMillimetersFullMap, "Millimeters  - Current Position on Full 0mm to 90mm Scale")
        Me.txtCurrentMillimetersFullMap.Visible = False
        '
        'txtCyclePositionMillimetersFromHome
        '
        Me.txtCyclePositionMillimetersFromHome.Location = New System.Drawing.Point(582, 159)
        Me.txtCyclePositionMillimetersFromHome.Name = "txtCyclePositionMillimetersFromHome"
        Me.txtCyclePositionMillimetersFromHome.ReadOnly = True
        Me.txtCyclePositionMillimetersFromHome.Size = New System.Drawing.Size(42, 20)
        Me.txtCyclePositionMillimetersFromHome.TabIndex = 163
        Me.txtCyclePositionMillimetersFromHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCyclePositionMillimetersFromHome, "Millimeters  - Cycle Position Distance  From Cycle Home Position")
        Me.txtCyclePositionMillimetersFromHome.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(534, 71)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(42, 20)
        Me.TextBox3.TabIndex = 162
        Me.TextBox3.Text = "ref 90"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox3, "Millimeters  - Full 90mm Reference")
        Me.TextBox3.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(534, 36)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(42, 20)
        Me.TextBox2.TabIndex = 161
        Me.TextBox2.Text = "ref 0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox2, "Millimeters  - Full 0mm Reference")
        Me.TextBox2.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(554, 18)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(23, 13)
        Me.Label30.TabIndex = 160
        Me.Label30.Text = "mm"
        Me.Label30.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(626, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 13)
        Me.Label29.TabIndex = 159
        Me.Label29.Text = "A2D"
        Me.Label29.Visible = False
        '
        'lblFullRetractA2D
        '
        Me.lblFullRetractA2D.AutoSize = True
        Me.lblFullRetractA2D.Location = New System.Drawing.Point(627, 74)
        Me.lblFullRetractA2D.Name = "lblFullRetractA2D"
        Me.lblFullRetractA2D.Size = New System.Drawing.Size(26, 13)
        Me.lblFullRetractA2D.TabIndex = 158
        Me.lblFullRetractA2D.Text = "wait"
        Me.ToolTip1.SetToolTip(Me.lblFullRetractA2D, "A2D Count - Fully Retracted Position")
        Me.lblFullRetractA2D.Visible = False
        '
        'lblFullExtendA2D
        '
        Me.lblFullExtendA2D.AutoSize = True
        Me.lblFullExtendA2D.Location = New System.Drawing.Point(627, 39)
        Me.lblFullExtendA2D.Name = "lblFullExtendA2D"
        Me.lblFullExtendA2D.Size = New System.Drawing.Size(26, 13)
        Me.lblFullExtendA2D.TabIndex = 157
        Me.lblFullExtendA2D.Text = "wait"
        Me.ToolTip1.SetToolTip(Me.lblFullExtendA2D, "A2D Count - Fully Extended Position ")
        Me.lblFullExtendA2D.Visible = False
        '
        'lblCycleA2D
        '
        Me.lblCycleA2D.AutoSize = True
        Me.lblCycleA2D.Location = New System.Drawing.Point(627, 166)
        Me.lblCycleA2D.Name = "lblCycleA2D"
        Me.lblCycleA2D.Size = New System.Drawing.Size(26, 13)
        Me.lblCycleA2D.TabIndex = 156
        Me.lblCycleA2D.Text = "wait"
        Me.ToolTip1.SetToolTip(Me.lblCycleA2D, "A2D Count - Cycle Position")
        Me.lblCycleA2D.Visible = False
        '
        'lblHomeA2D
        '
        Me.lblHomeA2D.AutoSize = True
        Me.lblHomeA2D.Location = New System.Drawing.Point(627, 124)
        Me.lblHomeA2D.Name = "lblHomeA2D"
        Me.lblHomeA2D.Size = New System.Drawing.Size(26, 13)
        Me.lblHomeA2D.TabIndex = 155
        Me.lblHomeA2D.Text = "wait"
        Me.ToolTip1.SetToolTip(Me.lblHomeA2D, "A2D Count - Home Position")
        Me.lblHomeA2D.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(582, 124)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(42, 20)
        Me.TextBox1.TabIndex = 154
        Me.TextBox1.Text = "ref 0.00"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox1, "Millimeters -  Cycle Home Position is 0mm Reference")
        Me.TextBox1.Visible = False
        '
        'lblDistanceA2DFromHome
        '
        Me.lblDistanceA2DFromHome.AutoSize = True
        Me.lblDistanceA2DFromHome.Location = New System.Drawing.Point(659, 206)
        Me.lblDistanceA2DFromHome.Name = "lblDistanceA2DFromHome"
        Me.lblDistanceA2DFromHome.Size = New System.Drawing.Size(26, 13)
        Me.lblDistanceA2DFromHome.TabIndex = 153
        Me.lblDistanceA2DFromHome.Text = "wait"
        Me.ToolTip1.SetToolTip(Me.lblDistanceA2DFromHome, "A2D Count - Distance Current Position From Home Position")
        Me.lblDistanceA2DFromHome.Visible = False
        '
        'lblAcutalA2DPostion
        '
        Me.lblAcutalA2DPostion.AutoSize = True
        Me.lblAcutalA2DPostion.Location = New System.Drawing.Point(627, 206)
        Me.lblAcutalA2DPostion.Name = "lblAcutalA2DPostion"
        Me.lblAcutalA2DPostion.Size = New System.Drawing.Size(26, 13)
        Me.lblAcutalA2DPostion.TabIndex = 152
        Me.lblAcutalA2DPostion.Text = "wait"
        Me.ToolTip1.SetToolTip(Me.lblAcutalA2DPostion, "A2D Count - Current Position")
        Me.lblAcutalA2DPostion.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(792, 278)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 311)
        Me.Panel1.TabIndex = 151
        '
        'txtReceiveIn
        '
        Me.txtReceiveIn.Location = New System.Drawing.Point(0, 5)
        Me.txtReceiveIn.Multiline = True
        Me.txtReceiveIn.Name = "txtReceiveIn"
        Me.txtReceiveIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReceiveIn.Size = New System.Drawing.Size(400, 536)
        Me.txtReceiveIn.TabIndex = 126
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(908, 11)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 88
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'SerialPort2
        '
        Me.SerialPort2.BaudRate = 115200
        Me.SerialPort2.DtrEnable = True
        Me.SerialPort2.ReadBufferSize = 80096
        Me.SerialPort2.ReadTimeout = 500
        Me.SerialPort2.RtsEnable = True
        '
        'tmrMARK10Data
        '
        '
        'SaveFileMARK10
        '
        Me.SaveFileMARK10.FileName = "*.csv"
        Me.SaveFileMARK10.Filter = "Excel Text Files|*.CSV|All Files|*.*"
        Me.SaveFileMARK10.RestoreDirectory = True
        '
        'pnlCamera
        '
        Me.pnlCamera.Controls.Add(Me.txtbxProjectFileName)
        Me.pnlCamera.Controls.Add(Me.lblProjectFileName)
        Me.pnlCamera.Controls.Add(Me.lblWorkingDirectory)
        Me.pnlCamera.Controls.Add(Me.rdobtnRecording)
        Me.pnlCamera.Controls.Add(Me.btnSavePhoto)
        Me.pnlCamera.Controls.Add(Me.btnStopRecord)
        Me.pnlCamera.Controls.Add(Me.btnStartRecord)
        Me.pnlCamera.Controls.Add(Me.btnOverlay)
        Me.pnlCamera.Controls.Add(Me.lnkWorkingDirectory)
        Me.pnlCamera.Controls.Add(Me.Label33)
        Me.pnlCamera.Controls.Add(Me.Label32)
        Me.pnlCamera.Controls.Add(Me.cmbxCameraVideoCapabilties)
        Me.pnlCamera.Controls.Add(Me.cmbxCameraList)
        Me.pnlCamera.Location = New System.Drawing.Point(1045, 513)
        Me.pnlCamera.Name = "pnlCamera"
        Me.pnlCamera.Size = New System.Drawing.Size(673, 108)
        Me.pnlCamera.TabIndex = 152
        '
        'txtbxProjectFileName
        '
        Me.txtbxProjectFileName.Location = New System.Drawing.Point(17, 28)
        Me.txtbxProjectFileName.Name = "txtbxProjectFileName"
        Me.txtbxProjectFileName.Size = New System.Drawing.Size(321, 20)
        Me.txtbxProjectFileName.TabIndex = 18
        Me.txtbxProjectFileName.Text = "Need_Project_File_Name"
        '
        'lblProjectFileName
        '
        Me.lblProjectFileName.AutoSize = True
        Me.lblProjectFileName.Location = New System.Drawing.Point(14, 9)
        Me.lblProjectFileName.Name = "lblProjectFileName"
        Me.lblProjectFileName.Size = New System.Drawing.Size(98, 13)
        Me.lblProjectFileName.TabIndex = 17
        Me.lblProjectFileName.Text = "Project / File Name"
        '
        'lblWorkingDirectory
        '
        Me.lblWorkingDirectory.AutoSize = True
        Me.lblWorkingDirectory.Location = New System.Drawing.Point(14, 80)
        Me.lblWorkingDirectory.Name = "lblWorkingDirectory"
        Me.lblWorkingDirectory.Size = New System.Drawing.Size(45, 13)
        Me.lblWorkingDirectory.TabIndex = 15
        Me.lblWorkingDirectory.Text = "Label35"
        '
        'rdobtnRecording
        '
        Me.rdobtnRecording.AutoSize = True
        Me.rdobtnRecording.Enabled = False
        Me.rdobtnRecording.Location = New System.Drawing.Point(536, 0)
        Me.rdobtnRecording.Name = "rdobtnRecording"
        Me.rdobtnRecording.Size = New System.Drawing.Size(94, 17)
        Me.rdobtnRecording.TabIndex = 13
        Me.rdobtnRecording.TabStop = True
        Me.rdobtnRecording.Text = "Camera Active"
        Me.rdobtnRecording.UseVisualStyleBackColor = True
        '
        'btnSavePhoto
        '
        Me.btnSavePhoto.Location = New System.Drawing.Point(358, 34)
        Me.btnSavePhoto.Name = "btnSavePhoto"
        Me.btnSavePhoto.Size = New System.Drawing.Size(75, 23)
        Me.btnSavePhoto.TabIndex = 12
        Me.btnSavePhoto.Text = "Save Photo"
        Me.btnSavePhoto.UseVisualStyleBackColor = True
        '
        'btnStopRecord
        '
        Me.btnStopRecord.Location = New System.Drawing.Point(439, 36)
        Me.btnStopRecord.Name = "btnStopRecord"
        Me.btnStopRecord.Size = New System.Drawing.Size(75, 23)
        Me.btnStopRecord.TabIndex = 11
        Me.btnStopRecord.Text = "Stop Record"
        Me.btnStopRecord.UseVisualStyleBackColor = True
        '
        'btnStartRecord
        '
        Me.btnStartRecord.Location = New System.Drawing.Point(439, 4)
        Me.btnStartRecord.Name = "btnStartRecord"
        Me.btnStartRecord.Size = New System.Drawing.Size(75, 23)
        Me.btnStartRecord.TabIndex = 10
        Me.btnStartRecord.Text = "Start Record"
        Me.btnStartRecord.UseVisualStyleBackColor = True
        '
        'btnOverlay
        '
        Me.btnOverlay.Location = New System.Drawing.Point(358, 3)
        Me.btnOverlay.Name = "btnOverlay"
        Me.btnOverlay.Size = New System.Drawing.Size(75, 23)
        Me.btnOverlay.TabIndex = 9
        Me.btnOverlay.Text = "Overlay"
        Me.btnOverlay.UseVisualStyleBackColor = True
        '
        'lnkWorkingDirectory
        '
        Me.lnkWorkingDirectory.AutoSize = True
        Me.lnkWorkingDirectory.Location = New System.Drawing.Point(14, 60)
        Me.lnkWorkingDirectory.Name = "lnkWorkingDirectory"
        Me.lnkWorkingDirectory.Size = New System.Drawing.Size(92, 13)
        Me.lnkWorkingDirectory.TabIndex = 5
        Me.lnkWorkingDirectory.TabStop = True
        Me.lnkWorkingDirectory.Text = "Working Directory"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(533, 68)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(62, 13)
        Me.Label33.TabIndex = 4
        Me.Label33.Text = "Frame Size "
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(533, 23)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(77, 13)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "Camera to Use"
        '
        'cmbxCameraVideoCapabilties
        '
        Me.cmbxCameraVideoCapabilties.FormattingEnabled = True
        Me.cmbxCameraVideoCapabilties.Location = New System.Drawing.Point(536, 84)
        Me.cmbxCameraVideoCapabilties.Name = "cmbxCameraVideoCapabilties"
        Me.cmbxCameraVideoCapabilties.Size = New System.Drawing.Size(121, 21)
        Me.cmbxCameraVideoCapabilties.TabIndex = 2
        '
        'cmbxCameraList
        '
        Me.cmbxCameraList.FormattingEnabled = True
        Me.cmbxCameraList.Location = New System.Drawing.Point(536, 39)
        Me.cmbxCameraList.Name = "cmbxCameraList"
        Me.cmbxCameraList.Size = New System.Drawing.Size(121, 21)
        Me.cmbxCameraList.TabIndex = 1
        '
        'pbxCameraLive
        '
        Me.pbxCameraLive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxCameraLive.InitialImage = Nothing
        Me.pbxCameraLive.Location = New System.Drawing.Point(1062, 27)
        Me.pbxCameraLive.Name = "pbxCameraLive"
        Me.pbxCameraLive.Size = New System.Drawing.Size(640, 480)
        Me.pbxCameraLive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCameraLive.TabIndex = 0
        Me.pbxCameraLive.TabStop = False
        '
        'tmrSavePhoto
        '
        '
        'SaveFilePhoto
        '
        Me.SaveFilePhoto.Filter = "PNG Format|*.png"
        '
        'baseImageOpenFileDialog
        '
        Me.baseImageOpenFileDialog.Filter = "PNG Format|*.png"
        '
        'overleyImageOpenFileDialog
        '
        Me.overleyImageOpenFileDialog.Filter = "PNG Fromat|*.png"
        '
        'recordOpenFileDialog
        '
        Me.recordOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'recordSaveFileDialog
        '
        Me.recordSaveFileDialog.Filter = "Movie Files|*.wmv"
        '
        'BackgroundWorker1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 109)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 24)
        Me.Button1.TabIndex = 188
        Me.Button1.Tag = "?"
        Me.Button1.Text = "Querry"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(61, 110)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(42, 23)
        Me.Button3.TabIndex = 189
        Me.Button3.Tag = "*"
        Me.Button3.Text = "Clr"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmSqueezer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1730, 624)
        Me.Controls.Add(Me.pnlCamera)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pbxCameraLive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSqueezer"
        Me.Text = "ST-202405_MTBC_Bottle_Squeezer v06.04.25"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tabGraph.ResumeLayout(False)
        CType(Me.chrtMARK10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabData.ResumeLayout(False)
        Me.tabData.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlCamera.ResumeLayout(False)
        Me.pnlCamera.PerformLayout()
        CType(Me.pbxCameraLive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrSerialPortScan As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents cbBaudRate As ComboBox
    Friend WithEvents lnkPortStatus As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents cbComPorts As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents btnExtend As Button
    Friend WithEvents btnRetract As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnStartCycle As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNumOfCycles As MaskedTextBox
    Friend WithEvents txtStartPosition As MaskedTextBox
    Friend WithEvents txtStopPosition As MaskedTextBox
    Friend WithEvents btnPollUpdate As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents txtStartHoldTime As MaskedTextBox
    Friend WithEvents txtStopHoldTime As MaskedTextBox
    Friend WithEvents txtmCurrentInchesFromHome As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnGoToFullExtend As Button
    Friend WithEvents btnGoToFullRetract As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnSetFullExtended As Button
    Friend WithEvents btnSetFullRetracted As Button
    Friend WithEvents chkCalibrate As CheckBox
    Friend WithEvents btnGoToCycleHome As Button
    Friend WithEvents btnGoToCycle As Button
    Friend WithEvents setCycleHome As Button
    Friend WithEvents btnSetCycle As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents txtExtendRateDelay As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btn_QuickExtend As Button
    Friend WithEvents btn_QuickRetract As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtReceiveIn As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btn_usr_QuickRetract As Button
    Friend WithEvents btn_usr_Retract As Button
    Friend WithEvents btn_usr_QuickExtend As Button
    Friend WithEvents btn_usr_Extend As Button
    Friend WithEvents btn_usr_FullExtend As Button
    Friend WithEvents btn_usr_FullRetract As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label18 As Label
    Friend WithEvents lbl_Squeezer As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn_SetSqueeze As Button
    Friend WithEvents btn_GotoSqueeze As Button
    Friend WithEvents btn_SetHome As Button
    Friend WithEvents btn_GotoHome As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_StartCycle As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents btn_Stop As Button
    Friend WithEvents lbl_TestStatus As Label
    Friend WithEvents lbl_Running As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lnk_CycleHoldTime As LinkLabel
    Friend WithEvents lnk_NumOfCycles As LinkLabel
    Friend WithEvents lnk_CycleHomeHoldTime As LinkLabel
    Friend WithEvents lnk_Distance As LinkLabel
    Friend WithEvents lbl_TestStatus2 As Label
    Friend WithEvents lblCurrentA2DOffset As Label
    Friend WithEvents lblCurrentA2D As Label
    Friend WithEvents lblDistanceA2DFromHome As Label
    Friend WithEvents lblAcutalA2DPostion As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCycleA2D As Label
    Friend WithEvents lblHomeA2D As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents lblFullRetractA2D As Label
    Friend WithEvents lblFullExtendA2D As Label
    Friend WithEvents txtCurrentMillimetersFullMap As TextBox
    Friend WithEvents txtCyclePositionMillimetersFromHome As TextBox
    Friend WithEvents txtCurrentMillimetersFromHome As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chkbxDebugMessages As CheckBox
    Friend WithEvents Label28 As Label
    Friend WithEvents chkbxDirectDriveToTarget As CheckBox
    Friend WithEvents txtDirectDriveRange As MaskedTextBox
    Friend WithEvents lnklblUnitSerialNumber As LinkLabel
    Friend WithEvents lnkMARK10PortStatus As LinkLabel
    Friend WithEvents Label27 As Label
    Friend WithEvents cbMARK10ComPorts As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents SerialPort2 As IO.Ports.SerialPort
    Friend WithEvents lblMARK10Status As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtMARK10ReceiveIn As TextBox
    Friend WithEvents txtMARK10Reading As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnMARK10Clear As Button
    Friend WithEvents chrtMARK10 As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents tabGraph As TabPage
    Friend WithEvents tabData As TabPage
    Friend WithEvents txtMARK10Data As TextBox
    Friend WithEvents tmrMARK10Data As Timer
    Friend WithEvents btnClearMARK10 As Button
    Friend WithEvents btnSaveMARK10 As Button
    Friend WithEvents SaveFileMARK10 As SaveFileDialog
    Friend WithEvents Label14 As Label
    Friend WithEvents txtMARK10Units As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtMARK10ForceUnits As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMARK10ForceData As TextBox
    Friend WithEvents pnlCamera As Panel
    Friend WithEvents pbxCameraLive As PictureBox
    Friend WithEvents cmbxCameraList As ComboBox
    Friend WithEvents cmbxCameraVideoCapabilties As ComboBox
    Friend WithEvents lnkWorkingDirectory As LinkLabel
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents tmrSavePhoto As Timer
    Friend WithEvents SaveFilePhoto As SaveFileDialog
    Friend WithEvents btnOverlay As Button
    Friend WithEvents baseImageOpenFileDialog As OpenFileDialog
    Friend WithEvents overleyImageOpenFileDialog As OpenFileDialog
    Friend WithEvents btnStopRecord As Button
    Friend WithEvents btnStartRecord As Button
    Friend WithEvents recordOpenFileDialog As OpenFileDialog
    Friend WithEvents recordSaveFileDialog As SaveFileDialog
    Friend WithEvents btnSavePhoto As Button
    Friend WithEvents rdobtnRecording As RadioButton
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents lblWorkingDirectory As Label
    Friend WithEvents lblProjectFileName As Label
    Friend WithEvents txtbxProjectFileName As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
End Class
