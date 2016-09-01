/**
 * Created by liu on 2016/5/4.
 */



import React from 'react'
import { render, findDOMNode } from 'react-dom'

import {Link} from 'react-router'


var RightTitle =React.createClass({

    getDefaultProps:function () {

        return {
            returnLink:"Home",
            titleName:"内容"
        };
    },

    render:function () {
        return (

            <div className="row">
                <div className="col-md-2">
                    <Link to={this.props.returnLink}>
                        <span className="glyphicon glyphicon-arrow-left returnPage" aria-hidden="true"></span>
                    </Link>
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
