/**
 * Created by liu on 2016/4/22.
 */

import React from 'react'
import { render, findDOMNode } from 'react-dom'


var Logo= React.createClass({

    getDefaultProps:function () {

        return {
            Url:"../../../img/Home/Hname.png"

        };

    },



    render:function () {
        return (
            <div style={{"paddingTop": "15px"}} class="col-md-2">
                <img src={this.props.Url} height="24" width="204" class="hospitalLogo" />
            </div>
        );
    }


});