<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAutos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.gbxOwnerInfo = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtIDnumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvVehicles = New System.Windows.Forms.DataGridView()
        Me.AutosDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AutosDataSet = New Rippee_A8_311.AutosDataSet()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.gbxOwnerInfo.SuspendLayout()
        CType(Me.dgvVehicles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutosDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutosDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxOwnerInfo
        '
        Me.gbxOwnerInfo.Controls.Add(Me.btnCancel)
        Me.gbxOwnerInfo.Controls.Add(Me.btnSave)
        Me.gbxOwnerInfo.Controls.Add(Me.txtIDnumber)
        Me.gbxOwnerInfo.Controls.Add(Me.Label3)
        Me.gbxOwnerInfo.Controls.Add(Me.btnUpdate)
        Me.gbxOwnerInfo.Controls.Add(Me.btnDelete)
        Me.gbxOwnerInfo.Controls.Add(Me.btnAdd)
        Me.gbxOwnerInfo.Controls.Add(Me.btnLast)
        Me.gbxOwnerInfo.Controls.Add(Me.btnNext)
        Me.gbxOwnerInfo.Controls.Add(Me.btnPrevious)
        Me.gbxOwnerInfo.Controls.Add(Me.btnFirst)
        Me.gbxOwnerInfo.Controls.Add(Me.txtState)
        Me.gbxOwnerInfo.Controls.Add(Me.txtZipCode)
        Me.gbxOwnerInfo.Controls.Add(Me.txtCity)
        Me.gbxOwnerInfo.Controls.Add(Me.txtAddress)
        Me.gbxOwnerInfo.Controls.Add(Me.Label2)
        Me.gbxOwnerInfo.Controls.Add(Me.txtLastName)
        Me.gbxOwnerInfo.Controls.Add(Me.txtFirstName)
        Me.gbxOwnerInfo.Controls.Add(Me.Label1)
        Me.gbxOwnerInfo.Location = New System.Drawing.Point(12, 12)
        Me.gbxOwnerInfo.Name = "gbxOwnerInfo"
        Me.gbxOwnerInfo.Size = New System.Drawing.Size(938, 335)
        Me.gbxOwnerInfo.TabIndex = 0
        Me.gbxOwnerInfo.TabStop = False
        Me.gbxOwnerInfo.Text = "Owner Information:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(486, 270)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(169, 35)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(310, 270)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(169, 35)
        Me.btnSave.TabIndex = 17
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'txtIDnumber
        '
        Me.txtIDnumber.Enabled = False
        Me.txtIDnumber.Location = New System.Drawing.Point(788, 41)
        Me.txtIDnumber.Name = "txtIDnumber"
        Me.txtIDnumber.Size = New System.Drawing.Size(139, 26)
        Me.txtIDnumber.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(699, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "ID Number:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(544, 165)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 84)
        Me.btnUpdate.TabIndex = 14
        Me.btnUpdate.TabStop = False
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(427, 165)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(111, 84)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(310, 165)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 84)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.TabStop = False
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(721, 165)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(54, 84)
        Me.btnLast.TabIndex = 11
        Me.btnLast.TabStop = False
        Me.btnLast.Text = ">|"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(661, 165)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(54, 84)
        Me.btnNext.TabIndex = 10
        Me.btnNext.TabStop = False
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(249, 165)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(54, 84)
        Me.btnPrevious.TabIndex = 9
        Me.btnPrevious.TabStop = False
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(189, 165)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(54, 84)
        Me.btnFirst.TabIndex = 8
        Me.btnFirst.TabStop = False
        Me.btnFirst.Text = "|<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtState
        '
        Me.txtState.Enabled = False
        Me.txtState.Location = New System.Drawing.Point(361, 113)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(60, 26)
        Me.txtState.TabIndex = 5
        '
        'txtZipCode
        '
        Me.txtZipCode.Enabled = False
        Me.txtZipCode.Location = New System.Drawing.Point(427, 113)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(161, 26)
        Me.txtZipCode.TabIndex = 6
        '
        'txtCity
        '
        Me.txtCity.Enabled = False
        Me.txtCity.Location = New System.Drawing.Point(128, 113)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(227, 26)
        Me.txtCity.TabIndex = 4
        '
        'txtAddress
        '
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(128, 81)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(460, 26)
        Me.txtAddress.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Address:"
        '
        'txtLastName
        '
        Me.txtLastName.Enabled = False
        Me.txtLastName.Location = New System.Drawing.Point(361, 41)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(227, 26)
        Me.txtLastName.TabIndex = 2
        '
        'txtFirstName
        '
        Me.txtFirstName.Enabled = False
        Me.txtFirstName.Location = New System.Drawing.Point(128, 41)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(227, 26)
        Me.txtFirstName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'dgvVehicles
        '
        Me.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVehicles.Location = New System.Drawing.Point(12, 353)
        Me.dgvVehicles.Name = "dgvVehicles"
        Me.dgvVehicles.ReadOnly = True
        Me.dgvVehicles.RowHeadersWidth = 62
        Me.dgvVehicles.RowTemplate.Height = 28
        Me.dgvVehicles.Size = New System.Drawing.Size(938, 341)
        Me.dgvVehicles.TabIndex = 1
        Me.dgvVehicles.TabStop = False
        '
        'AutosDataSetBindingSource
        '
        Me.AutosDataSetBindingSource.DataSource = Me.AutosDataSet
        Me.AutosDataSetBindingSource.Position = 0
        '
        'AutosDataSet
        '
        Me.AutosDataSet.DataSetName = "AutosDataSet"
        Me.AutosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmAutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 711)
        Me.Controls.Add(Me.dgvVehicles)
        Me.Controls.Add(Me.gbxOwnerInfo)
        Me.Name = "frmAutos"
        Me.Text = "Autos"
        Me.gbxOwnerInfo.ResumeLayout(False)
        Me.gbxOwnerInfo.PerformLayout()
        CType(Me.dgvVehicles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutosDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutosDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbxOwnerInfo As GroupBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtIDnumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtZipCode As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvVehicles As DataGridView
    Friend WithEvents AutosDataSetBindingSource As BindingSource
    Friend WithEvents AutosDataSet As AutosDataSet
    Friend WithEvents HelpProvider1 As HelpProvider
End Class
