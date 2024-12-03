<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ExpenseManagementApp.Admin.Categories" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">


     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style type="text/css">

.confirm-dialog {
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background: #fff;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.2);
    z-index: 1000;
}

.confirm-dialog-content {
    text-align: center;
}

.confirm-btn {
    margin: 5px;
}

.cancel-btn {
    margin: 5px;
}

        .row.jobs-head {
            color: #000;
            font-weight: bold;
            font-size: 14px;
            padding: 15px 0px;
        }

        .jobs-content {
            font-size: 14px;
        }

            .jobs-content .row {
                padding: 10px 0px;
            }

            .jobs-content .job-row:nth-child(odd) {
                background: #F5F7FF;
                border-bottom: 1px solid #CED4DA;
                border-top: 1px solid #CED4DA;
            }

        .action-block {
            display: flex;
            justify-content: space-evenly;
            align-items: center;
            flex-wrap: nowrap;
            flex-direction: row;
            align-content: center;
        }

        .job-details {
            width: 100%;
            padding: 0px 15px;
            display: none;
        }

        .job-row .column {
            padding: 10px 20px;
        }

        .showdetails {
            cursor: pointer;
        }

        .showdropdown {
            cursor: pointer;
        }

        .dropdown-menu {
            right: 0;
            left: auto;
        }
        .job-row:nth-child(odd) {
    background-color: #f9f9f9;
}

.job-row:nth-child(even) {
    background-color: #ffffff;
}

.job-row {
    border-bottom: 1px solid #ddd;
    padding: 10px 0;
}


        @media only screen and (max-width: 600px) {
            .job-details {
                display: block !important;
            }
        }
        /* Ensure the GridView takes up the full width of its container */
        /*.gridview-container {
            width: 100%;
            overflow-x: auto;*/ /* Allows horizontal scrolling if needed */
        /*}

        .table {
            width: 100%;
            table-layout: auto;*/ /* Allows the table to adjust column widths automatically */
        /*}*/
    </style>
    <link rel="stylesheet" href="../Content/vendors/mdi/css/materialdesignicons.min.css">
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               
      <div class="row">
      <div class="col-lg-12 grid-margin stretch-card">
          <div class="card">
                        <div class="container mt-4">
               <div class="row justify-content-left">
 <div class="col-auto">
     <div class="input-group">           

             <asp:LinkButton ID="Button1" OnClick="btnAddCategory_Click" runat="server" CssClass="btn btn-primary" ><i class="mdi mdi-plus-box"></i>
         Add Category</asp:LinkButton>
        
         </div>
     </div>
   <div class="card-body">
                   <h4 class="card-title">Category List</h4>
                   <p class="card-description">
                       <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2" />
                   </p>
                   <div class="row flex-grow-1 d-flex justify-content-center align-items-center">
                       <div class="col-12">
                        <div class="table-responsive">
    <table class="table table-striped">
        <thead>
            <tr>
                <th>SlNo</th>
                <th>Category Name</th>
                <th>Description</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptJobs" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# ((currentPage - 1) * pageSize) + Container.ItemIndex + 1 %></td>
                        <td><%# Eval("CategoryName") %></td>
                        <td><%# Eval("Description") %></td>
                        <td>
                        <!-- Update Button -->
<asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-sm" Text="Update" 
    CommandName="Update" CommandArgument='<%# Eval("CategoryID") %>' OnCommand="btnUpdate_Command" />

<!-- Delete Button -->
<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" Text="Delete" 
    CommandName="Delete" CommandArgument='<%# Eval("CategoryID") %>' OnCommand="btnDelete_Command" />

<%--<asp:Button ID="btnAddToCart" runat="server" CssClass="btn btn-warning btn-sm" Text="Add to Cart" 
    CommandName="AddToCart" CommandArgument='<%#  Eval("CategoryID") %>'  OnClientClick="btnAddToCart"/>--%>

<asp:HiddenField ID="hdnCategoryId" runat="server" Value='<%# Eval("CategoryID") %>' />

           
                        </td>
                    </tr>
                    <div id="confirmDialog" class="confirm-dialog" style="display: none;">
    <div class="confirm-dialog-content">
        <p>Are you sure you want to delete this category?</p>
        <button class="confirm-btn btn btn-danger" onclick="confirmDelete()">Yes, delete</button>
        <button class="cancel-btn btn btn-secondary" onclick="closeConfirmDialog()">Cancel</button>
    </div>
</div>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>

                           <%--<div class="jobs-content">
                               <asp:Repeater ID="rptJobs" runat="server">
                                   <ItemTemplate>
                                       <div class="row job-row" data-jobid='<%# Eval("CategoryID") %>'>
                                           <div class="col-md-1 column">
                                               <b class="d-inline d-sm-none">SlNo: </b><%# ((currentPage - 1) * pageSize) + Container.ItemIndex + 1 %>
                                           </div>

                                           <div class="col-md-2 column">
                                               <b class="d-inline d-sm-none">Company Name: </b><%# Eval("CategoryName") %>
                                           </div>
                                           <div class="col-md-2 column">
                                               <b class="d-inline d-sm-none">RegNumber: </b><%# Eval("Description") %>
                                           </div>
                                          

                                       <div class="col-md-2">
    <!-- Update Button -->
    <button class="btn btn-primary btn-sm" onclick="updateCategory('<%# Eval("CategoryID") %>')">
        <i class="bx bx-edit-alt me-1"></i>Update
    </button>

    <!-- Delete Button -->
    <button class="btn btn-danger btn-sm" onclick="openConfirmDialog('<%# Eval("CategoryID") %>')">
        <i class="bx bx-trash me-1"></i>Delete
    </button>
</div>

<!-- Confirmation Dialog -->
<div id="confirmDialog" class="confirm-dialog" style="display: none;">
    <div class="confirm-dialog-content">
        <p>Are you sure you want to delete this category?</p>
        <button class="confirm-btn btn btn-danger" onclick="confirmDelete()">Yes, delete</button>
        <button class="cancel-btn btn btn-secondary" onclick="closeConfirmDialog()">Cancel</button>
    </div>
</div>


                                      
                                       </div>
                                   </ItemTemplate>
                               </asp:Repeater>

                           </div>--%>
                       </div>
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
      <script type="text/javascript">
          let categoryIdToDelete = null;

          // Open Confirmation Dialog
          function openConfirmDialog(categoryId) {
              categoryIdToDelete = categoryId;
              document.getElementById("confirmDialog").style.display = "block";
          }

          // Close Confirmation Dialog
          function closeConfirmDialog() {
              categoryIdToDelete = null;
              document.getElementById("confirmDialog").style.display = "none";
          }

          // Confirm Delete Action
          function confirmDelete() {
              if (categoryIdToDelete) {
                  alert(`Deleting category with ID: ${categoryIdToDelete}`);
                  // Add logic to delete the category (e.g., AJAX or form submission)
                  closeConfirmDialog();
              }
          }

          // Update Category
          function updateCategory(categoryId) {
              window.location.href = 'CategoryUpdate.aspx?CategoryID=' + CategoryID;
              alert(`Updating category with ID: ${categoryId}`);
             
          }
          function addToCart(categoryId) {
              window.location.href = 'Cart.aspx';
              alert(`Updating category with ID: ${categoryId}`);

          }


    
         

      </script>
    
</asp:Content>
