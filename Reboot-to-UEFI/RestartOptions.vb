Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Restart_Options_Form
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Allow form to handle key presses
        Me.KeyPreview = True
        ' Set form text
        Me.Text = Application.ProductName
        ' Set the maximum time-out value and increment value
        Num_TimeOut.Maximum = max_timeout
        Num_TimeOut.Increment = timeout_increment
        ' Check if the user supplied command is a valid time-out value
        Try
            Dim timeout As UInteger = Math.Abs(Int(Command()))
            If timeout > max_timeout Then
                timeout = max_timeout
            End If
            Num_TimeOut.Value = timeout
        Catch ex As Exception
            ' Don't do anything if the command value is not a number
        End Try
        ' Set tool tip text
        ToolTip_UEFI.SetToolTip(CheckBox_UEFI, tip_uefi_text)
        ToolTip_Advanced.SetToolTip(CheckBox_Advanced, tip_advanced_text)
        ToolTip_Force.SetToolTip(CheckBox_Force, tip_force_text)
        ToolTip_Timeout.SetToolTip(Num_TimeOut, tip_timeout_text)
        ToolTip_Exit.SetToolTip(Button_Exit, tip_exit_text)
        ToolTip_About.SetToolTip(Button_About, tip_about_text)
        ToolTip_Restart.SetToolTip(Button_Restart, tip_restart_text)
        ' Check if the system is using UEFI bios
        check_uefi()
        ' If the system is using UEFI check if the firmware flag is set
        If is_uefi Then
            check_uefi_flag()
        End If
        ' Abort any previous system shutdown operations
        abort_restart()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        ' Update progress bar and time-out label on each timer tick
        timer_count += 1
        bar_value = ((timer_count + 1) / timeout) * 100
        If bar_value <= 100 Then ProgressBar.Value() = bar_value
        Label_TimeOut.TextAlign = ContentAlignment.MiddleCenter
        Label_TimeOut.Text = timeout - timer_count
    End Sub

    Private Sub Button_Restart_Click(sender As Object, e As EventArgs) Handles Button_Restart.Click
        restart_button()
        Label_TimeOut.Focus()
        'Me.Focus()
    End Sub

    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        exit_button()
    End Sub

    Private Sub Closing_Form(sender As Object, e As EventArgs) Handles Me.FormClosing
        exit_app()
    End Sub

    Private Sub Num_TimeOut_ValueChanged(sender As Object, e As EventArgs) Handles Num_TimeOut.ValueChanged
        ' Disable force checkbox if time-out is greater than 0 (force parameter is implied)
        If Num_TimeOut.Value > 0 Then
            CheckBox_Force.Checked = True
            CheckBox_Force.Enabled = False
        Else
            CheckBox_Force.Enabled = True
            CheckBox_Force.Checked = force_last
        End If
    End Sub

    Private Sub Num_TimeOut_LostFocus(sender As Object, e As EventArgs) Handles Num_TimeOut.LostFocus
        Dim value = Num_TimeOut.Value
        Num_TimeOut.Value = 0
        Num_TimeOut.Value = max_timeout
        Num_TimeOut.Value = value
    End Sub

    Private Sub CheckBox_UEFI_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_UEFI.CheckedChanged
        uefi_changed(CheckBox_UEFI.Checked)
    End Sub

    Private Sub CheckBox_Advanced_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Advanced.CheckedChanged
        advanced_changed(CheckBox_Advanced.Checked)
    End Sub

    Private Sub CheckBox_Force_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Force.CheckedChanged
        force_changed(CheckBox_Force.Checked)
    End Sub

    Private Sub Button_About_Click(sender As Object, e As EventArgs) Handles Button_About.Click
        About_Form.Show()
    End Sub

    Private Sub Restart_Form_KeyPress(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Dim timeout_value = Num_TimeOut.Value
        'MessageBox.Show(e.KeyCode)
        'e.SuppressKeyPress = True

        ' F1 shows about form
        If e.KeyCode = Keys.F1 Then
            About_Form.Show()
        End If

        If Num_TimeOut.Focused = True Then
            ' Toggle UEFI checkbox if UEFI enabled
            If e.KeyCode = Keys.U And CheckBox_UEFI.Enabled Then
                CheckBox_UEFI.Checked = Not CheckBox_UEFI.Checked
            End If
            ' Toggle Advanced Boot checkbox
            If e.KeyCode = Keys.A Then
                CheckBox_Advanced.Checked = Not CheckBox_Advanced.Checked
            End If
            ' Toggle Force checkbox if force enabled
            If e.KeyCode = Keys.F And CheckBox_Force.Enabled Then
                CheckBox_Force.Checked = Not CheckBox_Force.Checked
            End If
            ' Restart if time-out field focused
            If e.KeyCode = Keys.R Then
                restart_button()
            End If
        ElseIf Num_TimeOut.Focused = False Then
            ' Restart if time-out field NOT focused
            'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            'restart_button()
            'End If
            ' T focuses time-out field
            If e.KeyCode = Keys.T Then
                Num_TimeOut.Focus()
            End If
            ' Increment and focus time-out 
            If e.KeyCode = Keys.Up Then
                timeout_value += timeout_increment
                If timeout_value > max_timeout Then
                    timeout_value = max_timeout
                End If
                Num_TimeOut.Value = timeout_value
                Num_TimeOut.Focus()
            End If
            ' Decrement and focus time-out 
            If e.KeyCode = Keys.Down Then
                timeout_value -= timeout_increment
                If timeout_value < 0 Then
                    timeout_value = 0
                End If
                Num_TimeOut.Value = timeout_value
                Num_TimeOut.Focus()
            End If
        End If
    End Sub

End Class
