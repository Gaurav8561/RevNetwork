<%@ Page Title="" Language="C#" MasterPageFile="~/Contact.Master" AutoEventWireup="true" CodeBehind="ContactDefault.aspx.cs" Inherits="RevNetwork.ContactDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


     <style>

/* Make the image fully responsive */
  .carousel-inner img {
    width: 100%;
    height: 100%;
  }

</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    



    <main class="page-section">
    




<div style="text-align: center; font-weight: bold;">
    <p>Products</p>
</div>



        <div id="banner" class="carousel slide" data-ride="carousel">
  <ul class="carousel-indicators">
    <li data-target="#banner" data-slide-to="0" class="active"></li>
    <li data-target="#banner" data-slide-to="1"></li>
    <li data-target="#banner" data-slide-to="2"></li>
  </ul>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="../Resource/ub_img1.jpg" alt="" style="width:100%">
      <%--<div class="carousel-caption">
        <h3>Los Angeles</h3>
        <p>We had such a great time in LA!</p>
      </div> --%>  
    </div>
    <div class="carousel-item">
      <img src="../Resource/ub_img2.jpg" alt="" style="width:100%">
      <%--<div class="carousel-caption">
        <h3>Chicago</h3>
        <p>Thank you, Chicago!</p>
      </div>--%>   
    </div>
    <div class="carousel-item">
      <img src="../Resource/ub_img3.jpg" alt="" style="width:100%">
      <%--<div class="carousel-caption">
        <h3>New York</h3>
        <p>We love the Big Apple!</p>
      </div>--%>   
    </div>
  </div>
  <a class="carousel-control-prev" href="#banner" data-slide="prev">
    <span class="carousel-control-prev-icon"></span>
  </a>
  <a class="carousel-control-next" href="#banner" data-slide="next">
    <span class="carousel-control-next-icon"></span>
  </a>
</div>

        <br />
<div style="text-align: center; font-weight: bold;">
    <p>News & Promotions</p>
</div>




<div id="lowerbanner" class="carousel slide" data-ride="carousel">
  <ul class="carousel-indicators">
    <li data-target="#lowerbanner" data-slide-to="0" class="active"></li>
    <li data-target="#lowerbanner" data-slide-to="1"></li>
	<li data-target="#lowerbanner" data-slide-to="2"></li>
	<li data-target="#lowerbanner" data-slide-to="3"></li>
    <li data-target="#lowerbanner" data-slide-to="4"></li>
	<li data-target="#lowerbanner" data-slide-to="5"></li>
    <%--<li data-target="#lowerbanner" data-slide-to="2"></li>--%>
  </ul>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="../Resource/lb_img1.jpg" alt="" >
      <%--<div class="carousel-caption">
        <h3>Los Angeles</h3>
        <p>We had such a great time in LA!</p>
      </div> --%>  
    </div>
    <div class="carousel-item">
      <img src="../Resource/lb_img2.jpg" alt="" >
    </div>
	<div class="carousel-item">
      <img src="../Resource/lb_img3.jpg" alt="" >
    </div>
	<div class="carousel-item">
      <img src="../Resource/lb_img4.jpg" alt="" >
    </div>
    <div class="carousel-item">
      <img src="../Resource/lb_img5.jpg" alt="" >
    </div>
	<div class="carousel-item">
      <img src="../Resource/lb_img6.jpg" alt="" >
    </div>
  </div>
  <a class="carousel-control-prev" href="#lowerbanner" data-slide="prev">
    <span class="carousel-control-prev-icon"></span>
  </a>
  <a class="carousel-control-next" href="#lowerbanner" data-slide="next">
    <span class="carousel-control-next-icon"></span>
  </a>
</div>







    </main>







    


</asp:Content>


