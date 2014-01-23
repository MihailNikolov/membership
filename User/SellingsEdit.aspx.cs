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

public partial class MemberPages_SellingsEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            using (con)
            {
                try
                {

                    SqlCommand command = new SqlCommand("SELECT [Id], [ImagePath] ,[Title], [Description], [Price] FROM [UsersSellings] Where [Id] = @Id", con);

                    command.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);

                    SqlDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        if (reader.Read())
                        {
                            ViewState["PictureGuid"] = reader.GetGuid(1);
                            SellingTitle.Text = reader.GetString(2);
                            Description.Text = reader.GetString(3);
                            Price.Text = reader.GetDouble(4).ToString();
                        }
                    }
                }
                finally
                {
                }
            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Guid guid = (Guid)ViewState["PictureGuid"];
        if (guid != Guid.Empty)
            File.Delete(Server.MapPath("~/UserSellings/") + guid.ToString());

        if (fileuploadImage.HasFile)
        {
            if (guid == Guid.Empty)
                guid = Guid.NewGuid();

            int length = fileuploadImage.PostedFile.ContentLength;
            byte[] imgbyte = new byte[length];
            HttpPostedFile img = fileuploadImage.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);

            FileStream file = File.Create(Server.MapPath("~/UserSellings/") + guid.ToString());
            file.Write(imgbyte, 0, length);
        }

        string connStr = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        connection.Open();

        SqlCommand command = new SqlCommand("UPDATE UsersSellings SET [ImagePath] = @Path, [Title]= @Title, [Description]= @Description, [Price] = @Price WHERE ID = @Id", connection);
        
        command.Parameters.AddWithValue("@Path", guid);
        command.Parameters.AddWithValue("@Title", SellingTitle.Text);
        command.Parameters.AddWithValue("@Price", Price.Text);
        command.Parameters.AddWithValue("@Description", Description.Text);

        command.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);

        command.ExecuteNonQuery();
        connection.Close();
    }
}