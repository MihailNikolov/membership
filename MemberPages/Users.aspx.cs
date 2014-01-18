using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberPages_Users : System.Web.UI.Page
{
    int pageSize = 5;
    int totalUsers;
    int totalPages;
    int currentPage = 1;

    public void Page_Load()
    {
        if (!IsPostBack)
        {
            GetUsers();
            GetRoles();
        }
    }
    protected virtual void OnCheckedChanged_Admin(Object sender, EventArgs e)
    {

        for (int i = 0; i < UserGrid.Items.Count; i++)
        {
            DataGridItem item = UserGrid.Items[i];
            if (item.FindControl("Admin") == sender)
            {
                String strUserName = item.Cells[3].Text;

                if (User.Identity.Name == strUserName)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Not allowed to change your administrator settings');", true);
                    CheckBox checkbox = (CheckBox)sender;
                    checkbox.Checked = !checkbox.Checked;
                    return;
                }

                try
                {
                    if (Roles.IsUserInRole(strUserName, "Admin"))
                        Roles.RemoveUserFromRole(strUserName, "Admin");
                    else
                        Roles.AddUserToRole(strUserName, "Admin");
                }
                catch (System.Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + ex.ToString() + "');", true);
                }
                break;
            }
        }

        GetUsers();
        GetRoles();
    }

    protected void ItemsGrid_ItemCommand(object sender, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Deactivate")
        {
            String strUserName = e.Item.Cells[3].Text;

            if (!Roles.IsUserInRole(strUserName, "Admin"))
                Membership.DeleteUser(strUserName);
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Not allowed to remove administrator');", true);
                return;
            }

            GetUsers();
            GetRoles();
        }
    }

    private void GetUsers()
    {
        UsersOnlineLabel.Text = Membership.GetNumberOfUsersOnline().ToString();

        MembershipUserCollection oMembersUserCollection;
        oMembersUserCollection = Membership.GetAllUsers(currentPage - 1, pageSize, out totalUsers);
        UserGrid.DataSource = oMembersUserCollection;
        totalPages = ((totalUsers - 1) / pageSize) + 1;

        // Ensure that we do not navigate past the last page of users.

        if (currentPage > totalPages)
        {
            currentPage = totalPages;
            GetUsers();
            return;
        }

        UserGrid.DataBind();
        CurrentPageLabel.Text = currentPage.ToString();
        TotalPagesLabel.Text = totalPages.ToString();

        foreach (DataGridItem item in UserGrid.Items)
        {
            String strUserName = item.Cells[3].Text;
            CheckBox oCheckBox = (CheckBox)item.FindControl("Admin");
            oCheckBox.Checked = Roles.IsUserInRole(strUserName, "Admin");
        }

        if (currentPage == totalPages)
            NextButton.Visible = false;
        else
            NextButton.Visible = true;

        if (currentPage == 1)
            PreviousButton.Visible = false;
        else
            PreviousButton.Visible = true;

        if (totalUsers <= 0)
            NavigationPanel.Visible = false;
        else
            NavigationPanel.Visible = true;
    }

    private void GetRoles()
    {
        RolesGrid.DataSource = Roles.GetUsersInRole("Admin");
        RolesGrid.DataBind();
    }

    public void NextButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage++;
        GetUsers();
    }

    public void PreviousButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage--;
        GetUsers();
    }
}