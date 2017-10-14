var merge = require('webpack-merge')
var prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  API_HOST: '"http://scorchapiv2-dev.us-east-1.elasticbeanstalk.com/api"'
})
