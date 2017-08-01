Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Model
	Public Class GetItemByOrderNumbersResult
		Public Property TotalResults() As Integer

		Public Property Products() As List(Of ShortProductResult)
	End Class
End Namespace
