using System;
using System.Web.UI.WebControls;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            GridView1.DataSource = Business.Business.Instance.GetStaffs();
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length == 0 || txtFirstName.Text.Length == 0 || txtLastName.Text.Length == 0 || txtContact.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('All fields must be filled.');</script>");
            }
            else
            {
                Business.Business.Instance.InsertStaff(txtFirstName.Text, txtLastName.Text, txtEmail.Text, "Password123$", dropGender.SelectedValue, txtContact.Text);
                Response.Write("<script type='text/javascript'>alert('New user is added. Default password is Password123$.');</script>");
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('ID cant be empty.');</script>");
            }
            else
            {
                Business.Business.Instance.UpdateStaff(Convert.ToInt32(txtID.Text), txtFirstName.Text, txtLastName.Text, txtEmail.Text, dropGender.SelectedValue, txtContact.Text);
                Response.Write("<script type='text/javascript'>alert('User updated.');</script>");
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('ID cant be empty.');</script>");
            }
            else
            {
                Business.Business.Instance.ResetStaffPassword(Convert.ToInt32(txtID.Text));
                Response.Write("<script type='text/javascript'>alert('Password have been reset. Default password is Password123$.');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('ID cant be empty.');</script>");
            }
            else
            {
                Business.Business.Instance.DeleteStaff(Convert.ToInt32(txtID.Text));
                Response.Write("<script type='text/javascript'>alert('Staff Deleted.');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            StaffRow row = Business.Business.Instance.GetStaff(Convert.ToInt32(gridView.SelectedRow.Cells[1].Text));

            txtID.Text = row.ID.ToString();
            txtEmail.Text = row.Email;
            txtFirstName.Text = row.FirstName;
            txtLastName.Text = row.LastName;
            dropGender.SelectedValue = row.Gender;
            txtContact.Text = row.ContactNo;
            txtTotalSale.Text = row.TotalSale.ToString();
        }
    }
}