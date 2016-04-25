/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"


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
        option.title={
            text: '出入院(单位:人)',
            textStyle:
            {
                fontSize: 1,
                color: '#FEFFFD'
            }
        };

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

        $.getJSON(Globle.baseUrl+"IH/HI",function (item) {

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
        this.setState({option:option});
    },


    
    render:function () {
        return(


            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <ReactEcharts height={110}  option={this.state.option}  />

            </div>
        );
    }
    
    
});


module.exports=AdmissionDischargeHistory;

