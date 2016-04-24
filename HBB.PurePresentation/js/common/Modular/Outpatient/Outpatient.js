/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'

import ReactEcharts from "react-echarts-component"

import Extension from "../../component/Extension"

import RegWgt from "./RegWgt"


var Outpatient = React.createClass({

    render:function () {
        return (

            <div>
                <div className="wgt-group">
                    <RegWgt />

                    <Extension />

                </div>
            </div>

        );
    }
});


module.exports=Outpatient;