<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HBB.Web.Home" %>

<%@ Import Namespace="System.Globalization" %>

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
    <title>医院业务看板</title>


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
<body class="img-responsive">

    <!--Bootstrap js-->
    <script src="content/js/jquery/jquery.min.js"></script>
    <script src="content/bootstrap/bootstrap.js"></script>
        <script src="CustomJsLibrary/Gloable.js"></script>
    <style type="text/css">
        .rowContent {
            background: url('content/img/newHome/30black.png') repeat;
            color: white;
            height: 110px;
        }

        .pannelContent {
            background: url('/content/img/newHome/30green.png') repeat;
            margin-right: 10px;
            width: 16.5%;
        }

       .pannelContentWarning {
            background: url('/content/img/newHome/30blue.png') repeat;
            margin-right: 10px;
            width: 16.5%;
        }

        .bottomContent {
            float: right;
            margin-right: 20px;
        }


    </style>
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
                        <p>医院业务看板</p>
                        <li>&nbsp;</li>
                        <li role="presentation" class="active"><a href="Home.aspx">首页</a></li>
                        <li role="presentation"><a href="Outpatient.aspx">门诊</a></li>
                        <li role="presentation"><a href="Hospitalization.aspx">住院</a></li>
                        <li role="presentation"><a href="Medicine.aspx">药品</a></li>
                        <li role="presentation"><a id="operation" href="OperationMain.aspx">手术</a></li>


                    </ul>
                    <img class="img-responsive center-block" src="content/img/演示.png" width="120" height="40" />
                    <img class="img-responsive center-block lenovo" src="content/img/newHome/lenovo.png" />
                </div>


                <!--右侧内容区-->
                <div class="col-md-10 col-sm-10 col-xs-10 col-md-offset-2">

                    <!--顶部功能区-->
                    <div id="div_header" class="row">
                        <div class="col-md-6 col-sm-6 col-xs-6">

                            <div style="float: left">
                                <div style="margin-top: 25px; float: left; font-size: 28px; color: white; margin-left: 20px\0">
                                    <div id="Date" style="float:left;width:300px;"></div>
                                    <ul class="clock" style="float:left;width:150px;">
                                        <li id="hours"></li>
                                        <li>:</li>
                                        <li id="min"></li>
                                        <li>:</li>
                                        <li id="sec"></li>
                                    </ul>

                                    <script type="text/javascript">
                                        $(document).ready(function () {

                                            var monthNames = ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"];
                                            var dayNames = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"]


                                            var newDate = new Date();

                                            newDate.setDate(newDate.getDate());
                                            $('#Date').html(newDate.getFullYear() + '年' + monthNames[newDate.getMonth()] + newDate.getDate() + '日 ' + dayNames[newDate.getDay()]);
                                            setInterval(function () {

                                                var seconds = new Date().getSeconds();

                                                $("#sec").html((seconds < 10 ? "0" : "") + seconds);
                                            }, 1000);

                                            setInterval(function () {

                                                var minutes = new Date().getMinutes();

                                                $("#min").html((minutes < 10 ? "0" : "") + minutes);
                                            }, 1000);

                                            setInterval(function () {

                                                var hours = new Date().getHours();

                                                $("#hours").html((hours < 10 ? "0" : "") + hours);
                                            }, 1000);
                                        });
                                    </script>


                                </div>


                            </div>


                            <%-- <img class="img-responsive" src="content/img/newHome/logo.png" />--%>
                        </div>
                        <!--顶部导航-->
                        <%--  <div class="col-md-7">
                        </div>--%>
                        <!--用户功能区-->
                        <div class="col-md-4 col-sm-4 col-xs-4" style="padding-right: 0px;">

                            <div style="float: right;">
                                <div style="margin-top: 25px; float: left; font-size: 28px; color: white; margin-right: 15px;">
                                    <p>您好! <span id="currentUser">陈</span>院长 </p>
                                </div>
                                <div style="float: left; padding-top: 20px;">
                                    <img src="content/img/newHome/QUIT.png" class="img-responsive" style="height: 48px; width: 48px;">
                                </div>

                            </div>

                        </div>

                        <div class="col-md-2"></div>
                    </div>

                    <!--中间报表内容-->
                    <div class="row reportRow">
                        <div class="col-md-10 col-sm-10 col-xs-10" style="padding-left: 0px; padding-right: 0px;">

                            <!--医生签到-->
                            <div class="row text-center">
                                <div class="col-md-6 col-sm-6 col-xs-6 div_nav">
                                    <div class="row">
                                        <div class="col-md-2 col-sm-2 col-xs-2" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <img class="img-responsive" src="content/img/newHome/outpatientSignin.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                    <p class="imgText text-center">医生签到</p>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-4 col-sm-4 col-xs-4" style="background: url('/content/img/newHome/30green.png') repeat; margin: 5px; padding-left: 10px; padding-right: 10px; height: 100px; left: 10px;">
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p class="lead">上午 <strong id="morningSignInRate">95.2</strong>%</p>
                                                </div>
                                            </div>
                                            <div class="row" style="height: 10px">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p>已签到 <span id="morningHasSignIn">952 </span>人</p>
                                                    <p>应签到 <span id="morningShouldSignIn">10000 </span>人</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-4 col-sm-4 col-xs-4" style="background: url('/content/img/newHome/30green.png') repeat; margin: 5px; padding-left: 10px; padding-right: 10px; height: 100px; left: 10px;">
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">

                                                    <p class="lead">下午 <strong id="afternoonSignInRate">95.2</strong>%</p>
                                                </div>
                                            </div>
                                            <div class="row" style="height: 10px">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p>已签到 <span id="afternoonHasSignIn">952 </span>人</p>
                                                    <p>应签到 <span id="afternoonShouldSignIn">10000 </span>人</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class=" leftGo col-md-2 col-sm-2 col-xs-2 ">
                                            <a href="SignInStatics.aspx">
                                                <img class="img-responsive" src="content/img/newHome/into.png" />
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <div style="margin-top: 45px; position: absolute; right: 48.7%;">

                                    <img class="img-responsive" src="content/img/newHome/delta.png" />

                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-6 div_nav div_chart">
                                    <div>
                                        <div id="doctorSignInRate" class="chart"></div>
                                    </div>
                                </div>

                            </div>
                            <!--坐诊情况-->
                            <div class="row ">
                                <div class="col-md-6 div_nav">
                                    <div class="row">
                                        <div class="col-md-2" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <img class="img-responsive" src="content/img/newHome/medicalService.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                    <p class="imgText text-center">坐诊情况</p>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-4 text-right" style="vertical-align: middle; margin: 5px; padding-left: 10px; padding-right: 10px; padding-top: 10px; height: 100px;">
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p class="lead" style="padding-bottom: 5px;">目前候诊</p>
                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p class="lead" style="padding-bottom: 5px;">已完成就诊</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-4" style="margin: 5px; padding-left: 10px; padding-right: 10px; padding-top: 10px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <p class="lead" style="padding-bottom: 5px;"><span id="waitingNum">498 </span>人</p>
                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <p class="lead" style="padding-bottom: 5px;"><span id="treatedNum">502</span> 人</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class=" leftGo col-md-2 ">
                                            <a href="MedicalServiceSituation.aspx">
                                                <img class="img-responsive" src="content/img/newHome/into.png" />
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <div style="margin-top: 45px; position: absolute; right: 48.7%;">
                                    <img class="img-responsive" src="content/img/newHome/delta.png" />
                                </div>

                                <div class="col-md-6 div_nav div_chart">
                                    <div>
                                        <div id="delayedDept" class="chart"></div>
                                    </div>
                                </div>

                            </div>
                            <!--急诊-->
                            <div class="row ">
                                <div class="col-md-6 div_nav">
                                    <div class="row">
                                        <div class="col-md-2" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <img class="img-responsive" src="content/img/newHome/emergency.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                    <p class="imgText text-center">急诊</p>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-4 text-right" style="margin: 5px; padding-left: 10px; padding-right: 10px; padding-top: 10px; height: 100px;">
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p class="lead" style="padding-bottom: 5px;">重症留观</p>
                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">

                                                    <p class="lead" style="padding-bottom: 5px;">抢救区</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-4" style="margin: 5px; padding-left: 10px; padding-right: 10px; padding-top: 10px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <p class="lead" style="padding-bottom: 5px;"><span id="severeObservingQuanty">39</span> 人</p>
                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">

                                                    <p class="lead" style="padding-bottom: 5px;"><span id="firstAidQuanty">5</span>人</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-2 leftGo">
                                            <a href="EmergencyTreatment.aspx">
                                                <img class="img-responsive" src="content/img/newHome/into.png" />
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <div style="margin-top: 45px; position: absolute; right: 48.7%;">
                                    <%-- <img class="img-responsive" />--%>
                                </div>

                                <div class="col-md-6 div_nav div_chart" style="padding-left: 12px;">
                                    <div class="row" style="margin-left: 0px; margin-right: 0px;">
                                        <div class="col-md-2" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <img class="img-responsive" src="content/img/newHome/operation.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                    <p class="imgText text-center">手术</p>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-8" style="width:72%">
                                            <div id="operationStats" class="chart"></div>
                                        </div>

                                        <div class="col-md-2 rightGo">
                                            <a href="OperationMain.aspx">
                                                <img class="img-responsive" src="content/img/newHome/into.png" />
                                            </a>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <!--住院-->
                            <div class="row text-center ">
                                <div class="col-md-6 div_nav">
                                    <div class="row">
                                        <div class="col-md-2" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <img class="img-responsive" src="content/img/newHome/hospitalized.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                    <p class="imgText text-center">住院</p>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-4" style="background: url('/content/img/newHome/30green.png') repeat; margin: 5px; padding-left: 10px; padding-right: 10px; height: 100px; left: 10px;">
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p class="lead" style="margin-bottom: 0px">在院人数</p>
                                                    <p class="lead" style="margin-bottom: 0px"><span id="hospitalizedNum">2800</span>人</p>

                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p>昨日出院 <span id="leaveYeaterday">503 </span>人</p>
                                                    <p>昨日入院 <span id="IncomeYeaterday">620 </span>人</p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-4" style="background: url('/content/img/newHome/30green.png') repeat; margin: 5px; padding-left: 10px; padding-right: 10px; left: 10px;">
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p class="lead">空床</p>

                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 mobilePadding">
                                                    <p>额定 <span id="ratedBeds">60</span></p>
                                                    <p>加床 <span id="addedBeds">54</span></p>
                                                    <p>虚拟  <span id="vitrualBeds">12 </span></p>
                                                </div>

                                            </div>
                                        </div>

                                        <div class=" leftGo col-md-2 ">
                                            <a href="AdmissionDischarge.aspx">
                                                <img class="img-responsive" src="content/img/newHome/into.png" />
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <div style="margin-top: 45px; position: absolute; right: 48.7%;">
                                    <img class="img-responsive" src="content/img/newHome/delta.png" />
                                </div>

                                <div class="col-md-6 div_nav div_chart">
                                    <div>
                                        <div id="specifiedEmptyBed" class="chart"></div>
                                    </div>
                                </div>

                            </div>


                            <!--门诊就医-->
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row rowContent">
                                        <div class="col-md-2">
                                            <div class="row">
                                                <div class="col-md-7" style="margin-top: 20px; margin-left: -5px;">
                                                    <img class="img-responsive" src="content/img/门诊就医时长.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="margin-left: -30px; margin-left: -40px\0;">
                                                    <p class="imgText text-center">门诊就医</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-10" style="left: -3%;">
                                            <div class="row" style="margin-left: -50px;">
                                                <div class="col-md-2">
                                                    <p class="text-nowrap">门诊时长</p>
                                                </div>
                                                <div class="col-md-10"></div>
                                            </div>
                                            <div class="row" style="margin-left: -40px;">
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">预约</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="appointmentLastMonth">1.62</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent" >
                                                            <p class="text-right text-nowrap"> 天</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">候诊</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="awaitingDiagnosis">7.5</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">分钟</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">就诊</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="diagnosis">5.1</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">分钟</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">缴费</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="payFees">2.9</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">分钟</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">取药</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="medicineReceiving">9.4</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">分钟</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2" style="padding-left: 0px; padding-right: 0px; width: 6%;">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <%--<p class="text-center text-nowrap">门诊爽约率</p>--%>
                                                        </div>

                                                    </div>
                                                    <div class="row" style="padding-left: 15px; padding-top: 10px;">
                                                        <div class="col-md-12">
                                                            <%-- <p class="lead text-center"><strong id="">0.5</strong>%</p>--%>
                                                        </div>
                                                    </div>

                                                </div>



                                            </div>
                                        </div>
                                        <a href="PatientExperience.aspx" style="position: absolute; right: 0%;">
                                            <img class="img-responsive" src="content/img/newHome/into.png" />
                                        </a>

                                    </div>


                                    <div class="row">
                                    </div>


                                </div>

                            </div>

                            <!--特检时长-->
                            <div class="row" style="margin-top: 10px;">

                                <div class="col-md-12">
                                    <div class="row rowContent">
                                        <div class="col-md-2">
                                            <div class="row">
                                                <div class="col-md-7" style="margin-top: 20px; margin-left: -5px;">
                                                    <img class="img-responsive" src="content/img/特检时长.png" />
                                                    <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="margin-left: -30px; margin-left: -40px\0;">
                                                    <p class="imgText text-center">特检时长</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-10" style="left: -3%;">
                                            <div class="row" style="margin-left: -50px;">
                                                <div class="col-md-2">
                                                    <p class="text-nowrap">特检时长</p>
                                                </div>
                                                <div class="col-md-10"></div>
                                            </div>
                                            <div class="row" style="margin-left: -40px;">
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">X光</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="xray">1.62</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3" style="float: right; margin-right: 5px;">
                                                            <p class="text-right">天</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">CT</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="ct">7.5</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">天</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">MRI</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="mri">5.1</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">天</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">B超</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="bc">2.9</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">天</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2 pannelContent">
                                                    <div class="row">
                                                        <div class="col-md-5" style="margin-left: -5px;">
                                                            <p class="text-left text-nowrap">内窥镜</p>
                                                        </div>
                                                        <div class="col-md-7"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="lead text-center"><strong id="cu">9.4</strong></p>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9"></div>
                                                        <div class="col-md-3 bottomContent">
                                                            <p class="text-right text-nowrap">天</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2" style="padding-left: 0px; padding-right: 0px; width: 6%;">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                        </div>

                                                    </div>


                                                </div>



                                            </div>
                                        </div>
                                        <a href="SpecialInspectorExperience.aspx" style="position: absolute; right: 0%;">
                                            <img class="img-responsive" src="content/img/newHome/into.png" />
                                        </a>

                                    </div>


                                    <div class="row">
                                    </div>


                                </div>

                            </div>






                            <!--引入echart主文件-->
                            <script src="content/js/echarts.js"></script>
                            <script src="CustomJsLibrary/home/option.js"></script>
                            <script src="CustomJsLibrary/home/request.js"></script>



                        </div>

                        <!---->
                        <div class="col-md-2">
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


        </div>
    </form>
</body>
</html>
