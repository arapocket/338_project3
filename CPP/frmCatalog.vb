Public Class frmCatalog
    Dim catalogList As New List(Of clsCatalog)
    Dim courseList As New List(Of clsCourse)
    Dim instructorList As New List(Of clsInstructor)

    Private Sub frmCatalog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        catalogList = CPP_DB.loadCatalog()
        CPP_DB.dbClose()

        'Load the courses in the combo box
        CPP_DB.dbOpen()
        courseList = CPP_DB.loadCourses()
        CPP_DB.dbClose()

        'Load the instructors in the combo box
        CPP_DB.dbOpen()
        instructorList = CPP_DB.loadInstructors()
        CPP_DB.dbClose()

        Dim courses As New List(Of String)
        For Each aCourse As clsCourse In courseList
            courses.Add(aCourse.courseID & " - " & aCourse.description)
        Next
        COURSE_IDComboBox.DataSource = courses

        Dim instructors As New List(Of String)
        For Each instructor As clsInstructor In instructorList
            instructors.Add(instructor.profID & " - " & instructor.firstName & " , " & instructor.lastName & " , " & instructor.department)
        Next
        PROF_IDComboBox.DataSource = instructors




        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If


    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim CatalogBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        CatalogBindingSource.DataSource = catalogList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_CATALOGDataGridView.DataSource = CatalogBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CatalogS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbCatalogDetail.Hide()
            Me.gbCatalogList.Left = 0
            Me.gbCatalogList.Top = 0
            Me.Width = gbCatalogList.Width + 50
            Me.Height = gbCatalogList.Height + 50

            Me.gbCatalogList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbCatalogList.Hide()
            Me.gbCatalogDetail.Left = 0
            Me.gbCatalogDetail.Top = 0
            Me.Width = gbCatalogDetail.Width + 50
            Me.Height = gbCatalogDetail.Height + 50

            Me.gbCatalogDetail.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.CATALOG_IDTextBox.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim aCatalog As New clsCatalog
        Dim aCourse As New clsCourse
        Dim aInstructor As New clsInstructor

        clsValidator.clearErrors()

        'POPULATE CATALOG OBJECT
        aCatalog.catalogID = Me.CATALOG_IDTextBox.Text
        aCatalog.year = Me.YEARTextBox.Text
        aCatalog.quarter = Me.QUARTERComboBox.Text
        aCatalog.courseID = Me.COURSE_IDComboBox.Text
        aCatalog.profID = Me.PROF_IDComboBox.Text

        aCourse.courseID = COURSE_IDComboBox.Text.Split("-").GetValue(0)
        aCatalog.courseID = aCourse.courseID
        aInstructor.profID = PROF_IDComboBox.Text.Split("-").GetValue(0)
        aCatalog.profID = aInstructor.profID


        'VALIDATE
        If clsValidator.getError <> "" Then
            MessageBox.Show(clsValidator.getError())
            Exit Sub
        End If

        'CHECK IF WE ARE SAVING OR UPDATING
        If (btnSave.Text = "&Save") Then

            'SAVE Catalog
            CPP_DB.dbOpen()
            CPP_DB.insertCatalog(aCatalog)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                catalogList.Add(aCatalog)                       'NO ERRORS ADD Catalog TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Catalog Saved!")               'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'UPDATE Catalog
            CPP_DB.dbOpen()
            CPP_DB.updateCatalog(aCatalog)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'REMOVE OLD Catalog FROM LIST
                For Each Catalog In catalogList
                    If Catalog.catalogID = aCatalog.catalogID Then
                        catalogList.Remove(Catalog)
                        Exit For
                    End If
                Next
                catalogList.Add(aCatalog)                       'NO ERRORS ADD NEW Catalog TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Catalog Updated!")             'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT Catalog ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A Catalog OBJECT
        Dim aCatalog As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.CATALOG_IDTextBox.Text = aCatalog.catalogID
        Me.YEARTextBox.Text = aCatalog.year
        Me.QUARTERComboBox.Text = aCatalog.quarter
        Me.COURSE_IDComboBox.Text = aCatalog.courseID
        Me.PROF_IDComboBox.Text = aCatalog.profID

        'SET THE FOCUS ON ID
        Me.CATALOG_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO Catalog
        Dim aCatalog As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'DELETE Catalog FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteCatalog(aCatalog.catalogID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Catalog Deleted!")
            'REMOVE Catalog FROM LIST
            For Each Catalog In catalogList
                If Catalog.catalogID = aCatalog.catalogID Then
                    catalogList.Remove(Catalog)
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
        For Each ctrl In gbCatalogDetail.Controls
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
        Dim strcatalogId As String = InputBox("Enter catalog ID")

        For Each row As DataGridViewRow In CPP_CATALOGDataGridView.Rows
            If row.Cells(0).Value = strcatalogId Then
                row.Selected = True 'CPP_CatalogDataGridView.CurrentRow.
                MessageBox.Show("Found!")
                Exit Sub
            End If
        Next

        MessageBox.Show("Not found!")
    End Sub


End Class