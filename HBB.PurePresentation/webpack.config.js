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
        ],
        shared:['react','react-router','echarts','antd']
    },
    output: {
        path:__dirname+'/build',   //webpack HMR need absulte path
        filename: '[name].js',
        chunkFilename: '[name].chunk.js',
        publicPath:'http://localhost:3000/build/'
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                loaders: ['react-hot','babel-loader?presets[]=es2015&presets[]=react'] //should be loaders not loader important!!
            },
            //AdmissionDischarge
            {
                test: /\.js$/,
                exclude: /node_modules/,
                include: [path.resolve(__dirname, 'js/common/Modular/AdmissionDischarge')],
                loaders: ['bundle?lazy&name=AdmissionDischarge','babel-loader?presets[]=es2015&presets[]=react']
            },
            //Home
            {
                test: /\.js$/,
                exclude: /node_modules/,
                include: [path.resolve(__dirname, 'js/common/Modular/Home')],
                loaders: ['bundle?lazy&name=Home','babel-loader?presets[]=es2015&presets[]=react']
            },
            //Emergency
            {
                test: /\.js$/,
                exclude: /node_modules/,
                include: [path.resolve(__dirname, 'js/common/Modular/Emergency')],
                loaders: ['bundle?lazy&name=Emergency','babel-loader?presets[]=es2015&presets[]=react']
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
        new webpack.optimize.CommonsChunkPlugin('shared','shared.js'),
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NoErrorsPlugin(),

        new ExtracTextPlugin('styles.css'),
        
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery"
        }),
        new webpack.DefinePlugin({
            'process.env.NODE_ENV': JSON.stringify(process.env.NODE_ENV || 'development')
        })
    ]
}
