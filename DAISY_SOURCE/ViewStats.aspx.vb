Public Class WebForm10

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim a As String

        If Page.IsPostBack() Then

            '' Response.Write("Postback" + TimeOfDay)

        End If

    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.CommandTimeout = 0 '' WAITS INDEFINATELY
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Private Sub SqlDataSource2_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        e.Command.CommandTimeout = 0 '' WAITS INDEFINATELY
    End Sub

    Private Sub SqlDataSource3_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource3.Selecting
        e.Command.CommandTimeout = 0 '' WAITS INDEFINATELY
    End Sub

    Private Sub SqlDataSource4_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource4.Selecting
        e.Command.CommandTimeout = 0 '' WAITS INDEFINATELY
    End Sub

    Private Sub DownloadData_Click(sender As Object, e As EventArgs) Handles DownloadData.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' This is Server Side Code that downloads the data when clicked ''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '' This is a desparate attempt on validation as the CustomValidation Component does not work


        '' Depending on the password entered we download someting or everything!

        Dim DaConnection As New System.Data.SqlClient.SqlConnection
        DaConnection.ConnectionString = ConfigurationManager.ConnectionStrings("DAISYConnectionString1").ConnectionString.ToString()

        Using DaConnection

            Dim SqlSTring = ""
            If (CSVPassword.Text = "Daisy10") Then
                SqlSTring = "Select * FROM [DAISY].[dbo].[DownloadDataCurrentYear] order  by calldate asc"
            ElseIf (CSVPassword.Text = "Daisy100")
                SqlSTring = "Select * FROM [DAISY].[dbo].[DownloadData] order  by calldate asc"
            Else
                Response.End()
            End If

            Dim DaCommand As New System.Data.SqlClient.SqlCommand(SqlSTring, DaConnection)
            DaConnection.Open()

            Dim DaSqlDataReader As SqlClient.SqlDataReader = DaCommand.ExecuteReader()

            If DaSqlDataReader.HasRows Then


                Dim sb As New StringBuilder
                Dim i As Integer = 0

                For i = 0 To DaSqlDataReader.FieldCount - 1
                    sb.Append(DaSqlDataReader.GetName(i).ToString() & ",")
                Next
                sb.AppendLine("")



                Do While DaSqlDataReader.Read()

                    For i = 0 To DaSqlDataReader.FieldCount - 1
                        sb.Append(DaSqlDataReader.GetValue(i).ToString() & ",")
                    Next
                    sb.AppendLine("")
                Loop


                '''''''''''''''''''''''''''''''''''''''
                ' Loop the Datareader to get the Data '
                '''''''''''''''''''''''''''''''''''''''
                Dim bytes As Byte() = Encoding.ASCII.GetBytes(sb.ToString())

                Response.Clear()
                Response.ContentType = "text/csv"
                Response.AddHeader("Content-Length", bytes.Length.ToString())

                If (CSVPassword.Text = "Daisy10") Then
                    Response.AddHeader("Content-disposition", "attachment; filename='CallData" & Year(Now) & ".csv'")
                ElseIf (CSVPassword.Text = "Daisy100")
                    Response.AddHeader("Content-disposition", "attachment; filename='CallDataAll.csv'")
                End If

                Response.BinaryWrite(bytes)
                Response.Flush()

                CSVPassword.Text = ""

                Response.End()


            Else





            End If



        End Using





    End Sub

    Private Sub GridView1_PreRender(sender As Object, e As EventArgs) Handles GridView1.PreRender


        'Dim getRow As GridViewRow = GridView1.Rows(GridView1.Rows.Count - 1)
        'getRow.Cells.Item(0). .Style = " font-weight:bold" '' BackColor = Drawing.Color.Red


    End Sub

    'Protected Sub Password_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CustomValidator1.ServerValidate

    '    If args.Value = "Daisy10" Then
    '        args.IsValid = True
    '    Else
    '        args.IsValid = False
    '    End If


    '    '' args.IsValid = (args.Value.Length >= 8)


    'End Sub
End Class