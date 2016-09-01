/**
 * Created by Jay on 2016/6/1.
 * 门诊就医时常各科室数据清单
 */
import React,{Component,PropTypes} from 'react'

import OEListItem from './OEListItem'

import uuid from 'uuid'

class OEList extends Component{



    handleCheckbox(item,checked)
    {
        this.props.handleCheckbox(item,checked);
        
    }

    render(){

        var tbodyItem =[];
        var that = this;
        this.props.items.forEach(function (item) {
            
           tbodyItem.push(<OEListItem item={item} key={uuid.v1()} handleCheckbox={that.handleCheckbox.bind(that)} 
           handleItemClick={that.props.handleItemClick.bind(that)} />);
        });

        return (

            <div className="col-md-12">
                <table className="table text-center">
                    <thead>
                    <tr>
                        <td style={{"width":"10%"}}>加入对比</td>
                        <td style={{"width":"15%"}}>专科名称</td>
                        <td style={{"width":"15%"}}>预约时长（天）</td>
                        <td style={{"width":"15%"}}>候诊时长（分钟）</td>
                        <td style={{"width":"15%"}}>就诊时长（分钟）</td>
                        <td style={{"width":"15%"}}>缴费时长（分钟）</td>
                        <td >取药时长（分钟）</td>

                    </tr>
                    </thead>
                </table>
                <div className="oe-tabcontent">
                    <table id="content" className="table table-hover text-center">
                        <tbody>
                        {tbodyItem}
                        </tbody>
                    </table>
                </div>
            </div>


        )

    }

}


export default OEList