import Vue from 'vue'
import Vuex from 'vuex'

import { GET } from "@/services/apiService";

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        carAdministratorsDataTableModel: undefined,
        genericComponents: [
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
                { textkey: "Name", value: "name" },
                { textkey: "Note", value: "note" },
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
                { textkey: "Name", value: "name" },
                { textkey: "Note", value: "note" },
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
            // const administrators = state.carAdministrators.concat(administrator)
            // state.carAdministrators = administrators
        },
        LOAD_CAR_ADMINISTRATORS(state, { administratorsDataTableModel }) {
            state.carAdministratorsDataTableModel = administratorsDataTableModel
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
            const administratorsDataTableModel = await GET("CarAdministration", { params: pagination })
            commit("LOAD_CAR_ADMINISTRATORS", { administratorsDataTableModel })
        }
    },
    modules: {
    }
})
