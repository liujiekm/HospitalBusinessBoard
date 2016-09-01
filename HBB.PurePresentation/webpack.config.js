/**
 * Created by liu on 2016/4/13.
 */
var path = require('path');
var webpack = require('webpack');
var HtmlwebpackPlugin = require('html-webpack-plugin');
var OpenBrowserPlugin = require('open-browser-webpack-plugin');
var ExtracTextPlugin = require('extract-text-webpack-plugin');




// 定义一些文件夹的路径
var ROOT_PATH = path.resolve(__dirname);
var APP_PATH = path.resolve(ROOT_PATH,'js');
var BUILD_PATH = path.resolve(ROOT_PATH,'build');



module.exports = {
    entry: {
        bootstrap: "./lib/bootstrap/js/bootstrap.js",
        jquery: ['jquery'],
        webapp: [
            'webpack-dev-server/client?http://localhost:3000',
            'webpack/hot/only-dev-server',
            './js/webapp.js'
        ]
    },
    output: {
        path:__dirname+'build',   //webpack HMR need absulte path
        filename: '[name].js',
        publicPath:'http://localhost:3000/build/'
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                loaders: ['react-hot','babel-loader?presets[]=es2015&presets[]=react'] //should be loaders not loader important!!
            },
            {
                test: /\.css$/,
                loader: ExtracTextPlugin.extract('style-loader','css-loader')
            },
            {
                test: /\.(png|jpg)$/,
                loader: 'url?limit=40000'
            },
            {
                test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,loader:"url-loader?limit=1000&minetype=application/font-woff"
            },			
            {
                test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/,loader:"file-loader"
            }
        ]


    },
    plugins: [

        new webpack.HotModuleReplacementPlugin(),
        new webpack.NoErrorsPlugin(),

        new ExtracTextPlugin('styles.css'),
        
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery"
        })
    ]
}
