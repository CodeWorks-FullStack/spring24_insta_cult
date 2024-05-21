import { AppState } from "../AppState.js"
import { Cultist } from "../models/Cultist.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultMembersService {
  async getCultistsByCultId(cultId) {
    const res = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('GOT CULTISTS 🧙‍♂️🧙', res.data)
    AppState.cultists = res.data.map(pojo => new Cultist(pojo))
  }
}

export const cultMembersService = new CultMembersService()