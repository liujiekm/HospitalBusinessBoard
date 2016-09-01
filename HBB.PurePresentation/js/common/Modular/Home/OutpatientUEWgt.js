/**
 * Created by jay on 16/4/23.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'

//import classnames from "classnames"
import  {Link}  from 'react-router'


var OutpatientUEWgt = React.createClass({
    getDefaultProps: function () {
        return {
            appointmentLastMonth:1.62,
            awaitingDiagnosis:7.5,
            diagnosis:5.1,
            payFees:2.9,
            medicineReceiving:9.4
        };
    },


   render: function () {

       return (
               <div className="col-md-12">
                   <div className="row rowContent">
                       <div className="col-md-2">
                           <div className="row">
                               <div className="col-md-7 ue-symbol" >
                                   <img className="img-responsive" src="./img/门诊就医时长.png" />
                                   <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                               </div>
                           </div>
                           <div className="row">
                               <div className="col-md-12 ue-symbol-p" >
                                   <p className="imgText text-center">门诊就医</p>
                               </div>
                           </div>
                       </div>
                       <div className="col-md-10 ue-content">
                           <div className="row" style={{"marginLeft": "-50px"}}>
                               <div className="col-md-2">
                                   <p className="text-nowrap">门诊时长</p>
                               </div>
                               <div className="col-md-10"></div>
                           </div>
                           <div className="row" style={{"marginLeft": "-40px"}}>
                               <div className="col-md-2 pannelContent">
                                   <div className="row">
                                       <div className="col-md-5 ue-content-p">
                                           <p className="text-left text-nowrap">预约</p>
                                       </div>
                                       <div className="col-md-7"></div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-12">
                                           <p className="lead text-center">
                                                <strong>{this.props.appointmentLastMonth}</strong>
                                           </p>
                                       </div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-9"></div>
                                       <div className="col-md-3 bottomContent" >
                                           <p className="text-right text-nowrap"> 天</p>
                                       </div>
                                   </div>
                               </div>
                               <div className="col-md-2 pannelContent">
                                   <div className="row">
                                       <div className="col-md-5 ue-content-p">
                                           <p className="text-left text-nowrap">候诊</p>
                                       </div>
                                       <div className="col-md-7"></div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-12">
                                           <p className="lead text-center">
                                                <strong>{this.props.awaitingDiagnosis}</strong>
                                           </p>
                                       </div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-9"></div>
                                       <div className="col-md-3 bottomContent">
                                           <p className="text-right text-nowrap">分钟</p>
                                       </div>
                                   </div>
                               </div>
                               <div className="col-md-2 pannelContent">
                                   <div className="row">
                                       <div className="col-md-5 ue-content-p">
                                           <p className="text-left text-nowrap">就诊</p>
                                       </div>
                                       <div className="col-md-7"></div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-12">
                                           <p className="lead text-center">
                                                <strong>{this.props.diagnosis}</strong>
                                           </p>
                                       </div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-9"></div>
                                       <div className="col-md-3 bottomContent">
                                           <p className="text-right text-nowrap">分钟</p>
                                       </div>
                                   </div>
                               </div>
                               <div className="col-md-2 pannelContent">
                                   <div className="row">
                                       <div className="col-md-5 ue-content-p">
                                           <p className="text-left text-nowrap">缴费</p>
                                       </div>
                                       <div className="col-md-7"></div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-12">
                                           <p className="lead text-center">
                                                <strong>{this.props.payFees}</strong>
                                           </p>
                                       </div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-9"></div>
                                       <div className="col-md-3 bottomContent">
                                           <p className="text-right text-nowrap">分钟</p>
                                       </div>
                                   </div>
                               </div>
                               <div className="col-md-2 pannelContent">
                                   <div className="row">
                                       <div className="col-md-5 ue-content-p">
                                           <p className="text-left text-nowrap">取药</p>
                                       </div>
                                       <div className="col-md-7"></div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-12">
                                           <p className="lead text-center">
                                                <strong>{this.props.medicineReceiving}</strong>
                                           </p>
                                       </div>
                                   </div>
                                   <div className="row">
                                       <div className="col-md-9"></div>
                                       <div className="col-md-3 bottomContent">
                                           <p className="text-right text-nowrap">分钟</p>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>


                       <Link to="OE" className="ue-rightgo">
                           <img className="img-responsive" src="./img/Home/into.png" />
                       </Link>

                   </div>
               </div>
       );
   }

});

module.exports=OutpatientUEWgt;