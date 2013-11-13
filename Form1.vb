' ISSUES:
'
' We assume when decoding the barcode string that the mailerid is 9 characters. 9 character mailerids are going to
' be the most common we work with - anybody can obtain a single 9-digit without requirements. In order to obtain
' a 6-digit mailerid, the organization must mail a minimum million verified pieces per year. It's probably useless
' to add in the ability to choose 6- or 9-digit, so it's left out for now.

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFontCode.Font = New Font("", 12, FontStyle.Regular)
    End Sub

    Private Sub btnGenerateCode_Click(sender As Object, e As EventArgs) Handles btnGenerateCode.Click

        ' test
        'Dim bars As String = "01 234 567094 987654321 01234 5678 91".IMBClassBars()
        'lblFontCode.Text = bars
        Dim barcodeid, serviceid, mailerid, serialno, zip As String

        ' for hard-coded values, remove the boxes and labels and set the values here
        barcodeid = txtBarcodeID.Text
        serviceid = txtServiceID.Text
        mailerid = txtMailerID.Text
        serialno = txtSerialNo.Text
        zip = txtZip.Text



        ' construct a space-separated string of the components of the identifier
        Dim imbString As String
        imbString = barcodeid + " " + serviceid + " " + mailerid + " " + serialno + " " + zip

        Dim imbFontString As String = imbString.IMBClassBars()
        lblFontCode.Text = imbFontString

        CopyStringToClipboard()

    End Sub

    Private Sub btnClipboard_Click(sender As Object, e As EventArgs) Handles btnClipboard.Click
        CopyStringToClipboard()
    End Sub

    Private Sub CopyStringToClipboard()
        Clipboard.SetText(lblFontCode.Text, TextDataFormat.Text)
        lblIMBCode.Text = lblFontCode.Text
        lblClipboardStatus.Text = "Copied to clipboard"
    End Sub

    Private Sub btnDecode_Click(sender As Object, e As EventArgs) Handles btnDecode.Click
        If Not (txtDecode.Text = "") Then
            Dim decodeString As String = txtDecode.Text.IMBClassDecode()
            Dim barcodeid, serviceid, mailerid, serialno, zip As String
            ' barcodeid     2 chars     0-1
            ' serviceid     3 chars     2-4
            ' mailerid      9 chars     5-13    (we're assuming that they mail less than a million pieces annually, so they'd have a 9 digit and not 6)
            ' serialno      6 chars     14-19
            ' zip           11 chars    20-30

            barcodeid = decodeString.Substring(0, 2)
            serviceid = decodeString.Substring(2, 3)
            mailerid = decodeString.Substring(5, 9)
            serialno = decodeString.Substring(14, 6)
            zip = decodeString.Substring(20) 'until the end

            txtBarcodeID.Text = barcodeid
            txtServiceID.Text = serviceid
            txtMailerID.Text = mailerid
            txtSerialNo.Text = serialno
            txtZip.Text = zip
        End If

    End Sub
End Class
