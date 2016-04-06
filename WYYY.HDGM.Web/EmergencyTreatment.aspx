<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="EmergencyTreatment.aspx.cs" Inherits="WYYY.HDGM.Web.EmergencyTreatment" %>
<%@ Import Namespace="System.Globalization"  %>
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
    </style>

    <script src="content/js/knockout-3.3.0.js"></script>
    <script type="text/javascript">
        $(function () {

            $('#returnLink').click(function () {

                window.open('Home.aspx','_self');

            });

            $('#home').addClass('active');
            $('#moduleName').text("急诊");

            $.ajax({
                url: "../handler/zhandler.ashx?type=eme",
                success: function (data) {

                    var list = eval("(" + data + ")");
                    console.log(list.qjqxx);
                    ko.applyBindings({
                        qjqxx: list.qjqxx,
                        lgqxx: list.lgqxx
                    });
                }
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
    <div class="col-md-12 personPanel">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation"><a href="#observe" aria-controls="underway" role="tab" data-toggle="tab">急诊留观</a></li>
            <li role="presentation" class="active"><a href="#rescue" aria-controls="waiting" role="tab" data-toggle="tab">抢救区</a></li>
        </ul>
        <style type="text/css">
                .myContent {
                    background: white;
                    border: 1px solid #ddd;
                    height:600px;
                }
                                
                .myclass {
                    overflow-y:scroll;
                    height: 557px;
                }
        </style>
        <div class="tab-content myContent">
            <div role="tabpanel" class="tab-pane active" id="rescue">
                <table class="table text-center">
                    <thead>
                        <tr>
                            <td style="width: 10%;">姓名</td>
                            <td style="width: 5%;">性别</td>
                            <td style="width: 5%;">年龄</td>
                            <td style="width: 40%;">临床诊断</td>
                            <td style="width: 20%;">留观天数</td>
                            <td style="width: 20%;">预存余额</td>
                        </tr>
                    </thead>                                    
                </table>
                <div class="myclass">
                    <table class="table table-hover text-center">
                        <tbody data-bind="foreach: qjqxx">
                            <tr>
                                <td style="width: 10%;" data-bind="text: XM"></td>
                                <td style="width: 5%;" data-bind="text: XB"></td>
                                <td style="width: 5%;" data-bind="text: NL"></td>
                                <td style="width: 40%;" data-bind="text: LCZD"></td>
                                <td style="width: 20%;" data-bind="text: LGTS"></td>
                                <td style="width: 20%;" data-bind="text: YCYE"></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="observe">
                <table class="table text-center">
                    <thead>
                        <tr>
                            <td style="width: 10%;">姓名</td>
                            <td style="width: 5%;">性别</td>
                            <td style="width: 5%;">年龄</td>
                            <td style="width: 40%;">临床诊断</td>
                            <td style="width: 20%;">留观天数</td>
                            <td style="width: 20%;">预存余额</td>
                        </tr>
                    </thead>
                </table>
                <div class="myclass">
                    <table class="table table-hover text-center">
                        <tbody data-bind="foreach: lgqxx">
                            <tr>
                                <td style="width: 10%;" data-bind="text: XM"></td>
                                <td style="width: 5%;" data-bind="text: XB"></td>
                                <td style="width: 5%;" data-bind="text: NL"></td>
                                <td style="width: 40%;" data-bind="text: LCZD"></td>
                                <td style="width: 20%;" data-bind="text: LGTS"></td>
                                <td style="width: 20%;" data-bind="text: YCYE"></td>
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
