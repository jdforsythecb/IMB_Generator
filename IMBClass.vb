'   Copyright 2007 Vassilis Petroulias [drdigit]
'
'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may not use this file except in compliance with the License.
'   You may obtain a copy of the License at
'
'       http://www.apache.org/licenses/LICENSE-2.0
'
'   Unless required by applicable law or agreed to in writing, software
'   distributed under the License is distributed on an "AS IS" BASIS,
'   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'   See the License for the specific language governing permissions and
'   limitations under the License.

Imports System.Runtime.CompilerServices

Public Module Test
    Public Sub Main()
        Dim bars = "00 700 905016001 174945 57325052828".IMBClassBars(), code = bars.IMBClassDecode()
        Debug.WriteLine(bars)
        Debug.WriteLine(code)
    End Sub
End Module

Public Module Ext
    ' this will allow you the following handy usage
    ' Dim bars As String = "01 234 567094 987654321 01234 5678 91".IMBClassBars()
    ' Dim info As String = "AADTFFDFTDADTAADAATFDTDDAAADDTDTTDAFADADDDTFFFDDTTTADFAAADFTDAADA".IMBClassDecode()


    <Extension()> Public Function IMBClassBars(ByVal source As String) As String
        Return IMBClass.Bars(source)
    End Function

    <Extension()> Public Function IMBClassDecode(ByVal source As String) As String
        Return IMBClass.Decode(source)
    End Function
End Module


Public NotInheritable Class IMBClass
    ' for more information and specs check
    ' http://ribbs.usps.gov/IMBClasssolution/USPS-B-3200D001.pdf
    Private Shared table2of13Size As Integer = 78
    Private Shared table5of13Size As Integer = 1287
    Private Shared entries2of13 As Long = table5of13Size
    Private Shared entries5of13 As Long = table2of13Size
    Private Shared table2of13 As Integer() = IMBClassInfo(1)
    Private Shared table5of13 As Integer() = IMBClassInfo(2)
    Private Shared table2of13ArrayPtr As Integer() = table2of13
    Private Shared table5of13ArrayPtr As Integer() = table5of13
    Private Shared codewordArray As Decimal()() = IMBClassInfo()
    Private Shared BarTopCharacterIndexArray As Integer() = New Integer() {4, 0, 2, 6, 3, 5, 1, 9, 8, 7, 1, 2, 0, 6, 4, 8, 2, 9, 5, 3, 0, 1, 3, 7, 4, 6, 8, 9, 2, 0, 5, 1, 9, 4, 3, 8, 6, 7, 1, 2, 4, 3, 9, 5, 7, 8, 3, 0, 2, 1, 4, 0, 9, 1, 7, 0, 2, 4, 6, 3, 7, 1, 9, 5, 8}
    Private Shared BarBottomCharacterIndexArray As Integer() = New Integer() {7, 1, 9, 5, 8, 0, 2, 4, 6, 3, 5, 8, 9, 7, 3, 0, 6, 1, 7, 4, 6, 8, 9, 2, 5, 1, 7, 5, 4, 3, 8, 7, 6, 0, 2, 5, 4, 9, 3, 0, 1, 6, 8, 2, 0, 4, 5, 9, 6, 7, 5, 2, 6, 3, 8, 5, 1, 9, 8, 7, 4, 0, 2, 6, 3}
    Private Shared BarTopCharacterShiftArray As Integer() = New Integer() {3, 0, 8, 11, 1, 12, 8, 11, 10, 6, 4, 12, 2, 7, 9, 6, 7, 9, 2, 8, 4, 0, 12, 7, 10, 9, 0, 7, 10, 5, 7, 9, 6, 8, 2, 12, 1, 4, 2, 0, 1, 5, 4, 6, 12, 1, 0, 9, 4, 7, 5, 10, 2, 6, 9, 11, 2, 12, 6, 7, 5, 11, 0, 3, 2}
    Private Shared BarBottomCharacterShiftArray As Integer() = New Integer() {2, 10, 12, 5, 9, 1, 5, 4, 3, 9, 11, 5, 10, 1, 6, 3, 4, 1, 10, 0, 2, 11, 8, 6, 1, 12, 3, 8, 6, 4, 4, 11, 0, 6, 1, 9, 11, 5, 3, 7, 3, 10, 7, 11, 8, 2, 10, 3, 5, 8, 0, 3, 12, 11, 8, 4, 5, 1, 3, 0, 7, 12, 9, 8, 10}

    Public Shared Function Bars(ByVal source As String) As String
        If String.IsNullOrEmpty(source) Then Return Nothing
        source = TrimOff(source, " -.")
        If Not System.Text.RegularExpressions.Regex.IsMatch(source, "^[0-9][0-4](([0-9]{18})|([0-9]{23})|([0-9]{27})|([0-9]{29}))$") Then
            Return String.Empty
        End If
        Dim encoded = String.Empty
        Dim l = 0L, zip As String = source.Substring(20)
        Select Case zip.Length
            Case 5 : l = Long.Parse(zip) + 1
            Case 9 : l = Long.Parse(zip) + 100001
            Case 11 : l = Long.Parse(zip) + 1000100001
        End Select
        Dim v As Decimal = l
        v = v * 10 + Int32.Parse(source.Substring(0, 1))
        v = v * 5 + Int32.Parse(source.Substring(1, 1))
        Dim ds = v.ToString & source.Substring(2, 18)
        Dim byteArray = New Integer(12) {}
        byteArray(12) = CType((l And 255), Integer)
        byteArray(11) = CType((l >> 8 And 255), Integer)
        byteArray(10) = CType((l >> 16 And 255), Integer)
        byteArray(9) = CType((l >> 24 And 255), Integer)
        byteArray(8) = CType((l >> 32 And 255), Integer)
        IMBClassMathMultiply(byteArray, 13, 10)
        IMBClassMathAdd(byteArray, 13, Integer.Parse(source.Substring(0, 1)))
        IMBClassMathMultiply(byteArray, 13, 5)
        IMBClassMathAdd(byteArray, 13, Integer.Parse(source.Substring(1, 1)))
        For i = 2 To 19
            IMBClassMathMultiply(byteArray, 13, 10)
            IMBClassMathAdd(byteArray, 13, Integer.Parse(source.Substring(i, 1)))
        Next
        Dim fcs = IMBClassMathFcs(byteArray)
        For i = 0 To 9
            codewordArray(i)(0) = entries2of13 + entries5of13
            codewordArray(i)(1) = 0
        Next
        codewordArray(0)(0) = 659 : codewordArray(9)(0) = 636
        IMBClassMathDivide(ds)
        codewordArray(9)(1) *= 2
        If fcs >> 10 <> 0 Then codewordArray(0)(1) += 659
        Dim ai = New Integer(64) {}, ai1 = New Integer(64) {}, ad = New Decimal(10)() {}
        For i = 0 To 9
            ad(i) = New Decimal(2) {}
        Next
        For i = 0 To 9
            If codewordArray(i)(1) >= CType((entries2of13 + entries5of13), Decimal) Then
                Return Nothing
            End If
            ad(i)(0) = 8192
            If codewordArray(i)(1) >= CType(entries2of13, Decimal) Then
                ad(i)(1) = table2of13(CType((codewordArray(i)(1) - entries2of13), Integer))
            Else
                ad(i)(1) = table5of13(CType(codewordArray(i)(1), Integer))
            End If
        Next
        For i = 0 To 9
            If (fcs And 1 << i) <> 0 Then ad(i)(1) = (Not CType(ad(i)(1), Integer)) And 8191
        Next
        For i = 0 To 64
            ai(i) = CType(ad(BarTopCharacterIndexArray(i))(1), Integer) >> BarTopCharacterShiftArray(i) And 1
            ai1(i) = CType(ad(BarBottomCharacterIndexArray(i))(1), Integer) >> BarBottomCharacterShiftArray(i) And 1
        Next
        encoded = ""
        ' T: track, D: descender, A: ascender, F: full bar
        For i As Integer = 0 To 64
            If ai(i) = 0 Then
                If ai1(i) = 0 Then
                    encoded &= "T"
                Else
                    encoded &= "D"
                End If
            ElseIf ai1(i) = 0 Then
                encoded &= "A"
            Else
                encoded &= "F"
            End If
        Next
        Return encoded
    End Function

    Public Shared Function Decode(ByVal source As String) As String
        If Not System.Text.RegularExpressions.Regex.IsMatch(source, "^[ADFT]{65}$") Then
            Return String.Empty
        End If
        Dim ad = New Integer(9) {}, byteArray = New Integer(12) {}
        Dim r = 0
        Dim bin As New System.Text.StringBuilder()
        Dim result = String.Empty
        For i = 0 To 64
            If source.Substring(i, 1) = "T" Then
                bin.Append("00")
            ElseIf source.Substring(i, 1) = "D" Then
                bin.Append("01")
            ElseIf source.Substring(i, 1) = "A" Then
                bin.Append("10")
            Else
                bin.Append("11")
            End If
        Next
        Dim bits = bin.ToString()
        For i = 0 To 128 Step 2
            Dim v = Convert.ToInt16(bits.Substring(i, 2), 2), k = i \ 2
            If (v > 1) Then ad(BarTopCharacterIndexArray(k)) += 1 << BarTopCharacterShiftArray(k)
            If (v Mod 2 = 1) Then ad(BarBottomCharacterIndexArray(k)) += 1 << BarBottomCharacterShiftArray(k)
        Next
        For i = 0 To 9
            Dim test = ad(i), index = Array.IndexOf(table5of13, test)
            If (index < 0) Then
                test = Not test And 8191
                index = Array.IndexOf(table5of13, test)
                If (index < 0) Then
                    index = Array.IndexOf(table2of13, test)
                    index += 1287
                End If
            End If
            ad(i) = index
        Next
        ad(9) = CType(ad(9) \ 2, Integer)
        If (ad(0) > 658) Then ad(0) -= 659
        IMBClassMathAdd(byteArray, 13, ad(0))
        For i = 1 To 8
            IMBClassMathMultiply(byteArray, 13, 1365)
            IMBClassMathAdd(byteArray, 13, ad(i))
        Next
        IMBClassMathMultiply(byteArray, 13, 636)
        IMBClassMathAdd(byteArray, 13, ad(9))
        r = IMBClassMathMod(byteArray, 10)
        result = r.ToString() & result
        For i = 2 To 19
            IMBClassMathAdd(byteArray, 13, -r)
            IMBClassMathDivide(byteArray, 10)
            r = IMBClassMathMod(byteArray, 10)
            result = r.ToString() & result
        Next
        IMBClassMathAdd(byteArray, 13, -r)
        IMBClassMathDivide(byteArray, 5)
        r = IMBClassMathMod(byteArray, 5)
        result = r.ToString() & result
        IMBClassMathAdd(byteArray, 13, -r)
        IMBClassMathDivide(byteArray, 10)
        Dim restBytes = New Byte(7) {}
        For i = 12 To 5 Step -1
            restBytes(12 - i) = CType(byteArray(i), Byte)
        Next
        Dim rest = BitConverter.ToInt64(restBytes, 0)
        If rest > 1000100001 Then
            result &= (rest - 1000100001).ToString().PadLeft(11, "0"c)
        ElseIf rest > 100001 Then
            result &= (rest - 100001).ToString().PadLeft(9, "0"c)
        ElseIf rest > 0 Then
            result &= (rest - 1).ToString().PadLeft(5, "0"c)
        End If
        Return result
    End Function

    Private Shared Function IMBClassInfo(ByVal topic As Integer) As Integer()
        Select Case topic
            Case 1
                Dim a = New Integer(table2of13Size + 1) {}
                IMBClassInitializeNof13Table(a, 2, table2of13Size)
                entries5of13 = table2of13Size
                Return a
            Case 2
                Dim a = New Integer(table5of13Size + 1) {}
                IMBClassInitializeNof13Table(a, 5, table5of13Size)
                entries2of13 = table5of13Size
                Return a
        End Select
        Return New Integer(1) {}
    End Function

    Private Shared Function IMBClassInfo() As Decimal()()
        Dim da = New Decimal(10)() {}
        Try
            For i = 0 To 9
                da(i) = New Decimal(2) {}
            Next
            Return da
        Finally
            Erase da
        End Try
    End Function

    Private Shared Function IMBClassInitializeNof13Table(ByRef ai As Integer(), ByVal i As Integer, ByVal j As Integer) As Boolean
        Dim i1 = 0, j1 = j - 1
        For k = 0 To 8191
            Dim k1 = 0
            For l1 = 0 To 12
                If (k And 1 << l1) <> 0 Then k1 += 1
            Next
            If k1 = i Then
                Dim l = IMBClassMathReverse(k) >> 3, flag = (k = l)
                If l >= k Then
                    If flag Then
                        ai(j1) = k : j1 -= 1
                    Else
                        ai(i1) = k : i1 += 1 : ai(i1) = l : i1 += 1
                    End If
                End If
            End If
        Next
        Return i1 = j1 + 1
    End Function

    Private Shared Function IMBClassMathAdd(ByRef bytearray As Integer(), ByVal i As Integer, ByVal j As Integer) As Boolean
        If j = 0 Then Return True
        If bytearray Is Nothing Then Return False
        If i < 1 Then Return False
        i -= 1
        bytearray(i) += j
        Dim carry = 0
        If j > 0 Then
            Do While i > 0 And bytearray(i) > 255
                carry = (bytearray(i) >> 8)
                bytearray(i) = bytearray(i) Mod 256
                i -= 1
                bytearray(i) += carry
            Loop
        Else
            Do While i > 0 And bytearray(i) < 0
                carry = 1
                bytearray(i) += 256
                i -= 1
                bytearray(i) -= carry
            Loop
        End If
        Return True
    End Function

    Private Shared Function IMBClassMathMod(ByVal byteArray As Integer(), ByVal d As Integer) As Integer
        Dim i = 0, r = 0, l = byteArray.Length
        While (i < 13)
            r <<= 8
            r = r Or byteArray(i)
            r = r Mod d
            i += 1
        End While
        Return r
    End Function

    Private Shared Sub IMBClassMathDivide(ByRef byteArray As Integer(), ByVal d As Integer)
        Dim i = 0, r = 0, l = byteArray.Length
        While (i < l)
            r <<= 8
            r = r Or byteArray(i)
            byteArray(i) = CType(r \ d, Integer)
            r = r Mod d
            i += 1
        End While
    End Sub

    Private Shared Function IMBClassMathDivide(ByVal v As String) As Boolean
        ' back to school - you may change it to use shitfing
        Dim j = 10, n = v
        For k = j - 1 To 1 Step -1
            Dim r = String.Empty, divider = CType(codewordArray(k)(0), Integer)
            Dim copy = n, left = "0", l = copy.Length
            For i = 1 To l
                Dim divident = Integer.Parse(copy.Substring(0, i))
                While divident < divider And i < l - 1
                    r = r & "0"
                    i += 1
                    divident = Integer.Parse(copy.Substring(0, i))
                End While
                r = r & (divident \ divider).ToString
                left = (divident Mod divider).ToString.PadLeft(i, "0"c)
                copy = left & copy.Substring(i)
            Next
            n = r.TrimStart("0"c)
            If n = "" Then n = "0"
            codewordArray(k)(1) = Integer.Parse(left)
            If k = 1 Then codewordArray(0)(1) = Integer.Parse(r)
        Next
    End Function

    Private Shared Function IMBClassMathFcs(ByVal bytearray() As Integer) As Integer
        Dim c = 3893, i = 2047, j = bytearray(0) << 5
        For bb = 2 To 7
            If ((i Xor j) And 1024) <> 0 Then i = (i << 1) Xor c Else i = i << 1
            i = i And 2047 : j = j << 1
        Next
        For l = 1 To 12
            Dim k = bytearray(l) << 3
            For bb = 0 To 7
                If ((i Xor k) And 1024) <> 0 Then i = (i << 1) Xor c Else i = i << 1
                i = i And 2047 : k = k << 1
            Next
        Next
        Return i
    End Function

    Private Shared Function IMBClassMathMultiply(ByRef bytearray As Integer(), ByVal i As Integer, ByVal j As Integer) As Boolean
        If bytearray Is Nothing Then Return False
        If i < 1 Then Return False
        Dim l = 0, k = 0
        For k = i - 1 To 1 Step -2
            Dim x = (bytearray(k) Or (bytearray(k - 1) << 8)) * j + l
            bytearray(k) = x And 255
            bytearray(k - 1) = x >> 8 And 255
            l = x >> 16
        Next
        If k = 0 Then
            bytearray(0) = (bytearray(0) * j + l) And 255
        End If
        Return True
    End Function

    Private Shared Function IMBClassMathReverse(ByVal i As Integer) As Integer
        Dim j = 0
        For k = 0 To 15
            j <<= 1 : j = j Or i And 1 : i >>= 1
        Next
        Return j
    End Function

    Private Shared Function TrimOff(ByVal source As String, ByVal bad As String) As String
        Dim l = bad.Length - 1
        For i = 0 To l
            source = source.Replace(bad.Chars(i), String.Empty)
        Next
        Return source
    End Function

End Class
