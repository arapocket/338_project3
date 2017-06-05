Imports System.Text.RegularExpressions

Public Class clsValidator
    Shared sError As String

    Public Shared Function isValidFirstName(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                setError("You must enter a first name.")
                bResult = False
            End If
        Catch ex As Exception
            setError("First Name: Invalid First Name (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidLastName(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                setError("You must enter a last name.")
                bResult = False
            End If
        Catch ex As Exception
            setError("Last Name: Invalid Last Name (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidBroncoID(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                setError("You must enter a Bronco ID.")
                bResult = False
            End If
        Catch ex As Exception
            setError("BroncoID: Cannot be blank (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidCourseID(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                setError("You must enter a Course ID")
                bResult = False
            End If
        Catch ex As Exception
            setError("CourseID: Invalid Course ID (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidCatalogID(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                setError("You must enter a Catalog ID")
                bResult = False
            End If

            If IsNumeric(s) Then
                bResult = True

            ElseIf Not IsNumeric(s) Then
                setError("Catalog ID must be a valid number")
                bResult = False
            End If

        Catch ex As Exception
            setError("CatalogID: Invalid Catalog ID (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidProfID(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                setError("You must enter a Professor ID")
                bResult = False
            End If
        Catch ex As Exception
            setError("ProfID: Invalid ProfID (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidDepartment(ByVal sDepartment As String) As Boolean
        Dim bResult As Boolean
        Try
            If sDepartment <> "" Then
                bResult = True
            Else
                setError("You must enter a department.")
                bResult = False
            End If
        Catch ex As Exception
            setError("Department: Invalid department (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidUnits(ByVal sUnits As String) As Boolean
        Dim bResult As Boolean
        Try
            If sUnits <> "" Then
                bResult = True
            Else
                setError("You must enter how many units a course is.")
                bResult = False
            End If

            If IsNumeric(sUnits) Then

                bResult = True

            ElseIf Not IsNumeric(sUnits) Then
                setError(sUnits & " is not a valid number")

                bResult = False

            End If
        Catch ex As Exception
            setError("Units: Invalid units (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidYear(ByVal sYear As String) As Boolean
        Dim bResult As Boolean
        Try
            If sYear <> "" Then
                bResult = True
            Else
                setError("You must enter a year.")
                bResult = False
            End If

            If IsNumeric(sYear) Then

                bResult = True
            ElseIf Not IsNumeric(sYear) Then
                setError(sYear & " is not a valid year")
                bResult = False

            End If
        Catch ex As Exception
            setError("Year: Invalid year (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidEmail(ByVal sEmail As String) As Boolean
        Dim bResult As Boolean
        Dim sRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim emailAddressMatch As Match = Regex.Match(sEmail, sRegex)

        Try
            If emailAddressMatch.Success Then
                bResult = True
            Else

                setError(sEmail & " is not a valid Email")
                bResult = False

            End If

        Catch ex As Exception
            setError("Emai: Invalid Email (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidPhone(ByVal strPhone As String) As Boolean
        Dim bResult As Boolean
        Dim phoneNumber As New Regex("^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$")
        Try
            If strPhone <> "" Then
                bResult = True
            Else
                setError("Phone number cannot be left blank")
                bResult = False
            End If


            If phoneNumber.IsMatch(strPhone) Then
                bResult = True
            Else
                setError(strPhone & " is not valid phone number")

                bResult = False

            End If

        Catch ex As Exception
            setError("Phone number: Invalid Phone" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidDescription(ByVal sDescription As String) As Boolean
        Dim bResult As Boolean
        Try
            If sDescription <> "" Then
                bResult = True
            Else
                setError("You must enter a name for the course")
                bResult = False
            End If
        Catch ex As Exception
            setError("Description: Invalid description (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidQuarter(ByVal sQuarter As String) As Boolean
        Dim bResult As Boolean
        Try
            If sQuarter IsNot "FALL" Or sQuarter IsNot "SPRING" Or sQuarter IsNot "SUMMER" Or sQuarter IsNot "WINTER" Then
                bResult = True
            Else
                setError(sQuarter & "is not a valid quarter")
                bResult = False
            End If
        Catch ex As Exception
            setError("Quarter: Invalid quarter (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Sub setError(ByVal s As String)

        If sError = "" Then
            sError = s
        Else
            sError += vbCrLf & s
        End If

    End Sub

    Public Shared Function getError() As String
        Return sError
    End Function

    Public Shared Sub clearErrors()
        sError = ""
    End Sub

End Class
