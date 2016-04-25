/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"

var OutpatientIncomeHistory = React.createClass({

    componentDidMount:function () {
        var temp = new Date();
        var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
        temp.setDate(temp.getDate() - 7);
        var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';

        $.getJSON(Globle.baseUrl+'OPA/IA/' + sd + '/' + ed,function (data) {
            options.OutpatientIncome.series[0].data.length = 0;
            options.OutpatientIncome.xAxis[0].data.length = 0;
            for (var i = 0, l = data.length; i < l; i++) {

                if (i < 7) {
                    options.OutpatientIncome.xAxis[0].data.push(data[i].TimeStemp.substring(5));
                    options.OutpatientIncome.series[0].data.push(parseInt(data[i].TotolMoney/10000));
                }
            }
        });
    },


    render:function () {


        return (

            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <ReactEcharts height={110}  option={options.OutpatientIncome}  />

            </div>


        );
    }


});

module.exports = OutpatientIncomeHistory;