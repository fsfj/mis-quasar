<template>
    <q-page padding>
        <div class="row">
            <div class="col-xs-12 col-sm-6 col-md-4 q-pa-xs">
                <q-input v-model="member.firstname" float-label="Firstname"/>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 q-pa-xs">
                <q-input v-model="member.middlename" float-label="Middlename"/>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 q-pa-xs">
                <q-input v-model="member.lastname" float-label="Lastname"/>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 q-pa-xs">
                <q-input v-model="member.address" float-label="Address" type="textarea" :max-height="100" rows="5"/>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 q-pa-xs">
                <q-datetime v-model="member.dateOfBirth" type="date" float-label="Date of Birth"/>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 q-pa-xs">
                <q-input v-model="member.contactNumber" float-label="Contact Number"/>
            </div>
        </div>
        <div class="q-pa-sm"></div>
        <div class="row">
            <q-btn color="primary" @click="save">Save</q-btn>
        </div>
    </q-page>
</template>
<script>
export default {
  data () {
    return {
      member: {}
    }
  },
  methods: {
    save () {
      this.$axios.post('api/members', this.member)
        .then(response => {
          this.$q.notify(
            {
              message: 'Successfully saved!',
              type: 'positive'
            })
        })
        .catch(error => this.$q.notify(error))
    }
  }
}
</script>
