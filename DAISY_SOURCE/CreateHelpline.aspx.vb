Public Class CreateHelpline
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (IsPostBack) Then
            NewHelpline.Focus()
        End If

        NewHelpline.Focus()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        ''''''''''''''''''''''''''''''''''''''''
        ' Insert the stuff into the datasource '
        ' Using ADO.NET                        '
        '''''''''''''''''''''''''''''''''''''''

        Dim DaConnection As New System.Data.SqlClient.SqlConnection
        DaConnection.ConnectionString = ConfigurationManager.ConnectionStrings("DAISYConnectionString1").ConnectionString.ToString()

        Using DaConnection

            Dim DaCommand As New System.Data.SqlClient.SqlCommand("Select max(CALLERID)+1 FROM CALLERS", DaConnection)
            DaConnection.Open()

            Dim Retval = 0
            Try

                ''''''''''''''''''''''''''''''''''''''
                ' Insert The Stuff into the Database '
                ''''''''''''''''''''''''''''''''''''''
                DaCommand.CommandText = "Insert into HelplineS (Helpline) values ('" & NewHelpline.Text & "')"
                Retval = DaCommand.ExecuteNonQuery()

            Catch

                LblFeedback.Text = "Helpline Submission FAILED.(Possible Duplicate)"

            Finally

                If Retval = 1 Then

                    LblFeedback.Text = "Helpline '" & NewHelpline.Text & "' Added."

                End If

            End Try

            NewHelpline.Text = ""

        End Using
    End Sub
End Class