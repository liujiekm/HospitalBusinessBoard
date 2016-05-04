/**
 * Created by liu on 2016/4/25.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'
import echarts from 'echarts'
import classnames from "classnames"

import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"


var RealNameRegWgt = React.createClass({

    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(options.RealNamePie);
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

        $.getJSON(Globle.baseUrl + 'OPA/RNV/' + sd + '/' + ed, function (data) {

            var series1 = [];
            var series2= [];
            series1.push(data[1].Visitors);
            series2.push(this.props.YesterdayVisitors - data[1].Visitors);
            chart.setOption({

                series:[{

                    data: series1
                },
                    {

                        data: series2
                    }]
            });
            chart.hideLoading();

        }.bind(this));
    },
    componentWillUnmount:function () {
        echarts.dispose(this.refs.chart)
    },
    render:function () {


        return (
            <div className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size wgt-margin-right div_chart">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/operation.png" />
                                <img className="img-responsive verticalLine" style={{"marginLeft":"2px"}} src="./img/Home/VerticalLine.png" />
    
                            </div>
                        </div>
    
                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p" >
                            <p className="imgText text-center">实名制挂号</p>
                            </div>
    
                        </div>
    
                    </div>
    
                    <div className="col-md-7">
                    <div ref="chart" className="chart-size"  />
                    </div>
    
                    <div className="col-md-2 rightGo">
    
                    </div>
                </div>
            </div>




        );
    }


});


module.exports = RealNameRegWgt;