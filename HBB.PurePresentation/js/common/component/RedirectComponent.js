/**
 * Created by liu on 2016/4/25.
 */
import React from 'react'

var RedirectComponent = React.createClass({

    getDefaultProps:function () {
      return {
          imgUrl:"../../../img/床位查询.png",
          componentName:"组件名称",
          redirectUrl:"#"
      };
    },
    render:function () {
        return (
            <div className="col-md-6 div_nav redirect-wgt-size wgt-margin-right">
                <div className="row">
                    <div className="col-md-3" style={{"padding": "5px 0px 5px 10px"}}>
                        <div className="row">
                            <div className="col-md-12">
                                <img className="img-responsive" src={this.props.imgUrl} />

                            </div>
                        </div>


                    </div>



                    <div className="col-md-7" style={{"margin": "5px", "padding-top": "10px"}}>
                        <div className="row">
                            <div className="col-md-12">
                                <p className="lead text-nowrap text-center" style={{"margin-bottom": "3px"}}>{this.props.componentName}</p>
                            </div>
                        </div>

                    </div>

                    <div className=" leftGo col-md-2 ">
                        <a href={this.props.redirectUrl}>
                            <img className="img-responsive" src="./img/Home/into.png" />
                        </a>
                    </div>
                </div>
            </div>


        );
    }


});

module.exports=RedirectComponent;

