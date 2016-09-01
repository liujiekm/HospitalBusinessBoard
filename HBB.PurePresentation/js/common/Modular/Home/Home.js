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
import Globle from "../../../Globle"

import Es6Promise from 'es6-promise'

var Promise = Es6Promise.Promise;

var Home = React.createClass({

    getInitialState:function () {
        return {
            morningSignInRate:95.3,
            morningSignInRateLow:false,
            morningHasSignIn:952,
            morningShouldSignIn:1000,
            afternoonSignInRate:94.8,
            afternoonSignInRateLow:false,
            afternoonHasSignIn:948,
            afternoonShouldSignIn:1000,

            waitingNum:498,
            treatedNum:502,

            severeObservingQuanty:39,
            firstAidQuanty:5,

            hospitalizedNum:2803,
            leaveYeaterday:503,
            IncomeYeaterday:620,
            ratedBeds:60,
            addedBeds:54,
            virtualBeds:12,

            appointmentLastMonth:1.62,
            awaitingDiagnosis:7.5,
            diagnosis:5.1,
            payFees:2.9,
            medicineReceiving:9.4,

            xray:1.62,
            ct:7.5,
            mri:5.1,
            BUltrasonic:2.9,
            endoscope:9.4


        };

    },

    getHomeData:function () {


        var partData={};
        $.getJSON(Globle.baseUrl+'HI/GHI', function (data) {
            partData.morningSignInRate=parseInt(data.RegistrationRateAm * 100);
            partData.afternoonSignInRate=parseInt(data.RegistrationRatePm * 100);
            partData.morningHasSignIn=data.DoctorRegisteredQuantyAm;
            partData.morningShouldSignIn=data.DoctorTotalQuantyAm;
            partData.aftrnoonHasSignIn=data.DoctorRegisteredQuantyPm;
            partData.afternoonShouldSignIn=data.DoctorTotalQuantyPm;
            partData.waitingNum=data.WaitingQuantity;
            partData.treatedNum=data.CompletedTreatQuanty;
            partData.severeObservingQuanty=data.SevereObservingQuanty;
            partData.firstAidQuanty=data.FirstAidQuanty;
            partData.hospitalizedNum=data.HospitalizedQuanty;
            partData.leaveYeaterday=data.YesterdayLeaveHospitalQuanty;
            partData.IncomeYeaterday=data.YesterdayAdminttedHospitalQuanty;
            partData.ratedBeds=data.RatedEmptyBedQuanty;
            partData.addedBeds=data.ExtraBedQuanty;
            partData.virtualBeds=data.VirtualBedQuanty;
            
            $.getJSON(Globle.baseUrl+'CFG/GC',function (config) {

            })
            
            
            this.setState(partData);

        }.bind(this));

        $.getJSON(Globle.baseUrl + 'UE/OPILM',
            function (data) {
                partData.appointmentLastMonth=(data[0] / 60 / 24).toFixed(2);//以天为单位
                partData.awaitingDiagnosis=data[1].toFixed(1);
                partData.diagnosis=data[2].toFixed(1);
                partData.payFees=data[3].toFixed(1);
                partData.medicineReceiving=data[4].toFixed(1);
                this.setState(partData);
            }.bind(this));

        $.getJSON(Globle.baseUrl + 'UE/SIILM',
            function (data) {
                //$('#lines').animateNumber({ number: data.OutPatientRegisterYesterday });

                partData.xray=(data[0] / 60 / 24).toFixed(2);//以天时为单位
                partData.ct=(data[1] / 60 / 24).toFixed(1);
                partData.mri=(data[2] / 60 / 24).toFixed(1);
                partData.BUltrasonic=(data[3] / 60 / 24).toFixed(1);
                partData.endoscope=(data[4] / 60 / 24).toFixed(1);
                this.setState(partData);
            }.bind(this)
        );



    },

    componentDidMount:function () {

        this.getHomeData();
        // setInterval(function () {
        //     this.getHomeData()
        // }.bind(this), 10000);

    },
    render:function () {
        return (

            <div>
                <div className="wgt-group">
                <CheckinWgt  morningSignInRate={this.state.morningSignInRate}
                    morningSignInRateLow={false}
                    morningHasSignIn={this.state.morningHasSignIn}
                    morningShouldSignIn={this.state.morningShouldSignIn}
                    afternoonSignInRate={this.state.afternoonSignInRate}
                    afternoonSignInRateLow={false}
                             afternoonHasSignIn={this.state.afternoonHasSignIn}
                    afternoonShouldSignIn={this.state.afternoonShouldSignIn} />
                <Extension />
                <CheckinHistory />
                </div>


                <div className="wgt-group">
                    <OutpatientMedicalServiceWgt waitingNum={this.state.waitingNum}
                    treatedNum={this.state.treatedNum} />
                    <Extension />
                    <OutpatientMedicalServiceHistory />
                </div>



                <div className="wgt-group">
                    <EmergencyWgt severeObservingQuanty={this.state.severeObservingQuanty}
                    firstAidQuanty={this.state.firstAidQuanty}/>
                    <SurgeryWgt />

                </div>


                <div className="wgt-group">

                    <HospitalizationWgt hospitalizedNum={this.state.hospitalizedNum}
                            leaveYeaterday={this.state.leaveYeaterday}
                            IncomeYeaterday={this.state.IncomeYeaterday}
                            ratedBeds={this.state.ratedBeds}
                            addedBeds={this.state.addedBeds}
                            virtualBeds={this.state.virtualBeds}
                    />
                    <Extension />
                    <EmptyBedsDeptContrast />

                </div>

                <div className="wgt-group-ue">
                    <OutpatientUEWgt appointmentLastMonth={this.state.appointmentLastMonth}
                        awaitingDiagnosis={this.state.awaitingDiagnosis}
                        diagnosis={this.state.diagnosis}
                        payFees={this.state.payFees}
                        medicineReceiving={this.state.medicineReceiving}/>
                </div>

                <div className="wgt-group-ue">

                    <InspectionUEWgt xray={this.state.xray}
                    ct={this.state.ct}
                    mri={this.state.mri}
                    BUltrasonic={this.state.BUltrasonic}
                    endoscope={this.state.endoscope} />
                </div>


            </div>

        );
    }
});

module.exports=Home;