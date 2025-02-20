import axios from 'axios'
import apiUrls from '../config/api-urls.js'

const useApiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL, // Use the environment variable for the base URL
  headers: {
    'Content-Type': 'application/json',
  },
})

export default {
  getAlerts() {
    return useApiClient.get(apiUrls.allAlerts)
  },
  getCurrentAlert() {
    return useApiClient.get(apiUrls.currentAlert)
  },
  getAlertById(alertId) {
    const url = setAlertId(apiUrls.alertById, alertId)
    return useApiClient.get(url)
  },
  getCategories(alertId) {
    const url = setAlertId(apiUrls.categories, alertId)
    return useApiClient.get(url)
  },
  getReports(alertId) {
    const url = setAlertId(apiUrls.reports, alertId)
    return useApiClient.get(url)
  },
}

const setAlertId = (url, alertId) => url.replace('{alertId}', alertId)
