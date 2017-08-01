Imports System
Imports System.Collections.Generic

Namespace AliExpress.Api.Model
	Public Class GetPromotionLinksResult
		Public Class PromotionUrlResult
			Public Property Url() As String

			Public Property PromotionUrl() As String
		End Class

		Public Property TotalResults() As Integer

		Public Property TrackingId() As String

		Public Property PublisherId() As String

		Public Property Url() As String

		Public Property PromotionUrls() As List(Of GetPromotionLinksResult.PromotionUrlResult)

		Public Property LocalPrice() As String
	End Class
End Namespace
