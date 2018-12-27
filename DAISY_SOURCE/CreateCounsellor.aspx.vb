Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (IsPostBack) Then
            NewCounsellor.Focus()
        End If

        NewCounsellor.Focus()

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
                DaCommand.CommandText = "Insert into COUNSELLORS (COUNSELLOR) values ('" & NewCounsellor.Text & "')"
                Retval = DaCommand.ExecuteNonQuery()

            Catch

                LblFeedback.Text = "COUNSELLOR Submitted FAILED."

            Finally

                If Retval = 1 Then

                    LblFeedback.Text = "COUNSELLOR Submitted OK."

                End If

            End Try

            NewCounsellor.Text = ""

        End Using
    End Sub
End Class