/**
 * Created by liu on 2016/5/4.
 */



import React from 'react'
import { render, findDOMNode } from 'react-dom'


var RightTitle =React.createClass({

    getDefaultProps:function () {

        return {
            titleName:"内容"
        };
    },

    render:function () {
        return (

            <div className="row">
                <div className="col-md-2">
                    <span className="glyphicon glyphicon-arrow-left returnPage" aria-hidden="true" id="returnLink"></span>
                </div>
                <div className="col-md-6"></div>
                <div className="col-md-4 moduleIndicate">

                    <span className="lead text-nowrap" id="moduleName">{this.props.titleName}</span>
                </div>
            </div>


        );
    }


});



module.exports=RightTitle;
