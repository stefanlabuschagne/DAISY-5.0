Public Class WebForm9
    Inherits System.Web.UI.Page

    '' This is an attempt to speed up the Query.
    Public daSelectCommand As String = "SELECT dbo.Callers.*, dbo.Calls.CallDate, dbo.Calls.Callid FROM dbo.Callers INNER JOIN dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        '' This defaults to the basic Datasource for the Gridview.
        If IsPostBack Then

            '' We will filter on the event that caused the POSTBACK!
        Else

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '' SL - 27 May 2018 
            '' You gotta filter every time you load the page 
            '' Because The SQl Command is not Static on the server 
            ''''''''''''''''''''''''''''''''''''''''
            Set_DataGrid_Filter(daSelectCommand)

        End If


        Firstname.Focus()

    End Sub

    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Submit.Click

        '''''''''''''''''''''''''''''''''''''''''
        '' Search for new Callers in the grid. ''
        '' Die Blouk click op "Search Caller"  ''
        '''''''''''''''''''''''''''''''''''''''''

        GridView1.SelectedIndex = -1

        '' Filter on the 
        Set_DataGrid_Filter(daSelectCommand)

        ' Display the company name from the selected row.
        ' In this example, the third column (index 2) contains
        ' the company name.
        MessageLabel.Text = ""

        '' Let the ouk Edit IT!
        btnEditCall.Enabled = False


    End Sub

    Protected Sub Set_DataGrid_Filter(daSelectCommand As String)

        '''''''''''''''''''''''''''''''''''''''
        ' Query The callers on the datasource '
        '''''''''''''''''''''''''''''''''''''''
        '' Dim DaQuery As String
        Dim DaWhere As String = ""

        '' Check for stuff and add it on for the query.
        If Firstname.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Name like '" & Firstname.Text & "%'"
        End If

        If Surname.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Surname like '" & Surname.Text & "%'"
        End If

        If Province.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Province = '" & Province.Text & "'"
        End If

        If Telephone.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Telephone1 like '" & Telephone.Text & "%'"
        End If

        ''
        If DaWhere.Length > 0 Then
            '' Filter on the Criteria Specified
            DaWhere = " Where " & DaWhere.Substring(5)
        Else
            '' We Filter on Nothing so Return NOTHING!
            DaWhere = " Where dbo.Callers.callerid is null "
        End If

        SqlDataSource1.SelectCommand = daSelectCommand & " " & DaWhere

        '' THIS TRIGGERS A SELECT
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)

        '' Binds the grid to the Data!
        GridView1.DataBind()

    End Sub




    Private Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs) Handles GridView1.PageIndexChanged

        ' SO WE CLICKED TO SEE A NEW PAGE '
        '''''''''''''''''''''''''''''''''''
        Dim a As String = ""


        GridView1.SelectedIndex = -1

        '' Filter on the 
        Set_DataGrid_Filter(daSelectCommand)

        ' Display the company name from the selected row.
        ' In this example, the third column (index 2) contains
        ' the company name.
        MessageLabel.Text = ""

        '' Let the ouk Edit IT!
        btnEditCall.Enabled = False


    End Sub


    Protected Sub CallersGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '  This gets fired when you click on the grid and select a Line! '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ' Get the currently selected row using the SelectedRow property.
        Dim row As GridViewRow = GridView1.SelectedRow

        ' Display the company name from the selected row.
        ' In this example, the third column (index 2) contains
        ' the company name.
        MessageLabel.Text = "You selected: <B>" & row.Cells(1).Text & " " & row.Cells(2).Text & "</b> "

        '' Let the ouk Edit IT!
        btnEditCall.Enabled = True

    End Sub

    Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub


    Protected Sub Telephone_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Telephone.TextChanged

    End Sub

    Protected Sub Firstname_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Firstname.TextChanged

    End Sub

    Protected Sub btnEditCall_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditCall.Click


        '' Write code here to get the callers data 
        '' and load it into the edit screen !!!!

        btnEditCall.Enabled = False

        ' Get the currently selected row using the SelectedRow property.
        Dim row As GridViewRow = GridView1.SelectedRow

        ' Display the company name from the selected row.
        ' In this example, the third column (index 2) contains
        ' the company name.
        ''        MessageLabel.Text = "You selected " & row.Cells(0).Text & " " & row.Cells(3).Text & "."


        '' WE NEED TO DETERMIN TO SHOW A DEDICATED LINES SCREEN OR THE NORMAL SCREEN ''
        '' 
        '' Look in the database 


        Dim DaConnection As New System.Data.SqlClient.SqlConnection

        '' Get the string of the DAISYConnectionString1 '' 
        DaConnection.ConnectionString = ConfigurationManager.ConnectionStrings("DAISYConnectionString1").ConnectionString.ToString()

        '' The CALLs DLLocation field will NOT be null if its a dedicated line
        Dim daDLLocation As String = ""

        Using DaConnection

            Dim DaCommand As New System.Data.SqlClient.SqlCommand("Select [DLLocation] FROM CALLERS where callerid = " + row.Cells(9).Text, DaConnection)
            DaConnection.Open()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Get the next CallerID (if we dont have it already!) '
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim DaReader As System.Data.SqlClient.SqlDataReader = DaCommand.ExecuteReader()
            If DaReader.HasRows Then
                DaReader.Read()

                daDLLocation = ""
                Try
                    '' This will get the location o d the caller wich is Null if it is NOT from a dedicated line
                    daDLLocation = DaReader.GetString(0).ToString()
                Catch ex As Exception
                    daDLLocation = "Null"
                End Try

            End If

            DaReader.Close()

        End Using

        If daDLLocation <> "Null" Then
            Server.Transfer("CreateCaseDedicatedLines.aspx?Action=Edit&CallerID=" & row.Cells(9).Text & "&Callid=" & row.Cells(10).Text & "", False)
        Else
            Server.Transfer("CreateCase.aspx?Action=Edit&CallerID=" & row.Cells(9).Text & "&Callid=" & row.Cells(10).Text & "", False)
        End If

    End Sub



    Private Sub GridView1_Sorted(sender As Object, e As EventArgs) Handles GridView1.Sorted

    End Sub

    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting

        '' Filter on the 
        Set_DataGrid_Filter(daSelectCommand)

    End Sub
End Class