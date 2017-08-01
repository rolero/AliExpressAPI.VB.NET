Imports Microsoft.Extensions.DependencyInjection
Imports System

Namespace AliExpress.Api
    Public Module ServiceCollectionExtensions
        <System.Runtime.CompilerServices.ExtensionAttribute()>
        Public Function AddAliClient(services As IServiceCollection, provider As Action(Of AliSettingsProvider)) As IServiceCollection
            Dim defaults As AliSettingsProvider = New AliSettingsProvider()
            provider(defaults)
            services.AddSingleton(Function(client As IServiceProvider) New AliApiClient(defaults))
            Return services
        End Function
    End Module
End Namespace
