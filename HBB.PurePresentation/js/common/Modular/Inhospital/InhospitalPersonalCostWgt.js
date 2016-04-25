/**
 * Created by liu on 2016/4/25.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'


var InhospitalPersonalCostWgt = React.createClass({
    getDefaultProps:function () {
      return {
          avgPersonalCostYesterday:1024,
          avgPersonalCostLastMonth:652,
          avgPersonalCostLastYear:864
      };
    },

    render:function () {
        return (

            <div className="col-md-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3 wgt-symbol">
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/住院人均.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12 wgt-symbol-p" >
                                <p className="imgText text-center">住院人均</p>
                            </div>
                        </div>

                    </div>



                    <div className="col-md-7 inhospital-wgt-content" >
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap text-center" style={{"margin-bottom": "3px"}}>昨日人均费用 <strong>{this.props.avgPersonalCostYesterday}</strong>元</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap text-center" style={{"margin-bottom": "3px"}}>上月人均费用 <strong>{this.props.avgPersonalCostLastMonth}</strong>元</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap text-center" style={{"margin-bottom": "3px"}}>去年人均费用 <strong>{this.props.avgPersonalCostLastYear}</strong> 元</p>
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

module.exports=InhospitalPersonalCostWgt;