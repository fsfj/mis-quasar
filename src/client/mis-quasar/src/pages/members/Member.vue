<template>
    <q-page padding>
        <router-view></router-view>
    </q-page>
</template>
<script>
export default {
  name: 'Members',
  data () {
    return {
      members: [],
      columns: [
        {
          name: 'name',
          label: 'Name',
          field: 'name',
          align: 'left'
        }
      ]
    }
  },
  methods: {
    getMembers () {
      this.$axios.get('api/members').then(response => {
        this.members = response.data
      })
    }
  },
  created () {
    this.getMembers()
  }
}
</script>
