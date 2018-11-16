import axios from 'axios'

export default ({ Vue }) => {
  Vue.prototype.$axios = axios.create({ baseURL: "https://localhost:44337"})
}
