using System;
using System.Web.UI;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class SiteMaster : MasterPage
    {
        public bool IsAdmin;
        public AdministratorRow currentAdmin;
        public StaffRow currentStaff;

        protected void Page_Load(object sender, EventArgs e)
        {
            MenuMain.Items.Clear();

            // Logged in user is admin
            currentAdmin = Business.Business.Instance.GetAdmin(this.Page.User.Identity.Name);
            if (currentAdmin != null)
            {
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Administrator", "", "", "~/Administrator"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Staff", "", "", "~/Staff"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Owner", "", "", "~/Owner"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Room", "", "", "~/Room"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Tenant", "", "", "~/Tenant"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Booking", "", "", "~/Booking"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Change Password", "", "", "~/ChangePassword"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Logout", "", "", "~/Logout"));

                IsAdmin = true;
            }

            // Logged in user is Staff
            currentStaff = Business.Business.Instance.GetStaff(this.Page.User.Identity.Name);
            if (currentStaff != null)
            {
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Owner", "", "", "~/Owner"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Room", "", "", "~/Room"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Tenant", "", "", "~/Tenant"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Booking", "", "", "~/Booking"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Change Password", "", "", "~/ChangePassword"));
                MenuMain.Items.Add(new System.Web.UI.WebControls.MenuItem("Logout", "", "", "~/Logout"));

                IsAdmin = false;
            }
        }
    }
}