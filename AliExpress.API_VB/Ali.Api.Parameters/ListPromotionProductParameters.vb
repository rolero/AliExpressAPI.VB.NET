Imports System

Namespace AliExpress.Api.Parameters
	Public Class ListPromotionProductParameters
		Inherits ParametersCollection

		Public Const DefaultFields As String = "productId,productTitle,productUrl,salePrice,originalPrice,imageUrl,evaluateScore"

		Public Property Fields() As String

		Public Property Keywords() As String

		Public Property CategoryId() As String

		Public Property OriginalPriceFrom() As Double?

		Public Property OriginalPriceTo() As Double?

		Public Property VolumeFrom() As Integer?

		Public Property VolumeTo() As Integer?

		Public Property PageNo() As Integer?

		Public Property PageSize() As Integer?

		Public Property Sort() As String

		Public Property StartCreditScore() As Integer?

		Public Property EndCreditScore() As Integer?

		Public Property HighQualityItems() As String

		Public Property LocalCurrency() As String

		Public Property Language() As String

		Public Sub New(Optional fields As String="productId,productTitle,productUrl,salePrice,originalPrice,imageUrl,evaluateScore")
			Me.Fields = fields
		End Sub
	End Class
End Namespace
