<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="BuyItems.aspx.cs" Inherits="ExpenseManagementApp.Admin.BuyItems" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="row">
  <div class="col-lg-12 grid-margin stretch-card">
      <div class="card">
          <div class="card-body">
           <p > Add Items to Cart</p>

              <asp:Label ID="lblCategory" runat="server" Text="Select Category:" CssClass="form-label"></asp:Label>
<asp:DropDownList ID="ddlCategory"  CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" >
</asp:DropDownList>

<br /><br />

<asp:Label ID="lblItems" runat="server" Text="Select Item:" CssClass="form-label"></asp:Label>
<asp:DropDownList ID="ddlItems"   CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged" >
</asp:DropDownList>

<br /><br />

<asp:Label ID="lblPrice" runat="server" Text="Price:" CssClass="form-label"></asp:Label>
<asp:TextBox ID="txtPrice" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

<br /><br />

<asp:Label ID="lblQuantity" runat="server" Text="Quantity:" CssClass="form-label"></asp:Label>
<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" ></asp:TextBox>
<asp:Button ID="btnAddCart" runat="server" CssClass=" btn btn-primary mt-2" Text="AddToCart"  OnClick="btnAddCart_Click"/>
          </div>
      </div>
          </div>
          </div>
</asp:Content>
