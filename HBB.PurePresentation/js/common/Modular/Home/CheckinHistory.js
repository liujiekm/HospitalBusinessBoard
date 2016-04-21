/**
 * Created by liu on 2016/4/20.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"

import ReactEcharts from "react-echarts-component"


import Extension from "../../component/Extension"

import options from "../../../option"

var CheckinHistory = React.createClass({

    componentDidMount:function () {
        $.getJSON(baseUrl + 'OPA/RDR', function (items) {
            $.each(items, function (index, item) {

                options.homeLineOption.xAxis[0].data.push(item.RegistrationDate + item.RegistrationTime);
                options.homeLineOption.series[0].data.push(parseInt(item.RegistrationRate * 100));

            });

        });
    },


    render:function () {


        return (

            <div>
                
                <Extension />

                <ReactEcharts height={110}  option={options.homeLineOption}  />

            </div>


        );
    }


});

module.exports = CheckinHistory;