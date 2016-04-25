/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'

var InhospitalIncomeWgt = React.createClass({
    getDefaultProps:function () {
      return {

          inhospitalIncomeYesterday:699,
          inhospitalIncomeCurrent:612
      };
    },

    render:function () {
        return (


            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/收入.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p" >
                                <p className="imgText text-center">住院收入</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 inhospital-wgt-content" >
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-center reg-content-p">昨日 <strong>{this.props.inhospitalIncomeYesterday} </strong>万元</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-center reg-content-p" >今日目前 <strong >{this.props.inhospitalIncomeCurrent}</strong>万元</p>
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

module.exports=InhospitalIncomeWgt;