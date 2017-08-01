Imports System

Namespace AliExpress.Api.Exceptions
	Public Class AliApiException
		Inherits Exception

		Public Property Code() As Integer

		Public Sub New(code As Integer, message As String)
			MyBase.New(message)
			Me.Code = code
		End Sub
	End Class
End Namespace
