using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SellingItem
/// </summary>
public class SellingItem
{
    int Id = 0;
    string Title = "";
    decimal Price = 0;
    string PicturePath = "";
    string Description = "";
    DateTime Created = DateTime.Now;
    DateTime Selled = DateTime.MinValue;

    public SellingItem()
	{
      
	}
}