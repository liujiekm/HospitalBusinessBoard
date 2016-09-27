/**
 * Created by liu on 2016/4/22.
 */
import React,{Component,PropTypes} from 'react'
import { render, findDOMNode } from 'react-dom'
import { Link } from 'react-router'



class HospitalzationWgt extends Component{

    


    render() {
        return (

            <div className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-2 col-sm-2 col-xs-2 wgt-symbol" >
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src="./img/Home/hospitalized.png" />
                                    <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                                        <p className="imgText text-center">住院</p>
                            </div>
                        </div>

                    </div>

                    <div className="col-md-4 checkin-wgt-content wgt-content-position">
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p className="lead hospitalzation-p" >在院人数</p>
                                <p className="lead hospitalzation-p" ><span>{this.props.hospitalizedNum}</span>人</p>

                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p>昨日出院 <span>{this.props.leaveYeaterday}</span>人</p>
                                <p>昨日入院 <span>{this.props.IncomeYeaterday}</span>人</p>
                            </div>

                        </div>
                    </div>

                    <div className="col-md-4 col-sm-4 col-xs-4 checkin-wgt-content wgt-content-position">
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p className="lead">空床</p>

                            </div>
                        </div>
                        <div className="row">
                        </div>
                        <div className="row">
                            <div className="col-md-12 mobilePadding">
                                <p>额定 <span>{this.props.ratedBeds}</span></p>
                                <p>加床 <span>{this.props.addedBeds}</span></p>
                                <p>虚拟  <span>{this.props.virtualBeds}</span></p>
                            </div>

                        </div>
                    </div>

                    <div className=" leftGo col-md-2 ">
                        <Link to="AD">
                            <img className="img-responsive" src="./img/Home/into.png" />
                        </Link>
                    </div>
                </div>
            </div>
        );
    }
    
    
    
}


//module.exports = HospitalzationWgt;
HospitalzationWgt.defaultProps={
            hospitalizedNum:2803,
            leaveYeaterday:503,
            IncomeYeaterday:620,
            ratedBeds:60,
            addedBeds:54,
            virtualBeds:12

};

    


export default HospitalzationWgt;