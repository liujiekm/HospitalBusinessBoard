<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hospitalization.aspx.cs" Inherits="HBB.Web.Hospitalization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">

    <!--出入院-->
    <div class="row text-center">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/出入院.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">出入院</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-7" style="margin-top: 5px; margin-bottom: 5px; padding-top: 10px; padding-left: 0px; padding-right: 0px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead" style="padding-bottom: 5px;">今日出院 <strong data-bind="text:jrcyrs"></strong>人</p>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead" style="padding-bottom: 5px;">昨日入院 <strong data-bind="text:zrryrs"></strong> 人</p>
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
    <!--病床使用率-->
    <div class="row ">
        <div class="col-md-6 div_nav" style="padding-left: 0px; padding-right: 0px;">
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/病床使用率.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">病床使用率</p>
                        </div>

                    </div>

                </div>

                <div class="col-md-7" style="margin-top: 5px; margin-bottom: 5px; padding-top: 10px; padding-left: 0px; padding-right: 0px;">
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                <p class="lead text-nowrap" style="padding-bottom: 5px;"><strong id="">92.42%</strong></p>
                            </div>
                            <div class="col-md-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-4">
                                <p class="text-nowrap" style="margin-bottom: 3px;">总床位数 <strong id="" data-bind="text: zcws"></strong>张</p>
                                <p class="text-nowrap" style="margin-bottom: 3px;">当前在院 <strong id="" data-bind="text: dqzy"></strong>人</p>
                            </div>
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

        <div class="col-md-6 col-sm-6 col-xs-6 div_nav div_chart">
            <div>
                <div id="bedusage" class="chart"></div>
            </div>
        </div>

    </div>

    <!--住院收入-->
    <div class="row ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/收入.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">住院收入</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="margin-top: 5px; margin-bottom: 5px; padding-top: 10px; padding-left: 0px; padding-right: 0px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-center" style="padding-bottom: 5px;">昨日<strong id="registerYesterday" data-bind="text: zrzysr"></strong>万元</p>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-center" style="padding-bottom: 5px;">今日目前<strong id="registerCurrent" data-bind="text: jrzysr"></strong>万元</p>
                        </div>

                    </div>
                </div>

                <div class=" leftGo col-md-2 ">
                </div>
            </div>
        </div>

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
            <img class="img-responsive" src="content/img/newHome/delta.png" />
        </div>

        <div class="col-md-6 col-sm-6 col-xs-6 div_nav div_chart">
            <div>
                <div id="prestoreRate" class="chart"></div>
            </div>
        </div>

    </div>
    <!--住院人均-->
    <div class="row text-center ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding-left: 10px; padding-right: 5px; padding-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/住院人均.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="imgText text-center">住院人均</p>
                        </div>
                    </div>

                </div>



                <div class="col-md-7" style="margin: 5px; padding-left: 10px; padding-right: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">昨日人均费用 <strong id="averageMedicalChargeYesterday" data-bind="text: zrrjfy"></strong>元</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">上月人均费用 <strong id="averageMedicalChargeLastMonth" data-bind="text: syrjfy"></strong>元</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 4px;">去年人均费用 <strong id="averageMedicalChargeLastYear" data-bind="text: qnrjfy"></strong> 元</p>
                        </div>

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

        <div class="col-md-6 div_nav div_chart">
            <div>
                <div id="outpatientIncoming" class="chart"></div>
            </div>
        </div>

    </div>


    <!--床位查询 住院欠费-->
    <div class="row text-center ">
        <div class="col-md-6 div_nav">
            <div class="row">
                <div class="col-md-3" style="padding: 5px 0px 5px 10px">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/床位查询.png" />

                        </div>
                    </div>


                </div>



                <div class="col-md-7" style="margin: 5px; padding-top: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">床位查询</p>
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

        <div style="margin-top: 45px; position: absolute; right: 48.7%;">
        </div>

        <div class="col-md-6 div_nav div_chart">
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
                <div class="col-md-3" style="padding: 5px 0px 5px 10px">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="content/img/欠费.png" />

                        </div>
                    </div>


                </div>



                <div class="col-md-7" style="margin: 5px; padding-top: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <p class="lead text-nowrap" style="margin-bottom: 3px;">住院欠费</p>
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">
    <script src="content/js/knockout-3.3.0.js"></script>
    <script src="content/js/echarts.js"></script>
    
    <script type="text/javascript">

        $(function () {
            $('#hospitalization').addClass('active');
            $.ajax({
                //url: "../handler/zhandler.ashx?type=hos",
                url: baseUrl+"IH/HI",
                dataType: "json",
                success: function (data) {

                    //格式化json数据
                    items = eval(data);

                    //显示一般信息
                    ko.applyBindings({
                        jrcyrs:items.cry.jrcyrs,
                        zrryrs: items.cry.zrryrs,

                        zrzysr: addKannma(items.zysr.zrzysr),
                        jrzysr: addKannma(items.zysr.jrzysr),

                        zrrjfy: addKannma(items.zyrj.zrrjfy),
                        syrjfy: addKannma(items.zyrj.syrjfy),
                        qnrjfy: addKannma(items.zyrj.qnrjfy),

                        zcws:items.bc.zcws,
                        dqzy:items.bc.dqzy
                    });


                    MyChart.init();
                    MyChart.setxAxis = getLastSevenDay;

                    //出入院人员统计信息
                    var iONumOption = new MyChart.baseOption();
                    iONumOption.title={
                        text: '出入院(单位:人)',
                        textStyle:
                        {
                            fontSize: 1,
                            color: '#FEFFFD'
                        }
                    };
                    iONumOption.series = [
                        {
                            name: '入院人数',
                            type: 'line',
                            itemStyle: {
                                normal: {
                                    color: 'white',
                                    lineStyle: {
                                        width: 1

                                    }
                                }
                            },
                            data: items.crytj.ryrs,
                        },
                        {
                            name: '出院人数',
                            type: 'line',
                            itemStyle: {
                                normal: {
                                    color: 'white',
                                    lineStyle: {
                                        width: 1

                                    }
                                }
                            },
                            data: items.crytj.cyrs,
                        }
                    ];
                    
                    //住院收入统计
                    var inncomeOption = new MyChart.baseOption();
                    inncomeOption.title = {
                        text: '住院收入统计(单位:万元)',
                        textStyle:
                        {
                            fontSize: 1,
                            color: '#FEFFFD'
                        }
                    };
                    inncomeOption.series = [
                        {
                            name: '住院收入',
                            type: 'line',
                            itemStyle: {
                                normal: {
                                    color: 'white',
                                    lineStyle: {
                                        width: 1

                                    }
                                }
                            },
                            data: items.zysrje
                        }
                    ];

                    //住院人均统计
                    var AveNumOption = new MyChart.baseOption();
                    AveNumOption.title = {
                        text: '住院人均统计(单位:元)',
                        textStyle:
                        {
                            fontSize: 1,
                            color: '#FEFFFD'
                        }
                    };
                    AveNumOption.series = [
                        {
                            name: '住院人均费用',
                            type: 'line',
                            itemStyle: {
                                normal: {
                                    color: 'white',
                                    lineStyle: {       
                                        width: 1
                        
                                    }
                                }
                            },
                            data: items.rjjetj
                        }
                    ];

                    var bedusageOption = new MyChart.baseOption();
                    bedusageOption.title = {
                        text: '床位使用率统计',
                        textStyle:
                        {
                            fontSize: 1,
                            color: '#FEFFFD'
                        }
                    };
                    bedusageOption.series = [
                        {
                            name: '床位使用率',
                            type: 'line',
                            itemStyle: {
                                normal: {
                                    color: 'white',
                                    lineStyle: {
                                        width: 1

                                    }
                                }
                            },
                            data: items.bcsyl
                        }
                    ];
                    MyChart.create("register", iONumOption);
                    MyChart.create("prestoreRate", inncomeOption);
                    MyChart.create("outpatientIncoming", AveNumOption);
                    MyChart.create("bedusage", bedusageOption);
                }
            });

            
            //图表类
            function MyChart() {};
            // 初始化
            MyChart.init = function () {  

                require.config( { paths: {echarts: 'content/js'} } );
            };
            // 绘制图表
            MyChart.create = function (id, option) {  

                require(
                    [
                        'echarts',
                        'echarts/chart/line',
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
            //设置X轴坐标
            MyChart.setxAxis;
            // 图表基本模板
            MyChart.baseOption = function baseOption() {
                this.color = ['#516740'];
                this.renderAsImage = false;
                this.tooltip = { trigger: "axis", /*formatter: ""*/ };
                this.grid = { x: '40', y: '25', x2: '5', y2: '20', borderWidth: 0 };
                this.calculable = true;
                this.xAxis = [{
                    type: 'category',
                    axisLine: {
                        lineStyle: {
                            color: '#FEFFFD',
                            width: 1,
                            type: 'solid'
                        }
                    },
                    axisLabel: {
                        interval: '0',
                        margin: 5,
                        textStyle: {
                            color: '#FEFFFD',
                            fontWeight: 'lighter',
                            fontSize: 10
                        }
                    },
                    axisTick: {
                        show: false
                    },
                    splitLine: {
                        show: true,
                        lineStyle: {
                            color: '#609BAA',
                            width: 0.1,
                            type: 'solid'
                        }

                    },
                    data: MyChart.setxAxis()
                }];
                this.yAxis = [{
                    type: 'value',
                    axisLine: {
                        lineStyle: {
                            color: '#FEFFFD',
                            width: 1,
                            type: 'solid'
                        }
                    },
                    splitArea: { show: false },
                    axisLabel: {
                        formatter: '{value}',
                        interval: 'auto',
                        margin: 5,
                        textStyle: {
                            color: '#FEFFFD',
                            fontWeight: 'lighter',
                            fontSize: 10
                        }
                    },
                    splitNumber: 2,
                    splitLine: {
                        show: true,
                        lineStyle: {
                            color: '#609BAA',
                            width: 0.1,
                            type: 'solid'
                        }
                    }
                }];
            };

            // 转千分位
            function addKannma(number) {

                var num = number + "";
                num = num.replace(new RegExp(",", "g"), "");
                // 正负号处理   
                var symble = "";
                if (/^([-+]).*$/.test(num)) {
                    symble = num.replace(/^([-+]).*$/, "$1");
                    num = num.replace(/^([-+])(.*)$/, "$2");
                }

                if (/^[0-9]+(\.[0-9]+)?$/.test(num)) {
                    var num = num.replace(new RegExp("^[0]+", "g"), "");
                    if (/^\./.test(num)) {
                        num = "0" + num;
                    }

                    var decimal = num.replace(/^[0-9]+(\.[0-9]+)?$/, "$1");
                    var integer = num.replace(/^([0-9]+)(\.[0-9]+)?$/, "$1");

                    var re = /(\d+)(\d{3})/;

                    while (re.test(integer)) {
                        integer = integer.replace(re, "$1,$2");
                    }
                    return symble + integer + decimal;

                } else {
                    return number;
                }
            }

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
