const path = require('path');
const serve = require('koa-static');

const clientDir = path.join(__dirname, '../client');

module.exports = serve(clientDir);