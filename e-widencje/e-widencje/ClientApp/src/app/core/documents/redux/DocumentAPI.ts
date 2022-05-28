import axios from 'axios'
import { ExciseEvidence } from "../models/ExciseEvidence"

let API_URL = process.env.REACT_APP_API_URL || 'api'

export const GET_SEARCH_DOCUMENT = `${API_URL}/document/search`
export const GET_DOCUMENT = `${API_URL}/document`
export const UPDATE_DOCUMENT = `${API_URL}/document`
export const ADD_DOCUMENT = `${API_URL}/document/add`

export async function search(term: string) {
    if (term == null) {
        term = "";
    }
    return await axios.get(`${GET_SEARCH_DOCUMENT}?term=${term}`)
}
export async function get(id: string) {
    return await axios.get(`${GET_DOCUMENT}/${id}`)
}
export async function update(model: ExciseEvidence) {
    return await axios.put(`${UPDATE_DOCUMENT}/${model.id}`, model)
}
export async function add(model: ExciseEvidence) {
    return await axios.post(`${ADD_DOCUMENT}`, model)
}