Public Class WebForm8
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then


        End If

        Firstname.Focus()

    End Sub

    Protected Sub SubmitQuery_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitQuery.Click


        '' Redirect to the window

        lblFeedback.Text = ""

        '' HiddenField1.Value = StartDate.SelectedDate

        Server.Transfer("Webreport.aspx", True)

        '' Response.Redirect("Webreport.aspx")


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CalendarStartDate.Visible = Not (CalendarStartDate.Visible)
    End Sub

    Protected Sub CalendarStartDate_SelectionChanged(sender As Object, e As EventArgs) Handles CalendarStartDate.SelectionChanged
        StartDate.Text = CalendarStartDate.SelectedDate.ToString().Substring(0, 10).Replace("/", "-")
        CalendarStartDate.Visible = False
        EndDate.Focus()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CalendarEndDate.Visible = Not (CalendarEndDate.Visible)
    End Sub

    Protected Sub CalendarEndDate_SelectionChanged(sender As Object, e As EventArgs) Handles CalendarEndDate.SelectionChanged
        EndDate.Text = CalendarEndDate.SelectedDate.ToString().Substring(0, 10).Replace("/", "-")
        CalendarEndDate.Visible = False
        EndDate.Focus()
    End Sub
End Class