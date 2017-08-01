Imports AliExpress.Api.Model
Imports AliExpress.Api.Parameters
Imports System
Imports System.Threading.Tasks

Namespace AliExpress.Api
    Public Interface IAliApiClient
        Function ListPromotionProduct(parameters As ListPromotionProductParameters) As Task(Of ListPromotionProductResult)

        Function GetPromotionLinks(parameters As GetPromotionLinksParameters) As Task(Of GetPromotionLinksResult)

        Function GetPromotionProductDetail(parameters As GetPromotionProductDetailParameters) As Task(Of ProductResult)

        Function ListPromotionCreative(parameters As ListPromotionCreativeParameters) As Task(Of ListPromotionCreativeResult)

        Function GetCompletedOrders(parameters As GetCompletedOrdersParameters) As Task(Of GetCompletedOrdersResult)

        Function GetOrderStatus(parameters As GetOrderStatusParameters) As Task(Of GetOrderStatusResult)

        Function GetItemByOrderNumbers(parameters As GetItemByOrderNumbersParameters) As Task(Of GetItemByOrderNumbersResult)

        Function ListHotProducts(parameters As ListHotProductsParameters) As Task(Of ListHotProductsResult)

        Function ListSimilarProducts(parameters As ListSimilarProductsParameters) As Task(Of ListSimilarProductsResult)

        Function GetAppPromotionProduct(parameters As GetAppPromotionProductParameters) As Task(Of GetAppPromotionProductResult)

        Function ApiCallAsync(Of T)(method As String, parameters As ParametersCollection) As Task(Of T)

        Function RawApiCall(Of T)(url As String) As Task(Of T)
    End Interface

End Namespace
