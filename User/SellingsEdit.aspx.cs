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

                    int Id = (int)Session["SellId"];
                    command.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        if (reader.Read())
                        {
                            SellingTitle.Text = reader.GetString(3);
                            Description.Text = reader.GetString(4);
                            Price.Text = reader.GetDecimal(5).ToString();
                            Session["PictureGuid"] = reader.GetString(2);
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
        string PicturePath = "";
        if (fileuploadImage.HasFile)
        {
            Guid g;
            g = Guid.NewGuid();
            
            int length = fileuploadImage.PostedFile.ContentLength;
            byte[] imgbyte = new byte[length];
            HttpPostedFile img = fileuploadImage.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);

            PicturePath = g.ToString();

            FileStream file = File.Create(Server.MapPath("~/UserSellings/") + PicturePath);
            file.Write(imgbyte, 0, length);
        }

        string oldPic = (string)Session["PictureGuid"];

        if (oldPic != null && oldPic.Length > 0)
            File.Delete(Server.MapPath("~/UserSellings/") + oldPic);

        string connStr = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        connection.Open();

        SqlCommand command = new SqlCommand("UPDATE UsersSellings SET [ImagePath] = @Path ,[Title]= @Title, [Description]= @Description, [Price] = @Price WHERE ID = @Id", connection);

        command.Parameters.AddWithValue("@Title", SellingTitle.Text);
        command.Parameters.AddWithValue("@Price", Price.Text);
        command.Parameters.AddWithValue("@Path", PicturePath );
        command.Parameters.AddWithValue("@Description", Description.Text);
        
        int Id = (int)Session["Id"];
        command.Parameters.AddWithValue("@Id", Id);

        command.ExecuteNonQuery();
        connection.Close();
    }
}