/**
 * Created by liu on 2016/4/20.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import InputElement from "react-input-mask"

var Config = React.createClass({
    contextTypes: {
        router: React.PropTypes.object
    },

    componentDidMount:function () {
      this.context.router.setRouteLeaveHook(this.props.route,this.routeWillLeave);
    },

    //用户离开当前页面的处理逻辑
    //检查修改
    routeWillLeave:function (nextLocation) {
        console.log(nextLocation);
    },
    handleClick:function () {

        var config = {
            "checkinRate":parseFloat(findDOMNode(this.refs.checkin_rate).value),
            "waitingNum":parseFloat(findDOMNode(this.refs.waiting_num).value),
            "outpatientAppTime":parseFloat(findDOMNode(this.refs.outpatient_app_time).value),
            "outpatientWaitingTime":parseFloat(findDOMNode(this.refs.outpatient_waiting_time).value),
            "outpatientInTime":parseFloat(findDOMNode(this.refs.outpatient_in_time).value),
            "outpatientPayTime":parseFloat(findDOMNode(this.refs.outpatient_pay_time).value),
            "outpatientMedTime":parseFloat(findDOMNode(this.refs.outpatient_med_time).value),
            "checkXTime":parseFloat(findDOMNode(this.refs.check_x_time).value),
            "checkCTTime":parseFloat(findDOMNode(this.refs.check_ct_time).value),
            "checkMRITime":parseFloat(findDOMNode(this.refs.check_mri_time).value),
            "checkBTime":parseFloat(findDOMNode(this.refs.check_b_time).value),
            "checkoutEndoscopeTime":parseFloat(findDOMNode(this.refs.checkout_endoscope_time).value)
        };

        $.post(baseUrl+'CFG/MC',JSON.stringify(config),function(){

            
        }.bind(this));
   },

    render:function () {

        return (

                <form className="form-horizontal col-md-4 col-sm-4 col-xs-4">
                    <div className="form-group">

                        <div className="input-group">
                                <div className="input-group-addon">签到率</div>
                                <InputElement mask="99.9" type="text" className="form-control"  ref="checkin_rate" placeholder="医生签到率" defaultValue="98.7"
                                        />
                                <div className="input-group-addon">%</div>


                        </div>

                    </div>
                    <div className="form-group">
                        <div className="input-group">
                            <div className="input-group-addon">候诊人数</div>

                            <InputElement mask="999999" type="text" className="form-control"  ref="waiting_num" placeholder="候诊人数"
                                          defaultValue="2000"    />
                            <div className="input-group-addon">人</div>
                            </div>

                    </div>

                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">门诊预约时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="outpatient_app_time" placeholder="门诊预约时长"
                                          defaultValue="8.7"   />
                            <div className="input-group-addon">天</div>
                        </div>

                    </div>

                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">门诊候诊时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="outpatient_waiting_time" placeholder="门诊候诊时长"
                                          defaultValue="15.7"     />
                            <div className="input-group-addon">分钟</div>
                        </div>

                    </div>

                    <div className="form-group">


                        <div className="input-group">
                            <div className="input-group-addon">门诊就诊时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="outpatient_in_time" placeholder="门诊就诊时长"
                                          defaultValue="8.7"    />
                            <div className="input-group-addon">分钟</div>
                        </div>

                    </div>
                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">门诊缴费时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="outpatient_pay_time" placeholder="门诊缴费时长"
                                          defaultValue="8.7"      />
                            <div className="input-group-addon">分钟</div>
                        </div>

                    </div>
                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">门诊取药时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="outpatient_med_time" placeholder="门诊取药时长"
                                          defaultValue="8.7"    />
                            <div className="input-group-addon">分钟</div>
                        </div>

                    </div>

                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">X光预约时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="check_x_time" placeholder="X光预约时长"
                                          defaultValue="5.7"   />
                            <div className="input-group-addon">天</div>
                        </div>

                    </div>
                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">CT预约时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="check_ct_time" placeholder="CT预约时长"
                                          defaultValue="8.7"  />
                            <div className="input-group-addon">天</div>
                        </div>

                    </div>
                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">MRI预约时长</div>
                            <InputElement mask="99.9" type="text" className="form-control" ref="check_mri_time" placeholder="MRI预约时长"
                                          defaultValue="8.7" />
                            <div className="input-group-addon">天</div>
                        </div>

                    </div>
                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">B超预约时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="check_b_time" placeholder="B超预约时长"
                                          defaultValue="8.7"   />
                            <div className="input-group-addon">天</div>
                        </div>

                    </div>

                    <div className="form-group">

                        <div className="input-group">
                            <div className="input-group-addon">内窥镜预约时长</div>
                            <InputElement mask="99.9" type="text" className="form-control"  ref="checkout_endoscope_time" placeholder="内窥镜预约时长"
                                          defaultValue="8.7"  />
                            <div className="input-group-addon">天</div>
                        </div>

                    </div>


                    


                    <div className="form-group">

                        <button className="btn-primary" onClick={this.handleClick}>提交</button>
                    </div>


                </form>


        );
    }

});

//module.exports=Config;

export default Config;