/**
 * Created by liu on 2016/4/13.
 */



import React from 'react'
import { render, findDOMNode } from 'react-dom'

import { History } from 'react-router'



import { Link } from 'react-router'


var LeftNav = React.createClass({


    componentDidMount:function () {

    },
    activeClick:function (event) {
        //console.log(event.target);
        $(event.target).parent().addClass('active').siblings().removeClass('active');
    },
    render:function () {

        // let isActive = this.history.isActive(this.props.to, this.props.query)
        // let className = isActive ? 'active' : ''

        return (
              <ul className="nav nav-pills nav-stacked text-center navleft">
                  <p>综合业务系统</p>
                  <li>&nbsp;</li>
                  <li role="presentation" className="active" onClick={this.activeClick}>
                      <Link to="Home">首页</Link>
                  </li>
                  <li role="presentation" onClick={this.activeClick}>
                      <Link to="Outpatient">门诊</Link>
                  </li>
                  <li role="presentation" onClick={this.activeClick}>
                      <Link to="Inhospital">住院</Link>
                  </li>
                  <li role="presentation" onClick={this.activeClick}>
                      <Link to="Medicine">药品</Link>
                  </li>
                  <li role="presentation" onClick={this.activeClick}>
                      <Link to="Operation">手术</Link>
                  </li>
    
    
              </ul>
    
    
          );
    }


});


module.exports=LeftNav;