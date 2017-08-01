Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Model
	Public Class ListSimilarProductsResult
		Public Class SilimarProductResult
			Public Property ProductId() As Long

			Public Property ProductTitle() As String

			Public Property ProductUrl() As String

			Public Property ImageUrl() As String

			Public Property SalePrice() As String

			Public Property LocalPrice() As String

			Public Property Volume() As Integer?

			Public Property ValidTime() As DateTime
		End Class

		Public Property TotalResults() As Integer

		Public Property Products() As List(Of ListSimilarProductsResult.SilimarProductResult)
	End Class
End Namespace
