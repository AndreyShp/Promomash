const express = require('express');
const router = express.Router()
const routeConfig = require('./route.config')
const apiAdapter = require('./apiAdapter')

const api = apiAdapter(routeConfig.regions)

router.get('/api/regions[/?]?', (req, res) => {
  api.get(req.url).then(resp => {
    if (resp == null || resp.data == null) {
      res.status(500).json({ error: `Error` })
      return;
    }
    res.send(resp.data)
  });
})

module.exports = router