Imports System.IO
Imports System.IO.Ports
Imports System.Math
Imports System.Drawing

Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow

Imports Accord
Imports Accord.Video.FFMPEG




Public Class frmSqueezer
    ' Public strSaveFileLacation As String = ""

    Private activeWidth As Int16 = 640 'starting default size
    Private activeHeight As Int16 = 480 'starting default size

    Private Elapsed_msec As Int32
    Private flgPauseLiveWhileSaveDialog As Boolean = False
    Private currentFame As Bitmap


    Private CycleNumber As Int16 = 1
    Private PhotoNumber As Int16 = 1

    Private availableCameras As FilterInfoCollection
    Private WithEvents activeCamera As VideoCaptureDevice
    Private activeVideoCameraCapibilities() As VideoCapabilities

    Private writter As New VideoFileWriter()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        availableCameras = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        If availableCameras.Count > 0 Then
            For Each Device As FilterInfo In availableCameras
                cmbxCameraList.Items.Add(Device.Name)
            Next
            ' retive setting from before
            If cmbxCameraList.Items.Count >= My.Settings.cmbxCameraIndex Then
                cmbxCameraList.SelectedIndex = My.Settings.cmbxCameraIndex
            Else
                cmbxCameraList.SelectedIndex = 0
            End If

            If cmbxCameraVideoCapabilties.Items.Count >= My.Settings.cmbxCameraVideoCapabilitiesIndex Then
                cmbxCameraVideoCapabilties.SelectedIndex = My.Settings.cmbxCameraVideoCapabilitiesIndex
            Else
                cmbxCameraVideoCapabilties.SelectedIndex = 0
            End If
        End If

        'restore from settings
        lblWorkingDirectory.Text = My.Settings.WorkingDirectory
        FolderBrowserDialog.SelectedPath = lblWorkingDirectory.Text
        baseImageOpenFileDialog.InitialDirectory = lblWorkingDirectory.Text
        overleyImageOpenFileDialog.InitialDirectory = lblWorkingDirectory.Text
        SaveFilePhoto.InitialDirectory = lblWorkingDirectory.Text
        recordOpenFileDialog.InitialDirectory = lblWorkingDirectory.Text
        recordSaveFileDialog.InitialDirectory = lblWorkingDirectory.Text
        SaveFileMARK10.InitialDirectory = lblWorkingDirectory.Text

        txtbxProjectFileName.Text = My.Settings.ProjectFileName



        txtMARK10Data.AppendText("Elapsed MilliSeconds , Reading,  Units" + vbCrLf)
        txtMARK10Data.Select(txtMARK10ReceiveIn.TextLength, 0)
        txtMARK10Data.ScrollToCaret()

        Dim portName As String
        If My.Computer.Ports.SerialPortNames.Count < 2 Then
            MsgBox("Critical Error!" + vbNewLine + vbNewLine + "Count of " + My.Computer.Ports.SerialPortNames.Count.ToString + " Serial Ports were detected on this machine." + vbNewLine + vbNewLine + "This program requires 2 Serial Port for RS232 communcation to the controller and the Mark-10", MsgBoxStyle.Critical)
        Else
            For Each portName In My.Computer.Ports.SerialPortNames
                cbComPorts.Items.Add(portName)
                cbMARK10ComPorts.Items.Add(portName)
            Next

            'restore the com setting from last time
            cbBaudRate.SelectedIndex = My.Settings.COM_BAUD_RATE_DROP_DOWN

            If My.Settings.COM_PORT_DROP_DOWN > My.Computer.Ports.SerialPortNames.Count - 1 Then
                My.Settings.COM_PORT_DROP_DOWN = 0
                My.Settings.Save()
            End If
            ' cbComPorts.SelectedIndex = My.Settings.COM_PORT_DROP_DOWN

            If My.Settings.MARK10_COM_PORT_DROP_DOWN > My.Computer.Ports.SerialPortNames.Count - 1 Then
                My.Settings.MARK10_COM_PORT_DROP_DOWN = 0
                My.Settings.Save()
            End If
            ' cbMARK10ComPorts.SelectedIndex = My.Settings.MARK10_COM_PORT_DROP_DOWN

        End If

        tmrSerialPortScan.Enabled = True

        If My.Settings.FILE_LOCATION = "" Then
            My.Settings.FILE_LOCATION = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            My.Settings.Save()
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Me.Invoke(New EventHandler(AddressOf RcvData))
        'While SerialPort1.BytesToRead > 0
        'Call RcvData(Nothing, Nothing)
        'End While
    End Sub

    Private Sub RcvData(ByVal s As Object, ByVal e As EventArgs)
        Dim strRead As String
        Dim strReads() As String
        Do
            Try
                strRead = SerialPort1.ReadLine()
                If strRead.StartsWith("?,") And strRead.EndsWith(",?" & vbCr) Then
                    Try
                        strReads = strRead.Split(",")

                        lblAcutalA2DPostion.Text = strReads(1)
                        lblDistanceA2DFromHome.Text = strReads(2)
                        txtCurrentMillimetersFullMap.Text = (Val(strReads(3))).ToString()

                        lnk_Distance.Text = (Val(strReads(4))).ToString()
                        txtmCurrentInchesFromHome.Text = (Val(strReads(4))).ToString()
                        txtCurrentMillimetersFromHome.Text = (Val(strReads(4))).ToString()

                        txtStartHoldTime.Text = (strReads(5).Replace("?", "").Replace(vbCr, ""))
                        txtStopHoldTime.Text = (strReads(6).Replace("?", "").Replace(vbCr, ""))
                        txtNumOfCycles.Text = (strReads(7).Replace("?", "").Replace(vbCr, ""))

                        lblHomeA2D.Text = (strReads(8).Replace("?", "").Replace(vbCr, ""))
                        txtStartPosition.Text = ((strReads(9).Replace("?", "").Replace(vbCr, ""))).ToString()

                        lblCycleA2D.Text = (strReads(10).Replace("?", "").Replace(vbCr, ""))
                        txtStopPosition.Text = ((strReads(11).Replace("?", "").Replace(vbCr, ""))).ToString()
                        txtCyclePositionMillimetersFromHome.Text = ((strReads(12).Replace("?", "").Replace(vbCr, ""))).ToString()
                        lblFullExtendA2D.Text = (strReads(13).Replace("?", "").Replace(vbCr, ""))
                        lblFullRetractA2D.Text = (strReads(14).Replace("?", "").Replace(vbCr, ""))

                        txtExtendRateDelay.Text = strReads(15).Replace("?", "").Replace(vbCr, "")
                        '
                        If strReads(16).Replace("?", "").Replace(vbCr, "") = "0" Then
                            chkbxDebugMessages.CheckState = CheckState.Unchecked
                        Else
                            chkbxDebugMessages.CheckState = CheckState.Checked
                        End If

                        If strReads(17).Replace("?", "").Replace(vbCr, "") = "0" Then
                            chkbxDirectDriveToTarget.CheckState = CheckState.Unchecked
                        Else
                            chkbxDirectDriveToTarget.CheckState = CheckState.Checked
                        End If

                        txtDirectDriveRange.Text = strReads(18).Replace("?", "").Replace(vbCr, "")
                        lnklblUnitSerialNumber.Text = "SN: " + strReads(19).Replace("?", "").Replace(vbCr, "")

                        txtmCurrentInchesFromHome.Text = lnk_Distance.Text
                        lnk_NumOfCycles.Text = txtNumOfCycles.Text
                        lnk_CycleHoldTime.Text = txtStopHoldTime.Text + " seconds"
                        lnk_CycleHomeHoldTime.Text = txtStartHoldTime.Text + " seconds"

                        btn_usr_Retract.Enabled = True
                        btn_usr_Extend.Enabled = True
                        btn_usr_FullExtend.Enabled = True
                        btn_usr_FullRetract.Enabled = True
                        btn_usr_QuickExtend.Enabled = True
                        btn_usr_QuickRetract.Enabled = True
                        btn_GotoHome.Enabled = True
                        btn_GotoSqueeze.Enabled = True
                        btn_SetHome.Enabled = True
                        btn_SetSqueeze.Enabled = True

                        btn_Stop.Enabled = False
                        btn_StartCycle.Enabled = True

                        lnk_CycleHoldTime.Enabled = True
                        lnk_CycleHomeHoldTime.Enabled = True
                        lnk_NumOfCycles.Enabled = True
                        lnk_Distance.Enabled = True
                        'txtCurrentInchesFromHome.Enabled = True
                    Catch ex As Exception
                        MsgBox("Error 602" + vbNewLine + "Commuication Error - Parsing ? receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                    End Try

                ElseIf strRead.StartsWith("$,") And strRead.EndsWith(",$" & vbCr) Then
                    Try
                        strReads = strRead.Split(",")
                        lblAcutalA2DPostion.Text = strReads(1)
                        lblDistanceA2DFromHome.Text = strReads(2)
                        txtCurrentMillimetersFullMap.Text = (Val(strReads(3))).ToString()
                        lnk_Distance.Text = (Val(strReads(4))).ToString()
                        txtmCurrentInchesFromHome.Text = (Val(strReads(4))).ToString()
                        txtCurrentMillimetersFromHome.Text = (Val(strReads(4))).ToString()
                    Catch ex As Exception
                        MsgBox("Error 604" + vbNewLine + "Communication Error - Parsing $ receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                    End Try

                ElseIf strRead.Contains("Test Starting") = True Then
                    Try
                        btn_usr_Retract.Enabled = False
                        btn_usr_Extend.Enabled = False
                        btn_usr_FullExtend.Enabled = False
                        btn_usr_FullRetract.Enabled = False
                        btn_usr_QuickExtend.Enabled = False
                        btn_usr_QuickRetract.Enabled = False
                        btn_GotoHome.Enabled = False
                        btn_GotoSqueeze.Enabled = False
                        btn_SetHome.Enabled = False
                        btn_SetSqueeze.Enabled = False

                        btn_Stop.Enabled = True
                        btn_StartCycle.Enabled = False

                        lnk_CycleHoldTime.Enabled = False
                        lnk_CycleHomeHoldTime.Enabled = False
                        lnk_NumOfCycles.Enabled = False
                        lnk_Distance.Enabled = False

                        lbl_TestStatus.Text = "Cycles Left:" + txtNumOfCycles.Text + vbNewLine
                        lbl_TestStatus.Visible = True

                        lbl_Running.Visible = True


                    Catch ex As Exception
                        MsgBox("Error 603" + vbNewLine + "Communication Error - Parsing 'Test Starting' receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)
                    End Try


                ElseIf strRead.Contains("Test Stopped") = True Then
                    Try
                        btn_usr_Retract.Enabled = True
                        btn_usr_Extend.Enabled = True
                        btn_usr_FullExtend.Enabled = True
                        btn_usr_FullRetract.Enabled = True
                        btn_usr_QuickExtend.Enabled = True
                        btn_usr_QuickRetract.Enabled = True
                        btn_GotoHome.Enabled = True
                        btn_GotoSqueeze.Enabled = True
                        btn_SetHome.Enabled = True
                        btn_SetSqueeze.Enabled = True

                        btn_Stop.Enabled = False
                        btn_StartCycle.Enabled = True

                        lnk_CycleHoldTime.Enabled = True
                        lnk_CycleHomeHoldTime.Enabled = True
                        lnk_NumOfCycles.Enabled = True
                        lnk_Distance.Enabled = True

                        lbl_TestStatus.Visible = False
                        lbl_TestStatus2.Visible = False
                        lbl_Running.Visible = False

                        CycleNumber = 1
                        rdobtnRecording.Checked = False
                        tmrSavePhoto.Enabled = False
                    Catch ex As Exception
                        MsgBox("Error 603" + vbNewLine + "Communication Error - Parsing 'Test Stopped' receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)
                    End Try
                ElseIf strRead.Contains("Complete !") = True Then
                    Try
                        btnSaveMARK10_Click(Nothing, Nothing)
                        lbl_TestStatus.Text = strRead.Substring(strRead.IndexOf("Complete !"))
                        lbl_TestStatus2.Text = ("Files saved - Press Stop.")
                        lbl_Running.Visible = False
                        lbl_TestStatus.Visible = True
                        lbl_TestStatus2.Visible = True
                        tmrMARK10Data.Enabled = False

                        ''rdobtnRecording.Checked = False
                        'tmrSavePhoto.Enabled = False
                    Catch ex As Exception
                        MsgBox("Error 603" + vbNewLine + "Communication Error - Parsing 'Complete !' receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                    End Try

                ElseIf strRead.Contains("Hold ") = True Then
                    Try
                        lnk_Distance.Text = Val(strRead.Remove(strRead.IndexOf("Hold "))).ToString()
                        lbl_TestStatus2.Text = strRead.Substring(strRead.IndexOf("Hold "))
                        lbl_TestStatus2.Visible = True

                    Catch ex As Exception
                        MsgBox("Error 603" + vbNewLine + "Communication Error - Parsing 'Hold ' receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                    End Try

                ElseIf strRead.Contains("Cycles Left:") = True Then
                    Try
                        lbl_TestStatus.Text = strRead.Substring(strRead.IndexOf("Cycles Left:"))
                        lbl_TestStatus.Visible = True
                    Catch ex As Exception
                        MsgBox("Error 603" + vbNewLine + "Communication Error - Parsing 'Cycles Left:'  receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                    End Try

                ElseIf strRead.Contains("Start Drive to") = True Then
                    Try
                        lbl_TestStatus2.Text = strRead.Substring(strRead.IndexOf("Start Drive to"))
                        lbl_TestStatus2.Visible = True
                        If lbl_TestStatus2.Text.Contains("Cycle") = True Then
                            rdobtnRecording.Checked = True
                            tmrSavePhoto.Enabled = True
                            Try
                                'open the video file
                                If writter.IsOpen Then
                                    MsgBox("Video File Still Open")
                                End If
                                writter.Close() ' make sure prevoius one is closed
                                writter.Open(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text + "\" + txtbxProjectFileName.Text + "_Squeeze" + CycleNumber.ToString() + "_" + Now.Ticks.ToString() + ".wmv", activeWidth, activeHeight, 30, VideoCodec.WMV2)
                                'flgRecord = True
                            Catch ex As Exception
                                MsgBox("Error 603a" + vbNewLine + "File error writing to *.mvv" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                            End Try
                Else
                            CycleNumber += 1
                            rdobtnRecording.Checked = False
                            tmrSavePhoto.Enabled = False
                            ' close the video file
                            'flgRecord = False
                            writter.Close()

                        End If


                    Catch ex As Exception
                        MsgBox("Error 603" + vbNewLine + "Communication Error - Parsing 'Start Drive to' receive command" + vbNewLine + ex.Message, MsgBoxStyle.Information)

                    End Try

                Else
                    txtReceiveIn.AppendText(strRead + vbCrLf)
                End If
            Catch ex As Exception
                MsgBox("Error XXX" + vbNewLine + "Communication Error" + vbNewLine + ex.Message, MsgBoxStyle.Information)

            End Try
        Loop While SerialPort1.BytesToRead

        txtReceiveIn.AppendText(SerialPort1.ReadExisting())

        txtReceiveIn.Select(txtReceiveIn.TextLength, 0)
        txtReceiveIn.ScrollToCaret()
    End Sub
    Private Sub cbBaudRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBaudRate.SelectedIndexChanged
        If cbComPorts.SelectedItem = "" Then
            Exit Sub

        End If
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port Not open."
        End If

        SerialPort1.PortName = cbComPorts.SelectedItem
        SerialPort1.BaudRate = cbBaudRate.SelectedItem
        ' save off the setting
        My.Settings.COM_BAUD_RATE_DROP_DOWN = cbBaudRate.SelectedIndex
        My.Settings.Save()
        Try
            SerialPort1.BaudRate = cbBaudRate.SelectedItem
            SerialPort1.Open()
            lnkPortStatus.LinkColor = Color.Blue
            lnkPortStatus.Text = "open"
            lblStatus.ForeColor = Color.Blue
            lblStatus.Text = "Ready: "
        Catch ex As Exception
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            ' CollectRcv = ""
            MsgBox("Error!" + vbNewLine + vbNewLine + "Unable to open the selected Serial Port " + SerialPort1.PortName + " for communications." + vbNewLine + "Verify that it is available and not in use by another program" + vbNewLine + "or select a different port and retry.", MsgBoxStyle.Exclamation, "Serial Port Error")
        End Try
    End Sub
    Private Sub cbComPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbComPorts.SelectedIndexChanged

        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End If

        SerialPort1.PortName = cbComPorts.SelectedItem
        ' save off the setting
        My.Settings.COM_PORT_DROP_DOWN = cbComPorts.SelectedIndex
        My.Settings.Save()
        Try
            SerialPort1.BaudRate = cbBaudRate.SelectedItem
            SerialPort1.Open()
            lnkPortStatus.LinkColor = Color.Blue
            lnkPortStatus.Text = "open"
            lblStatus.ForeColor = Color.Blue
            lblStatus.Text = "Ready: "
            DisplayReadyToStartState()
        Catch ex As Exception
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
            MsgBox("Error 103" + vbNewLine + vbNewLine + "Unable to open the selected Serial Port " + SerialPort1.PortName + " for commuications." + vbNewLine + "Verify that it is available and not in use by another program" + vbNewLine + "or select a different port and retry.", MsgBoxStyle.Exclamation, "Serial Port Error")
        End Try

        ' send a querry when port is open 
        Try
            If SerialPort1.IsOpen Then
                '       SerialPort1.Write("?")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub lnkPortStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPortStatus.LinkClicked
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."

            DisplayNoComState()

        Else
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            Try
                SerialPort1.BaudRate = cbBaudRate.SelectedItem
                SerialPort1.Open()
                lnkPortStatus.LinkColor = Color.Blue
                lnkPortStatus.Text = "open"
                lblStatus.ForeColor = Color.Blue
                lblStatus.Text = "Ready: ."
                DisplayReadyToStartState()
            Catch ex As Exception
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
                MsgBox("Error 101" + vbNewLine + vbNewLine + "Unable to open the selected Serial Port " + SerialPort1.PortName + " for communications." + vbNewLine + "Verify that it is available and not in use by another program" + vbNewLine + "or select a different port and retry." + vbNewLine + vbNewLine + ex.Message, MsgBoxStyle.Exclamation, "Serial Port Error")
            End Try

            ' send a querry when port is open 
            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Write("?")
                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort1.Close()
                lnkPortStatus.LinkColor = Color.Crimson
                lnkPortStatus.Text = "closed"
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try

        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub tmrSerialPortScan_Tick(sender As Object, e As EventArgs) Handles tmrSerialPortScan.Tick

        If My.Computer.Ports.SerialPortNames.Count <> cbComPorts.Items.Count Then

            'Dim portName As String
            cbComPorts.Items.Clear()

            'cbComPorts.SelectedText = ""
            'If My.Computer.Ports.SerialPortNames.Count = 0 Then
            '    ' MsgBox("Critical Error!" + vbNewLine + vbNewLine + "No Serial Ports were detected on this machine." + vbNewLine + "This program requires a Serial Port for RS232 communcation", MsgBoxStyle.Critical)
            '    ' Me.Close()
            'Else
            For Each portName In My.Computer.Ports.SerialPortNames
                cbComPorts.Items.Add(portName)
            Next

            '    'restore the com setting from last time
            '    cbBaudRate.SelectedIndex = My.Settings.COM_BAUD_RATE_DROP_DOWN
            '    cbComPorts.SelectedIndex = My.Settings.COM_PORT_DROP_DOWN

            'End If 
        End If
    End Sub
    Private Sub DisplayNoComState()
    End Sub
    Private Sub DisplayReadyToStartState()
    End Sub
    Private Sub DisplayRunningNotSavingState()
    End Sub
    Private Sub DisplayRunningWithSavingState()
    End Sub
    Private Sub btnStop_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnStartCycle_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtReceiveIn.Clear()
    End Sub

    Private Sub txtNumOfCycles_Leave(sender As Object, e As EventArgs) Handles txtNumOfCycles.Leave
        Try
            If SerialPort1.IsOpen Then
                txtNumOfCycles.Text = txtNumOfCycles.Text.PadLeft(4, "0")
                lnk_NumOfCycles.Text = txtNumOfCycles.Text.TrimStart("0")
                SerialPort1.Write(txtNumOfCycles.Text + "y")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub txtStopHoldTime_Leave(sender As Object, e As EventArgs) Handles txtStopHoldTime.Leave
        Try
            If SerialPort1.IsOpen Then
                txtStopHoldTime.Text = txtStopHoldTime.Text.PadLeft(2, "0")
                lnk_CycleHoldTime.Text = txtStopHoldTime.Text.TrimStart("0") + " seconds"
                SerialPort1.Write(txtStopHoldTime.Text + "m")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub txtStartHoldTime_Leave(sender As Object, e As EventArgs) Handles txtStartHoldTime.Leave
        Try
            If SerialPort1.IsOpen Then
                txtStartHoldTime.Text = txtStartHoldTime.Text.PadLeft(2, "0")
                lnk_CycleHomeHoldTime.Text = txtStartHoldTime.Text.TrimStart("0") + " seconds"
                SerialPort1.Write(txtStartHoldTime.Text + "t")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub txtStartPosition_Leave(sender As Object, e As EventArgs) Handles txtStartPosition.Leave
        Try
            If SerialPort1.IsOpen Then
                '                    txtStartHoldTime.Text = txtStartHoldTime.Text.PadLeft(3, "0")
                Dim str As String = (txtStartPosition.Text).ToString.PadLeft(3, "0")

                SerialPort1.Write(str + "b")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub txtStopPosition_Leave(sender As Object, e As EventArgs) Handles txtStopPosition.Leave
        Try
            If SerialPort1.IsOpen Then
                Dim str As String = (txtStopPosition.Text).ToString.PadLeft(3, "0")
                SerialPort1.Write(str + "e")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkCalibrate.CheckedChanged
        btnSetFullExtended.Visible = chkCalibrate.Checked
        btnSetFullRetracted.Visible = chkCalibrate.Checked
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RcvData(Nothing, Nothing)
    End Sub

    Private Sub txtExtendRateDelay_Leave(sender As Object, e As EventArgs) Handles txtExtendRateDelay.Leave
        Try
            If SerialPort1.IsOpen Then
                Dim str As String = (txtExtendRateDelay.Text).ToString.PadLeft(1, "0")
                SerialPort1.Write(str + "d")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub btnSendTagCommand_Click(sender As Object, e As EventArgs) Handles btnExtend.Click, btnRetract.Click, btn_QuickRetract.Click, btn_QuickExtend.Click, btnStop.Click, btnStartCycle.Click, setCycleHome.Click, btnSetFullRetracted.Click, btnSetFullExtended.Click, btnSetCycle.Click, btnPollUpdate.Click, btnGoToFullRetract.Click, btnGoToFullExtend.Click, btnGoToCycleHome.Click, btnGoToCycle.Click, btn_usr_Retract.Click, btn_usr_QuickRetract.Click, btn_usr_QuickExtend.Click, btn_usr_FullRetract.Click, btn_usr_FullExtend.Click, btn_usr_Extend.Click, btn_Stop.Click, btn_StartCycle.Click, btn_SetSqueeze.Click, btn_SetHome.Click, btn_GotoSqueeze.Click, btn_GotoHome.Click

        btnSetFullExtended.Visible = False
        btnSetFullRetracted.Visible = False
        chkCalibrate.Checked = False

        If sender.tag.ToString.Contains("c") Then ' start test cycle command 
            ' check that project file directory is valid
            'If Directory.Exists(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text) Then
            '    MsgBox("ERROR! That Project Already Exists." + vbNewLine + "Use a uniquie Project Name or Externally Delete this one." + vbNewLine + vbNewLine + lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)
            '    Exit Sub
            'End If

            'Directory.CreateDirectory(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)
            'Call btnClearMARK10_Click(Nothing, Nothing)

            'first entry is at zero time
            Elapsed_msec = 0
            chrtMARK10.Series("Force").Points.AddXY(Elapsed_msec, (txtMARK10Reading.Text))
            txtMARK10ForceData.Text = txtMARK10Reading.Text
            txtMARK10ForceUnits.Text = txtMARK10Units.Text
            txtMARK10Data.AppendText(Elapsed_msec.ToString + ",  " + txtMARK10Reading.Text + ",  " + txtMARK10Units.Text + vbLf)
            txtMARK10Data.Select(txtMARK10ReceiveIn.TextLength, 0)
            txtMARK10Data.ScrollToCaret()

            tmrMARK10Data.Enabled = True
        End If

        If sender.tag.ToString.Contains("s") Then ' stop test cycle command 
            tmrMARK10Data.Enabled = False
        End If

        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Write(sender.tag + vbNewLine)
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub btn_StartCycle_Click(sender As Object, e As EventArgs)
        Call btnStartCycle_Click(Nothing, Nothing)
    End Sub

    Private Sub btn_Stop_Click(sender As Object, e As EventArgs)
        Call btnStop_Click(Nothing, Nothing)
    End Sub

    Private Sub lnk_NumOfCycles_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_NumOfCycles.LinkClicked
        dlgNumOfCycles.txtNumberOfCycles.Text = txtNumOfCycles.Text
        If dlgNumOfCycles.ShowDialog() = DialogResult.OK Then
            If dlgNumOfCycles.txtNumberOfCycles.Text = 0 Then
                dlgNumOfCycles.txtNumberOfCycles.Text = 1
            End If
            txtNumOfCycles.Text = dlgNumOfCycles.txtNumberOfCycles.Text
            lnk_NumOfCycles.Text = txtNumOfCycles.Text
            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Write(txtNumOfCycles.Text.PadLeft(4, "0") + "y")
                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort1.Close()
                lnkPortStatus.LinkColor = Color.Crimson
                lnkPortStatus.Text = "closed"
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try
        End If
    End Sub

    Private Sub lnk_CycleHomeHoldTime_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_CycleHomeHoldTime.LinkClicked

        dlgCycleHomeHoldTime.txtHomeHoldTime.Text = txtStartHoldTime.Text
        If dlgCycleHomeHoldTime.ShowDialog() = DialogResult.OK Then
            txtStartHoldTime.Text = dlgCycleHomeHoldTime.txtHomeHoldTime.Text
            lnk_CycleHomeHoldTime.Text = txtStartHoldTime.Text + " seconds"
            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Write(txtStartHoldTime.Text.PadLeft(4, "0") + "t")
                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort1.Close()
                lnkPortStatus.LinkColor = Color.Crimson
                lnkPortStatus.Text = "closed"
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try
        End If
    End Sub

    Private Sub lnk_CycleHoldTime_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_CycleHoldTime.LinkClicked

        dlgCycleHoldTime.txtCycleHoldTime.Text = txtStopHoldTime.Text
        If dlgCycleHoldTime.ShowDialog() = DialogResult.OK Then
            txtStopHoldTime.Text = dlgCycleHoldTime.txtCycleHoldTime.Text
            lnk_CycleHoldTime.Text = txtStopHoldTime.Text + " seconds"

            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Write(txtStopHoldTime.Text.PadLeft(4, "0") + "m")
                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort1.Close()
                lnkPortStatus.LinkColor = Color.Crimson
                lnkPortStatus.Text = "closed"
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try
        End If
    End Sub

    Private Sub lnk_Distance_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_Distance.LinkClicked

        If Val(lnk_Distance.Text) < 0 Then
            dlgDistance.chkRetractDirection.Checked = True
        Else
            dlgDistance.chkRetractDirection.Checked = False
        End If
        dlgDistance.txtDistance.Text = Abs(Val(lnk_Distance.Text))
        If dlgDistance.ShowDialog() = DialogResult.OK Then
            If dlgDistance.chkRetractDirection.Checked Then
                lnk_Distance.Text = "-" + Val(dlgDistance.txtDistance.Text).ToString()
            Else
                lnk_Distance.Text = Val(dlgDistance.txtDistance.Text).ToString()
            End If
            Try
                If SerialPort1.IsOpen Then
                    If dlgDistance.chkRetractDirection.Checked Then
                        SerialPort1.Write(Abs(Val(lnk_Distance.Text)).ToString.PadLeft(3, "0") + "-")
                    Else
                        SerialPort1.Write(Abs(Val(lnk_Distance.Text)).ToString.PadLeft(3, "0") + "+")
                    End If

                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort1.Close()
                lnkPortStatus.LinkColor = Color.Crimson
                lnkPortStatus.Text = "closed"
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try
        End If
    End Sub

    Private Sub chkbxDebugMessages_CheckedChanged(sender As Object, e As EventArgs) Handles chkbxDebugMessages.CheckedChanged
        Try
            If SerialPort1.IsOpen Then
                If chkbxDebugMessages.Checked Then
                    SerialPort1.Write("1D")
                Else
                    SerialPort1.Write("0D")
                End If
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub chkbxDirectDriveToTarget_CheckedChanged(sender As Object, e As EventArgs) Handles chkbxDirectDriveToTarget.CheckedChanged
        Try
            If SerialPort1.IsOpen Then
                If chkbxDirectDriveToTarget.Checked Then
                    SerialPort1.Write("1_")
                Else
                    SerialPort1.Write("0_")
                End If
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub txtDirectDriveRange_Leave(sender As Object, e As EventArgs) Handles txtDirectDriveRange.Leave
        Try
            If SerialPort1.IsOpen Then
                txtDirectDriveRange.Text = txtDirectDriveRange.Text.PadLeft(2, "0")
                SerialPort1.Write(txtDirectDriveRange.Text + "=")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort1.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub

    Private Sub lnklblUnitSerialNumber_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblUnitSerialNumber.LinkClicked
        dlgSetUnitSerialNumber.txtUnitSerialNumber.Text = lnklblUnitSerialNumber.Tag
        If dlgSetUnitSerialNumber.ShowDialog() = DialogResult.OK Then
            lnklblUnitSerialNumber.Tag = dlgSetUnitSerialNumber.txtUnitSerialNumber.Text
            lnklblUnitSerialNumber.Text = "SN:" + lnklblUnitSerialNumber.Tag
            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Write(lnklblUnitSerialNumber.Tag + "a")
                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort1.Close()
                lnkPortStatus.LinkColor = Color.Crimson
                lnkPortStatus.Text = "closed"
                lblStatus.ForeColor = Color.Crimson
                lblStatus.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try
        End If
    End Sub

    Private Sub cbMARK10ComPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMARK10ComPorts.SelectedIndexChanged

        If SerialPort2.IsOpen Then
            SerialPort2.Close()
            lnkMARK10PortStatus.LinkColor = Color.Crimson
            lnkMARK10PortStatus.Text = "closed"
            lblMARK10Status.ForeColor = Color.Crimson
            lblMARK10Status.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End If

        SerialPort2.PortName = cbMARK10ComPorts.SelectedItem
        ' save off the setting
        My.Settings.MARK10_COM_PORT_DROP_DOWN = cbMARK10ComPorts.SelectedIndex
        My.Settings.Save()
        Try
            SerialPort2.Open()
            lnkMARK10PortStatus.LinkColor = Color.Blue
            lnkMARK10PortStatus.Text = "open"
            lblMARK10Status.ForeColor = Color.Blue
            lblMARK10Status.Text = "Ready: "
            DisplayReadyToStartState()
        Catch ex As Exception
            lblMARK10Status.ForeColor = Color.Crimson
            lblMARK10Status.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
            MsgBox("Error 123" + vbNewLine + vbNewLine + "Unable to open the selected Serial Port " + SerialPort1.PortName + " for commuications." + vbNewLine + "Verify that it is available and not in use by another program" + vbNewLine + "or select a different port and retry.", MsgBoxStyle.Exclamation, "Serial Port Error")
        End Try

        ' send a querry when port is open 
        Try
            If SerialPort2.IsOpen Then
                SerialPort2.Write("?")
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort2.Close()
            lnkMARK10PortStatus.LinkColor = Color.Crimson
            lnkMARK10PortStatus.Text = "closed"
            lblMARK10Status.ForeColor = Color.Crimson
            lblMARK10Status.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try

    End Sub


    Private Sub lnkMARK10PortStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMARK10PortStatus.LinkClicked
        If SerialPort2.IsOpen Then
            SerialPort2.Close()
            lnkMARK10PortStatus.LinkColor = Color.Crimson
            lnkMARK10PortStatus.Text = "closed"
            lblMARK10Status.ForeColor = Color.Crimson
            lblMARK10Status.Text = "Serial Port Error:  Port not open."

            DisplayNoComState()

        Else
            lnkMARK10PortStatus.LinkColor = Color.Crimson
            lnkMARK10PortStatus.Text = "closed"
            lblMARK10Status.ForeColor = Color.Crimson
            lblMARK10Status.Text = "Serial Port Error:  Port not open."
            Try
                SerialPort2.Open()
                lnkMARK10PortStatus.LinkColor = Color.Blue
                lnkMARK10PortStatus.Text = "open"
                lblMARK10Status.ForeColor = Color.Blue
                lblMARK10Status.Text = "Ready: ."
                DisplayReadyToStartState()
            Catch ex As Exception
                lblMARK10Status.ForeColor = Color.Crimson
                lblMARK10Status.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
                MsgBox("Error 101" + vbNewLine + vbNewLine + "Unable to open the selected Serial Port " + SerialPort1.PortName + " for communications." + vbNewLine + "Verify that it is available and not in use by another program" + vbNewLine + "or select a different port and retry." + vbNewLine + vbNewLine + ex.Message, MsgBoxStyle.Exclamation, "Serial Port Error")
            End Try

            ' send a querry when port is open 
            Try
                If SerialPort2.IsOpen Then
                    SerialPort2.Write("?")
                End If

            Catch ex As Exception
                MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
                SerialPort2.Close()
                lnkMARK10PortStatus.LinkColor = Color.Crimson
                lnkMARK10PortStatus.Text = "closed"
                lblMARK10Status.ForeColor = Color.Crimson
                lblMARK10Status.Text = "Serial Port Error:  Port not open."
                DisplayNoComState()
            End Try

        End If
    End Sub


    Private Sub SerialPort2_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        Try
            Me.Invoke(New EventHandler(AddressOf MARK10RcvData))
            'While SerialPort2.BytesToRead > 0
            'Call MARK10RcvData(Nothing, Nothing)
            'End While
        Catch ex As Exception

        End Try


    End Sub
    Private Sub MARK10RcvData(ByVal s As Object, ByVal e As EventArgs)
        Dim strRead As String
        Dim strReads() As String
        Do
            Try
                strRead = SerialPort2.ReadLine()
                strReads = strRead.Split(" ")

                txtMARK10Reading.Text = strReads(0)
                txtMARK10Units.Text = strReads(1)
                txtMARK10ReceiveIn.AppendText(strRead + vbCrLf)

            Catch ex As Exception
                MsgBox("Error 602" + vbNewLine + "Communication Error" + vbNewLine + ex.Message, MsgBoxStyle.Information)
                Exit Do
            End Try
        Loop While SerialPort2.BytesToRead

        txtMARK10ReceiveIn.AppendText(SerialPort2.ReadExisting())

        txtMARK10ReceiveIn.Select(txtMARK10ReceiveIn.TextLength, 0)
        txtMARK10ReceiveIn.ScrollToCaret()

        txtMARK10ForceData.Text = txtMARK10Reading.Text
        txtMARK10ForceUnits.Text = txtMARK10Units.Text
    End Sub

    Private Sub btnMARK10Clear_Click(sender As Object, e As EventArgs) Handles btnMARK10Clear.Click
        txtMARK10ReceiveIn.Clear()
    End Sub

    Private Sub tmrMARK10Data_Tick(sender As Object, e As EventArgs) Handles tmrMARK10Data.Tick
        Elapsed_msec += tmrMARK10Data.Interval

        chrtMARK10.Series("Force").Points.AddXY(Elapsed_msec, (txtMARK10Reading.Text))
        txtMARK10ForceData.Text = txtMARK10Reading.Text
        txtMARK10ForceUnits.Text = txtMARK10Units.Text

        txtMARK10Data.AppendText(Elapsed_msec.ToString + ",  " + txtMARK10Reading.Text + ",  " + txtMARK10Units.Text + vbLf)

        txtMARK10Data.Select(txtMARK10ReceiveIn.TextLength, 0)
        txtMARK10Data.ScrollToCaret()

    End Sub

    Private Sub btnSaveMARK10_Click(sender As Object, e As EventArgs) Handles btnSaveMARK10.Click
        SaveFileMARK10.FileName = lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text + "\" + txtbxProjectFileName.Text + "_Force_" + Now.Ticks.ToString() + ".csv"
        'If (SaveFileMARK10.ShowDialog() = DialogResult.OK) Then
        Try
                My.Computer.FileSystem.WriteAllText(SaveFileMARK10.FileName, txtMARK10Data.Text, False)
            Catch ex As Exception
                MsgBox("Error 601" + vbNewLine + "Save MARK10 Data to CSV File Error" + vbNewLine + ex.Message, MsgBoxStyle.Information)
            End Try

        ' End If


    End Sub

    Private Sub btnClearMARK10_Click(sender As Object, e As EventArgs) Handles btnClearMARK10.Click
        txtMARK10Data.Clear()
        Elapsed_msec = 0
        chrtMARK10.Series("Force").Points.Clear()
        txtMARK10ForceData.Clear()
        txtMARK10ForceUnits.Clear()
        txtMARK10Data.AppendText("Elapsed MilliSeconds , Reading,  Units" + vbCrLf)
        txtMARK10Data.Select(txtMARK10ReceiveIn.TextLength, 0)
        txtMARK10Data.ScrollToCaret()
    End Sub

    Private Sub frmSqueezer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End  ' need this to kill the serial port invokes
    End Sub

    Private Sub event_activeCamera_NewFrame(sender As Object, eventArgs As NewFrameEventArgs) Handles activeCamera.NewFrame
        Try
            If flgPauseLiveWhileSaveDialog = False Then
                pbxCameraLive.Image = eventArgs.Frame.Clone()
            End If

            If writter.IsOpen Then
                writter.WriteVideoFrame(eventArgs.Frame)
                'Else
                '    If writter.IsOpen Then
                '        writter.Close()
                'End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxCameraList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxCameraList.SelectedIndexChanged
        Try
            If activeCamera IsNot Nothing Then
                If activeCamera.IsRunning Then
                    activeCamera.Stop()
                End If
            End If

            activeCamera = New VideoCaptureDevice(availableCameras(cmbxCameraList.SelectedIndex).MonikerString)
            AddHandler activeCamera.NewFrame, AddressOf event_activeCamera_NewFrame

            activeVideoCameraCapibilities = activeCamera.VideoCapabilities
            cmbxCameraVideoCapabilties.Items.Clear()
            For Each Capability As VideoCapabilities In activeVideoCameraCapibilities
                cmbxCameraVideoCapabilties.Items.Add(Capability.FrameSize)
            Next

            ' restore from before
            If cmbxCameraVideoCapabilties.Items.Count >= My.Settings.cmbxCameraVideoCapabilitiesIndex Then
                cmbxCameraVideoCapabilties.SelectedIndex = My.Settings.cmbxCameraVideoCapabilitiesIndex
            Else
                cmbxCameraVideoCapabilties.SelectedIndex = 0
            End If

            My.Settings.cmbxCameraIndex = cmbxCameraList.SelectedIndex
            My.Settings.Save()

            activeCamera.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbxCameraVideoCapabilties_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxCameraVideoCapabilties.SelectedIndexChanged
        Try
            If activeCamera IsNot Nothing Then
                If activeCamera.IsRunning Then
                    activeCamera.Stop()
                End If
            End If

            activeCamera.VideoResolution = activeVideoCameraCapibilities(cmbxCameraVideoCapabilties.SelectedIndex)
            activeWidth = activeCamera.VideoResolution.FrameSize.Width
            activeHeight = activeCamera.VideoResolution.FrameSize.Height
            'change picturebox display for 4:3 (640x480) or 16:9 (640:360) ratio ; 
            If activeHeight = 1080 Or activeHeight = 720 Or activeHeight = 180 Then
                pbxCameraLive.Height = 360
            Else
                pbxCameraLive.Height = 480
            End If

            My.Settings.cmbxCameraVideoCapabilitiesIndex = cmbxCameraVideoCapabilties.SelectedIndex
            My.Settings.Save()

            activeCamera.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnkSavePhotoTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkWorkingDirectory.LinkClicked
        FolderBrowserDialog.ShowDialog()
        lblWorkingDirectory.Text = FolderBrowserDialog.SelectedPath
        My.Settings.WorkingDirectory = lblWorkingDirectory.Text
        My.Settings.Save()

    End Sub



    Private Sub tmrSavePhoto_Tick(sender As Object, e As EventArgs) Handles tmrSavePhoto.Tick
        Try
            'pbxCameraLive.Image.Save(SaveFilePhoto.FileName + " " + Now.Ticks.ToString() + " Squeeze" + CycleNumber.ToString() + ".png", Imaging.ImageFormat.Png)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnOverlay_Click(sender As Object, e As EventArgs) Handles btnOverlay.Click
        activeCamera.Stop()
        baseImageOpenFileDialog.Title = "Select the background image"
        baseImageOpenFileDialog.ShowDialog()
        Dim baseImage As New Bitmap(baseImageOpenFileDialog.FileName)
        pbxCameraLive.Image = baseImage
        MsgBox(baseImageOpenFileDialog.FileName,, "Background Image Loaded")

        overleyImageOpenFileDialog.Title = "Select the overlay image, green will be transparent"
        overleyImageOpenFileDialog.ShowDialog()
        Dim overlayImage As New Bitmap(overleyImageOpenFileDialog.FileName)
        overlayImage = TurnToGreen(overlayImage)
        overlayImage.MakeTransparent(Color.Lime)
        pbxCameraLive.Image = overlayImage
        pbxCameraLive.BackColor = Color.Transparent
        MsgBox(overleyImageOpenFileDialog.FileName,, "Overlay Image Loaded")

        Dim combineImage As New Bitmap(baseImage.Width, baseImage.Height)

        Using g As Graphics = Graphics.FromImage(combineImage)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            overlayImage.MakeTransparent(Color.Lime)
            g.DrawImage(baseImage, New Rectangle(0, 0, baseImage.Width, baseImage.Height))
            g.DrawImage(overlayImage, New Rectangle(0, 0, overlayImage.Width, overlayImage.Height))

            'g.DrawLine(New Pen(Color.Lime, 3), New PointF(0, 0), New PointF(baseImage.Width,baseImage.Height))

        End Using

        pbxCameraLive.Image = combineImage
        MsgBox("Overlay Done")
        'baseImage.Save()

        activeCamera.Start()

        baseImage.Dispose()
        overlayImage.Dispose()

    End Sub

    Private Sub btnStopRecord_Click(sender As Object, e As EventArgs) Handles btnStopRecord.Click
        'flgRecord = False
        rdobtnRecording.Checked = False
        writter.Close()
    End Sub

    Private Sub btnStartRecord_Click(sender As Object, e As EventArgs) Handles btnStartRecord.Click
        recordSaveFileDialog.FileName = ""
        If recordSaveFileDialog.ShowDialog() = DialogResult.OK Then
            writter.Close()  ' make sure prevois one is closed
            writter.Open(recordSaveFileDialog.FileName, activeWidth, activeHeight, 30, VideoCodec.WMV2)
            'flgRecord = True
            rdobtnRecording.Checked = True
        End If
    End Sub

    Private Function TurnToGreen(bmp As Bitmap) As Bitmap
        Dim greenBitmap As New Bitmap(bmp.Width, bmp.Height)
        Dim w As Int16
        Dim h As Int16
        Dim pxColor As Color
        For w = 0 To (bmp.Width - 1)
            For h = 0 To (bmp.Height - 1)
                pxColor = bmp.GetPixel(w, h)

                If pxColor.G > pxColor.R + 5 Then
                    If pxColor.G > pxColor.B + 5 Then
                        bmp.SetPixel(w, h, Color.Lime)
                    End If
                End If

            Next
        Next

        Return bmp
    End Function

    Private Sub btnSavePhoto_Click(sender As Object, e As EventArgs) Handles btnSavePhoto.Click
        Try
            SaveFilePhoto.FileName = ""
            flgPauseLiveWhileSaveDialog = True
            If SaveFilePhoto.ShowDialog() = DialogResult.OK Then
                pbxCameraLive.Image.Save(SaveFilePhoto.FileName, Imaging.ImageFormat.Png)
                tmrSavePhoto.Enabled = False
            End If
            flgPauseLiveWhileSaveDialog = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbxProjectFileName_TextChanged(sender As Object, e As EventArgs) Handles txtbxProjectFileName.TextChanged

        'check if folder/project already exisit and get a new project name before starting
        If Directory.Exists(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text) Then
            MsgBox("ERROR! That Project Already Exists." + vbNewLine + "Use a uniquie Project Name or Externally Delete this one." + vbNewLine + vbNewLine + lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)

        End If

        My.Settings.ProjectFileName = txtbxProjectFileName.Text



    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub recordSaveFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles recordSaveFileDialog.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        btnSetFullExtended.Visible = False
        btnSetFullRetracted.Visible = False
        chkCalibrate.Checked = False

        If sender.tag.ToString.Contains("c") Then ' start test cycle command 
            ' check that project file directory is valid
            'If Directory.Exists(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text) Then
            '    MsgBox("ERROR! That Project Already Exists." + vbNewLine + "Use a uniquie Project Name or Externally Delete this one." + vbNewLine + vbNewLine + lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)
            '    Exit Sub
            'End If

            'Directory.CreateDirectory(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)
            'Call btnClearMARK10_Click(Nothing, Nothing)

            'first entry is at zero time
            Elapsed_msec = 0
            chrtMARK10.Series("Force").Points.AddXY(Elapsed_msec, (txtMARK10Reading.Text))
            txtMARK10ForceData.Text = txtMARK10Reading.Text
            txtMARK10ForceUnits.Text = txtMARK10Units.Text
            txtMARK10Data.AppendText(Elapsed_msec.ToString + ",  " + txtMARK10Reading.Text + ",  " + txtMARK10Units.Text + vbLf)
            txtMARK10Data.Select(txtMARK10ReceiveIn.TextLength, 0)
            txtMARK10Data.ScrollToCaret()

            tmrMARK10Data.Enabled = True
        End If

        If sender.tag.ToString.Contains("s") Then ' stop test cycle command 
            tmrMARK10Data.Enabled = False
        End If

        Try
            If SerialPort2.IsOpen Then
                '  SerialPort2.Write(sender.tag + vbNewLine)
                SerialPort2.Write("?PT" + vbNewLine)
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort2.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        btnSetFullExtended.Visible = False
        btnSetFullRetracted.Visible = False
        chkCalibrate.Checked = False

        If sender.tag.ToString.Contains("c") Then ' start test cycle command 
            ' check that project file directory is valid
            'If Directory.Exists(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text) Then
            '    MsgBox("ERROR! That Project Already Exists." + vbNewLine + "Use a uniquie Project Name or Externally Delete this one." + vbNewLine + vbNewLine + lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)
            '    Exit Sub
            'End If

            'Directory.CreateDirectory(lblWorkingDirectory.Text + "\" + txtbxProjectFileName.Text)
            'Call btnClearMARK10_Click(Nothing, Nothing)

            'first entry is at zero time
            Elapsed_msec = 0
            chrtMARK10.Series("Force").Points.AddXY(Elapsed_msec, (txtMARK10Reading.Text))
            txtMARK10ForceData.Text = txtMARK10Reading.Text
            txtMARK10ForceUnits.Text = txtMARK10Units.Text
            txtMARK10Data.AppendText(Elapsed_msec.ToString + ",  " + txtMARK10Reading.Text + ",  " + txtMARK10Units.Text + vbLf)
            txtMARK10Data.Select(txtMARK10ReceiveIn.TextLength, 0)
            txtMARK10Data.ScrollToCaret()

            tmrMARK10Data.Enabled = True
        End If

        If sender.tag.ToString.Contains("s") Then ' stop test cycle command 
            tmrMARK10Data.Enabled = False
        End If

        Try
            If SerialPort2.IsOpen Then
                ' SerialPort2.Write(sender.tag + vbNewLine)
                SerialPort2.Write("CLR" + vbNewLine)
            End If

        Catch ex As Exception
            MsgBox("Error 401" + vbNewLine + "Unable to communicate with device." + vbNewLine + "Check and verify connection and port selection." + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            SerialPort2.Close()
            lnkPortStatus.LinkColor = Color.Crimson
            lnkPortStatus.Text = "closed"
            lblStatus.ForeColor = Color.Crimson
            lblStatus.Text = "Serial Port Error:  Port not open."
            DisplayNoComState()
        End Try
    End Sub
End Class