Public Class frmEnrollment

    Dim enrollmentList As New List(Of clsEnrollment)
    Dim studentList As New List(Of clsStudent)
    Dim catalogList As New List(Of clsCatalog)
    Dim broncoComboDetail As New List(Of String)
    Dim catalogComboDetail As New List(Of String)

    Private Sub frmEnrollment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        enrollmentList = CPP_DB.loadEnrollment()
        CPP_DB.dbClose()

        'FILL BRONCOID COMBOBOX
        CPP_DB.dbOpen()
        studentList = CPP_DB.loadStudents()
        CPP_DB.dbClose()

        'FILL CATALOG COMBOBOX
        CPP_DB.dbOpen()
        catalogList = CPP_DB.loadCatalog()
        CPP_DB.dbClose()

        'FILL DETAILS FOR STUDENTS IN COMBOBOX
        For Each aStudent As clsStudent In studentList
            broncoComboDetail.Add(aStudent.broncoID & " - " & "(" & aStudent.firstName & " " & aStudent.lastName & ")")
        Next
        BRONCO_IDComboBox.DataSource = broncoComboDetail


        'FILL DETAILS FOR CATALOG COMBOBOX
        Dim catalogInfo As New List(Of String)

        For Each aCatalog As clsCatalog In catalogList
            catalogInfo.Add(aCatalog.catalogID & " - " & aCatalog.courseID & " , " & aCatalog.year & " , " & aCatalog.quarter & " , " & aCatalog.profID)
        Next
        CATALOG_IDComboBox.DataSource = catalogInfo


        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If


    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        StudentBindingSource.DataSource = EnrollmentList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_ENROLLMENTDataGridView.DataSource = StudentBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF EnrollmentS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbEnrollmentDetail.Hide()
            Me.gbEnrollmentList.Left = 0
            Me.gbEnrollmentList.Top = 0
            Me.Width = gbEnrollmentList.Width + 50
            Me.Height = gbEnrollmentList.Height + 50

            Me.gbEnrollmentList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbEnrollmentList.Hide()
            Me.gbEnrollmentDetail.Left = 0
            Me.gbEnrollmentDetail.Top = 0
            Me.Width = gbEnrollmentDetail.Width + 50
            Me.Height = gbEnrollmentDetail.Height + 50

            Me.gbEnrollmentDetail.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.BRONCO_IDComboBox.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE Enrollment OBJECT
        Dim aEnrollment As New clsEnrollment
        clsValidator.clearErrors()


        'POPULATE Enrollment OBJECT
        aEnrollment.broncoID = Me.BRONCO_IDComboBox.Text.Split(" -").GetValue(0)
        aEnrollment.catalogID = Me.CATALOG_IDComboBox.Text.Split(" -").GetValue(0)

        'VALIDATE
        If clsValidator.getError <> "" Then
            MessageBox.Show(clsValidator.getError())
            Exit Sub
        End If


        'CHECK IF WE ARE SAVING OR UPDATING
        If (btnSave.Text = "&Save") Then

            'SAVE Enrollment
            CPP_DB.dbOpen()
            CPP_DB.insertEnrollment(aEnrollment)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                enrollmentList.Add(aEnrollment)                       'NO ERRORS ADD Enrollment TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Enrollment Saved!")               'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If

        Else



            'UPDATE Enrollment
            CPP_DB.dbOpen()
            CPP_DB.updateEnrollment(aEnrollment)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'REMOVE OLD Enrollment FROM LIST
                For Each Enrollment In enrollmentList
                    If Enrollment.broncoID = aEnrollment.broncoID And Enrollment.catalogID = aEnrollment.catalogID Then
                        enrollmentList.Remove(Enrollment)
                        Exit For
                    End If
                Next
                enrollmentList.Add(aEnrollment)                       'NO ERRORS ADD NEW Enrollment TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Enrollment Updated!")             'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If



    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT Enrollment ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A Enrollment OBJECT
        Dim aEnrollment As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.BRONCO_IDComboBox.Text = aEnrollment.broncoID
        Me.CATALOG_IDComboBox.Text = aEnrollment.catalogID


        'SET THE FOCUS ON ID
        Me.BRONCO_IDComboBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO Enrollment
        Dim aEnrollment As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'DELETE Enrollment FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteEnrollment(aEnrollment.broncoID, aEnrollment.catalogID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Enrollment Deleted!")
            'REMOVE Enrollment FROM LIST
            For Each Enrollment In enrollmentList
                If Enrollment.broncoID = aEnrollment.broncoID Then
                    enrollmentList.Remove(Enrollment)
                    Exit For
                End If
            Next
            'UPDATE GRID
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'CLEAR ALL CONTROLS
        For Each ctrl In gbEnrollmentDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim strBroncoId As String = InputBox("Enter Bronco ID")

        For Each row As DataGridViewRow In CPP_ENROLLMENTDataGridView.Rows
            If row.Cells(0).Value = strBroncoId Then
                row.Selected = True 'CPP_EnrollmentSDataGridView.CurrentRow.
                MessageBox.Show("Found!")
                Exit Sub
            End If
        Next

        MessageBox.Show("Not found!")
    End Sub



End Class