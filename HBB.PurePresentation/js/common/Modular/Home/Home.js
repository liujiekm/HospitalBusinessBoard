/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'


import CheckinWgt from "./CheckinWgt"

import Extension from "../../component/Extension"

import CheckinHistory from "./CheckinHistory"

import OutpatientMedicalServiceWgt from "./OutpatientMedicalServiceWgt"
import OutpatientMedicalServiceHistory from "./OutpatientMedicalServiceHistory"

import EmergencyWgt from "./EmergencyWgt"

import SurgeryWgt  from "./SurgeryWgt"

import ReactEcharts from "react-echarts-component"

var Home = React.createClass({

    render:function () {
        return (

            <div>
                <div className="wgt-group">
                <CheckinWgt />
                <Extension />
                <CheckinHistory />
                </div>


                <div className="wgt-group">
                    <OutpatientMedicalServiceWgt />
                    <Extension />
                    <OutpatientMedicalServiceHistory />
                </div>



                <div className="wgt-group">
                    <EmergencyWgt />
                    <SurgeryWgt />

                </div>


                <div className="wgt-group"></div>

                <div className="wgt-group"></div>


            </div>

        );
    }
});

module.exports=Home;