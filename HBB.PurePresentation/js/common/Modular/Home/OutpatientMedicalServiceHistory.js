/**
 * Created by liu on 2016/4/22.
 */
import React,{Component,PropTypes} from 'react'
import { render, findDOMNode } from 'react-dom'
import classnames from "classnames"
import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from 'echarts'

var intervalRef;

class OutpatientMedicalServiceHistory extends Component{

    componentDidMount() {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        chart.setOption(options.homeBarOption);
        this.getChartData(chart);

        intervalRef=setInterval(function () {
            this.getChartData(chart)
        }.bind(this), 10000);
    }
    getChartData(chart) {

        // chart.showLoading({
        //     text: '数据读取中...', effect: 'spin', textStyle: {
        //         fontSize: 20
        //     }
        // });
        $.getJSON(Globle.baseUrl + 'OPA/RWQ', function (items) {

            const xaxis = [];
            const series1=[];
            const series2=[];
            $.each(items, function (index, item) {

                xaxis.push(item.Specialist);//修改成科室名称
                series1.push(item.WaitingQuanty);
                series2.push(item.CompletedTreatQuanty);

            });
            chart.setOption({
                xAxis:[{
                    data: xaxis
                }],
                series:[{

                    data: series1
                },{
                    data:series2
                }]
            });
            chart.hideLoading();

        });
    }

    componentWillUnmount() {
        clearInterval(intervalRef);
        echarts.dispose(this.refs.chart)
    }
    render() {
        return (
            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <div ref="chart" className="chart-size" />

            </div>

        );
    }
}

//module.exports = OutpatientMedicalServiceHistory;

export default OutpatientMedicalServiceHistory;