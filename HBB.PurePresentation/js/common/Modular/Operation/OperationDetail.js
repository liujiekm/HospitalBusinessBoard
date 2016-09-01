/**
 * Created by liu on 2016/4/28.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import DatePicker from 'react-datepicker'
import moment from 'moment'
import RightTitle from "../../component/RightTitle"
import 'react-datepicker/dist/react-datepicker.css';


var OperationDetail = React.createClass({
    


    getInitialState:function () {
        return {
            startDate: moment(),
            endDate:moment()
        }

    },
    handleStartChange:function (date) {
        this.setState({

            startDate:date
        });
    },

    handleEndChange:function (date) {
        this.setState({

            endDate:date
        });
    },
    componentDidMount:function () {


    },

    render:function () {
        return (

            <div className="col-md-12 col-sm-12 col-xs-12 operation-detail-content">
                
                

                <RightTitle titleName="手术查询" returnLink="Home"/>

                <div className="row operation-detail-content-row">
                    <div className="col-md-12">
                        <div className="row" style={{"marginTop":"50px"}}>
                            <div className="col-md-2"></div>
                            <div className="col-md-6">
                                
                                <input type="text" className="input-lg" id="searchContent" autoComplete="off" />

                                

                            </div>
                            <div className="col-md-2">
                                <button className="btn btn-lg" id="search" type="button"  onclick="OperationSearch()">查询</button>
                            </div>
                            <div className="col-md-2"></div>
                        </div>

                        <div className="row" style={{"marginTop":"20px"}}>
                            <div className="col-md-2"></div>

                            <div className="col-md-5">

                                <DatePicker locale={"zh-cn"} className="datepicker"
                                    selected={this.state.startDate}
                                    onChange={this.handleStartChange} />

                                <DatePicker locale={"zh-cn"} className="datepicker"
                                    selected={this.state.endDate}
                                    onChange={this.handleEndChange} />

                            </div>
                            <div className="col-md-5" style={{"paddingLeft":"0px"}}>
                                <div className="btn-group" role="group">
                                    <button type="button" className="btn btn-default operation-btn-lick" value="01,02" id="hospital">全院</button>
                                    <button type="button" className="btn btn-default" value="01" id="hospitalOld">老院区</button>
                                    <button type="button" className="btn btn-default" value="02" id="hospitalNew">新院区</button>
                                </div>
                            </div>

                            

                        </div>


                        <div className="row" style={{"marginTop":"30px"}}>
                            <div className="col-md-2"></div>
                            <div className="col-md-3">
                                <div className="radio">
                                    <label>
                                        <input type="radio" name="searchBaseOn" value="category" checked />
                                            按类别（特类至四类）
                                    </label>
                                </div>


                            </div>
                            <div className="col-md-5" id="cb_operationType">
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="specialClass" name="operationType" checked="checked" />
                                        特类
                                </label>
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="fourthClass" name="operationType" checked="checked"  />
                                        四类
                                </label>
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="thirdClass" name="operationType" checked="checked"  />
                                        三类
                                </label>
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="secondClass" name="operationType" checked="checked" />
                                        二类
                                </label>
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="firstClass" name="operationType" checked="checked"  />
                                        一类
                                </label>


                            </div>
                            <div className="col-md-2"></div>

                        </div>


                        <div className="row">
                            <div className="col-md-2"></div>
                            <div className="col-md-3">

                                <div className="radio">
                                    <label>
                                        <input type="radio" name="searchBaseOn" value="dept"  />
                                            按科室
                                    </label>
                                </div>


                            </div>
                            <div className="col-md-5">
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="" checked="checked" disabled="disabled" />
                                        按专科下病区
                                </label>
                            </div>
                            <div className="col-md-2"></div>

                        </div>


                        <div className="row">
                            <div className="col-md-2"></div>
                            <div className="col-md-3">

                                <div className="radio">
                                    <label>
                                        <input type="radio" name="searchBaseOn" value="disease"  />
                                            按疾病
                                    </label>
                                </div>


                            </div>
                            <div className="col-md-5">
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="" checked="checked" disabled="disabled" />
                                        模糊查询，提供手术名称选取
                                </label>
                            </div>
                            <div className="col-md-2"></div>

                        </div>


                        <div className="row">
                            <div className="col-md-2"></div>
                            <div className="col-md-3">

                                <div className="radio">
                                    <label>
                                        <input type="radio" name="searchBaseOn" value="doctor" />
                                            按医生
                                    </label>
                                </div>

                            </div>
                            <div className="col-md-5">
                                <label className="checkbox-inline">
                                    <input type="checkbox" value="" checked="checked" disabled="disabled" />
                                        医生工作量
                                </label>
                            </div>
                            <div className="col-md-2"></div>

                        </div>

                    </div>
                </div>
            </div>
            
            
            
        );
    }
    
    
    
});


module.exports=OperationDetail;