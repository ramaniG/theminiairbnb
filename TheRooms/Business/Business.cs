using System;
using TheRooms.Business.TheRoomsTableAdapters;
using static TheRooms.Business.TheRooms;

namespace TheRooms.Business
{
    public class Business
    {
        private static readonly Lazy<Business> lazy = new Lazy<Business>(() => new Business());

        public static Business Instance { get { return lazy.Value; } }

        // Adapters
        AdministratorTableAdapter administratorTableAdapter;
        RoomTableAdapter roomTableAdapter;
        OwnerTableAdapter ownerTableAdapter;
        TenantTableAdapter tenantTableAdapter;
        BookingTableAdapter bookingTableAdapter;
        StaffTableAdapter staffTableAdapter;

        public Business()
        {
            administratorTableAdapter = new AdministratorTableAdapter();
            roomTableAdapter = new RoomTableAdapter();
            ownerTableAdapter = new OwnerTableAdapter();
            tenantTableAdapter = new TenantTableAdapter();
            bookingTableAdapter = new BookingTableAdapter();
            staffTableAdapter = new StaffTableAdapter();
        }

        // Adminstator
        public bool AuthenticateAdmin(string email, string password)
        {
            AdministratorDataTable administratorDataTable = administratorTableAdapter.GetAdminAuthenticate(email, password);

            if (administratorDataTable.Count > 0)
            {
                return true;
            }

            return false;
        }
        
        public int InsertAdmin(string fname, string lname, string email, string password, string gender, string contactno)
        {
            int id = administratorTableAdapter.Insert(fname, lname, email, password, gender, contactno);

            if (id > 0)
            {
                return id;
            }

            return 0;
        }

        public void UpdateAdmin(int id, string fname, string lname, string email, string gender, string contactno)
        {
            administratorTableAdapter.UpdateAdmin(fname, lname, email, gender, contactno, id);
        }

        public void DeleteAdmin(int id)
        {
            administratorTableAdapter.Delete(id);
        }

        public bool ChangeAdminPassword(int id, string oldpassword, string newpassword)
        {
            AdministratorRow row = administratorTableAdapter.GetAdmin(id)[0];

            if (row != null)
            {
                if (row.Password == oldpassword)
                {
                    administratorTableAdapter.UpdateAdminPassword(newpassword, row.ID);
                    return true;
                }
            }

            return false;
        }

        public string ResetAdminPassword(int id)
        {
            AdministratorRow row = administratorTableAdapter.GetAdmin(id)[0];
            string randomPassword = "Password123$";
            administratorTableAdapter.UpdateAdminPassword(randomPassword, row.ID);
            return randomPassword;
        }

        public AdministratorDataTable GetAdmins()
        {
            return administratorTableAdapter.GetAdmins();
        }

        public AdministratorRow GetAdmin(int id)
        {
            AdministratorDataTable table = administratorTableAdapter.GetAdmin(id);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        public AdministratorRow GetAdmin(string email)
        {
            AdministratorDataTable table = administratorTableAdapter.GetAdminByEmail(email);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        // Staff
        public bool AuthenticateStaff(string email, string password)
        {
            StaffDataTable staffDataTable = staffTableAdapter.GetStaffAuthenticate(email, password);

            if (staffDataTable.Count > 0)
            {
                return true;
            }

            return false;
        }

        public int InsertStaff(string fname, string lname, string email, string password, string gender, string contactno)
        {
            int id = staffTableAdapter.Insert(fname, lname, email, password, gender, contactno);

            if (id > 0)
            {
                return id;
            }

            return 0;
        }

        public void UpdateStaff(int id, string fname, string lname, string email, string gender, string contactno)
        {
            staffTableAdapter.UpdateStaff(fname, lname, email, gender, contactno, id);
        }

        public void DeleteStaff(int id)
        {
            staffTableAdapter.Delete(id);
        }

        public bool ChangeStaffPassword(int id, string oldpassword, string newpassword)
        {
            StaffRow row = staffTableAdapter.GetStaff(id)[0];

            if (row != null)
            {
                if (row.Password == oldpassword)
                {
                    staffTableAdapter.UpdateStaffPassword(newpassword, row.ID);
                    return true;
                }
            }

            return false;
        }

        public string ResetStaffPassword(int id)
        {
            StaffRow row = staffTableAdapter.GetStaff(id)[0];
            string randomPassword = "Password123$";
            staffTableAdapter.UpdateStaffPassword(randomPassword, row.ID);
            return randomPassword;
        }

        public StaffDataTable GetStaffs()
        {
            return staffTableAdapter.GetStaffs();
        }

        public StaffRow GetStaff(int id)
        {
            StaffDataTable table = staffTableAdapter.GetStaff(id);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        public StaffRow GetStaff(string email)
        {
            StaffDataTable table = staffTableAdapter.GetStaffByEmail(email);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        public decimal GetStaffTotalSale(int id)
        {
            var total = staffTableAdapter.GetStaffTotalSale(id);
            if (total != null)
            {
                return Convert.ToDecimal(total);
            }
            return 0;
        }

        // Owner
        public int InsertOwner(string name, string email, string gender, int age, string contactno)
        {
            int id = ownerTableAdapter.InsertOwner(email, name, gender, age, contactno);

            if (id > 0)
            {
                return id;
            }
            return 0;
        }

        public void UpdateOwner(int id, string name, string email, string gender, int age, string contactno)
        {
            ownerTableAdapter.UpdateOwner(email, name, gender, age, contactno, id);
        }

        public void DeleteOwner(int id)
        {
            ownerTableAdapter.DeleteOwner(id);
        }

        public int GetOwnerTotalRoom(int id)
        {
            return Convert.ToInt32(ownerTableAdapter.GetOwnerRoomTotal(id));
        }

        public OwnerDataTable GetOwners()
        {
            return ownerTableAdapter.GetOwners();
        }

        public OwnerRow GetOwner(int id)
        {
            OwnerDataTable table = ownerTableAdapter.GetOwner(id);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        // Room
        public int InsertRoom(DateTime availableDate, string type, int size, string facility, decimal price, string address, bool nearbyPubTrans, string restrictedItem, int ownerID)
        {
            int id = roomTableAdapter.Insert(availableDate, type, size, facility, price, address, nearbyPubTrans, restrictedItem, ownerID);

            if (id > 0)
            {
                return id;
            }

            return 0;
        }

        public void UpdateRoom(int id, DateTime availableDate, string type, int size, string facility, decimal price, string address, bool nearbyPubTrans, string restrictedItem, int ownerId)
        {
            roomTableAdapter.UpdateRoom(availableDate, type, size, facility, price, address, nearbyPubTrans, restrictedItem, ownerId, id);
        }

        public void DeleteRoom(int id)
        {
            roomTableAdapter.Delete(id);
        }

        public RoomDataTable GetRooms()
        {
            return roomTableAdapter.GetRooms();
        }

        public RoomDataTable GetOwnersRoom(int ownerid)
        {
            return roomTableAdapter.GetOwnerRooms(ownerid);
        }

        public RoomRow GetRoom(int id)
        {
            RoomDataTable table = roomTableAdapter.GetRoom(id);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        // Tenant
        public int InsertTenant(string email, string name, string gender, int age, string contactno)
        {
            int id = tenantTableAdapter.Insert(email, name, gender, age, contactno);
            if (id > 0) return id;
            return 0;
        }

        public void UpdateTenant(int id, string email, string name, string gender, int age, string contactno)
        {
            tenantTableAdapter.UpdateTenant(email, name, gender, age, contactno, id);
        }

        public void DeleteTenant(int id)
        {
            tenantTableAdapter.Delete(id);
        }

        public TenantDataTable GetTenants()
        {
            return tenantTableAdapter.GetTenants();
        }

        public TenantRow GetTenant(int id)
        {
            TenantDataTable table = tenantTableAdapter.GetTenant(id);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }

        // Booking
        public int InsertBooking(DateTime bookingDate, DateTime checkin, DateTime checkout, decimal totalprice, int roomid, int staffid, int tenantid, int status)
        {
            int id = bookingTableAdapter.InsertBooking(bookingDate, checkin, checkout, totalprice, roomid, staffid, tenantid, status);
            if (id > 0)
            {
                return id;
            }
            return 0;
        }

        public void UpdateBooking(int id, DateTime bookingDate, DateTime checkin, DateTime checkout, decimal totalprice, int roomid, int staffid, int tenantid, int status)
        {
            bookingTableAdapter.UpdateBooking(bookingDate, checkin, checkout, totalprice, roomid, staffid, tenantid, status, id);
        }

        public void DeleteBooking(int id)
        {
            bookingTableAdapter.Delete(id);
        }

        public BookingDataTable GetBookings()
        {
            return bookingTableAdapter.GetBookings();
        }

        public BookingDataTable GetBookingsByStaff(int staffid)
        {
            return bookingTableAdapter.GetBookingByStaff(staffid);
        }

        public BookingRow GetBooking(int id)
        {
            BookingDataTable table = bookingTableAdapter.GetBooking(id);

            if (table != null && table.Count > 0)
            {
                return table[0];
            }

            return null;
        }
    }
}