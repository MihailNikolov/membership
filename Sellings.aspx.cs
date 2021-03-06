using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class MemberPages_Sellings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (User.Identity.IsAuthenticated)
        {

            MembershipUser CurrentUser = Membership.GetUser(User.Identity.Name);
            Session["Uid"] = CurrentUser.ProviderUserKey.ToString();
        }
    }
    public string ProcessMyDataItem(object myValue)
    {
        Guid str = (Guid)myValue;
        if (str == Guid.Empty)
        {
            return "DefaultNoImage";
        }

        return myValue.ToString();
    }
}
