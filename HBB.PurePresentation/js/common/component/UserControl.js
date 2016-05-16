/**
 * Created by liu on 2016/4/13.
 */
import React from 'react'

var UserControl = React.createClass({


    contextTypes: {
        router: React.PropTypes.object.isRequired
    },

    handleQuit:function () {

        localStorage.setItem('login', 'false');
        this.context.router.replace('/Login');
    },


    render:function () {
        return (

            <div className="right">
                <div className="usercontrol-name" >
                    <p>您好! <span id="currentUser">陈</span>院长 </p>
                </div>
                <div className="left usercontrol-symbol">
                    <img src="./img/Home/QUIT.png" className="img-responsive" height="48px" width="48px"
                    onClick={this.handleQuit}/>
                </div>

            </div>

        );
    }


});

module.exports=UserControl;