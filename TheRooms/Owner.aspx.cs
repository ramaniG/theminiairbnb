using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class Owner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            GridView1.DataSource = Business.Business.Instance.GetOwners();
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length == 0 || txtName.Text.Length == 0 || txtAge.Text.Length == 0 || txtContact.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('All fields must be filled.');</script>");
            }
            else
            {
                Business.Business.Instance.InsertOwner(txtName.Text, txtEmail.Text, dropGender.SelectedValue, Convert.ToInt32(txtAge.Text), txtContact.Text);
                Response.Write("<script type='text/javascript'>alert('New Owner is added.');</script>");
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
                Business.Business.Instance.UpdateOwner(Convert.ToInt32(txtID.Text), txtName.Text, txtEmail.Text, dropGender.SelectedValue, Convert.ToInt32(txtAge.Text), txtContact.Text);
                Response.Write("<script type='text/javascript'>alert('Owner updated.');</script>");
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
                Business.Business.Instance.DeleteOwner(Convert.ToInt32(txtID.Text));
                Response.Write("<script type='text/javascript'>alert('Owner Deleted.');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            OwnerRow row = Business.Business.Instance.GetOwner(Convert.ToInt32(gridView.SelectedRow.Cells[1].Text));

            txtID.Text = row.ID.ToString();
            txtEmail.Text = row.Email;
            txtName.Text = row.Name;
            txtAge.Text = row.Age.ToString();
            dropGender.SelectedValue = row.Gender;
            txtContact.Text = row.ContactNo;
            txtRecentUpdate.Text = row.RecentUpdate.ToString();
            txtTotalRoom.Text = row.TotalRoom.ToString();

            if (row.TotalRoom > 0)
            {
                GridView2.DataSource = Business.Business.Instance.GetOwnersRoom(row.ID);
            }
            else
            {
                GridView2.DataSource = null;
            }

            GridView2.DataBind();
        }
    }
}