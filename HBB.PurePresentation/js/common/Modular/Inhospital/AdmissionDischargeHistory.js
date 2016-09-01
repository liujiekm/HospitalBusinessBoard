/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import echarts from 'echarts'


import Globle from "../../../Globle"

import HospitalizationChart from "../../../HospitalizationChart"

var AdmissionDischargeHistory = React.createClass({

    getInitialState:function () {
        return {
            option:{}
        }


    },

    componentDidMount:function () {
        var option = new  HospitalizationChart.baseOption();
        option.title.text='出入院(单位:人)';
        option.series = [
            {
                name: '入院人数',
                type: 'line',
                itemStyle: {
                    normal: {
                        color: 'white',
                        lineStyle: {
                            width: 1

                        }
                    }
                },
                data: [5,5,5,5,5,5,5],
            },
            {
                name: '出院人数',
                type: 'line',
                itemStyle: {
                    normal: {
                        color: 'white',
                        lineStyle: {
                            width: 1

                        }
                    }
                },
                data: [5,5,5,5,5,5,5],
            }
        ];

        $.getJSON(Globle.baseUrl+"IH/HI",function (data) {

            option.series = [
                {
                    name: '入院人数',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: 'white',
                            lineStyle: {
                                width: 1

                            }
                        }
                    },
                    data: data.crytj.ryrs,
                },
                {
                    name: '出院人数',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: 'white',
                            lineStyle: {
                                width: 1

                            }
                        }
                    },
                    data: data.crytj.cyrs,
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


module.exports=AdmissionDischargeHistory;

