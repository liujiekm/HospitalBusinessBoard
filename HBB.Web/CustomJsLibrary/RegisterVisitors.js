// 为模块加载器配置echarts的路径，从当前页面链接到echarts.js，定义所需图表路径
require.config({
    paths: {
        echarts: 'content/js'
    }
});

// 动态加载echarts然后在回调函数中开始使用，注意保持按需加载结构定义图表路径
require(
    [
        'echarts',
        'echarts/chart/bar',
        'echarts/chart/line',
        'echarts/chart/pie'
    ],
    function(ec) {
        //--- 折柱 ---
        var myChart = ec.init(document.getElementById('main'));

        //获取挂号人数数据
        var lineOption = {
            title: {
                show: true,
                text: '温州医科大学附属第一医院挂号人次统计图',
                subtext: '',
                x: 'center'
            },
            tooltip: { trigger: 'axis' },
            legend: {
                // data: ['最高', '最低']

            },
            toolbox: {
                show: true,
                feature: {
                    mark: { show: true },
                    dataView: { readOnly: false },
                    magicType: { show: true, type: ['line', 'bar', 'tiled'] },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: true,
            dataZoom: {
                show: true,
                realtime: true,
                start: 40,
                end: 60
            },
            xAxis: [
                {
                    type: 'category',
                    boundaryGap: true,
                    data: function () {

                        //从挂号人数处理程序中获取时间区间


                        var list = [];
                        for (var i = 1; i <= 30; i++) {
                            list.push('2013-03-' + i);
                        }
                        return list;
                    }()
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series: [
                {
                    name: '挂号人次',
                    type: 'line',
                    data: function() {
                        var list = [];
                        for (var i = 1; i <= 30; i++) {
                            list.push(Math.round(Math.random() * 30) + 30);
                        }
                        return list;
                    }()
                },
                {
                    name: '挂号人次',
                    type: 'bar',
                    data: function() {
                        var list = [];
                        for (var i = 1; i <= 30; i++) {
                            list.push(Math.round(Math.random() * 10));
                        }
                        return list;
                    }()
                }
            ]
        };


       var pieOption = {
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                orient: 'vertical',
                x: 'left',
                data: ['直接访问', '邮件营销', '联盟广告', '视频广告', '搜索引擎']
            },
            toolbox: {
                show: true,
                feature: {
                    mark: { show: true },
                    dataView: { show: true, readOnly: false },
                    magicType: {
                        show: true,
                        type: ['pie', 'funnel'],
                        option: {
                            funnel: {
                                x: '25%',
                                width: '50%',
                                funnelAlign: 'center',
                                max: 1548
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
                    name: '访问来源',
                    type: 'pie',
                    radius: ['50%', '70%'],
                    itemStyle: {
                        normal: {
                            label: {
                                show: false
                            },
                            labelLine: {
                                show: false
                            }
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
                    data: [
                        { value: 335, name: '直接访问' },
                        { value: 310, name: '邮件营销' },
                        { value: 234, name: '联盟广告' },
                        { value: 135, name: '视频广告' },
                        { value: 1548, name: '搜索引擎' }
                    ]
                }
            ]
        };



        myChart.setOption(lineOption);


    });