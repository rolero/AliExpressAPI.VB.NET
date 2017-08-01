Imports System

Namespace AliExpress.Api.Parameters
	Public Class GetPromotionProductDetailParameters
		Inherits ParametersCollection

		Public Const DefaultFields As String = "productId,productTitle,productUrl,salePrice,originalPrice,imageUrl,evaluateScore"

		Public Property Fields() As String

		Public Property ProductId() As String

		Public Property LocalCurrency() As String

		Public Property Language() As String

		Public Sub New(Optional fields As String="productId,productTitle,productUrl,salePrice,originalPrice,imageUrl,evaluateScore")
			Me.Fields = fields
		End Sub
	End Class
End Namespace
