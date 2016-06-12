/**
 * Created by liu on 2016/4/29.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from "echarts"

function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();
        var milliseconds = date.getMilliseconds();

        return month + "-" + day;
    } catch (ex) {
        return "";
    }
}
function jsonDateFormatForHourAndMinutes(jsonDate) {//json日期格式转换为正常格式
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var hours = date.getHours();
        var minutes = date.getMinutes();

        return hours * 60 + minutes;
    } catch (ex) {
        return "";
    }

}
//获取一天的分钟总数
function getTotalMinutesOfDay(jsonDate) {
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var hour = hours ? "0" + hours : hours;
        var minute = minutes ? "0" + minutes : minutes;
        return hours + ":" + minutes;
    } catch (ex) {
        return "";
    }
}


var DoctorCheckinTimePoint = React.createClass({


    getInitialState:function () {
        return {userID:8}
    },

    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);


        this.getChartData(chart,5510);
        //chart.setOption(options.personSignInOption);

    },

    componentWillReceiveProps:function (nextProps) {
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        this.getChartData(chart,nextProps.userID);
    },
    getChartData:function (chart,userId) {
        options.personSignInOption.xAxis[0].data.length = 0;
        options.personSignInOption.series[0].data.length = 0;
        options.personSignInOption.series[1].data.length = 0;
        $.getJSON(Globle.baseUrl + 'DCI/RDIP/week/' + userId,function (data) {
            for (let i = 0; i < data.length; i++) {
                if (data[i].TimeType == "1") {//上午
                    options.personSignInOption.xAxis[0].data.push(jsonDateFormat(data[i].ArrangeWorkTime) + "上午");
                    options.personSignInOption.series[0].data.push(jsonDateFormatForHourAndMinutes(data[i].ArrangeWorkTime));//排班时间点
                    options.personSignInOption.series[1].data.push(jsonDateFormatForHourAndMinutes(data[i].RegisterTime));//签到时间点
                }
                if (data[i].TimeType == "2") {//下午
                    options.personSignInOption.xAxis[0].data.push(jsonDateFormat(data[i].ArrangeWorkTime) + "下午"); //x轴坐标
                    options.personSignInOption.series[0].data.push(jsonDateFormatForHourAndMinutes(data[i].ArrangeWorkTime));//排班时间点
                    options.personSignInOption.series[1].data.push(jsonDateFormatForHourAndMinutes(data[i].RegisterTime));//签到时间点
                }

            }
            chart.setOption(options.personSignInOption);


        });
    },
    componentWillUnmount:function () {

        echarts.dispose(this.refs.chart)
    },


    render:function () {
        return (
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <ul className="nav nav-pills chartNav">
                            <li role="presentation"><a href="#">近1年</a></li>
                            <li role="presentation"><a href="#">近1月</a></li>
                            <li role="presentation"><a href="#">近1周</a></li>
                            <li role="presentation"></li>
                        </ul>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <div ref="chart" className="detail-chart"></div>
                    </div>
                </div>

            </div>

        );
    }
});

module.exports=DoctorCheckinTimePoint;