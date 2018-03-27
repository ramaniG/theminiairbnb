using System;
using System.Web.UI.WebControls;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class Room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropOwner.DataSource = Business.Business.Instance.GetOwners();
                dropOwner.DataBind();
            }
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            GridView1.DataSource = Business.Business.Instance.GetRooms();
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length == 0 || txtPrice.Text.Length == 0 || txtSize.Text.Length == 0 || 
                calAvailableDate.SelectedDate == null || dropOwner.SelectedValue == null || dropType.SelectedValue == null)
            {
                Response.Write("<script type='text/javascript'>alert('All fields must be filled.');</script>");
            }
            else
            {
                Business.Business.Instance.InsertRoom(calAvailableDate.SelectedDate, dropType.SelectedValue, 
                    Convert.ToInt32(txtSize.Text), txtFacility.Text, Convert.ToDecimal(txtPrice.Text), txtAddress.Text, 
                    chkNearbyPTP.Checked , txtRestricted.Text, Convert.ToInt32(dropOwner.SelectedValue));
                Response.Write("<script type='text/javascript'>alert('New room is added.');</script>");
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
                Business.Business.Instance.UpdateRoom(Convert.ToInt32(txtID.Text), calAvailableDate.SelectedDate, dropType.SelectedValue,
                    Convert.ToInt32(txtSize.Text), txtFacility.Text, Convert.ToDecimal(txtPrice.Text), txtAddress.Text,
                    chkNearbyPTP.Checked, txtRestricted.Text, Convert.ToInt32(dropOwner.SelectedValue));
                Response.Write("<script type='text/javascript'>alert('Room updated.');</script>");
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
                Business.Business.Instance.DeleteRoom(Convert.ToInt32(txtID.Text));
                Response.Write("<script type='text/javascript'>alert('Room deleted.');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            RoomRow row = Business.Business.Instance.GetRoom(Convert.ToInt32(gridView.SelectedRow.Cells[1].Text));

            txtID.Text = row.ID.ToString();
            calAvailableDate.SelectedDate = row.AvailableDate;
            dropType.SelectedValue = row.Type;
            txtSize.Text = row.Size.ToString();
            txtFacility.Text = row.Facility;
            txtPrice.Text = row.Price.ToString();
            txtAddress.Text = row.Address;
            chkNearbyPTP.Checked = row.NearbyPubTrans;
            txtFacility.Text = row.Facility;
            dropOwner.SelectedValue = row.Owner_ID.ToString();
        }
    }
}