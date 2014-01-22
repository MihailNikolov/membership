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
    public partial class EditFilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ImageFilm.ImageUrl = "ImgHandler.ashx?ID=" + Session["EDIT_FILM"].ToString();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                    String strSelectStatement = String.Format("SELECT * FROM FILMS WHERE ID= {0}", Session["EDIT_FILM"].ToString());
                    SqlCommand cmd = new SqlCommand(strSelectStatement, con);
                    cmd.CommandType = CommandType.Text;
                    adp.SelectCommand = cmd;
                    adp.Fill(dt);
                    cmd.Dispose();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Films2 curFilm = new Films2();
                        //ID
                        Int32.TryParse(dt.Rows[i]["ID"].ToString(), out curFilm.ID);
                        //Name
                        curFilm.Name = dt.Rows[i]["FILM_NAME"].ToString();
                        //Year
                        Int32.TryParse(dt.Rows[i]["YEAR"].ToString(), out curFilm.Year);
                        //Creator
                        curFilm.Creator = dt.Rows[i]["CREATOR"].ToString();
                        //Date
                        String strDate = dt.Rows[i]["RELEASE_DATE"].ToString();
                        DateTime.TryParse(dt.Rows[i]["RELEASE_DATE"].ToString(), out curFilm.dtDate);
                        //Descriptions 
                        curFilm.Description = dt.Rows[i]["DESCRIPTION"].ToString();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter adp2 = new SqlDataAdapter();
                        try
                        {

                            String strStarsStatement = String.Format("SELECT * FROM FILM_STARS WHERE FILM_ID = {0}", curFilm.ID);
                            SqlCommand cmd2 = new SqlCommand(strStarsStatement, con);
                            cmd2.CommandType = CommandType.Text;
                            adp2.SelectCommand = cmd2;
                            adp2.Fill(dt2);
                            cmd2.Dispose();

                            for (int st = 0; st < dt2.Rows.Count; st++)
                            {
                                curFilm.collStars.Add(String.Format("{0} {1}", dt2.Rows[st]["FIRSTNAME"].ToString(), dt2.Rows[st]["LASTNAME"]));
                            }// for
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + ex.Message.ToString() + "');", true);

                            // Response.Write("Oops!! following error occured: " +ex.Message.ToString());           
                        }
                        finally
                        {
                            dt2.Clear();
                            dt2.Dispose();
                            adp2.Dispose();
                        }


                        FilmName.Text = curFilm.Name;
                        Creator.Text = curFilm.Creator;
                        Calendar.SelectedDate = curFilm.dtDate;
                        Calendar.VisibleDate = curFilm.dtDate;
                        Description.Text = curFilm.Description;
                        Actors.Text = String.Join(";", curFilm.collStars);

                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + ex.Message.ToString() + "');", true);

                    // Response.Write("Oops!! following error occured: " +ex.Message.ToString());           
                }
                finally
                {
                    dt.Clear();
                    dt.Dispose();
                    adp.Dispose();
                }
            }
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

            SqlCommand cmdInsertFilm = null;
            if( fileuploadImage.HasFile )
                cmdInsertFilm = new SqlCommand("UPDATE FILMS SET FILM_NAME = @NAME, YEAR = @YEAR, @ReleaseDate = @ReleaseDate, Creator = @Creator, Description = @Description, Image = @Image WHERE ID = @ID", connection);
            else
                cmdInsertFilm = new SqlCommand("UPDATE FILMS SET FILM_NAME = @NAME, YEAR = @YEAR, @ReleaseDate = @ReleaseDate, Creator = @Creator, Description = @Description WHERE ID = @ID", connection);
            cmdInsertFilm.Parameters.Add("@Name", SqlDbType.VarChar).Value = FilmName.Text;
            cmdInsertFilm.Parameters.Add("@Year", SqlDbType.Int).Value = Calendar.SelectedDate.Year;
            cmdInsertFilm.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = Calendar.SelectedDate;
            cmdInsertFilm.Parameters.Add("@Creator", SqlDbType.VarChar).Value = Creator.Text;
            cmdInsertFilm.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description.Text;
            if (fileuploadImage.HasFile)
                cmdInsertFilm.Parameters.Add("@Image", SqlDbType.Image).Value = imgbyte;
            int nID = -1;
            Int32.TryParse(Session["EDIT_FILM"].ToString(), out nID);
            cmdInsertFilm.Parameters.Add("@ID", SqlDbType.Int).Value = nID;
            cmdInsertFilm.ExecuteNonQuery();
            connection.Close();
        }
    }
}