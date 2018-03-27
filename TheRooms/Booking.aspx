<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="TheRooms.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Bookings</h1>
    </div>
    <div class="row">
        <asp:Panel ID="searchPanel" runat="server" Visible="false">
            <div class="col-md-2">
            </div>
            <div class="col-md-8">
                <div class="form-inline">
                    <div class="form-group">
                        <label class="control-label col-sm-2">Staff ID:</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" Text="SEARCH" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="col-md-2">
            </div>
        </asp:Panel>
    </div>
    <div class="row">
        <div class="col-md-12 main">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true" CssClass="table table-striped"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
        </div>
    </div>
    <div class="page-header">
        <h3>Editing</h3>
    </div>
    <div class="row">
        <div class="col-md-12 main">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="control-label col-sm-2">ID:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        <asp:HiddenField ID="hidStaffID" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Booking Date:</label>
                    <div class="col-sm-10">
                        <asp:Calendar ID="calBookingDate" runat="server"></asp:Calendar>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Check-in Date:</label>
                    <div class="col-sm-10">
                        <asp:Calendar ID="calCheckin" runat="server"></asp:Calendar>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Check-out Date:</label>
                    <div class="col-sm-10">
                        <asp:Calendar ID="calCheckout" runat="server"></asp:Calendar>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Owner Name:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropOwner" runat="server" CssClass="form-control" DataTextField="Name"
                            DataValueField="ID" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Room ID:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropRoom" runat="server" CssClass="form-control" DataTextField="IDandAddress" DataValueField="ID" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Tenant Name:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropTenant" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="ID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Per Night Price (RM):</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPriceDaily" runat="server" CssClass="form-control" Enabled="false" Text="0" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Total Night(s):</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNights" runat="server" CssClass="form-control" Enabled="false" Text="0" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Total Price (RM):</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="form-control" Enabled="false" Text="0" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Booking Status:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="On going" Value="1" />
                            <asp:ListItem Text="Completed" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Canceled" Value="3" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btn btn-danger" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
