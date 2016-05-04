/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'

import OperationClassCountWgt from "./OperationClassCountWgt"

import OperationDetail from "./OperationDetail"
import ReactEcharts from "react-echarts-component"

var Operation = React.createClass({

    render:function () {
        return (

            <div>

                <div className="wgt-group">
                    <OperationClassCountWgt />
                    <OperationDetail />
                </div>



            </div>

        );
    }
});

module.exports=Operation;