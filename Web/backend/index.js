var express = require('express')
var app = express()
var router = require('./routers/router')
var routeConfig = require('./routers/route.config');
var bodyParser = require('body-parser')

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "http://localhost:4200");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: false }));

app.use(router)

console.log(`API Gateway run on localhost:${routeConfig.port}`)

app.listen(routeConfig.port);
