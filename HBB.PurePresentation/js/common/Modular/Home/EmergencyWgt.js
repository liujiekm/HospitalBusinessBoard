/**
 * Created by liu on 2016/4/22.
 */
import React,{Component,PropTypes} from 'react'
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import { Link } from 'react-router'

class EmergencyWgt extends Component{


    getDefaultProps() {
      return {


          severeObservingQuanty:39,
          firstAidQuanty:5
      };
    }

    render() {
        return(

            <div className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size wgt-margin-right">

                <div className="row">
                    <div className="col-md-2 col-sm-2 col-xs-2 wgt-symbol" >
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/emergency.png" />
                                    <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                                        <p className="imgText text-center">急诊</p>
                            </div>
                        </div>

                    </div>

                    <div className="col-md-4 text-right outpatient-ms-left">
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p className="lead outpatient-ms-p" >重症留观</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12 mobilePadding">

                                <p className="lead outpatient-ms-p" >抢救区</p>
                            </div>

                        </div>
                    </div>

                    <div className="col-md-4 outpatient-ms-right">
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead outpatient-ms-p"><span>{this.props.severeObservingQuanty}</span> 人</p>
                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12">

                                <p className="lead outpatient-ms-p"><span>{this.props.firstAidQuanty}</span>人</p>
                            </div>

                        </div>
                    </div>

                    <div className="col-md-2 leftGo">

                        <Link to="Emergency">
                            <img className="img-responsive" src="./img/Home/into.png" />
                        </Link>
                    </div>
                </div>

            </div>

        );
    }


}


//module.exports = EmergencyWgt;

export default EmergencyWgt;