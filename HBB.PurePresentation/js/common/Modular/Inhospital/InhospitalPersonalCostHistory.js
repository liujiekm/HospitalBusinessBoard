/**
 * Created by liu on 2016/4/25.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import echarts from 'echarts'


import Globle from "../../../Globle"

import HospitalizationChart from "../../../HospitalizationChart"

var InhospitalPersonalCostHistory = React.createClass({

    getInitialState:function () {
        return {
            option:{}
        }


    },

    componentDidMount:function () {
        var option = new  HospitalizationChart.baseOption();
        option.title.text='住院人均统计(单位:元)'; 
        option.series = [
            {
                name: '住院人均费用',
                type: 'line',
                itemStyle: {
                    normal: {
                        color: 'white',
                        lineStyle: {
                            width: 1

                        }
                    }
                },
                data: [675,666,689,634,651,654,644]
            }
        ];

        $.getJSON(Globle.baseUrl+"IH/HI",function (item) {

            option.title = {
                text: '住院人均统计(单位:元)',
                textStyle:
                {
                    fontSize: 1,
                    color: '#FEFFFD'
                }
            };
            option.series = [
                {
                    name: '住院人均费用',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: 'white',
                            lineStyle: {
                                width: 1

                            }
                        }
                    },
                    data: item.rjjetj
                }
            ];


        });
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(option);
    },


    componentWillUnmount:function () {
        
        echarts.dispose(this.refs.chart)
    },
    render:function () {
        return(


            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <div ref="chart" className="chart-size" />

            </div>
        );
    }


});


module.exports=InhospitalPersonalCostHistory;

