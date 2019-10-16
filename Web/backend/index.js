var express = require('express')
var app = express()
var router = require('./routers/router')
var routeConfig = require('./routers/route.config');
var bodyParser = require('body-parser')

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: false }));

app.use(router)

console.log(`API Gateway run on localhost:${routeConfig.port}`)

app.listen(routeConfig.port);
