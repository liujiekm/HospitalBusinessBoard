/**
 * Created by Jay on 2016/6/1.
 * 门诊就医时长查询组件
 */



import React,{Component,PropTypes} from 'react'
import  classNames from 'classnames'

import {Button , DatePicker,Radio,Icon } from 'antd';


//import DatePicker from 'react-datepicker'
import moment from 'moment'

//import 'react-datepicker/dist/react-datepicker.css';

const RangePicker = DatePicker.RangePicker;
const RadioButton = Radio.Button;
const RadioGroup = Radio.Group;
const ButtonGroup = Button.Group;

class OESearchPanel extends Component{

    constructor(props) {
        super(props);
        this.state={
            startDate:new Date(new Date().getTime() - 1000 * 60 * 60 * 24 * 7),
            endDate:new Date(),
            area:'01,02'
        }
    }
    
    
    
    handleDateChange(value, dateString) {
        this.setState({
            startDate:value[0],
            endDate:value[1]
        });
    }



    handleSearch(){
        this.props.handleSearch(this.state.startDate,this.state.endDate,this.state.area);
    }

    handleAreaChoice(e){
        this.setState({area:e.target.value});
        
    }


    componentDidMount(){


    }

    render(){

        
        let {contrast} =this.props; 

        return (


            <div className="oe-searchbar">
                <div className="col-md-1">
                    <img  className="img-responsive" style={{"marginTop": "6px","marginLeft": "40px"}} src="/img/Calendar.png"/>
                </div>

                <div className="col-md-4">

                    <RangePicker style={{ "width": "220px","borderRadius":"0px" }} onChange={this.handleDateChange.bind(this)} 
                    value={[this.state.startDate,this.state.endDate]} size="large"  format="yyyy-MM-dd" disabled={contrast} />
                    
                </div>
               




                <div className="col-md-7">


                    <RadioGroup defaultValue="01,02" size="large" disabled={contrast}  onChange={this.handleAreaChoice.bind(this)}>
                        <RadioButton  value="01,02">全院</RadioButton>
                        <RadioButton  value="01">老院区</RadioButton>
                        <RadioButton  value="02">新院区</RadioButton>
                    
                    </RadioGroup>

                    {' '}
                    <Button  type="button" size="large" type="primary" disabled={contrast} onClick={this.handleSearch.bind(this)} icon="search">统计</Button >

                </div>

            </div>


        )

    }

}


export default OESearchPanel


