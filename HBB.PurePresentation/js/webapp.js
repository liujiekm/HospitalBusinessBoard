/**
 * Created by liu on 2016/4/14.
 */
import "../lib/bootstrap/css/bootstrap.min.css"
import "../css/layout.css"

import React, { Component, PropTypes } from 'react'
import { render, findDOMNode } from 'react-dom'

import { browserHistory, Router, Route, IndexRoute, Link ,hashHistory} from 'react-router'
import Home from "./common/Modular/Home/Home"
import Outpatient from "./common/Modular/Outpatient/Outpatient"
import Inhospital from "./common/Modular/Inhospital/Inhospital"
import Medicine from "./common/Modular/Medicine/Medicine"
import Operation from "./common/Modular/Operation/Operation"
import DoctorCheckin from "./common/Modular/DoctorCheckin/DoctorCheckin"
import AdmissionDischarge from './common/Modular/AdmissionDischarge/AdmissionDischarge'
import OutpatientExperience from './common/Modular/OutpatientExperience/OutpatientExperience'
import MSS from "./common/Modular/MedicalServiceSituation/MedicalServiceSituation"
import Emergency from "./common/Modular/Emergency/EmergencyDetail"
import Login from "./common/Modular/Login/Login"
import Config from "./common/Modular/Config/Config"
import FileUploadComponenet from "./common/Modular/Config/FileUploadComponent"
import App from "./app"



var isReactComponent = (obj) => Boolean(obj && obj.prototype && Boolean(obj.prototype.isReactComponent));

var component = (component) => {
  return isReactComponent(component)
    ? {component}
    : {getComponent: (loc, cb)=> component(
         comp=> cb(null, comp.default || comp))}
};





class Webapp extends Component{

    render() {
        return (
            <div>
                {this.props.children}
            </div>
        );
    }

}

function hasLogin() {
    return localStorage.getItem('login') === 'true';
}

function requireAuth(nextState, replace) {
    if (!hasLogin()) {
        replace({ pathname: nextState.location.pathname }, '/Login')
    }
}

render((
    <Router history={browserHistory}>
        <Route path="/" component={Webapp}>
            <IndexRoute component={Login} />
            <Route path="Login" component={Login} />
            <Route onEnter={requireAuth} path="/" component={App}>
                <IndexRoute {...component(Home)}/>
                <Route path="Home" {...component(Home)}/>
                <Route path="Inhospital" component={Inhospital} />
                <Route path="Medicine" component={Medicine} />
                <Route path="Operation" component={Operation} />
                <Route path="Outpatient" component={Outpatient} />
                <Route path="Config" component={Config} />
                <Route path="FileUpload" component={FileUploadComponenet} />
                <Route path="Operation" component={Operation} />
                <Route path="DoctorCheckin" component={DoctorCheckin} />
                <Route path="MSS" component={MSS} />
                <Route path="AD"  {...component(Emergency)}/>
                <Route path="OE" component={OutpatientExperience} />
                <Route path="Emergency" {...component(Emergency)} />
            </Route>

        </Route>
    </Router>
), document.getElementById("webapp"));


