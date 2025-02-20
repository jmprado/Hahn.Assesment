const controller = '/alert'

const apiUrls = {
  alertById: `${controller}/{alertId}`,
  allAlerts: `${controller}/alerts`,
  currentAlert: `${controller}/current-alert`,
  categories: `${controller}/{alertId}/categories`,
  reports: `${controller}/{alertId}/reports`,
}

export default apiUrls
