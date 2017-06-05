Public Class clsEnrollment

    Private strBroncoID As String
    Private strCatalogID As String

    Public Property broncoID As String
        Get
            Return strBroncoID
        End Get
        Set(value As String)
            If clsValidator.isValidBroncoID(value) Then
                strBroncoID = value
            End If
        End Set
    End Property

    Public Property catalogID As String
        Get
            Return strCatalogID
        End Get
        Set(value As String)
            If clsValidator.isValidCatalogID(value) Then
                strCatalogID = value
            End If
        End Set
    End Property

End Class
