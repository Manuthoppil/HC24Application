<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HC24Application.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
      <meta charset="utf-8"/>
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
      <title>HC24 - Login</title>
      <!-- Favicon -->
      <%--<link rel="shortcut icon" href="images/favicon.ico" /--%>
      <!-- Bootstrap CSS -->
      <link rel="stylesheet" href="css/bootstrap.min.css"/>
      <!-- Typography CSS -->
      <link rel="stylesheet" href="css/typography.css"/>
      <!-- Style CSS -->
      <link rel="stylesheet" href="css/style.css"/>
      <!-- Responsive CSS -->
      <link rel="stylesheet" href="css/responsive.css"/>
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=InputEmail.ClientID %>").value == "") {
                alert("Password and UserName Doesn't Match");
                return false;
            }
            if (document.getElementById("<%=InputPassword.ClientID %>").value == "") {
                alert("Password and UserName Doesn't Match");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <!-- loader Start -->
     <%-- <div id="loading">--%>
         <%--<div id="loading-center">
         </div>--%>
     <%-- </div>--%>
      <!-- loader END -->
        <!-- Sign in Start -->
        <section class="sign-in-page">
            <div class="container sign-in-page-bg mt-5 p-0">
                <div class="row no-gutters">
                    <div class="col-md-6 text-center">
                        <div class="sign-in-detail text-white">
                            <a class="sign-in-logo mb-5" href="#"><img src="images/hc24-logo.gif" class="img-fluid" alt="logo"/></a>
                            <div class="owl-carousel" data-autoplay="true" data-loop="true" data-nav="false" data-dots="true" data-items="1" data-items-laptop="1" data-items-tab="1" data-items-mobile="1" data-items-mobile-sm="1" data-margin="0">
                                <div class="item">
                                    <img src="images/login/1.png" class="img-fluid mb-4" alt="logo"/>
                                    <h4 class="mb-1 text-dark ">Trusted solutions for helathcare staffing</h4>
                                    <p class="text-dark">Are you a Qualified Nurse or an HCA</p>
                                </div>
                                <div class="item">
                                    <img src="images/login/2.png" class="img-fluid mb-4" alt="logo"/>
                                     <h4 class="mb-1 text-dark ">Trusted solutions for helathcare staffing</h4>
                                    <p class="text-dark">Are you a Qualified Nurse or an HCA</p>
                                </div>
                                <div class="item">
                                    <img src="images/login/3.png" class="img-fluid mb-4" alt="logo"/>
                                    <h4 class="mb-1 text-dark ">Trusted solutions for helathcare staffing</h4>
                                    <p class="text-dark">Are you a Qualified Nurse or an HCA</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 position-relative">
                        <div class="sign-in-from">
                            <h1 class="mb-0 sign-in-head">Sign in</h1>
                           
                            <p>Enter your email address and password to access admin panel.</p>
                     
                                <div class="form-group">
                                    <label/ for="exampleInputEmail1">Email address</label>
                                    <asp:TextBox ID="InputEmail" runat="server" class="form-control mb-0" placeholder="Enter email"></asp:TextBox>
                                  
                                </div>
                                <div class="form-group">
                                    <label/ for="exampleInputPassword1">Password</label>
                                    <a href="#" class="float-right">Forgot password?</a>
                                    <asp:TextBox ID="InputPassword" runat="server" class="form-control mb-0" placeholder="Password"></asp:TextBox>
                                    
                                </div>
                                <div class="d-inline-block w-100">
                                    <div class="custom-control custom-checkbox d-inline-block mt-2 pt-1">
                                        <input type="checkbox" class="custom-control-input" id="customCheck1"/>
                                        <label class="custom-control-label" for="customCheck1">Remember Me</label>
                                    </div>

<asp:Button ID="Login" class="btn btn-primary float-right" runat="server" Text="Sign in" OnClientClick="return validate()" OnClick="Login_Click" />
                                    
                                </div>
                               <%-- <div class="sign-info">
                                    <span class="dark-color d-inline-block line-height-2">Don't have an account? <a href="#">Sign up</a></span>
                                    <ul class="iq-social-media">
                                        <li><a href="#"><i class="ri-facebook-box-line"></i></a></li>
                                        <li><a href="#"><i class="ri-twitter-line"></i></a></li>
                                        <li><a href="#"><i class="ri-instagram-line"></i></a></li>
                                    </ul>
                                </div>--%>
                   
    
                        </div>
                    </div>
                </div>
            </div>
   
        </section>

        <!-- Sign in END -->
      <!-- Optional JavaScript -->
      <!-- jQuery first, then Popper.js, then Bootstrap JS -->
      <script src="js/jquery.min.js"></script>
      <script src="js/popper.min.js"></script>
      <script src="js/bootstrap.min.js"></script>
      <!-- Appear JavaScript -->
      <script src="js/jquery.appear.js"></script>
      <!-- Countdown JavaScript -->
      <script src="js/countdown.min.js"></script>
      <!-- Counterup JavaScript -->
      <script src="js/waypoints.min.js"></script>
      <script src="js/jquery.counterup.min.js"></script>
      <!-- Wow JavaScript -->
      <script src="js/wow.min.js"></script>
      <!-- Apexcharts JavaScript -->
      <script src="js/apexcharts.js"></script>
      <!-- Slick JavaScript -->
      <script src="js/slick.min.js"></script>
      <!-- Select2 JavaScript -->
      <script src="js/select2.min.js"></script>
      <!-- Owl Carousel JavaScript -->
      <script src="js/owl.carousel.min.js"></script>
      <!-- Magnific Popup JavaScript -->
      <script src="js/jquery.magnific-popup.min.js"></script>
      <!-- Smooth Scrollbar JavaScript -->
      <script src="js/smooth-scrollbar.js"></script>
      <!-- Chart Custom JavaScript -->
      <script src="js/chart-custom.js"></script>
      <!-- Custom JavaScript -->
      <script src="js/custom.js"></script>
    </form>
</body>
</html>
