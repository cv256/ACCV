<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTracks
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLenFrom = New System.Windows.Forms.TextBox()
        Me.txtLenTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLikeTo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLikeFrom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbTotals = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.delayedDrawHTML = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(174, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1182, 705)
        Me.WebBrowser1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Length >"
        '
        'txtLenFrom
        '
        Me.txtLenFrom.Location = New System.Drawing.Point(55, 50)
        Me.txtLenFrom.Name = "txtLenFrom"
        Me.txtLenFrom.Size = New System.Drawing.Size(40, 20)
        Me.txtLenFrom.TabIndex = 2
        Me.txtLenFrom.Text = "0"
        Me.txtLenFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLenTo
        '
        Me.txtLenTo.Location = New System.Drawing.Point(112, 50)
        Me.txtLenTo.Name = "txtLenTo"
        Me.txtLenTo.Size = New System.Drawing.Size(43, 20)
        Me.txtLenTo.TabIndex = 4
        Me.txtLenTo.Text = "?"
        Me.txtLenTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "<"
        '
        'txtLikeTo
        '
        Me.txtLikeTo.Location = New System.Drawing.Point(112, 73)
        Me.txtLikeTo.Name = "txtLikeTo"
        Me.txtLikeTo.Size = New System.Drawing.Size(22, 20)
        Me.txtLikeTo.TabIndex = 8
        Me.txtLikeTo.Text = "10"
        Me.txtLikeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "<"
        '
        'txtLikeFrom
        '
        Me.txtLikeFrom.Location = New System.Drawing.Point(73, 73)
        Me.txtLikeFrom.Name = "txtLikeFrom"
        Me.txtLikeFrom.Size = New System.Drawing.Size(22, 20)
        Me.txtLikeFrom.TabIndex = 6
        Me.txtLikeFrom.Text = "0"
        Me.txtLikeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Like >"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(158, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "m"
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(55, 27)
        Me.txtText.MaxLength = 30
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(113, 20)
        Me.txtText.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Text:"
        '
        'lbTotals
        '
        Me.lbTotals.AutoSize = True
        Me.lbTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotals.Location = New System.Drawing.Point(54, 5)
        Me.lbTotals.Name = "lbTotals"
        Me.lbTotals.Size = New System.Drawing.Size(98, 13)
        Me.lbTotals.TabIndex = 36
        Me.lbTotals.Text = "( 999 / 999 tracks )"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Filters:"
        '
        'delayedDrawHTML
        '
        Me.delayedDrawHTML.Interval = 600
        '
        'FormTracks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1356, 705)
        Me.Controls.Add(Me.lbTotals)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtLikeTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLikeFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLenTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLenFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FormTracks"
        Me.Text = "AC CV Choose Track"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLenFrom As TextBox
    Friend WithEvents txtLenTo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLikeTo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLikeFrom As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtText As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents lbTotals As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents delayedDrawHTML As Timer
End Class
