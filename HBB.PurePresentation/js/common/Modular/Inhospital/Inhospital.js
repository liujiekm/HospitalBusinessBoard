/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'

import ReactEcharts from "react-echarts-component"

import AdmissionDischargeWgt from "./AdmissionDischargeWgt"
import AdmissionDischargeHistory from "./AdmissionDischargeHistory"

import Extension from "../../component/Extension"

import SickbedsUseRatesWgt from "./SickbedsUseRatesWgt"
import  SickbedsUseRateHistory from "./SickbedsUseRateHistory"

import InhospitalIncomeWgt from "./InhospitalIncomeWgt"

import InhospitalIncomeHistory from "./InhospitalIncomeHistory"

import InhospitalPersonalCostWgt from "./InhospitalPersonalCostWgt"
import InhospitalPersonalCostHistory  from "./InhospitalPersonalCostHistory"

import RedirectComponent from "../../component/RedirectComponent"

var Inhospital = React.createClass({

    render:function () {
        return (

            <div>

                <div className="wgt-group">
                    <AdmissionDischargeWgt />

                    <Extension />

                    <AdmissionDischargeHistory />


                </div>

                <div className="wgt-group">
                    <SickbedsUseRatesWgt />
                    <Extension />
                    <SickbedsUseRateHistory />
                </div>

                <div className="wgt-group">
                    <InhospitalIncomeWgt />
                    <Extension />
                    <InhospitalIncomeHistory />
                </div>

                <div className="wgt-group">
                    <InhospitalPersonalCostWgt />
                    <Extension />
                    <InhospitalPersonalCostHistory />
                </div>

                <div className="wgt-group">
                    <RedirectComponent imgUrl="./img/床位查询.png" componentName="床位查询"  redirectUrl="#" />

                    <RedirectComponent imgUrl="./img/欠费.png" componentName="住院欠费"  redirectUrl="#"/>
                </div>


            </div>

        );
    }
});

module.exports=Inhospital;