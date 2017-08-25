const Router = require('koa-router');
const router = new Router({
    prefix: '/api'
});

router.get('/', async (ctx, next) => {
    ctx.body = 'Hello World';
    await next();
});

module.exports = router;