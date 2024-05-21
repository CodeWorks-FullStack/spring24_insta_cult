import { AppState } from "../AppState.js"
import { Cultist } from "../models/Cultist.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultMembersService {
  async createCultMember(cultId) {
    const cultMemberData = { cultId: cultId }
    const res = await api.post('api/cultMembers', cultMemberData)
    logger.log('CREATED CULT MEMBER ✨🧙', res.data)
    AppState.cultists.push(new Cultist(res.data))
  }
  async getCultistsByCultId(cultId) {
    AppState.cultists.length = 0 // empties array
    const res = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('GOT CULTISTS 🧙‍♂️🧙', res.data)
    AppState.cultists = res.data.map(pojo => new Cultist(pojo))
  }
}

export const cultMembersService = new CultMembersService()