Dim request As HttpWebRequest = DirectCast(WebRequest.Create("https://huggingface.co"), HttpWebRequest)
Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
Dim responseStream As Stream = response.GetResponseStream()
Dim reader As New StreamReader(responseStream)
Dim sourceCode As String = reader.ReadToEnd()
reader.Close()
responseStream.Close()
response.Close()
Dim htmlDoc As HtmlDocument = New HtmlDocument()
htmlDoc.LoadHtml(sourceCode)
Dim nodes As HtmlNodeCollection = htmlDoc.DocumentNode.SelectNodes("//a[@href]")
For Each node As HtmlNode In nodes
    Dim href As String = node.Attributes("href").Value
    ' deal href link
Next