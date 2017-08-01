Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Model
	Public Class GetCompletedOrdersResult
		Public Property TotalResults() As Integer

		Public Property Orders() As List(Of OrderResult)
	End Class
End Namespace
