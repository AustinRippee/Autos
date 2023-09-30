Imports System.Data.SqlClient
'------------------------------------------------------------
'-                File Name : frmAutos.frm                     - 
'-                Part of Project: Main                  -
'------------------------------------------------------------
'-                Written By: Austin Rippee                     -
'-                Written On: April 3rd, 2022        -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file is the main class in which holds the
'- entire program.
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program takes data in from a previously created
'- database and displays the various information from the 
'- database tables and can add, update, and remove rows from
'- the database tables through the application. With that said
'- the program displays an individuals information Name, Address,
'- City, State, and ZipCode and the vehicles that are associated
'- with that owner.
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- DBConn - Sets as the Database connection for the program
'- cmd - The sql command to take in query commands to execute
'- intMaxRecord - Keeps track of the max amount of records created in the owners table
'- intRecordOwner - Keeps track of the current record the user is viewing
'- strCONNECTION - Connection string
'- strDBNAME - The database name
'- strDBPATH - The path of the database
'- strSERVERNAME - The Server name for the database
'------------------------------------------------------------
Public Class frmAutos
    'Creates the Connection to the database
    Const strDBNAME As String = "Autos"
    Const strSERVERNAME As String = "(localdb)\MSSQLLocalDB;"
    Dim strDBPATH As String = My.Application.Info.DirectoryPath & "\" & strDBNAME & ".mdf"
    Dim strCONNECTION As String = "Data Source=" & strSERVERNAME & "AttachDbFilename=" & strDBPATH & ";Integrated Security=True;Connect Timeout=30"

    'Initializes a global variable for first record and last record
    Public intRecordOwner As Integer = 1
    Public intMaxRecord As Integer = ReturnMaxID()

    'Creates the database connection and initlizes the global command
    Public DBConn As SqlConnection
    Public cmd As SqlCommand = New SqlCommand("", DBConn)

    'Checks whether the user clicked Add / UPDATE / DELETE
    Public strActions As String = ""

    '------------------------------------------------------------
    '-                Subprogram Name: frmAutos_Load            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user loads the
    '– initial form of the program.
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '- DBAdapter - Creates the database adapter
    '- DBCommand - Creates the database sql command
    '- myDataset - Creates the data set
    '- strSQLCmd - Creates the string command
    '------------------------------------------------------------
    Private Sub frmAutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-------------------------------------------------------------------
        ' I AM USING THE VISUAL STUDIO IDE TO CREATE MY DATABASE
        '-------------------------------------------------------------------

        'Initializes variables based on sql requirements
        Dim strSQLCmd As String
        Dim DBCommand As New SqlCommand
        Dim myDataset As New DataSet
        Dim DBAdapter As New SqlDataAdapter

        'Creates the connection and opens it
        DBConn = New SqlConnection(strCONNECTION)
        DBConn.Open()

        'Sets the current Owner ID record as the ID number
        txtIDnumber.Text = intRecordOwner

        'Initlializes cmd to take in a sql command to execute
        Dim cmd As SqlCommand = New SqlCommand("", DBConn)
        cmd.CommandType = CommandType.Text

        'Query to read in the first name and set it as the textbox
        cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
        txtFirstName.Text = cmd.ExecuteScalar()

        'Query to read in the last name and set it as the textbox
        cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
        txtLastName.Text = cmd.ExecuteScalar()

        'Query to read in the street address and set it as the textbox
        cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
        txtAddress.Text = cmd.ExecuteScalar()

        'Query to read in the city and set it as the textbox
        cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
        txtCity.Text = cmd.ExecuteScalar()

        'Query to read in the state and set it as the textbox
        cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
        txtState.Text = cmd.ExecuteScalar()

        'Query to read in the zip code and set it as the textbox
        cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
        txtZipCode.Text = cmd.ExecuteScalar()

        'Query to takes the Make, Model, Color, ModelYear, and VIN based on the OwnerID
        strSQLCmd = "SELECT Make, Model, Color, ModelYear, VIN FROM Vehicles WHERE OwnerID = " & intRecordOwner

        'Sets the command to the database command
        DBCommand.CommandText = strSQLCmd

        'Initializes the adapter for the command
        DBAdapter = New SqlDataAdapter(strSQLCmd, DBConn)

        'Fills the datagridview with the dataset
        DBAdapter.Fill(myDataset, "Owners")

        'Adds the fill to the datasource
        dgvVehicles.DataSource = myDataset.Tables("Owners")
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnFirst_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- first button. It takes the user to the first record.                                      –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '- DBAdapter - Creates the database adapter
    '- DBCommand - Creates the database sql command
    '- DBConn - Creates the sql connection for the database
    '- myDataset - Creates the data set
    '- strSQLCmd - Creates the string command
    '------------------------------------------------------------
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Checks if the user is at the first record
        If txtIDnumber.Text = 1 Then
            MsgBox("You are already at the first record")
        Else
            intRecordOwner = 1
            txtIDnumber.Text = intRecordOwner

            'Initializes variables based on sql requirements
            Dim DBConn As SqlConnection
            Dim strSQLCmd As String
            Dim DBCommand As New SqlCommand
            Dim myDataset As New DataSet
            Dim DBAdapter As New SqlDataAdapter

            'Creates the connection and opens it
            DBConn = New SqlConnection(strCONNECTION)
            DBConn.Open()

            'Initlializes cmd to take in a sql command to execute
            Dim cmd As SqlCommand = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Query to takes the Make, Model, Color, ModelYear, and VIN based on the OwnerID
            strSQLCmd = "SELECT Make, Model, Color, ModelYear, VIN FROM Vehicles WHERE OwnerID = " & intRecordOwner

            'Sets the command to the database command
            DBCommand.CommandText = strSQLCmd

            'Initializes the adapter for the command
            DBAdapter = New SqlDataAdapter(strSQLCmd, DBConn)

            'Fills the datagridview with the dataset
            DBAdapter.Fill(myDataset, "Owners")

            'Adds the fill to the datasource
            dgvVehicles.DataSource = myDataset.Tables("Owners")
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnPrevious_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- previous button. It takes the user back 1 record.                                      –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '- DBAdapter - Creates the database adapter
    '- DBCommand - Creates the database sql command
    '- DBConn - Creates the sql connection for the database
    '- myDataset - Creates the data set
    '- strSQLCmd - Creates the string command
    '------------------------------------------------------------
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        'Checks if the user is at the first record
        If txtIDnumber.Text = 1 Then
            MsgBox("You are already at the first record")
        Else
            'Subtracts 1 from the current record
            intRecordOwner -= 1
            txtIDnumber.Text = intRecordOwner

            'Initializes variables based on sql requirements
            Dim DBConn As SqlConnection
            Dim strSQLCmd As String
            Dim DBCommand As New SqlCommand
            Dim myDataset As New DataSet
            Dim DBAdapter As New SqlDataAdapter

            'Creates the connection and opens it
            DBConn = New SqlConnection(strCONNECTION)
            DBConn.Open()

            'Initlializes cmd to take in a sql command to execute
            Dim cmd As SqlCommand = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Query to takes the Make, Model, Color, ModelYear, and VIN based on the OwnerID
            strSQLCmd = "SELECT Make, Model, Color, ModelYear, VIN FROM Vehicles WHERE OwnerID = " & intRecordOwner

            'Sets the command to the database command
            DBCommand.CommandText = strSQLCmd

            'Initializes the adapter for the command
            DBAdapter = New SqlDataAdapter(strSQLCmd, DBConn)

            'Fills the datagridview with the dataset
            DBAdapter.Fill(myDataset, "Owners")

            'Adds the fill to the datasource
            dgvVehicles.DataSource = myDataset.Tables("Owners")
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnNext_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- next button. It takes the user forward 1 button.                                       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '- DBAdapter - Creates the database adapter
    '- DBCommand - Creates the database sql command
    '- DBConn - Creates the sql connection for the database
    '- myDataset - Creates the data set
    '- strSQLCmd - Creates the string command
    '------------------------------------------------------------
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Initializes variables based on sql requirements
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCommand As New SqlCommand
        Dim myDataset As New DataSet
        Dim DBAdapter As New SqlDataAdapter

        'Creates the connection and opens it
        DBConn = New SqlConnection(strCONNECTION)
        DBConn.Open()

        'Initlializes cmd to take in a sql command to execute
        Dim cmd As SqlCommand = New SqlCommand("", DBConn)
        cmd.CommandType = CommandType.Text

        'Checks if the current ID is the max ID
        If txtIDnumber.Text = intMaxRecord Then
            MsgBox("You are already at the last record")
        Else
            'Adds 1 to the current record
            intRecordOwner += 1
            txtIDnumber.Text = intRecordOwner

            'Creates the connection and opens it
            DBConn = New SqlConnection(strCONNECTION)
            DBConn.Open()

            'Initlializes cmd to take in a sql command to execute
            cmd = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Query to takes the Make, Model, Color, ModelYear, and VIN based on the OwnerID
            strSQLCmd = "SELECT Make, Model, Color, ModelYear, VIN FROM Vehicles WHERE OwnerID = " & intRecordOwner

            'Sets the command to the database command
            DBCommand.CommandText = strSQLCmd

            'Initializes the adapter for the command
            DBAdapter = New SqlDataAdapter(strSQLCmd, DBConn)

            'Fills the datagridview with the dataset
            DBAdapter.Fill(myDataset, "Owners")

            'Adds the fill to the datasource
            dgvVehicles.DataSource = myDataset.Tables("Owners")
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnLast_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- last button. It takes the user to the last record.                                       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '- DBAdapter - Creates the database adapter
    '- DBCommand - Creates the database sql command
    '- DBConn - Creates the sql connection for the database
    '- myDataset - Creates the data set
    '- strSQLCmd - Creates the string command
    '------------------------------------------------------------
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Initializes variables based on sql requirements
        Dim DBConn As SqlConnection
        Dim strSQLCmd As String
        Dim DBCommand As New SqlCommand
        Dim myDataset As New DataSet
        Dim DBAdapter As New SqlDataAdapter

        'Creates the connection and opens it
        DBConn = New SqlConnection(strCONNECTION)
        DBConn.Open()

        ''Initlializes cmd to take in a sql command to execute
        Dim cmd As SqlCommand = New SqlCommand("", DBConn)
        cmd.CommandType = CommandType.Text

        'Checks if the record is at the last possible record
        If txtIDnumber.Text = intMaxRecord Then
            MsgBox("You are already at the last ID number")
        Else
            'Sets the current record to the max record
            intRecordOwner = intMaxRecord
            txtIDnumber.Text = intMaxRecord

            'Creates the connection and opens it
            DBConn = New SqlConnection(strCONNECTION)
            DBConn.Open()

            'Initlializes cmd to take in a sql command to execute
            cmd = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Query to takes the Make, Model, Color, ModelYear, and VIN based on the OwnerID
            strSQLCmd = "SELECT Make, Model, Color, ModelYear, VIN FROM Vehicles WHERE OwnerID = " & intRecordOwner

            'Sets the command to the database command
            DBCommand.CommandText = strSQLCmd

            'Initializes the adapter for the command
            DBAdapter = New SqlDataAdapter(strSQLCmd, DBConn)

            'Fills the datagridview with the dataset
            DBAdapter.Fill(myDataset, "Owners")

            'Adds the fill to the datasource
            dgvVehicles.DataSource = myDataset.Tables("Owners")
        End If
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnAdd_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- add button. This button sets it up to where a user can enter
    '– in data to add it to the record.
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Sets the action as an Add function
        strActions = "Add"

        'Setting false to various buttons
        btnFirst.Enabled = False
        btnPrevious.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
        btnAdd.Visible = False
        btnDelete.Visible = False
        btnUpdate.Visible = False

        'Setting true and enabling textboxes to enter data
        btnSave.Visible = True
        btnCancel.Visible = True
        txtFirstName.Enabled = True
        txtFirstName.Text = ""
        txtLastName.Enabled = True
        txtLastName.Text = ""
        txtAddress.Enabled = True
        txtAddress.Text = ""
        txtCity.Enabled = True
        txtCity.Text = ""
        txtState.Enabled = True
        txtState.Text = ""
        txtZipCode.Enabled = True
        txtZipCode.Text = ""

        'Sets the record 1 higher than the Max ID
        intRecordOwner = ReturnMaxID()
        intRecordOwner += 1
        txtIDnumber.Text = intRecordOwner
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnUpdate_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- update button. This button sets it up to where a user can
    '– update a row of data in the table.
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Sets the action as an Add function
        strActions = "Update"

        'Setting false to various buttons
        btnFirst.Enabled = False
        btnPrevious.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
        btnAdd.Visible = False
        btnDelete.Visible = False
        btnUpdate.Visible = False

        'Setting true and enabling textboxes to enter data
        btnSave.Visible = True
        btnCancel.Visible = True
        txtFirstName.Enabled = True
        txtLastName.Enabled = True
        txtAddress.Enabled = True
        txtCity.Enabled = True
        txtState.Enabled = True
        txtZipCode.Enabled = True
    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnDelete_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- delete button. This button sets it up to where a user can remove
    '– a row of data from the table.
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Sets the action as an Add function
        strActions = "Delete"

        'Setting true and false to various buttons
        btnFirst.Enabled = False
        btnPrevious.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
        btnAdd.Visible = False
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        btnCancel.Visible = True

    End Sub

    '------------------------------------------------------------
    '-                Subprogram Name: btnSave_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- save button. The user's current info will be saved based
    '– on if the user pressed Add, UPDATE, or DELETE
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '------------------------------------------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Checks if any textbox is empty
        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtAddress.Text = "" Or txtCity.Text = "" Or txtState.Text = "" Or txtZipCode.Text = "" Then
            MsgBox("Fill in all textboxes before saving")
        ElseIf strActions = "Add" Then
            'Initlializes cmd to take in a sql command to execute
            Dim cmd As SqlCommand = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to INSERT INTO the text from the textboxes and adds another row with the info the database table
            cmd.CommandText = "INSERT INTO Owners(TUID, FirstName, LastName, StreetAddress, City, State, ZipCode) VALUES('" & txtIDnumber.Text & "' , '" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" & txtAddress.Text & "', '" & txtCity.Text & "', '" & txtState.Text & "', '" & txtZipCode.Text & "')"
            cmd.ExecuteScalar()

            'Sets various buttons to true
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            btnAdd.Visible = True
            btnDelete.Visible = True
            btnUpdate.Visible = True

            'Sets various buttons and textboxes to false
            btnSave.Visible = False
            btnCancel.Visible = False
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtAddress.Enabled = False
            txtCity.Enabled = False
            txtState.Enabled = False
            txtZipCode.Enabled = False

            'Adds 1 to the current record number
            intRecordOwner += 1
            intRecordOwner = txtIDnumber.Text
            intMaxRecord += 1

            'Initlializes cmd to take in a sql command to execute
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Resets Action
            strActions = ""
        ElseIf strActions = "Delete" Then
            'Initlializes cmd to take in a sql command to execute
            Dim cmd As SqlCommand = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to DELETE a record from the table based on the record number
            cmd.CommandText = "DELETE FROM Owners WHERE TUID = " & intRecordOwner
            cmd.ExecuteScalar()
            MsgBox("Entry deleted")

            'Sets various buttons to true
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            btnAdd.Visible = True
            btnDelete.Visible = True
            btnUpdate.Visible = True

            'Sets various buttons and textboxes to false
            btnSave.Visible = False
            btnCancel.Visible = False
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtAddress.Enabled = False
            txtCity.Enabled = False
            txtState.Enabled = False
            txtZipCode.Enabled = False

            'Removes 1 from the current record number
            intRecordOwner -= 1
            txtIDnumber.Text = intRecordOwner
            intMaxRecord -= 1

            'Initlializes cmd to take in a sql command to execute
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Resets Action
            strActions = ""
        ElseIf strActions = "Update" Then
            'Initlializes cmd to take in a sql command to execute
            Dim cmd As SqlCommand = New SqlCommand("", DBConn)
            cmd.CommandType = CommandType.Text

            'Query to UPDATE a record from the table
            cmd.CommandText = "UPDATE Owners SET FirstName = '" & txtFirstName.Text & "', LastName = '" & txtLastName.Text & "', StreetAddress = '" & txtAddress.Text & "', City = '" & txtCity.Text & "', State = '" & txtState.Text & "', ZipCode = '" & txtZipCode.Text & "' WHERE TUID = " & intRecordOwner
            cmd.ExecuteScalar()

            'Sets various buttons to true
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            btnAdd.Visible = True
            btnDelete.Visible = True
            btnUpdate.Visible = True

            'Sets various buttons and textboxes to false
            btnSave.Visible = False
            btnCancel.Visible = False
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtAddress.Enabled = False
            txtCity.Enabled = False
            txtState.Enabled = False
            txtZipCode.Enabled = False

            'Initlializes cmd to take in a sql command to execute
            cmd.CommandType = CommandType.Text

            'Query to read in the first name and set it as the textbox
            cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
            txtFirstName.Text = cmd.ExecuteScalar()

            'Query to read in the last name and set it as the textbox
            cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
            txtLastName.Text = cmd.ExecuteScalar()

            'Query to read in the street address and set it as the textbox
            cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
            txtAddress.Text = cmd.ExecuteScalar()

            'Query to read in the city and set it as the textbox
            cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
            txtCity.Text = cmd.ExecuteScalar()

            'Query to read in the state and set it as the textbox
            cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
            txtState.Text = cmd.ExecuteScalar()

            'Query to read in the zip code and set it as the textbox
            cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
            txtZipCode.Text = cmd.ExecuteScalar()

            'Resets Action
            strActions = ""
        Else
            MsgBox("Unknown Function")
        End If
    End Sub


    '------------------------------------------------------------
    '-                Subprogram Name: btnCancel_Click            -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   -
    '- cancel button. The process will be cancelled.                                       –
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '------------------------------------------------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Sets various buttons to true
        btnFirst.Enabled = True
        btnPrevious.Enabled = True
        btnNext.Enabled = True
        btnLast.Enabled = True
        btnAdd.Visible = True
        btnDelete.Visible = True
        btnUpdate.Visible = True

        'Sets various buttons to false
        btnSave.Visible = False
        btnCancel.Visible = False
        txtFirstName.Enabled = False
        txtLastName.Enabled = False
        txtAddress.Enabled = False
        txtCity.Enabled = False
        txtState.Enabled = False
        txtZipCode.Enabled = False

        'Sets the record as 1 to go back to the original record
        intRecordOwner = 1
        txtIDnumber.Text = intRecordOwner

        'Initlializes cmd to take in a sql command to execute
        Dim cmd As SqlCommand = New SqlCommand("", DBConn)
        cmd.CommandType = CommandType.Text

        'Query to read in the first name and set it as the textbox
        cmd.CommandText = "SELECT FirstName FROM Owners WHERE TUID = " & intRecordOwner
        txtFirstName.Text = cmd.ExecuteScalar()

        'Query to read in the last name and set it as the textbox
        cmd.CommandText = "SELECT LastName FROM Owners WHERE TUID = " & intRecordOwner
        txtLastName.Text = cmd.ExecuteScalar()

        'Query to read in the street address and set it as the textbox
        cmd.CommandText = "SELECT StreetAddress FROM Owners WHERE TUID = " & intRecordOwner
        txtAddress.Text = cmd.ExecuteScalar()

        'Query to read in the city and set it as the textbox
        cmd.CommandText = "SELECT City FROM Owners WHERE TUID = " & intRecordOwner
        txtCity.Text = cmd.ExecuteScalar()

        'Query to read in the state and set it as the textbox
        cmd.CommandText = "SELECT State FROM Owners WHERE TUID = " & intRecordOwner
        txtState.Text = cmd.ExecuteScalar()

        'Query to read in the zip code and set it as the textbox
        cmd.CommandText = "SELECT ZipCode FROM Owners WHERE TUID = " & intRecordOwner
        txtZipCode.Text = cmd.ExecuteScalar()
    End Sub

    '------------------------------------------------------------
    '-                Function Name: ReturnMaxID()           -
    '------------------------------------------------------------
    '-                Written By: Austin Rippee                     -
    '-                Written On: April 3rd, 2022         -
    '------------------------------------------------------------
    '- Function Purpose:                                      -
    '-                                                          -
    '- This function is called when a user wants to get the max
    '– amount of records to get the highest TUID of owners.
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmd - Takes in query commands to execute
    '- DBConn - Creates the sql connection for the database
    '- intMaxValue - Int value to store the max TUID value of the owners table
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- Integer – telling how many records were found            -
    '------------------------------------------------------------

    Public Function ReturnMaxID() As Integer
        'Initializes the database connection
        Dim DBConn As SqlConnection

        'Creates the connection and opens it
        DBConn = New SqlConnection(strCONNECTION)
        DBConn.Open()

        'Initlializes cmd to take in a sql command to execute
        Dim cmd As SqlCommand = New SqlCommand("", DBConn)
        cmd.CommandType = CommandType.Text

        'Query to get the max TUID number and set it as the max value
        cmd.CommandText = "SELECT MAX(TUID) FROM Owners"
        Dim intMaxValue As Integer = cmd.ExecuteScalar()

        Return intMaxValue
    End Function
End Class
