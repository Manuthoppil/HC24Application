<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StaffDetails.aspx.cs" Inherits="HC24Application.StaffDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript">
    function printDiv(divName) {
        var printContents = document.getElementById(divName).innerHTML;
        var originalContents = document.body.innerHTML;

        document.body.innerHTML = printContents;

        window.print();

        document.body.innerHTML = originalContents;
    }
    </script>
    <form runat="server">
            <div class="col-sm-12">
                     <div class="iq-card">
                        <div class="iq-card-header d-flex justify-content-between">
                           <div class="iq-header-title">
                              <h4 class="card-title">Staff details</h4>
                           </div>
                        </div>
                        <div class="iq-card-body">
                            <div class="iq-search-bar">
                        <div class="searchbox" id="search_main">
                           <input type="text" class="text search-input" placeholder="Type here to search...">
                           <a class="search-link" href="#"><i class="ri-search-line"></i></a>
                        </div>
                              </div>
                            <div class="table-responsive" id="data">
                              <table class="table auto-index custome_Table" >
                                 <thead>
                                    <tr>
                                       <th scope="col">Reg No</th>
                                       <th scope="col">Name</th>
                                       <th scope="col">Position</th>
                                       <th scope="col">Mobile</th>
                                       <th scope="col">Email</th>
                                       <th scope="col">Country</th>
                                       <th scope="col">County</th>
                                       <th scope="col">Address</th>
                                       <th scope="col">Postcode</th>
                                    </tr>
                                 </thead>
                                 <tbody>
                                   <%=GetDetails()%>
                                </tbody>
                              </table>
                                <div>
                 </div>
                           </div>
                             <input type="button" class="btn btn-primary" onclick="printDiv('data')" value="Print only Datalist!" />
                        </div>
                     </div>
                  </div>
        </form>
</asp:Content>
