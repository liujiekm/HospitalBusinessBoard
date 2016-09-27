/**
 * Created by jay on 16/4/23.
 */
/**
 * Created by jay on 16/4/23.
 */


import React,{Component,PropTypes} from 'react'
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  Link  from 'react-router'


class InspectionUEWgt extends Component{
    


    render() {

        return (



            <div className="col-md-12">
                <div className="row rowContent">
                    <div className="col-md-2">
                        <div className="row">
                            <div className="col-md-7 ue-symbol" >
                                <img className="img-responsive" src="./img/特检时长.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12 ue-symbol-p" >
                                <p className="imgText text-center">特检时长</p>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-10 ue-content">
                        <div className="row" style={{"marginLeft": "-50px"}}>
                            <div className="col-md-2">
                                <p className="text-nowrap">特检时长</p>
                            </div>
                            <div className="col-md-10"></div>
                        </div>
                        <div className="row" style={{"marginLeft": "-40px"}}>
                            <div className="col-md-2 pannelContent">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p">
                                        <p className="text-left text-nowrap">X光</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center"><strong>{this.props.xray}</strong></p>
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
                                        <p className="text-left text-nowrap">CT</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center"><strong>{this.props.ct}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 bottomContent">
                                        <p className="text-right text-nowrap">天</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 pannelContent">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p">
                                        <p className="text-left text-nowrap">MRI</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center"><strong>{this.props.mri}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 bottomContent">
                                        <p className="text-right text-nowrap">天</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 pannelContent">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p">
                                        <p className="text-left text-nowrap">B超</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center"><strong>{this.props.BUltrasonic}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 bottomContent">
                                        <p className="text-right text-nowrap">天</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-2 pannelContent">
                                <div className="row">
                                    <div className="col-md-5 ue-content-p">
                                        <p className="text-left text-nowrap">内窥镜</p>
                                    </div>
                                    <div className="col-md-7"></div>
                                </div>
                                <div className="row">
                                    <div className="col-md-12">
                                        <p className="lead text-center"><strong>{this.props.endoscope}</strong></p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-md-9"></div>
                                    <div className="col-md-3 bottomContent">
                                        <p className="text-right text-nowrap">天</p>
                                    </div>
                                </div>
                            </div>




                        </div>
                    </div>
                    <a href="PatientExperience.aspx" className="ue-rightgo">
                        <img className="img-responsive" src="./img/Home/into.png" />
                    </a>

                </div>



            </div>



        );
    }

}

//module.exports=InspectionUEWgt;


InspectionUEWgt.defaultProps={


            xray:1.62,

            ct:7.5,

            mri:5.1,

            BUltrasonic:2.9,

            endoscope:9.4

}


export default InspectionUEWgt;