/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"

var RegHistory = React.createClass({

    componentDidMount:function () {
        var temp = new Date();
        var ed = '' + temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';
        temp.setDate(temp.getDate() - 7);
        var sd =''+ temp.getFullYear()+'-'+(temp.getMonth()+1)+'-'+temp.getDate()+' '+'00:00:00';

        $.getJSON(Globle.baseUrl + 'OPA/RV/' + sd + '/' + ed,function (data) {
            options.OutpatientVisited.series[0].data.length = 0;
            options.OutpatientVisited.xAxis[0].data.length = 0;
            for (var i = 0, l = data.length; i < l; i++) {
                if (i < 7) {
                    options.OutpatientVisited.xAxis[0].data.push(data[i].TimeStemp.substring(5));
                    options.OutpatientVisited.series[0].data.push(data[i].Visitors);

                }
            }
        });
    },


    render:function () {


        return (

            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <ReactEcharts height={110}  option={options.OutpatientVisited}  />

            </div>


        );
    }


});

module.exports = RegHistory;