Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.IO

Public Class Form1
    
    Private Function GetMd5Hash(ByVal input As String) As String
        Dim md5Hash As MD5 = MD5.Create()
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text

        Dim password As String = TextBox2.Text



        Dim hashedPassword As String = GetMd5Hash(password)

        Dim postData As String = "username=" & username & "&password=" & password
        Dim request As WebRequest = WebRequest.Create("https://haxcore.net/login7/Reg.php")
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        Dim postDataBytes As Byte() = Encoding.UTF8.GetBytes(postData)
        Console.WriteLine(postData)
        request.ContentLength = postDataBytes.Length
        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(postDataBytes, 0, postDataBytes.Length)
        End Using

        Dim response As WebResponse = request.GetResponse()
        Dim responseStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(responseStream)
        Dim responseText As String = reader.ReadToEnd()

        MessageBox.Show(responseText)

        reader.Close()
        responseStream.Close()
        response.Close()

    End Sub
End Class
