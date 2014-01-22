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
using System.Data.SqlTypes;

public partial class MemberPages_SellingsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

        string connStr = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        connection.Open();

        SqlCommand command = new SqlCommand("INSERT INTO UsersSellings (UserId, Title, ImagePath, Description, Price, DateCreated, DateSelled) VALUES" + 
                                            "( @UserId, @Path, @Title, @Description, @Price, @DateCreated, @DateSelled )", connection);
        
        command.Parameters.AddWithValue("@UserId", (string)Session["Uid"]);
        command.Parameters.AddWithValue("@Title", SellingTitle.Text);
        command.Parameters.AddWithValue("@Price", Price.Text);
        command.Parameters.AddWithValue("@Path", PicturePath );
        command.Parameters.AddWithValue("@Description", Description.Text);
        command.Parameters.AddWithValue("@DateCreated", DateTime.Now);
        command.Parameters.AddWithValue("@DateSelled", SqlDateTime.MinValue);
        
        command.ExecuteNonQuery();
        connection.Close();
        btnClear_Click(sender, e);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        SellingTitle.Text = "";
        Price.Text= "";
        Description.Text = "";
        
        if (fileuploadImage.HasFile)
        {
            fileuploadImage = new FileUpload();
        }// if
    }
}