<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="AdmissionDischarge.aspx.cs" Inherits="HBB.Web.AdmissionDischarge" %>

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
            margin-left: -20px;
            margin-top: 10px;
            margin-bottom: 10px;
            overflow-y: scroll;
        }

        @media only screen and (min-width: 1024px) {
            .chart {
                height: 250px;
            }

            .nextInfoContainer {
                height: 250px;
            }

            .personContent {
                height: 250px;
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
                height: 320px;
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
                height: 320px;
            }
        }
    </style>

    <script type="text/javascript">
        $(function () {

            $('#returnLink').click(function () {

                window.open('Home.aspx','_self');

            });
            $('#moduleName').text("住院");
            $('#home').addClass('active');
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
    <div class="col-md-7">

        <div class="row">
            <div class="col-md-12">
                <div class="chart" id="admissionDischarge"></div>

            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="chart" id="emptyBed"></div>

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

                <img class="img-responsive" src="content/img/delt.png" />
            </div>
        </div>
    </div>
    <!--各专科出入院及空床情况-->
    <div class="col-md-4">
        <div class="row">
            <style type="text/css">
                .myContent {
                    background: white;
                    height: 320px;
                    border: 1px solid #ddd;
                    margin-left: -20px;
                    margin-top: 10px;
                    margin-bottom: 10px;
                }
                                
                .myclass {
                    overflow-y: scroll;
                    height: 240px;
                    margin-top: -20px;
                    margin-right: -14px;
                }
            </style>
            <div class="col-md-12 myContent">
                <table class="table text-center">
                    <caption><strong>各专科出入院情况</strong>(在院病人数排序)</caption>
                    <thead>
                        <tr>
                            <td style="width: 19%;">科室</td>
                            <td style="width: 27%;">今日在院</td>
                            <td style="width: 27%;">今日出院</td>
                            <td style="width: 27%;">今日入院</td>
                        </tr>
                    </thead>
                </table>

                <div class="myclass">
                    <table class="table table-hover text-center">
                        <tbody data-bind="foreach: gzkcryqk" style="overflow-y:scroll;">
                                <tr>
                                    <td style="width: 19%;" data-bind="text: ZKMC"></td>
                                    <td style="width: 27%;" data-bind="text: RS"></td>
                                    <td style="width: 27%;" data-bind="text: OUTNUM"></td>
                                    <td style="width: 27%;" data-bind="text: INNUM"></td>
                                </tr>
                        </tbody>   
                    </table>
                </div>

            </div>
        </div>

        <div class="row">
            <div class="col-md-12 myContent">
                <table class="table text-center">
                    <caption><strong>各专科空床情况</strong>(额定床位空床数排序)</caption>
                    <thead>
                        <tr>
                            <td style="width: 15%;">科室</td>
                            <td style="width: 28%;">额定空床位</td>
                            <td style="width: 28%;">加床空床位</td>
                            <td style="width: 28%;">虚拟空床位</td>
                        </tr>
                    </thead> 
                </table>
                <div class="myclass">
                    <table class="table table-hover text-center">
                        <tbody data-bind="foreach: gzkkcqk">
                            <tr>
                                <td style="width: 15%;" data-bind="text: ZKMC"></td>
                                <td style="width: 28%;" data-bind="text: EDKCW"></td>
                                <td style="width: 28%;" data-bind="text: JCKCW"></td>
                                <td style="width: 28%;" data-bind="text: XNKCW"></td>
                            </tr>                            
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
    
    <script type="text/javascript">

        $(function () {

                $.ajax({
                    //url: "../handler/zhandler.ashx?type=Adm",
                    url:baseUrl+"IH/ADI",
                    dataType: "json",
                    success: function (data) {

                        //格式化json数据
                        items = eval(data);
                        
                        console.log(items.edkcw);

                        ko.applyBindings({
                            gzkcryqk: items.gzkcryqk,
                            gzkkcqk: items.gzkkcqk,
                        });

                        var admissionDischargeOption = {
                            title: {
                                text: '出入院(单位:人)',
                                subtext: '',
                                sublink: '',
                                textStyle:
                                {
                                    fontSize: 15,
                                    fontWeight: 'bolder',
                                    color: '#2E9ED4'
                                }
                            },
                            color: ['#B6A2DE', '#4DC7C9'],
                            tooltip: {
                                trigger: 'axis',
                                axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                                    type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                                },
                                formatter: "{b}:{c}人"
                            },
                            grid:
                            {
                                x: '40',
                                y: '30',
                                x2: '5',
                                y2: '30',
                            },
                            xAxis: [
                                {
                                    type: 'category',
                                    splitLine: { show: false },
                                    data: ["昨日住院", "今日出院", "今日入院"]
                                }
                            ],
                            yAxis: [
                                {
                                    type: 'value'
                                }
                            ],
                            series: [
                                        {
                                            name: '',
                                            type: 'bar',
                                            stack: '总量',
                                            itemStyle: {
                                                normal: {
                                                    barBorderColor: 'rgba(0,0,0,0)',
                                                    color: 'rgba(0,0,0,0)'
                                                },
                                                emphasis: {
                                                    barBorderColor: 'rgba(0,0,0,0)',
                                                    color: 'rgba(0,0,0,0)'
                                                }
                                            },
                                            data: [0, items.cry.zrzy - items.cry.jrcy, items.cry.zrzy - items.cry.jrcy]
                                        },
                                        {
                                            name: '',
                                            type: 'bar',
                                            stack: '总量',
                                            itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                                            data: [items.cry.zrzy, items.cry.jrcy, items.cry.jrry]
                                        }
                            ]
                        };
                        
                        var emptyBedOption = {
                            title: {
                                text: '空床位(单位:张)',
                                subtext: '',
                                sublink: '',
                                textStyle:
                                {
                                    fontSize: 15,
                                    fontWeight: 'bolder',
                                    color: '#2E9ED4'
                                }
                            },
                            color: ['#B6A2DE', '#4DC7C9'],
                            tooltip: {
                                trigger: 'axis',
                                axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                                    type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                                },
                                formatter: "{b}:{c}张"
                            },
                            grid:
                            {
                                x: '40',
                                y: '30',
                                x2: '5',
                                y2: '30',
                            },
                            xAxis: [
                                {
                                    type: 'category',
                                    splitLine: { show: false },
                                    data: ["额定空床位", "加床空床位", "虚拟空床位"]
                                }
                            ],
                            yAxis: [
                                {
                                    type: 'value'
                                }
                            ],
                            series: [
                                        {
                                            name: '',
                                            type: 'bar',
                                            stack: '总量',
                                            itemStyle: { normal: { label: { show: true, position: 'inside' } } },
                                            data: [items.edkcw, items.jckcw, items.xnkcw]
                                        }
                            ]
                        };

                        MyChart.init();
                        MyChart.create("admissionDischarge", admissionDischargeOption);
                        MyChart.create("emptyBed", emptyBedOption);
                    }
                });


                //图表类
                function MyChart() { };
                // 初始化
                    MyChart.init = function () {

                        require.config({ paths: { echarts: 'content/js' } });
                    };
                // 绘制图表
                MyChart.create = function (id, option) {

                    require(
                        [
                            'echarts',
                            'echarts/chart/bar',
                            'echarts/chart/line'
                        ],
                        function (ec) {
                            var loadingTicket;
                            var myChart = ec.init(document.getElementById(id));

                            myChart.showLoading({
                                text: 'Loading...',
                                effect: 'spin',
                                textStyle: {
                                    fontSize: 20
                                }
                            });
                            clearTimeout(loadingTicket);
                            loadingTicket = setTimeout(function () {
                                myChart.hideLoading();
                                myChart.setOption(option);
                            }, 1000);
                        }
                    );
                };

                //获取过去七天时间
                function getLastSevenDay() {

                    var weekArr = ["周日", "周一", "周二", "周三", "周四", "周五", "周六"];
                    var today = new Date();
                    var resArr = [];

                    today.setDate(today.getDate() - 7);

                    for (var i = 1; i < 7; i++) {

                        resArr.push(weekArr[today.getDay()]);
                        today.setDate(today.getDate() + 1);
                    };

                    resArr.push("昨天");

                    return resArr;
                }
        });



    </script>
</asp:Content>
