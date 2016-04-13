/**
 * Created by liu on 2016/4/13.
 */

import "/lib/bootstrap/css/bootstrap.min.css"
import "/css/layout.css"

import React from 'react';
import { render, findDOMNode } from 'react-dom'

//import { Router, Route, hashHistory, IndexRoute, browserHistory } from 'react-router'

import { browserHistory, Router, Route, IndexRoute, Link } from 'react-router'


import LeftNav from "/js/common/component/LeftNav"
import Clock from "/js/common/component/Clock"
import UserControl from "/js/common/component/UserControl"
var App = React.createClass({
    render:function () {
        return (
            <div className="container-fluid">
                <div className="row">


                    <!--左侧导航-->
                    <div className="leftNavigation col-md-2 col-sm-2 col-xs-2">

                        <img className="img-responsive center-block" style="padding-top: 30px" src="/img/Home/logo.png" />

                        <LeftNav />

                        <img className="img-responsive center-block" src="/img/演示.png" width="120" height="40" />
                        <img className="img-responsive center-block lenovo" src="/img/Home/lenovo.png" />
                    </div>

                    <!--右侧报表内容-->
                    <div className="col-md-10 col-sm-10 col-xs-10 col-md-offset-2">

                        <div id="div_header" className="row">
                            <div className="col-md-6 col-sm-6 col-xs-6">
                                <Clock />
                            </div>

                            <!--用户功能区-->
                            <div className="col-md-4 col-sm-4 col-xs-4 userzone" >

                                <UserControl />

                            </div>

                            <div className="col-md-2"></div>
                        </div>


                        <div className="row reportRow">

                            {this.props.children}

                        </div>

                        
                    </div>

                </div>
            </div>


        );
    }
});