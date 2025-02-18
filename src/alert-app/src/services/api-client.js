import axios from 'axios';

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL, // Use the environment variable for the base URL
  headers: {
    'Content-Type': 'application/json',
  },
});

export default {
  getCurrentAlert() {
    const url = "/alert/current-alert";
    return apiClient.get(url);
  },
  getCategories(alertId) {
    const url = `/alert/${alertId}/categories`;
    return apiClient.get(url);
  },
  getReports(alertId) {
    const url = `/alert/${alertId}/reports`;
    return apiClient.get(url);
  },  
};