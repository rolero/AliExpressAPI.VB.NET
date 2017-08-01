Imports AliExpress.Api.Exceptions
Imports AliExpress.Api.Model
Imports AliExpress.Api.Parameters
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Serialization
Imports System.Net.Http
Imports System.Threading.Tasks

Namespace AliExpress.Api

    Public Class AliApiClient
        Implements IAliApiClient
        Private ReadOnly _settings As AliSettingsProvider

        Public Sub New(settingsProvider As AliSettingsProvider)
            _settings = settingsProvider
        End Sub

        Protected Function CreateClient() As HttpClient
            Dim client As HttpClient = New HttpClient()
            Return client
        End Function

        Protected Function BuildUrl(method As String, parameters As ParametersCollection) As String
            Return String.Format("https://{0}/openapi/{1}/{2}/portals.open/{3}/{4}?{5}", _settings.DomainName, _settings.Protocol, _settings.Version, method, _settings.AppKey,
                parameters.Build())
        End Function

        Public Async Function ListPromotionProduct(parameters As ListPromotionProductParameters) As Task(Of ListPromotionProductResult) Implements IAliApiClient.ListPromotionProduct
            Return Await ApiCallAsync(Of ListPromotionProductResult)(AliApiMethods.ListPromotionProduct, parameters)
        End Function

        Public Async Function GetPromotionLinks(parameters As GetPromotionLinksParameters) As Task(Of GetPromotionLinksResult) Implements IAliApiClient.GetPromotionLinks
            Return Await ApiCallAsync(Of GetPromotionLinksResult)(AliApiMethods.GetPromotionLinks, parameters)
        End Function

        Public Async Function GetPromotionProductDetail(parameters As GetPromotionProductDetailParameters) As Task(Of ProductResult) Implements IAliApiClient.GetPromotionProductDetail
            Return Await ApiCallAsync(Of ProductResult)(AliApiMethods.GetPromotionProductDetail, parameters)
        End Function

        Public Async Function ListPromotionCreative(parameters As ListPromotionCreativeParameters) As Task(Of ListPromotionCreativeResult) Implements IAliApiClient.ListPromotionCreative
            Return Await ApiCallAsync(Of ListPromotionCreativeResult)(AliApiMethods.ListPromotionCreative, parameters)
        End Function

        Public Async Function GetCompletedOrders(parameters As GetCompletedOrdersParameters) As Task(Of GetCompletedOrdersResult) Implements IAliApiClient.GetCompletedOrders
            Return Await ApiCallAsync(Of GetCompletedOrdersResult)(AliApiMethods.GetCompletedOrders, parameters)
        End Function

        Public Async Function GetOrderStatus(parameters As GetOrderStatusParameters) As Task(Of GetOrderStatusResult) Implements IAliApiClient.GetOrderStatus
            Return Await ApiCallAsync(Of GetOrderStatusResult)(AliApiMethods.GetOrderStatus, parameters)
        End Function

        Public Async Function GetItemByOrderNumbers(parameters As GetItemByOrderNumbersParameters) As Task(Of GetItemByOrderNumbersResult) Implements IAliApiClient.GetItemByOrderNumbers
            Return Await ApiCallAsync(Of GetItemByOrderNumbersResult)(AliApiMethods.GetItemByOrderNumbers, parameters)
        End Function

        Public Async Function ListHotProducts(parameters As ListHotProductsParameters) As Task(Of ListHotProductsResult) Implements IAliApiClient.ListHotProducts
            Return Await ApiCallAsync(Of ListHotProductsResult)(AliApiMethods.ListHotProducts, parameters)
        End Function

        Public Async Function ListSimilarProducts(parameters As ListSimilarProductsParameters) As Task(Of ListSimilarProductsResult) Implements IAliApiClient.ListSimilarProducts
            Return Await ApiCallAsync(Of ListSimilarProductsResult)(AliApiMethods.ListSimilarProducts, parameters)
        End Function

        Public Async Function GetAppPromotionProduct(parameters As GetAppPromotionProductParameters) As Task(Of GetAppPromotionProductResult) Implements IAliApiClient.GetAppPromotionProduct
            Return Await ApiCallAsync(Of GetAppPromotionProductResult)(AliApiMethods.GetAppPromotionProduct, parameters)
        End Function

        Public Async Function ApiCallAsync(Of T)(method As String, parameters As ParametersCollection) As Task(Of T) Implements IAliApiClient.ApiCallAsync
            Dim url As String = BuildUrl(method, parameters)
            Return Await IAliApiClient_RawApiCallAsync(Of T)(url)
        End Function

        Private Async Function IAliApiClient_RawApiCallAsync(Of T)(url As String) As Task(Of T) Implements IAliApiClient.RawApiCall
            Using client As HttpClient = CreateClient()
                Dim response As String = Await client.GetStringAsync(url)
                Dim parsed As JObject = JObject.Parse(response)

                Dim callCode As Integer = parsed("errorCode").Value(Of Integer)()

                If callCode <> ErrorCodes.SucceedCode Then
                    Dim message As String = ErrorCodes.GetMessage(callCode)
                    Throw New AliApiException(callCode, message)
                End If

                '
                '                         * Because Aliexpress Api logic is very weird - 
                '                         * it could return "-" for totalResults field, 
                '                         * Which is Integer by documentation and common sense
                '                        

                Return JsonConvert.DeserializeObject(Of T)(parsed("result").ToString(),
                    New JsonSerializerSettings With {.Error = AddressOf HandleDeserializationError
                })

            End Using
        End Function


        Protected Sub HandleDeserializationError(sender As Object, errorArgs As ErrorEventArgs)
            Dim currentError As String = errorArgs.ErrorContext.[Error].Message
            errorArgs.ErrorContext.Handled = True
        End Sub
    End Class
End Namespace
