
const state = {
    counter: 1
}

const getters = {

}

const mutations = {
    add(state: any) {
        state.counter++;
    }
}

const actions = {
    count({ commit } : any) {
        commit('add');
    }
}
export default {
    state,
    getters,
    mutations,
    actions,
    namespaced: true
}