using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TheRooms.Business.TheRooms;

namespace TheRooms
{
    public partial class Booking : System.Web.UI.Page
    {
        StaffRow staff;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropOwner.DataSource = Business.Business.Instance.GetOwners();
                dropOwner.DataBind();

                dropTenant.DataSource = Business.Business.Instance.GetTenants();
                dropTenant.DataBind();
            }
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            SiteMaster master = (SiteMaster)this.Master;

            if (master.IsAdmin)
            {
                searchPanel.Visible = true;

                if (txtSearch.Text.Length > 0)
                {
                    GridView1.DataSource = Business.Business.Instance.GetBookingsByStaff(Convert.ToInt32(txtSearch.Text));
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = Business.Business.Instance.GetBookings();
                    GridView1.DataBind();
                }

                btnAdd.Enabled = false;
            } 
            else
            {
                staff = master.currentStaff;
                searchPanel.Visible = false;
                GridView1.DataSource = Business.Business.Instance.GetBookingsByStaff(staff.ID);
                GridView1.DataBind();

                btnAdd.Enabled = true;
            }            

            if (dropOwner.SelectedValue != null)
            {
                dropRoom.DataSource = Business.Business.Instance.GetOwnersRoom(Convert.ToInt32(dropOwner.SelectedValue));
                dropRoom.DataBind();
            }

            if (dropRoom.SelectedValue == null || dropRoom.SelectedValue.Length == 0)
            {
                txtPriceDaily.Text = "0";
            }
            else
            {
                RoomRow room = Business.Business.Instance.GetRoom(Convert.ToInt32(dropRoom.SelectedValue));
                txtPriceDaily.Text = room.Price.ToString();
            }

            if (calCheckin.SelectedDate != null && calCheckout.SelectedDate != null)
            {
                int date = (int)(calCheckout.SelectedDate - calCheckin.SelectedDate).TotalDays;
                txtNights.Text = date.ToString();
            }
            else
            {
                txtNights.Text = "0";
            }

            txtTotalPrice.Text = (Convert.ToInt32(txtNights.Text) * Convert.ToDecimal(txtPriceDaily.Text)).ToString();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SiteMaster master = (SiteMaster)this.Master;
            staff = master.currentStaff;

            if (calBookingDate.SelectedDate == null || calCheckin.SelectedDate == null || calCheckout.SelectedDate == null || dropRoom.SelectedValue == null || dropRoom.SelectedValue.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('All fields must be filled.');</script>");
            }
            else if (master.IsAdmin)
            {
                Response.Write("<script type='text/javascript'>alert('Admin not allowed to enter bookings.');</script>");
            }
            else
            {
                Business.Business.Instance.InsertBooking(calBookingDate.SelectedDate, calCheckin.SelectedDate, calCheckout.SelectedDate, 
                    Convert.ToDecimal(txtTotalPrice.Text), Convert.ToInt32(dropRoom.SelectedValue), staff.ID, Convert.ToInt32(dropTenant.SelectedValue), 
                    Convert.ToInt32(dropStatus.SelectedValue));
                Response.Write("<script type='text/javascript'>alert('New booking is added.');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('ID cant be empty.');</script>");
            }
            else if (calBookingDate.SelectedDate == null || calCheckin.SelectedDate == null || calCheckout.SelectedDate == null || dropRoom.SelectedValue == null || dropRoom.SelectedValue.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('All fields must be filled.');</script>");
            }
            else
            {
                Business.Business.Instance.UpdateBooking(Convert.ToInt32(txtID.Text), calBookingDate.SelectedDate, calCheckin.SelectedDate, calCheckout.SelectedDate,
                    Convert.ToDecimal(txtTotalPrice.Text), Convert.ToInt32(dropRoom.SelectedValue), Convert.ToInt32(hidStaffID.Value), Convert.ToInt32(dropTenant.SelectedValue),
                    Convert.ToInt32(dropStatus.SelectedValue));
                Response.Write("<script type='text/javascript'>alert('Booking updated.');</script>");
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
                Business.Business.Instance.DeleteBooking(Convert.ToInt32(txtID.Text));
                Response.Write("<script type='text/javascript'>alert('Booking deleted.');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            BookingRow row = Business.Business.Instance.GetBooking(Convert.ToInt32(gridView.SelectedRow.Cells[1].Text));
            RoomRow room = Business.Business.Instance.GetRoom(row.Room_ID);

            txtID.Text = row.ID.ToString();
            hidStaffID.Value = row.Staff_ID.ToString();
            calBookingDate.SelectedDate = row.BookingDate;
            calCheckin.SelectedDate = row.CheckInDate;
            calCheckout.SelectedDate = row.CheckOutDate;
            dropOwner.SelectedValue = room.Owner_ID.ToString();

            dropRoom.DataSource = Business.Business.Instance.GetOwnersRoom(Convert.ToInt32(dropOwner.SelectedValue));
            dropRoom.DataBind();

            dropRoom.SelectedValue = row.Room_ID.ToString();
            dropTenant.SelectedValue = row.Tenant_ID.ToString();
            dropStatus.SelectedValue = row.Status.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Business.Business.Instance.GetBookingsByStaff(Convert.ToInt32(txtSearch.Text));
            GridView1.DataBind();
        }
    }
}