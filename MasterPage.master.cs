using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        this.MasterPageFile = "MasterPage.master";
        /*if (Request.QueryString["color"] == "green")
        {
            this.MasterPageFile = "MasterGreen.master";
        }
        this.Title = Master.MyTitle;*/
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
