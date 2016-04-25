/**
 * Created by jay on 16/4/23.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'

var RegWgt = React.createClass({
    getDefaultProps: function () {

        return {

            registerYesterday:2800,
            registerCurrent:1500
        };

    },


    render:function(){

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
                                <p className="imgText text-center">挂号</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 reg-content" >
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead reg-content-p">昨日挂号总数 <span>{this.props.registerYesterday} </span>人</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead reg-content-p" >目前挂号人次 <span >{this.props.registerCurrent}</span> 人</p>
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

module.exports=RegWgt;