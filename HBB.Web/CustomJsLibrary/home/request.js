
$(function(){

    getHomeInfo();
    getPatientExperienceInfo();
    getHomeChart();



    //门诊 以及特检对应值 超过多少 颜色加深显示
    if (parseFloat($('#appointmentLastMonth').text()) > 3)
    {
        $('#appointmentLastMonth').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else
    {
        $('#appointmentLastMonth').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#awaitingDiagnosis').text()) > 30) {
        $('#awaitingDiagnosis').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#awaitingDiagnosis').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#diagnosis').text()) > 10) {
        $('#diagnosis').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#diagnosis').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#payFees').text()) > 5) {
        $('#payFees').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#payFees').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#medicineReceiving').text()) > 10) {
        $('#medicineReceiving').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#medicineReceiving').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    //特检

    if (parseFloat($('#xray').text()) > 3) {
        $('#xray').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#xray').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#ct').text()) > 3) {
        $('#ct').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#ct').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#mri').text()) > 3) {
        $('#mri').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#mri').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#bc').text()) > 3) {
        $('#bc').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#bc').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }
    if (parseFloat($('#cu').text()) > 3) {
        $('#cu').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
    }
    else {
        $('#cu').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
    }

});


    

   

    function getHomeInfo()
    {
        //主页数字类数据动态显示
        //'Handler/HomeHandler.ashx?type=hi'
        $.getJSON(baseUrl+'HI/GHI', function (data) {
            //$('#lines').animateNumber({ number: data.OutPatientRegisterYesterday });

            $('#morningSignInRate').text(parseInt(data.RegistrationRateAm * 100));
            $('#afternoonSignInRate').text(parseInt(data.RegistrationRatePm * 100));
            $('#morningHasSignIn').text(data.DoctorRegisteredQuantyAm);
            $('#morningShouldSignIn').text(data.DoctorTotalQuantyAm);
            $('#afternoonHasSignIn').text(data.DoctorRegisteredQuantyPm);
            $('#afternoonShouldSignIn').text(data.DoctorTotalQuantyPm);
            $('#waitingNum').text(data.WaitingQuantity);
            $('#treatedNum').text(data.CompletedTreatQuanty);
            $('#severeObservingQuanty').text(data.SevereObservingQuanty);
            $('#firstAidQuanty').text(data.FirstAidQuanty);
            $('#hospitalizedNum').text(data.HospitalizedQuanty);
            $('#leaveYeaterday').text(data.YesterdayLeaveHospitalQuanty);
            $('#IncomeYeaterday').text(data.YesterdayAdminttedHospitalQuanty);
            $('#ratedBeds').text(data.RatedEmptyBedQuanty);
            $('#addedBeds').text(data.ExtraBedQuanty);
            $('#vitrualBeds').text(data.VirtualBedQuanty);

        });
    }



    function getPatientExperienceInfo() {
        //'Handler/GenericHandler.ashx?type=pti',
        $.getJSON(baseUrl + 'UE/OPILM',
            function (data) {
            //$('#lines').animateNumber({ number: data.OutPatientRegisterYesterday });

            $('#appointmentLastMonth').text((data[0] / 60 / 24).toFixed(2));//以天为单位
            $('#awaitingDiagnosis').text(data[1].toFixed(1));
            $('#diagnosis').text(data[2].toFixed(1));
            $('#payFees').text(data[3].toFixed(1));
            $('#medicineReceiving').text(data[4].toFixed(1));

            //门诊 以及特检对应值 超过多少 颜色加深显示
            if (parseFloat($('#appointmentLastMonth').text()) > 3) {
                $('#appointmentLastMonth').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#appointmentLastMonth').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#awaitingDiagnosis').text()) > 30) {
                $('#awaitingDiagnosis').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#awaitingDiagnosis').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#diagnosis').text()) > 10) {
                $('#diagnosis').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#diagnosis').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#payFees').text()) > 5) {
                $('#payFees').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#payFees').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#medicineReceiving').text()) > 10) {
                $('#medicineReceiving').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#medicineReceiving').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
        });
        //特检标识性数据
        //'Handler/GenericHandler.ashx?type=psti',
        $.getJSON(baseUrl + 'UE/SIILM',
            function (data) {
            //$('#lines').animateNumber({ number: data.OutPatientRegisterYesterday });

            $('#xray').text((data[0] / 60 / 24).toFixed(2));//以天时为单位
            $('#ct').text((data[1] / 60 / 24).toFixed(1));
            $('#mri').text((data[2] / 60 / 24).toFixed(1));
            $('#bc').text((data[3] / 60 / 24).toFixed(1));
            $('#cu').text((data[4] / 60 / 24).toFixed(1));



            if (parseFloat($('#xray').text()) > 3) {
                $('#xray').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#xray').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#ct').text()) > 3) {
                $('#ct').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#ct').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#mri').text()) > 3) {
                $('#mri').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#mri').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#bc').text()) > 3) {
                $('#bc').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#bc').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
            if (parseFloat($('#cu').text()) > 3) {
                $('#cu').parent().parent().parent().parent().removeClass('pannelContent').addClass('pannelContentWarning');
            }
            else {
                $('#cu').parent().parent().parent().parent().removeClass('pannelContentWarning').addClass('pannelContent');
            }
        });
    }
    //门诊标识性数据



    function getHomeChart() {
        require.config({
            paths: {
                echarts: 'content/js'
            }
        });
        require(
        [
            'echarts',
            'echarts/chart/bar',
            'echarts/chart/line',
            'echarts/chart/pie'
        ],
        function (ec) {
            var echarts = ec;
            var doctorSignInRate = ec.init(document.getElementById('doctorSignInRate'));
            var delayedDept = ec.init(document.getElementById('delayedDept'));
            var specifiedEmptyBed = ec.init(document.getElementById('specifiedEmptyBed'));
            //operationStats
            var operationStats = ec.init(document.getElementById('operationStats'));
            //近7天

            //医生签到
            homeLineOption.xAxis[0].data.length = 0;
            homeLineOption.series[0].data.length = 0;
            doctorSignInRate.showLoading({
                text: '数据读取中...', effect: 'spin', textStyle: {
                    fontSize: 20
                }
            });
            //'Handler/HomeHandler.ashx?type=dr
            $.getJSON(baseUrl + 'OPA/RDR', function (items) {
                $.each(items, function (index, item) {

                    homeLineOption.xAxis[0].data.push(item.RegistrationDate + item.RegistrationTime);
                    homeLineOption.series[0].data.push(parseInt(item.RegistrationRate * 100));
                    doctorSignInRate.hideLoading();
                    doctorSignInRate.setOption(homeLineOption);
                });

            });

            homeBarOption.xAxis[0].data.length = 0;
            homeBarOption.series[0].data.length = 0;
            homeBarOption.series[1].data.length = 0;
            //坐诊情况
            delayedDept.showLoading({
                text: '数据读取中...', effect: 'spin', textStyle: {
                    fontSize: 20
                }
            });
            //'Handler/HomeHandler.ashx?type=wq'
            $.getJSON(baseUrl + 'OPA/RWQ', function (items) {
                $.each(items, function (index, item) {
                    homeBarOption.xAxis[0].data.push(item.Specialist);//修改成科室名称
                    homeBarOption.series[0].data.push(item.WaitingQuanty);
                    homeBarOption.series[1].data.push(item.CompletedTreatQuanty);
                    delayedDept.hideLoading();
                    delayedDept.setOption(homeBarOption);
                });

            });

            operationStats.showLoading({
                text: '数据读取中...', effect: 'spin', textStyle: {
                    fontSize: 20
                }
            });
            //手术
            //'Handler/HomeHandler.ashx?type=si'
            $.getJSON(baseUrl+'OP/RSI', function (item) {
                //手术

                hoemPieOption.series[0].data = [item.CompletedQuanty];
                hoemPieOption.series[1].data = [item.DoingQuanty];
                hoemPieOption.series[2].data = [item.WaitingQuanty];
                //hoemPieOption.series[0].data = [{ value: item.CompletedQuanty, name: '已完成' }, { value: item.DoingQuanty, name: '进行中' }, { value: item.WaitingQuanty, name: '等待中' }];
                operationStats.hideLoading();
                operationStats.setOption(hoemPieOption);
            });

            //额定空床
            homeEmptyBedOption.xAxis[0].data.length = 0;
            homeEmptyBedOption.series[0].data.length = 0;
            specifiedEmptyBed.showLoading({
                text: '数据读取中...', effect: 'spin', textStyle: {
                    fontSize: 20
                }
            });
            //'Handler/HomeHandler.ashx?type=reb'
            $.getJSON(baseUrl+'HI/REB', function (items) {
                $.each(items, function (index, item) {
                    homeEmptyBedOption.xAxis[0].data.push(item.Specialist);

                    homeEmptyBedOption.series[0].data.push(item.RateEmptyBedQuanty);
                    specifiedEmptyBed.hideLoading();
                    specifiedEmptyBed.setOption(homeEmptyBedOption);
                });

            });



        });


    }
        

    setInterval('getHomeInfo()', 10000);
    setInterval('getPatientExperienceInfo()', 10000);
    setInterval('getHomeChart()', 10000);



