<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="SignInStatics.aspx.cs" Inherits="HBB.Web.SignInStatics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .chart {
            width: 100%;
            /*padding: 10px;*/
        }

        .chartNav {
            float: right;
        }

            .chartNav > li > a {
                color: #108CCD;
                padding: 5px;
            }

                .chartNav > li > a:hover, .nav > li > a:focus {
                    background: #4aa0e9;
                    color: white;
                }

        .nextInfo {
            position: relative;
            top: 55%;
        }

        .personPanel {
            padding-top: 40px;
        }

            .personPanel > ul > li > a {
                margin-right: 0px;
                border-radius: 0px;
            }

                .personPanel > ul > li > a:hover,
                .personPanel > ul > li > a:focus {
                    background: #F7F7F7;
                }

            .personPanel > ul > li > a {
                color: black;
            }

            .personPanel > ul {
                border-bottom: 0px;
            }

        .personContent {
            background: white;
            /*height:600px;*/
            border-left: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
            border-right: 1px solid #ddd;
            /*overflow-y: scroll;*/
        }

        .tabContent {
            height: 85%;
            overflow-y: auto;
        }

        .table {
            margin-bottom: 5px;
        }

            .table > thead > tr > td,
            .table > tbody>tr > td {
                width: 50%;
            }

        @media only screen and (min-width: 1024px) {
            .chart {
                height: 230px;
                
            }

            .nextInfoContainer {
                height: 230px;
            }

            .personContent {
                height: 437px;
            }
        }

        @media only screen and (min-width: 1280px) {
            .chart {
                height: 300px;
                
            }

            .nextInfoContainer {
                height: 300px;
            }

            .personContent {
                height: 580px;
            }
        }

        @media only screen and (min-width: 1440px) {
            .chart {
                height: 300px;
                
            }

            .nextInfoContainer {
                height: 300px;
            }

            .personContent {
                height: 580px;
            }
        }
    </style>
    <script>
        function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
            try {
                var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
                var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var seconds = date.getSeconds();
                var milliseconds = date.getMilliseconds();
                // return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;
                return month + "-" + day;
            } catch (ex) {
                return "";
            }
        }
        function jsonDateFormatForHourAndMinutes(jsonDate) {//json日期格式转换为正常格式
            try {
                var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
                var hours = date.getHours();
                var minutes = date.getMinutes();
                //return hours + "." + minutes;
                return hours * 60 + minutes;
            } catch (ex) {
                return "";
            }
        
        }
        //获取一天的分钟总数
        function getTotalMinutesOfDay(jsonDate) {
            try {
                var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
                var hours = date.getHours();
                var minutes = date.getMinutes();
                //return hours * 60 + minutes;

                var hour = hours ? "0" + hours : hours;
                var minute = minutes ? "0" + minutes : minutes;
                return hours + ":" + minutes;
            } catch (ex) {
                return "";
            }
        }
        $(function () {

            $('#returnLink').click(function () {

                window.open('Home.aspx', '_self');

            });
            $('#moduleName').text("医生签到");
            $('#home').addClass('active');
        });
    </script>
    <script>
        var arraySignInQuanty = new Array();

        $(function () {
            //1、定义方法：获取签到数量
            function GetSignInQuanty(time) {
                if(time == "undefined"){time = "today";}
                $.ajax({
                    type: "get",
                    contentType: "text/json",
                    dataType: "json",
                    async: false,
                    url: '../handler/DoctorRegisterHandler.ashx?type=drmi',
                    success: function (data) {
                        var json = eval(data);
                        signInChangeOption.xAxis[0].data.length = 0;
                        signInChangeOption.series[0].data.length = 0;
                        signInChangeOption.series[1].data.length = 0;
                        if (json != null) {
                            for (var i = 0, l = json.length; i < l; i++) {

                                if (i == 0) {
                                    signInChangeOption.series[0].data.push(0);//总量
                                    signInChangeOption.series[1].data.push(json[i].RegisteredDoctorQuanty); //增量
                                    signInChangeOption.xAxis[0].data.push(json[i].TimeSpan + ":00"); //x轴坐标
                                }
                                else if (i == l) {
                                    signInChangeOption.series[0].data.push(json[i - 1].RegisteredDoctorQuanty);

                                }
                                else {
                                    signInChangeOption.series[0].data.push(json[i - 1].RegisteredDoctorQuanty);
                                    signInChangeOption.series[1].data.push(json[i].RegisteredDoctorQuanty - json[i - 1].RegisteredDoctorQuanty);
                                    signInChangeOption.xAxis[0].data.push(json[i].TimeSpan + ":00");
                                }
                            }
                            arraySignInQuanty = json;
                        };
                        //var ecConfig = require('echarts/config');
                        //function eConsole(param) {
                        //    alert("eConsole");
                        //};
                        //signInChange.on(ecConfig.EVENT.CLICK, eConsole);

                    },
                    error: function () {
                        //alert("获取失败！");
                    }
                });

                
            }
            //执行方法
            GetSignInQuanty();
            //GetSignInDetails("6");
 
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">

    <div class="col-md-7">
        <!--chart 控制项-->
        <div class="row">
            <div class="col-md-12">
                <ul class="nav nav-pills chartNav">
                    <li role="presentation"><a href="#" onclick="">今天</a></li>
                    <li role="presentation"><a href="#">昨天</a></li>
                    <li role="presentation"><a href="#">前天</a></li>
                    <li role="presentation"></li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="chart" id="signInChange"></div>

            </div>
        </div>
        <!--chart 控制项-->
        <div class="row">
            <div class="col-md-12">
                <ul class="nav nav-pills chartNav">
                    <li role="presentation"><a href="#">近1年</a></li>
                    <li role="presentation"><a href="#">近1月</a></li>
                    <li role="presentation"><a href="#">近1周</a></li>
                    <li role="presentation"></li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="chart" id="signInPerson" ></div>

            </div>
        </div>
    </div>

    <div class="col-md-1">
        <div class="row nextInfoContainer">
            <div class="col-md-12 nextInfo">

                <img class="img-responsive" src="content/img/delt.png" />
            </div>
        </div>

        <div class="row nextInfoContainer">
            <div class="col-md-12 nextInfo">
                <img class="img-responsive" src="content/img/deltLeft.png" />
            </div>
        </div>
    </div>

    <!--选中的全院签到变化图中的具体人员列表-->
    <div class="col-md-4 personPanel" rol="tabpanel">


        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#signIned" aria-controls="signIned" role="tab" data-toggle="tab" id="a_signIn">已签到</a></li>
            <li role="presentation"><a href="#notSignIn" aria-controls="notSignIn" role="tab" data-toggle="tab">未签到</a></li>
        </ul>
        <div class="tab-content personContent">
            <div role="tabpanel" class="tab-pane  active" id="signIned">
                <table class="table text-center">
                    <thead>
                        <tr>
                            <td>姓名</td>
                            <td>签到时间</td>
                        </tr>
                    </thead>
                </table>
                <div class="tabContent" style="height:530px;overflow-y:auto;">
                    <table class="table table-hover text-center">
                        <tbody id="tb_signIned" >
                            
                          <%--  <tr >
                                <td>xxxxx</td>
                                <td>xxxxxxx</td>
                            </tr>--%>
                        </tbody>
                    </table>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="notSignIn">
                <table class="table table-hover text-center">
                    <thead>
                        <tr>
                            <td>姓名</td>
                            <td>排班时间</td>
                        </tr>
                    </thead>
                </table>
                <div class="tabContent" style="height:530px;overflow-y:auto;">
                    <table class="table table-hover text-center">
                        <tbody id="tb_UnsignIned" >
                           <%-- <tr>
                                <td>uuuu</td>
                                <td>uuuu</td>
                            </tr>--%>
                        </tbody>

                    </table>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">

        <!--引入echart主文件-->
       <script src="content/js/knockout-3.3.0.js"></script>
        <script src="content/js/echarts.js"></script>
    <script src="content/js/knockout-3.3.0.js"></script>
    <script src="CustomJsLibrary/home/option.js"></script>
    <script type="text/javascript">
        $(function () {
            GetSignInDetails(8);
            GetUnSignInDetails(8)
            //alert("sdf");
        })

        function GetSignInHistory(item) {
            var userID = item;
                $.ajax({
                    type: "get",
                    contentType: "text/json",
                    dataType: "json",
                    async: true,
                    url: '../Handler/DoctorRegisterHandler.ashx?type=drdifp&timetype=week&userid=' + userID,
                    success: function (data) {
                        var json = eval(data);
                        //self.SignInHistory.removeAll();
                        personSignInOption.xAxis[0].data.length = 0;
                        personSignInOption.series[0].data.length = 0;
                        personSignInOption.series[1].data.length = 0;
                        var signInPerson = echarts.init(document.getElementById('signInPerson'));
                        //
                        signInPerson.clear();

                        if (json != null) {
                            for (var i = 0; i < json.length; i++) {
                                if (json[i].TimeType == "1") {
                                    personSignInOption.xAxis[0].data.push(jsonDateFormat(json[i].ArrangeWorkTime) + "上午");
                                    personSignInOption.series[0].data.push(jsonDateFormatForHourAndMinutes(json[i].ArrangeWorkTime));//排班时间点
                                    personSignInOption.series[1].data.push(jsonDateFormatForHourAndMinutes(json[i].RegisterTime));//签到时间点
                                }
                                if (json[i].TimeType == "2") {
                                    personSignInOption.xAxis[0].data.push(jsonDateFormat(json[i].ArrangeWorkTime) + "下午"); //x轴坐标  
                                    personSignInOption.series[0].data.push(jsonDateFormatForHourAndMinutes(json[i].ArrangeWorkTime));//排班时间点
                                    personSignInOption.series[1].data.push(jsonDateFormatForHourAndMinutes(json[i].RegisterTime));//签到时间点
                                }
                                
                            }
                            signInPerson.setOption(personSignInOption);
                        }

                    },
                    error: function () {
                        //alert("获取失败！");
                    }
                });
            }

        //$(function () {
           
            //2、定义方法：获取签到医生列表
            function GetSignInDetails(timePoint) {
                // var timePoint = item.TimeSpan;
                if (timePoint == 'undefined') { timePoint = 8; }
                $.ajax({
                    type: "get",
                    contentType: "text/json",
                    dataType: "json",
                    async: true,
                    url: '../handler/DoctorRegisterHandler.ashx?type=drdi&timePoint=' + timePoint,
                    success: function (data) {
                        var json = eval(data);
                        //var tr = $('#tr_signIned').val();
                        var tableStr = "";
                        if (json != null) {
                            $("#tb_signIned").empty();
                            for (var i = 0, l = json.length; i < l; i++) {
                                tableStr += "<tr onClick='GetSignInHistory(" + json[i].UserID + ");'><td >" + json[i].DoctorName + "</td><td>" + json[i].RegisterTime + "</td></tr>";
                            }
                            $("#tb_signIned").append(tableStr);
                        }
                    },
                    error: function () {
                        //alert("获取失败！");
                    }
                });
            }
            //3、定义方法：获取未签到医生列表
            function GetUnSignInDetails(timePoint) {
                // var timePoint = item.TimeSpan;
                if (timePoint == 'undefined') { timePoint = 8; }
                $.ajax({
                    type: "get",
                    contentType: "text/json",
                    dataType: "json",
                    async: true,
                    url: '../handler/DoctorRegisterHandler.ashx?type=durdi&timePoint=' + timePoint,
                    success: function (data) {
                        var json = eval(data);
                        var tableStr = "";
                        if (json != null) {
                            $("#tb_UnsignIned").empty();
                            for (var i = 0, l = json.length; i < l; i++) {
                                tableStr += "<tr onClick='GetSignInHistory(" + json[i].UserID + ");'><td >" + json[i].DoctorName + "</td><td>" + json[i].RegisterTime + "</td></tr>";
                            }
                            $("#tb_UnsignIned").append(tableStr);
                        }
                    },
                    error: function () {
                        //alert("获取失败！");
                    }
                });
            }


            require.config({
                paths: {
                    echarts: 'content/js'

                }
            });
            require(
                [
                    'echarts',
                    'echarts/chart/bar',
                    'echarts/chart/line'
                ],
                function (ec) {
                    echarts = ec;
                    var signInChange = ec.init(document.getElementById('signInChange'));
                    var signInPerson = ec.init(document.getElementById('signInPerson'));

                    signInChange.setOption(signInChangeOption);
                    signInPerson.setOption(personSignInOption);


                    var ecConfig = require('echarts/config');
                    
                    function eConsole(param) {
                        var tempValue = arraySignInQuanty[param.dataIndex].TimeSpan
                        GetSignInDetails(tempValue);
                        GetUnSignInDetails(tempValue);
                        var signInText = tempValue+"点签到"
                        $("#a_signIn").empty();
                        $("#a_signIn").append(signInText);
                    }
                    signInChange.on(ecConfig.EVENT.CLICK, eConsole);

                });

        //});
     </script>

</asp:Content>
