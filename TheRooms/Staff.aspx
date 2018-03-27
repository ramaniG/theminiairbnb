<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="TheRooms.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Staff</h1>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-8">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true"
               OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-striped"></asp:GridView>
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
                    <label class="control-label col-sm-2">Email:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">First Name:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Last Name:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Gender:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropGender" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Male" Value="M" />
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Contact No:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>                
                <div class="form-group">
                    <label class="control-label col-sm-2">Total Sale:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtTotalSale" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
                        <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="btn btn-success" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnResetPassword" runat="server" Text="RESET PASSWORD" CssClass="btn btn-warning" OnClick="btnResetPassword_Click"/>
                        <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btn btn-danger" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this user?');"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
