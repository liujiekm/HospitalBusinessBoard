<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="WYYY.HDGM.Web.Content" %>

<!DOCTYPE html>
<html lang="zh-CN">

<head runat="server">
    <!--Bootstrap 不支持 IE 古老的兼容模式。为了让 IE 浏览器运行最新的渲染模式下,加入如下内容-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--让部分国产浏览器默认采用高速模式渲染页面-->
    <meta name="renderer" content="webkit" />
    <!--Bootstrap3 是移动设备优先的为了确保适当的绘制和触屏缩放，增加如下内容-->
    <%--<meta name="viewport" content="width=device-width, initial-scale=1" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>院长综合查询系统</title>


    <!--Bootstrap css-->
    <link href="content/bootstrap/bootstrap.min.css" rel="stylesheet">
    <!--子定义主页样式-->
    <link href="content/css/content.css" rel="stylesheet" />


    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="content/js/html5shiv.min.js"></script>
      <script src="content/js/respond.min.js"></script>
    <![endif]-->
</head>
<body>

    <!--Bootstrap js-->
    <script src="content/js/jquery/jquery.min.js"></script>
    <script src="content/bootstrap/bootstrap.js"></script>


    <script type="text/javascript">
        var xs1 = [], xs2 = [], xd3 = [];
        var content1 = [], content2 = [], content3 = [];

    </script>

    <form id="form1" runat="server">


        <div class="container-fluid">

            <div class="row">
                <!--左侧导航-->
                <div class="leftNavigation col-md-2 col-sm-2 col-xs-2">

                    <img class="img-responsive center-block" style="padding-top: 30px" src="content/img/newHome/logo.png" />
                    <ul class="nav nav-pills nav-stacked text-center navleft">
                        <li role="presentation"><a href="#">首页</a></li>
                        <li role="presentation"><a href="#">门诊</a></li>
                        <li role="presentation"><a href="#">住院</a></li>
                        <li role="presentation"><a href="#">药品</a></li>
                        <li role="presentation"><a href="#">资产</a></li>
                        <li role="presentation"><a href="#">财务人事</a></li>
                        <li role="presentation"><a href="#">患者体验</a></li>

                    </ul>
                    <img class="img-responsive center-block lenovo" src="content/img/newHome/lenovo.png" />
                </div>


                <!--右侧内容区-->
                <div class="col-md-10 col-sm-10 col-xs-10 col-md-offset-2">

                    <!--顶部功能区-->
                    <div id="div_header" class="row">
                        <div class="col-md-7 col-sm-7 col-xs-7">

                            <div style="float: left; padding-right: 20px">
                                <div style="margin-top: 25px; float: left; font-size: 30px; color: white">
                                    <p><%=DateTime.Now.ToString("yyyy年MM月dd日")+" "+DateTime.Now.ToString("dddd",new System.Globalization.CultureInfo("zh-cn")) +" "+DateTime.Now.ToString("tt hh:mm") %></p>
                                </div>


                            </div>



                        </div>

                        <!--用户功能区-->
                        <div class="col-md-5 col-sm-5 col-xs-5">

                            <div style="float: right; padding-right: 20px">
                                <div style="margin-top: 25px; float: left; font-size: 30px; color: white; margin-right: 30px;">
                                    <p>您好! <span id="currentUser">陈</span>院长 </p>
                                </div>
                                <div style="float: left; padding-right: 10px; padding-top: 20px;">
                                    <img src="content/img/newHome/QUIT.png" class="img-responsive" style="height: 48px; width: 48px;">
                                </div>

                            </div>

                        </div>
                    </div>

                    <!--中间报表内容-->
                    <div class="row">
                        <!--中间页面内容-->
                        <div class="col-md-12 col-sm-12 col-xs-12 reportMain">
                            <!--中间页面顶部标识-->
                            <div class="row">
                                <div class="col-md-2">
                                    <span class="glyphicon glyphicon-arrow-left returnPage" aria-hidden="true"></span>
                                </div>
                                <div class="col-md-8"></div>
                                <div class="col-md-2 moduleIndicate">
                                    <!--当前页面模块内容-->
                                    <span class="lead">医生签到</span>
                                </div>
                            </div>
                            <div class="row contentRow">
                                



                                    <div class="col-md-8"></div>
                                    <div class="col-md-4"></div>
                                
                            </div>







                            <!--引入echart主文件-->
                            <script src="content/js/echarts.js"></script>
                            <script src="CustomJsLibrary/home/option.js"></script>




                        </div>
                    </div>
                </div>


                <!--底部logo-->
                <div id="div_footer" class="row" style="height: 60px;">
                    <div style="padding-top: 20px;" class="col-md-2">
                    </div>
                    <div class="col-md-8"></div>
                    <div style="padding-top: 15px;" class="col-md-2">
                        <img src="content/img/newHome/Hname.png" height="24" width="204" class="hospitalLogo" />
                    </div>

                </div>
            </div>



        </div>
    </form>
</body>
</html>

