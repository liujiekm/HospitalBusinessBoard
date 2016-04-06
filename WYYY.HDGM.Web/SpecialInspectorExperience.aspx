<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="SpecialInspectorExperience.aspx.cs" Inherits="WYYY.HDGM.Web.SpecialInspectorExperience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/DateTimePicker.css" rel="stylesheet" />
    <style type="text/css">
        .personPanel {
            padding-top: 20px;
        }

            .personPanel > ul > li {
                float: right;
            }

                .personPanel > ul > li > a {
                    margin-right: 0px;
                    border-radius: 0px;
                    cursor: pointer;
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
            height: 500px;
            border-bottom:2px solid #0084CC;
            border-top:2px solid #0084CC;
            overflow-y: auto;
        }

        .table{
            margin-bottom:0px;
        }
        .btn {
            border-radius: 0px;
            width: 100px;
        }

        .btnClick {
            color: white;
            background-color: #0988CE;
        }
        .rightPosition{
            float:right;
        }

        .btn:hover,
        .btn:focus {
            color: white;
            background-color: #0988CE;
        }

        .dataControl {
            height: 34px;
            text-align: center;
            color: #0988CE;
            border: 1px solid #9F9F9F;
        }

        #btnReturn,#btnCompare{
            border: 1px solid #0988CE; 
            color:#0988CE;
            background-color:white;
        }

        #btnReturn:hover,
        #btnReturn:focus,
        #btnCompare:hover,
        #btnCompare:focus
        {
            color:white;
            background-color:#0988CE;
        }

        @media only screen and (min-width: 1024px) {

            .chart {
                height: 390px;
            }

            .personContent {
                height: 400px;
            }
        }

        @media only screen and (min-width: 1280px) {

            .chart {
                height: 500px;
            }

            .personContent {
                height: 550px;
            }
        }

        @media only screen and (min-width: 1440px) {

            .chart {
                height: 500px;
            }

            .personContent {
                height: 550px;
            }
        }
    </style>
    <script src="content/js/DateTimePicker.js"></script>

    <script type="text/javascript">
        $(function () {

            $("#dtBox").DateTimePicker({

                dateFormat: "yyyy-MM-dd",
                fullDayNames: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"],
                shortMonthNames: ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"],
                fullMonthNames: ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"],
                titleContentDate: "设置日期",
                setButtonContent: "设定",
                clearButtonContent: "清除",
                isPopup:true,
                formatHumanDate: function (date) {
                    return date.yyyy + "-" + date.month + "-" + date.dd;
                },
                addEventHandlers: function () {
                    var dtPickerObj = this;
                    dtPickerObj.setDateTimeStringInInputField($("#eDate"), new Date());
                    dtPickerObj.setDateTimeStringInInputField($("#sDate"), new Date(new Date().getTime() - 1000 * 60 * 60 * 24 * 7));
                    dtPickerObj.setDateTimeStringInInputField($("#eDeptDate"), new Date());
                    dtPickerObj.setDateTimeStringInInputField($("#sDeptDate"), new Date(new Date().getTime() - 1000 * 60 * 60 * 24 * 7));

                },
                afterHide: function (InputElement) {

                    if (InputElement.id == 'sDate') {
                        $('#sDeptDate').val(InputElement.value);
                    }
                    if (InputElement.id == 'eDate') {
                        $('#eDeptDate').val(InputElement.value);
                    }
                }
            });

            $('.btn-default').click(function () {
                $(this).addClass('btnClick');
                $(this).siblings().removeClass('btnClick');

                $('#hospitalDistrict').val($(this).val());
            });
            $('#returnLink').click(function () {

                window.open('Home.aspx', '_self');

            });
            $('#home').addClass('active');
            $('#moduleName').text("特检预约时长");
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
    <div class="col-md-12" id="main">


        <div class="row" style="padding-bottom: 10px; margin-top: 10px; border-bottom: 1px solid #0988CE;">
            <div class="col-md-1">
                <img  class="img-responsive" style="  margin-top: 6px;   margin-left: 40px;" src="content/img/Calendar.png"/>
            </div>

            <div class="col-md-2">
                <input id="sDate" class="dataControl" type="text" data-field="date"  data-startend="start"  data-format="yyyy-MM-dd" value="2014-05-06" readonly>
            </div>
            <div class="col-md-2">
                <input id="eDate" class="dataControl" type="text" data-field="date"  data-startend="end" data-format="yyyy-MM-dd" value="2014-06-06" readonly>
            </div>

            


            <div class="col-md-7">
                <div class="btn-group" role="group">
                    <button type="button" class="btn btn-default btnClick" value="01,02">全院</button>
                    <button type="button" class="btn btn-default" value="01">老院区</button>
                    <button type="button" class="btn btn-default" value="02">新院区</button>
                </div>
                <button type="button" id="btnSearch" class="btn btnClick">统计</button>
            </div>



        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table text-center">
                    <thead>
                        <tr>
                            <td style="width:10%">加入对比</td>
                            <td style="width:15%">检查类型</td>
                            <td style="width:15%">预约时长（天）</td>
                            <td style="width:20%">检查报告时长（小时）</td>
                            <td style="width:20%">实际检查人数</td>
                            <td >特检爽约数</td>
                            

                        </tr>
                    </thead>
                </table>
                <div class="tabContent">
                    <table id="content" class="table table-hover text-center">
                        <tbody data-bind="foreach: specialTreatmentTime">
                            <tr>
                                <td style="width:10%">
                                    <input type="checkbox" name="chk"  data-bind="attr: { value: InspectionType }, checked: $parent.selectedChoices,"/></td>
                                <td style="width:15%" data-bind="text: InspectionType, click: $parent.deptClick"></td>
                                <td style="width:15%" data-bind="text: AppointmentDuration"></td>
                                <td style="width:20%" data-bind="text: ReportDuration"></td>
                                <td style="width:20%" data-bind="text: ActualInspectNum"></td>
                                <td  data-bind="text: BreakNum.toFixed(1)"></td>
                                

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div class="row" style="  padding-top: 10px;">
            <div class="col-md-4">
                <p><%--注：对比最多勾选5个科室--%></p>
            </div>
            <div class="col-md-4"></div>
            <div class="col-md-4">
                 <button type="button" id="btnCompare" class="btn rightPosition" >开始对比--></button>
            </div>

        </div>
    </div>

    

    <!--部门三年同比-->
    <div class="col-md-12" id="dept" style="display: none">
        <div class="row" style="padding-bottom: 10px; margin-top: 10px; border-bottom: 1px solid #0988CE;">
            <div class="col-md-1">
                <img  class="img-responsive" style="  margin-top: 6px;   margin-left: 40px;" src="content/img/Calendar.png"/>
            </div>

            <div class="col-md-2">
                <input id="sDeptDate" class="dataControl" type="text" data-field="date" data-startend="start" data-format="yyyy-MM-dd" value="2014-05-06" readonly>
            </div>
            <div class="col-md-2">
                <input id="eDeptDate" class="dataControl" type="text" data-field="date" data-startend="end" data-format="yyyy-MM-dd" value="2014-06-06" readonly>
            </div>

            


            <div class="col-md-7">
                <div class="btn-group" role="group">
                    <%--<button type="button" class="btn btn-default btnClick" value="01,02">全院</button>
                    <button type="button" class="btn btn-default" value="01">老院区</button>
                    <button type="button" class="btn btn-default" value="02">新院区</button>--%>
                </div>
                <button type="button" id="btnDeptSearch" class="btn  btnClick">统计</button>
            </div>



        </div>
        <div class="row">
            <div class="col-md-12 personPanel">
                <ul class="nav nav-tabs" role="tablist" id="ulTimeType">
                    <li role="presentation" class="active"><a id="AppointmentDuration" aria-controls="AppointmentDuration" role="tab" data-toggle="tab">预约时长(天)</a></li>
                    <li role="presentation"><a id="ReportDuration" aria-controls="ReportDuration" role="tab" data-toggle="tab">检查报告时长(小时)</a></li>
                    <li role="presentation"><a id="ActualInspectNum" aria-controls="ActualInspectNum" role="tab" data-toggle="tab">实际检查人数</a></li>
                    <li role="presentation"><a id="BreakNum" aria-controls="BreakNum" role="tab" data-toggle="tab">特检爽约数</a></li>
                   
                </ul>

                <div class="tab-content personContent">
                   

                    <div id="chart" class="chart"></div>
                    <div style="bottom: 0px;  position: absolute;">
                        <button type="button" id="btnReturn" class="btn" ><--返回列表</button>

                    </div>
                </div>
            </div>
        </div>


    </div>


    <!--部门相同时间区间对比-->



     <input type="hidden" id="specialistId" value="" />
    <input type="hidden" id="specialistName" value="" />
    <input type="hidden" id="hospitalDistrict" value="01,02" />
    <!--部门前三年同比yoy 或者 几个部门相同时间内对比dod-->
     <input type="hidden" id="compareType" value="01,02" />

    <!--选择对比的科室-->
    <input type="hidden" id="specialistIds" value="" data-bind="value: selectedChoicesDelimited"/>
   
    <div id="dtBox"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">
    <script src="content/js/knockout-3.3.0.js"></script>
    <!--引入echart主文件-->
    <script src="content/js/echarts.js"></script>

    <script type="text/javascript">

        var option = {
            title: {
                text: '',
                x: 'left',
                textStyle:
                {
                    fontSize: 20,
                    fontWeight: 'bolder',
                    color: '#4AA6D9'
                }        
            },
            tooltip: {
                trigger: 'axis'
            },
            legend: {
                y: 25,
                data: ['视频广告', '直接访问', '搜索引擎']
            },
            toolbox: {
                show: true,
                feature: {
                    mark: { show: true },
                    dataView: { show: false, readOnly: false },
                    magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    boundaryGap: true,
                    data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series: [

                {
                    name: '视频广告',
                    type: 'line',

                    data: [150, 232, 201, 154, 190, 330, 410]
                },
                {
                    name: '直接访问',
                    type: 'line',

                    data: [320, 332, 301, 334, 390, 330, 320]
                },
                {
                    name: '搜索引擎',
                    type: 'line',

                    data: [820, 932, 901, 934, 1290, 1330, 1320]
                }
            ]
        };

        var deptOption = {
            title: {
                text: '',
                x: 'left',
                textStyle:
                {
                    fontSize: 20,
                    fontWeight: 'bolder',
                    color: '#4AA6D9'
                }
            },
            tooltip: {
                trigger: 'axis'
            },
            legend: {
                y: 25,
                data: ['视频广告', '直接访问', '搜索引擎']
            },
            toolbox: {
                show: true,
                feature: {
                    mark: { show: true },
                    dataView: { show: false, readOnly: false },
                    magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    boundaryGap: true,
                    data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series: [

                {
                    name: '视频广告',
                    type: 'line',

                    data: [150, 232, 201, 154, 190, 330, 410]
                },
                {
                    name: '直接访问',
                    type: 'line',

                    data: [320, 332, 301, 334, 390, 330, 320]
                },
                {
                    name: '搜索引擎',
                    type: 'line',

                    data: [820, 932, 901, 934, 1290, 1330, 1320]
                }
            ]
        };
        var echarts;
        var optionData = [];
        $(function () {

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
                });

            function viewModel() {
                var self = this;
              
                self.selectedChoices = ko.observableArray();
                self.specialTreatmentTime = ko.observableArray();
                self.selectedChoicesDelimited = ko.dependentObservable(function () {
                    return self.selectedChoices().join(",");
                });
               

                self.deptClick = function (item) {
                    $('#specialistId').val(item.SpecialistId)
                    $('#specialistName').val(item.InspectionType);
                    var sDate = new Date($('#sDate').val().replace(/-/g, "/"));
                    var eDate = new Date($('#eDate').val().replace(/-/g, "/"));
                    $('#compareType').val('yoy');
                    $('#main').hide();
                    $('#dept').show();
                    //var legends = [sDate.getFullYear() + '-' + sDate.getMonth() + 1 + '-' + sDate.getDate() + '--' + eDate.getFullYear() + '-' + (eDate.getMonth() + 1) + '-' + eDate.getDate(),
                    //(sDate.getFullYear() - 1) + '-' + (sDate.getMonth() + 1) + '-' + sDate.getDate() + '--' + (eDate.getFullYear() - 1) + '-' + (eDate.getMonth() + 1) + '-' + eDate.getDate(),
                    //(sDate.getFullYear() - 2) + '-' + (sDate.getMonth() + 1) + '-' + sDate.getDate() + '--' + (eDate.getFullYear() - 2) + '-' + (eDate.getMonth() + 1) + '-' + eDate.getDate()];
                    var legends = [sDate.getFullYear() ,(sDate.getFullYear() - 1) ,(sDate.getFullYear() - 2)];
                    option.title.text = item.InspectionType + '同比近三年' + $('#ulTimeType>li.active>a').first().text() + '对比统计';
                    option.legend.data = legends;
                    //option.xAxis[0].data.length = 0;

                    option.series[0].name = legends[0];
                    option.series[0].data.length = 0;
                    option.series[1].name = legends[1];
                    option.series[1].data.length = 0;
                    option.series[2].name = legends[2];
                    option.series[2].data.length = 0;
                    //获得检查类型三年来的数据
                    var itemProperty = $('#ulTimeType>li.active>a').first().attr('id');
                    echarts.init(document.getElementById('chart')).showLoading({
                        text: '数据读取中...', effect: 'spin', textStyle: {
                            fontSize: 20
                        }
                    });
                    $.getJSON('Handler/GenericHandler.ashx?type=psty&sd=' + $('#sDate').val() + '&ed=' + $('#eDate').val() + '&hd=' + $('#hospitalDistrict').val() + '&si=' + item.InspectionType, function (data) {
                        optionData = data;
                        $.each(data, function (index, items) {
                            option.xAxis[0].data.length = 0;
                            $.each(items, function (itemIndex, item) {
                                option.xAxis[0].data.push(item.TimeStamp);
                                option.series[index].data.push(item[itemProperty]);
                            });
                        });
                        echarts.init(document.getElementById('chart')).hideLoading();
                        echarts.init(document.getElementById('chart')).setOption(option);

                    });
                }
            };

            //查询当前检查类型选择时间内的三年内的同比
            $('#btnDeptSearch').click(function () {
                switch ($('#compareType').val()) {
                    case 'dod'://查询指定时间内，选择的特检类型的比较-------------？
                        echarts.init(document.getElementById('chart')).showLoading({
                            text: '数据读取中...', effect: 'spin', textStyle: {
                                fontSize: 20
                            }
                        });
                        deptOption.title.text = $('#sDeptDate').val() + '~' + $('#eDeptDate').val() + ' 特检' + $('#ulTimeType>li.active>a').first().text() + '对比统计';

                        $.getJSON('Handler/GenericHandler.ashx?type=pstt&sd=' + $('#sDeptDate').val() + '&ed=' + $('#eDeptDate').val() + '&hd=' + $('#hospitalDistrict').val() + '&si=' + $('#specialistIds').val(), function (data) {
                            optionData = data;
                            $.each(optionData, function (index, items) {
                                deptOption.xAxis[0].data.length = 0;
                                $.each(items, function (itemIndex, item) {
                                    deptOption.xAxis[0].data.push(item.TimeStamp);
                                    deptOption.series[index].data.push(item[$('li.active>a').first().attr('id')]);
                                });
                            });
                            echarts.init(document.getElementById('chart')).hideLoading();
                            echarts.init(document.getElementById('chart')).setOption(deptOption);
                        });
                    break;
                    case 'yoy'://查询当前检查类型选择时间内的三年内的同比
                        echarts.init(document.getElementById('chart')).showLoading({
                            text: '数据读取中...', effect: 'spin', textStyle: {
                                fontSize: 20
                            }
                        });
                        $.getJSON('Handler/GenericHandler.ashx?type=psty&sd=' + $('#sDeptDate').val() + '&ed=' + $('#eDeptDate').val() + '&hd=' + $('#hospitalDistrict').val() + '&si=' + $('#specialistName').val(), function (data) {
                            optionData = data;
                            $.each(optionData, function (index, items) {
                                option.xAxis[0].data.length = 0;
                                $.each(items, function (itemIndex, item) {
                                    option.xAxis[0].data.push(item.TimeStamp);
                                    option.series[index].data.push(item[$('li.active>a').first().attr('id')]);
                                });
                            });
                            echarts.init(document.getElementById('chart')).hideLoading();
                            echarts.init(document.getElementById('chart')).setOption(option);
                        });
                    break;
                    default:

                }        
               
            });

            //查询当前特检类型选择时间内的三年内的同比
            $('#ulTimeType> li >a').click(function () {
                var currentId = $(this).attr('id');
                
                switch ($('#compareType').val()) {
                    case 'dod':
                        deptOption.title.text = $('#sDeptDate').val() + '~' + $('#eDeptDate').val() + ' 特检' + $(this).text() + '对比统计';

                        $.each(optionData, function (index, items) {
                            deptOption.xAxis[0].data.length = 0;
                            deptOption.series[index].data.length = 0;
                            $.each(items, function (itemIndex, item) {
                                deptOption.xAxis[0].data.push(item.TimeStamp);//时间段
                                deptOption.series[index].data.push(item[currentId]);
                            });
                        });
                        echarts.init(document.getElementById('chart')).setOption(deptOption);
                        break;
                    case 'yoy':
                        option.title.text = $('#specialistName').val() + '同比近三年' + $(this).text() + '对比统计';

                        $.each(optionData, function (index, items) {
                            option.xAxis[0].data.length = 0;
                            option.series[index].data.length = 0;
                            $.each(items, function (itemIndex, item) {
                                option.xAxis[0].data.push(item.TimeStamp);//时间段
                                option.series[index].data.push(item[currentId]);
                            });
                        });
                        echarts.init(document.getElementById('chart')).setOption(option);
                        break;
                        default:
                }
              
            });





            //切换到科室间数据对比
            $('#btnCompare').click(function () {
                var sids = $('#specialistIds').val();
                if (!sids)
                {
                    alert("请选择对比特检类型！");
                    return false
                }
                var content = $('#ulTimeType> li.active >a').first().attr('id');
                $('#compareType').val('dod');
                $('#main').hide();
                $('#dept').show();
                //获取选中的科室ID
                var sDate = new Date($('#sDate').val().replace(/-/g, "/"));
                var eDate = new Date($('#eDate').val().replace(/-/g, "/"));
                var legends = [];

                deptOption.title.text = $('#sDate').val() + '~' + $('#eDate').val() + ' 特检' + $('#ulTimeType>li.active>a').first().text() + '对比统计';
                echarts.init(document.getElementById('chart')).showLoading({
                    text: '数据读取中...', effect: 'spin', textStyle: {
                        fontSize: 20
                    }
                });
                //获得指定特检类型指定时间区间内的对比数据
                $.getJSON('Handler/GenericHandler.ashx?type=pstt&sd=' + $('#sDate').val() + '&ed=' + $('#eDate').val() + '&hd=' + $('#hospitalDistrict').val() + '&si=' + sids, function (data) {
                    optionData = data;
                    //取得科室名称
                    $.each(data, function (index, items) {
                        for (var i = 0; i < items.length; i++) {
                            legends.push(items[i].InspectionType);
                            break;
                        }
                    });
                    deptOption.legend.data = legends;
                    deptOption.series.length = 0;
                    for (var i = 0; i < legends.length; i++) {
                        deptOption.series[i] = { name: legends[i], type: 'line', data: [] };
                        
                    }
                    $.each(data, function (index, items) {
                        deptOption.xAxis[0].data.length = 0;
                        $.each(items, function (itemIndex, item) {
                            deptOption.xAxis[0].data.push(item.TimeStamp);//时间段
                            deptOption.series[index].data.push(item[content]);
                        });
                    });
                    echarts.init(document.getElementById('chart')).hideLoading();
                    echarts.init(document.getElementById('chart')).setOption(deptOption);

                });

            });



            var viewModelInstance = new viewModel();

            $('#btnReturn').click(function () {
                $('#main').show();
                $('#dept').hide();
                optionData = [];
                //清空数据
                //option.legend.data.length = 0;
                //option.series.length = 0;
                //option.xAxis[0].data.length = 0;
            });
            //查询当前部门选择时间内的三年内的同比（选择时间区间查询）
            $('#btnSearch').click(function () {
                var specialTreatmentTime;
                $.getJSON('Handler/GenericHandler.ashx?type=pst&sd=' + $('#sDate').val() + '&ed=' + $('#eDate').val() + '&hd=' + $('#hospitalDistrict').val(),
                          function (data) {
                              viewModelInstance.specialTreatmentTime(data);
                          });
            });

            ko.applyBindings(viewModelInstance);


          

        });

    </script>


</asp:Content>

