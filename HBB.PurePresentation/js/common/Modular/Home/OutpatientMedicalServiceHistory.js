/**
 * Created by liu on 2016/4/22.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import classnames from "classnames"
import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"


var OutpatientMedicalServiceHistory=React.createClass({

    componentDidMount:function () {

        $.getJSON(Globle.baseUrl + 'OPA/RWQ', function (items) {
            $.each(items, function (index, item) {
                options.homeBarOption.xAxis[0].data.push(item.Specialist);//修改成科室名称
                options.homeBarOption.series[0].data.push(item.WaitingQuanty);
                options.homeBarOption.series[1].data.push(item.CompletedTreatQuanty);

            });

        });
    },

    render:function () {
        return (
            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">


                <ReactEcharts height={110}  option={options.homeBarOption}  />

            </div>

        );
    }
});

module.exports = OutpatientMedicalServiceHistory;