Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Model
	Public Class ListPromotionProductResult
		Public Property TotalResults() As Integer

		Public Property Products() As List(Of ProductResult)
	End Class
End Namespace
