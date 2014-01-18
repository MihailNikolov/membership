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

public partial class MemberPages_ChangePassword : System.Web.UI.Page
{
    static string prevPage = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            prevPage = Request.UrlReferrer.ToString();
        }
    }
    protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
    {
        Response.Redirect(prevPage);
    }
}
