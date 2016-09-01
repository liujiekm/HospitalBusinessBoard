/**
 * Created by liu on 2016/4/27.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'


var DrugStoragePurchaseWgt = React.createClass({

    getDefaultProps:function () {
      return {


          purchaseLastMonth:818
      };
    },
    render:function () {
        return (

            <div className="col-md-6 col-sm-6 col-xs-6 div_nav div_chart wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/药库月报.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="imgText text-center med-symbol-p">药库采购</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 text-center inhospital-wgt-content">
                        <div className="row">
                            <div className="col-md-5">
                                <p className="text-nowrap">上月采购总额</p>
                            </div>
                            <div className="col-md-7">
                            </div>
                        </div>
                        <div className="row">

                            <div className="col-md-12 text-center" style={{"paddingTop": "10px"}}>

                                <p className="lead text-big"><span >{this.props.purchaseLastMonth}</span>万元</p>
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

module.exports=DrugStoragePurchaseWgt;