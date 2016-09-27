/**
 * Created by liu on 2016/4/29.
 */
import React, { Component, PropTypes } from 'react'
import { render, findDOMNode } from 'react-dom'
import Globle from "../../../Globle"


import uuid from "uuid";
import DoctorListItem from "./DoctorListItem"

class DoctorList extends Component{

    constructor(props)
    {
        super(props)
        this.state={
            regItems:[],unRegItems:[]
        }
    }

    //获取已签到医生
    getRegisterList(timePoint) {
        var items =[];
        var that = this;
        $.getJSON(Globle.baseUrl+'DCI/RDI/' + timePoint,function (data) {
            $.each(data,function (index,item) {
                items.push(item);
            })

            that.setState({regItems:items});
        });
    }

    //获取未签到
    getUnregList(timePoint) {
        var items =[];
        var that=this;
        $.getJSON(Globle.baseUrl + 'DCI/URDI/' + timePoint,function (data) {
            $.each(data,function (index,item) {
                items.push(item);
            })

            that.setState({unRegItems:items});
        });
    }

    componentWillReceiveProps(nextProps) {
        this.getRegisterList(nextProps.timePoint);
        this.getUnregList(nextProps.timePoint);
    }

    componentDidMount() {

        this.getRegisterList(8);
        this.getUnregList(8);
    }





    render() {

        var tableRegItems=[];
        var that = this;
        this.state.regItems.forEach(function (item) {
            tableRegItems.push(
                <DoctorListItem key={uuid.v1()}  UserID={item.UserID} DoctorName={item.DoctorName} Time={item.RegisterTime} handleItemClick={that.props.handleItemClick} />
            );
        });

        var tableUnregItems=[];
        this.state.unRegItems.forEach(function (item) {
            tableUnregItems.push(
                <DoctorListItem key={uuid.v1()}  UserID={item.UserID} DoctorName={item.DoctorName} Time={item.RegisterTime} handleItemClick={that.props.handleItemClick} />
            );
        })

        return (

            <div className="personPanel">

                <ul className="nav nav-tabs" role="tablist">
                    <li role="presentation" className="active"><a href="#signIned" aria-controls="signIned" role="tab" data-toggle="tab" id="a_signIn">已签到</a></li>
                    <li role="presentation"><a href="#notSignIn" aria-controls="notSignIn" role="tab" data-toggle="tab">未签到</a></li>
                </ul>
                <div className="tab-content personContent">
                    <div role="tabpanel" className="tab-pane  active" id="signIned">
                        <table className="table text-center">
                            <thead>
                            <tr>
                                <td>姓名</td>
                                <td>签到时间</td>
                            </tr>
                            </thead>
                        </table>
                        <div className="tabContent" style={{"height":"530px","overflowY":"auto"}}>
                            <table className="table table-hover text-center">
                                <tbody id="tb_signIned" >
                                  {tableRegItems}
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div role="tabpanel" className="tab-pane" id="notSignIn">
                        <table className="table table-hover text-center">
                            <thead>
                            <tr>
                                <td>姓名</td>
                                <td>排班时间</td>
                            </tr>
                            </thead>
                        </table>
                        <div className="tabContent" style={{"height":"530px","overflowY":"auto"}}>
                            <table className="table table-hover text-center">
                                <tbody id="tb_UnsignIned" >
                                {tableUnregItems}
                                </tbody>

                            </table>
                        </div>
                    </div>

                </div>

            </div>



        );
    }


}

//module.exports= DoctorList;

export default DoctorList;
