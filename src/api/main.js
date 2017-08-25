const koa = require('koa');
const routes = require('./routes');
const serve = require('./serve');
const PORT = process.env.PORT || 3000;

const app = new koa();

app.use(routes.allowedMethods())
    .use(routes.routes())
    .use(serve);

app.listen(PORT);

console.log("App started on port", PORT);