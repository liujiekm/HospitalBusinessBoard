/**
 * Created by liu on 2016/4/13.
 */



import React from 'react'
import { render, findDOMNode } from 'react-dom'



import { Link } from 'react-router'


var LeftNav = React.createClass({
    
    activeClick:function () {
        $(this.getDOMNode()).addClass('active').siblings().removeClass('active');
    },
    render:function () {
          return (
              <ul className="nav nav-pills nav-stacked text-center navleft">
                  <p>医院业务看板</p>
                  <li>&nbsp;</li>
                  <li role="presentation" className="active" onClick={this.activeClick}>
                      <Link to="Home">首页</Link>
                  </li>
                  <li role="presentation">
                      <Link to="Outpatient">门诊</Link>
                  </li>
                  <li role="presentation">
                      <Link to="Inhospital">住院</Link>
                  </li>
                  <li role="presentation">
                      <Link to="Medicine">药品</Link>
                  </li>
                  <li role="presentation">
                      <Link to="Operation">手术</Link>
                  </li>
    
    
              </ul>
    
    
          );
    }


});


module.exports=LeftNav;