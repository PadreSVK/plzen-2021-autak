import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        carAdministrators: [
            { name: "Albert", note: "programator" },
            { name: "Fero", note: "manager" },
            { name: "Jozo", note: "správca" },
            { name: "Kevin", note: "manager" },
            { name: "Patrik", note: "programator" },
        ],
        genericComponents:[
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
        UPDATE_CAR_ADMINISTRATOR(state, { administrators }) {
            state.carAdministrators = administrators
        }
    },
    actions: {
        async addCarAdministrator({ commit }, { administrator, filter }) {
            console.log(filter)
            // call server, update administrators,  return administrators
            // const administrators = await POST("administrator", administrator)
            // commit("UPDATE_CAR_ADMINISTRATOR", { administrators })
            commit("ADD_CAR_ADMINISTRATOR", { administrator })
        },
        async loadCarAdmninistratorData({ commit }, { pagination }) {
            console.log(pagination)
            // call server, update administrators,  return administrators
            // const administrators = await GET("caradministrators", {query: pagination})
            // commit("UPDATE_CAR_ADMINISTRATOR", { administrators })
        }
    },
    modules: {
    }
})
