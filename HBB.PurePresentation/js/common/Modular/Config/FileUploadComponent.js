/**
 * Created by liu on 2016/4/22.
 */
import React from 'react';
import { render, findDOMNode } from 'react-dom'

import FileProcessor from 'react-file-processor';



var FileUploadComponenet = React.createClass({
    getDefaultProps:function () {
      return {

          baseUrl:"http://localhost:5831/"
      }
    },


    handleClick(e) {
        this.refs.myFileInput.chooseFile();
    },
    handleFileSelect(e, files) {
        console.log(e, files);
        //上传图片logo到服务器
        var ajaxRequest = $.ajax({
            type: "POST",
            url: this.props.baseUrl+"CFG/UL",
            contentType: false,
            processData: false,
            data: files
        });

        ajaxRequest.done(function (xhr, textStatus) {
            alert("设置成功");
        });



    },
    render:function (){

        var self = this;
        return (

            <FileProcessor
                ref="myFileInput"
                onFileSelect={self.handleFileSelect.bind(self)}>
                <button onClick={self.handleClick.bind(self.handleClick)}>
                    上传医院Logo
                </button>
            </FileProcessor>
        );
    }



});

module.exports=FileUploadComponenet;



