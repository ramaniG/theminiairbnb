using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheRooms
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (oldpassword.Text.Length == 0 || newPassword.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('Old and New Password must not be empty.');</script>");
            }
            else
            {
                SiteMaster a = (SiteMaster)this.Master;

                if (a.IsAdmin)
                {
                    if (Business.Business.Instance.ChangeAdminPassword(a.currentAdmin.ID, oldpassword.Text, newPassword.Text))
                    {
                        Response.Write("<script type='text/javascript'>alert('Change Password Successful.');</script>");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('Change Password Failed.');</script>");
                    }
                }
                else
                {
                    if (Business.Business.Instance.ChangeStaffPassword(a.currentStaff.ID, oldpassword.Text, newPassword.Text))
                    {
                        Response.Write("<script type='text/javascript'>alert('Change Password Successful.');</script>");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('Change Password Failed.');</script>");
                    }
                }
            }
        }
    }
}