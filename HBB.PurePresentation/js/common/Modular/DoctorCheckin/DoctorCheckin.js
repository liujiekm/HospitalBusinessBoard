/**
 * Created by liu on 2016/4/29.
 */
import React, { Component, PropTypes } from 'react'
import { render, findDOMNode } from 'react-dom'

import DoctorCheckinNum from  "./DoctorCheckinNum"
import DoctorCheckinTimePoint from  "./DoctorCheckinTimePoint"
import DoctorList from "./DoctorList"


import RightTitle from "../../component/RightTitle"


class DoctorCheckin extends Component{


    constructor(props)
    {
        super(props)
        this.state={
             userID:8,
            timePoint:9
        }
    }




    //医生签到、排班时间条目点击事件
    handleItemClick(userId) {
        this.setState({userID:userId});
    }
    handleClickTimePoint(timePointString) {
        var timePoint = parseInt(timePointString.substr(0,2));
        this.setState({timePoint:timePoint});
    }
    render() {
        return (

    <div className="detail-content">


        <RightTitle titleName="医生签到"/>

        <div className="row contentRow" >
                <div className="col-md-8">
                    <DoctorCheckinNum handleClickTimePoint={this.handleClickTimePoint}/>
                    <DoctorCheckinTimePoint userID={this.state.userID}/>
                </div>


                <div className="col-md-1">
                    <div className="row nextInfoContainer">
                        <div className="col-md-12 nextInfo">

                            <img className="img-responsive" src="./img/delt.png" />
                        </div>
                    </div>

                    <div className="row nextInfoContainer">
                        <div className="col-md-12 nextInfo">
                            <img className="img-responsive" src="./img/deltLeft.png" />
                        </div>
                    </div>
                </div>

                <div className="col-md-3">
                    <DoctorList timePoint={this.state.timePoint} handleItemClick={this.handleItemClick}/>

                </div>



            </div>

        </div>


        );
    }


}

//module.exports=DoctorCheckin;

export default DoctorCheckin;