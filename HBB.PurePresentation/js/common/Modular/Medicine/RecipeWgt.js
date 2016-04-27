/**
 * Created by liu on 2016/4/27.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

var RecipeWgt=React.createClass({

    getDefaultProps:function () {

        return {

            outPatientPrescription:2088,
            outpatientFormula:1400,
            inhospitalPrescription:1000,
            inhospitalFormula:900
        };

    },


    render:function () {
        return (

            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/处方配方.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="imgText text-center med-symbol-p">处方配方</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 text-nowrap recipe-wgt-content" >
                        <div className="row recipe-wgt-content-title" >
                            <div className="col-md-4">
                            </div>
                            <div className="col-md-4">
                                <p>门诊 </p>
                            </div>
                            <div className="col-md-4">
                                <p>住院 </p>
                            </div>
                        </div>
                        
                        <div className="row" style={{"padding-bottom":"5px"}}>
                            <div className="col-md-4">
                                <p>处方 </p>
                            </div>
                            <div className="col-md-4">
                                <p><span>{this.props.outPatientPrescription}</span>张 </p>
                            </div>
                            <div className="col-md-4">
                                <p><span>{this.props.outpatientFormula}</span>张 </p>
                            </div>
                        </div>
                        
                        <div className="row" style={{"padding-bottom":"5px"}}>
                            <div className="col-md-4">
                                <p>配方 </p>
                            </div>
                            <div className="col-md-4">
                                <p><span>{this.props.inhospitalPrescription}</span>张 </p>
                            </div>
                            <div className="col-md-4">
                                <p><span>{this.props.inhospitalFormula}</span>张 </p>
                            </div>

                        </div>
                        
                    </div>

                    <div className=" leftGo col-md-2 ">
                        
                    </div>
                </div>
            </div>


        );
    }


});

module.exports = RecipeWgt;