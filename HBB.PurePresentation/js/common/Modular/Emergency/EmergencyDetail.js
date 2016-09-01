/**
 * Created by Jay on 2016/6/1.
 * 急诊抢救区、留观区病人详细清单
 */


import React,{Component,PropTypes} from 'react'
import 'whatwg-fetch';
import Globle from "../../../Globle"

import uuid from 'uuid'
import { Table } from 'antd';
import RightTitle from "../../component/RightTitle"


const observation_columns = [
    {title: '姓名',dataIndex: 'Name',width: 150,},
    {title: '性别',dataIndex: 'Sex',width: 150,},
    {title: '年龄',dataIndex: 'Age',width: 150,},
    {title: '临床诊断',dataIndex: 'Diagnosis',width: 300,},
    {title: '留观天数',dataIndex: 'ObservationDays',width: 150,},
    {title: '预存余额',dataIndex: 'Balance',width: 150,}
];

const rescue_columns =[
    {title: '姓名',dataIndex: 'Name',width: 150,},
    {title: '性别',dataIndex: 'Sex',width: 150,},
    {title: '年龄',dataIndex: 'Age',width: 150,},
    {title: '临床诊断',dataIndex: 'Diagnosis',width: 300,},
    {title: '留观天数',dataIndex: 'ObservationDays',width: 150,},
    {title: '预存余额',dataIndex: 'Balance',width: 150,}
];


class EmergencyDetail extends Component{

    constructor(props)
    {
        super(props);
        this.state={
            loading:true,
            columns:observation_columns,
            tabName:"Observation",
            source:{},//数据源
            data:[] //Table数据
        }
    }

    //根据是留观还是抢救来加载对应数据源
    _constructSource(dataSource,dataType)
    {
        var data =[];
        let source = dataSource[dataType];
        $.each(source,function(index,item){
            item.key=uuid.v1();
            data.push(item);

        });

        return data;

    }
    componentDidMount(){

        let self = this;
        ///IH/ET
        fetch('http://localhost:3000/js/common/ih.json')
        .then(Globle.checkStatus)
        .then(Globle.parseJSON)
        .then(function(json) {
            //转换为留观数据源
            let data = self._constructSource(json,self.state.tabName);
            self.setState({data:data,loading:false,source:json});

        }).catch(function(error) {
            console.log('request failed', error)
        })

    }

    componentWillUpdate(nextProps, nextState)
    {
        
        
    }
    handleTabClick(e)
    {
        let tabId = e.target.id;
        let source = this.state.source;
        let data = this._constructSource(source,tabId);
        if(tabId==='Observation')
        {
            this.setState({columns:observation_columns,tabName:tabId,data:data});
        }
        else{
            this.setState({columns:rescue_columns,tabName:tabId,data:data});
        }
        
    }
    render(){
        return (
            <div className="detail-content">
                <RightTitle titleName="急诊" returnLink="Home"/>
                <div className="row contentRow">
                    <div className="col-md-12 personPanel">
                            <ul className="nav nav-tabs" role="tablist">
                                <li role="presentation" className="active"><a id="Observation" aria-controls="underway" role="tab" data-toggle="tab" 
                                onClick={this.handleTabClick.bind(this)}>急诊留观</a></li>
                                <li role="presentation" ><a id="Rescue" aria-controls="waiting" role="tab"  data-toggle="tab" 
                                onClick={this.handleTabClick.bind(this)}>抢救区</a></li>
                            </ul>
                            <div className="tab-content personContent">               
                                <Table columns={this.state.columns} dataSource={this.state.data} loading={this.state.loading} pagination={{ pageSize: 8 }} scroll={{ y: 450 }} />                  
                        </div>
                    </div>
                </div>
            </div>
            )
    }

}


export default EmergencyDetail;


