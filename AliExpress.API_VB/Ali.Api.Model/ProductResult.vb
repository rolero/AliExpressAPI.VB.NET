Imports Newtonsoft.Json
Imports System

Namespace AliExpress.Api.Model
	Public Class ProductResult
		Public Property ProductId() As Long

		Public Property ProductTitle() As String

		Public Property ProductUrl() As String

		Public Property ImageUrl() As String

		Public Property OriginalPrice() As String

		Public Property SalePrice() As String

		Public Property Discount() As String

		Public Property LocalPrice() As String

		Public Property EvaluateScore() As Single

		Public Property Commission() As String

		Public Property CommissionRate() As String

		<JsonProperty("30daysCommission")>
		Public Property DaysCommission30() As String

		Public Property Volume() As Integer?

		Public Property PackageType() As String

		Public Property LotNum() As Integer

		Public Property ValidTime() As DateTime

		Public Property AllImageUrls() As String
	End Class
End Namespace
