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
        <div class="col-md-12"><div class="iq-card">
<div class="iq-card-header d-flex justify-content-between">
                                 <div class="iq-header-title">
                                    <h4 class="card-title">Education</h4>
                                 </div>
                              </div>
                              <div class="iq-card-body">
                                 <table class="table mb-0 table-borderless">
                                  <thead>
                                      <tr>
                                          <th scope="col">Year</th>
                                          <th scope="col">Degree</th>
                                          <th scope="col">Institute</th>
                                          <th scope="col">Result</th>
                                      </tr>
                                  </thead>
                                  <tbody>
                                      <tr>
                                          <td>2010</td>
                                          <td>MBBS, M.D</td>
                                          <td>University of Wyoming</td>
                                          <td><span class="badge badge-success">Distinction</span></td>
                                      </tr>
                                      <tr>
                                          <td>2014</td>
                                          <td>M.D. of Medicine</td>
                                          <td>Netherland Medical College</td>
                                          <td><span class="badge badge-success">Distinction</span></td>
                                      </tr>
                                  </tbody>
                              </table>
                              </div>
                           </div>
                        </div>


               </div>
</asp:Content>
