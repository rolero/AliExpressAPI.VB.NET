Imports System

Namespace AliExpress.Api.Parameters
	Public Class GetCompletedOrdersParameters
		Inherits ParametersCollection

		Public Property AppSignature() As String

		Public Property StartDate() As DateTime?

		Public Property EndDate() As DateTime?

		Public Property LiveOrderStatus() As String

		Public Property PageNo() As Integer?

		Public Property PageSize() As Integer?
	End Class
End Namespace
