const controller = '/alerts'

const apiUrls = {
  alertById: `${controller}/{alertId}/alert`,
  allAlerts: `${controller}/alerts`,
  currentAlert: `${controller}/current`,
  categories: `${controller}/{alertId}/categories`,
  reports: `${controller}/{alertId}/reports`,
}

export default apiUrls
