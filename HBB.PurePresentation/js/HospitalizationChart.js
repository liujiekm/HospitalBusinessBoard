/**
 * Created by liu on 2016/4/25.
 */


function HospitalizationChart(){};

// 图表基本模板
HospitalizationChart.baseOption = function baseOption() {
    this.title ={
        show: true,
        text: '最近7天挂号人次',
        subtext: '',
        x: 'left',
        textStyle: {
            fontSize: 10,
            fontWeight: 'bolder',
            color: 'white'
        }
    };
    this.color=['#516740'];
    this.renderAsImage=false;
    this.tooltip= {
        trigger: 'axis'

    };
    this.grid=
    {
        x: '50',
        y: '25',
        x2: '30',
        y2: '20',
        borderWidth: 0


    };
    this.legend={
        show: false,
        data: ['挂号人次']
    };
    this.toolbox ={
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
    };
    this.calculable= true;




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
        data: getLastSevenDay()
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


module.exports=HospitalizationChart;