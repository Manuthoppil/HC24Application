<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Staffverification.aspx.cs" Inherits="HC24Application.Staffverification" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="row">
     <div class="col-sm-12">
                     <div class="iq-card">
                        <div class="iq-card-header d-flex justify-content-between">
                           <div class="iq-header-title">
                              <h4 class="card-title">Verification</h4>
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

                                <asp:GridView ID="grdEmp" runat="server"
            DataKeyNames="Staffid"  CssClass="rowHover table auto-index custome_Table" RowStyle-CssClass="rowHover"
            AutoGenerateColumns="False" AllowPaging="True" 
            PageSize="4" 
             
             CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>          
         <Columns>          
                <asp:TemplateField HeaderText="Emp Name" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("FirstName")%> <%#Eval("LastName")%> 
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEmpName" runat="server" Text='<%#Eval("FirstName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmpName" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEmpName" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>       
        <asp:TemplateField HeaderText="Position" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("Position")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("Position") %>'  TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEditAddress" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="DOJ" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
         <ItemTemplate>
        <%#Eval("DOJ", "{0:dd/MM/yyyy}")%>   
         </ItemTemplate>
         <EditItemTemplate>
               <asp:DropDownList ID="ddlEditDay" runat="server" ToolTip="Select Day">
              </asp:DropDownList>
              <asp:DropDownList ID="ddlEditMonth" runat="server" ToolTip="Select Month">
                    </asp:DropDownList>
              <asp:DropDownList ID="ddlEditYear" runat="server" ToolTip="Select Year">
                    </asp:DropDownList>
         </EditItemTemplate>        
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="180px" />        
         </asp:TemplateField>--%>
           <asp:TemplateField HeaderText="Contact Number" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("Phn")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtSal" runat="server" Text='<%#Eval("Phn") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSal" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtSal" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />             
         </asp:TemplateField>

             <asp:TemplateField HeaderText="EmailAddress" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("EmailAdd")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("EmailAdd") %>'  TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEditAddress" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>
             <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("Nationality")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("Nationality") %>'  TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEditAddress" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>
             <asp:TemplateField HeaderText="County" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("Country")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("Country") %>'  TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEditAddress" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>
             <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("Address")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("Address") %>'  TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEditAddress" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>
             <asp:TemplateField HeaderText="PostCode" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <%#Eval("Postal")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#Eval("Postal") %>'  TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtEditAddress" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
             </EditItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />            
         </asp:TemplateField>
                   <%--<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="custome_Heading"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>             
                <asp:ImageButton ID="imgEdit" runat="server" CommandName="Edit"  ImageUrl="~/images/vf.jpg" ToolTip="Edit" CausesValidation="false" Width="100px"/>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:LinkButton ID="lkUpdate" runat="server" Text="Update" CommandName="Update" ToolTip="Update" CausesValidation="false"></asp:LinkButton>
                 <asp:LinkButton ID="lkCancel" runat="server"  Text="Cancel" CommandName="Cancel" ToolTip="Cancel" CausesValidation="false"></asp:LinkButton>               
             </EditItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="custome_Heading"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            
             <ItemTemplate>
                 <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete"  ImageUrl="~/Images/Delete.png" OnClientClick="return confirm('Are you sure you want to delete selected record ?')" ToolTip="Delete" CausesValidation="false" Width="30px"/>
            </ItemTemplate>           
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>   --%>
             <asp:TemplateField HeaderText="Need To Verify" HeaderStyle-CssClass="custome_Heading"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
            <asp:Button Text="Verify" runat="server" ID="verify" OnClick="verify_Click" CssClass="Button_Action" />
        </ItemTemplate>
               </asp:TemplateField>
                  </Columns>        
             <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle CssClass="rowHover" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />       
         </asp:GridView>    
       


                              <div>
                 </div>
                           </div>
                             <input type="button" class="btn btn-primary" onclick="printDiv('data')" value="Print only Datalist!" />
                        </div>
                     </div>
                  </div>
            </div>
      </form>
</asp:Content>
