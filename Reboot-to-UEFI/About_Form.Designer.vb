<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class About_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About_Form))
        Me.Label_AppTitle = New System.Windows.Forms.Label()
        Me.LinkLabel_Homepage = New System.Windows.Forms.LinkLabel()
        Me.Label_Developer = New System.Windows.Forms.Label()
        Me.Label_Homepage = New System.Windows.Forms.Label()
        Me.PictureBox_gustech = New System.Windows.Forms.PictureBox()
        Me.LinkLabel_Dev = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox_gustech, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_AppTitle
        '
        Me.Label_AppTitle.AutoSize = True
        Me.Label_AppTitle.Location = New System.Drawing.Point(82, 12)
        Me.Label_AppTitle.Name = "Label_AppTitle"
        Me.Label_AppTitle.Size = New System.Drawing.Size(80, 13)
        Me.Label_AppTitle.TabIndex = 1
        Me.Label_AppTitle.Text = "Restart Options"
        '
        'LinkLabel_Homepage
        '
        Me.LinkLabel_Homepage.AutoSize = True
        Me.LinkLabel_Homepage.Location = New System.Drawing.Point(143, 63)
        Me.LinkLabel_Homepage.Name = "LinkLabel_Homepage"
        Me.LinkLabel_Homepage.Size = New System.Drawing.Size(143, 13)
        Me.LinkLabel_Homepage.TabIndex = 2
        Me.LinkLabel_Homepage.TabStop = True
        Me.LinkLabel_Homepage.Text = "restart-options.sourceforge.io"
        '
        'Label_Developer
        '
        Me.Label_Developer.AutoSize = True
        Me.Label_Developer.Location = New System.Drawing.Point(82, 37)
        Me.Label_Developer.Name = "Label_Developer"
        Me.Label_Developer.Size = New System.Drawing.Size(90, 13)
        Me.Label_Developer.TabIndex = 3
        Me.Label_Developer.Text = "Copyright © 2024"
        '
        'Label_Homepage
        '
        Me.Label_Homepage.AutoSize = True
        Me.Label_Homepage.Location = New System.Drawing.Point(82, 63)
        Me.Label_Homepage.Name = "Label_Homepage"
        Me.Label_Homepage.Size = New System.Drawing.Size(62, 13)
        Me.Label_Homepage.TabIndex = 4
        Me.Label_Homepage.Text = "Homepage:"
        '
        'PictureBox_gustech
        '
        Me.PictureBox_gustech.BackgroundImage = Global.Restart_Options.My.Resources.Resources.gus_tech
        Me.PictureBox_gustech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_gustech.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox_gustech.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox_gustech.Name = "PictureBox_gustech"
        Me.PictureBox_gustech.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox_gustech.TabIndex = 0
        Me.PictureBox_gustech.TabStop = False
        '
        'LinkLabel_Dev
        '
        Me.LinkLabel_Dev.AutoSize = True
        Me.LinkLabel_Dev.Location = New System.Drawing.Point(173, 37)
        Me.LinkLabel_Dev.Name = "LinkLabel_Dev"
        Me.LinkLabel_Dev.Size = New System.Drawing.Size(48, 13)
        Me.LinkLabel_Dev.TabIndex = 5
        Me.LinkLabel_Dev.TabStop = True
        Me.LinkLabel_Dev.Text = "gus.tech"
        '
        'About_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 91)
        Me.Controls.Add(Me.LinkLabel_Dev)
        Me.Controls.Add(Me.Label_Homepage)
        Me.Controls.Add(Me.Label_Developer)
        Me.Controls.Add(Me.LinkLabel_Homepage)
        Me.Controls.Add(Me.Label_AppTitle)
        Me.Controls.Add(Me.PictureBox_gustech)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Restart Options"
        Me.TopMost = True
        CType(Me.PictureBox_gustech, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox_gustech As PictureBox
    Friend WithEvents Label_AppTitle As Label
    Friend WithEvents LinkLabel_Homepage As LinkLabel
    Friend WithEvents Label_Developer As Label
    Friend WithEvents Label_Homepage As Label
    Friend WithEvents LinkLabel_Dev As LinkLabel
End Class
