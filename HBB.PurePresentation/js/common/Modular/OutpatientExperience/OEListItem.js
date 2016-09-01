/**
 * Created by Jay on 2016/6/1.
 *
 */
import React,{Component,PropTypes} from 'react'


class OEListItem extends Component{
    constructor(props)
    {
        super(props);

    }

    handleCheckbox(item,e){
        this.props.handleCheckbox(item,e.target.checked);
        
    }

    componentWillReceiveProps(nextProps) {

    }


    render(){

        return (

            <tr >
                <td style={{"width":"10%"}}>
                    <input type="checkbox" ref="chk" onChange={this.handleCheckbox.bind(this,this.props.item)} 
                    checked={this.props.item.isCheck}/>
                </td>
                <td style={{"width":"15%","cursor":"pointer"}} onClick={this.props.handleItemClick.bind(this,this.props.item)}>{this.props.item.SpecialistName} </td>
                <td style={{"width":"15%"}}>{this.props.item.Appointment}</td>
                <td style={{"width":"15%"}}>{this.props.item.AwaitingDiagnosis}</td>
                <td style={{"width":"15%"}}>{this.props.item.Diagnosis}</td>
                <td style={{"width":"15%"}}>{this.props.item.PayFees}</td>
                <td>{this.props.item.MedicineReceiving}</td>


            </tr>


        )

    }

}


export default OEListItem