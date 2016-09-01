// var express = require('express');
// var app = express();


// var webpack = require('webpack');

// var WebpackDevServer = require('webpack-dev-server');

// var webpackDevMiddleware = require('webpack-dev-middleware');
// var webpackHotMiddleware = require('webpack-hot-middleware');
// var config = require('./webpack.config');


// app.use(express.static(__dirname));


// app.get('/',function(req,res) {
//     res.sendFile(__dirname+'/index.html');
// });

// app.listen(3000,function() {
//     console.log('server is on port 3000');
// });


var webpack = require('webpack');
var WebpackDevServer = require('webpack-dev-server');
var config = require('./webpack.config');


new WebpackDevServer(webpack(config), {
  publicPath: config.output.publicPath,
  hot: true,
  noInfo: false,
  historyApiFallback: true
}).listen(3000, 'localhost', function (err, result) {
  if (err) {
    console.log(err);
  }
  console.log('Listening at localhost:3000');
});



