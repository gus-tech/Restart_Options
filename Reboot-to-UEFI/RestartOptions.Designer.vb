<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Restart_Options_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Restart_Options_Form))
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.Button_Restart = New System.Windows.Forms.Button()
        Me.Label_TimeOut = New System.Windows.Forms.Label()
        Me.ToolTip_UEFI = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Advanced = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Force = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Timeout = New System.Windows.Forms.ToolTip(Me.components)
        Me.CheckBox_UEFI = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Advanced = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Force = New System.Windows.Forms.CheckBox()
        Me.ToolTip_Exit = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Restart = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button_About = New System.Windows.Forms.Button()
        Me.Num_TimeOut = New System.Windows.Forms.NumericUpDown()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip_About = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Num_TimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Exit
        '
        Me.Button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Exit.Location = New System.Drawing.Point(176, 12)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(98, 23)
        Me.Button_Exit.TabIndex = 14
        Me.Button_Exit.Text = "Exit"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'Button_Restart
        '
        Me.Button_Restart.Location = New System.Drawing.Point(176, 78)
        Me.Button_Restart.Name = "Button_Restart"
        Me.Button_Restart.Size = New System.Drawing.Size(98, 23)
        Me.Button_Restart.TabIndex = 10
        Me.Button_Restart.Text = "&Restart"
        Me.Button_Restart.UseVisualStyleBackColor = True
        '
        'Label_TimeOut
        '
        Me.Label_TimeOut.Location = New System.Drawing.Point(98, 83)
        Me.Label_TimeOut.Name = "Label_TimeOut"
        Me.Label_TimeOut.Size = New System.Drawing.Size(86, 13)
        Me.Label_TimeOut.TabIndex = 5
        Me.Label_TimeOut.Text = "Time-out"
        Me.Label_TimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox_UEFI
        '
        Me.CheckBox_UEFI.AutoSize = True
        Me.CheckBox_UEFI.Location = New System.Drawing.Point(12, 12)
        Me.CheckBox_UEFI.Name = "CheckBox_UEFI"
        Me.CheckBox_UEFI.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox_UEFI.TabIndex = 2
        Me.CheckBox_UEFI.Text = "&UEFI"
        Me.CheckBox_UEFI.UseVisualStyleBackColor = True
        '
        'CheckBox_Advanced
        '
        Me.CheckBox_Advanced.AutoSize = True
        Me.CheckBox_Advanced.Location = New System.Drawing.Point(12, 35)
        Me.CheckBox_Advanced.Name = "CheckBox_Advanced"
        Me.CheckBox_Advanced.Size = New System.Drawing.Size(100, 17)
        Me.CheckBox_Advanced.TabIndex = 4
        Me.CheckBox_Advanced.Text = "&Advanced Boot"
        Me.CheckBox_Advanced.UseVisualStyleBackColor = True
        '
        'CheckBox_Force
        '
        Me.CheckBox_Force.AutoSize = True
        Me.CheckBox_Force.Location = New System.Drawing.Point(12, 58)
        Me.CheckBox_Force.Name = "CheckBox_Force"
        Me.CheckBox_Force.Size = New System.Drawing.Size(53, 17)
        Me.CheckBox_Force.TabIndex = 6
        Me.CheckBox_Force.Text = "&Force"
        Me.CheckBox_Force.UseVisualStyleBackColor = True
        '
        'Button_About
        '
        Me.Button_About.Location = New System.Drawing.Point(176, 45)
        Me.Button_About.Name = "Button_About"
        Me.Button_About.Size = New System.Drawing.Size(98, 23)
        Me.Button_About.TabIndex = 12
        Me.Button_About.Text = "About"
        Me.Button_About.UseVisualStyleBackColor = True
        '
        'Num_TimeOut
        '
        Me.Num_TimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Num_TimeOut.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Num_TimeOut.Location = New System.Drawing.Point(13, 81)
        Me.Num_TimeOut.Maximum = New Decimal(New Integer() {315359999, 0, 0, 0})
        Me.Num_TimeOut.Name = "Num_TimeOut"
        Me.Num_TimeOut.Size = New System.Drawing.Size(80, 20)
        Me.Num_TimeOut.TabIndex = 8
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 111)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(262, 23)
        Me.ProgressBar.TabIndex = 15
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'Restart_Options_Form
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.Button_Exit
        Me.ClientSize = New System.Drawing.Size(286, 145)
        Me.Controls.Add(Me.Button_Restart)
        Me.Controls.Add(Me.Label_TimeOut)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Num_TimeOut)
        Me.Controls.Add(Me.Button_About)
        Me.Controls.Add(Me.CheckBox_Force)
        Me.Controls.Add(Me.CheckBox_Advanced)
        Me.Controls.Add(Me.CheckBox_UEFI)
        Me.Controls.Add(Me.Button_Exit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Restart_Options_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restart Options"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        CType(Me.Num_TimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Exit As Button
    Friend WithEvents Button_Restart As Button
    Friend WithEvents Label_TimeOut As Label
    Friend WithEvents ToolTip_UEFI As ToolTip
    Friend WithEvents ToolTip_Advanced As ToolTip
    Friend WithEvents ToolTip_Force As ToolTip
    Friend WithEvents ToolTip_Timeout As ToolTip
    Friend WithEvents CheckBox_UEFI As CheckBox
    Friend WithEvents CheckBox_Advanced As CheckBox
    Friend WithEvents CheckBox_Force As CheckBox
    Friend WithEvents ToolTip_Exit As ToolTip
    Friend WithEvents ToolTip_Restart As ToolTip
    Friend WithEvents Button_About As Button
    Friend WithEvents Num_TimeOut As NumericUpDown
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Timer As Timer
    Friend WithEvents ToolTip_About As ToolTip
End Class
