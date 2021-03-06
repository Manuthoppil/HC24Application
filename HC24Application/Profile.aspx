<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HC24Application.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
    <div class="row">
                  <div class="col-lg-5">
                     <div class="iq-card">
                        <div class="iq-card-body pl-0 pr-0 pt-0">
                           <div class="doctor-details-block">
                              <div class="doc-profile-bg bg-primary" style="height:150px;">
                              </div>
                              <div class="doctor-profile text-center">
                                  <asp:Image ID="Image1" runat="server" ImageUrl="images/user/11.png" class="avatar-130 img-fluid" />
                              </div>
                               <%=GetDetails()%>
                           </div>
                        </div>
                     </div>
                      <%=GetAddress()%>
                  </div>
                   <%=GetOtherDetails()%>
       <div class="col-sm-12">
                     <div class="iq-card">
                        <div class="iq-card-header d-flex ">
                            <asp:Button ID="verify" runat="server" class="btn btn-primary button_profile" Text="Verify"   CausesValidation="False" />
                <asp:Button ID="Delete" runat="server" class="btn btn-primary button_profile" Text="Delete"   CausesValidation="False" />
                <asp:Button ID="Update" runat="server" class="btn btn-primary button_profile" Text="Update"   CausesValidation="False" />
                
                        </div>
                            </div>
        </div>
               </div>
              </ContentTemplate>
             </asp:UpdatePanel>
        </form>
</asp:Content>
