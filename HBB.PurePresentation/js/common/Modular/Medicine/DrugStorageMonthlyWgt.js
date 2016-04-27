/**
 * Created by liu on 2016/4/27.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'


var DrugStorageMonthlyWgt = React.createClass({

    getDefaultProps:function () {
      return {
          balanceLastMonth:142,
          storageSum:1244,
            stockRemoval:1198
      };
    },


    render:function () {
        return (

            <div className="col-md-6 div_nav wgt-size wgt-margin-right" >
                <div className="row" >
                    <div className="col-md-3 wgt-symbol">
                        <div className="row ">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/药库月报.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />

                            </div>
                        </div>

                        <div className="row">
                            <div className="col-md-12">
                                <p className="imgText text-center med-symbol-p">药库月报</p>
                            </div>

                        </div>

                    </div>

                    <div className="col-md-7 text-center" style={{"padding-top": "5px"}}>

                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap" style={{"margin-bottom": "3px"}}>上月结余 <span id="balanceLastMonth">2800 </span>万</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap" style={{"margin-bottom": "3px"}}>入库合计 <span id="storageSum">2800 </span>万</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap" style={{"margin-bottom": "4px"}}>出库合计 <span id="stockRemoval">1500</span> 万</p>
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

module.exports=DrugStorageMonthlyWgt;