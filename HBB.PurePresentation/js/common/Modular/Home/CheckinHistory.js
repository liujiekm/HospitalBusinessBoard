/**
 * Created by liu on 2016/4/20.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"


import Globle from "../../../Globle"



import options from "../../../option"

var CheckinHistory = React.createClass({

    componentDidMount:function () {
        $.getJSON(Globle.baseUrl + 'OPA/RDR', function (items) {
            $.each(items, function (index, item) {

                options.homeLineOption.xAxis[0].data.push(item.RegistrationDate + item.RegistrationTime);
                options.homeLineOption.series[0].data.push(parseInt(item.RegistrationRate * 100));

            });

        });
    },


    render:function () {


        return (

            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <ReactEcharts height={110}  option={options.homeLineOption}  />

            </div>


        );
    }


});

module.exports = CheckinHistory;