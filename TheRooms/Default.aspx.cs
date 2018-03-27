using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            SiteMaster a = (SiteMaster)this.Master;

            if (a.IsAdmin)
            {
                Response.Redirect("~/Administrator");
            }
            else
            {
                Response.Redirect("~/Booking");
            }
        }
    }
}