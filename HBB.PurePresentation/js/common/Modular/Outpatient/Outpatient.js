/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'

import ReactEcharts from "react-echarts-component"

import Extension from "../../component/Extension"

import RegWgt from "./RegWgt"
import RegHistory from "./RegHistory"
import RealNameRegWgt from "./RealNameRegWgt"
import PrestoreRegWgt from "./PrestoreRegWgt"

import AppointmentsRateWgt from "./AppointmentsRateWgt"
import AppointmentsRateHistory from "./AppointmentsRateHistory"

import OutpatientIncomeWgt from "./OutpatientIncomeWgt"
import OutpatientIncomeHistory from "./OutpatientIncomeHistory"

var Outpatient = React.createClass({

    render:function () {
        return (

            <div>
                <div className="wgt-group">
                    <RegWgt />

                    <Extension />
                    <RegHistory />
                </div>


                <div className="wgt-group">
                    <RealNameRegWgt YesterdayVisitors="15003" />

                    <PrestoreRegWgt YesterdayVisitors="15003"/>
                </div>

                <div className="wgt-group">
                    <AppointmentsRateWgt />
                    <Extension />
                    <AppointmentsRateHistory />
                </div>

                <div className="wgt-group">

                    <OutpatientIncomeWgt />
                    <Extension />
                    <OutpatientIncomeHistory />


                </div>



            </div>

        );
    }
});


module.exports=Outpatient;