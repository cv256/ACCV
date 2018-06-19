<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOpponent
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
        Me.lbCarName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLevel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbUp = New System.Windows.Forms.Label()
        Me.lbDown = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbCarName
        '
        Me.lbCarName.AutoSize = True
        Me.lbCarName.BackColor = System.Drawing.Color.Black
        Me.lbCarName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCarName.Location = New System.Drawing.Point(3, 0)
        Me.lbCarName.Name = "lbCarName"
        Me.lbCarName.Size = New System.Drawing.Size(62, 13)
        Me.lbCarName.TabIndex = 9
        Me.lbCarName.Text = "Car Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(331, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "%"
        '
        'txtLevel
        '
        Me.txtLevel.Location = New System.Drawing.Point(300, -3)
        Me.txtLevel.MaxLength = 2
        Me.txtLevel.Name = "txtLevel"
        Me.txtLevel.Size = New System.Drawing.Size(27, 20)
        Me.txtLevel.TabIndex = 13
        Me.txtLevel.Text = "80"
        Me.txtLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(260, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Level:"
        '
        'lbUp
        '
        Me.lbUp.Location = New System.Drawing.Point(220, 0)
        Me.lbUp.Name = "lbUp"
        Me.lbUp.Size = New System.Drawing.Size(23, 13)
        Me.lbUp.TabIndex = 16
        Me.lbUp.Text = "Up"
        '
        'lbDown
        '
        Me.lbDown.Location = New System.Drawing.Point(240, 0)
        Me.lbDown.Name = "lbDown"
        Me.lbDown.Size = New System.Drawing.Size(23, 13)
        Me.lbDown.TabIndex = 17
        Me.lbDown.Text = "Dn"
        '
        'ucOpponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(Me.lbDown)
        Me.Controls.Add(Me.lbUp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLevel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbCarName)
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ucOpponent"
        Me.Size = New System.Drawing.Size(343, 212)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbCarName As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLevel As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lbUp As Label
    Friend WithEvents lbDown As Label
End Class
