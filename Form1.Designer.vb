<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.btnGenerateCode = New System.Windows.Forms.Button()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.lblFontCode = New System.Windows.Forms.TextBox()
        Me.btnClipboard = New System.Windows.Forms.Button()
        Me.lblBarcodeID = New System.Windows.Forms.Label()
        Me.txtBarcodeID = New System.Windows.Forms.TextBox()
        Me.lblServiceID = New System.Windows.Forms.Label()
        Me.txtServiceID = New System.Windows.Forms.TextBox()
        Me.lblMailerID = New System.Windows.Forms.Label()
        Me.txtMailerID = New System.Windows.Forms.TextBox()
        Me.lblSerialNo = New System.Windows.Forms.Label()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.lblZip2 = New System.Windows.Forms.Label()
        Me.lblIMBCode = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(174, 142)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(113, 20)
        Me.txtZip.TabIndex = 5
        '
        'btnGenerateCode
        '
        Me.btnGenerateCode.Location = New System.Drawing.Point(13, 185)
        Me.btnGenerateCode.Name = "btnGenerateCode"
        Me.btnGenerateCode.Size = New System.Drawing.Size(113, 23)
        Me.btnGenerateCode.TabIndex = 6
        Me.btnGenerateCode.Text = "Generate IMB Code"
        Me.btnGenerateCode.UseVisualStyleBackColor = True
        '
        'lblZip
        '
        Me.lblZip.AutoSize = True
        Me.lblZip.Location = New System.Drawing.Point(16, 144)
        Me.lblZip.Name = "lblZip"
        Me.lblZip.Size = New System.Drawing.Size(148, 13)
        Me.lblZip.TabIndex = 3
        Me.lblZip.Text = "Enter ZIP+4 (e.g. 444601234)"
        '
        'lblFontCode
        '
        Me.lblFontCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFontCode.Enabled = False
        Me.lblFontCode.Location = New System.Drawing.Point(16, 240)
        Me.lblFontCode.Name = "lblFontCode"
        Me.lblFontCode.Size = New System.Drawing.Size(477, 20)
        Me.lblFontCode.TabIndex = 8
        '
        'btnClipboard
        '
        Me.btnClipboard.Location = New System.Drawing.Point(16, 277)
        Me.btnClipboard.Name = "btnClipboard"
        Me.btnClipboard.Size = New System.Drawing.Size(110, 23)
        Me.btnClipboard.TabIndex = 7
        Me.btnClipboard.Text = "Copy to Clipboard"
        Me.btnClipboard.UseVisualStyleBackColor = True
        '
        'lblBarcodeID
        '
        Me.lblBarcodeID.AutoSize = True
        Me.lblBarcodeID.Location = New System.Drawing.Point(16, 13)
        Me.lblBarcodeID.Name = "lblBarcodeID"
        Me.lblBarcodeID.Size = New System.Drawing.Size(93, 13)
        Me.lblBarcodeID.TabIndex = 6
        Me.lblBarcodeID.Text = "Barcode ID (2 dig)"
        '
        'txtBarcodeID
        '
        Me.txtBarcodeID.Location = New System.Drawing.Point(174, 6)
        Me.txtBarcodeID.Name = "txtBarcodeID"
        Me.txtBarcodeID.Size = New System.Drawing.Size(113, 20)
        Me.txtBarcodeID.TabIndex = 1
        '
        'lblServiceID
        '
        Me.lblServiceID.AutoSize = True
        Me.lblServiceID.Location = New System.Drawing.Point(16, 45)
        Me.lblServiceID.Name = "lblServiceID"
        Me.lblServiceID.Size = New System.Drawing.Size(116, 13)
        Me.lblServiceID.TabIndex = 8
        Me.lblServiceID.Text = "Service Type ID (3 dig)"
        '
        'txtServiceID
        '
        Me.txtServiceID.Location = New System.Drawing.Point(174, 37)
        Me.txtServiceID.Name = "txtServiceID"
        Me.txtServiceID.Size = New System.Drawing.Size(113, 20)
        Me.txtServiceID.TabIndex = 2
        '
        'lblMailerID
        '
        Me.lblMailerID.AutoSize = True
        Me.lblMailerID.Location = New System.Drawing.Point(16, 77)
        Me.lblMailerID.Name = "lblMailerID"
        Me.lblMailerID.Size = New System.Drawing.Size(102, 13)
        Me.lblMailerID.TabIndex = 10
        Me.lblMailerID.Text = "Mailer ID (6 or 9 dig)"
        '
        'txtMailerID
        '
        Me.txtMailerID.Location = New System.Drawing.Point(174, 70)
        Me.txtMailerID.Name = "txtMailerID"
        Me.txtMailerID.Size = New System.Drawing.Size(113, 20)
        Me.txtMailerID.TabIndex = 3
        '
        'lblSerialNo
        '
        Me.lblSerialNo.AutoSize = True
        Me.lblSerialNo.Location = New System.Drawing.Point(16, 108)
        Me.lblSerialNo.Name = "lblSerialNo"
        Me.lblSerialNo.Size = New System.Drawing.Size(126, 13)
        Me.lblSerialNo.TabIndex = 12
        Me.lblSerialNo.Text = "Serial Number (9 or 6 dig)"
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Location = New System.Drawing.Point(174, 100)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(113, 20)
        Me.txtSerialNo.TabIndex = 4
        '
        'lblZip2
        '
        Me.lblZip2.AutoSize = True
        Me.lblZip2.Location = New System.Drawing.Point(80, 157)
        Me.lblZip2.Name = "lblZip2"
        Me.lblZip2.Size = New System.Drawing.Size(84, 13)
        Me.lblZip2.TabIndex = 14
        Me.lblZip2.Text = "(0,5,9, or 11 dig)"
        '
        'lblIMBCode
        '
        Me.lblIMBCode.AutoSize = True
        Me.lblIMBCode.Location = New System.Drawing.Point(133, 286)
        Me.lblIMBCode.Name = "lblIMBCode"
        Me.lblIMBCode.Size = New System.Drawing.Size(103, 13)
        Me.lblIMBCode.TabIndex = 15
        Me.lblIMBCode.Text = "(no code generated)"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 316)
        Me.Controls.Add(Me.lblIMBCode)
        Me.Controls.Add(Me.lblZip2)
        Me.Controls.Add(Me.txtSerialNo)
        Me.Controls.Add(Me.lblSerialNo)
        Me.Controls.Add(Me.txtMailerID)
        Me.Controls.Add(Me.lblMailerID)
        Me.Controls.Add(Me.txtServiceID)
        Me.Controls.Add(Me.lblServiceID)
        Me.Controls.Add(Me.txtBarcodeID)
        Me.Controls.Add(Me.lblBarcodeID)
        Me.Controls.Add(Me.btnClipboard)
        Me.Controls.Add(Me.lblFontCode)
        Me.Controls.Add(Me.lblZip)
        Me.Controls.Add(Me.btnGenerateCode)
        Me.Controls.Add(Me.txtZip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Generate USPS IMB Code"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerateCode As System.Windows.Forms.Button
    Friend WithEvents lblZip As System.Windows.Forms.Label
    Friend WithEvents lblFontCode As System.Windows.Forms.TextBox
    Friend WithEvents btnClipboard As System.Windows.Forms.Button
    Friend WithEvents lblBarcodeID As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeID As System.Windows.Forms.TextBox
    Friend WithEvents lblServiceID As System.Windows.Forms.Label
    Friend WithEvents txtServiceID As System.Windows.Forms.TextBox
    Friend WithEvents lblMailerID As System.Windows.Forms.Label
    Friend WithEvents txtMailerID As System.Windows.Forms.TextBox
    Friend WithEvents lblSerialNo As System.Windows.Forms.Label
    Friend WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents lblZip2 As System.Windows.Forms.Label
    Friend WithEvents lblIMBCode As System.Windows.Forms.Label

End Class
