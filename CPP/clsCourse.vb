Public Class clsCourse
    Private strCourseId As String
    Private strDescription As String
    Private strUnits As String



    Public Property courseID As String
        Get
            Return strCourseId
        End Get
        Set(value As String)
            If clsValidator.isValidCourseID(value) Then
                strCourseId = value
            End If

        End Set
    End Property

    Public Property description As String
        Get
            Return strDescription

        End Get
        Set(value As String)
            If clsValidator.isValidDescription(value) Then
                strDescription = value
            End If

        End Set
    End Property

    Public Property units As String
        Get
            Return strUnits
        End Get
        Set(value As String)
            If clsValidator.isValidUnits(value) then
                strUnits = value
            End If
        End Set
    End Property


End Class