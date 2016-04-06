$('.div_nav').click(function () {
    //样式切换 
    $(this).css('background', '#4AA0E9').css('color', 'white');
    $(this).siblings().css('background', '#E9F3FC').css('color', '#8AC4F2');
    chart1 = require('echarts').init(document.getElementById('chart_1'));
    chart2 = require('echarts').init(document.getElementById('chart_2'));
    //根据选中项目，加载对应的echart
    var reportType = $(this).attr("id");
    switch (reportType) {
        case "outpatient":
            chart3 = require('echarts').init(document.getElementById('chart_3'));


            break;
        case "inhospital"://切换到住院类别的报表
            
            chart3 = require('echarts').init(document.getElementById('chart_3'));




            break;
        case "pharmaceuticals":
           
            chart3 = require('echarts').init(document.getElementById('chart_3'));

            break;
        case "property":
            $('#chart_3').parent().parent().hide();
            $('#chart_3').parent().parent().prev().hide()
            
            break;
        case "finance":
            $('#chart_3').parent().parent().hide();
            //增加职工查询高级选项
            break;
        case "experiance":
          
            chart3 = require('echarts').init(document.getElementById('chart_3'));
            break;

        default:
    }
    $('#hdn_reportType').val(reportType);


});