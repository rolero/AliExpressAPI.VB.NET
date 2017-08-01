Imports System
Imports System.Net
Imports System.Reflection
Imports System.Text

Namespace AliExpress.Api.Parameters
	Public MustInherit Class ParametersCollection
		Public Overridable Function Build() As String
			Dim result As StringBuilder = New StringBuilder()
			Dim properties As PropertyInfo() = MyBase.[GetType]().GetProperties()
			Dim array As PropertyInfo() = properties
			For i As Integer = 0 To array.Length - 1
				Dim [property] As PropertyInfo = array(i)
				Dim value As Object = [property].GetValue(Me)
				Dim flag As Boolean = value Is Nothing OrElse String.IsNullOrEmpty(value.ToString())
				If Not flag Then
					Dim name As String = [property].Name.Substring(0, 1).ToLower() + [property].Name.Substring(1)
					Dim stringValue As String = String.Empty
					Dim flag2 As Boolean = [property].PropertyType Is GetType(DateTime) OrElse [property].PropertyType Is GetType(DateTime?)
					If flag2 Then
						stringValue = DateTime.Parse(value.ToString()).ToString("yyyy-mm-dd")
					Else
						stringValue = value.ToString()
					End If
					Dim flag3 As Boolean = result.Length = 0
					If flag3 Then
						result.AppendFormat("{0}={1}", name, WebUtility.UrlEncode(stringValue))
					Else
						result.AppendFormat("&{0}={1}", name, WebUtility.UrlEncode(stringValue))
					End If
				End If
			Next
			Return result.ToString()
		End Function
	End Class
End Namespace
