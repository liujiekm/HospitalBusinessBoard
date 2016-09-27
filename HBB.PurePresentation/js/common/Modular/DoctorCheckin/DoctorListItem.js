/**
 * Created by liu on 2016/4/29.
 */
import React, { Component, PropTypes } from 'react'
import { render, findDOMNode } from 'react-dom'


import uuid from "uuid";


class DoctorListItem extends Component{

    handleItemClick() {

        $(this.refs.doctor).addClass("detail-item-active").siblings().removeClass("detail-item-active");

        this.props.handleItemClick(this.props.UserID);
    }



    render() {


        return (

            (

                <tr key={uuid.v1()} ref="doctor" className="detail-item" onClick={this.handleItemClick.bind(this)}>
                    <td>{this.props.DoctorName}</td>
                    <td>{this.props.Time}</td>
                </tr>
            )
        );
    }


}

//module.exports=DoctorListItem;

export default DoctorListItem;