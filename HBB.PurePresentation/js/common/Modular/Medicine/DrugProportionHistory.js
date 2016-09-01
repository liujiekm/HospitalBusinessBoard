/**
 * Created by liu on 2016/4/26.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import echarts from 'echarts'


import Globle from "../../../Globle"
import options from "../../../option"

var DrugProportionHistory = React.createClass({

    componentDidMount:function () {
        $.getJSON(Globle.baseUrl+'MED/MUL',function (data) {
            options.MedicineUsedOption.series[0].data.length = 0;
            options.MedicineUsedOption.series[1].data.length = 0;
            options.MedicineUsedOption.xAxis[0].data.length = 0;
            for (var i = 0, l = data.length; i < l; i++) {

                if (i < 7) {
                    var tomonth = new Date().getMonth() + 1;
                    var today = new Date().getDate() - 7+i;
                    options.MedicineUsedOption.xAxis[0].data.push(tomonth + '-' + today);
                    options.MedicineUsedOption.series[0].data.push(data[i].zhongyao);
                    options.MedicineUsedOption.series[1].data.push(data[i].xiyao);
                }
            }

        });
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(options.MedicineUsedOption);
    },
    componentWillUnmount:function () {
        
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

module.exports=DrugProportionHistory;