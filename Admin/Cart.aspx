<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ExpenseManagementApp.Admin.Cart" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
<div class="col-lg-12 grid-margin stretch-card">
    <div class="card">
        <div class="card-body">
    <div class="container">
            <h2>Your Cart</h2>
            <asp:GridView ID="gvCartItems" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvCartItems_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Unit Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                   <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:LinkButton ID="btnRemove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("CartID") %>' CssClass="btn btn-danger btn-sm" />
          
                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="EditQuantity" CommandArgument='<%# Eval("CartID") %>' CssClass="btn btn-primary btn-sm" />
            </ItemTemplate>
        
        </asp:TemplateField>
                </Columns>
            </asp:GridView>

           <div class="d-flex justify-content-between mt-3">
    <h5>Total Price: <asp:Label ID="lblSubtotal" runat="server" CssClass="fw-bold"></asp:Label></h5>
    <asp:Button ID="btnPlaceOrder" runat="server" CssClass="btn btn-success" Text="Place Order" OnClick="btnPlaceOrder_Click" />
</div>
        </div>
             <div class="pagination-controls">
     <asp:LinkButton ID="lnkPrevious" runat="server" Text="Previous" OnClick="lnkPrevious_Click" CssClass="btn btn-primary"></asp:LinkButton>
     <asp:Label ID="lblPageInfo" runat="server" CssClass="page-info"></asp:Label>
     <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNext_Click" CssClass="btn btn-primary"></asp:LinkButton>
 </div>
            </div>
        </div>
    </div>
           </div>
</asp:Content>
