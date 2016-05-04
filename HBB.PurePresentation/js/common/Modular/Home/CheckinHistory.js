/**
 * Created by liu on 2016/4/20.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from 'echarts'

var intervalRef;

var CheckinHistory = React.createClass({
    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(options.homeLineOption);
        this.getChartData(chart);

        intervalRef=setInterval(function () {
            this.getChartData(chart)
        }.bind(this), 10000);
    },

    getChartData:function (chart) {

        chart.showLoading({
            text: '数据读取中...', effect: 'spin', textStyle: {
                fontSize: 20
            }
        });
        $.getJSON(Globle.baseUrl + 'OPA/RDR', function (items) {
            
            var xaxis = [];
            var actualData=[];
            $.each(items, function (index, item) {

                xaxis.push(item.RegistrationDate + item.RegistrationTime);
                actualData.push(parseInt(item.RegistrationRate * 100));

            });
            chart.setOption({
                xAxis:[{
                    data: xaxis
                }],
                series:[{

                    data: actualData
                }]
            });
            chart.hideLoading();

        });
    },
    componentWillUnmount:function () {
        clearInterval(intervalRef);
        echarts.dispose(this.refs.chart)
    },
    render:function () {
        return (
            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">
                <div ref="chart" className="chart-size" />
            </div>
        );
    }


});

module.exports = CheckinHistory;