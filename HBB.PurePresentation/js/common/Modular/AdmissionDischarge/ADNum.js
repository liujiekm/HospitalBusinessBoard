/**
 * Created by Jay on 2016/5/27.
 * 出入院柱状图（昨日住院，今日入院，今日出院）
 */

import React, { Component, PropTypes } from 'react'
import { render, findDOMNode } from 'react-dom'
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from "echarts"

class ADNum extends Component {

    componentDidMount(){
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);


        options.admissionDischargeOption.series[0].data=this.props.data[0];
        options.admissionDischargeOption.series[1].data=this.props.data[1];
        
        chart.setOption(options.admissionDischargeOption);
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


export default ADNum