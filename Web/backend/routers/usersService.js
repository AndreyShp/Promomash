const express = require('express');
const router = express.Router()
const routeConfig = require('./route.config')
const apiAdapter = require('./apiAdapter')

const api = apiAdapter(routeConfig.users)

router.post('/api/users/add', (req, res) => {
  var regionId = req.body.regionId;
  var url = `${routeConfig.main}/api/regions/?ids=${regionId}&types=2`;

  api.get(url)
    //проверить существует ли регион
    .then(regionResult => {
      var regions = regionResult.data;
      if (!Array.isArray(regions) || regions.length <= 0) {
        throw new Error('Invalid region!');
      }
    })
    //регион существует - сохранить пользователя
    .then(() => {
      return api.post(req.url, req.body).then(resp => {
        res.send(resp.data)
      }).catch((error) => {
        var msg = error.response ? error.response.data : error.message
        throw new Error(`Invalid user! ${msg}`)
      });
    })
    .catch((error) => {
      res.status(500).json({ error: `${error}!` })
    });
})

module.exports = router