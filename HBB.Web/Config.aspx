<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="HBB.Web.Config" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="content/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_reportContent" runat="server">
        <fieldset>

            <legend>用户体验数据设置</legend>

        <div class="form-horizontal col-md-4 col-sm-4 col-xs-4" style=" left: 5%;">
                    <div class="form-group">

                        <%--<div class="input-group">
                                <div class="input-group-addon">签到率</div>
                                <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="checkin_rate" placeholder="医生签到率" 
                                        />
                                <div class="input-group-addon">%</div>


                        </div>

                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-group-addon">候诊人数</div>

                            <input data-inputmask="'mask':'999999'" type="text" class="form-control"  id="waiting_num" placeholder="候诊人数"
                                              />
                            <div class="input-group-addon">人</div>
                            </div>

                    </div>--%>

                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">门诊预约时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="outpatient_app_time" placeholder="门诊预约时长"
                                     onkeyup="javascript:CheckInputIntFloat(this);"        />
                            <div class="input-group-addon">天</div>
                        </div>

                    </div>

                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">门诊候诊时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="outpatient_waiting_time" placeholder="门诊候诊时长"
                                        onkeyup="javascript:CheckInputIntFloat(this);"       />
                            <div class="input-group-addon">分钟</div>
                        </div>

                    </div>

                    <div class="form-group">


                        <div class="input-group">
                            <div class="input-group-addon">门诊就诊时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="outpatient_in_time" placeholder="门诊就诊时长"
                                        onkeyup="javascript:CheckInputIntFloat(this);"      />
                            <div class="input-group-addon">分钟</div>
                        </div>

                    </div>
                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">门诊缴费时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="outpatient_pay_time" placeholder="门诊缴费时长"
                                      onkeyup="javascript:CheckInputIntFloat(this);"         />
                            <div class="input-group-addon">分钟</div>
                        </div>

                    </div>
                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">门诊取药时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="outpatient_med_time" placeholder="门诊取药时长"
                                      onkeyup="javascript:CheckInputIntFloat(this);"      />
                            <div class="input-group-addon">分钟</div>
                        </div>

                    </div>

                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">X光预约时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="check_x_time" placeholder="X光预约时长"
                                        onkeyup="javascript:CheckInputIntFloat(this);"     />
                            <div class="input-group-addon">天</div>
                        </div>

                    </div>
                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">CT预约时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="check_ct_time" placeholder="CT预约时长"
                                      onkeyup="javascript:CheckInputIntFloat(this);"      />
                            <div class="input-group-addon">天</div>
                        </div>

                    </div>
                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">MRI预约时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control" id="check_mri_time" placeholder="MRI预约时长"
                                     onkeyup="javascript:CheckInputIntFloat(this);"      />
                            <div class="input-group-addon">天</div>
                        </div>

                    </div>
                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">B超预约时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="check_b_time" placeholder="B超预约时长"
                                  onkeyup="javascript:CheckInputIntFloat(this);"         />
                            <div class="input-group-addon">天</div>
                        </div>

                    </div>

                    <div class="form-group">

                        <div class="input-group">
                            <div class="input-group-addon">内窥镜预约时长</div>
                            <input data-inputmask="'mask':'99.9'" type="text" class="form-control"  id="checkout_endoscope_time" placeholder="内窥镜预约时长"
                                 onkeyup="javascript:CheckInputIntFloat(this);"          />
                            <div class="input-group-addon">天</div>
                        </div>

                    </div>


                    


                    <div class="form-group">

                        <button class="btn btn-primary btn-lg" id="btn_config" style=" width: 100%;">提交</button>
                    </div>


                </div>


    </div>

       </fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_reportJsContent" runat="server">

    <script type="text/javascript">



        function CheckInputIntFloat(oInput) {
            if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
            }
        }


        $(document).ready(function () {
            //$("#outpatient_app_time,#outpatient_waiting_time,#outpatient_in_time,#outpatient_pay_time,#outpatient_med_time,#check_x_time,#check_ct_time,#check_mri_time,#check_b_time,#checkout_endoscope_time").inputmask("99.9");


            $.getJSON(baseUrl + 'CFG/GC', function (config) {

                $("#outpatient_app_time").val(config.outpatientAppTime);
                $("#outpatient_waiting_time").val(config.outpatientWaitingTime);
                $("#outpatient_in_time").val(config.outpatientInTime);
                $("#outpatient_pay_time").val(config.outpatientPayTime);
                $("#outpatient_med_time").val(config.outpatientMedTime);
                $("#check_x_time").val(config.checkXTime);
                $("#check_ct_time").val(config.checkCTTime);
                $("#check_mri_time").val(config.checkMRITime);
                $("#check_b_time").val(config.checkBTime);
                $("#checkout_endoscope_time").val(config.checkoutEndoscopeTime);

            });


            $("#btn_config").click(function (event) {
                event.preventDefault();
                event.stopPropagation();


                


                var postData = {
                    'checkinRate': 0,
                    'waitingNum': 0,
                    'outpatientAppTime': parseFloat($("#outpatient_app_time").val()),
                    'outpatientWaitingTime': parseFloat($("#outpatient_waiting_time").val()),
                    'outpatientInTime': parseFloat($("#outpatient_in_time").val()),
                    'outpatientPayTime': parseFloat($("#outpatient_pay_time").val()),
                    'outpatientMedTime': parseFloat($("#outpatient_med_time").val()),
                    'checkXTime': parseFloat($("#check_x_time").val()),
                    'checkCTTime': parseFloat($("#check_ct_time").val()),
                    'checkMRITime': parseFloat($("#check_mri_time").val()),
                    'checkBTime': parseFloat($("#check_b_time").val()),
                    'checkoutEndoscopeTime': parseFloat($("#checkout_endoscope_time").val())
                };



                $.ajax({
                    url: baseUrl + 'CFG/MC',
                    dataType: "json",   //返回格式为json
                    async: true, //请求是否异步，默认为异步，这也是ajax重要特性
                    data: JSON.stringify(postData),    //参数值
                    contentType: 'application/json',
                    type: "POST",   //请求方式
                    beforeSend: function () {
                        //请求前的处理
                    },
                    success: function (req) {
                        alert("设置成功!");

                        
                    },
                    complete: function () {
                        window.open('Home.aspx', '_self');
                    },
                    error: function () {
                        alert("设置失败!");
                    }
                });

                

            });



            
        });



    </script>
</asp:Content>
