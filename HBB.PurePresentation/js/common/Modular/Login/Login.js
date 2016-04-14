/**
 * Created by liu on 2016/4/14.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'

var Login = React.createClass({

    
    handleSubmit:function () {

    },
    render:function () {

        return (

            <div className="container-fluid">
                <div className="row">
                    <div className="col-md-4">
                    </div>
                    <div className="col-md-4 loginContainer">


                        <div className="errors-container"></div>

                        <form id="form1" className="login-form form-horizontal">
                            <div className="login-header">

                                <img src="./img/login/logo.png" className='logoImg' />

                                <p className="lead text-center loginSymbol-position">医院业务看板</p>
                            </div>
                            <div className="formGroup">
                                <img className="loginIcon" src="./img/login/LoginNmae_icon.png"/>
                                <input type="text" className="formControl" id="account" name="username" autoComplete="off" />
                            </div>
                            <div className="formGroup">
                                <img className="loginIcon" src="./img/login/LoginPsw_icon.png"/>
                                <input type="password" className="formControl" id="pwd" name="password" autoComplete="off"  />
                            </div>
                            <div className="formGroupBtn btnBG">
                                <button type="submit" id="SignIn" className="btn loginBtn" onClick={this.handleSubmit}  >
                                    登录
                                </button>
                            </div>
                            <div className="login-footer">

                            </div>

                        </form>



                    </div>

                    <div className="col-md-4"></div>


                </div>
            </div>
        );
    }


});

module.exports=Login;