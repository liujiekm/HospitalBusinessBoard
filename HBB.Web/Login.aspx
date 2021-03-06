﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HBB.Web.Login" %>

<!DOCTYPE html>
<html lang="zh-CN">

<head runat="server">
    <!--Bootstrap 不支持 IE 古老的兼容模式。为了让 IE 浏览器运行最新的渲染模式下,加入如下内容-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--让部分国产浏览器默认采用高速模式渲染页面-->
    <meta name="renderer" content="webkit" />
    <!--Bootstrap3 是移动设备优先的为了确保适当的绘制和触屏缩放，增加如下内容-->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>院长综合查询系统</title>


    <!--Bootstrap css-->
    <link href="content/bootstrap/bootstrap.min.css" rel="stylesheet">

    <style type="text/css">
        body {
            font-family: 微软雅黑;
            background: url('/content/img/newHome/BG.png') no-repeat;
            background-color: #49AECF;
        }
        .loginContainer {
            position: fixed;
            left: 38%;
            height: 100%;
            width: 25%;
            background: url('/content/img/login/BlueBG.png');
        }

        .logoImg {
            position: relative;
            left: 32%;
        }

        .login-footer {
            margin-top: 45px;
        }

        .info-links {
            font-size: 11px;
            margin-top: 5px;
            color: rgba(151, 152, 152, 0.7);
        }

        .formControl {
            height: 53px;
            border: 1px solid white;
            width: 72%;
        }

        .loginIcon {
            /*margin-top: -1px;*/
        }
        .login-form {
            position: relative;
            color: white;
            top: 15%;
        }
        .form-group {
            background: white;
            color: black;
            font-size: 25px;
        }

        input:focus {
            /*border: 1px solid white; 13818866603 */
        }

        .loginBtn {
            width: 90%;
            text-align: center;
            position: relative;
            left: 5%;
            height: 50px;
            background:   url('/content/img/login/BlueBG.png');
            border: 1px solid white;
            border-radius: 0px;
            color: white;
        }
        .loginBtn:focus,
        .loginBtn:hover {
            background:   white;
            color: #49aecf;
        }


        .formGroup {
            margin-left: -15px;
            margin-right: -15px;
            margin-bottom: 15px;
            background-color: white;
        }
        .formGroupBtn {
            margin-left: -15px;
            margin-right: -15px;
            margin-bottom: 15px;
        }
    </style>
</head>
    

<body>
    <!--Bootstrap js-->
    <script src="content/js/jquery/jquery-2.1.3.min.js"></script>
    <script src="content/bootstrap/bootstrap.js"></script>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
            </div>


            <div class="col-md-4 loginContainer">


                <div class="errors-container"></div>

                <form id="form1" runat="server" class="login-form form-horizontal">
                    <div class="login-header">

                        <img src="content/img/login/logo.png" class='logoImg' />

                        <p class="lead text-center" style="margin-top: 10px;">医院业务看板</p>
                    </div>
                    <div class="formGroup">
                        <img class="loginIcon" src="content/img/login/LoginNmae_icon.png"/>
                        <input type="text" class="formControl" id="account" name="username" autocomplete="off" runat="server" />
                    </div>
                    <div class="formGroup">
                        <img class="loginIcon" src="content/img/login/LoginPsw_icon.png"/>
                        <input type="password" class="formControl" id="pwd" name="password" autocomplete="off" runat="server" />
                    </div>
                    <div class="formGroupBtn btnBG">
                        <button type="submit" id="SignIn" class="btn loginBtn" runat="server" onserverclick="SignIn_Click">
                            登录
                        </button>
                    </div>
                    <div class="login-footer">
                        <a href="#">忘记密码？</a>

                        

                    </div>

                </form>



            </div>

            <div class="col-md-4"></div>


        </div>
    </div>


</body>
</html>
