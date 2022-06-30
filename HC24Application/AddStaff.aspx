<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddStaff.aspx.cs" Inherits="HC24Application.AddStaff" enableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   hjgjhgjhgjhghj
    
    <script type="text/javascript">
         function showpreview(input) {
             var uploadControlImage = document.getElementById('<%=ImageUpload.ClientID %>');
                
             if (uploadControlImage.files[0].size > 2097152) {
                 alert("Profile image size should be leass than 2 Mb");


                 document.getElementById('ImageUpload').src = "images/user/11.png";
                 return false;
             }
             else {
                 if (input.files && input.files[0]) {

                     var reader = new FileReader();
                     reader.onload = function (e) {
                         $('#imgpreview').css('visibility', 'visible');
                         $('#imgpreview').attr('src', e.target.result);
                     }
                     reader.readAsDataURL(input.files[0]);
                 }
             }
         }
     </script>
     
     <script type="text/javascript">
    function validate()  
    {
  if (document.getElementById("<%=ImageUpload.ClientID %>").value == "") {
            alert("Profile Picture Can not be blank");
            document.getElementById("<%=ImageUpload.ClientID %>").focus();
            return false;
        }

       var ddlpostionFormatVal = document.getElementById("<%=Drpposition.ClientID%>");
            var selectedText = ddlpostionFormatVal.options[ddlpostionFormatVal.selectedIndex].innerHTML;
        if (selectedText == "Select") {
            alert("Position can not be blank");
            document.getElementById("<%=Drpposition.ClientID%>").focus();
            return false;
        }
        else {

        }
        if (selectedText == "RGN") {

            if (document.getElementById("<%=NMCPin.ClientID%>").value == "") {

                alert("NMC PIn can not be blank");
                document.getElementById("<%=NMCPin.ClientID%>").focus();
                return false
            }
            else
            {
                
            }
            <%--if (document.getElementById("<%=RenewalInputdate.ClientID%>").value == "") {

                alert("RenewalDate  can not be blank");
                document.getElementById("<%=RenewalInputdate.ClientID%>").focus();
                return false
            }
            else
            {

            }--%>
        }
        else {

        }
        if (document.getElementById("<%=txtfirstname.ClientID%>").value == "")
        {
           alert("First Name Field can not be blank");
           document.getElementById("<%=txtfirstname.ClientID%>").focus();
           return false;
        }
        if (document.getElementById("<%=txtlastname.ClientID%>").value == "")
             {
                 alert("Last Name Feild can not be blank");
             document.getElementById("<%=txtlastname.ClientID%>").focus();
             return false;
         }
        if (document.getElementById("<%=txtemail.ClientID %>").value == "") {
            alert("Email id can not be blank");
            document.getElementById("<%=txtemail.ClientID %>").focus();  
                return false;  
             }  
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;  
            var emailid=document.getElementById("<%=txtemail.ClientID %>").value;  
            var matchArray = emailid.match(emailPat);  
            if (matchArray == null)  
            {  
               alert("Your email address seems incorrect. Please try again.");  
                document.getElementById("<%=txtemail.ClientID %>").focus();
                return false;
        }

        var userid;
        var controlId = document.getElementById("<%=txtmobileNumber.ClientID %>");
        userid = controlId.value;
        var val;
        val = /^[0-9]+$/;
        var digits = /\d(10)/;
        if (userid == "") {
            alert("Please Enter Your PhoneNo");
            document.getElementById("<%=txtmobileNumber.ClientID%>").focus();
                        return false;
                    }
                    if (val.test(userid))
                    {
                    
                       
                    }
                    else
                    {
                        document.getElementById("<%=txtmobileNumber.ClientID%>").focus();
                        alert("Phone Number Should be In digits");
                        return false;
                    }
        var Nationality = document.getElementById("<%=Drpnationality.ClientID%>");
        var selectedNation = Nationality.options[Nationality.selectedIndex].innerHTML;
        if (selectedNation == "Select")
        {
            alert("Nationality can not be blank");
            document.getElementById("<%=Drpnationality.ClientID%>").focus();
            return false;
        }
        else
        {

        }
       
        if (document.getElementById("<%=exampleInputdate.ClientID %>").value == "") {
            alert("Date of Birth cannot be blank");
            document.getElementById("<%=exampleInputdate.ClientID %>").focus();
            return false;
        }
        var rb = document.getElementById("<%=RadioButtonList1.ClientID%>");
        var radio = rb.getElementsByTagName("input");
        var isChecked = false;
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {
                isChecked = true;
                break;
            }
        }
        if (!isChecked) {
            document.getElementById("<%=RadioButtonList1.ClientID%>").focus();
            alert("Please select Gender");
            return false;
        }
       

        if (document.getElementById("<%=txtaddress.ClientID %>").value == "") {
            alert("Address cannot be blank");
             document.getElementById("<%=txtaddress.ClientID %>").focus();
             return false;
         }

        if (document.getElementById("<%=txtpostcode.ClientID %>").value == "") {
            alert("PostCode cannot be blank");
            document.getElementById("<%=txtpostcode.ClientID %>").focus();
            return false;
        }
        if (document.getElementById("<%=txtNI.ClientID %>").value == "") {
            alert("National Insurance Number cannot be blank");
            document.getElementById("<%=txtNI.ClientID %>").focus();
            return false;
        }

        var ddlAddressProf = document.getElementById("<%=DrpAddress.ClientID%>");
        var selectedText = ddlAddressProf.options[ddlAddressProf.selectedIndex].innerHTML;
        if (selectedText == "Select") {
            alert("Address Proof can not be blank");
            document.getElementById("<%=DrpAddress.ClientID%>").focus();
            return false;
        }
        else {


        }
        if (selectedText == "YES") {

            if (document.getElementById("<%=Adrupl.ClientID %>").value == "") {
                alert("Please Upload Address Proof");
                document.getElementById("<%=Adrupl.ClientID %>").focus();
                return false;
            }
            else
            {

            }


        }

        var ddlTraining = document.getElementById("<%=Drptraining.ClientID%>");
        var selectedText = ddlTraining.options[ddlTraining.selectedIndex].innerHTML;
        if (selectedText == "Select") {
            alert("Training Section can not be blank");
            document.getElementById("<%=Drptraining.ClientID%>").focus();
            return false;
        }

        else
        {


        }
        if (selectedText == "YES") {

            if (document.getElementById("<%=Inputdate3.ClientID %>").value == "") {
                alert("Issue Date Canot be blank");
                document.getElementById("<%=Inputdate3.ClientID %>").focus();
                return false;
            }
            else {

            }
            if (document.getElementById("<%=Inputdate4.ClientID %>").value == "") {
                alert("Expiry Date Canot be blank");
                document.getElementById("<%=Inputdate4.ClientID %>").focus();
                return false;
            }
            else {
            
}
            if (document.getElementById("<%=tfupld.ClientID %>").value == "") {
                alert("Please Upload Your Training Certificate");
                document.getElementById("<%=tfupld.ClientID %>").focus();
                return false;
            }
            else {

            }


        }


        }
         
       
        
     </script> 
     <script type="text/javascript">
         function checkDOB() {

             var dateString = document.getElementById("<%= exampleInputdate.ClientID %>").value;
            var myDate = new Date(dateString);
            
            var today = new Date();
      
            if (myDate > today) {
               
                alert("You cannot enter a Date of birth as future date!");
                document.getElementById("<%= exampleInputdate.ClientID %>").value = "";
                 return false;

             }
             return true;
         }
         </script>
     <script type="text/javascript">
         function checkIssueDate() {

             var dateString = document.getElementById("<%= Inputdate.ClientID %>").value;
            var myDate = new Date(dateString);
            
            var today = new Date();
      
            if (myDate > today) {
               
                alert("You cannot enter a DBS issue date as future date!");
                 document.getElementById("<%= Inputdate.ClientID %>").value = "";
                 return false;

             }
             return true;
         }
  
     </script>
  
     <script type="text/javascript">
         function checkTrainingIssueDate() {

             var dateString = document.getElementById("<%= Inputdate3.ClientID %>").value;
            var myDate = new Date(dateString);
            
            var today = new Date();
      
            if (myDate > today) {
               
                alert("You cannot enter a Training issue date as future date!");
                 document.getElementById("<%= Inputdate3.ClientID %>").value = "";
                 return false;

             }
             return true;
         }

     </script>
      <script type="text/javascript">
          function checkRenewalDate() {

              var dateString = document.getElementById("<%= RenewalInputdate.ClientID %>").value;
            var myDate = new Date(dateString);
            
            var today = new Date();
      
            if (myDate < today) {
               
                alert("You cannot enter Renewal date as past date!");
                 document.getElementById("<%= RenewalInputdate.ClientID %>").value = "";
                  return false;

              }
              return true;
          }

      </script>

    <script type="text/javascript">
        function checkExpiryDate() {

            var dateString = document.getElementById("<%= Inputdate2.ClientID %>").value;
            var myDate = new Date(dateString);
            
            var today = new Date();
      
            if (myDate < today) {
               
                alert("You cannot enter  DBS Expiry date as past date!");
                 document.getElementById("<%= Inputdate2.ClientID %>").value = "";
                return false;

            }
            return true;
        }

    </script>
    <script type="text/javascript">
        function checkTrainingExpiryDate() {

            var dateString = document.getElementById("<%= Inputdate4.ClientID %>").value;
            var myDate = new Date(dateString);
            
            var today = new Date();
      
            if (myDate < today) {
               
                alert("You cannot enter  Training Expiry date as past date!");
                 document.getElementById("<%= Inputdate4.ClientID %>").value = "";
                return false;

            }
            return true;
        }

    </script>
        <script type="text/javascript">
            function validateFileSize() {
                var uploadControltraining = document.getElementById('<%= tfupld.ClientID %>');
                
                if (uploadControltraining.files[0].size > 2097152) {
                    alert("Training certificate size should be leass than 2 Mb");
                    document.getElementById("<%= tfupld.ClientID %>").value = "";
                    return false;
                }
            }
        </script>
     <script type="text/javascript">
         function validateFileSize1() {
            
                var uploadAddressProof = document.getElementById('<%= Adrupl.ClientID %>');
             if (uploadAddressProof.files[0].size > 2097152) {
                    alert("Address proof file size should be leass than 2 Mb");
                    document.getElementById("<%= Adrupl.ClientID %>").value = "";
                      return false;
                  }
                
         }
     </script>
          
<style type="text/css">

.fileUpload {
    position: relative;
    overflow: hidden;
    margin: 10px;
}

.fileUpload span {
    background: #3dbddf !important;
    color: #fff !important;
    display: inline-block;
    font-weight: 400;
    color: #fff;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-color: transparent;
    border: 1px solid transparent;
    padding: 4px;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: 15px;
}

.fileUpload input.upload {
    position: absolute;
    top: 0;
    right: 0;
    margin: 0;
    padding: 0;
    font-size: 20px;
    cursor: pointer;
    opacity: 0;
    filter: alpha(opacity=0);
}

#imgpreview {
 height: 150px;
           }

.uploadLabel {
  border: 1px solid #ccc;
  display: inline-block;
  padding: 2px 10px;
  cursor: pointer;
  border-radius: 15px;
  background-color: #3dbddf;
  color: #ffffff;
}

.uploadButton{
  display:none;
}

</style>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">

   
       </asp:ScriptManager>
   <div class="row">
    <div class="col-lg-3">

                     <div class="iq-card">
                        <div class="iq-card-header d-flex justify-content-between">
                          <div class="iq-header-title">
                          <h4 class="card-title custome_Heading">Application No:<asp:Label ID="AppLabel" CssClass="custome_Label" runat="server" Text="Label"></asp:Label></h4>
                           </div>
                        </div>
                        <div class="iq-card-body">
                              <div class="form-group">
                                 <div class="add-img-user profile-img-edit">
                                    <img class="profile-pic img-fluid" id="imgpreview" src="images/user/11.png" alt="profile-pic" >
                                    <div class="p-image">
                                        <div class="fileUpload">
                                             <label class="uploadLabel">
                                                  <span>File Upload</span>
                     <asp:FileUpload ID="ImageUpload" accept=".png,.jpg,.jpeg,.gif"    runat="server" class="uploadButton" onchange="showpreview(this);" />
                                            </label>

        </div>
                                        <%--<input class="file-upload" type="file" accept="image/*">--%>
                                    </div>
                                 </div>
                             
                              </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
                              <div class="form-group">
                                 <label>Position/Role:</label>
                                 <asp:DropDownList ID="Drpposition" runat="server" OnSelectedIndexChanged="Drpposition_SelectedIndexChanged" class="form-control" AutoPostBack="true" >
                                            <asp:ListItem Text="Select" Value= “-1”></asp:ListItem>
                                            <asp:ListItem Text="HCA" Value=”1”></asp:ListItem>
                                            <asp:ListItem Text="RGN" Value=”2”></asp:ListItem>
                                 </asp:DropDownList>
                              </div>
                            <div name="RGN" runat="server">
                              <div class="form-group">
                                 <label for="furl" id="PinNo" runat="server">NMC Pin No(If Applicable):</label>
                                 <asp:TextBox ID="NMCPin" MaxLength="15" runat="server" class="form-control" placeholder="NMC Pin"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                 <label for="turl" id="RenId" runat="server">Renewal Date(If Applicable):</label>
                                  <input type="date" class="form-control"  onmouseleave="checkRenewalDate()"  id="RenewalInputdate" name="datemain" value="" runat="server">

                              
                              </div>
                             
                    </div>


              </ContentTemplate>
             </asp:UpdatePanel>
                        </div>
                     </div>

                  </div>
                  <div class="col-lg-9">
                     <div class="iq-card">
                        <div class="iq-card-header d-flex justify-content-between">
                           <div class="iq-header-title">
                              <h4 class="card-title">Personal Information</h4>
                           </div>
                        </div>

                        <div class="iq-card-body">
                           <div class="new-user-info">
                                 <div class="row">
                                    <div class="form-group col-md-6">
                                       <label for="fname">First Name:</label>
                                       <asp:TextBox id="txtfirstname" MaxLength="25" class="form-control" runat="server" placeholder="First Name" ></asp:TextBox>
                                        </div>
                                    <div class="form-group col-md-6">
                                       <label for="lname">Last Name:</label>
                                        <asp:TextBox ID="txtlastname" MaxLength="25" class="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                       <label for="add1">Email:</label>
                                        <asp:TextBox ID="txtemail"  class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                                     
                                    </div>
                                    <div class="form-group col-md-6">
                                       <label for="mobno">Mobile Number:</label>
                                        <asp:TextBox ID="txtmobileNumber"  class="form-control" runat="server" placeholder="Mobile Number"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-12">
                                       <label>Nationality:</label>
                                        <asp:DropDownList ID="Drpnationality" class="form-control" runat="server">
                                            <asp:ListItem Text="Select" Value= “-1”></asp:ListItem>
                                            <asp:ListItem Text="United Kingdom" Value=”1”></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group col-md-6">
                                    <label for="altconno">Date of Birth:</label>
                                    <input type="date" class="form-control" onmouseleave="checkDOB()" id="exampleInputdate" name="dateofbirth" value="" runat="server">
                              
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="email" class="width100">Gender:</label>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Male" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="2" ></asp:ListItem>
                                        </asp:RadioButtonList>
                                
                                     </div>
                                    </div>
                                </div> 
                                 <hr>
                                 <h5 class="mb-3 heading_Main">Address Details</h5>
                                 <div class="row">
                                    <div class="form-group col-md-12">
                                       <label for="uname">Address:</label>
                                        <asp:TextBox ID="txtaddress" MaxLength="30" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                       <label for="pass">Street / City:</label>
                                       <asp:TextBox ID="txtstreet" MaxLength="15" runat="server" class="form-control" placeholder="Street / City"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                       <label for="rpass">Country:</label>
                                        <asp:DropDownList ID="county"  class="form-control" runat="server">
                                            <asp:ListItem Text="Select" Value= “-1”></asp:ListItem>
                                            <asp:ListItem Text="Staffordshire" Value=”1”></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                      <div class="form-group col-md-6">
                                       <label for="pass">Postal Code:</label>
                                       <asp:TextBox ID="txtpostcode" MaxLength="15" class="form-control" runat="server" placeholder="Postal Code"></asp:TextBox>
                                          </div>
                                 </div>
                               <hr>
                                <h5 class="mb-3 heading_Main">Other Details</h5>
                              
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
                               <div class="row">
                               <div class="form-group col-md-6">
                                       <label for="uname">National Insurance NO:</label>
                                    <asp:TextBox ID="txtNI" MaxLength="15" runat="server" placeholder="National Insurance NO" class="form-control"></asp:TextBox>
                                   </div>
                                <div class="form-group col-md-6">
                                       <label for="uname">DBS Uniquie Number :</label>       
                                    <asp:TextBox ID="txtDBS" MaxLength="15" runat="server" placeholder="DBS Uniquie Number" class="form-control"></asp:TextBox>
                                   </div>
                                     <div class="form-group col-md-6">
                                       <label for="uname">CRD/DBS Type :</label>     
                                         <asp:DropDownList ID="DrpDBS" runat="server" class="form-control">
                                            <asp:ListItem Text="Select" Value= “-1”></asp:ListItem>
                                            <asp:ListItem Text="Enhanced" Value=”1”></asp:ListItem>
                                            <asp:ListItem Text="Normal" Value=”2”></asp:ListItem>
                                         </asp:DropDownList>  
                                    
                                   </div> 
                                   <div class="form-group col-md-6">
                                       <label for="uname">DBS Issue Date :</label>
                                 <input type="date" class="form-control" onmouseleave="checkIssueDate()" id="Inputdate" runat="server" name="DBSIssueDate" value="">
                              
                                   </div>
                                   <div class="form-group col-md-6">
                                       <label for="uname">DBS Expiry Date :</label>
                                 <input type="date" class="form-control"  onmouseleave="checkExpiryDate()"  id="Inputdate2" runat="server" name="ExDate" value="">
                              
                                   </div>
                                   <div class="form-group col-md-6">
                                       <label for="uname" class="width100">Do you have full UK Driving Licence :</label>     
                                       
                                    <div class="custom-control custom-radio custom-control-inline">
                                        <asp:RadioButtonList ID="DrivingList" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="No" Value="2" ></asp:ListItem>
                                        </asp:RadioButtonList>
                             
                           </div>
                           
                                   </div>
                            
                                   <div class="form-group col-md-6">
                                 <label for="uname">Proof of Address:</label>
                      
                                 <asp:DropDownList ID="DrpAddress"  runat="server" class="form-control" OnSelectedIndexChanged="DrpAddress_SelectedIndexChanged" AutoPostBack="true">
                                         <asp:ListItem Text="Select" Value= “-1”></asp:ListItem>
                                            <asp:ListItem Text="YES" Value=”1”></asp:ListItem>
                                            <asp:ListItem Text="NO" Value=”2”></asp:ListItem>
                                 </asp:DropDownList>
                                 
                                   </div>
                

                                   <div class="form-group col-md-6 custom_Formgroupcolor" runat="server" id="adrp" name="adrpu">
                                       <label for="uname" id="upl" runat="server" class="width100">Upload Proof of Address:</label>
                                       
                                            
                                     <asp:FileUpload ID="Adrupl"  onchange="validateFileSize1();" runat="server" />
                       
                                   </div>
                          
                           
                                   <div class="form-group col-md-6">
                                       
                                 <label for="uname">Training Attented Or Not:</label>
                           <%--  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
         <ContentTemplate>--%>
                                  <asp:DropDownList ID="Drptraining"  runat="server" class="form-control" OnSelectedIndexChanged="Drptraining_SelectedIndexChanged" AutoPostBack="true">
                                 <asp:ListItem Text="Select" Value= “-1”></asp:ListItem>
                                 <asp:ListItem Text="YES" Value=”1”></asp:ListItem>
                                 <asp:ListItem Text="NO" Value=”2”></asp:ListItem>
                                 </asp:DropDownList>
                            <%--</ContentTemplate>
                                 <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Drptraining" EventName="SelectedIndexChanged" />
    </Triggers>--%>
      <%--  </asp:UpdatePanel>--%>
                                   </div>

             
                                   <div class="form-group col-md-6" runat="server" id="IsDate">
                                       <label for="uname" runat="server" id="lbl_ISdate">Issue Date :</label>
                                 <input type="date" class="form-control" runat="server"  onmouseleave="checkTrainingIssueDate()" id="Inputdate3" name="trDate" >
                              
                                   </div>
                                   <div class="form-group col-md-6" runat="server" id="ExDate">
                                       <label for="uname" runat="server" id="lbl_ExDate">Expiry Date :</label>
                                 <input type="date" class="form-control" runat="server" onmouseleave="checkTrainingExpiryDate()" id="Inputdate4" name="exDate" >
                              
                                   </div>
                                   <div class="form-group col-md-6 custom_Formgroupcolor" runat="server" id="crtraining">
                                       <label for="uname" id="tlbl" runat="server" class="width100">
                                           Upload the training certificate:
                                       </label>         

                                       <asp:FileUpload ID="tfupld"  onchange="validateFileSize();" runat="server"/>
                                   </div>
                  
                                   </div> 
             </ContentTemplate>
        </asp:UpdatePanel>
                                   
       
             
                                 <div class="checkbox">
                                    <label>
                                        <input class="mr-2" type="checkbox">Enable Two-Factor-Authentication</label>
                                 </div>
                          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
         <ContentTemplate>
             <div>
                    <asp:Button ID="Staffadd" runat="server" class="btn btn-primary" Text="AddewUser" onclientclick="return validate()"   OnClick="Staffadd_Click" CausesValidation="False" />
                 </div>
                        </ContentTemplate>
        </asp:UpdatePanel>   
                            
                          


                           </div>
                        </div>

                     </div>
                  </div>
  

            </form>
</asp:Content>
     