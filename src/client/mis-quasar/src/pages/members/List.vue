<template>
    <q-page padding>
        <q-btn color="primary" :to="{ path: '/members/create' }">New Member <q-icon name="add" /></q-btn>
        <div class="q-pa-sm"></div>
        <q-table
          title="List of Members"
          :data="members"
          :columns="columns"
          row-key="name"
        />
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
