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






class OutpatientExperience extends Component{

    constructor(props) {
        super(props);
        this.state = {
            contrast:false,//指明组件是对比状态还是列数据清单状态
            items:[], //科室就医时常清单
            oeOption:opions.outpatientExperience
        };
    }


    handleCheckbox(item,checked){
        let oeitems = this.state.items;
        let count = 0;
        oeitems.forEach(function(oeitem){
            if(oeitem.titleName===item.titleName)
            {
                oeitem.isCheck =item.isCheck;
            }
            if(oeitem.isCheck)
            {
                count++;
            }
            
        });
        //控制在最多五个科室进行对比
        if(count>5)
        {
            alert("对比最多勾选5个科室！");
            return false;
        }

        this.setState({items:oeitems});

    }
    handleCompare(e){
        //获取选中项
        
        
    }
    
    handleReturn(e){
        this.setState({contrast:false});
    }
    //查询科室门诊就诊时间清单
    handleSearch(startDate,endDate,area)
    {
        //恢复所有选项的未选中状态
        fetch(Globle.baseUrl+'UE/TAT/'+startDate+'/'+endDate+'?hospitalDistrict='+area)
        .then(Globle.checkStatus)
        .then(Globle.parseJSON)
        .then(function(json) {
            //填充state中的items
            json.forEach(function(item){
                item.isCheck=false;
            });
            this.setState({items:json});
        }).catch(function(ex) {
            console.log('request failed', error)
        })
        
    }

    componentDidMount(){
        //默认取今年的各门诊科室就诊时长
        const sDate = Date.now();
        const eDate = Date.now();


    }
    render(){
        return (
            <div className="detail-content">

                <RightTitle titleName="门诊就医时长"/>

                <div className="row oe-row">
                    <OESearchPanel />
                </div>
                
                <div className="row">
                    { this.state.contrast? <OEChart />:<OEList items={this.state.items} handleCheckbox={this.handleCheckbox}/> }

                </div>
                <div className="row">
                    <div>
                    { this.state.contrast? 
                        <button type="button" id="btnCompare" className="btn right" onClick={this.handleCompare} >{'开始对比-->'}</button>
                        :
                        <button type="button" id="btnReturn" className="btn right" onClick={this.handleReturn}>{'<--返回列表'}</button>
                    }
                    </div>
                </div>
            </div>)
    }


}

export default OutpatientExperience

