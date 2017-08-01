Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Exceptions
	Public Class ErrorCodes
		Public Const SucceedCode As Integer = 20010000

		Public Shared Messages As Dictionary(Of Integer, String)

		Public Shared Function GetMessage(code As Integer) As String
			Dim flag As Boolean = ErrorCodes.Messages.ContainsKey(code)
			Dim result As String
			If flag Then
				result = ErrorCodes.Messages(code)
			Else
				result = "Unexpected error"
			End If
			Return result
		End Function

		Shared Sub New()
			ErrorCodes.Messages = New Dictionary(Of Integer, String)() From { { 20020000, "System Error" }, { 20030000, "Unauthorized transfer request" }, { 20030010, "Required parameters" }, { 20030020, "Invalid protocol format" }, { 20030030, "API version input parameter error" }, { 20030040, "API name space input parameter error" }, { 20030050, "API name input parameter error" }, { 20030060, "Fields input parameter error" }, { 20030070, "Keyword input parameter error" }, { 20030080, "Category ID input parameter error" }, { 20030090, "Tracking ID input parameter error" }, { 20030100, "Commission rate input parameter error" }, { 20030110, "Original Price input parameter error" }, { 20030120, "Discount input parameter error" }, { 20030130, "Volume input parameter error" }, { 20030140, "Page number input parameter error" }, { 20030150, "Page size input parameter error" }, { 20030160, "Sort input parameter error" }, { 20030170, "Credit Score input parameter error" } }
		End Sub
	End Class
End Namespace
