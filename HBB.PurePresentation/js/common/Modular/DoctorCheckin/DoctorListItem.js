/**
 * Created by liu on 2016/4/29.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'


import uuid from "uuid";


var DoctorListItem=React.createClass({

    handleItemClick:function () {

        $(this.refs.doctor).addClass("detail-item-active").siblings().removeClass("detail-item-active");

        this.props.handleItemClick(this.props.UserID);
    },



    render:function () {


        return (

            (

                <tr key={uuid.v1()} ref="doctor" className="detail-item" onClick={this.handleItemClick}>
                    <td>{this.props.DoctorName}</td>
                    <td>{this.props.Time}</td>
                </tr>
            )
        );
    }


});

module.exports=DoctorListItem;