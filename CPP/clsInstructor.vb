Public Class clsInstructor
    Private strProfId As String
    Private strFirstName As String
    Private strLastName As String
    Private strPhone As String
    Private strDepartment As String

    Public Property profID As String
        Get
            Return strProfId
        End Get
        Set(value As String)
            If clsValidator.isValidProfID(value) Then
                strProfId = value
            End If
        End Set
    End Property

    Public Property firstName As String
        Get
            Return strFirstName
        End Get
        Set(value As String)
            If clsValidator.isValidFirstName(value) Then
                strFirstName = value
            End If
        End Set
    End Property

    Public Property lastName As String
        Get
            Return strLastName
        End Get
        Set(value As String)
            If clsValidator.isValidLastName(value) Then
                strLastName = value
            End If
        End Set
    End Property

    Public Property phone As String
        Get
            Return strPhone
        End Get

        Set(value As String)
            If clsValidator.isValidPhone(value) Then
                strPhone = value
            End If
        End Set
    End Property

    Public Property department As String
        Get
            Return strDepartment
        End Get
        Set(value As String)
            If clsValidator.isValidDepartment(value) Then
                strDepartment = value
            End If
        End Set
    End Property

End Class
