<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="HBB.Web.Demo" %>


<!DOCTYPE html>
<html lang="en">
<head>
    

    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!--Bootstrap 不支持 IE 古老的兼容模式。为了让 IE 浏览器运行最新的渲染模式下,加入如下内容-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--让部分国产浏览器默认采用高速模式渲染页面-->
    <meta name="renderer" content="webkit" />
    <!--Bootstrap3 是移动设备优先的为了确保适当的绘制和触屏缩放，增加如下内容-->
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="application/views/frontEnd/build/lib/html5shiv.js"></script>
      <script src="application/views/frontEnd/build/lib/echarts-1.3.8/excanvas/excanvas.js"></script>
    <![endif]-->
    <!-- 解决IE8中canvas绘图错位 -->
    <!--[if lt IE 9]>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <![endif]-->
    <title>ECharts</title>
    
    <!--Bootstrap-->
    <link href="content/bootstrap/bootstrap.min.css" rel="stylesheet">
    <link href="content/bootstrapdatepicker/bootstrap-datetimepicker.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="content/js/html5shiv.min.js"></script>
      <script src="content/js/respond.min.js"></script>
    <![endif]-->
</head>

<body>

    <script src="content/js/jquery/jquery-2.1.3.min.js"></script>
    <script src="content/bootstrap/bootstrap.js"></script>
    <script src="content/bootstrapdatepicker/bootstrap-datetimepicker.js"></script>
    <script src="content/bootstrapdatepicker/bootstrap-datetimepicker.zh-CN.js"></script>
    
    
    
    <div class="container">
    <div class="row">
                <label for="dtp_input1" class="control-label">报表时间</label>
                <div id="sDate" class="input-group date col-md-3"  data-link-field="dtp_input1">
                    <input class="form-control" size="16" type="text" value="2015-05-08 00:00" >
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                </div>
				<input type="hidden" id="dtp_input1" value="" />
           
                <label for="dtp_input2" class=" control-label">-</label>
                <div id="eDate" class="input-group date col-md-3" data-link-field="dtp_input2" >
                    <input class="form-control" size="16" type="text" value="2015-05-08 23:59" >
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                </div>
				<input type="hidden" id="dtp_input2" value="" /><br/>
            
           
       
        <script type="text/javascript">

            var xs = [];//x 坐标
            var content = [];//人次
            var pieContent = [];//饼图人次
            var option = {};
            var pieOption = {};
            $(function () {
                $('.form_datetime').datetimepicker(
                {
                    language: 'zh-CN',
                    autoclose: 1,
                    forceParse: true

                });
                $('.form_date').datetimepicker(
                {
                    language: 'zh-CN',
                    autoclose: 1,
                    forceParse: true
                });


            });
        </script>
        <div class="col-md-3">
        <select id="slt_hd" class="form-control">
            <option selected="selected" value="01,02" >所有院区</option>
            <option value="01" >老院区</option>
            <option value="02" >新院区</option>
        </select>
        </div>
        
        
    <button type="button" class="btn btn-primary" id="btn_search">统计</button>

    </div>
</div>
    

    <!--模块化AMD引入插件-->
    <!--Step:1 为ECharts准备一个具备大小（宽高）的Dom-->
    <div id="main" style="height:500px;border:1px solid #ccc;padding:10px;"></div>
    <div id="pieMain" style="height:500px;border:1px solid #ccc;padding:10px;"></div>
   
    

    <!--Step:2 引入echarts.js-->
    <script src="content/js/echarts.js"></script>
    <script type="text/javascript">




        // Step:3 为模块加载器配置echarts的路径，从当前页面链接到echarts.js，定义所需图表路径
        require.config({
            paths: {
                echarts: 'content/js'
            }
        });

        // Step:4 动态加载echarts然后在回调函数中开始使用，注意保持按需加载结构定义图表路径
        require(
            [
                'echarts',
                'echarts/chart/bar',
                'echarts/chart/line',
                'echarts/chart/pie'
            ],
            function (ec) {
                //--- 折柱 ---
                var myChart = ec.init(document.getElementById('main'));
                //--- 饼  ---
                var pieChart = ec.init(document.getElementById('pieMain'));
                //获取时间，院区
                //var sd = '2011-06-02 00:00:00';
                //var ed = '2014-12-22 23:59:59';
                //var hd = '01,02';







                //$.ajaxSettings.async = false;
                //$.getJSON('Handler/GenericHandler.ashx?type=rv&sd=' + sd + '&ed=' + ed + '&hd=' + hd,
                //    function (visitors) {
                //        $.each(visitors, function (index, item) {

                //            xs.push(item.TimeStemp);
                //            content.push(item.Visitors);
                //            pieContent.push({ value: item.Visitors, name: item.TimeStemp });
                //        });
                //    });


                option = {
                    title: {
                        show: true,
                        text: '',
                        subtext: '',
                        x: 'left'
                    },
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: ['挂号人次']
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            mark: { show: true },
                            dataView: { show: false, readOnly: false },
                            magicType:
                            {
                                show: true,
                                title: { line: '折线图切换', bar: '柱形图切换' },

                                type: ['line', 'bar']
                            },
                            restore: { show: true },
                            saveAsImage: { show: true }
                        }
                    },
                    calculable: true,
                    xAxis: [
                        {
                            type: 'category',
                            data: xs

                        }
                    ],
                    yAxis: [
                        {
                            type: 'value',
                            splitArea: { show: true },
                            axisLabel: {
                                formatter: function (value) {
                                    return value;
                                }()
                            }

                        }
                    ],
                    series: [
                        {
                            name: '挂号人次',
                            type: 'bar',
                            data: content
                        }
                    ]
                };


                //myChart.setOption(option);

                pieOption = {

                    tooltip: {
                        trigger: 'item',
                        formatter: "{a} <br/>{b} : {c} ({d}%)"
                    },
                    legend: {
                        orient: 'vertical',
                        x: 'left',
                        data: xs
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            mark: { show: true },
                            dataView: { show: false, readOnly: false },
                            magicType: {
                                show: true,
                                type: ['pie', 'funnel'],
                                option: {
                                    funnel: {
                                        x: '50%',
                                        width: '50%',
                                        funnelAlign: 'center',
                                        max: 3166488
                                    }
                                }
                            },
                            restore: { show: true },
                            saveAsImage: { show: true }

                        }
                    },
                    calculable: true,
                    series: [
                        {
                            name: '挂号人次',
                            type: 'pie',
                            radius: ['50%', '70%'],
                            itemStyle: {
                                normal: {
                                    label: { show: true },
                                    labelLine: { show: true }
                                },
                                emphasis: {
                                    label: {
                                        show: true,
                                        position: 'center',
                                        textStyle: {
                                            fontSize: '30',
                                            fontWeight: 'bold'
                                        }
                                    }
                                }
                            },
                            data: pieContent

                        }

                    ]


                };
                //----pieOption
                //pieChart.setOption(pieOption);




                $('#btn_search').click(function () {
                    //获得时间
                    var sd = $('#dtp_input1').val();
                    var ed = $('#dtp_input2').val();
                    //获得院区代码
                    var hd = $('#slt_hd').val();

                    //$.ajaxSettings.async = false;
                    //'Handler/GenericHandler.ashx?type=rv&sd=' + sd + '&ed=' + ed + '&hd=' + hd,
                    $.getJSON(baseUrl + 'OPA/RVM/' + sd + "/" + ed + "?hospitalDistrict="+hd,
                        function (visitors) {
                            xs.length = 0;
                            content.length = 0;
                            pieContent.length = 0;
                            $.each(visitors, function (index, item) {

                                xs.push(item.TimeStemp);
                                content.push(item.Visitors);
                                pieContent.push({ value: item.Visitors, name: item.TimeStemp });
                            });

                            option.xAxis[0].data = xs;
                            option.series[0].data = content;
                            myChart.setOption(option);

                            pieOption.legend.data = xs;
                            pieOption.series[0].data = pieContent;
                            pieChart.setOption(pieOption);

                        });

                });

            }
        );


    </script>
</body>
</html>
