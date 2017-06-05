Imports System.Data.SqlClient
Public Class CPP_DB
    Private Shared cn As SqlConnection
    Private Shared strError As String




    '------------------------------------------------------------STUDENT FORM FUNCTIONS

    Public Shared Function loadStudents() As List(Of clsStudent)
        'List of students that will be returned
        Dim studentList As New List(Of clsStudent)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_STUDENTS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic student information
                Dim aStudent As New clsStudent
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function deleteStudent(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_STUDENTS where BRONCO_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch e As SqlException
            dbAddError("Enrollment is using this data")
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateStudent(aStudent As clsStudent)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteStudent(aStudent.broncoID)

        If strError = "" Then
            insertStudent(aStudent)
        End If

        If strError <> "" Then
            strError = "Could not Update student " & aStudent.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertStudent(aStudent As clsStudent) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_STUDENTS (BRONCO_ID, FIRST_NAME, LAST_NAME, PHONE, EMAIL) " & _
                            "values('" & aStudent.broncoID & "','" & aStudent.firstName & "','" & aStudent.lastName & "','" & aStudent.phone & "', '" & _
                            aStudent.email & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findStudent(strStudentID As String) As clsStudent
        'student that will be returned
        Dim aStudent As clsStudent = New clsStudent

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_STUDENT Where ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")
            Else
                dbAddError("Student not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    '------------------------------------------------------------COURSE FORM FUNCTIONS

    Public Shared Function loadCourses() As List(Of clsCourse)
        'List of courses that will be returned
        Dim courseList As New List(Of clsCourse)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_COURSES"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic course information
                Dim aCourse As New clsCourse
                aCourse.courseID = rdr("COURSE_ID")
                aCourse.description = rdr("DESCRIPTION")
                aCourse.units = rdr("UNITS")


                courseList.Add(aCourse)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return courseList
    End Function

    Public Shared Function deleteCourse(strCourseID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_COURSES where COURSE_ID = '" & strCourseID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Course id " & strCourseID & " was not found!")
            End If

            dbClose()
        Catch e As SqlException
            dbAddError("Course is used in catalog table")
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateCourse(aCourse As clsCourse)
        strError = ""

        'To update we remove old Course and add new Course
        'there are other ways to do this as well using the update statement
        deleteCourse(aCourse.courseID)
        insertCourse(aCourse)

        If strError <> "" Then
            strError = "Could not Update Course " & aCourse.courseID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertCourse(aCourse As clsCourse) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strCourseSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strCourseSQL = "INSERT INTO CPP_COURSES (COURSE_ID, DESCRIPTION, UNITS) " & _
                            "values('" & aCourse.courseID & "','" & aCourse.description & "','" & aCourse.units & "')"

            cmd.Connection = cn
            cmd.CommandText = strCourseSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findCourse(strCourseID As String) As clsCourse
        'Course that will be returned
        Dim aCourse As clsCourse = New clsCourse

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_COURSES Where ID = '" & strCourseID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aCourse.courseID = rdr("COURSE_ID")
                aCourse.description = rdr("description")
                aCourse.units = rdr("units")

            Else
                dbAddError("Course not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aCourse
    End Function

    '------------------------------------------------------------INSTRUCTOR FORM FUNCTIONS

    Public Shared Function loadInstructors() As List(Of clsInstructor)
        'List of instructors that will be returned
        Dim instructorList As New List(Of clsInstructor)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_INSTRUCTORS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic instructor information
                Dim aInstructor As New clsInstructor
                aInstructor.profID = rdr("PROF_ID")
                aInstructor.firstName = rdr("FIRST_NAME")
                aInstructor.lastName = rdr("LAST_NAME")
                aInstructor.phone = rdr("PHONE")
                aInstructor.department = rdr("DEPARTMENT")

                instructorList.Add(aInstructor)

            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return instructorList
    End Function

    Public Shared Function deleteinstructor(strprofID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_INSTRUCTORS where PROF_ID = '" & strprofID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, instructor id " & strprofID & " was not found!")
            End If

            dbClose()
        Catch e As SqlException
            dbAddError("This professor is used in course catalog")
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateinstructor(aInstructor As clsInstructor)
        strError = ""

        'To update we remove old instructor and add new instructor
        'there are other ways to do this as well using the update statement
        deleteinstructor(aInstructor.profID)

        If strError = "" Then
            insertinstructor(aInstructor)
        End If
        If strError <> "" Then
            strError = "Could not Update instructor " & aInstructor.profID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertinstructor(aInstructor As clsInstructor) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strinstructorSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strinstructorSQL = "INSERT INTO CPP_INSTRUCTORS (PROF_ID, FIRST_NAME, LAST_NAME, PHONE, DEPARTMENT) " & _
                            "values('" & aInstructor.profID & "','" & aInstructor.firstName & "','" & aInstructor.lastName & "','" & aInstructor.phone & "','" & aInstructor.department & "')"

            cmd.Connection = cn
            cmd.CommandText = strinstructorSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findinstructor(strprofID As String) As clsInstructor
        'instructor that will be returned
        Dim aInstructor As clsInstructor = New clsInstructor

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_INSTRUCTORS Where ID = '" & strprofID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aInstructor.profID = rdr("PROF_ID")
                aInstructor.firstName = rdr("FIRST_NAME")
                aInstructor.lastName = rdr("LAST_NAME")
                aInstructor.phone = rdr("PHONE")
                aInstructor.department = rdr("DEPARTMENT")

            Else
                dbAddError("instructor not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aInstructor
    End Function

    '------------------------------------------------------------CATALOG FORM FUNCTIONS

    Public Shared Function loadCatalog() As List(Of clsCatalog)
        'List of Catalogs that will be returned
        Dim CatalogList As New List(Of clsCatalog)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_CATALOG"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic Catalog information
                Dim aCatalog As New clsCatalog
                aCatalog.catalogID = rdr("CATALOG_ID")
                aCatalog.year = rdr("YEAR")
                aCatalog.quarter = rdr("QUARTER")
                aCatalog.courseID = rdr("COURSE_ID")
                aCatalog.profID = rdr("PROF_ID")


                CatalogList.Add(aCatalog)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return CatalogList
    End Function

    Public Shared Function deleteCatalog(strCatalogID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_CATALOG where CATALOG_ID = '" & strCatalogID & "'"
            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Catalog id " & strCatalogID & " was not found!")
            End If

            dbClose()
        Catch e As SqlException
            dbAddError("Enrollment is using this data")

        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateCatalog(aCatalog As clsCatalog)
        strError = ""

        'To update we remove old Catalog and add new Catalog
        'there are other ways to do this as well using the update statement
        deleteCatalog(aCatalog.catalogID)

        If strError = "" Then
            insertCatalog(aCatalog)
        End If
        If strError <> "" Then
            strError = "Could not Update Catalog " & aCatalog.catalogID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertCatalog(aCatalog As clsCatalog) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strCatalogSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strCatalogSQL = "INSERT INTO CPP_CATALOG (CATALOG_ID, YEAR, QUARTER, COURSE_ID, PROF_ID) " & _
                            "values('" & aCatalog.catalogID & "','" & aCatalog.year & "','" & aCatalog.quarter & "','" & aCatalog.courseID & "', '" & _
                            aCatalog.profID & "')"

            cmd.Connection = cn
            cmd.CommandText = strCatalogSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findCatalog(strCatalogID As String) As clsCatalog
        'Catalog that will be returned
        Dim aCatalog As clsCatalog = New clsCatalog

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_Catalog Where ID = '" & strCatalogID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aCatalog.catalogID = rdr("CATALOG_ID")
                aCatalog.year = rdr("YEAR")
                aCatalog.quarter = rdr("QUARTER")
                aCatalog.courseID = rdr("COURSE_ID")
                aCatalog.profID = rdr("PROF_ID")
            Else
                dbAddError("Catalog not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aCatalog
    End Function

    '------------------------------------------------------------Enrollment FORM FUNCTIONS

    Public Shared Function loadEnrollment() As List(Of clsEnrollment)
        'List of Enrollments that will be returned
        Dim EnrollmentList As New List(Of clsEnrollment)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_ENROLLMENT"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                'Add basic Enrollment information
                Dim aEnrollment As New clsEnrollment
                aEnrollment.broncoID = rdr("BRONCO_ID")
                aEnrollment.catalogID = rdr("CATALOG_ID")
                EnrollmentList.Add(aEnrollment)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return EnrollmentList
    End Function

    Public Shared Function deleteEnrollment(strBroncoID As String, strCatalogID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = " Delete from CPP_Enrollment where BRONCO_ID = '" & strBroncoID & "' AND CATALOG_ID = '" & strCatalogID & "' "

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Enrollment id " & strBroncoID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateEnrollment(aEnrollment As clsEnrollment)
        strError = ""

        'To update we remove old Enrollment and add new Enrollment
        'there are other ways to do this as well using the update statement
        deleteEnrollment(aEnrollment.broncoID, aEnrollment.catalogID)
        insertEnrollment(aEnrollment)

        If strError <> "" Then
            strError = "Could not Update Enrollment " & aEnrollment.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertEnrollment(aEnrollment As clsEnrollment) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strEnrollmentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strEnrollmentSQL = "INSERT INTO CPP_ENROLLMENT (BRONCO_ID, CATALOG_ID) " & _
                            "values('" & aEnrollment.broncoID & "','" & aEnrollment.catalogID & "')"

            cmd.Connection = cn
            cmd.CommandText = strEnrollmentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findEnrollment(strEnrollmentID As String) As clsEnrollment
        'Enrollment that will be returned
        Dim aEnrollment As clsEnrollment = New clsEnrollment

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_Enrollment Where ID = '" & strEnrollmentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aEnrollment.broncoID = rdr("BRONCO_ID")
                aEnrollment.catalogID = rdr("CATALOG_ID")

            Else
                dbAddError("Enrollment not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aEnrollment
    End Function

    '------------------------------------------------------------GENERAL DB FUNCTIONS

    Public Shared Sub dbOpen()
        'Only assign one reference to the connection
        If IsNothing(cn) Then
            cn = New SqlConnection
            'EXAMPLE OF CONNECTION STRING TO A SQL SERVER INSTANCE
            'cn.ConnectionString = "Data Source=SKYNET\SQLEXPRESS;Initial Catalog=CPP;Integrated Security=True"

            'EXAMPLE OF CONNECTION TO A LOCAL DATABASE FILE. YOU MIGHT NEED TO ADJUST THE CONNECTION STRING
            'BASED ON YOUR PROJECT DATABASE VERSION. 
            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CPP.mdf;Integrated Security=True"

        End If
    End Sub

    Public Shared Sub dbConnect()
        'Only open if connection is closed
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub

    Public Shared Sub dbClose()
        'Only close if open
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Shared Sub dbAddError(ByVal s As String)
        'build error
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub

    Public Shared Function dbGetError() As String
        'return error
        Return strError
    End Function

End Class
