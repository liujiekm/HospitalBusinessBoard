$('.nav-choice>li').click(function () {

    chart1 = require('echarts').init(document.getElementById('chart_1'));
    chart2 = require('echarts').init(document.getElementById('chart_2'));
    chart3 = require('echarts').init(document.getElementById('chart_3'));
    $(this).addClass("active");
    $(this).siblings().removeClass("active");
    var timespan = $(this).children()[0].innerText;
    var temp = new Date();
    
    var sd = '', ed = '';
    switch (timespan) {
        case "近7天":
            temp.setDate(temp.getDate() - 7);
            sd = temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '00:00:00';
            ed = temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';

            

            break;
        case "近一月":
            temp.setDate(temp.getDate() - 30);
            sd = temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '00:00:00';
            ed = temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';

            break;
        case "近一年":
            temp.setDate(temp.getDate() - 365);
            sd = temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '00:00:00';
            ed = temp.getFullYear() + '-' + (temp.getMonth() + 1) + '-' + temp.getDate() + ' ' + '23:59:59';

            break;

        default:
    }
});