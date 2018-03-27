<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TheRooms.Room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Rooms</h1>
    </div>
    <div class="row">
        <div class="col-md-12 main">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true" CssClass="table table-striped"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
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
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Available Date:</label>
                    <div class="col-sm-10">
                        <asp:Calendar ID="calAvailableDate" runat="server"></asp:Calendar>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Type:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropType" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Condominiums" Value="Condominiums" />
                            <asp:ListItem Text="Service Residence" Value="ServiceResidence"></asp:ListItem>
                            <asp:ListItem Text="Apartments" Value="Apartments" />
                            <asp:ListItem Text="Flats" Value="Flats" />
                            <asp:ListItem Text="SoHo" Value="SoHo" />
                            <asp:ListItem Text="Bungalow" Value="Bungalow" />
                            <asp:ListItem Text="Semi Detached" Value="Semi Detached" />
                            <asp:ListItem Text="Townhouse" Value="Townhouse" />
                            <asp:ListItem Text="Terrace Houses" Value="Terrace Houses" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Size (sqft):</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtSize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Facilities:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtFacility" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Price per Night (RM):</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Full Address:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Nearby Public Transport:</label>
                    <div class="col-sm-10 checkbox">
                        <asp:CheckBox ID="chkNearbyPTP" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Restricted Items:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtRestricted" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Owner Name:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropOwner" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="ID">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
                        <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="btn btn-success" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btn btn-danger" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this user?');"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
