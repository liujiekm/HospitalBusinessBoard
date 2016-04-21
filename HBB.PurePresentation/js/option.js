var options = {};


options.defaultoption = {
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
                data: []
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
                    data: []

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
                    data: []
                }
            ]
        };


//主页chart option模板
options.homeLineOption = {
    title: {
        show: false,
        text: '',
        subtext: '',
        x: 'left'
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: "{a}<br/>{b}: {c} %"
    },
    grid:
    {
        x: '40',
        y: '20',
        x2: '5',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: false,
        data: ['医生签到率']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: true },
            magicType:
            {
                show: true,
                type: ['line']
            },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
    {
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
                fontSize:10
            }
        },
        axisTick: {
            show:false
        },
        splitLine: {
            show: true,
            lineStyle: {
                color: '#609BAA',
                width: 0.1,
                type: 'solid'
            }
            
        },

        data: ['5.20上午', '5.20下午', '5.21上午', '5.21下午', '5.22上午', '5.22下午']

        }
    ],
    yAxis: [
        {
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
                formatter: '{value} ',
                interval: 'auto',
                margin: 5,
                textStyle: {
                    color: '#FEFFFD',
                    fontWeight: 'lighter',
                    fontSize: 10
                }
            },
            splitNumber:2,
            splitLine: {
                show: true,
                lineStyle: {
                    color: '#609BAA',
                    width: 0.1,
                    type: 'solid'
                }
            }

        }
    ],
    series: [
        {
            name: '医生签到率',
            type: 'line',
            symbol: 'emptyCircle',
            symbolSize:4,
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 1
                        
                    }
                }
            },
            data: [90, 75, 65, 65, 40,87]
        }
    ]
};





//候诊人数
options.homeBarOption = {
    title: {
        show: true,
        text: '候诊人数 TOP5科室',
        subtext: '',
        x: 38,
        y:5,
        textStyle:
        {
            fontSize: 10,
            fontWeight: 'bolder',
            color: '#E4EEEF'
        }
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: "{b}<br/>{a0}: {c0} 人 <br/>{a1}: {c1} 人"
    },
    grid:
    {
        x: '40',
        y: '20',
        x2: '5',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: true,
        selectedMode:false,
        data: ['候诊', '已就诊'],
        orient: 'horizontal',
        textStyle: { color: '#E4EEEF' },
        x:250,
        y:5
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: false, readOnly: false },
            magicType:
            {
                show: true,
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

        data: []

    }
    ],
    yAxis: [
        {
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
                formatter: '{value}  ',
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

        }
    ],
    series: [
        {
            name: '候诊',
            type: 'bar',
            
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 3

                    }
                }
            },
            data: []
        },
        {
            name: '已就诊',
            type: 'bar',
            symbol: 'emptyCircle',
            itemStyle: { normal: { color: '#4DB7D2' } },
            data: []
        }
    ]
};






options.hoemPieOption = {
    tooltip: {
        trigger: 'item',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: '{a}<br/>{b}: {c}例'
    },
    grid:
{
    x: '15',
    y: '35',
    x2: '5',
    y2: '20',
    borderWidth: 0,


},
    legend: {
        textStyle: { color: '#E4EEEF' },
        data: ['已完成', '进行中', '等待中']
    },
    color: ['#FEFFFD', '#4EB6D2', '#3F84C6'],
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: true, readOnly: false },
            magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
        {
            show: false,
            type: 'value'
        }
    ],
    yAxis: [
        {
            show: false,
            type: 'category',
            data: ['手术']
        }
    ],
    series: [
        {
            name: '已完成',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside', textStyle: { color: '#83CBDF' } } } },
            data: [320]
        },
        {
            name: '进行中',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside' } } },
            data: [120]
        },
        {
            name: '等待中',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside' } } },
            data: [220]
        }
    ]
};




//var hoemPieOption = {
//    tooltip: {
//        trigger: 'item',
//        formatter: "{a} <br/>{b} : {c} ({d}%)",
//        textStyle: {
//            fontFamily: '微软雅黑',
//            fontSize:4
//        }
//    },
//    legend: {
//        show: true,
//        textStyle: { color: '#E4EEEF' },
//        orient: 'vertical',
//        x: 150,
//        y:20,
//        data: ['已完成','进行中','等待中']
//    },
//    toolbox: {
//        show: false,
//        feature: {
//            mark: { show: true },
//            dataView: { show: true, readOnly: false },
//            magicType: {
//                show: true,
//                type: ['pie', 'funnel'],
//                option: {
//                    funnel: {
//                        x: '25%',
//                        width: '50%',
//                        funnelAlign: 'center',
//                        max: 1548
//                    }
//                }
//            },
//            restore: { show: true },
//            saveAsImage: { show: true }
//        }
//    },
//    calculable: true,

//    color: ['#FEFFFD', '#3F84C6', '#4EB6D2'],
//    series: [
//        {
//            name: '手术',
//            type: 'pie',
//            radius: ['50%', '70%'],
//            center:['30%','50%'],
//            itemStyle: {
//                normal: {
                    
//                    label: {
//                        show: false
//                    },
//                    labelLine: {
//                        show: false
//                    }
//                },
//                emphasis: {
//                    label: {
//                        show: true,
//                        position: 'center',
//                        textStyle: {
//                            fontSize: '20',
//                            fontWeight: 'bold'
//                        }
//                    }
//                }
//            },
//            data: [
//                { value: 335, name: '直接访问' },
//                { value: 310, name: '邮件营销' },
//                { value: 234, name: '联盟广告' },
//                { value: 135, name: '视频广告' },
//                { value: 1548, name: '搜索引擎' }
//            ]
//        }
//    ]
//};



//空床科室

options.homeEmptyBedOption = {
    title: {
        show: true,
        text: '额定空床TOP5科室',
        subtext: '',
        x: 38,
        y: 5,
        textStyle:
        {
            fontSize: 10,
            fontWeight: 'bolder',
            color: '#E4EEEF'
        }
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: "{a}<br/>{b}: {c} 床"
    },
    grid:
    {
        x: '40',
        y: '20',
        x2: '5',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: false,
        data: ['额定空床'],
        orient: 'horizontal',
        x: 250,
        y: 5
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: false, readOnly: false },
            magicType:
            {
                show: true,
                type: ['bar']
            },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
    {
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

        data: []

    }
    ],
    yAxis: [
        {
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
                formatter: '{value}  ',
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

        }
    ],
    series: [
        {
            name: '额定空床',
            type: 'bar',
            
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        
                        width: 3

                    }
                }
            },
            data: []
        }
    ]
};


//门诊就医时长option模板
options.optdOption = {
    tooltip: {
        trigger: 'item'
    },
    toolbox: {
        show: true,
        
        feature: {
            mark: { show: false },
            dataView: { show: true, readOnly: false },
            magicType: { show: true, type: ['line', 'bar'] },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    legend: {
        data: ['蒸发量', '降水量', '平均温度']
    },
    grid:
{
    x: '40',
    y: '60',
    x2: '50',
    y2: '60',
    borderWidth: 0


},
    dataZoom: {
        show: true,
        realtime: true,
        start: 0,
        end: 30
    },
    xAxis: [
        {
            type: 'category',
            data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
        }
    ],
    yAxis: [
        {
            type: 'value',
            name: '时长（分钟）',
            axisLabel: {
                formatter: '{value} '
            }
        },
        {
            type: 'value',
            name: '时长（天）',
            axisLabel: {
                formatter: '{value} '
            }
        }
    ],
    series: [

        {
            name: '蒸发量',
            type: 'bar',
            data: [2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3]
        },
        {
            name: '降水量',
            type: 'bar',
            data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3]
        },
        {
            name: '平均温度',
            type: 'line',
            yAxisIndex: 1,
            data: [2.0, 2.2, 3.3, 4.5, 6.3, 10.2, 20.3, 23.4, 23.0, 16.5, 12.0, 6.2]
        }
    ]
};



/*签到echart option 模板*/
options.signInChangeOption =
    {
    title: {
        text: '签到人数统计图',
        subtext: '',
        sublink: '',
        textStyle:
        {
            fontSize: 15,
            fontWeight: 'bolder',
            color: '#2E9ED4'
        }
       
    },
    color: ['#4DC7C9'],
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            var tar;
            if (params[1].value != '-') {
                tar = params[1];
            }
            else {
                tar = params[0];
            }
            return tar.name + '<br/>' + tar.seriesName + ' : ' + tar.value;
        }
    },
    grid:
{
    x: '40',
    y: '30',
    x2: '30',
    y2: '30',
    


},
    legend: {
        data: ['签到人数']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: true, readOnly: false },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    xAxis: [
        {
            type: 'category',
            splitLine: { show: false },
            data: function () {
                var list = [];
                for (var i = 1; i <= 12; i++) {
                    list.push( + i + ':00');
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
            name: '辅助',
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
            data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
        },
        {
            name: '签到人数',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'top' } } },
            //data: [900, 345, 393, '-', '-', 135, 178, 286, '-', '-', '-']
            // data: [0, 900, 1245, 1530, 1376, 1376, 1511, 1689, 1856, 1495, 1292]
            data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
        },
        {
            name: '支出',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'bottom' } } },
            data: ['-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-']
        }
    ]
};


options.personSignInOption = {
    title: {
        text: '签到时间点统计图',
        subtext: '',
        sublink: '',
        textStyle:
        {
            fontSize: 15,
            fontWeight: 'bolder',
            color: '#2E9ED4'
        }

    },
    tooltip : {
        trigger: 'axis',
        formatter: function (data) {
          
            //排版
            var timeSpanArrange = data[1][2];
            var hoursArrange = Math.floor(timeSpanArrange / 60) < 10 ? "0" + Math.floor(timeSpanArrange / 60) : Math.floor(timeSpanArrange / 60);
            var minutesArrange = timeSpanArrange % 60 < 10 ? "0" + timeSpanArrange % 60 : timeSpanArrange % 60;
            var timeArrange = hoursArrange + ":" + minutesArrange;
            //签到
            var timeSpanSignIn = data[0][2];
            var hoursSignIn = Math.floor(timeSpanSignIn / 60) < 10 ? "0" + Math.floor(timeSpanSignIn / 60) : Math.floor(timeSpanSignIn / 60);
            var minutesSignIn = timeSpanSignIn % 60 < 10 ? "0" + timeSpanSignIn % 60 : timeSpanSignIn % 60;
            var timeSignIn = hoursSignIn + ":" + minutesSignIn;
            //x轴时间
            var dateTime = data[0][1];
            //排版时间提示语
            var arrangeLabel = data[1][0];
            //签到时间提示语
            var signInLabel = data [0][0];
    
            return dateTime + "<br>" + signInLabel + ":" + timeSignIn + "<br>" + arrangeLabel + ":" + timeArrange;
        }
    },
    grid:
{
    x: '40',
    y: '30',
    x2: '30',
    y2: '30',

},
    legend: {
        data: ['排班时间点','签到时间点']
    },
    toolbox: {
        show : true,
        feature : {
            mark : {show: false},
            dataView : {show: true, readOnly: false},
            //magicType : {show: true, type: ['line', 'bar', 'stack', 'tiled']},
            magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
            restore : {show: true},
            saveAsImage : {show: true}
        }
    },
    calculable : true,
    xAxis : [
        {
            type : 'category',
            boundaryGap : false,
            data : ['周一','周二','周三','周四','周五','周六','周日']
        }
    ],
    yAxis : [
        {
            type: 'value',
            axisLabel:{
                formatter: function (timePoint) {
                    var hours = Math.floor(timePoint / 60) < 10 ? "0" + Math.floor(timePoint / 60) : Math.floor(timePoint / 60);
                    var minutes = timePoint % 60 < 10 ? "0" + timePoint % 60  : timePoint % 60 ;
                    return hours + ":" + minutes;
                }
            },
            min: 0,
            max: 960,
            splitNumber: 16,
            data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日'],
            markLine: {
                data:[4800]
            }
        }
    ],
    series : [
        {
            name:'排班时间点',
            type:'line',
            //stack: '总量',
            data: [8.00, 8.00, 13.30, 13.30, 8.00, 8.00, 8.00],
            markLine : {
                data : [
                   [{ name: '上午签到点', value: '08.00',x: 40, y: 150 }, { name: '08：00',value: '08.00', x: 560, y: 150 }]
                 // [{ name: '上午签到点', value: '08.00', xAxis: 0, yAxis: 480 }, { name: '08.00', value: '08', xAxis: 6, yAxis: 480 }]
                ]     

            }
        },
        {
            name:'签到时间点',
            type:'line',
            //stack: '总量',
            data: [8.10, 7.40, 13.00, 13.10, 7.30, 8.00, 7.40],
            markLine: {
                data: [
                   [{ name: '下午签到点',value: '13.30', x: 40, y: 67 }, { name: '13：30',value: '13.30', x: 560, y: 67 }]
                  // [{ name: '上午签到点', value: '08.00', xAxis: 0, yAxis: 480 }, { name: '08.00', value: '08', xAxis: 6, yAxis: 480 }]
                ]

            }
        }
    ]
};



options.emptyBedOption = {
    tooltip: {
        trigger: 'axis',
        axisPointer: {
// 坐标轴指示器，坐标轴触发有效
            type: 'shadow' // 默认为直线，可选为：'line' | 'shadow'
        }
    },
    legend: {
        
        data: ['直接访问', '邮件营销', '联盟广告', '视频广告', '搜索引擎']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: true, readOnly: false },
            magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
        {
            type: 'value'
        }
    ],
    yAxis: [
        {
            type: 'category',
            data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
        }
    ],
    grid: {
        x: '40',
        y: '30',
        x2: '5',
        y2: '40',



    },
    series: [
        {
            name: '直接访问',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
            data: [320, 302, 301, 334, 390, 330, 320]
        },
        {
            name: '邮件营销',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
            data: [120, 132, 101, 134, 90, 230, 210]
        },
        {
            name: '联盟广告',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
            data: [220, 182, 191, 234, 290, 330, 310]
        },
        {
            name: '视频广告',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
            data: [150, 212, 201, 154, 190, 330, 410]
        },
        {
            name: '搜索引擎',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'insideRight' } } },
            data: [820, 832, 901, 934, 1290, 1330, 1320]
        }
    ]
};



options.medicalServiceOption1 = {
    title: {
        text: '专科候诊/未就诊人次统计'
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            return params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value + '<br/>'
                   + params[1].seriesName + ' : ' + (params[1].value + params[0].value);
        }
    },
    legend: {
        selectedMode: false,
        x:250,
        data: ['候诊人次', '未就诊人次']
    },
    toolbox: {
        show: true,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: false },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    grid: {
        x: '40',
        y: '30',
        x2: '5',
        y2: '40',



    },
    calculable: true,
    xAxis: [
        {
            type: 'category',
            data: ['Cosco', 'CMA', 'APL', 'OOCL', 'Wanhai', 'Zim']//科室列表
        }
    ],
    yAxis: [
        {
            type: 'value',
            boundaryGap: [0, 0.1]
        }
    ],
    series: [
        {
            name: '候诊人次',
            type: 'bar',
            stack: 'sum',
            barCategoryGap: '50%',
            itemStyle: {
                normal: {
                    color: 'tomato',
                    barBorderColor: 'tomato',
                    barBorderWidth: 6,
                    barBorderRadius: 0,
                    label: {
                        show: false, position: 'insideTop'
                    }
                }
            },
            data: [260, 200, 220, 120, 100, 80]//候诊人次列表
        },
        {
            name: '未就诊人次',
            type: 'bar',
            stack: 'sum',
            itemStyle: {
                normal: {
                    color: '#fff',
                    barBorderColor: 'tomato',
                    barBorderWidth: 6,
                    barBorderRadius: 0,
                    label: {
                        show: true,
                        position: 'top',
                        formatter: function (params) {
                            for (var i = 0, l = option.xAxis[0].data.length; i < l; i++) {
                                if (option.xAxis[0].data[i] == params.name) {
                                    return option.series[0].data[i] + params.value;
                                }
                            }
                        },
                        textStyle: {
                            color: 'tomato'
                        }
                    }
                }
            },
            data: [40, 80, 50, 80, 80, 70]//就诊人次列表
        }
    ]
};
options.medicalServiceOption2 = {
    title: {
        text: '个人候诊/未就诊人次统计'
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            return params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value + '<br/>'
                   + params[1].seriesName + ' : ' + (params[1].value + params[0].value);
        }
    },
    legend: {
        selectedMode: false,
        x: 250,
        data: ['候诊人次', '未就诊人次']
    },
    toolbox: {
        show: true,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: false },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    grid: {
        x: '40',
        y: '30',
        x2: '5',
        y2: '40',



    },
    calculable: true,
    xAxis: [
        {
            type: 'category',
            data: ['Cosco', 'CMA', 'APL', 'OOCL', 'Wanhai', 'Zim']//科室列表
        }
    ],
    yAxis: [
        {
            type: 'value',
            boundaryGap: [0, 0.1]
        }
    ],
    series: [
        {
            name: '候诊人次',
            type: 'bar',
            stack: 'sum',
            barCategoryGap: '50%',
            itemStyle: {
                normal: {
                    color: 'tomato',
                    barBorderColor: 'tomato',
                    barBorderWidth: 6,
                    barBorderRadius: 0,
                    label: {
                        show: false, position: 'insideTop'
                    }
                }
            },
            data: [260, 200, 220, 120, 100, 80]//候诊人次列表
        },
        {
            name: '未就诊人次',
            type: 'bar',
            stack: 'sum',
            itemStyle: {
                normal: {
                    color: '#fff',
                    barBorderColor: 'tomato',
                    barBorderWidth: 6,
                    barBorderRadius: 0,
                    label: {
                        show: true,
                        position: 'top',
                        formatter: function (params) {
                            for (var i = 0, l = option.xAxis[0].data.length; i < l; i++) {
                                if (option.xAxis[0].data[i] == params.name) {
                                    return option.series[0].data[i] + params.value;
                                }
                            }
                        },
                        textStyle: {
                            color: 'tomato'
                        }
                    }
                }
            },
            data: [40, 80, 50, 80, 80, 70]//就诊人次列表
        }
    ]
};

options.OutpatientVisited = {
    title: {
        show: true,
        text: '最近7天挂号人次',
        subtext: '',
        x: 'left',
        textStyle: {
            fontSize: 10,
            fontWeight: 'bolder',
            color: 'white'
        }
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: "{a}<br/>{b}: {c}人次"
    },
    grid:
    {
        x: '50',
        y: '25',
        x2: '30',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: false,
        data: ['挂号人次']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: true },
            magicType:
            {
                show: true,
                type: ['line']
            },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
    {
        type: 'category',
        boundaryGap: false,
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

        data: ['5.20上午', '5.20下午', '5.21上午', '5.21下午', '5.22上午', '5.22下午']

    }
    ],
    yAxis: [
        {
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
                formatter: '{value} ',
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

        }
    ],
    series: [
        {
            name: '挂号人次',
            type: 'line',
            symbol: 'emptyCircle',
            symbolSize: 4,
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 1

                    }
                }
            },
            data: [90, 75, 65, 65, 40, 87]
        }
    ]
};

options.OutpatientAppointment = {
    title: {
        show: true,
        text: '最近7天预约人次比例',
        subtext: '',
        x: 'left',
        textStyle: {
            fontSize: 10,
            fontWeight: 'bolder',
            color: 'white'
        }
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: "{a}<br/>{b}: {c} %"
    },
    grid:
    {
        x: '50',
        y: '25',
        x2: '30',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: false,
        data: ['预约人次']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: true },
            magicType:
            {
                show: true,
                type: ['line']
            },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
    {
        type: 'category',
        boundaryGap: false,
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

        data: ['5.20上午', '5.20下午', '5.21上午', '5.21下午', '5.22上午', '5.22下午']

    }
    ],
    yAxis: [
        {
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
                formatter: '{value} %',
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

        }
    ],
    series: [
        {
            name: '预约人次比例',
            type: 'line',
            symbol: 'emptyCircle',
            symbolSize: 4,
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 1

                    }
                }
            },
            data: [90, 75, 65, 65, 40, 87]
        }
    ]
};

options.OutpatientIncome = {
    title: {
        show: true,
        text: '最近7天门诊收入',
        subtext: '',
        x: 'left',
        textStyle: {
            fontSize: 10,
            fontWeight: 'bolder',
            color: 'white'
        }
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: "{a}<br/>{b}: {c}万元"
    },
    grid:
    {
        x: '50',
        y: '25',
        x2: '30',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: false,
        data: ['门诊收入']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: true },
            magicType:
            {
                show: true,
                type: ['line']
            },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
    {
        type: 'category',
        boundaryGap: false,
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

        data: ['5.20上午', '5.20下午', '5.21上午', '5.21下午', '5.22上午', '5.22下午']

    }
    ],
    yAxis: [
        {
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
                formatter: '{value}万',
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

        }
    ],
    series: [
        {
            name: '门诊收入',
            type: 'line',
            symbol: 'emptyCircle',
            symbolSize: 4,
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 1

                    }
                }
            },
            data: [90, 75, 65, 65, 40, 87]
        }
    ]
};

options.RealNamePie = {
    tooltip: {
        trigger: 'item',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: '{a}<br/>{b}: {c}人次'
    },
    grid:
{
    x: '15',
    y: '35',
    x2: '5',
    y2: '20',
    borderWidth: 0,


},
    legend: {
        textStyle: { color: '#E4EEEF' },
        data: ['实名挂号人次', '其他']
    },
    color: ['#FEFFFD', '#4EB6D2', '#3F84C6'],
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: true, readOnly: false },
            magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
        {
            show: false,
            type: 'value'
        }
    ],
    yAxis: [
        {
            show: false,
            type: 'category',
            data: ['挂号']
        }
    ],
    series: [
        {
            name: '实名挂号人次',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside', textStyle: { color: '#83CBDF' } } } },
            data: [320]
        },
        {
            name: '其他',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside' } } },
            data: [120]
        }
    ]
};

options.BeforeMoneyPie = {
    tooltip: {
        trigger: 'item',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: '{a}<br/>{b}: {c}人次'
    },
    grid:
{
    x: '15',
    y: '35',
    x2: '5',
    y2: '20',
    borderWidth: 0,


},
    legend: {
        textStyle: { color: '#E4EEEF' },
        data: ['预存挂号人次', '其他']
    },
    color: ['#FEFFFD', '#4EB6D2', '#3F84C6'],
    toolbox: {
        show: false,
        feature: {
            mark: { show: true },
            dataView: { show: true, readOnly: false },
            magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
        {
            show: false,
            type: 'value'
        }
    ],
    yAxis: [
        {
            show: false,
            type: 'category',
            data: ['挂号']
        }
    ],
    series: [
        {
            name: '预存挂号人次',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside', textStyle: { color: '#83CBDF' } } } },
            data: [320]
        },
        {
            name: '其他',
            type: 'bar',
            stack: '总量',
            itemStyle: { normal: { label: { show: true, position: 'inside' } } },
            data: [120]
        }
    ]
};

options.MedicineUsedOption = {
    title: {
        show: true,
        text: '最近7天药占比',
        subtext: '',
        x: 'left',
        textStyle: {
            fontSize: 10,
            fontWeight: 'bolder',
            color: 'white'
        }
    },
    color: ['#516740'],
    renderAsImage: false,
    tooltip: {
        trigger: 'axis',
        formatter: function (params) {
            return params[0].name + '<br/>'
           + params[0].seriesName + ' : ' + params[0].value + '%<br/>'
           + params[1].seriesName + ' : ' + params[1].value + '%';
}
    },
    grid:
    {
        x: '40',
        y: '25',
        x2: '30',
        y2: '20',
        borderWidth: 0,


    },
    legend: {
        show: false,
        data: ['中药','西药']
    },
    toolbox: {
        show: false,
        feature: {
            mark: { show: false },
            dataView: { show: false, readOnly: true },
            magicType:
            {
                show: true,
                type: ['line']
            },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    calculable: true,
    xAxis: [
    {
        type: 'category',
        boundaryGap: false,
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

        data: ['5.20上午', '5.20下午', '5.21上午', '5.21下午', '5.22上午', '5.22下午']

    }
    ],
    yAxis: [
        {
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
                formatter: '{value} %',
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

        }
    ],
    series: [
        {
            name: '中药',
            type: 'line',
            symbol: 'emptyCircle',
            symbolSize: 4,
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 1

                    }
                }
            },
            data: [90, 75, 65, 65, 40, 87]
        },
        {
            name: '西药',
            type: 'line',
            symbol: 'emptyCircle',
            symbolSize: 4,
            itemStyle: {
                normal: {
                    color: 'white',
                    lineStyle: {        // 系列级个性化折线样式
                        width: 1

                    }
                }
            },
            data: [32, 65, 13, 24, 90, 66]
        }
    ]
};

module.exports=options;