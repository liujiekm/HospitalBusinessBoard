<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="MedicalServiceSituation.aspx.cs" Inherits="HBB.Web.MedicalServiceSituation" %>
<%@ Import Namespace="System.Globalization"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .chart {
            width: 100%;
            padding: 20px;
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
            top: 45%;
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
            border: 1px solid #ddd;
            margin-left: -10px;
            margin-top: 10px;
            margin-bottom: 10px;
            /*overflow-y: scroll;*/
        }



        @media only screen and (min-width: 1024px) {
            .chart {
                height: 250px;
            }

            .nextInfoContainer {
                height: 250px;
            }

            .personContent {
                height: 500px;
            }
        }

        @media only screen and (min-width: 1280px) {
            .chart {
                height: 320px;
            }

            .nextInfoContainer {
                height: 320px;
            }

            .personContent {
                height: 640px;
            }
        }

        @media only screen and (min-width: 1440px) {
            .chart {
                height: 320px;
            }

            .nextInfoContainer {
                height: 320px;
            }

            .personContent {
                height: 640px;
            }
        }
    </style>
    <script src="content/js/knockout-3.3.0.js"></script>
    <script type="text/javascript">
        $(function () {

            $('#returnLink').click(function () {

                window.open('Home.aspx', '_self');

            });
            $('#moduleName').text("坐诊情况");
            $('#home').addClass('active');
        });
        $(document).ready(function () {
            var MedicalServiceViewModel = function () {
                var self = this;
                //变量区
                //专科就诊人次列表
                self.Specialist = ko.observableArray();
                //医生就诊人次列表
                self.DoctorList = ko.observableArray();
                $(function () {
                    
                });
                //方法区
                //获取专科列表
                self.GetSpecialist = function () {
                    var holeHospital = require('echarts').init(document.getElementById('holeHospital'));
                    holeHospital.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/MedicalServiceSituation.ashx?type=zk',
                        url: baseUrl+'OPA/SM',
                        success: function (data) {
                            var json = eval(data);
                            self.Specialist.removeAll();
                            medicalServiceOption1.series[0].data.length = 0;
                            medicalServiceOption1.series[1].data.length = 0;
                            medicalServiceOption1.xAxis[0].data.length = 0;
                            if (json != null) {
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.Specialist.push(json[i]);
                                    if (i < 6) {
                                        medicalServiceOption1.xAxis[0].data.push(json[i].SpecialistName);
                                        medicalServiceOption1.series[0].data.push(json[i].JZnums);
                                        medicalServiceOption1.series[1].data.push(json[i].HZnums - json[i].JZnums);
                                    }
                                }
                            }
                            var holeHospital = require('echarts').init(document.getElementById('holeHospital'));
                            var ecConfig = require('echarts/config');
                            function eConsole(param) {
                                //点击事件的回调函数
                                var item = new Object();
                                item = self.Specialist()[param.dataIndex];
                                self.SelectSpecialist(item);
                            }

                            holeHospital.on(ecConfig.EVENT.CLICK, eConsole);
                            holeHospital.hideLoading();
                            holeHospital.setOption(medicalServiceOption1)
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                //获取医生列表
                self.GetDoctorlist = function () {
                    var departments = require('echarts').init(document.getElementById('departments'));
                    departments.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        //url: '../handler/MedicalServiceSituation.ashx?type=qy',
                        url: baseUrl+'OPA/DM',
                        success: function (data) {
                            var json = eval(data);
                            self.DoctorList.removeAll();
                            medicalServiceOption2.series[0].data.length = 0;
                            medicalServiceOption2.series[1].data.length = 0;
                            medicalServiceOption2.xAxis[0].data.length = 0;
                            if (json != null) {
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.DoctorList.push(json[i]);
                                    if (i < 6) {
                                        medicalServiceOption2.xAxis[0].data.push(json[i].DoctorName);
                                        medicalServiceOption2.series[0].data.push(json[i].JZnums);
                                        medicalServiceOption2.series[1].data.push(json[i].HZnums - json[i].JZnums);
                                    }
                                }
                            }
                            var departments = require('echarts').init(document.getElementById('departments'));
                            departments.hideLoading();
                            departments.setOption(medicalServiceOption2);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }

                //事件区
                self.SelectSpecialist = function (item) {
                    //点击专科列表区域，更新医生统计图
                    var departments = require('echarts').init(document.getElementById('departments'));
                    departments.showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    var zkid = item.SpecialistID;
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        //url: '../handler/MedicalServiceSituation.ashx?type=ys&zkid=' + zkid,
                        url: baseUrl + 'OPA/DSM/' + zkid,
                        dataType:"json",
                        success: function (data) {
                            var json = eval(data);
                            self.DoctorList.removeAll();
                            medicalServiceOption2.series[0].data.length = 0;
                            medicalServiceOption2.series[1].data.length = 0;
                            medicalServiceOption2.xAxis[0].data.length = 0;
                            if (json != null) {
                                for (var i = 0, l = json.length; i < l; i++) {
                                    self.DoctorList.push(json[i]);
                                    if (i < 6) {
                                        medicalServiceOption2.xAxis[0].data.push(json[i].DoctorName);
                                        medicalServiceOption2.series[0].data.push(json[i].JZnums);
                                        medicalServiceOption2.series[1].data.push(json[i].HZnums - json[i].JZnums);
                                    }
                                }
                            }
                            var departments = require('echarts').init(document.getElementById('departments'));
                            departments.hideLoading();
                            departments.setOption(medicalServiceOption2);
                        },
                        error: function () {
                            //alert("获取失败！");
                        }
                    });
                }
                self.GetSpecialist();
                self.GetDoctorlist();
            }
            ko.applyBindings(new MedicalServiceViewModel);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
    <div class="col-md-7">

        <div class="row">
            <div class="col-md-12">
                <div class="chart" id="holeHospital"></div>

            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="chart" id="departments"></div>

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
    <!--各专科出入院及空床情况-->
    <div class="col-md-4">

        <div class="col-md-12 personContent">
            <table class="table">
                <thead>
                    <tr>
                        <td colspan="2">全科室坐诊情况</td>
                    </tr>
                    <tr>
                        <td style="width:50%;">科室</td>
                        <td>候诊/已就诊（人）</td>
                    </tr>
                </thead>
            </table>
            <div style="height:85%;overflow-y:auto;">
                <table class="table table-hover">
                    <tbody data-bind="foreach: Specialist">
                    <tr data-bind="click: $root.SelectSpecialist">
                        <td data-bind="text: SpecialistName">12121</td>
                        <td data-bind="text: HZnums + '/' + JZnums">121212</td>
                    </tr>
                    </tbody>
                    <%--<tbody data-bind="foreach: DoctorList">
                    <tr>
                        <td data-bind="text: DoctorName">12121</td>
                        <td data-bind="text: HZnums + '/' + JZnums">121212</td>
                    </tr>
                    </tbody>--%>
                </table>
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
            require(
                [
                    'echarts',
                    'echarts/chart/bar',
                    'echarts/chart/line'
                ],
                function (ec) {
                    var echarts = ec;
                    var holeHospital = ec.init(document.getElementById('holeHospital'));
                    var departments = ec.init(document.getElementById('departments'));


                });
     



    </script>
</asp:Content>
