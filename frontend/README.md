# bc.multiverse.edu.frontend

> A Vue.js project

## Build Setup

``` bash
# install dependencies
npm install

# serve with hot reload at localhost:8080
npm run dev

# build for production with minification
npm run build

# build for production and view the bundle analyzer report
npm run build --report
```

For a detailed explanation on how things work, check out the [guide](http://vuejs-templates.github.io/webpack/) and [docs for vue-loader](http://vuejs.github.io/vue-loader).

## .net core ajax call  
* Use [qs](https://www.npmjs.com/package/qs) with option **allowDots** sets to **true**  

## Vue routing authentication
* Add **meta: {requiresAuth: true}** to any router that requires authentication
```
{
  path: '/',
  component: _HomeLayout,
  children: [
    ...
    {
      path: 'quick-note',
      name: 'QuickNote',
      component: QuickNote
      meta: { requiresAuth: true }
    }
  ]
}
```
