<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ExpenseManagementApp.Admin.Addcategory"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      <div class="row">
  <div class="col-lg-12 grid-margin stretch-card">
      <div class="card"><p >Add Category</p>
    <div class="form-group">
    <asp:Label ID="lblCategoryName" runat="server" Text="Category Name:" CssClass="form-label"></asp:Label>
    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="form-label"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
</div>

<asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-primary" OnClick="btnAddCategory_Click" />
<asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
          </div>
      </div>
          </div>
</asp:Content>
