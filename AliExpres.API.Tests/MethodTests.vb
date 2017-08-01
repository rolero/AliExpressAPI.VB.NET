
Imports AliExpress.Api.Parameters
Imports Microsoft.Extensions.Configuration
Imports System.IO
Imports System.Threading.Tasks
Imports Xunit
Imports System.Linq
Imports System.Reflection
Imports AliExpress.Api

Namespace AliExpress.Api.Tests
    Public Class MethodsTests
        Private ReadOnly _client As IAliApiClient

        Public ReadOnly AppKey As String
        Public ReadOnly TrackingId As String
        Public ReadOnly AppSignature As String

        Public Sub New()
            'Dim config As IConfigurationRoot = Nothing

            '' Work around for https://github.com/xunit/xunit/issues/1093
            '' You can't debug your tests without 
            'Try
            '    config = New ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("settings.json").Build()
            'Catch generatedExceptionName As Exception
            '    Dim location = GetType(MethodsTests).GetTypeInfo().Assembly.Location
            '    Dim directory__1 = Path.GetDirectoryName(location)

            '    config = New ConfigurationBuilder().SetBasePath(directory__1).AddJsonFile("settings.json").Build()
            'End Try



            'If AppKey = "YOUR_APP_KEY" Then
            '    Throw New Exception("Please fill your app information in settings.json file")
            'End If

            AppKey = "Ali:AppKey" 'config("Ali:AppKey")
            TrackingId = "Ali:TrackingId" ' config("Ali:TrackingId")
            AppSignature = "Ali:AppSignature" 'config("Ali:AppSignature")

            _client = New AliApiClient(New AliSettingsProvider() With {
                .AppKey = AppKey
            })
        End Sub

        <Fact>
        Public Async Function ProductsListAsync() As Task
            Dim result = Await _client.ListPromotionProduct(New ListPromotionProductParameters() With {
                .Keywords = "Test"
            })

            Assert.[True](result.TotalResults > 0)

            Dim urlsList = result.Products.[Select](Function(p) p.ProductUrl)
            Dim urls = String.Join(",", urlsList)

            Dim promotionItems = Await _client.GetPromotionLinks(New GetPromotionLinksParameters() With {
                .TrackingId = TrackingId,
                .Urls = urls
            })

            Assert.[True](promotionItems.TotalResults > 0)

            Dim testId = result.Products.First().ProductId

            Dim item = Await _client.GetPromotionProductDetail(New GetPromotionProductDetailParameters() With {
                .ProductId = testId.ToString()
            })

            Assert.[True](item.ProductId = testId)
        End Function

        <Fact>
        Public Async Function OrdersListAsync() As Task
            Dim orders = Await _client.GetCompletedOrders(New GetCompletedOrdersParameters() With {
                .AppSignature = AppSignature,
                .StartDate = DateTime.Now.AddMonths(-1),
                .EndDate = DateTime.Now,
                .LiveOrderStatus = "pay",
                .PageNo = 1,
                .PageSize = 15
            })

            If orders.TotalResults > 0 Then
                Dim statusOrders = Await _client.GetOrderStatus(New GetOrderStatusParameters() With {
                    .AppSignature = AppSignature,
                    .OrderNumbers = String.Join(",", orders.Orders.[Select](Function(order) order.OrderNumber))
                })

                Assert.[True](statusOrders.TotalResults > 0)

                Dim items = Await _client.GetOrderStatus(New GetOrderStatusParameters() With {
                    .AppSignature = AppSignature,
                    .OrderNumbers = String.Join(",", orders.Orders.[Select](Function(order) order.OrderNumber))
                })

                Assert.[True](items.TotalResults > 0)
            End If

            ' Assert if no exceptions
            Assert.[True](True)
        End Function

        <Fact>
        Public Async Function HotProductsAsync() As Task

            Dim result = Await _client.ListHotProducts(New ListHotProductsParameters())

            ' Assert if no exceptions
            Assert.[True](result.TotalResults > 0)
        End Function

        <Fact>
        Public Async Function SimilarAndPromotionsProductsAsync() As Task
            Dim result = Await _client.ListPromotionProduct(New ListPromotionProductParameters() With {
                 .Keywords = "Test"
            })
            Assert.[True](result.TotalResults > 0)

            Dim testId = result.Products.First().ProductId

            Dim similar = Await _client.ListSimilarProducts(New ListSimilarProductsParameters() With {
                 .ProductId = testId.ToString()
            })
            Assert.[True](similar.TotalResults > 0)

            Dim appPromotions = Await _client.GetAppPromotionProduct(New GetAppPromotionProductParameters() With {
                .ProductId = testId.ToString()
            })
            ' Assert if no exceptions
            Assert.[True](True)
        End Function
    End Class
End Namespace
