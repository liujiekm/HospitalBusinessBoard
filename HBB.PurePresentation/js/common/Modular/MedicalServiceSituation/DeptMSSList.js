/**
 * Created by liu on 2016/5/4.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'
import DeptMSSItem from "./DeptMSSItem"

const DeptMSSList = React.createClass({

    
    
    componentDidMount:function () {
        

    },

    render:function () {
        
        var depts = [];

        this.props.depts.forEach(function (item) {
            var that = this;
            depts.push(<DeptMSSItem specialistID={item.SpecialistID} deptName={item.SpecialistName} personCount={that.props.HZnums + '/' + that.props.JZnums} handleDeptClick={that.props.handleDeptClick} />);
        });
        
        
        return (

            <div className="col-md-12 personContent">
                <table className="table">
                    <thead>
                    <tr>
                        <td colspan="2">全科室坐诊情况</td>
                    </tr>
                    <tr>
                        <td style={{"width":"50%"}}>科室</td>
                        <td>候诊/已就诊（人）</td>
                    </tr>
                    </thead>
                </table>
                <div style={{"height":"85%","overflowY":"auto"}}>
                    <table className="table table-hover">
                        <tbody>



                        </tbody>

                    </table>
                </div>
            </div>
            
        );
    }

});

module.exports = DeptMSSList;