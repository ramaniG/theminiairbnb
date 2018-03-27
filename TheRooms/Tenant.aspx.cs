using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class Tenant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            GridView1.DataSource = Business.Business.Instance.GetTenants();
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
                Business.Business.Instance.InsertTenant(txtEmail.Text, txtName.Text, dropGender.SelectedValue, Convert.ToInt32(txtAge.Text), txtContact.Text);
                Response.Write("<script type='text/javascript'>alert('New Tenant is added.');</script>");
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
                Business.Business.Instance.UpdateTenant(Convert.ToInt32(txtID.Text), txtEmail.Text, txtName.Text, dropGender.SelectedValue, Convert.ToInt32(txtAge.Text), txtContact.Text);
                Response.Write("<script type='text/javascript'>alert('Tenant updated.');</script>");
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
                Business.Business.Instance.DeleteTenant(Convert.ToInt32(txtID.Text));
                Response.Write("<script type='text/javascript'>alert('Tenant Deleted.');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            TenantRow row = Business.Business.Instance.GetTenant(Convert.ToInt32(gridView.SelectedRow.Cells[1].Text));

            txtID.Text = row.ID.ToString();
            txtEmail.Text = row.Email;
            txtName.Text = row.Name;
            dropGender.SelectedValue = row.Gender;
            txtContact.Text = row.ContactNo;
            txtAge.Text = row.Age.ToString();
        }
    }
}