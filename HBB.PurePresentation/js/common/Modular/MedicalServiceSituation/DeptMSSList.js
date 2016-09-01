/**
 * Created by liu on 2016/5/4.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import DeptMSSItem from "./DeptMSSItem"


import uuid from "uuid"

const DeptMSSList = React.createClass({

    
    
    componentDidMount:function () {
        

    },

    render:function () {
        
        var depts = [];
        var that = this;
        this.props.depts.forEach(function (item) {
            var personCount = item.HZnums + '/' + item.JZnums;
            depts.push(<DeptMSSItem key={uuid.v1()} specialistID={item.SpecialistID} deptName={item.SpecialistName} personCount={personCount} handleDeptClick={that.props.handleDeptClick} />);
        });
        
        
        return (

            <div className="col-md-12 mss-dept-list ">
                <table className="table ">
                    <thead>
                    <tr>
                        <td colSpan="2">全科室坐诊情况</td>
                    </tr>
                    <tr>
                        <td style={{"width":"50%"}}>科室</td>
                        <td>候诊/已就诊</td>
                    </tr>
                    </thead>
                </table>
                <div style={{"height":"85%","overflowY":"auto"}}>
                    <table className="table table-hover">

                        <tbody>
                            {depts}
                        </tbody>
                       

                    </table>
                </div>
            </div>
            
        );
    }

});

module.exports = DeptMSSList;