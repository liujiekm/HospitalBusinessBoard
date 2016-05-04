/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import echarts from 'echarts'


import Globle from "../../../Globle"
import options from "../../../option"

var OutpatientIncomeHistory = React.createClass({

    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(options.OutpatientIncome);
        this.getChartData(chart);

    },
    getChartData:function (chart) {


        chart.showLoading({
            text: '数据读取中...', effect: 'spin', textStyle: {
                fontSize: 20
            }
        });

        var temp = new Date();
        var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
        temp.setDate(temp.getDate() - 7);
        var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';

        $.getJSON(Globle.baseUrl + 'OPA/IA/' + sd + '/' + ed, function (data) {

            var xaxis = [];
            var actualData=[];
            $.each(data, function (index, item) {

                xaxis.push(item.TimeStemp.substring(5));
                actualData.push(parseInt(item.TotolMoney/10000));

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
        echarts.dispose(this.refs.chart)
    },
    render:function () {


        return (

            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <div ref="chart" className="chart-size"  />

            </div>


        );
    }


});

module.exports = OutpatientIncomeHistory;