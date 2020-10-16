<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEdit
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLikes = New System.Windows.Forms.TrackBar()
        CType(Me.txtLikes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(125, 63)
        Me.txtNotes.MaxLength = 4000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(354, 87)
        Me.txtNotes.TabIndex = 1
        '
        'btSetup
        '
        Me.btSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSetup.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btSetup.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.btSetup.Location = New System.Drawing.Point(323, 166)
        Me.btSetup.Name = "btSetup"
        Me.btSetup.Size = New System.Drawing.Size(75, 23)
        Me.btSetup.TabIndex = 16
        Me.btSetup.Text = "Save"
        Me.btSetup.UseVisualStyleBackColor = False
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btClose.ForeColor = System.Drawing.Color.DarkRed
        Me.btClose.Location = New System.Drawing.Point(404, 166)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 15
        Me.btClose.Text = "Cancel"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Like:"
        '
        'txtLikes
        '
        Me.txtLikes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLikes.LargeChange = 1
        Me.txtLikes.Location = New System.Drawing.Point(117, 12)
        Me.txtLikes.Minimum = 1
        Me.txtLikes.Name = "txtLikes"
        Me.txtLikes.Size = New System.Drawing.Size(370, 45)
        Me.txtLikes.TabIndex = 18
        Me.txtLikes.Value = 1
        '
        'FormEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(491, 201)
        Me.Controls.Add(Me.txtLikes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FormEdit"
        Me.Text = "AC CV Edit"
        CType(Me.txtLikes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents btSetup As Button
    Friend WithEvents btClose As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLikes As TrackBar
End Class
