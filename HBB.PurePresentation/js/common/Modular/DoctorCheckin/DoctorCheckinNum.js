/**
 * Created by liu on 2016/4/29.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'


import Globle from "../../../Globle"
import options from "../../../option"
import echarts from "echarts"


var DoctorCheckinNum = React.createClass({

    getInitialState:function () {
      return {option:options.signInChangeOption,
                timePoint:8}
    },

    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);

        chart.setOption(options.signInChangeOption);

        this.getChartData(chart);

        chart.on('click',function (params) {
        
            this.props.handleClickTimePoint(params.name);
        }.bind(this));

    },


    getChartData:function (chart) {
        options.signInChangeOption.xAxis[0].data.length = 0;
        options.signInChangeOption.series[0].data.length = 0;
        options.signInChangeOption.series[1].data.length = 0;
        $.getJSON(Globle.baseUrl+'DCI/RMI',function (data) {
            for (var i = 0, l = data.length; i < l; i++) {

                if (i == 0) {
                    options.signInChangeOption.series[0].data.push(0);//总量
                    options.signInChangeOption.series[1].data.push(data[i].RegisteredDoctorQuanty); //增量
                    options.signInChangeOption.xAxis[0].data.push(data[i].TimeSpan + ":00"); //x轴坐标
                }
                else if (i == l) {
                    options.signInChangeOption.series[0].data.push(data[i - 1].RegisteredDoctorQuanty);

                }
                else {
                    options.signInChangeOption.series[0].data.push(data[i - 1].RegisteredDoctorQuanty);
                    options.signInChangeOption.series[1].data.push(data[i].RegisteredDoctorQuanty - data[i - 1].RegisteredDoctorQuanty);
                    options.signInChangeOption.xAxis[0].data.push(data[i].TimeSpan + ":00");
                }
            }


            chart.setOption(options.signInChangeOption);

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
                            <li role="presentation"><a href="#">今天</a></li>
                            <li role="presentation"><a href="#">昨天</a></li>
                            <li role="presentation"><a href="#">前天</a></li>
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

module.exports=DoctorCheckinNum;