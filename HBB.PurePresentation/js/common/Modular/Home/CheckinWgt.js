/**
 * Created by liu on 2016/4/15.
 */
import React,{Component,PropTypes} from 'react'
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import { Link } from 'react-router'

//医生签到部件
class CheckinWgt extends Component{

        getClass(warning) {

            return classnames({
                'lead':true,
                'indicate-alarm':warning

            });
        }
        getDefaultProps () {
            return {
                morningSignInRate:95.3,
                morningSignInRateLow:false,
                morningHasSignIn:953,
                morningShouldSignIn:1000,
                afternoonSignInRate:94.8,
                afternoonSignInRateLow:false,
                afternoonHasSignIn:948,
                afternoonShouldSignIn:1000
            };
        }
        render() {

            return(
                <div className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size wgt-margin-right">
                    <div className="row">
                        <div className="col-md-2 col-sm-2 col-xs-2 wgt-symbol" >
                            <div className="row">
                                <div className="col-md-12">
                                    <img className="img-responsive" src="./img/Home/outpatientSignin.png" />
                                        <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                                            <p className="imgText text-center">医生签到</p>
                                </div>
                            </div>

                        </div>

                        <div className="col-md-4 col-sm-4 col-xs-4 checkin-wgt-content wgt-content-position" >
                            <div className="row">
                                <div className="col-md-12 mobilePadding">
                                    <p className={this.getClass(this.props.morningSignInRateLow)}>上午 <strong id="morningSignInRate">{this.props.morningSignInRate}</strong>%</p>
                                </div>
                            </div>
                            <div className="row" style={{height: '10px'}}>
                            </div>
                            <div className="row">
                                <div className="col-md-12 mobilePadding">
                                    <p>已签到 <span id="morningHasSignIn">{this.props.morningHasSignIn}</span>人</p>
                                    <p>应签到 <span id="morningShouldSignIn">{this.props.morningShouldSignIn} </span>人</p>
                                </div>

                            </div>
                        </div>

                        <div className="col-md-4 col-sm-4 col-xs-4 checkin-wgt-content wgt-content-position" >
                            <div className="row">
                                <div className="col-md-12 mobilePadding">

                                    <p className={this.getClass(this.props.afternoonSignInRateLow)}>下午 <strong id="afternoonSignInRate">{this.props.afternoonSignInRate}</strong>%</p>
                                </div>
                            </div>
                            <div className="row" style={{height: '10px'}}>
                            </div>
                            <div className="row">
                                <div className="col-md-12 mobilePadding">
                                    <p>已签到 <span id="afternoonHasSignIn">{this.props.afternoonHasSignIn}</span>人</p>
                                    <p>应签到 <span id="afternoonShouldSignIn">{this.props.afternoonShouldSignIn} </span>人</p>
                                </div>

                            </div>
                        </div>

                        <div className=" leftGo col-md-2 col-sm-2 col-xs-2 ">
                            <Link to="DoctorCheckin">
                                <img className="img-responsive" src="./img/Home/into.png" />

                            </Link>
                        </div>
                    </div>
                </div>
            
            );
        }

}

//module.exports = CheckinWgt;

export default CheckinWgt;