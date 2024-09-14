Imports System.Deployment.Application
Module Restart_Options

    Public max_timeout As Integer = 315359999
    Public timeout As Integer = 0
    Public timer_count As Integer = 0
    Public bar_value As Integer = 0

    Public timeout_increment As UInteger = 15

    Dim temp_file As String = "C:\Windows\Temp\RestartOptions.tmp"

    Dim abort_cmd As String = "shutdown /a"

    Dim uefi_arg As String = ""
    Dim uefi_not_arg As String = " /fw "
    Dim advanced_arg As String = ""
    Dim force_arg As String = ""

    Public is_uefi As Boolean = False
    Dim restart_set As Boolean = False
    Public force_last As Boolean = False

    Public button_exit_text As String = "&Exit"
    Public button_exit_cancel_text As String = "Canc&el"
    Public button_exit_fw_text As String = "U&EFI Next Boot"

    Public tip_uefi_text As String = "Restart to firmware user interface"
    Public tip_advanced_text As String = "Go to the advanced boot options menu"
    Public tip_force_text As String = "Force running applications to close without forewarning users"
    Public tip_timeout_text As String = "Time-out period before restart in seconds"
    Public tip_restart_text As String = "Restart the computer with the selected options"
    Public tip_exit_text As String = "Exit app"
    Public tip_about_text As String = "About " + Application.ProductName
    Public tip_exit_cancel_text As String = "Abort system shutdown"
    Public tip_exit_fw_text As String = "Exit app and go to firmware user interface on next boot"

    Sub uefi_changed(ByVal checked As Boolean)
        ' Set shutdown args
        If checked = True Then
            uefi_arg = " /fw "
            uefi_not_arg = ""
            If restart_set = False Then
                Restart_Options_Form.Button_Exit.Text = button_exit_fw_text
                Restart_Options_Form.ToolTip_Exit.SetToolTip(Restart_Options_Form.Button_Exit, tip_exit_fw_text)
            End If
        Else
            uefi_arg = ""
            If is_uefi Then
                uefi_not_arg = " /fw "
            End If
            If restart_set = False Then
                Restart_Options_Form.Button_Exit.Text = button_exit_text
                Restart_Options_Form.ToolTip_Exit.SetToolTip(Restart_Options_Form.Button_Exit, tip_exit_text)
            End If
        End If
    End Sub

    Sub advanced_changed(ByVal checked As Boolean)
        ' Set shutdown args
        If checked = True Then
            advanced_arg = " /o "
        Else
            advanced_arg = ""
        End If
    End Sub

    Sub force_changed(ByVal checked As Boolean)
        ' If force option changed by user, save it
        Dim timeout As Integer = Restart_Options_Form.Num_TimeOut.Value
        If timeout = 0 Then
            force_last = checked
        End If
        ' Set shutdown args
        If checked = True Then
            force_arg = " /f "
        Else
            force_arg = ""
        End If

    End Sub

    Sub check_uefi()
        ' Get system data to describe boot applications and boot application settings.
        Dim processID = Shell("powershell -command ""BCDEdit /enum > " + temp_file + """", 0)
        Dim oProcess As Process = Process.GetProcessById(processID)
        oProcess.WaitForExit()

        Dim sOutput As String = ""
        ' If BCDEdit can't run, just return empty data and assume no UEFI
        Try
            sOutput = System.IO.File.ReadAllText(temp_file)
            ' Delete the temp file containing the output
            My.Computer.FileSystem.DeleteFile(temp_file)
        Catch ex As Exception
            ' Don't do anything if BCDEdit is not found
        End Try
        ' If UEFI then set True else set False
        If sOutput.Contains("\system32\winload.efi") Then
            is_uefi = True
            Restart_Options_Form.CheckBox_UEFI.Enabled = True
        Else
            is_uefi = False
            Restart_Options_Form.CheckBox_UEFI.Enabled = False
            uefi_not_arg = ""
        End If

    End Sub

    Sub check_uefi_flag()
        ' Run powershell script to get Firmware Flag
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("powershell", get_uefi_cmd)
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.UseShellExecute = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        'Dim processID = Shell("powershell " + get_uefi_cmd, 0)
        'Dim oProcess As Process = Process.GetProcessById(processID)
        oProcess.WaitForExit()
        ' If script exits with 0 then UEFI flag set
        If oProcess.ExitCode = 0 Then
            Restart_Options_Form.CheckBox_UEFI.Checked = True
        Else
            Restart_Options_Form.CheckBox_UEFI.Checked = False
        End If

    End Sub

    Sub shutdown_cmd(ByVal command As String)
        ' Run shutdown command with arguments
        Dim processID = Shell("powershell -command """ + command + " 2> " + temp_file + """", 0)
        Dim oProcess As Process = Process.GetProcessById(processID)
        oProcess.WaitForExit()

        Dim sOutput As String = ""
        ' If output has text there is an error
        Try
            ' Get first line of error, if no error, then catch gets triggered
            sOutput = System.IO.File.ReadAllLines(temp_file)(0)
        Catch ex As Exception
            ' This catch means that there was no error running shutdown command
        End Try
        ' Delete the temp file containing the output
        My.Computer.FileSystem.DeleteFile(temp_file)
        ' If output is empty than command is success
        If sOutput = "" Then
            restart_set = True
            Restart_Options_Form.Button_Exit.Text = button_exit_cancel_text
            Restart_Options_Form.ToolTip_Exit.SetToolTip(Restart_Options_Form.Button_Exit, tip_exit_cancel_text)
            Restart_Options_Form.Timer.Start()
        Else ' If output is NOT empty than there was an error with shutdown command
            uefi_changed(Restart_Options_Form.CheckBox_UEFI.Checked)
            Dim error_msg As String = ""
            ' If advanced boot not supported say RDP won't work
            If sOutput.Contains("The parameter is incorrect.(87)") Then
                'Restart_Options_Form.CheckBox_Advanced.Checked = False
                error_msg = "Advanced boot can't be used from an RDP session" + Environment.NewLine + Environment.NewLine
            End If
            ' Display error message
            error_msg += "Error: " + sOutput
            MessageBox.Show(error_msg, Restart_Options_Form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub abort_restart()
        Dim processID = Shell(abort_cmd + uefi_not_arg, 0)
        restart_set = False
    End Sub

    Sub restart_button()
        abort_restart()
        reset_timer()

        timeout = Restart_Options_Form.Num_TimeOut.Value
        Dim timeout_arg As String = " /t " + timeout.ToString()

        Dim comment As String = ""
        If uefi_arg <> "" And advanced_arg <> "" Then
            comment = "/c \""Restart to UEFI and advanced boot options menu\"""
        ElseIf uefi_arg <> "" Then
            comment = "/c \""Restart to UEFI\"""
        ElseIf advanced_arg <> "" Then
            comment = "/c \""Restart to advanced boot options menu\"""
        ElseIf force_arg <> "" Then
            comment = "/c \""Force restart\"""
        End If

        Dim command As String = "shutdown /r " + comment + force_arg + uefi_arg + advanced_arg + timeout_arg
        shutdown_cmd(command)
        'Restart_Options_Form.Button_Exit.Focus()
    End Sub

    Sub reset_timer()
        Restart_Options_Form.Timer.Stop()
        timer_count = 0
        Restart_Options_Form.ProgressBar.Value() = 0
        Restart_Options_Form.Label_TimeOut.TextAlign = ContentAlignment.MiddleLeft
        Restart_Options_Form.Label_TimeOut.Text = "Time-out"
    End Sub

    Sub exit_button()
        ' Cancel time-out
        reset_timer()
        ' If restart activated cancel it
        If restart_set Then
            abort_restart()
        Else
            ' Exit app if restart not active
            Restart_Options_Form.Close()
        End If
        ' Set exit button text
        uefi_changed(Restart_Options_Form.CheckBox_UEFI.Checked)
    End Sub

    Sub exit_app()
        abort_restart()
        ' If UEFI checked then set UEFI firmware flag
        If uefi_arg <> "" Then
            set_uefi()
        End If
    End Sub

    Sub set_uefi()
        ' Set UEFI flag to boot to firmware on next boot
        Dim processID = Shell(set_uefi_cmd, 0)
    End Sub

    Dim get_uefi_cmd As String = "-command ""
function Get-FirmwareSetup ([switch]$Restart)
{
$Code = @'
 using System;
 using System.Runtime.InteropServices;
 using System.Text;
   
 public class NativeAPI
 { 
		[DllImport(\""kernel32.dll\"", SetLastError = true)]
        public static extern UInt32 GetFirmwareEnvironmentVariableA(string lpName, string lpGuid, [Out] Byte[] lpBuffer, UInt32 nSize);
		
		 [DllImport(\""ntdll.dll\"", EntryPoint=\""RtlAdjustPrivilege\"")]
	    public static extern int RtlAdjustPrivilege(ulong Privilege, bool Enable, bool CurrentThread, ref bool Enabled);
 }
'@

    Add-Type -TypeDefinition $Code
	
	#Enable SeSystemEnvironmentPrivilege
    $WasEnabledBefore=$false
    $ReturnCode=[NativeAPI]::RtlAdjustPrivilege(22, $true, $false, [ref]$WasEnabledBefore)

    #Set the flag to boot to firmware
    $VariableName  = \""OsIndications\""
    $Namespace     = '{8BE4DF61-93CA-11D2-AA0D-00E098032B8C}'
    [byte[]]$Value = @(0,0,0,0,0,0,0,0)
    $Size          = $Value.Length

    $Temp=[NativeAPI]::GetFirmwareEnvironmentVariableA($VariableName,$Namespace,$Value,$Size)
	
	return $Value[0]

}

$Result=Get-FirmwareSetup
if ( $Result -eq 1 )
{
  exit 0
}
exit 1
"

    Dim set_uefi_cmd As String = "powershell -command ""
function Set-FirmwareSetup ([switch]$Restart)
{
$Code = @'
 using System;
 using System.Runtime.InteropServices;
 using System.Text;
   
 public class NativeAPI
 { 
        [DllImport(\""kernel32.dll\"", SetLastError = true)]
        public static extern UInt32 SetFirmwareEnvironmentVariableA(string lpName, string lpGuid, Byte[] lpBuffer, UInt32 nSize);

	    [DllImport(\""ntdll.dll\"", EntryPoint=\""RtlAdjustPrivilege\"")]
	    public static extern int RtlAdjustPrivilege(ulong Privilege, bool Enable, bool CurrentThread, ref bool Enabled);
 }
'@

    Add-Type -TypeDefinition $Code

    #Enable SeSystemEnvironmentPrivilege
    $WasEnabledBefore=$false
    $ReturnCode=[NativeAPI]::RtlAdjustPrivilege(22, $true, $false, [ref]$WasEnabledBefore)

    #Set the flag to boot to firmware
    $VariableName  = \""OsIndications\""
    $Namespace     = '{8BE4DF61-93CA-11D2-AA0D-00E098032B8C}'
    [byte[]]$Value = @(1,0,0,0,0,0,0,0)
    $Size          = $Value.Length

    $Result=[NativeAPI]::SetFirmwareEnvironmentVariableA($VariableName,$Namespace,$Value,$Size)
}
Set-FirmwareSetup
"

End Module
