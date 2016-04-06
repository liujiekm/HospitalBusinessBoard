<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeOld.aspx.cs" Inherits="HBB.Web.Home" %>

<!DOCTYPE html>
<html lang="zh-CN">

<head runat="server">
    <!--Bootstrap 不支持 IE 古老的兼容模式。为了让 IE 浏览器运行最新的渲染模式下,加入如下内容-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--让部分国产浏览器默认采用高速模式渲染页面-->
    <meta name="renderer" content="webkit" />
    <!--Bootstrap3 是移动设备优先的为了确保适当的绘制和触屏缩放，增加如下内容-->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>院长综合查询系统</title>


    <!--Bootstrap css-->
    <link href="content/bootstrap/bootstrap.min.css" rel="stylesheet">
    <!--子定义主页样式-->
    <link href="content/css/home.css" rel="stylesheet" />


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
    <script src="content/js/jquery.animateNumber.min.js"></script>

    <script type="text/javascript">
        var xs1=[], xs2=[], xd3=[];
        var content1=[], content2=[], content3=[];
       
    </script>
    <form id="form1" runat="server">


        <div class="container-fluid">
            <!--顶部功能区-->
            <div id="div_header" class="row" style="background-color: #EBEAE6; height: 100px; border-bottom-color: #C3C3C3;">
                <div class="col-md-3" style="padding-top: 20px">
                    <img class="img-responsive" src="content/img/logo.png" />
                </div>
                <!--顶部导航-->
                <div class="col-md-7">
                </div>
                <!--用户功能区-->
                <div class="col-md-2" style="padding-top: 20px">

                    <div style="float: right; padding-right: 20px">
                        <div style="float: left; padding-right: 10px">
                            <img src="content/img/User.png" class="img-responsive" style="height: 48px; width: 48px;">
                        </div>
                        <div style="margin-top: 15px; float: left">
                            <p>陈院长 您好</p>
                        </div>
                    </div>

                </div>
            </div>

            <!--中间报表内容-->
            <div class="row" style="height: 660px; padding-top: 10px; padding-left: 10px;">
                <div class="col-md-3">
                    <!--左侧导航-->
                    <!--门诊-->
                    <div class="row div_nav" id="outpatient">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>门诊</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="content/img/index_门诊.png" />
                                </div>
                                <div class="col-sm-8">
                                    <div style="float: right" class="div_navContent">
                                        <p class="text-right">昨日挂号量</p>
                                        <p class="p_navContent text-right">153,45 人次</p>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <!--住院-->
                    <div class="row div_nav" id="inhospital">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>住院</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="content/img/index_住院.png" />
                                </div>
                                <div class="col-sm-8">
                                    <div style="float: right" class="div_navContent">
                                        <p class="text-right">昨日出\入院</p>
                                        <p class="p_navContent text-right">500\600 人次</p>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <!--药品-->
                    <div class="row div_nav" id="pharmaceuticals">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>药品</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="content/img/index_药品.png" />
                                </div>
                                <div class="col-sm-8">
                                    <div style="float: right" class="div_navContent">
                                        <p class="text-right">昨日门诊\住院药占比</p>
                                        <p class="p_navContent text-right">67%\80%</p>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <!--资产-->
                    <div class="row div_nav" id="property">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>资产</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="content/img/index_资产.png" />
                                </div>
                                <div class="col-sm-8">
                                    <div style="float: right" class="div_navContent">
                                        <p class="text-right">本月至今出库\入库</p>
                                        <p class="p_navContent text-right">14.5万元\563.4万元</p>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <!--财务人事-->
                    <div class="row div_nav" id="finance">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>财务人事</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="content/img/index_财务人事.png" />
                                </div>
                                <div class="col-sm-8">
                                    <div style="float: right" class="div_navContent">
                                        <p class="text-right">上月工资总额</p>
                                        <p class="p_navContent text-right">153,45 万元</p>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <!--患者体验-->
                    <div class="row div_nav" id="experiance">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>患者体验</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="content/img/index_患者体验.png" />
                                </div>
                                <div class="col-sm-8">
                                    <div style="float: right" class="div_navContent">
                                        <p class="text-right">上月平均预约时间</p>
                                        <p class="p_navContent text-right">2.12天</p>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                    <!--引入echart主文件-->
                    <script src="content/js/echarts.js"></script>
                    <script src="CustomJsLibrary/home/option.js"></script>
                    <script src="CustomJsLibrary/home/request.js"></script>
                    <!--设置导航点击样式 以及切换逻辑-->
                    <script src="CustomJsLibrary/home/navigation.js"></script>
                    
                </div>

                <!--报表显示区域-->
                <div class="col-md-9">
                    <div class="reportMain">
                        <!--第一个chart 标题及内容-->
                        <div class="row">
                            <div class="col-md-12" style="background: #4AA0E9; color: white; height: 20px">
                                挂号统计
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-10" style="padding-left: 0px">
                                <div id="chart_1" class="chart">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <ul class="nav nav-stacked nav-choice" style="border: 1px solid #4AA0E9;">
                                    <li role="presentation" class="active"><a href="#">近7天</a></li>
                                    <li role="presentation"><a href="#">近一月</a></li>
                                    <li role="presentation"><a href="#">近一年</a></li>
                                </ul>
                                <div class="chartMore">
                                    <a href="#">更多>></a>
                                </div>

                            </div>

                        </div>
                        <!--第二个chart 标题及内容-->
                        <div class="row">
                            <div class="col-md-12" style="background: #4AA0E9; height: 20px"></div>

                        </div>
                        <div class="row">
                            <div class="col-md-10" style="padding-left: 0px">
                                <div id="chart_2" class="chart"></div>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <!--第三个chart 标题及内容-->
                        <div class="row">
                            <div class="col-md-12" style="background: #4AA0E9; height: 20px"></div>

                        </div>
                        <div class="row">
                            <div class="col-md-10" style="padding-left: 0px">
                                <div id="chart_3" class="chart"></div>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <!--按天,月切换数据-->
                        <script src="CustomJsLibrary/home/timespanChoice.js"></script>

                    </div>




                </div>




            </div>


            <!--底部logo-->
            <div id="div_footer" class="row navbar-fixed-bottom" style="background: #EEEDE9; height: 60px;">
                <div style="padding-top: 20px;" class="col-md-2">
                    <img src="content/img/Hname.png" height="24" width="204" style="padding-left: 20px" />
                </div>
                <div class="col-md-8"></div>
                <div style="padding-top: 20px;" class="col-md-2">
                    <img src="content/img/lenovo.png" height="17" width="214" style="padding-right: 20px" />
                </div>
            </div>


            <!--隐藏域标记用户选中的是哪种类型的报表类型-->
            <input type="hidden" id="hdn_reportType" value="outpatient" />
        </div>
    </form>
</body>
</html>
