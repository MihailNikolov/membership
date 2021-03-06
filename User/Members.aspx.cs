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
using System.Data.SqlTypes;

public partial class MemberPages_Members : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        MembershipUser CurrentUser = Membership.GetUser(User.Identity.Name);
        Session["Uid"] = CurrentUser.ProviderUserKey.ToString();
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

    public String IsBought(object DateSelled, object BuyerEmail)
    {
        DateTime dt = (DateTime)DateSelled;
        string Bought = (dt == SqlDateTime.MinValue ? "" : "<br>This item is bought by<br>" + (string)BuyerEmail);
        return Bought;
    }
}
