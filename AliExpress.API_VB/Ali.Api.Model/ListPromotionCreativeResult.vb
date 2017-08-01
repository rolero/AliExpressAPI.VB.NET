Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Model
	Public Class ListPromotionCreativeResult
		Public Class PromotionCreativeResult
			Public Property ActivityUrl() As String

			Public Property ActivityTime() As DateTime

			Public Property ActivityTitle() As String

			Public Property Description() As String

			Public Property Height() As Integer

			Public Property Width() As Integer

			Public Property ImageUrl() As String
		End Class

		Public Property TotalResults() As Integer

		Public Property Products() As List(Of ListPromotionCreativeResult.PromotionCreativeResult)
	End Class
End Namespace
