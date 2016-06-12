/**
 * Created by Jay on 2016/6/1.
 * 门诊就医时常查询组件
 */



import React,{Component,PropTypes} from 'react'
import DatePicker from 'react-datepicker'
import moment from 'moment'

import 'react-datepicker/dist/react-datepicker.css';



class OESearchPanel extends Component{

    constructor(props) {
        super(props);
        this.state={
            startDate:new Date(new Date().getTime() - 1000 * 60 * 60 * 24 * 7),
            endDate:new Date(),
            area:''
        }
    }
    
    
    
    handleStartChange(date) {
        this.setState({
            startDate:date
        });
    }

    handleEndChange(date) {
        this.setState({
            endDate:date
        });
    }

    handleSearch(){
        this.props.handleSearch(this.state.startDate,this.state.endDate,this.state.area);

    }

    handleAreaChoice(e){
        this.setState({area:e.target.value});
        
    }
    render(){

        return (

            <div>

                <div className="col-md-1">
                    <img  className="img-responsive" style={{"marginTop": "6px","marginLeft": "40px"}} src="/img/Calendar.png"/>
                </div>

                <div className="col-md-2">
                    <DatePicker locale={"zh-cn"} className="datepicker"
                                selected={this.state.startDate}
                                onChange={this.handleStartChange} />
                </div>
                <div className="col-md-2">
                    <DatePicker locale={"zh-cn"} className="datepicker"
                                selected={this.state.endDate}
                                onChange={this.handleEndChange} />
                </div>




                <div className="col-md-7">
                    <div className="btn-group" role="group">
                        <button type="button" className="btn btn-default oe-btn-click" value="01,02" onClick={this.handleAreaChoice}>全院</button>
                        <button type="button" className="btn btn-default" value="01" onClick={this.handleAreaChoice}>老院区</button>
                        <button type="button" className="btn btn-default" value="02" onClick={this.handleAreaChoice}>新院区</button>
                    </div>
                    <button type="button" id="btnSearch" className="btn oe-btn-click" onClick={this.handleSearch}>统计</button>
                </div>

            </div>


        )

    }

}


export default OESearchPanel


