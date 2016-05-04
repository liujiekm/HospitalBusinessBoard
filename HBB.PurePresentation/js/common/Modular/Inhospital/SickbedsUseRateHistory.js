/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"


import Globle from "../../../Globle"

import HospitalizationChart from "../../../HospitalizationChart"

var SickbedsUseRateHospital = React.createClass({

    getInitialState:function () {
        return {
            option:{}
        }


    },

    componentDidMount:function () {
        var option = new  HospitalizationChart.baseOption();
        option.title = {
            text: '床位使用率统计',
            textStyle:
            {
                fontSize: 1,
                color: '#FEFFFD'
            }
        };
        option.series = [
            {
                name: '床位使用率',
                type: 'line',
                itemStyle: {
                    normal: {
                        color: 'white',
                        lineStyle: {
                            width: 1

                        }
                    }
                },
                data: [86.6,87.6,96.5,79.5,79.1,87.4,94.3]
            }
        ];

        $.getJSON(Globle.baseUrl+"IH/HI",function (item) {

            option.series = [
                {
                    name: '床位使用率',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: 'white',
                            lineStyle: {
                                width: 1

                            }
                        }
                    },
                    data: item.bcsyl
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


module.exports=SickbedsUseRateHospital;

