using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarevFilms
{
    public partial class AddFilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar.SelectedDate = Calendar.TodaysDate;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
                //getting length of uploaded file
                int length = fileuploadImage.PostedFile.ContentLength;
                //create a byte array to store the binary image data
                byte[] imgbyte = new byte[length];
                //store the currently selected file in memeory
                HttpPostedFile img = fileuploadImage.PostedFile;
                //set the binary data
                img.InputStream.Read(imgbyte, 0, length);
                //use the web.config to store the connection string
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                connection.Open();
                // Записване данните за филма
                SqlCommand cmdInsertFilm = new SqlCommand("INSERT INTO FILMS VALUES(@Name, @Year, @ReleaseDate, @Creator, @Image, @Description); select SCOPE_IDENTITY() FROM FILMS;", connection);
                cmdInsertFilm.Parameters.Add("@Name", SqlDbType.VarChar).Value = FilmName.Text;
                cmdInsertFilm.Parameters.Add("@Year", SqlDbType.Int).Value = Calendar.SelectedDate.Year;
                cmdInsertFilm.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = Calendar.SelectedDate;
                cmdInsertFilm.Parameters.Add("@Creator", SqlDbType.VarChar).Value = Creator.Text;
                cmdInsertFilm.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description.Text;
                if( fileuploadImage.HasFile )
                    cmdInsertFilm.Parameters.Add("@Image", SqlDbType.Image).Value = imgbyte;
                else
                    cmdInsertFilm.Parameters.Add("@Image", SqlDbType.Image).Value = DBNull.Value;

                var nCount = cmdInsertFilm.ExecuteScalar();
                String[] strActors = Actors.Text.Split(';');
                SqlCommand cmdInsertStars = null;
                foreach (String strActor in strActors)
                {
                    cmdInsertStars = new SqlCommand("INSERT INTO FILM_STARS VALUES(@FILM_ID,@FIRSTNAME,@LASTNAME)", connection);
                    cmdInsertStars.Parameters.Add("@FILM_ID", SqlDbType.Int).Value = nCount;
                    String[] Names = strActor.Split(' ');
                    cmdInsertStars.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = Names[0];
                    cmdInsertStars.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = Names[1];
                    cmdInsertStars.ExecuteNonQuery();
                }// foreach
                
                connection.Close();
                btnClear_Click(sender, e);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            FilmName.Text = "";
            Creator.Text = "";
            Calendar.VisibleDate = Calendar.TodaysDate;
            Calendar.SelectedDate = Calendar.TodaysDate;
            Actors.Text = "";
            Description.Text = "";
            if (fileuploadImage.HasFile)
            {
                fileuploadImage = new FileUpload();
            }// if
        }
    }
}