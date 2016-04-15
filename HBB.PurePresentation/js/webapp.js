/**
 * Created by liu on 2016/4/14.
 */
import "../lib/bootstrap/css/bootstrap.min.css"
import "../css/layout.css"

import React from 'react';
import { render, findDOMNode } from 'react-dom'

import { browserHistory, Router, Route, IndexRoute, Link ,hashHistory} from 'react-router'



import Home from "./common/Modular/Home/Home"
import Outpatient from "./common/Modular/Outpatient/Outpatient"
import Inhospital from "./common/Modular/Inhospital/Inhospital"
import Medicine from "./common/Modular/Medicine/Medicine"
import Operation from "./common/Modular/Operation/Operation"


import Login from "./common/Modular/Login/Login"

import App from "./app"

var Webapp = React.createClass({
    render:function () {

        return (
            <div>
                {this.props.children}
            </div>
        );
    }

});

render((
    <Router history={browserHistory}>
        <Route path="/" component={Webapp}>

            <IndexRoute component={Login} />
            <Route path="Login" component={Login} >
            </Route>
            <Route path="/" component={App}>
                <IndexRoute component={Home} />
                <Route path="Home" component={Home} />
                <Route path="Inhospital" component={Inhospital} />
                <Route path="Medicine" component={Medicine} />
                <Route path="Operation" component={Operation} />
                <Route path="Outpatient" component={Outpatient} />
            </Route>

        </Route>
    </Router>
), document.getElementById("webapp"));


