import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultsService {
  async getCults() {
    const res = await api.get('api/cults')
    logger.log('GOT CULTS 💀💀💀', res.data)
  }
}

export const cultsService = new CultsService()