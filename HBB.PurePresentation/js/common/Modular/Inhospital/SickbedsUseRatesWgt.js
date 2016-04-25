/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'


var SickbedsUseRatesWgt = React.createClass({

    getDefaultProps:function () {
      return {

          sickbedsUseRate:88.1,
          allSickbeds:3200,
          allInpatients:2842
      };
    },


    render:function () {
        return (

            <div className="col-md-6 div_nav wgt-size wgt-margin-right" >
                <div className="row" >
                    <div className="col-md-3 wgt-symbol" >
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/病床使用率.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />

                            </div>
                        </div>

                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p">
                                <p className="imgText text-center">病床使用率</p>
                            </div>

                        </div>

                    </div>

                    <div className="col-md-7 inhospital-wgt-content">
                        <div className="row">
                            <div className="col-md-4"></div>
                            <div className="col-md-4">
                                <p className="lead text-center text-nowrap"><strong>{this.props.sickbedsUseRate}</strong>%</p>
                            </div>
                            <div className="col-md-4"></div>
                        </div>
                        <div className="row">
                            <div className="col-md-8"></div>
                            <div className="col-md-4">
                                <p className="text-center text-nowrap" >总床位数 <strong>{this.props.allSickbeds}</strong>张</p>
                                <p className="text-center text-nowrap" >当前在院 <strong>{this.props.allInpatients}</strong>人</p>
                            </div>
                        </div>
                    </div>

                    <div className="col-md-2 rightGo">

                    </div>
                </div>
            </div>

        );
    }



});

module.exports=SickbedsUseRatesWgt;