<%@ Page Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="OutPatientTreatmentDuration.aspx.cs" Inherits="WYYY.HDGM.Web.OutPatientTreatmentDuration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="content/bootstrapdatepicker/bootstrap-datetimepicker.js"></script>
    <script src="content/bootstrapdatepicker/bootstrap-datetimepicker.zh-CN.js"></script>
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

        .fixedtd {
            position: relative;
            z-index: 1;
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

    <script type="text/javascript">
        var echarts;
        $(function () {

            $('#sDate,#eDate').datetimepicker(
            {
                format: 'yyyy-mm-dd',
                language: 'zh-CN',
                autoclose: 1,
                forceParse: true,
                minView: 'month',
                todayBtn: true,
                todayHighlight: true,
                initialDate: '2001-10-10'
                //initialDate: function() {
                //    var current = new Date();
                //    return current.getFullYear()+'-'+(current.getMonth()+1)+'-'+current.getDate();
                //}()

            });
            //$('#eDate').datetimepicker(
            //{
            //    format: 'yyyy-mm-dd',
            //    language: 'zh-CN',
            //    autoclose: 1,
            //    forceParse: true,
            //    minView: 'month',
            //    todayBtn: true
            //});


            $('#returnLink').click(function () {

                window.open('Home.aspx', '_self');

            });
            $('#moduleName').text("门诊就医时长");
        });


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">


    <div class="row" style="padding-left:15px;padding-right: 15px;padding-top:5px;">

        <div class="col-md-4">
            <label for="dtp_input1" class="control-label">就诊时间（开始）</label>
            <div id="sDate" class="input-group date" data-link-field="dtp_input1">
                <input class="form-control" size="16" type="text">
                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                <span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
            </div>
            <input type="hidden" id="dtp_input1" value="" />
        </div>
        <div class="col-md-4 ">
            <label for="dtp_input2" class=" control-label">就诊时间（结束）</label>
            <div id="eDate" class="input-group date" data-link-field="dtp_input2">
                <input class="form-control" size="16" type="text">
                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                <span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
            </div>
            <input type="hidden" id="dtp_input2" value="" /><br />
        </div>
        <div class="col-md-4">
             <label for="slt_hd" class=" control-label">院区</label>
            <select id="slt_hd" class="form-control">
                <option selected="selected" value="01,02">所有院区</option>
                <option value="01">老院区</option>
                <option value="02">新院区</option>
            </select>
        </div>
    </div>


    <div class="row">
        <div class="col-md-12">
            <div id="optdChoice" class="chart"></div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="chart" id="departments"></div>

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
                echarts = ec;
                var choiceChart = ec.init(document.getElementById('optdChoice'));

                //近7天
                var temp = new Date();
                temp.setDate(temp.getDate() - 7);
                //var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';
                //var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';

                var sd = '2014-06-11 00:00:00';
                var ed = '2014-06-18 23:59:59';
                $.getJSON('Handler/GenericHandler.ashx?type=pet&sd=' + sd + '&ed=' + ed + '&group=d&hd=01,02',
                    function (visitors) {
                        //xs1.length = 0;
                        //content1.length = 0;
                        var xs = [], appointment = [], awaitingDiagnosis = [], diagnosis = [], payFees = [], medicineReceiving = [];
                        $.each(visitors, function (index, item) {

                            xs.push(item.SpecialistName);
                            appointment.push(item.Appointment.toFixed(2));
                            awaitingDiagnosis.push(item.AwaitingDiagnosis.toFixed(2));
                            diagnosis.push(item.Diagnosis.toFixed(2));
                            payFees.push(item.PayFees.toFixed(2));
                            medicineReceiving.push(item.MedicineReceiving.toFixed(2));

                        });

                        optdOption.legend.data = ["候诊时长", "就诊时长", "缴费时长", "取药时长", "预约时长"];
                        optdOption.xAxis[0].data = xs;

                        var markline = {
                            symbol: ['arrow', 'none'], symbolSize: [4, 2],
                            itemStyle: {
                                normal: {
                                    lineStyle: { color: 'orange' }, barBorderColor: 'orange', label: {
                                        position: 'left', formatter: function (params) {
                                            return Math.round(params.value);
                                        },
                                        textStyle: { color: 'orange' }
                                    }
                                }
                            },
                            'data': [{ 'type': 'average', 'name': '平均值' }]
                        };


                        optdOption.series[0] = {
                            name: '候诊时长', type: 'bar',
                            markLine: markline,
                            stack: '总量',
                            data: awaitingDiagnosis

                        };
                        optdOption.series[1] = { name: '就诊时长', type: 'bar', markLine: markline, stack: '总量', data: diagnosis };
                        optdOption.series[2] = { name: '缴费时长', type: 'bar', markLine: markline, stack: '总量', data: payFees };
                        optdOption.series[3] = { name: '取药时长', type: 'bar', markLine: markline, stack: '总量', data: medicineReceiving };
                        optdOption.series[4] = { name: '预约时长', type: 'bar', markLine: markline, yAxisIndex: 1, data: appointment };

                        choiceChart.setOption(optdOption);

                    });
                choiceChart.on(ecConfig.EVENT.CLICK, eConsole);

            });

        var ecConfig = require('echarts/config');

        function eConsole(param) {
            var mes = '【' + param.type + '】';
            if (typeof param.seriesIndex != 'undefined') {
                mes += '  seriesIndex : ' + param.seriesIndex;
                mes += '  dataIndex : ' + param.dataIndex;

            }
        }

    </script>
</asp:Content>


