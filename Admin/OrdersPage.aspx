<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="OrdersPage.aspx.cs" Inherits="ExpenseManagementApp.Admin.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server" CssClass="text-center mb-3"></asp:Label>

<asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
        <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
       
        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd-MM-yyyy}" />
    </Columns>
</asp:GridView>
    <div class="total-amount">
    <h3>Total Order Amount: <asp:Label ID="lblTotalAmount" runat="server" Text="0" CssClass="total-amount-label" /></h3>
</div>
</asp:Content>
