/**
 * Created by liu on 2016/4/13.
 */
import React from 'react'


var Clock = React.createClass({
    
    componentDidMount:function () {
            var monthNames = ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"];
            var dayNames = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"]


            var newDate = new Date();

            newDate.setDate(newDate.getDate());
            $(this.refs.Date).html(newDate.getFullYear() + '年' + monthNames[newDate.getMonth()] + newDate.getDate() + '日 ' + dayNames[newDate.getDay()]);
            setInterval(function () {

            var seconds = new Date().getSeconds();

            $(this.refs.sec).html((seconds < 10 ? "0" : "") + seconds);
        }, 1000);

            setInterval(function () {

            var minutes = new Date().getMinutes();

            $(this.refs.min).html((minutes < 10 ? "0" : "") + minutes);
        }, 1000);

            setInterval(function () {

            var hours = new Date().getHours();

            $(this.refs.hours).html((hours < 10 ? "0" : "") + hours);
        }, 1000);
    }
    ,
    render:function () {
        return (

            <div className="left">
                <div className="clock-position">
                    <div id="Date" ref="Date" className="left clock-date">2016年4月13日 星期三</div>
                    <ul class="clock" className="left clock-time">
                        <li id="hours" ref="hours">15</li>
                        <li>:</li>
                        <li id="min" ref="min">07</li>
                        <li>:</li>
                        <li id="sec" ref="sec">21</li>
                    </ul>




                </div>


            </div>
            
            
        );
    }
    
});

module.exports=Clock;