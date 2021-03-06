﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        this.MasterPageFile = "MasterPage.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bLogged = HttpContext.Current.User.Identity.IsAuthenticated;

        if (!bLogged)
            SiteMapDataSource1.SiteMapProvider = "GuestXmlSiteMapProvider";
    }
}
