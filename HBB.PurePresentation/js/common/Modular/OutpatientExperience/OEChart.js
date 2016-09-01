/**
 * Created by Jay on 2016/6/1.
 * 门诊体验，各科室对比时长chart
 */
import React,{Component,PropTypes} from 'react'
import echarts from 'echarts'

// import { Tabs } from 'antd'
// const TabPane = Tabs.TabPane;

class OEChart extends Component{

    constructor(props)
    {
        super(props);
        this.state={
            currentTab:"Diagnosis"//默认展现就诊时长Tab
        }

    }

    //构建科室间对比的chart option
    _constructContrastOption(optionItems,currentOption,currentTab)
    {
        let legends = [];
        //取得科室名称
        $.each(optionItems, function (index, items) {
            for (var i = 0; i < items.length; i++) {
                legends.push(items[i].SpecialistName);
                break;
            }
        });
        currentOption.legend.data = legends;
        currentOption.series.length = 0;
        for (var i = 0; i < legends.length; i++) {
            currentOption.series[i] = { name: legends[i], type: 'line', data: [] };
        }
        $.each(optionItems, function (index, items) {
            currentOption.xAxis[0].data.length = 0;
            $.each(items, function (itemIndex, item) {
                currentOption.xAxis[0].data.push(item.StaticsTime);
                currentOption.series[index].data.push(item[currentTab]);
            });
        });
    }

    //指定科室的三年同比数据
    _constructYoYOption(optionItems,currentOption,currentTab)
    {
        //取得年份为legend
        var legends = [];
        //清空option series数据
        currentOption.series.length=0;
        currentOption.legend.data.length=0;
        $.each(optionItems, function (index, items) {
            currentOption.xAxis[0].data.length = 0;
            let currentLegend = "";
            currentOption.series[index]={};
            currentOption.series[index].type="line";
            currentOption.series[index].data=[];
            $.each(items, function (itemIndex, item) {
                currentLegend=item.StaticsTime.substring(0,4);//依赖时间格式 后续需修改
                currentOption.xAxis[0].data.push(item.StaticsTime.substring(5));//依赖时间格式 后续需修改
                currentOption.series[index].data.push(item[currentTab]);
            });
            currentOption.series[index].name = currentLegend;    
            legends.push(currentLegend);
        });
        currentOption.legend.data = legends;
    }

    componentDidMount() {       
        const chart = this.getEchartInstance();
        let indicate = this.props.indicate;
        let currentOption = this.props.oeOption;
        let self = this;
        if(indicate)//对比
        {
            let contrastItems = this.props.contrastItems;//对比数据源
            this._constructContrastOption(contrastItems,currentOption,self.state.currentTab);
        }
        else//同比
        {
            let yoyItems = this.props.yoyItems;//同比数据源
            this._constructYoYOption(yoyItems,currentOption,self.state.currentTab);
        }

        chart.setOption(currentOption);

    }

    componentWillUpdate(nextProps, nextState){
        //更新
        let chart = this.getEchartInstance();
        let indicate = this.props.indicate;
        let currentTab = nextState.currentTab;
        let currentOption = this.props.oeOption;
        if(indicate)
        {
            let contrastItems = this.props.contrastItems;//对比数据源
            this._constructContrastOption(contrastItems,currentOption,currentTab);
        }
        else
        {
            let yoyItems = this.props.yoyItems;//同比数据源
            this._constructYoYOption(yoyItems,currentOption,currentTab);
        }
        chart.setOption(currentOption);

    }

    componentWillUnmount () {
        echarts.dispose(this.refs.chart)
    }
    
    getEchartInstance(){
        
        const chartDom = this.refs.chart;
        const chart = echarts.getInstanceByDom(chartDom) || echarts.init(chartDom);
        
        return chart;
    }
    handleTabClick(e)
    {
        this.setState({currentTab:e.target.id});
    }

    render(){

        return (

            <div className="col-md-12 personPanel">
                <ul className="nav nav-tabs" role="tablist" ref="ulTimeType">
                    <li role="presentation"><a id="MedicineReceiving" aria-controls="medicineReceiving" role="tab" data-toggle="tab" onClick={this.handleTabClick.bind(this)}>取药时长(分钟)</a></li>
                    <li role="presentation"><a id="PayFees" aria-controls="payFees" role="tab" data-toggle="tab" onClick={this.handleTabClick.bind(this)}>缴费时长(分钟)</a></li>
                    <li role="presentation" className="active"><a id="Diagnosis" aria-controls="diagnosis" role="tab" data-toggle="tab" onClick={this.handleTabClick.bind(this)}>就诊时长(分钟)</a></li>
                    <li role="presentation"><a id="AwaitingDiagnosis" aria-controls="awaitingDiagnosis" role="tab" data-toggle="tab" onClick={this.handleTabClick.bind(this)}>候诊时长(分钟)</a></li>
                    <li role="presentation"><a id="Appointment" aria-controls="appointment" role="tab" data-toggle="tab" onClick={this.handleTabClick.bind(this)}>预约时长(天)</a></li>
                </ul>

                <div className="tab-content personContent">               

                    <div ref="chart" className="oe-chart"></div>
                   
                </div>



            </div>


        )

    }

}


export default OEChart