/**
 * Created by Jay on 2016/5/27.
 */

import React, { Component, PropTypes } from 'react'
import ADListItem from './ADListItem'


class ADList extends Component {

    render() {

        const { items, tableName, tableDesc,columnNames} = this.props

        var tableItem =[]

        items.forEach(function(item){


            tableItem.push(<ADListItem  deptName={item.deptName} counts={item.counts}/>);

        })




        return (
            <table className="ad-table table text-center">

                <caption>
                    <strong>{tableName}</strong>
                    {tableDesc}
                </caption>
                <thead>
                <tr>
                    <td style={{"width": "19%"}}>{columnNames[0]}</td>
                    <td style={{"width": "27%"}}>{columnNames[1]}</td>
                    <td style={{"width": "27%"}}>{columnNames[2]}</td>
                    <td style={{"width": "27%"}}>{columnNames[3]}</td>
                </tr>



                </thead>
                <tbody>

                {tableItem}

                </tbody>
            </table>






        )


    }

}

ADList.propTypes={
    items:PropTypes.arrayOf(PropTypes.shape({
        deptName: PropTypes.string.isRequired,
        counts: React.PropTypes.arrayOf(React.PropTypes.number)
    }).isRequired).isRequired,
    tableName:PropTypes.string.isRequired,
    tableDesc:PropTypes.string.isRequired,
    columnNames:PropTypes.arrayOf(React.PropTypes.number)
}

export default ADList;
