/**
 * Created by liu on 2016/4/13.
 */
import React from 'react'


var Clock = React.createClass({
    getInitialState:function () {
        return {date:'',
                hour:'',
                min:'',
                sec:''
        }
    },

    componentDidMount:function () {
            var monthNames = ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"];
            var dayNames = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"]


            var newDate = new Date();

            newDate.setDate(newDate.getDate());
            var currentDate=
            newDate.getFullYear() + '年' + monthNames[newDate.getMonth()] + newDate.getDate() + '日 ' + dayNames[newDate.getDay()];
        //     setInterval(function () {
        //
        //     var seconds = new Date().getSeconds();
        //
        //     $(this.refs.sec).html((seconds < 10 ? "0" : "") + seconds);
        // }, 1000);
        //
        //     setInterval(function () {
        //
        //     var minutes = new Date().getMinutes();
        //
        //     $(this.refs.min).html((minutes < 10 ? "0" : "") + minutes);
        // }, 1000);
        //
        //     setInterval(function () {
        //
        //     var hours = new Date().getHours();
        //
        //     $(this.refs.hours).html((hours < 10 ? "0" : "") + hours);
        // }, 1000);
var that = this;
        setInterval(function(){
            var seconds = new Date().getSeconds();
            var minutes = new Date().getMinutes();
            var hours = new Date().getHours();
            that.setState({date:currentDate,
                hour:hours,
                min:minutes,
                sec:seconds});

        },1000);

    }
    ,
    render:function () {
        return (

            <div className="left">
                <div className="clock-position">
                    <div id="Date" ref="Date" className="left clock-date">{this.state.date}</div>
                    <ul className="clock left clock-time">
                        <li id="hours" ref="hours">{this.state.hour}</li>
                        <li>:</li>
                        <li id="min" ref="min">{this.state.min}</li>
                        <li>:</li>
                        <li id="sec" ref="sec">{this.state.sec}</li>
                    </ul>




                </div>


            </div>
            
            
        );
    }
    
});

module.exports=Clock;