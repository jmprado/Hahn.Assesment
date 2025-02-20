import axios from 'axios'
import apiUrls from '../config/api-urls.js'

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL, // Use the environment variable for the base URL
  headers: {
    'Content-Type': 'application/json',
  },
})

export default {
  getAlerts() {
    return apiClient.get(apiUrls.allAlerts)
  },
  getCurrentAlert() {
    return apiClient.get(apiUrls.currentAlert)
  },
  getAlertById(alertId) {
    const url = setAlertId(apiUrls.alertById, alertId)
    return apiClient.get(url)
  },
  getCategories(alertId) {
    const url = setAlertId(apiUrls.categories, alertId)
    return apiClient.get(url)
  },
  getReports(alertId) {
    const url = setAlertId(apiUrls.reports, alertId)
    return apiClient.get(url)
  },
}

const setAlertId = (url, alertId) => url.replace('{alertId}', alertId)
