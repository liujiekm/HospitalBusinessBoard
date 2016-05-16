/**
 * Created by liu on 2016/4/29.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'



import RightTitle from "../../component/RightTitle"
import DeptMSS from "./DeptMSS"
import DoctorMSS from "./DoctorMSS"
import DeptMSSList from "./DeptMSSList"


import Globle from "../../../Globle"
import options from "../../../option"


var MedicalServiceSituation = React.createClass({

    getInitialState:function () {
      return {
          depts:[],
          doctors:[]


      };
    },

    componentDidMount:function () {

        var that = this;
        $.getJSON(Globle.baseUrl+'OPA/SM',function (items) {
            that.setState({depts:items});
        });


    },
    handleDeptClick:function (specialistID) {
        var that =this;
        $.getJSON(Globle.baseUrl+'OPA/DSM/'+specialistID,function (items) {

            that.setState({doctors:items});
        });
    },

    render:function(){



        return (

            <div className="detail-content">


                <RightTitle titleName="坐诊情况"/>

                <div className="row contentRow" >
                    <div className="col-md-8">
                        <DeptMSS depts={this.state.depts} />
                        <DoctorMSS  doctors={this.state.doctors}/>

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
                            <DeptMSSList depts={this.state.depts} handleDeptClick={this.handleDeptClick} />

                    </div>



                </div>

            </div>



        );
    }



});

module.exports = MedicalServiceSituation