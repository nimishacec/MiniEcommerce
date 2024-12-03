<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="EditCart.aspx.cs" Inherits="ExpenseManagementApp.Admin.EditCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="row">
  <div class="col-lg-12 grid-margin stretch-card">
      <div class="card">
          <div class="card-body">
          <p>Edit Items in Cart</p>

<asp:Label ID="lblCategory" runat="server" Text="Select Category:" CssClass="form-label"></asp:Label>
<asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" Enabled="false">
</asp:DropDownList>

<br /><br />

<asp:Label ID="lblItems" runat="server" Text="Select Item:" CssClass="form-label"></asp:Label>
<asp:DropDownList ID="ddlItems" CssClass="form-control" runat="server" Enabled="false">
</asp:DropDownList>

<br /><br />

<asp:Label ID="lblPrice" runat="server" Text="Price:" CssClass="form-label"></asp:Label>
<asp:TextBox ID="txtPrice" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

<br /><br />

<asp:Label ID="lblQuantity" runat="server" Text="Quantity:" CssClass="form-label"></asp:Label>
<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>

<asp:Button ID="btnUpdateCart" runat="server" CssClass="btn btn-primary mt-2" Text="Update Quantity" OnClick="btnUpdateCart_Click" />

          </div>
          </div>
</asp:Content>
