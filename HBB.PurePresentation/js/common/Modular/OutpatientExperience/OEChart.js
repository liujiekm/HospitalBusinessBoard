/**
 * Created by Jay on 2016/6/1.
 * 门诊体验，各科室对比时长chart
 */
import React,{Component,PropTypes} from 'react'
import echarts from "echarts"




class OEChart extends Component{



    componentDidMount() {       
        const chart = this.getEchartInstance();
        chart.setOption(this.props.oeOption);
        //this.getChartData(chart);
    }

    componentDidUpdate(){
        //更新
        const chart = this.getEchartInstance();
        chart.setOption(this.props.oeOption);

    }

    componentWillUnmount () {
        echarts.dispose(this.refs.chart)
    }
    
    getEchartInstance(){
        
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        
        return chart;
    }
    
    render(){

        return (

            <div className="col-md-12 personPanel">
                <ul className="nav nav-tabs" role="tablist" ref="ulTimeType">
                    <li role="presentation"><a id="MedicineReceiving" aria-controls="medicineReceiving" role="tab" data-toggle="tab">取药时长(分钟)</a></li>
                    <li role="presentation"><a id="PayFees" aria-controls="payFees" role="tab" data-toggle="tab">缴费时长(分钟)</a></li>
                    <li role="presentation" className="active"><a id="Diagnosis" aria-controls="diagnosis" role="tab" data-toggle="tab">就诊时长(分钟)</a></li>
                    <li role="presentation"><a id="AwaitingDiagnosis" aria-controls="awaitingDiagnosis" role="tab" data-toggle="tab">候诊时长(分钟)</a></li>
                    <li role="presentation"><a id="Appointment" aria-controls="appointment" role="tab" data-toggle="tab">预约时长(天)</a></li>
                </ul>

                <div className="tab-content personContent">               

                    <div ref="chart" className="oe-chart"></div>
                   
                </div>
            </div>


        )

    }

}


export default OEChart