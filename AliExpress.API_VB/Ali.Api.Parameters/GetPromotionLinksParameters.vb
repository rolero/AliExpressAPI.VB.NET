Imports System

Namespace AliExpress.Api.Parameters
	Public Class GetPromotionLinksParameters
		Inherits ParametersCollection

		Public Const DefaultFields As String = "trackingId,publisherId,promotionUrl"

		Public Property Fields() As String

		Public Property TrackingId() As String

		Public Property Urls() As String

		Public Sub New(Optional fields As String="trackingId,publisherId,promotionUrl")
			Me.Fields = fields
		End Sub
	End Class
End Namespace
