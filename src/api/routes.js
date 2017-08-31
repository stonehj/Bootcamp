const Router = require('koa-router');
const data = require('../data.json');
const router = new Router({
    prefix: '/api'
});

router.get('/data.json', async (ctx, next) => {
    ctx.body = data;
    await next();
});

module.exports = router;