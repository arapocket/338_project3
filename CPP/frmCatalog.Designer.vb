<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CATALOG_IDLabel As System.Windows.Forms.Label
        Dim YEARLabel As System.Windows.Forms.Label
        Dim QUARTERLabel As System.Windows.Forms.Label
        Dim COURSE_IDLabel As System.Windows.Forms.Label
        Dim PROF_IDLabel As System.Windows.Forms.Label
        Me.gbCatalogDetail = New System.Windows.Forms.GroupBox()
        Me.CATALOG_IDTextBox = New System.Windows.Forms.TextBox()
        Me.YEARTextBox = New System.Windows.Forms.TextBox()
        Me.QUARTERComboBox = New System.Windows.Forms.ComboBox()
        Me.COURSE_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.PROF_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gbCatalogList = New System.Windows.Forms.GroupBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.CPP_CATALOGDataGridView = New System.Windows.Forms.DataGridView()
        CATALOG_IDLabel = New System.Windows.Forms.Label()
        YEARLabel = New System.Windows.Forms.Label()
        QUARTERLabel = New System.Windows.Forms.Label()
        COURSE_IDLabel = New System.Windows.Forms.Label()
        PROF_IDLabel = New System.Windows.Forms.Label()
        Me.gbCatalogDetail.SuspendLayout()
        Me.gbCatalogList.SuspendLayout()
        CType(Me.CPP_CATALOGDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CATALOG_IDLabel
        '
        CATALOG_IDLabel.AutoSize = True
        CATALOG_IDLabel.Location = New System.Drawing.Point(61, 38)
        CATALOG_IDLabel.Name = "CATALOG_IDLabel"
        CATALOG_IDLabel.Size = New System.Drawing.Size(74, 13)
        CATALOG_IDLabel.TabIndex = 24
        CATALOG_IDLabel.Text = "CATALOG ID:"
        '
        'YEARLabel
        '
        YEARLabel.AutoSize = True
        YEARLabel.Location = New System.Drawing.Point(61, 64)
        YEARLabel.Name = "YEARLabel"
        YEARLabel.Size = New System.Drawing.Size(39, 13)
        YEARLabel.TabIndex = 26
        YEARLabel.Text = "YEAR:"
        '
        'QUARTERLabel
        '
        QUARTERLabel.AutoSize = True
        QUARTERLabel.Location = New System.Drawing.Point(61, 90)
        QUARTERLabel.Name = "QUARTERLabel"
        QUARTERLabel.Size = New System.Drawing.Size(63, 13)
        QUARTERLabel.TabIndex = 28
        QUARTERLabel.Text = "QUARTER:"
        '
        'COURSE_IDLabel
        '
        COURSE_IDLabel.AutoSize = True
        COURSE_IDLabel.Location = New System.Drawing.Point(61, 117)
        COURSE_IDLabel.Name = "COURSE_IDLabel"
        COURSE_IDLabel.Size = New System.Drawing.Size(69, 13)
        COURSE_IDLabel.TabIndex = 30
        COURSE_IDLabel.Text = "COURSE ID:"
        '
        'PROF_IDLabel
        '
        PROF_IDLabel.AutoSize = True
        PROF_IDLabel.Location = New System.Drawing.Point(61, 144)
        PROF_IDLabel.Name = "PROF_IDLabel"
        PROF_IDLabel.Size = New System.Drawing.Size(53, 13)
        PROF_IDLabel.TabIndex = 32
        PROF_IDLabel.Text = "PROF ID:"
        '
        'gbCatalogDetail
        '
        Me.gbCatalogDetail.Controls.Add(CATALOG_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.CATALOG_IDTextBox)
        Me.gbCatalogDetail.Controls.Add(YEARLabel)
        Me.gbCatalogDetail.Controls.Add(Me.YEARTextBox)
        Me.gbCatalogDetail.Controls.Add(QUARTERLabel)
        Me.gbCatalogDetail.Controls.Add(Me.QUARTERComboBox)
        Me.gbCatalogDetail.Controls.Add(COURSE_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.COURSE_IDComboBox)
        Me.gbCatalogDetail.Controls.Add(PROF_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.PROF_IDComboBox)
        Me.gbCatalogDetail.Controls.Add(Me.btnCancel)
        Me.gbCatalogDetail.Controls.Add(Me.btnSave)
        Me.gbCatalogDetail.Location = New System.Drawing.Point(12, 12)
        Me.gbCatalogDetail.Name = "gbCatalogDetail"
        Me.gbCatalogDetail.Size = New System.Drawing.Size(641, 252)
        Me.gbCatalogDetail.TabIndex = 14
        Me.gbCatalogDetail.TabStop = False
        Me.gbCatalogDetail.Text = "Course Catalog Information"
        Me.gbCatalogDetail.Visible = False
        '
        'CATALOG_IDTextBox
        '
        Me.CATALOG_IDTextBox.Location = New System.Drawing.Point(141, 35)
        Me.CATALOG_IDTextBox.Name = "CATALOG_IDTextBox"
        Me.CATALOG_IDTextBox.Size = New System.Drawing.Size(75, 20)
        Me.CATALOG_IDTextBox.TabIndex = 25
        '
        'YEARTextBox
        '
        Me.YEARTextBox.Location = New System.Drawing.Point(141, 61)
        Me.YEARTextBox.Name = "YEARTextBox"
        Me.YEARTextBox.Size = New System.Drawing.Size(121, 20)
        Me.YEARTextBox.TabIndex = 27
        '
        'QUARTERComboBox
        '
        Me.QUARTERComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.QUARTERComboBox.FormattingEnabled = True
        Me.QUARTERComboBox.Items.AddRange(New Object() {"FALL", "WINTER", "SPRING", "SUMMER"})
        Me.QUARTERComboBox.Location = New System.Drawing.Point(141, 87)
        Me.QUARTERComboBox.Name = "QUARTERComboBox"
        Me.QUARTERComboBox.Size = New System.Drawing.Size(121, 21)
        Me.QUARTERComboBox.TabIndex = 29
        '
        'COURSE_IDComboBox
        '
        Me.COURSE_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.COURSE_IDComboBox.FormattingEnabled = True
        Me.COURSE_IDComboBox.Location = New System.Drawing.Point(141, 114)
        Me.COURSE_IDComboBox.Name = "COURSE_IDComboBox"
        Me.COURSE_IDComboBox.Size = New System.Drawing.Size(291, 21)
        Me.COURSE_IDComboBox.TabIndex = 31
        '
        'PROF_IDComboBox
        '
        Me.PROF_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PROF_IDComboBox.FormattingEnabled = True
        Me.PROF_IDComboBox.Location = New System.Drawing.Point(141, 141)
        Me.PROF_IDComboBox.Name = "PROF_IDComboBox"
        Me.PROF_IDComboBox.Size = New System.Drawing.Size(291, 21)
        Me.PROF_IDComboBox.TabIndex = 33
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(165, 191)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(64, 191)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 23
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gbCatalogList
        '
        Me.gbCatalogList.Controls.Add(Me.btnFind)
        Me.gbCatalogList.Controls.Add(Me.btnDelete)
        Me.gbCatalogList.Controls.Add(Me.btnUpdate)
        Me.gbCatalogList.Controls.Add(Me.btnAdd)
        Me.gbCatalogList.Controls.Add(Me.CPP_CATALOGDataGridView)
        Me.gbCatalogList.Location = New System.Drawing.Point(12, 270)
        Me.gbCatalogList.Name = "gbCatalogList"
        Me.gbCatalogList.Size = New System.Drawing.Size(641, 382)
        Me.gbCatalogList.TabIndex = 15
        Me.gbCatalogList.TabStop = False
        Me.gbCatalogList.Text = "Course Catalog List"
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(295, 327)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 18
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(199, 327)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(107, 327)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(17, 327)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'CPP_CATALOGDataGridView
        '
        Me.CPP_CATALOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CPP_CATALOGDataGridView.Location = New System.Drawing.Point(17, 24)
        Me.CPP_CATALOGDataGridView.Name = "CPP_CATALOGDataGridView"
        Me.CPP_CATALOGDataGridView.Size = New System.Drawing.Size(607, 272)
        Me.CPP_CATALOGDataGridView.TabIndex = 14
        '
        'frmCatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 662)
        Me.Controls.Add(Me.gbCatalogList)
        Me.Controls.Add(Me.gbCatalogDetail)
        Me.Name = "frmCatalog"
        Me.Text = "CPP COURSE CATALOG INFORMATION"
        Me.gbCatalogDetail.ResumeLayout(False)
        Me.gbCatalogDetail.PerformLayout()
        Me.gbCatalogList.ResumeLayout(False)
        CType(Me.CPP_CATALOGDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbCatalogDetail As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gbCatalogList As System.Windows.Forms.GroupBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents CPP_CATALOGDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CATALOG_IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YEARTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QUARTERComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents COURSE_IDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PROF_IDComboBox As System.Windows.Forms.ComboBox
End Class
