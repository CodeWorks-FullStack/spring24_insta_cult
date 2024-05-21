import App from "../App.vue"
import { AppState } from "../AppState.js"
import { Cult } from "../models/Cult.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultsService {
  async destroyCult(cultId) {
    const res = await api.delete(`api/cults/${cultId}`)
    logger.log("DELETE CULT ❌", res.data)
    AppState.activeCult = null
  }
  async getCultById(cultId) {
    AppState.activeCult = null
    const res = await api.get(`api/cults/${cultId}`)
    logger.log('GOT CULT BY ID 💀', res.data)
    AppState.activeCult = new Cult(res.data)
  }
  async getCults() {
    AppState.cults.length = 0 // empties array
    // AppState.cults = []
    const res = await api.get('api/cults')
    logger.log('GOT CULTS 💀💀💀', res.data)
    AppState.cults = res.data.map(pojo => new Cult(pojo))
  }
}

export const cultsService = new CultsService()