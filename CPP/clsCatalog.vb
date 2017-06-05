Public Class clsCatalog

    Private strCatalogID As String
    Private strYear As String
    Private strQuarter As String
    Private strCourseID As String
    Private strProfID As String

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

    Public Property year As String
        Get
            Return strYear
        End Get
        Set(value As String)
            If clsValidator.isValidYear(value) Then
                strYear = value
            End If
        End Set
    End Property

    Public Property quarter As String
        Get
            Return strQuarter
        End Get
        Set(value As String)
            If clsValidator.isValidQuarter(value) Then
                strQuarter = value
            End If
        End Set
    End Property

    Public Property courseID As String
        Get
            Return strCourseID
        End Get
        Set(value As String)
            If clsValidator.isValidCourseID(value) Then
                strCourseID = value
            End If

        End Set
    End Property

    Public Property profID As String
        Get
            Return strProfID
        End Get
        Set(value As String)
            If clsValidator.isValidProfID(value) Then
                strProfID = value
            End If
        End Set
    End Property

End Class
