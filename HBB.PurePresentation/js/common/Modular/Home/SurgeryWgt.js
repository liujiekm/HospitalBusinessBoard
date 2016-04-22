/**
 * Created by liu on 2016/4/22.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import classnames from "classnames"
import ReactEcharts from "react-echarts-component"
import Globle from "../../../Globle"
import options from "../../../option"



var SurgeryWgt=React.createClass({

    componentDidMount:function () {

        $.getJSON(Globle.baseUrl+'OP/RSI', function (item) {
            //手术

            options.hoemPieOption.series[0].data = [item.CompletedQuanty];
            options.hoemPieOption.series[1].data = [item.DoingQuanty];
            options.hoemPieOption.series[2].data = [item.WaitingQuanty];

        });
    },


    render:function () {
        return (


            <div  className="col-md-6 col-sm-6 col-xs-6 div_nav wgt-size div_chart">
            <div className="row surgerywgt-symbol" >
                <div className="col-md-2 surgerywgt-symbol-content">
                    <div className="row">
                        <div className="col-md-12">
                            <img className="img-responsive" src="./img/Home/operation.png" />
                                <img className="img-responsive verticalLine" src="./img/Home/VerticalLine.png" />
                                    <p className="imgText text-center">手术</p>
                        </div>
                    </div>

                </div>

                <div className="col-md-8 " style={{"width":"72%"}}>
                    <ReactEcharts height={110}  option={options.hoemPieOption}  />
                </div>

                <div className="col-md-2 rightGo">
                    <a href="OperationMain.aspx">
                        <img className="img-responsive" src="./img/Home/into.png" />
                    </a>
                </div>
            </div>








            </div>


        );
    }


});



module.exports=SurgeryWgt;