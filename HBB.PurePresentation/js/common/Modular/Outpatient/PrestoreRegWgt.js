/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"

var PrestoreRegWgt = React.createClass({

    componentDidMount:function () {
        var temp = new Date();
        var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
        temp.setDate(temp.getDate() - 7);
        var sd = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '00:00:00';


        $.getJSON(Globle.baseUrl+'OPA/IV/' + sd + '/' + ed,function (data) {
            options.BeforeMoneyPie.series[0].data.length = 0;
            options.BeforeMoneyPie.series[1].data.length = 0;
            options.BeforeMoneyPie.series[0].data.push(data[1].Visitors);
            options.BeforeMoneyPie.series[1].data.push(this.props.YesterdayVisitors - data[1].Visitors);
        });
    },

    render:function () {
        return (
            <div className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/operation.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />

                            </div>
                        </div>

                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p" >
                                <p className="imgText text-center">预存挂号</p>
                            </div>

                        </div>

                    </div>

                    <div className="col-md-7">
                        <ReactEcharts height={110}  option={options.BeforeMoneyPie}  />
                    </div>

                    <div className="col-md-2 rightGo">

                    </div>
                </div>
            </div>


        );
    }
});

module.exports=PrestoreRegWgt;