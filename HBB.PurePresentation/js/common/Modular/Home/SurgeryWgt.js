/**
 * Created by liu on 2016/4/22.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import { Link } from 'react-router'
import classnames from "classnames"
import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from 'echarts'

var intervalRef;
var SurgeryWgt=React.createClass({

    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(options.homePieOption);
        this.getChartData(chart);

        intervalRef=setInterval(function () {
            this.getChartData(chart)
        }.bind(this), 10000);
    },

    getChartData:function (chart) {

        // chart.showLoading({
        //     text: '数据读取中...', effect: 'spin', textStyle: {
        //         fontSize: 20
        //     }
        // });
        $.getJSON(Globle.baseUrl + 'OP/RSI', function (item) {
            var series1 = [item.CompletedQuanty];
            var series2 = [item.DoingQuanty];
            var series3 = [item.WaitingQuanty];


            chart.setOption({

                series:[{

                    data: series1
                },{
                    data: series2
                },{
                    data: series3
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
            <div className="row surgerywgt-symbol" >
                <div className="col-md-2 surgerywgt-symbol-content">
                    <div className="row">
                        <div className="col-md-12">
                            <img className="img-responsive" src="./img/Home/operation.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                                    <p className="imgText text-center">手术</p>
                        </div>
                    </div>

                </div>

                <div className="col-md-8 " style={{"width":"72%"}}>
                    <div ref="chart" className="chart-size" />
                </div>

                <div className="col-md-2 rightGo">
                    <Link to="Operation">
                        <img className="img-responsive" src="./img/Home/into.png" />
                    </Link>
                </div>
            </div>

            </div>


        );
    }


});



module.exports=SurgeryWgt;