using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberPages_DeactivateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void YesButton_OnClick(object sender, EventArgs args)
    {
        Membership.DeleteUser(User.Identity.Name);
        FormsAuthentication.SignOut();
        Response.Redirect("~\\Default.aspx");
    }

    public void CancelButton_OnClick(object sender, EventArgs args)
    {
        Response.Redirect("default.aspx");
    }
}