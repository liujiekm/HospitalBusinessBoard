/**
 * Created by Jay on 2016/5/27.
 */
import React,{Component,PropTypes} from 'react'


class ADListItem extends Component{

    render(){

        const {deptName,counts} = this.props
        return (
            <tr>
                <td >{deptName}</td>
                <td >{counts[0]}</td>
                <td >{counts[1]}</td>
                <td >{counts[2]}</td>
            </tr>

        )


    }


}


ADListItem.propTypes={

    deptName:PropTypes.string.isRequired,
    counts:React.PropTypes.arrayOf(React.PropTypes.number).isRequired


}
export default ADListItem;