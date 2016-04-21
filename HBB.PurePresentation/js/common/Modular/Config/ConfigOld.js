/**
 * Created by liu on 2016/4/19.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import "react-input-mask"



//配置数据标识的阈值，以便警示，通知
var ConfigOld = React.createClass({
    propTypes:{

        errors:React.PropTypes.object,
        validate:React.PropTypes.func,
        isValid:React.PropTypes.func,
        handleValidation:React.PropTypes.func,
        getValidationMessages:React.PropTypes.func,
        clearValidations:React.PropTypes.func
    },


    validatorTypes:function () {
        var base = Joi.object().keys({
            checkinRate:Joi.number().min(0).max(100),
            waitingNum:Joi.number().min(0),
            outpatientAppTime:Joi.number().greater(0),
            outpatientWaitingTime:Joi.number().greater(0),
            outpatientInTime:Joi.number().greater(0),
            outpatientPayTimeg:Joi.number().greater(0),
            outpatientMedTime:Joi.number().greater(0),
            checkXTime:Joi.number().greater(0),
            checkCTTime:Joi.number().greater(0),
            checkMRITime:Joi.number().greater(0),
            checkBTime:Joi.number().greater(0),
            checkoutEndoscopeTime:Joi.number().greater(0)
        });

        return base;
    },

    getValidatorData:function () {
      return {

          checkinRate:findDOMNode(this.refs.checkin_rate).value,
          waitingNum:findDOMNode(this.refs.waiting_num).value,
          outpatientAppTime:findDOMNode(this.refs.outpatient_app_time).value,
          outpatientWaitingTime:findDOMNode(this.refs.outpatient_waiting_time).value,
          outpatientInTime:findDOMNode(this.refs.outpatient_in_time).value,
          outpatientPayTimeg:findDOMNode(this.refs.outpatient_pay_timeg).value,
          outpatientMedTime:findDOMNode(this.refs.outpatient_med_time).value,
          checkXTime:findDOMNode(this.refs.check_x_time).value,
          checkCTTime:findDOMNode(this.refs.check_ct_time).value,
          checkMRITime:findDOMNode(this.refs.check_mri_time).value,
          checkBTime:findDOMNode(this.refs.check_b_time).value,
          checkoutEndoscopeTime:findDOMNode(this.refs.checkout_endoscope_time).value

      };
    },

    renderHelpText:function(msg)
    {
        return (
            <span className="help-block">{msg}</span>

        );
    },


    getClass:function (field) {

        return classnames({
            'form-group':true,
            'has-error':!this.props.isValid(field)

        });
    },
    handleClick:function (e) {

        e.preventDefault();
        const onValidate=function (error) {
            if(error)
            {
                console.log(error);
                return false;
            }else
            {
                //提交服务
                console.log("OK");
            }
        };

        this.props.validate(onValidate);
    },

    render:function () {
        
        return(
            <div>
                <form className="form-horizontal">
                    <div className={this.getClass('checkinRate')}>
                        <label htmlFor="checkin_rate" className="col-sm-2 control-label">签到率</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="checkin_rate" placeholder="医生签到率"
                                   onBlur={this.props.handleValidation('checkinRate')} />%
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('checkinRate'))}
                    </div>
                    <div className={this.getClass('waitingNum')}>
                        <label htmlFor="waiting_num" className="col-sm-2 control-label">候诊人数</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="waiting_num" placeholder="候诊人数"
                                   onBlur={this.props.handleValidation('waitingNum')} />
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('waitingNum'))}
                    </div>
                    <div className={this.getClass('outpatientAppTime')}>
                        <label htmlFor="outpatient_app_time" className="col-sm-2 control-label">门诊预约时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="outpatient_app_time" placeholder="门诊预约时长"
                                   onBlur={this.props.handleValidation('outpatientAppTime')} />天
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('outpatientAppTime'))}
                    </div>

                    <div className={this.getClass('outpatientWaitingTime')}>
                        <label htmlFor="outpatient_waiting_time" className="col-sm-2 control-label">门诊候诊时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="outpatient_waiting_time" placeholder="门诊候诊时长"
                                   onBlur={this.props.handleValidation('outpatientWaitingTime')} />分钟
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('outpatientWaitingTime'))}
                    </div>
                    <div className={this.getClass('outpatientInTime')}>
                        <label htmlFor="outpatient_in_time" className="col-sm-2 control-label">门诊就诊时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="outpatient_in_time" placeholder="门诊就诊时长"
                                   onBlur={this.props.handleValidation('outpatientInTime')} />分钟
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('outpatientInTime'))}
                    </div>
                    <div className={this.getClass('outpatientPayTime')}>
                        <label htmlFor="outpatient_pay_time" className="col-sm-2 control-label">门诊缴费时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="outpatient_pay_time" placeholder="门诊缴费时长"
                                   onBlur={this.props.handleValidation('outpatientPayTime')} />分钟
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('outpatientPayTime'))}
                    </div>
                    <div className={this.getClass('outpatientMedTime')}>
                        <label htmlFor="outpatient_med_time" className="col-sm-2 control-label">门诊取药时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="outpatient_med_time" placeholder="门诊取药时长"
                                   onBlur={this.props.handleValidation('outpatientMedTime')} />分钟
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('outpatientMedTime'))}
                    </div>

                    <div className={this.getClass('checkXTime')}>
                        <label htmlFor="check_x_time" className="col-sm-2 control-label">X光预约时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="check_x_time" placeholder="X光预约时长"
                                   onBlur={this.props.handleValidation('checkXTime')} />天
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('checkXTime'))}
                    </div>
                    <div className={this.getClass('checkCTTime')}>
                        <label htmlFor="check_ct_time" className="col-sm-2 control-label">CT预约时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="check_ct_time" placeholder="CT预约时长"
                                   onBlur={this.props.handleValidation('checkCTTime')} />天
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('checkCTTime'))}
                    </div>
                    <div className={this.getClass('checkMRITime')}>
                        <label htmlFor="check_mri_time" className="col-sm-2 control-label">MRI预约时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control" ref="check_mri_time" placeholder="MRI预约时长"
                                   onBlur={this.props.handleValidation('checkMRITime')} />天
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('checkMRITime'))}
                    </div>
                    <div className={this.getClass('checkBTime')}>
                        <label htmlFor="check_b_time" className="col-sm-2 control-label">B超预约时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="check_b_time" placeholder="B超预约时长"
                                   onBlur={this.props.handleValidation('checkBTime')} />天
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('checkBTime'))}
                    </div>

                    <div className={this.getClass('checkoutEndoscopeTime')}>
                        <label htmlFor="checkout_endoscope_time" className="col-sm-2 control-label">内窥镜预约时长</label>
                        <div className="col-sm-2">
                            <input type="text" className="form-control"  ref="checkout_endoscope_time" placeholder="内窥镜预约时长"
                                   onBlur={this.props.handleValidation('checkoutEndoscopeTime')} />天
                        </div>
                        {this.renderHelpText(this.props.getValidationMessages('checkoutEndoscopeTime'))}
                    </div>

                    <div className="form-group">

                        <button className="btn-primary" onClick={this.handleClick}>提交</button>
                    </div>


                </form>
                
            </div>
        );
    }
    
    
});


//module.exports=validation(strategy)(Config);
