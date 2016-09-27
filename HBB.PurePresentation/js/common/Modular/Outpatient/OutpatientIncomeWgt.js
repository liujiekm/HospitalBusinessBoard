/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'

var OutpatientIncomeWgt = React.createClass({

    render :function () {
        return (

            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/medicalService.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p" >
                                <p className="imgText text-center">门诊收入</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 reg-content" >
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead reg-content-p text-center">昨日 <span>{this.props.outpatientIncomingYesterday} </span>万元</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead reg-content-p text-center" >今日目前 <span >{this.props.outpatientIncomingCurrent}</span> 万元</p>
                            </div>

                        </div>
                    </div>

                    <div className=" leftGo col-md-2">
                    </div>
                </div>
            </div>
            
        );
    }
    
    
});


OutpatientIncomeWgt.defaultProps={

    outpatientIncomingYesterday:647,
    outpatientIncomingCurrent:598

}


module.exports=OutpatientIncomeWgt;