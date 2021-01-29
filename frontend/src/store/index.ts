import Vue from 'vue'
import Vuex from 'vuex'

import { GET } from "@/services/apiService";

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        carAdministrators: [],
            {
                tableType: "CarAdministration",
                items: [
                    { name: "Albert", note: "programator" },
                    { name: "Fero", note: "manager" },
                    { name: "Jozo", note: "správca" },
                    { name: "Kevin", note: "manager" },
                    { name: "Patrik", note: "programator" },
                ]
            },
            {
                tableType: "UserAdministration",
                items: [
                    { name: "Albert", note: "programator" },
                    { name: "Fero", note: "manager" },
                    { name: "Jozo", note: "správca" },
                    { name: "Kevin", note: "manager" },
                    { name: "Patrik", note: "programator" },
                ]
            }
        ],
        genericTable1: {
            tableType: "CarAdministration",
            headers: [
                { text: "Spravce", value: "name" },
                { text: "Poznamka", value: "note" },
            ],
            items: [
                { name: "Albert", note: "programator" },
                { name: "Fero", note: "manager" },
                { name: "Jozo", note: "správca" },
                { name: "Kevin", note: "manager" },
                { name: "Patrik", note: "programator" },
            ],
        },
        genericTable2: {
            tableType: "UserAdministration",
            headers: [
                { text: "Spravce", value: "name" },
                { text: "Poznamka", value: "note" },
            ],
            items: [
                { name: "Albert", note: "programator" },
                { name: "Fero", note: "manager" },
                { name: "Jozo", note: "správca" },
                { name: "Kevin", note: "manager" },
                { name: "Patrik", note: "programator" },
            ],
        }
    },
    mutations: {
        ADD_CAR_ADMINISTRATOR(state, { administrator }) {
            const administrators = state.carAdministrators.concat(administrator)
            state.carAdministrators = administrators
        },
        LOAD_CAR_ADMINISTRATORS(state, { administrators }) {
            state.carAdministrators = administrators
        }
    },
    actions: {
        async addCarAdministrator({ commit }, { administrator, filter }) {
            console.log(filter)
            // call server, update administrators,  return administrators
            // const administrators = await POST("administrator", administrator)
            // commit("LOAD_CAR_ADMINISTRATORS", { administrators })
            commit("ADD_CAR_ADMINISTRATOR", { administrator })
        },
        async loadCarAdministratorData({ commit }, { pagination }) {
            const administrators = await GET("CarAdministration", { params: pagination })
            commit("LOAD_CAR_ADMINISTRATORS", { administrators })
        }
    },
    modules: {
    }
})
