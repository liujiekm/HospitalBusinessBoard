<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Operation.aspx.cs" Inherits="WYYY.HDGM.Web.Operation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .personPanel {
            padding-top: 20px;
        }

            .personPanel > ul > li {
                float: right;
            }

                .personPanel > ul > li > a {
                    margin-right: 0px;
                    border-radius: 0px;
                }

                    .personPanel > ul > li > a:hover,
                    .personPanel > ul > li > a:focus {
                        background: #F7F7F7;
                    }

                .personPanel > ul > li > a {
                    color: black;
                }

            .personPanel > ul {
                border-bottom: 0px;
            }

        .personContent {
            background: white;
            /*height:600px;*/
            border-left: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
            border-right: 1px solid #ddd;
            /*overflow-y: scroll;*/
        }

        .tabContent {
            height: 85%;
            overflow-y: auto;
        }

        .table {
            margin-bottom: 5px;
        }

        @media only screen and (min-width: 1024px) {


            .personContent {
                height: 457px;
            }
        }

        @media only screen and (min-width: 1280px) {


            .personContent {
                height: 600px;
            }
        }

        @media only screen and (min-width: 1440px) {


            .personContent {
                height: 600px;
            }
        }
        .table_overflow {
            height: 550px;
            overflow: auto;
        }
    </style>

    <script src="content/js/knockout-3.3.0.js"></script>

    <script type="text/javascript">
        //完成情况
        var oprationState = "done";//underway waiting done

        //查询类型，院区，查询内容，开始时间，结束时间
        var searchType = "";
        var hospitalValue = "";
        var searchContent = "";
        var searchContentName = "";
        var sDate = "";
        var eDate = "";
        //手术类型
        var operationType = "";


        $(function() {
            function GetQueryString(name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
                var r = window.location.search.substr(1).match(reg);
                //if (r != null) return unescape(r[2]);
                if (r != null) return r[2];
                return null;
            };

            //window.location.href = "Operation.aspx?searchType=category&area=" + hospitalValue + "&operationType=" + operationType + "&sDate=" + sDate + "&eDate=" + eDate + "&content=" + searchContent;
            //查询类型，院区，查询内容，开始时间，结束时间
            searchType = GetQueryString("searchType");
            hospitalValue = GetQueryString("area");
            searchContent = GetQueryString("content");
            searchContentName = GetQueryString("searchContentName");
            sDate = GetQueryString("sDate");
            eDate = GetQueryString("eDate");
            //手术类型
            operationType = GetQueryString("operationType");
            //按照科室和医生来查询时要传它们的ID
            if (searchType == "dept") { searchContent = searchContentName;}
            if (searchType == "doctor") { searchContent = searchContentName; }

        });
    </script>
    <script type="text/javascript">
        $(function () {

            $('#returnLink').click(function () {

                window.open('OperationMain.aspx', '_self');

            });
            $('#moduleName').text("手术");
            $('#home').addClass('active');
        });

        function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
            try {//出自http://www.cnblogs.com/ahjesus 尊重作者辛苦劳动成果,转载请注明出处,谢谢!
                var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
                var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var seconds = date.getSeconds();
                var milliseconds = date.getMilliseconds();
                return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds;
                //return date.getFullYear() + "-" + month + "-" + day;
            } catch (ex) {//出自http://www.cnblogs.com/ahjesus 尊重作者辛苦劳动成果,转载请注明出处,谢谢!
                return "";
            }
        }
    </script>

    <script>
        $(document).ready(function () {
     
            var OperationViewModel = function () {
                var self = this;
                //变量区
                //签到人数按时间点统计列表
                self.Operation = ko.observableArray();
                $(function () {
                    self.GetOperation();
                });
                //方法区
                //1、获取手术信息
                self.GetOperation = function () {
                    //手术类型
                    //var operationType = "";
                    for (var j = 0; j < 3; j++) {
                        if (j == 0) { oprationState = "waiting"; } //underway waiting done}
                        else if (j == 1) { oprationState = "underway"; }
                        else if (j == 2) { oprationState = "done"; }
                        $.ajax({
                            type: "get",
                            contentType: "text/json",
                            dataType: "json",
                            async: false,
                            //url: '../Handler/HomeHandler.ashx?type=ordi',
                            url: "../Handler/OperationHandler.ashx?type=ordi&oprationState=" + oprationState + "&searchType=" + searchType + "&area=" + hospitalValue + "&operationType=" + operationType + "&sDate=" + sDate + "&eDate=" + eDate + "&content=" + searchContent,
                            success: function (data) {
                                var json = eval(data);
                                var tableStr = "";
                                if (json != null) {
                                    for (var i = 0, l = json.length; i < l; i++) {
                                        if (j == 0) { $("#tb_signIned1").empty(); } //underway waiting done}
                                        else if (j == 1) { $("#tb_signIned2").empty(); }
                                        else if (j == 2) { $("#tb_signIned3").empty(); }
                                        for (var i = 0, l = json.length; i < l; i++) {
                                            tableStr += "<tr><td width='150px'>" + json[i].SurgeryCode + "</td><td width='150px'>第" + parseInt(json[i].OperatingRoomCode) + "手术室</td><td width='150px'>" + json[i].PateintName + "</td><td width='250px'>" + jsonDateFormat(json[i].SurgeryStartTime) + "</td><td width='250px'>" + json[i].SurgeryName + "</td><td width='150px'>" + json[i].SurgeonDoctor + "</td></tr>";
                                        }
                                        if (j == 0) { $("#tb_signIned1").append(tableStr); } //underway waiting done}
                                        else if (j == 1) { $("#tb_signIned2").append(tableStr); }
                                        else if (j == 2) { $("#tb_signIned3").append(tableStr); }
                                    }
                                }
                            },
                            error: function () {
                                //alert("获取失败！");
                            }
                        });
                    }  

                }
            }
            ko.applyBindings(new OperationViewModel);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
    <div class="col-md-12 personPanel">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation"><a href="#waiting" aria-controls="waiting" role="tab" data-toggle="tab">等待中</a></li>
            <li role="presentation"><a href="#underway" aria-controls="underway" role="tab" data-toggle="tab">进行中</a></li>
            <li role="presentation" class="active"><a href="#done" aria-controls="done" role="tab" data-toggle="tab">已完成</a></li>
        </ul>
        <div class="tab-content personContent">
            <div role="tabpanel" class="tab-pane" id="waiting" >
                <table class="table text-center">
                    <thead>
                        <tr>
                            <td width="150px">手术代码</td>
                            <td width="150px">手术室</td>
                            <td width="150px">患者姓名</td>
                            <td width="250px">手术时间</td>
                            <td width="250px">手术名称</td>
                            <td width="150px">主刀医生</td>
                        </tr>
                        </tr>
                    </thead>
                </table>
                <div class="tabContent table_overflow"  >
                    <table class="table table-hover text-center" >
                        <tbody id="tb_signIned2">
                            <tr>
                                <td>暂无数据</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="underway">
                <table class="table table-hover text-center" >
                    <thead>
                        <tr>
                            <td width="150px">手术代码</td>
                            <td width="150px">手术室</td>
                            <td width="150px">患者姓名</td>
                            <td width="250px">手术时间</td>
                            <td width="250px">手术名称</td>
                            <td width="150px">主刀医生</td>
                        </tr>
                        </tr>
                    </thead>
                </table>
                <div class="tabContent table_overflow" >
                    <table class="table table-hover text-center">
                        <tbody id="tb_signIned1">
                            <tr>
                               <td>暂无数据</td>
                            </tr>
                        </tbody>

                    </table>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane active" id="done">
                <table class="table table-hover text-center">
                    <thead>
                        <tr>
                            <td width="150px">手术代码</td>
                            <td width="150px">手术室</td>
                            <td width="150px">患者姓名</td>
                            <td width="250px">手术时间</td>
                            <td width="250px">手术名称</td>
                            <td width="150px">主刀医生</td>
                        </tr>
                    </thead>
                </table>
                <div class="tabContent table_overflow" >
                    <table class="table table-hover text-center">
                        <tbody id="tb_signIned3">
                            <tr>
                                <td>暂无数据</td>
                            </tr>
                        </tbody>

                    </table>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">
</asp:Content>