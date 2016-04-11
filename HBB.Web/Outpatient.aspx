<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Outpatient.aspx.cs" Inherits="HBB.Web.Outpatient" %>
<%@ Import Namespace="System.Globalization"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="content/js/jquery/jquery.min.js"></script>
    <script src="content/js/knockout-3.3.0.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#outpatient').addClass('active');

            var OutpatientViewModel = function () {
                var self = this;
                //变量区
                //挂号人次统计列表
                self.VisitList = ko.observableArray();
                //实名制挂号人次统计列表
                self.RealNameList = ko.observableArray();
                //预存挂号人次统计列表
                self.BeforeMoneyList = ko.observableArray();
                //预存总额统计列表
                self.BeforeMoneyAllList = ko.observableArray();
                //门诊收费总额统计列表
                self.IncomeList = ko.observableArray();
                //预约人次统计列表
                self.AppointmentList = ko.observableArray();
                //单日统计
                //昨日挂号人次
                self.YsVisitNum = ko.observable();
                //今日挂号人次
                self.ToDayVisitNum = ko.observable();
                //昨日实名挂号人次
                self.YsRealNameNum = ko.observable();
                //昨日预存挂号人次
                self.YsBeforeMoneyNum = ko.observable();
                //昨日预存总额
                self.YsBeforeMoneyTotal = ko.observable();
                //昨日预约人次
                self.YsAppointmentNum = ko.observable();
                //昨日门诊收入
                self.YsIncomeNum = ko.observable();
                //今日门诊收入
                self.ToDayIncomeNum = ko.observable();
                
                //方法区
                //挂号人次，返回每天预约人数
                self.GetVisitList = function () {
                    var temp = new Date();
                    var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
                    temp.setDate(temp.getDate() - 7);
                    var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';

                    var VisitedChart = require('echarts').init(document.getElementById('register'));
                    VisitedChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/OutPatient.ashx?type=gh&sd=' + sd + '&ed=' + ed,
                        url: baseUrl+'OPA/RV/' + sd + '/' + ed,
                        success: function (data) {
                            var json = eval(data);
                            self.VisitList.removeAll();
                            OutpatientVisited.series[0].data.length = 0;
                            OutpatientVisited.xAxis[0].data.length = 0;
                            if (json != null) {
                                self.ToDayVisitNum(json[0].Visitors)
                                self.YsVisitNum(json[1].Visitors);
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.VisitList.push(json[i]);
                                    if (i < 7) {
                                        OutpatientVisited.xAxis[0].data.push(json[i].TimeStemp.substring(5));
                                        OutpatientVisited.series[0].data.push(json[i].Visitors);
                                        
                                    }
                                }
                            }
                            var VisitedChart = require('echarts').init(document.getElementById('register'));
                            VisitedChart.hideLoading();
                            VisitedChart.setOption(OutpatientVisited);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //获取实名挂号列表
                self.GetRealNameList = function () {
                    var temp = new Date();
                    var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
                    temp.setDate(temp.getDate() - 7);
                    var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';
                    
                    var RealNameChart = require('echarts').init(document.getElementById('realNameRegistration'));
                    RealNameChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/OutPatient.ashx?type=smgh&sd=' + sd + '&ed=' + ed,
                        url: baseUrl+'OPA/RNV/' + sd + '/' + ed,
                        success: function (data) {
                            var json = eval(data);
                            self.RealNameList.removeAll();
                            RealNamePie.series[0].data.length = 0;
                            RealNamePie.series[1].data.length = 0;
                            if (json != null) {
                                //添加饼图
                                self.YsRealNameNum(json[1].Visitors);
                                if (self.YsRealNameNum() != "") {
                                    RealNamePie.series[0].data.push(self.YsRealNameNum());
                                    RealNamePie.series[1].data.push(self.YsVisitNum() - self.YsRealNameNum());
                                    //var temp0 = new Object;
                                    //temp0.value = self.YsRealNameNum();
                                    //temp0.name = '实名挂号人次';
                                    //RealNamePie.series[0].data.push(temp0);
                                    //var temp1 = new Object;
                                    //temp1.name = '其他挂号人次';
                                    //temp1.value = self.YsVisitNum() - self.YsRealNameNum();
                                    //RealNamePie.series[1].data.push(temp1);
                                }
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.RealNameList.push(json[i]);
                                    
                                }
                            }
                            var RealNameChart = require('echarts').init(document.getElementById('realNameRegistration'));
                            RealNameChart.hideLoading();
                            RealNameChart.setOption(RealNamePie);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //获取预存挂号列表
                self.GetBeforeMoneyList = function () {
                    var temp = new Date();
                    var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
                    temp.setDate(temp.getDate() - 7);
                    var sd = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '00:00:00';

                    var BeforeMoneyChart = require('echarts').init(document.getElementById('prestoreRegistration'));
                    BeforeMoneyChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/OutPatient.ashx?type=ycgh&sd=' + sd + '&ed=' + ed,
                        url: baseUrl+'OPA/IV/' + sd + '/' + ed,
                        success: function (data) {
                            var json = eval(data);
                            self.BeforeMoneyList.removeAll();
                            BeforeMoneyPie.series[0].data.length = 0;
                            BeforeMoneyPie.series[1].data.length = 0;
                            if (json != null) {
                                self.YsBeforeMoneyNum(json[1].Visitors);
                                if (self.YsBeforeMoneyNum() != "") {
                                    BeforeMoneyPie.series[0].data.push(self.YsBeforeMoneyNum());
                                    BeforeMoneyPie.series[1].data.push(self.YsVisitNum() - self.YsBeforeMoneyNum());
                                    //var temp0 = new Object;
                                    //temp0.value = self.YsBeforeMoneyNum();
                                    //temp0.name = '预存挂号人次';
                                    //BeforeMoneyPie.series[0].data.push(temp0);
                                    //var temp1 = new Object;
                                    //temp1.name = '其他挂号人次';
                                    //temp1.value = self.YsVisitNum() - self.YsBeforeMoneyNum();
                                    //BeforeMoneyPie.series[0].data.push(temp1);
                                }
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.BeforeMoneyList.push(json[i]);
                                    
                                }
                            }
                            var BeforeMoneyChart = require('echarts').init(document.getElementById('prestoreRegistration'));
                            BeforeMoneyChart.hideLoading();
                            BeforeMoneyChart.setOption(BeforeMoneyPie);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //获取预存金额列表
                self.GetBeforeMoneyAllList = function () {
                    var temp = new Date();
                    var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
                    temp.setDate(temp.getDate() - 7);
                    var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';
                    
                    var BeforeMoneyChart = require('echarts').init(document.getElementById('prestoreRegistration'));
                    BeforeMoneyChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/OutPatient.ashx?type=yc&sd=' + sd + '&ed=' + ed,
                        url: baseUrl+'OPA/IF/' + sd + '/' + ed,
                        success: function (data) {
                            var json = eval(data);
                            self.BeforeMoneyAllList.removeAll();
                            if (json != null) {
                                self.YsBeforeMoneyTotal(parseInt(json[1].TotolMoney/10000));
                                
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.BeforeMoneyAllList.push(parseInt(json[i]/10000));
                                }
                            }
                            var BeforeMoneyChart = require('echarts').init(document.getElementById('prestoreRegistration'));
                            BeforeMoneyChart.hideLoading();
                            BeforeMoneyChart.setOption(BeforeMoneyPie);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //获取门诊收入列表
                self.GetIncomeList = function () {
                    var temp = new Date();
                    var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
                    temp.setDate(temp.getDate() - 7);
                    var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';

                    var IncomeChart = require('echarts').init(document.getElementById('outpatientIncoming'));
                    IncomeChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/OutPatient.ashx?type=mz&sd=' + sd + '&ed=' + ed,
                        url: baseUrl+'OPA/IA/' + sd + '/' + ed,
                        success: function (data) {
                            var json = eval(data);
                            self.IncomeList.removeAll();
                            OutpatientIncome.series[0].data.length = 0;
                            OutpatientIncome.xAxis[0].data.length = 0;
                            if (json.length != 0) {
                                self.YsIncomeNum(parseInt(json[1].TotolMoney/10000));
                                self.ToDayIncomeNum(parseInt(json[0].TotolMoney/10000));
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.IncomeList.push(json[i]);
                                    if (i < 7) {
                                        OutpatientIncome.xAxis[0].data.push(json[i].TimeStemp.substring(5));
                                        OutpatientIncome.series[0].data.push(parseInt(json[i].TotolMoney/10000));
                                    }
                                }
                            }
                            var IncomeChart = require('echarts').init(document.getElementById('outpatientIncoming'));
                            IncomeChart.hideLoading();
                            IncomeChart.setOption(OutpatientIncome);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //获取预约挂号列表
                self.GetAppointmentList = function () {
                    var temp = new Date();
                    var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
                    temp.setDate(temp.getDate() - 7);
                    var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';
                    
                    var AppointmentChart = require('echarts').init(document.getElementById('prestoreRate'));
                    AppointmentChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/OutPatient.ashx?type=yy&sd=' + sd + '&ed=' + ed,
                        url:baseUrl+ 'OPA/FV/' + sd + '/' + ed,
                        success: function (data) {
                            var json = eval(data);
                            self.AppointmentList.removeAll();
                            OutpatientAppointment.series[0].data.length = 0;
                            OutpatientAppointment.xAxis[0].data.length = 0;
                            if (json != null) {
                                self.YsAppointmentNum(json[1].Visitors);
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.AppointmentList.push(json[i]);
                                    if (i < 7) {
                                        OutpatientAppointment.xAxis[0].data.push(json[i].TimeStemp.substring(5));
                                        OutpatientAppointment.series[0].data.push(parseInt(json[i].Visitors / self.VisitList()[i].Visitors * 100));
                                    }
                                }
                            }
                            var AppointmentChart = require('echarts').init(document.getElementById('prestoreRate'));
                            AppointmentChart.hideLoading();
                            AppointmentChart.setOption(OutpatientAppointment);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //事件区
                self.GetVisitList();
                self.GetIncomeList();
                    self.GetRealNameList();
                    self.GetBeforeMoneyList();
                    self.GetBeforeMoneyAllList();
                    self.GetAppointmentList();
            }
            ko.applyBindings(new OutpatientViewModel);
        });
        function format(num) {
            if (num == "" || num== null) return 0;
            return (num.toFixed(0) + '').replace(/\d{1,3}(?=(\d{3})+(\.\d*)?$)/g, '$&,');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">

    <!--挂号-->
    <div class="row text-center">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/newHome/medicalService.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">挂号</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="margin-top: 5px;margin-bottom: 5px; ; padding-top: 10px;padding-left:0px;padding-right:0px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead" style="padding-bottom: 5px;">昨日挂号总数 <span id="registerYesterday" data-bind="text: YsVisitNum">2800 </span>人</p>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead" style="padding-bottom: 5px;">目前挂号人次 <span id="registerCurrent"  data-bind="text: ToDayVisitNum">1500</span> 人</p>
                        </div>

                    </div>
                </div>

                <div class=" leftGo col-md-2 ">
                   <%-- <a href="MedicalServiceSituation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">

            <img class="img-responsive" src="content/img/newHome/delta.png" />

        </div>

        <div class="col-md-6 col-sm-6 col-xs-6 div_nav div_chart">
            <div>
                <div id="register" class="chart"></div>
            </div>
        </div>

    </div>
    <!--实名制挂号-->
    <div class="row ">
        <div class="col-md-6 div_nav" style="padding-left: 0px; padding-right: 0px;">
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/newHome/operation.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                           
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                             <p class="imgText text-center">实名制挂号</p>
                        </div>

                    </div>

                </div>

                <div class="col-md-7">
                    <div id="realNameRegistration" class="chart">
                        
                    </div>
                </div>

                <div class="col-md-2 rightGo">
                   <%-- <a href="Operation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
            <img class="img-responsive" src="content/img/newHome/delta.png" />
        </div>

        <div class="col-md-6 div_nav" style="padding-left: 12px;">
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/newHome/operation.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                           
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                           
                            <p class="imgText text-center">预存挂号</p>
                        </div>
                    </div>

                </div>

                <div class="col-md-7">
                    <div id="prestoreRegistration" class="chart">
                        
                    </div>
                    <%--<div style="float:left">
                        <div data-bind="text: '昨日预存总额:'+YsBeforeMoneyTotal()+'万元'"></div>
                    </div>--%>
                </div>

                <div class="col-md-2 rightGo">
                    <%--<a href="Operation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

    </div>

    <!--预约率-->
    <div class="row ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/newHome/emergency.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                            
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-12">
                          
                            <p class="imgText text-center">预约率</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="margin: 5px; padding-left: 10px; padding-right: 10px; padding-top: 10px;">
                    <div class="row">
                        <div class="col-md-4">
                            <p class="text-left">昨日 </p>
                        </div><div class="col-md-8">
                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                             <p class="lead text-center" style="font-size:28px;font-weight:100;"><strong id="prestoreRateYesterday" data-bind="text: parseInt(YsAppointmentNum() / YsVisitNum() * 100)">79</strong>%</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8"></div>
                        <div class="col-md-4" >

                            <p class="text-right text-nowrap" ><span id="persontimeYesterday" data-bind="text:YsAppointmentNum">1000000</span>人次</p>
                        </div>

                    </div>
                </div>

                <div class="col-md-2 rightGo" >
                   <%-- <a href="Operation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
        </div>

        <div class="col-md-6 col-sm-6 col-xs-6 div_nav div_chart">
            <div>
                <div id="prestoreRate" class="chart"></div>
            </div>
        </div>

    </div>
    <!--门诊收入-->
    <div class="row text-center ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/newHome/medicalService.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">门诊收入</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="margin: 5px; padding-left: 10px; padding-right: 10px; padding-top: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead" style="padding-bottom: 5px;">昨日 <span id="outpatientIncomingYesterday" data-bind="text: format(YsIncomeNum())">2800 </span>万元</p>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead" style="padding-bottom: 5px;">今日目前 <span id="outpatientIncomingCurrent" data-bind="text: format(ToDayIncomeNum())">1500</span> 万元</p>
                        </div>

                    </div>
                </div>

                <div class=" leftGo col-md-2 ">
<%--                    <a href="MedicalServiceSituation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
            <img class="img-responsive" src="content/img/newHome/delta.png" />
        </div>

        <div class="col-md-6 div_nav div_chart">
            <div>
                <div id="outpatientIncoming" class="chart">

                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">
    <!--引入echart主文件-->
    <script src="content/js/echarts.js"></script>
    <script src="CustomJsLibrary/home/option.js"></script>
    <script type="text/javascript">
       
            require.config({
                paths: {
                    echarts: 'content/js'

                }
            });
            require([
            'echarts',
            'echarts/chart/bar',
            'echarts/chart/line',
            'echarts/chart/pie'
            ],
        function (ec) {
            var echarts = ec;
            var VisitedChart = ec.init(document.getElementById('register'));
            var IncomeChart = ec.init(document.getElementById('outpatientIncoming'));
            var AppointmentChart = ec.init(document.getElementById('prestoreRate'));
            var RealNameChart = ec.init(document.getElementById('realNameRegistration'));
            var BeforeMoneyChart = ec.init(document.getElementById('prestoreRegistration'));

        });



    </script>
</asp:Content>
