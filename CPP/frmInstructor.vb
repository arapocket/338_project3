Public Class frmInstructor
    Dim instructorList As New List(Of clsInstructor)

    Private Sub frminstructor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        instructorList = CPP_DB.loadInstructors()
        CPP_DB.dbClose()
        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim instructorBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE instructor LIST
        instructorBindingSource.DataSource = instructorList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_INSTRUCTORSDataGridView.DataSource = instructorBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF InstructorS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbInstructorDetail.Hide()
            Me.gbInstructorList.Left = 0
            Me.gbInstructorList.Top = 0
            Me.Width = gbInstructorList.Width + 50
            Me.Height = gbInstructorList.Height + 50

            Me.gbInstructorList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbInstructorList.Hide()
            Me.gbInstructorDetail.Left = 0
            Me.gbInstructorDetail.Top = 0
            Me.Width = gbInstructorDetail.Width + 50
            Me.Height = gbInstructorDetail.Height + 50

            Me.gbInstructorDetail.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.PROF_IDTextBox.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE Instructor OBJECT
        Dim aInstructor As New clsInstructor
        clsValidator.clearErrors()

        'POPULATE Instructor OBJECT
        aInstructor.profID = Me.PROF_IDTextBox.Text
        aInstructor.firstName = Me.FIRST_NAMETextBox.Text
        aInstructor.lastName = Me.LAST_NAMETextBox.Text
        aInstructor.phone = Me.PHONETextBox.Text
        aInstructor.department = Me.DEPARTMENTTextBox.Text


        'VALIDATE
        If clsValidator.getError <> "" Then
            MessageBox.Show(clsValidator.getError())
            Exit Sub
        End If

        'CHECK IF WE ARE SAVING OR UPDATING
        If (btnSave.Text = "&Save") Then

            'SAVE Instructor
            CPP_DB.dbOpen()
            CPP_DB.insertinstructor(aInstructor)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                instructorList.Add(aInstructor)                       'NO ERRORS ADD Instructor TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Instructor Saved!")               'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'UPDATE Instructor
            CPP_DB.dbOpen()
            CPP_DB.updateinstructor(aInstructor)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'REMOVE OLD Instructor FROM LIST
                For Each Instructor In instructorList
                    If Instructor.profID = aInstructor.profID Then
                        instructorList.Remove(Instructor)
                        Exit For
                    End If
                Next
                instructorList.Add(aInstructor)                       'NO ERRORS ADD NEW Instructor TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Instructor Updated!")             'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT Instructor ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_INSTRUCTORSDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A Instructor OBJECT
        Dim aInstructor As clsInstructor = TryCast(row.DataBoundItem, clsInstructor)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.PROF_IDTextBox.Text = aInstructor.profID
        Me.FIRST_NAMETextBox.Text = aInstructor.firstName
        Me.LAST_NAMETextBox.Text = aInstructor.lastName
        Me.PHONETextBox.Text = aInstructor.phone
        Me.DEPARTMENTTextBox.Text = aInstructor.department

        'SET THE FOCUS ON ID
        Me.PROF_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_INSTRUCTORSDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO Instructor
        Dim aInstructor As clsInstructor = TryCast(row.DataBoundItem, clsInstructor)

        'DELETE Instructor FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteinstructor(aInstructor.profID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Instructor Deleted!")
            'REMOVE Instructor FROM LIST
            For Each Instructor In instructorList
                If Instructor.profID = aInstructor.profID Then
                    instructorList.Remove(Instructor)
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
        For Each ctrl In gbInstructorDetail.Controls
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
        Dim strPROFId As String = InputBox("Enter PROF ID")

        For Each row As DataGridViewRow In CPP_INSTRUCTORSDataGridView.Rows
            If row.Cells(0).Value = strPROFId Then
                row.Selected = True 'CPP_InstructorSDataGridView.CurrentRow.
                MessageBox.Show("Found!")
                Exit Sub
            End If
        Next

        MessageBox.Show("Not found!")
    End Sub

End Class