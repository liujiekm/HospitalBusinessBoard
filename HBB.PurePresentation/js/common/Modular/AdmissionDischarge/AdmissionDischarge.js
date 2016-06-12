/**
 * Created by liu on 2016/4/29.
 * 出入院及空床情况
 */
import React, { Component, PropTypes } from 'react'

import ADNum from './ADNum'
import EmptyBedNum from './EmptyBedNum'
import ADList from './ADList'

import RightTitle from '../../component/RightTitle'

var AdmissionDischarge = React.createClass ({




    getInitialState:function ()
    {

        return {
            adByDept:[],//各专科出入院情况
            ebByDept:[],//各专科空床情况
            wholeAD:[],//全院出入院情况
            wholeEB:[]//全院空床情况

        }
    },

    componentDidMount:function ()
    {
        //查询
        $.getJSON(Globle.baseUrl + 'IH/ADI', function (ad) {
            ad.gzkcryqk.forEach(function (item) {
                adByDept.push({deptName:item.ZKMC,counts:[item.RS,item.OUTNUM,item.INNUM]});

            });
            ad.gzkkcqk.forEach(function (item) {
                adByDept.push({deptName:item.ZKMC,counts:[item.EDKCW,item.JCKCW,item.XNKCW]});

            });

            //全院空床情况
            wholeEB.push(ad.edkcw);
            wholeEB.push(ad.jckcw);
            wholeEB.push(ad.xnkcw);
            //全院出入院情况

            wholeAD.push([0, ad.cry.zrzy - ad.cry.jrcy, ad.cry.zrzy - ad.cry.jrcy]);
            wholeAD.push([ad.cry.zrzy, ad.cry.jrcy, ad.cry.jrry]);


        });


    },


    render(){

        return (
            <div className="detail-content">


                <RightTitle titleName="医生签到"/>

                <div className="row contentRow" >
                    <div className="col-md-8">
                        <ADNum data ={this.state.wholeAD}/>
                        <EmptyBedNum data={this.state.wholeEB}/>
                    </div>


                    <div className="col-md-1">
                        <div className="row nextInfoContainer">
                            <div className="col-md-12 nextInfo">

                                <img className="img-responsive" src="./img/delt.png" />
                            </div>
                        </div>

                        <div className="row nextInfoContainer">
                            <div className="col-md-12 nextInfo">
                                <img className="img-responsive" src="./img/deltLeft.png" />
                            </div>
                        </div>
                    </div>

                    <div className="col-md-3">
                        <div className="row">
                            <ADList tableName="各专科出入院情况" tableDesc="(在院病人数排序)"
                                    columnNames={["科室","今日在院","今日出院","今日入院"]} items={this.state.adByDept} />
                        </div>

                        <div className="row">
                            <ADList tableName="各专科空床情况" tableDesc="(额定床位空床数排序)"
                                    columnNames={["科室","额定空床位","加床空床位","虚拟空床位"]} items={this.state.ebByDept}/>
                        </div>

                    </div>



                </div>

            </div>
        )


    }

})


export default AdmissionDischarge