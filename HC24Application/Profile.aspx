<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HC24Application.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        


               </div>
</asp:Content>
