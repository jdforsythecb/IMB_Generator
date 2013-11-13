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

End Class
