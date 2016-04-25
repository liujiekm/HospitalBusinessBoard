/**
 * Created by liu on 2016/4/25.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'

var AppointmentsRateWgt = React.createClass({

    getDefaultProps:function () {
      return {

          prestoreRateYesterday:87,
          visitsYesterday:1000000
      }
    },

    render :function () {
        return (

            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/emergency.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />

                            </div>
                        </div>

                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p">

                                <p className="imgText text-center">预约率</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 outpatient-ms-right">
                        <div className="row">
                            <div className="col-md-4">
                                <p className="text-left">昨日 </p>
                            </div><div className="col-md-8">

                        </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-center appointrete-strong" ><strong>{this.props.prestoreRateYesterday}</strong>%</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-8"></div>
                            <div className="col-md-4" >

                                <p className="text-right text-nowrap" ><span>{this.props.visitsYesterday}</span>人次</p>
                            </div>

                        </div>
                    </div>

                    <div className="col-md-2 rightGo" >
                        <a href="Operation.aspx">
                        <img className="img-responsive" src="./img/Home/into.png" />
                    </a>
                    </div>
                </div>
            </div>


        );
    }


});

module.exports=AppointmentsRateWgt;

