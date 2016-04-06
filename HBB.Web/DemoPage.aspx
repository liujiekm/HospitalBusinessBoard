<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="DemoPage.aspx.cs" Inherits="HBB.Web.DemoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <script type="text/javascript">
             $(function () {
                 
                 $('#returnLink').click(function () {
                     
                     window.open('www.baidu.com');

                 });
                 $('#moduleName').text("医生");
             });


    </script>

</asp:Content>
<%--<!--table or echart DOM 放置在下面-->--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
    <div class="row">
        <div class="col-md-7">
            <div class="row">
                
               <div class="col-md-12">
                   
               </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                   
               </div>
            </div>
            

        </div>
        <div class="col-md-5"></div>

    </div>
    


</asp:Content>
<%--<!--对 table or echart DOM 一些脚本操作放置在下面-->--%>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">
    
   
</asp:Content>
