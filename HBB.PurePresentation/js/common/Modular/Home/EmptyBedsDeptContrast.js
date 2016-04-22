/**
 * Created by liu on 2016/4/22.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"


import Globle from "../../../Globle"



import options from "../../../option"

var EmptyBedsDeptContrast = React.createClass({

    componentDidMount:function () {
        $.getJSON(Globle.baseUrl+'HI/REB', function (items) {
            $.each(items, function (index, item) {
                options.homeEmptyBedOption.xAxis[0].data.push(item.Specialist);

                options.homeEmptyBedOption.series[0].data.push(item.RateEmptyBedQuanty);

            });

        });
    },


    render:function () {


        return (

            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <ReactEcharts height={110}  option={options.homeEmptyBedOption}  />

            </div>


        );
    }


});

module.exports = EmptyBedsDeptContrast;