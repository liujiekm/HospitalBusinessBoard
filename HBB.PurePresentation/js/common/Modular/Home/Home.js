/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'


import CheckinWgt from "./CheckinWgt"
import CheckinHistory from "./CheckinHistory"

import ReactEcharts from "react-echarts-component"

var Home = React.createClass({

    render:function () {
        return (

            <div>
                
                <CheckinWgt />
                <CheckinHistory />
            </div>

        );
    }
});

module.exports=Home;