Imports System

Namespace AliExpress.Api
    Public Class AliSettingsProvider
        Public Property DomainName() As String

        Public Property AppKey() As String

        Public Property Protocol() As String

        Public Property Version() As String

        Public Property [Namespace]() As String

        Public Sub New()
            Me.DomainName = "gw.api.alibaba.com"
            Me.Protocol = "param2"
            Me.Version = 2.ToString()
            Me.[Namespace] = "portals.open"
        End Sub

        Public Sub New(appKey As String)
            Me.New()
            Me.AppKey = appKey
        End Sub
    End Class
End Namespace
