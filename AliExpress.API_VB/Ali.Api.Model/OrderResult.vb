Imports System

Namespace AliExpress.Api.Model
	Public Class OrderResult
		Public Property OrderTime() As DateTime

		Public Property TransactionTime() As DateTime

		Public Property OrderNumber() As Long

		Public Property Product() As String

		Public Property OrderStatus() As String

		Public Property CommisionRate() As String

		Public Property PaymentAmount() As String

		Public Property EstimatedCommission() As String

		Public Property FinalPaymentAmount() As String

		Public Property Commission() As String

		Public Property PID() As String

		Public Property ExtraParams() As String
	End Class
End Namespace
