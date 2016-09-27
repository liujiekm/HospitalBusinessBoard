/**
 * Created by liu on 2016/4/22.
 */
import React,{Component,PropTypes} from 'react'
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import  { Link }  from 'react-router'


class OutpatientMedicalServiceWgt extends Component{

    
    render() {
        return (
            <div className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size wgt-margin-right">


                <div className="row">

                    <div className="col-md-2 col-sm-2 col-xs-2 wgt-symbol" >
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/medicalService.png"/>
                                    <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                                        <p className="imgText text-center">坐诊情况</p>
                            </div>
                        </div>

                    </div>

                    <div className="col-md-4 text-right outpatient-ms-left" >
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p className="lead outpatient-ms-p" >目前候诊</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p className="lead outpatient-ms-p" >已完成就诊</p>
                            </div>

                        </div>
                    </div>

                    <div className="col-md-4 outpatient-ms-right" >
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead outpatient-ms-p" ><span>{this.props.waitingNum} </span>人</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead outpatient-ms-p" ><span>{this.props.treatedNum}</span> 人</p>
                            </div>

                        </div>
                    </div>

                    <div className="leftGo col-md-2 ">

                        <Link to="MSS" >

                            <img className="img-responsive" src="./img/Home/into.png" />

                        </Link>
                    </div>


                </div>

            </div>


        );
    }



}




//module.exports=OutpatientMedicalServiceWgt;
OutpatientMedicalServiceWgt.defaultProps={
    waitingNum:498,
    treatedNum:502
}
export default OutpatientMedicalServiceWgt;