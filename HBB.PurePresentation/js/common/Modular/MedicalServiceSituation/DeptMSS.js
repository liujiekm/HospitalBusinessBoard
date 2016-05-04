/**
 * Created by liu on 2016/5/4.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import Globle from "../../../Globle"
import options from "../../../option"
import echarts from "echarts"


const DeptMSS = React.createClass({

    componentDidMount:function () {

        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);


        

        chart.on('click',function (params) {

            this.props.handleClickTimePoint(params.name);
        }.bind(this));

    },



    componentWillUnmount:function () {

        echarts.dispose(this.refs.chart)
    },
    render:function () {
        return (


            <div className="row">
                <div className="col-md-12">
                    <div ref="chart" className="detail-chart"></div>

                </div>
            </div>
            
        );
    }
    
    
    
});

module.exports=DeptMSS;

