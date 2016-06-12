/**
 * Created by Jay on 2016/5/27.
 * 空床情况柱状图
 */
import React, { Component, PropTypes } from 'react'
import { render, findDOMNode } from 'react-dom'
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from "echarts"

class EmptyBedNum extends Component {

    componentDidMount(){
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);


        options.emptyBedOption.series[0].data=this.props.data;

        chart.setOption(options.emptyBedOption);
        //this.getChartData(chart);
    }

    getChartData(chart){



    }


    render(){


        return (

            <div>
                <div className="row">
                    <div className="col-md-12">

                        <div ref="chart" className="detail-chart"></div>
                    </div>
                </div>

            </div>
        )
    }

}


export default EmptyBedNum