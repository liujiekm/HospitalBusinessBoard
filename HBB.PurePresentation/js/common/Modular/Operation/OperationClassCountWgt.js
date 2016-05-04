/**
 * Created by liu on 2016/4/27.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'


var OperationClassCountWgt = React.createClass({

    getDefaultProps:function () {
        return {

            specialClassNum:200,
            forthClassNum:345,
            thirdClassNum:421,
            secondClassNum:331,
            firstClassNum:423


        };
    },

    render:function () {
        return (

            <div className="col-md-12">
                <div className="row rowContent">
                    <div className="col-md-2">
                        <div className="row">
                            <div className="col-md-7 ue-symbol" >
                                <img className="img-responsive" src="./img/Home/operation.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row" >
                            <div className="col-md-12 ue-symbol-p" >
                                <p className="imgText text-center">手术统计</p>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-10 ue-content" >

                        <div className="row" style={{"marginLeft": "-40px"}}>
                            <div className="col-md-2 operation-box-clean">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p" >
                                        <p className="text-left text-nowrap">近30天</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center text-nowrap operation-box-indicate"><strong>{this.props.specialClassNum+this.props.forthClassNum+
                                        this.props.thirdClassNum+this.props.secondClassNum+this.props.firstClassNum}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 operation-box-p">
                                        <p className="text-right">台</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 operation-box">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p" >
                                        <p className="text-left text-nowrap">特类</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center operation-box-indicate"><strong>{this.props.specialClassNum}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 operation-box-p">
                                        <p className="text-right">台</p>
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-2 operation-box">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p" >
                                        <p className="text-left text-nowrap">四类</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center operation-box-indicate"><strong>{this.props.forthClassNum}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 operation-box-p">
                                        <p className="text-right text-nowrap">台</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 operation-box">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p">
                                        <p className="text-left text-nowrap">三类</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center operation-box-indicate"><strong>{this.props.thirdClassNum}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 operation-box-p">
                                        <p className="text-right text-nowrap">台</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 operation-box">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p">
                                        <p className="text-left text-nowrap">二类</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center operation-box-indicate"><strong>{this.props.secondClassNum}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 operation-box-p">
                                        <p className="text-right text-nowrap">台</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 operation-box">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p" >
                                        <p className="text-left text-nowrap">一类</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center operation-box-indicate"><strong>{this.props.firstClassNum}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 operation-box-p">
                                        <p className="text-right text-nowrap">台</p>
                                    </div>
                                </div>
                            </div>




                        </div>
                    </div>
                </div>





            </div>

            
        );
    }


});

module.exports = OperationClassCountWgt;