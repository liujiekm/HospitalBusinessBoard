/**
 * Created by Jay on 2016/6/1.
 *
 */
import React,{Component,PropTypes} from 'react'


class OEListItem extends Component{



    
    handleCheckbox(e){
        this.props.handleCheckbox(this.props.item,e.target.checked);
    }

    render(){

        return (

            <tr onClick={this.handleItemClick}>
                <td>
                    <input type="checkbox" ref="chk" onChange={this.handleCheckbox} checked={this.props.item.isCheck}/>
                </td>
                <td>{this.props.item.SpecialistName}</td>
                <td>{this.props.item.Appointment}</td>
                <td>{this.props.item.AwaitingDiagnosis}</td>
                <td>{this.props.item.Diagnosis}</td>
                <td>{this.props.item.PayFees}</td>
                <td>{this.props.item.MedicineReceiving}</td>


            </tr>


        )

    }

}


export default OEListItem