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

import HospitalizationWgt from "./HospitalizationWgt"
import EmptyBedsDeptContrast from "./EmptyBedsDeptContrast"

import OutpatientUEWgt from "./OutpatientUEWgt"

import InspectionUEWgt from "./InspectionUEWgt"

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


                <div className="wgt-group">

                    <HospitalizationWgt />
                    <Extension />
                    <EmptyBedsDeptContrast />

                </div>

                <div className="wgt-group-ue">
                    <OutpatientUEWgt />
                </div>

                <div className="wgt-group-ue">

                    <InspectionUEWgt />
                </div>


            </div>

        );
    }
});

module.exports=Home;