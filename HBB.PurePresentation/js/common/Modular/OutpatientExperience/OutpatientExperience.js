/**
 * Created by Jay on 2016/6/1.
 * 门诊就医体验组件父容器
 */

import React,{Component,PropTypes} from 'react'
import 'whatwg-fetch';
import Globle from "../../../Globle"
import options from "../../../option"
import OEChart from './OEChart'
import OEList from './OEList'
import OESearchPanel from './OESearchPanel'
import RightTitle from "../../component/RightTitle"

import { format,fromNow} from 'silly-datetime'




class OutpatientExperience extends Component{
    constructor(props) {
        super(props);
        this.state = {
            contrast:false,//指明组件是对比状态还是列数据清单状态
            items:[], //科室就医时长清单
            oeOption:options.outpatientExperience,
            contrastItems:[],//科室对比数据源
            yoyItems:[],//科室同比数据源
            indicate:true //对比还是同比 true 对比 false 同比

        };
    }


    handleCheckbox(item,checked){
        
        let oeitems = this.state.items;
        let count = 0;

        for(let i =0;i<oeitems.length;i++)
        {
            if(oeitems[i].isCheck===true)
            {
                count++;
            }
            if(count>=5&&checked==true)
            {
                alert("对比最多勾选5个科室！");
                return false;
            }
            else{

                if(oeitems[i].SpecialistName===item.SpecialistName)
                {
                    oeitems[i].isCheck=checked;
                }
            }

        }
        this.setState({items:oeitems});
        
    }
    handleCompare(e){
        //获取选中项
        let oeitems = this.state.items;
        let count = 0;
        oeitems.forEach(function(oeitem){
            if(oeitem.isCheck===true)
            {
                count++
            }
        });
        if(count<1)//控制在最多五个科室进行对比
        {
            alert("请选择对比科室！");
            return false;
        }
        if(count>5)//控制在最多五个科室进行对比
        {
            alert("对比最多勾选5个科室！");
            return false;
        }

        var that = this;
        //UE/DTATGBD/2016-08-04/2016-08-11?hospitalDistrict=01,02&depts=14,15,16
        fetch('http://localhost:3000/js/common/oec.json')
        .then(Globle.checkStatus)
        .then(Globle.parseJSON)
        .then(function(json) {
            that.setState({contrast:true,contrastItems:json,indicate:true});
        }).catch(function(error) {
            console.log('request failed', error)
        })

        
        
    }
    
    handleReturn(e){
        this.setState({contrast:false});
    }
    //查询科室门诊就诊时间清单
    handleSearch(startDate,endDate,area)
    {
        var that = this;
        let formattedStart= format(startDate, 'YYYY-MM-DD HH:mm:ss');
        let formattedEnd = format(endDate, 'YYYY-MM-DD HH:mm:ss');

        //恢复所有选项的未选中状态
        //fetch(Globle.baseUrl+'UE/TAT/'+formattedStart+'/'+formattedEnd+'?hospitalDistrict='+area,{credentials: 'include'})
        fetch('http://localhost:3000/js/common/oe.json')
        .then(Globle.checkStatus)
        .then(Globle.parseJSON)
        .then(function(json) {
            //填充state中的items
            json.forEach(function(item){
                item.isCheck=false;
            });
            that.setState({items:json});
        }).catch(function(error) {
            console.log('request failed', error)
        })
        
    }
    handleItemClick(item,e)//点击科室条目，则同比近三年当前科室的各就诊阶段的时长对比
    {
        var that = this;
        //fetch(Globle.baseUrl+'UE/DTATYTY/' + sDate+ '/' + eDate + '/' + SpecialistId + '?hospitalDistrict=',{credentials: 'include'})
        fetch('http://localhost:3000/js/common/oey.json')
        .then(Globle.checkStatus)
        .then(Globle.parseJSON)
        .then(function(json) {
            that.setState({yoyItems:json,contrast:true,indicate:false});
        }).catch(function(error) {
            console.log('request failed', error)
        })
    }
    componentDidMount(){

    }
    render(){
        return (
            <div className="detail-content">

                <RightTitle titleName="门诊就医时长" returnLink="Home"/>

                <div className="row oe-content">
                    <div className="col-md-12">
                        <div className="row oe-row">
                            <OESearchPanel  handleSearch={this.handleSearch.bind(this)} contrast={this.state.contrast}/>
                        </div>
                        
                        <div className="row">
                            { 
                                this.state.contrast? <OEChart oeOption={this.state.oeOption} 
                                    indicate={this.state.indicate} contrastItems={this.state.contrastItems} yoyItems={this.state.yoyItems}/>
                                :
                                <OEList items={this.state.items} handleCheckbox={this.handleCheckbox.bind(this)} 
                                handleItemClick={this.handleItemClick.bind(this)} /> 
                            }

                        </div>

                         <div className="row oe-contrast-zone">
                            <div className="col-md-12">
                            { this.state.contrast? 
                                <button type="button" id="btnReturn" className="btn right" onClick={this.handleReturn.bind(this)}>{'<--返回列表'}</button>
                                :
                                <button type="button" id="btnCompare" className="btn right" onClick={this.handleCompare.bind(this)} >{'开始对比-->'}</button>


                            }
                            </div>
                        </div>
                    </div>
                </div>
                
               
            </div>)
    }


}

export default OutpatientExperience

