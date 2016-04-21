<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OperationMain.aspx.cs" Inherits="HBB.Web.OperationMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/DateTimePicker.css" rel="stylesheet" />
    <style type="text/css">
        .rowContent {
            background: url('content/img/newHome/30black.png') repeat;
            color: white;
            height: 110px;
        }

        .pannelContent {
            background: url('content/img/newHome/30green.png') repeat;
            margin-right: 10px;
            width: 14.5%;
            margin-top: 10px;
        }

        .pannelContentClean {
            margin-right: 10px;
            margin-top: 10px;
            width: 14.5%;
        }

        .lead {
            margin-top: 10px;
        }

        .bottomContent {
            float: right;
            margin-right: 5px;
        }

        .reportMain {
            background: url('content/img/newHome/30black.png') repeat;
            margin-top: 20px;
            width: 100%;
            overflow: hidden;
        }


        .returnPage {
            color: white;
            font-size: 40px;
            padding-left: 20px;
            cursor: pointer;
        }

        .moduleIndicate {
            color: white;
            text-align: right;
            padding-top: 10px;
            padding-right: 20px;
        }

        .contentRow {
            margin-left: 5px;
            margin-right: 5px;
            background-color: #F7F7F7;
        }

        .btn {
            border-radius: 0px;
            width: 70px;
        }
        .btn-lg
        {
            width:100px;
            background-color:#0988CE;
            color:white;
        }

        .input-lg
        {
            width:400px;
            border-radius:0px;
        }
        .btnClick {
            color: white;
            background-color: #0988CE;
        }

        .btn:hover,
        .btn:focus {
            color: white;
            background-color: #0988CE;
        }
        .dataControl{
            height:34px;
        }

        .checkbox, .radio {
            
             margin-top: 0px; 
           
        }
        @media only screen and (min-width: 1024px) {


            .reportMain {
                height: 400px;
            }

            .contentRow {
                height: 335px;
            }
        }

        @media only screen and (min-width: 1280px) {


            .reportMain {
                height: 550px;
            }

            .contentRow {
                height: 485px;
            }
        }

        @media only screen and (min-width: 1440px) {


            .reportMain {
                height: 550px;
            }

            .contentRow {
                height: 485px;
            }
        }



        .searchBaseOn {
        }
    </style>
    <style>
        .select4_box{border: 1px solid #5897fb;position: absolute;width:250px;background: #fff;border-radius: 4px;-webkit-box-shadow: 0 4px 5px rgba(0, 0, 0, .15);box-shadow: 0 4px 5px rgba(0, 0, 0, .15);z-index: 9999;}
        .select4_box ul{padding: 0px;margin: 5px;}
        .select4_box ul li{list-style: none;padding: 3px 7px 4px; cursor: pointer;}
        .select4_box ul li:hover{background: #51A9A9;color: #fff;}
        .select4_box ul li.active{background: #3875d7; color: #fff;}
    </style>
    <script type="text/javascript">
        $(function () {
            $('#operation').addClass('active');
            $('#returnLink').hide();
            $("#dtBox").DateTimePicker({

                dateFormat: "yyyy-MM-dd",
                fullDayNames: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"],
                shortMonthNames: ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"],
                fullMonthNames: ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"],
                titleContentDate: "设置日期",
                setButtonContent: "设定",
                clearButtonContent: "清除",
                isPopup: true,
                formatHumanDate: function (date) {
                    return date.yyyy + "-" + date.month + "-" + date.dd;
                },
                addEventHandlers: function () {
                    var dtPickerObj = this;
                    dtPickerObj.setDateTimeStringInInputField($("#eDate"), new Date());
                    dtPickerObj.setDateTimeStringInInputField($("#sDate"), new Date(new Date().getTime() - 1000 * 60 * 60 * 24 * 7));

                }
            });

            //初始化日期选择时间

           

            $('.btn-default').click(function () {
                $(this).addClass('btnClick');
                $(this).siblings().removeClass('btnClick');

                $('#hospitalDistrict').val($(this).val());
            });
        });
    </script>
    <script type="text/javascript">


        function OperationSearch() {
            //公共变量
            var searchContent = $("#searchContent").val();
            var searchContentName = $("#searchContent").attr("name");
            var sDate=$("#sDate").val();
            var eDate = $("#eDate").val();
            var hospital = $("#hospital").attr('class');
            var hospitalOld = $("#hospitalOld").attr('class');
            var hospitalNew = $("#hospitalNew").attr('class');
            var hospitalValue = "";
            var operationType = "";
            if (hospital == "btn btn-default btnClick") { hospitalValue = $("#hospital").val() }
            else if (hospitalOld == "btn btn-default btnClick") { hospitalValue = $("#hospitalOld").val() }
            else if (hospitalNew == "btn btn-default btnClick") { hospitalValue = $("#hospitalNew").val() }
            searchContent = encodeURI(searchContent);

            var obj = document.getElementsByName('searchBaseOn');
            for (var i = 0; i < obj.length; i++) {
                if (obj[i].checked == true) {
                    if (obj[i].value == 'category') {//按类别
                        if (operationType = GetOperationType())
                        { window.location.href = "Operation.aspx?searchType=category&area=" + hospitalValue + "&operationType=" + operationType + "&sDate=" + sDate + "&eDate=" + eDate + "&content=" + searchContent + "&searchContentName="+searchContentName; }
                    } else if (obj[i].value == 'dept') {//按科室
                        window.location.href = "Operation.aspx?searchType=dept&area=" + hospitalValue + "&sDate=" + sDate + "&eDate=" + eDate + "&content="  + searchContent + "&searchContentName=" + searchContentName;
                    } else if (obj[i].value == 'disease') {//按疾病
                        
                        window.location.href = "Operation.aspx?searchType=disease&area=" + hospitalValue + "&sDate=" + sDate + "&eDate=" + eDate + "&content=" + searchContent + "&searchContentName=" + searchContentName;
                    } else if (obj[i].value == 'doctor') {//按医生
                        window.location.href = "Operation.aspx?searchType=doctor&area=" + hospitalValue + "&sDate=" + sDate + "&eDate=" + eDate + "&content=" + searchContent + "&searchContentName=" + searchContentName;
                    }
                }
            }
            //获取手术类型
            function GetOperationType() {
                var operationType = "";
                var checkedBox = $("input[type='checkbox'][name='operationType']:checked");
                if (checkedBox.length == 0) {
                    alert("手术类别没有选择！");
                    return false;
                }
                //alert(checkedBox.length);
                checkedBox.each(function () {
                    if ($(this).val() == "specialClass") {
                        operationType += "5";
                    } else if ($(this).val() == "fourthClass") {
                        operationType += "4";
                    } else if ($(this).val() == "thirdClass") {
                        operationType += "3";
                    } else if ($(this).val() == "secondClass") {
                        operationType += "2";
                    } else if ($(this).val() == "firstClass") {
                        operationType += "1";
                    }
                })
                return operationType;
            }
        }

        $(function () {
                    $.ajax({
                        type: "get",
                        contentType: "text/json",
                        dataType: "json",
                        async: false,
                        
                        //url: "../Handler/OperationHandler.ashx?type=oq",
                        url: baseUrl+"OP/OQ",
                        success: function(data) {
                            var json = eval(data);
                           // alert("sdf");
                            $("#operationNumLastMonth").empty();
                            $("#appointmentLastMonth").empty();
                            $("#awaitingDiagnosis").empty();
                            $("#diagnosis").empty();
                            $("#payFees").empty();
                            $("#medicineReceiving").empty();

                            $("#operationNumLastMonth").append(json.Table[0].TOTAL);
                            $("#appointmentLastMonth").append(json.Table[0].FIVETYPEOPERATION);
                            $("#awaitingDiagnosis").append(json.Table[0].FOURTYPEOPERATION);
                            $("#diagnosis").append(json.Table[0].THREETYPEOPERATION);
                            $("#payFees").append(json.Table[0].TWOTYPEOPERATION);
                            $("#medicineReceiving").append(json.Table[0].ONETYPEOPERATION);
                        },
                        error: function() {
                            //alert("获取失败！");
                        }
                    });
            //单选框点击事件
            $('.searchBaseOn').bind('click', function() {
                var obj = document.getElementsByName('searchBaseOn');
                // var operationType = "operationType";
                var operationType = "cb_operationType";
                var checked = false; //未选中
                var disabled = true; //不可选
                var type = "";
                for (var i = 0; i < obj.length; i++) {
                    if (obj[i].checked == true) {
                        if (obj[i].value == 'category') {
                            checked = true; //未选中
                            disabled = false; //不可选
                            type = "category";
                            OperationCheckBox(operationType, checked, disabled, type);
                            //alert(' 按类别');
                            //var checkbox = $("#" + operationType + "").find("input:checkbox");
                            //if (1) {
                            //    checkbox.prop("checked", true);
                            //} else {
                            //    checkbox.removeAttr("checked");
                            //}
                        } else if (obj[i].value == 'dept') {
                            OperationCheckBox(operationType, checked, disabled, type);
                            // alert(' 按科室');
                        } else if (obj[i].value == 'disease') {
                            OperationCheckBox(operationType, checked, disabled, type);
                            //var checkbox = $("#" + operationType + "").find("input:checkbox");
                        } else if (obj[i].value == 'doctor') {
                            OperationCheckBox(operationType, checked, disabled, type);
                        }
                    }
                }
            });

            //多选框操作（是否选中、是否可用）
            function OperationCheckBox(id, checked, disabled, type) {
                var number = 0;
                var checkbox = $("#" + id + "").find("input:checkbox");
                var checkedBox = $("input[type='checkbox'][name='operationType']:checked");
                var disabledBox = $("input[type='checkbox'][name='operationType'][disabled='disabled']");
                //alert(checkedBox.length);
                checkbox.each(function() {
                    if ($(this).prop("checked")) {
                        // $(this).prop("disabled", disabled);
                        $(this).attr("disabled", disabled);
                    } else {
                        // $(this).prop("disabled", disabled); 
                        $(this).attr("disabled", disabled);
                    }

                    if (type == "category" && checkbox.length == checkedBox.length && disabledBox.length == 0) {
                        $(this).prop("checked", false);
                        $(this).attr("checked", false);
                    } else if (type == "category" && checkedBox.length == 0) {
                        $(this).prop("checked", true);
                        $(this).attr("checked", true);
                    } else if (type == "category" && checkedBox.length > 0 && disabledBox.length == 0) {
                        $(this).prop("checked", true);
                        $(this).attr("checked", true);
                    }
                });
            };

            function getOperationQuanty() {
                $.ajax({
                    type: "get",
                    contentType: "text/json",
                    dataType: "json",
                    async: false,
                    //url: '../Handler/HomeHandler.ashx?type=ordi',
                    url: "../Handler/HomeHandler.ashx?type=oq",
                    success: function (data) {
                        var json = eval(data);
                        var tableStr = "";
                        if (json != null) {
                            //alert(json.length);
                            for (var i = 0, l = json.length; i < l; i++) {
                                alert(json.TOTAL);
                            }
                        }
                    },
                    error: function () {
                        alert("获取失败！");
                    }
                });
            }
          


        });
    </script>
    <script type="text/javascript">
        function test() {

            //var checkbox = $("#ce").find("input:checkbox");
            //checkbox.attr("disabled", "disabled");
            //checkbox.each(function () {
            //    if ($(this).val() == "Monthly") {
            //        $(this).attr("checked", true);
            //    }
            //});

            //var checkbox = $("#" + name + "").find("input:checkbox");
            //checkbox.Count;
            //checkbox.prop("checked", checked);
            //checkbox.prop("disabled", disabled);

            //$("input[name=" + name + "]").each(function () {
            //    if ($(this).prop("checked")) {
            //        $(this).prop("disabled", disabled);
            //        number++;

            //    }
            //    else {
            //        $(this).prop("disabled", disabled);
            //        $(this).prop("checked", checked);
            //    }
            //    alert(checkbox.length);
            //})

            //if (number == 1) { alert(sdf); }
        }
    </script>
    <script>
            (function ($) {
                $.fn.extend({
                    select4: function (options) {
                        var defaults = { ajax_url: true }
                        var options = $.extend(defaults, options);
                        return this.each(function () {
                            $(".h2").remove();
                            var mythis = $(this);

                            $(document).on("click", ".select4_box li", function () {
                                mythis.val($(this).text());
                                var alt =$(this).attr("alt");
                                mythis.attr("name", alt);
                                $(".select4_box").remove();
                            });

                            $(document).click(function (event) {
                                $(".select4_box").remove();
                            });

                            $(".select4_box").click(function (event) {
                                event.stopPropagation();
                            });

                            mythis.click(function (event) {
                                var val = $(this).val();
                                console.log(val);
                                var mythis = $(this);
                                var width = $(this).width() + 36 + "px";
                                var top = $(this).position().top + 46;
                                var left = $(this).position().left;
                                var height = $(this).height() + 300;

                                var searchRateType = "";
                                $("input[name='searchBaseOn']:checked").each(function (n, d) {
                                    //在这里对result进行赋值 
                                    if (this.value == 'dept') { searchRateType = "specialist" ; return}
                                    else if (this.value == 'disease') { searchRateType = "disease"; return}
                                    else if (this.value == 'doctor') { searchRateType = "doctor"; return}
                                    else if (this.value == 'category') { return}
                                    //result = this.value;
                                    //alert(result);
                                });
                                if (searchRateType == "") { return;}
                                var searchContent = $("#searchContent").val();
                                //var url = "../handler/OperationHandler.ashx?type=osr&searchContent=" + searchContent + "&searchRateType=" + searchRateType;
                                var url = baseUrl+"OP/OSR/" + searchContent + "/" + searchRateType;

                                $.ajax({
                                    //url: options.ajax_url,
                                    url:url,
                                    dataType: "json",
                                    //data: { name: val },
                                    success: function (data) {
                                        var json = eval(data);
                                        if (json != null) {
                                            var html = '<div class="select4_box"><ul>';
                                            $.each(json, function (k, v) {
                                                html += '<li alt="' + v.ID + '">' + v.Name + '</li>';
                                            });
                                            html += '</ul></div>'
                                            $(".select4_box").remove();
                                            //alert(html);
                                            mythis.after(html);
                                            $(".select4_box").css({ top: top, left: left, width: width, 'overflow-y': 'auto', 'height': height + 'px' });
                                        }
                                    }
                                });
                            });

                            mythis.keyup(function (event) {
                                if (event.keyCode == 40) {
                                    var index = $(".select4_box li.active").index() + 1;
                                    $(".select4_box li").eq(index).addClass('active').siblings().removeClass('active');
                                    mythis.val($(".select4_box li.active").text());
                                } else if (event.keyCode == 38) {
                                    var index = $(".select4_box li.active").index() - 1;
                                    if (index < 0) {
                                        index = $(".select4_box li").length - 1;
                                    }
                                    $(".select4_box li").eq(index).addClass('active').siblings().removeClass('active');
                                    mythis.val($(".select4_box li.active").text());
                                } else if (event.keyCode == 13) {
                                    event.stopPropagation();
                                    //alert($(".select4_box li.active").text());
                                    mythis.val($(".select4_box li.active").text());
                                    var alt=$(".select4_box li.active").attr("alt");
                                    mythis.attr("name", alt);
                                    $(".select4_box").remove();//huang
                                    return false;
                                } else {
                                    mythis.trigger("click");
                                }
                            });

                        });


                    }
                });
            })(jQuery);
    </script>
     <script>
         var aa=function getCheckObject() {
             var result;
             $("input[name='searchBaseOn']:checked").each(function (n, d) {
                 //在这里对result进行赋值 
                 result = this.value;
                 alert(result);
             });
         }

         $(function () {
             var searchRateType = "";
             aa;
                 //
                 
             //$("input[name=searchBaseOn]:checkbox").each(function () { 
             //    if ($(this).attr("checked") && $(this).val() == "dept") {
             //        searchRateType = "specialist";
             //        alert(searchRateType);
             //    }
             //    else if ($(this).attr("checked") && $(this).val() == "disease") {
             //        searchRateType = "disease";
             //    }
             //    else if ($(this).attr("checked") && $(this).val() == "doctor") {
             //        searchRateType = "doctor";
             //    }
             //    else {
             //        return ;
             //    }
             //}) 
             
             //var url = "../handler/DoctorRegisterHandler.ashx?type=durdi&timePoint=10";
             //var url = "../handler/OperationHandler.ashx?type=osr&searchContent=" + searchContent + "&searchRateType="+searchRateType;
             //ajax_url是这个input绑定的ajax数据地址
             //$(".Jiancha_xiangmu").select4({ "ajax_url": "../handler/DoctorRegisterHandler.ashx?type=durdi&timePoint=10" });
             $(".input-lg").select4({ "ajax_url": "df" });
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
     <script src="content/js/DateTimePicker.js"></script>
    <!--门诊就医-->
    <div class="row">

        <div class="col-md-12">
            <div class="row rowContent">
                <div class="col-md-2">
                    <div class="row">
                        <div class="col-md-7" style="margin-top: 20px; margin-left: -5px;">
                            <img class="img-responsive" src="content/img/newHome/operation.png" />
                            <img class="img-responsive verticalLine" src="content/img/newHome/VerticalLine.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-left: -20px; margin-left: -30px\0;">
                            <p class="imgText text-center">手术统计</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-10" style="left: -3%;">

                    <div class="row" style="margin-left: -40px;">
                        <div class="col-md-2 pannelContentClean">
                            <div class="row">
                                <div class="col-md-5" style="margin-left: -5px;">
                                    <p class="text-left text-nowrap">近30天</p>
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="lead text-center text-nowrap"><strong id="operationNumLastMonth">1500</strong></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-3 bottomContent">
                                    <p class="text-right">台</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 pannelContent">
                            <div class="row">
                                <div class="col-md-5" style="margin-left: -5px;">
                                    <p class="text-left text-nowrap">特类</p>
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="lead text-center"><strong id="appointmentLastMonth">500</strong></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-3 bottomContent">
                                    <p class="text-right">台</p>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-2 pannelContent">
                            <div class="row">
                                <div class="col-md-5" style="margin-left: -5px;">
                                    <p class="text-left text-nowrap">四类</p>
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="lead text-center"><strong id="awaitingDiagnosis">450</strong></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-3 bottomContent">
                                    <p class="text-right text-nowrap">台</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 pannelContent">
                            <div class="row">
                                <div class="col-md-5" style="margin-left: -5px;">
                                    <p class="text-left text-nowrap">三类</p>
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="lead text-center"><strong id="diagnosis">240</strong></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-3 bottomContent">
                                    <p class="text-right text-nowrap">台</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 pannelContent">
                            <div class="row">
                                <div class="col-md-5" style="margin-left: -5px;">
                                    <p class="text-left text-nowrap">二类</p>
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="lead text-center"><strong id="payFees">375</strong></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-3 bottomContent">
                                    <p class="text-right text-nowrap">台</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 pannelContent">
                            <div class="row">
                                <div class="col-md-5" style="margin-left: -5px;">
                                    <p class="text-left text-nowrap">一类</p>
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="lead text-center"><strong id="medicineReceiving">263</strong></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-3 bottomContent">
                                    <p class="text-right text-nowrap">台</p>
                                </div>
                            </div>
                        </div>




                    </div>
                </div>
                <a href="#" style="position: absolute; right: 0%;">
                    <img class="img-responsive" src="content/img/newHome/into.png" />
                </a>

            </div>


            <div class="row">
            </div>


        </div>




    </div>

    <div class="row">

        <div class="col-md-12 col-sm-12 col-xs-12 reportMain">
            <!--中间页面顶部标识-->
            <div class="row">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-arrow-left returnPage" aria-hidden="true" id="returnLink"></span>
                </div>
                <div class="col-md-6"></div>
                <div class="col-md-4 moduleIndicate">
                    <!--当前页面模块内容-->
                    <span class="lead text-nowrap" id="moduleName" >手术查询</span>
                </div>
            </div>

            <div class="row contentRow">
                <div class="col-md-12" style="  margin-top: 6%;">
                    <div class="row" style="margin-top:50px;">
                        <div class="col-md-2"></div>
                        <div class="col-md-6">
                        <%--huang--%>

                            <input type="text" class="input-lg" id="searchContent" autocomplete="off" />

                            <%--<input type="text"  name="Shoushuid"  class="Shoushuid"  autocomplete="off">
                            <input type="text"  name="Jiancha_xiangmu"  class="Jiancha_xiangmu"  autocomplete="off">--%>

                            </div>
                            <div class="col-md-2">
                            <button class="btn btn-lg" id="search" type="button"  onclick="OperationSearch()">查询</button>
                        </div>
                        <div class="col-md-2"></div>
                    </div>

                    <div class="row" style="margin-top:20px;">
                        <div class="col-md-2"></div>

                        <div class="col-md-5">
                            <input id="sDate" class="dataControl text-center" type="text" data-field="date" data-startend="start" data-format="yyyy-MM-dd" value="2014-05-06" readonly>
                            <input id="eDate" class="dataControl text-center" type="text" data-field="date" data-startend="end" data-format="yyyy-MM-dd" value="2014-06-06" readonly>
                         </div>
                             <div class="col-md-5" style="padding-left:0px;">
                               <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default btnClick" value="01,02" id="hospital">全院</button>
                                <button type="button" class="btn btn-default" value="01" id="hospitalOld">老院区</button>
                                <button type="button" class="btn btn-default" value="02" id="hospitalNew">新院区</button>
                            </div>
                        </div>

                        <%--<div class="col-md-1"></div>--%>

                    </div>


                    <div class="row" style="margin-top:30px;">
                        <div class="col-md-2"></div>
                        <div class="col-md-3">
                            <div class="radio">
                                <label>
                                    <input type="radio" name="searchBaseOn" value="category" checked class="searchBaseOn">
                                    按类别（特类至四类）
                                </label>
                            </div>


                        </div>
                        <div class="col-md-5" id="cb_operationType">
                            <label class="checkbox-inline">
                                <input type="checkbox" value="specialClass" name="operationType" checked="checked" >
                                特类
                            </label>
                            <label class="checkbox-inline">
                                <input type="checkbox" value="fourthClass" name="operationType" checked="checked">
                                四类
                            </label>
                            <label class="checkbox-inline">
                                <input type="checkbox" value="thirdClass" name="operationType" checked="checked">
                                三类
                            </label>
                            <label class="checkbox-inline">
                                <input type="checkbox" value="secondClass" name="operationType" checked="checked">
                                二类
                            </label>
                            <label class="checkbox-inline">
                                <input type="checkbox" value="firstClass" name="operationType" checked="checked">
                                一类
                            </label>


                        </div>
                        <div class="col-md-2"></div>

                    </div>


                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-3">

                            <div class="radio">
                                <label>
                                    <input type="radio" name="searchBaseOn" value="dept" class="searchBaseOn">
                                    按科室
                                </label>
                            </div>


                        </div>
                        <div class="col-md-5">
                            <label class="checkbox-inline">
                                <input type="checkbox" value="" checked="checked" disabled="disabled">
                                按专科下病区
                            </label>
                        </div>
                        <div class="col-md-2"></div>

                    </div>


                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-3">

                            <div class="radio">
                                <label>
                                    <input type="radio" name="searchBaseOn" value="disease" class="searchBaseOn">
                                    按疾病
                                </label>
                            </div>


                        </div>
                        <div class="col-md-5">
                            <label class="checkbox-inline">
                                <input type="checkbox" value="" checked="checked" disabled="disabled">
                                模糊查询，提供手术名称选取
                            </label>
                        </div>
                        <div class="col-md-2"></div>

                    </div>


                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-3">

                            <div class="radio">
                                <label>
                                    <input type="radio" name="searchBaseOn" value="doctor" class="searchBaseOn">
                                    按医生
                                </label>
                            </div>

                        </div>
                        <div class="col-md-5">
                            <label class="checkbox-inline">
                                <input type="checkbox" value="" checked="checked" disabled="disabled">
                                医生工作量
                            </label>
                        </div>
                        <div class="col-md-2"></div>

                    </div>

                </div>
            </div>
        </div>


    </div>
    <input type="hidden" id="hospitalDistrict" value="01,02" />
    <div id="dtBox"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">
</asp:Content>
