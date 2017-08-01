Imports System

Namespace AliExpress.Api.Model
	Public Class ShortProductResult
		Public Property ProductId() As Long

		Public Property ProductTitle() As String

		Public Property ProductUrl() As String

		Public Property ImageUrl() As String

		Public Property SalePrice() As String

		Public Property LocalPrice() As String

		Public Property Volume() As Integer?

		Public Property ValidTime() As DateTime
	End Class
End Namespace
