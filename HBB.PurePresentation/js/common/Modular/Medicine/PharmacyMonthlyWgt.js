/**
 * Created by liu on 2016/4/27.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

var PharmacyMonthlyWgt=React.createClass({

    getDefaultProps:function () {
      return {

          outpatientWesternMedicine:2800,
          inpatientAreaWesternMedicine:2300,
        traditionalMedicinePharmacy:1345
      };
    },

    render:function () {
        return (



            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/药房月报.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="imgText text-center med-symbol-p">药房月报</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7">
                        <div className="row">
                            <div className="col-md-5">
                                <p className="text-left" style={{"padding-bottom":"5px"}}>本月入库</p>
                            </div>
                            <div className="col-md-7">
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-center" style={{"margin-bottom": "0px"}}>门诊西药 <span>{this.props.outpatientWesternMedicine} </span>万</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-center" style={{"margin-bottom": "0px"}}>病区西药 <span>{this.props.inpatientAreaWesternMedicine} </span>万</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-center" style={{"margin-bottom":"0px"}}>中药房 <span>{this.props.traditionalMedicinePharmacy}</span> 万</p>
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

module.exports=PharmacyMonthlyWgt;