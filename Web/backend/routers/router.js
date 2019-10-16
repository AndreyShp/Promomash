const express = require('express');
const router = express.Router()
const regionsRouter = require('./regionsService')
const usersRouter = require('./usersService')

router.use((req, res, next) => {
    console.log("Called: ", req.url)
    next()
})

router.use(regionsRouter)
router.use(usersRouter)

module.exports = router