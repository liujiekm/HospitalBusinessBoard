/**
 * Created by liu on 2016/5/4.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import uuid from "uuid";

const DeptMSSItem = React.createClass({
    handleItemClick:function () {
        $(this.refs.dept).addClass("detail-item-active").siblings().removeClass("detail-item-active");
        this.props.handleDeptClick(this.props.specialistID);
    },
    render:function () {
        return (
            <tr key={uuid.v1()} ref="dept" className="detail-item" onClick={this.handleItemClick}>
                <td>{this.props.deptName}</td>
                <td>{this.props.personCount}</td>
            </tr>
        );
    }
});


module.exports=DeptMSSItem;