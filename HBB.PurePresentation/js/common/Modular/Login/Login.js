/**
 * Created by liu on 2016/4/14.
 */

import React from 'react';
import { render, findDOMNode } from 'react-dom'



var Login = React.createClass({

    
    handleSubmit:function (e) {
        e.preventDefault();
        e.stopPropagation();

        var account = this.refs.account.value;
        var pwd = this.refs.pwd.value;

        if (pwd !== 'password') {
            return;
        }
        localStorage.setItem('login', 'true')
        var location = this.props.location;

        if (location.state && location.state.nextPathname) {
            this.props.history.replaceState(null, location.state.nextPathname);
        } else {
            this.props.history.replaceState(null, '/Home');
        }

        // $.post(baseUrl+'AUTH/VC',{account:account,certificate:pwd},function(result){
        //     if(result)
        //     {
        //
        //     }
        //     else {
        //         return false;
        //     }
        //
        // });


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
                                <input type="text" className="formControl" ref="account" name="username" autoComplete="off" />
                            </div>
                            <div className="formGroup">
                                <img className="loginIcon" src="./img/login/LoginPsw_icon.png"/>
                                <input type="password" className="formControl" ref="pwd" name="password" autoComplete="off"  />
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