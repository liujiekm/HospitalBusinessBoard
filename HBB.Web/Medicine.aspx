<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicine.aspx.cs" Inherits="HBB.Web.Medicine" %>
<%@ Import Namespace="System.Globalization"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="content/js/jquery/jquery.min.js"></script>
    <script src="content/js/knockout-3.3.0.js"></script>
    <style type="text/css">
        .text-big {
            font-size: 22px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#medicine').addClass('active');
            var MedicineViewModel = function () {
                var self = this;
                //变量区
                //1.药品使用情况（中药西药）统计列表
                self.MedicineUsedList = ko.observableArray([{ 'TimeStemp': '2015-06-01', 'zhongyao': '123', 'xiyao': '456' }, { 'TimeStemp': '2015-06-02', 'zhongyao': '123', 'xiyao': '888' }, { 'TimeStemp': '2015-06-03', 'zhongyao': '666', 'xiyao': '999' }, { 'TimeStemp': '2015-06-04', 'zhongyao': '2345', 'xiyao': '563' }, { 'TimeStemp': '2015-06-05', 'zhongyao': '545', 'xiyao': '753' }]);
                //2.药库报表（上月结余，入库合计，出库合计）
                self.StoreRoomList = ko.observable({ 'jieyu': '12312', 'ruku': '6767', 'chuku': '6775' });
                //3.上月采购总额
                self.LastMonthPurchases = ko.observable(44567);
                //4.药房报表本月入库（门诊西药房，病区西药房，中药房）
                self.MedicineRoomList = ko.observable({ 'menzhenxi': '6667', 'bingquxi': '8789', 'zhongyao': '123454' });
                //5处方配方量统计（门诊住院）
                self.MonthlyDirection = ko.observable({ 'menzhen': '13123', 'zhuyuan': '67867' });
               
                //单日统计
                //昨日药品使用人次
                self.YsMedicineUsed = ko.observable();
                

                //方法区
                //1.获取药品使用情况（中药西药）上月
                self.GetMedicineUsed = function () {
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        url: '../handler/Medicine.ashx?type=ypsy',
                        success: function (data) {
                            var json = eval(data);
                            self.YsMedicineUsed(json);                         
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //1.获取药品使用情况（中药西药）统计列表
                self.GetMedicineUsedList = function () {

                    var UsedChart = require('echarts').init(document.getElementById('register'));
                    UsedChart.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });

                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        url: '../handler/Medicine.ashx?type=ypsyb',
                        success: function (data) {
                            var json = eval(data);

                            MedicineUsedOption.series[0].data.length = 0;
                            MedicineUsedOption.series[1].data.length = 0;
                            MedicineUsedOption.xAxis[0].data.length = 0;
                            self.MedicineUsedList.removeAll();
                            if (json != null) {
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.MedicineUsedList.push(json[i]);
                                    if (i < 7) {
                                        var tomonth = new Date().getMonth() + 1;
                                        var today = new Date().getDate() - i;
                                        MedicineUsedOption.xAxis[0].data.push(tomonth + '-' + today);
                                        MedicineUsedOption.series[0].data.push(json[i].zhongyao);
                                        MedicineUsedOption.series[1].data.push(json[i].xiyao);
                                    }
                                }
                            }
                            var UsedChart = require('echarts').init(document.getElementById('register'));
                            UsedChart.hideLoading();
                            UsedChart.setOption(MedicineUsedOption);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //2.获取药库报表（上月结余，入库合计，出库合计）
                self.GetStoreRoomList = function () {
                    
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        url: '../handler/Medicine.ashx?type=ykyb',
                        success: function (data) {
                            var json = eval(data);
                            self.StoreRoomList(json);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //3.获取上月采购总额
                self.GetLastMonthPurchases = function () {

                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        url: '../handler/Medicine.ashx?type=ykcg',
                        success: function (data) {
                            var json = eval(data);
                            self.LastMonthPurchases(json);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //4.获取药房报表本月入库（门诊西药房，病区西药房，中药房）
                self.GetMedicineRoomListt = function () {
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        url: '../handler/Medicine.ashx?type=yfyb',
                        success: function (data) {
                            var json = eval(data);
                            self.MedicineRoomList(json);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //5.获取处方配方量统计（门诊住院）
                self.GetMonthlyDirection = function () {
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        url: '../handler/Medicine.ashx?type=cfpf',
                        success: function (data) {
                            var json = eval(data);
                            self.MonthlyDirection(json);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                
                //事件区
                self.GetMedicineUsed();
                self.GetStoreRoomList();
                self.GetLastMonthPurchases();
                self.GetMedicineRoomListt();
                self.GetMonthlyDirection();
                self.GetMedicineUsedList();
                
            }
            ko.applyBindings(new MedicineViewModel);
        });
        function format(num) {
            if (num == "" || num == null) return 0;
            return (num.toFixed(0) + '').replace(/\d{1,3}(?=(\d{3})+(\.\d*)?$)/g, '$&,');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">

    <!--药占比-->
    <div class="row text-center">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/药占比.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">药占比</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="margin-top: 5px; margin-bottom: 5px; padding-top: 10px; padding-left: 0px; padding-right: 0px;">
                    <div class="row">
                        <div class="col-md-3">
                            <p class="text-nowrap">昨日</p>
                        </div>
                        <div class="col-md-9">
                        </div>
                    </div>
                    <div class="row">
                         <!--ko with:YsMedicineUsed -->
                        <div class="col-md-6 text-right">
                            <p class="text-big">门诊</p>
                            <p class="lead text-big"><span data-bind="text: zhongyao">58</span>%</p>
                        </div>
                        <div class="col-md-6 text-left text-big">
                            <p class="text-big">住院</p>
                            <p class="lead text-big"><span  data-bind="text: xiyao">41</span>%</p>
                        </div>
                         <!--/ko -->
                    </div>

                </div>

                <div class=" leftGo col-md-2 ">
                    <%--<a href="MedicalServiceSituation.aspx">
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

    <!--药库月报-->
    <div class="row ">
        <div class="col-md-6 div_nav" style="padding-left: 0px; padding-right: 0px;">
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/药库月报.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">药库月报</p>
                        </div>

                    </div>

                </div>

                <div class="col-md-7 text-center" style="padding-top: 5px;">
                    <!--ko with:StoreRoomList -->
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">上月结余 <span id="averageMedicalChargeYesterday" data-bind="text: format(parseInt(jieyu / 10000))">2800 </span>万</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">入库合计 <span id="averageMedicalChargeLastMonth" data-bind="text: format(parseInt(ruku / 10000))">2800 </span>万</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 4px;">出库合计 <span id="averageMedicalChargeLastYear" data-bind="text: format(parseInt(chuku / 10000))">1500</span> 万</p>
                        </div>

                    </div>
                    <!--/ko -->
                </div>

                <div class="col-md-2 rightGo">
<%--                    <a href="Operation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
            <img class="img-responsive" src="content/img/newHome/delta.png" />
        </div>

        <div class="col-md-6 col-sm-6 col-xs-6 div_nav div_chart">
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/药库月报.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">药库采购</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7 text-center" style="margin-top: 5px; margin-bottom: 5px; padding-top: 10px; padding-left: 0px; padding-right: 0px;">
                    <div class="row">
                        <div class="col-md-5">
                            <p class="text-nowrap">上月采购总额</p>
                        </div>
                        <div class="col-md-7">
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-12 text-center" style="padding-top: 10px;">

                            <p class="lead text-big"><span id="clinicMedicineProportion" data-bind="text: format(parseInt(LastMonthPurchases() / 10000))">612</span>万元</p>
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

    </div>

    <!--药房月报-->
    <div class="row ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/药房月报.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">药房月报</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="padding-left: 0px; padding-right: 0px;">
                    <div class="row">
                        <div class="col-md-5">
                            <p class="text-left" style="padding-bottom: 5px;">本月入库</p>
                        </div>
                        <div class="col-md-7">
                        </div>
                    </div>
                    <!--ko with:MedicineRoomList -->
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-center" style="margin-bottom: 0px;">门诊西药 <span data-bind="text: format(parseInt(menzhenxi / 10000))">2800 </span>万</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-center" style="margin-bottom: 0px;">病区西药 <span data-bind="text: format(parseInt(bingquxi / 10000))">2800 </span>万</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-center" style="margin-bottom: 0px;">中药房 <span  data-bind="text: format(parseInt(zhongyao / 10000))">1500</span> 万</p>
                        </div>

                    </div>
                    <!--/ko -->

                </div>

                <div class=" leftGo col-md-2 ">
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
            <img class="img-responsive" src="content/img/newHome/delta.png" />
        </div>

        <div class="col-md-6 div_nav div_chart">
            <div class="row" style="margin-left: 0px; margin-right: 0px; height: 110px;">
                <div class="col-md-3" style="padding: 20px 0px 5px 10px">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/newHome/medicalService.png" />

                        </div>
                    </div>


                </div>



                <div class="col-md-7" style="margin: 5px; padding-top: 30px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">在用药品查询</p>
                        </div>
                    </div>

                </div>

                <div class=" leftGo col-md-2 ">
                    <a href="#">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>
                </div>
            </div>
        </div>

    </div>

    <!--处方配方-->
    <div class="row text-center ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/处方配方.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">处方配方</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7 text-nowrap" style="margin: 5px; padding-left:10px; padding-right: 10px;font-size:15px;padding-top:10px;">
                    <div class="row" style="  border-bottom: 1px solid white;padding-bottom:5px;">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-4">
                            <p>门诊 </p>
                        </div>
                        <div class="col-md-4">
                            <p>住院 </p>
                        </div>
                    </div>
                    <!--ko with:MonthlyDirection -->
                    <div class="row" style="padding-bottom:5px;">
                        <div class="col-md-4">
                            <p>处方 </p>
                        </div>
                        <div class="col-md-4">
                            <p><span data-bind="text: menzhen">2088</span>张 </p>
                        </div>
                        <div class="col-md-4">
                            <p><span data-bind="text: zhuyuan">1400</span>张 </p>
                        </div>
                    </div>
                    <!--/ko -->
                    <%--<!--ko with:MonthlyDirection -->
                    <div class="row" style="padding-bottom:5px;">
                        <div class="col-md-4">
                            <p>配方 </p>
                        </div>
                        <div class="col-md-4">
                            <p><span data-bind="text: menzhen">1000</span>张 </p>
                        </div>
                        <div class="col-md-4">
                            <p><span data-bind="text: zhuyuan">900</span>张 </p>
                        </div>

                    </div>
                    <!--/ko -->--%>
                </div>

                <div class=" leftGo col-md-2 ">
                    <%--<a href="MedicalServiceSituation.aspx">
                        <img class="img-responsive" src="content/img/newHome/into.png" />
                    </a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
        </div>

        <div class="col-md-6 div_nav div_chart">
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
            var UsedChart = ec.init(document.getElementById('register'));


        });
  </script>
</asp:Content>
