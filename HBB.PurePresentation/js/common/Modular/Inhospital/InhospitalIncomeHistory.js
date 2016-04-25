/**
 * Created by liu on 2016/4/25.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"


import Globle from "../../../Globle"

import HospitalizationChart from "../../../HospitalizationChart"

var InhospitalIncomeHistory = React.createClass({

    getInitialState:function () {
        return {
            option:{}
        }


    },

    componentDidMount:function () {
        var option = new  HospitalizationChart.baseOption();
        option.title = {
            text: '住院收入统计(单位:万元)',
            textStyle:
            {
                fontSize: 1,
                color: '#FEFFFD'
            }
        };
        option.series = [
            {
                name: '住院收入',
                type: 'line',
                itemStyle: {
                    normal: {
                        color: 'white',
                        lineStyle: {
                            width: 1

                        }
                    }
                },
                data: [345,545,564,657,656,657,644]
            }
        ];

        $.getJSON(Globle.baseUrl+"IH/HI",function (item) {

            option.series = [
                {
                    name: '住院收入',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: 'white',
                            lineStyle: {
                                width: 1

                            }
                        }
                    },
                    data: items.zysrje
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


module.exports=InhospitalIncomeHistory;

