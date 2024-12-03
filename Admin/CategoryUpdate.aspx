<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="CategoryUpdate.aspx.cs" Inherits="ExpenseManagementApp.Admin.CategoryUpdate"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
      <div class="row">
  <div class="col-lg-12 grid-margin stretch-card">
      <div class="card">
          <div class="card-body>
              "<p class="form-control ms-3" >Update Category</p>
    <div class="form-group ms-3">
    <asp:Label ID="lblCategoryName" runat="server" Text="Category Name:" CssClass="form-label"></asp:Label>
    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group ms-3">
    <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="form-label"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
</div>

<asp:Button ID="btnUpdateCategory" runat="server" Text="Update Category" CssClass="btn btn-primary" OnClick="btnUpdateCategory_Click" />
<asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
          </div>
      </div>
          </div>
    </div>
</asp:Content>
