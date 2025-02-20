import { createMemoryHistory, createRouter } from 'vue-router';

import HomeView from '../views/home-page.vue';
import AllAlerts from '../views/all-alerts.vue';

const routes = [
  {
    path: '/',
    name: 'HomeRoute',
    component: HomeView
},
{
    path: '/all-alerts',
    name: 'AllAlerts',
    component: AllAlerts
}
];

export const router = createRouter({
  history: createMemoryHistory(),
  routes,
});
