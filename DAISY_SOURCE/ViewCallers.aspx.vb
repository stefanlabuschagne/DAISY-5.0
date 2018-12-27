Public Class WebForm5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Firstname.Focus()

        If IsPostBack Then
            FilterCallers()
        End If

    End Sub

    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Submit.Click

        FilterCallers()

    End Sub

    Protected Sub FilterCallers()

        '''''''''''''''''''''''''''''''''''''''
        ' Query The callers on the datasource '
        '''''''''''''''''''''''''''''''''''''''
        '' Dim DaQuery As String
        Dim DaWhere As String

        '' This connectionstring is also on the datasource!!
        '' DaQuery = "SELECT dbo.Callers.*, dbo.Calls.CallDate, 'Hello' as [Reasons] FROM dbo.Callers INNER JOIN dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID"
        DaWhere = ""

        '' Check for stuff and add it on for the query.
        If Firstname.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Name like '" & Firstname.Text & "%'"
        End If

        If Surname.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Surname like '" & Surname.Text & "%'"
        End If

        If Race.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Race = '" & Race.Text & "'"
        End If

        If Gender.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Sex = '" & Gender.Text & "'"
        End If

        If Province.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Province = '" & Province.Text & "'"
        End If

        If Age.Text.ToString.Length > 0 Then
            DaWhere = DaWhere & " and Age = '" & Age.Text & "'"
        End If


        If DaWhere.Length > 0 Then
            DaWhere = DaWhere.Substring(5)
        End If

        '' Set the Filter
        SqlDataSource1.FilterExpression = DaWhere

        '' THIS TRIGGERS A SELECT
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)

        '' Binds the grid to the Data!
        GridView1.DataBind()


    End Sub

    Protected Sub Province_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Province.TextChanged

    End Sub

    Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class