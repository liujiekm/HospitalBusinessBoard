/**
 * Created by liu on 2016/4/26.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'
var DrugProportionWgt = React.createClass({

    getDefaultProps:function () {

        return {
            chineseMedicine:58,
            westernMedicine:41


        };
    },
    
    render:function () {
        return (
            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/药占比.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="imgText text-center med-symbol-p">药占比</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 inhospital-wgt-content" >
                        <div className="row">
                            <div className="col-md-3">
                                <p className="text-nowrap">昨日</p>
                            </div>
                            <div className="col-md-9">
                            </div>
                        </div>
                        <div className="row">
                            
                            <div className="col-md-6 text-right">
                                <p className="text-big">门诊</p>
                                <p className="lead text-big"><span>{this.props.chineseMedicine}</span>%</p>
                            </div>
                            <div className="col-md-6 text-left text-big">
                                <p className="text-big">住院</p>
                                <p className="lead text-big"><span>{this.props.westernMedicine}</span>%</p>
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

module.exports=DrugProportionWgt;