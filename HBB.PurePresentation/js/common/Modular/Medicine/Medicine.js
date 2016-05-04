/**
 * Created by liu on 2016/4/13.
 */


import React from 'react';
import { render, findDOMNode } from 'react-dom'

import ReactEcharts from "react-echarts-component"


import DrugProportionHistory from "./DrugProportionHistory"

import DrugProportionWgt from "./DrugProportionWgt"
import DrugStorageMonthlyWgt from "./DrugStorageMonthlyWgt"
import DrugStoragePurchaseWgt from "./DrugStoragePurchaseWgt"
import PharmacyMonthlyWgt from "./PharmacyMonthlyWgt"
import RecipeWgt from "./RecipeWgt"
import Extension from "../../component/Extension"

import RedirectComponent from "../../component/RedirectComponent"


var Medicine = React.createClass({

    render:function () {
        return (
            <div>

                <div className="wgt-group">
                    <DrugProportionWgt />
                    <Extension />
                    <DrugProportionHistory />
                </div>

                <div className="wgt-group">
                    <DrugStorageMonthlyWgt />
                    <Extension />
                    <DrugStoragePurchaseWgt/>
                </div>

                <div className="wgt-group">
                    <PharmacyMonthlyWgt />
                    <RedirectComponent  imgUrl="./img/Home/medicalService.png" componentName="在用药品查询" redirectUrl="#" />
                </div>

                <div className="wgt-group">
                    <RecipeWgt/>
                </div>
            </div>

        );
    }
});

module.exports=Medicine;