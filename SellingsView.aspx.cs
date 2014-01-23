using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Web.Security;
using System.Net;
using System.Data.SqlTypes;

public partial class MemberPages_SellingsView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        string connStr = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
        SqlConnection con = new SqlConnection(connStr);
        con.Open();

        using (con)
        {
            try
            {

                SqlCommand command = new SqlCommand("SELECT [UserId], [ImagePath] ,[Title], [Description], [Price], [DateSelled], [BuyerEmail] FROM [UsersSellings] Where [Id] = @Id", con);

                command.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        Guid uid = reader.GetGuid(0);
                        Guid uidpic = reader.GetGuid(1);
                        ImagePic.ImageUrl = "~/UserSellings/" + (uidpic == Guid.Empty ? "DefaultNoImage" : uidpic.ToString());

                        SellingTitle.Text = reader.GetString(2);
                        Description.Text = reader.GetString(3);

                        double price = reader.GetDouble(4);
                        Price.Text = price.ToString();
                        DateTime dtBoughtDate = reader.GetDateTime(5);
                        BoughtEmail.Text = "This item is bought by " + reader.GetString(6);

                        if (Session["Uid"] != null)
                        {
                            // Дали е наш
                            string sUid = (string)Session["Uid"];
                            if (sUid == uid.ToString())
                            {
                                if (dtBoughtDate == SqlDateTime.MinValue)
                                    Edit.Visible = true;
                                else
                                    BoughtEmail.Visible = true;
                            }
                            else
                                Buy.Visible = true;

                        }
                    }
                }
            }
            finally
            {
            }
        }
    }

    protected void Buy_Click(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        connection.Open();

        SqlCommand command = new SqlCommand("UPDATE UsersSellings SET [DateSelled]= @Date, [BuyerEmail] = @BuyerEmail WHERE ID = @Id", connection);
        
        MembershipUser Buyer = Membership.GetUser(new Guid((String)Session["uid"]));
        string userBuyerEmail = Buyer.Email.ToString(); 

        command.Parameters.AddWithValue("@Date", DateTime.Now);
        command.Parameters.AddWithValue("@BuyerEmail", userBuyerEmail);

        command.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);

        command.ExecuteNonQuery();

        connection.Close();

        Response.Redirect("~/Sellings.aspx");

    }

    protected void Edit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/SellingsEdit.aspx?Id=" + Request.QueryString["Id"]);
    }
}