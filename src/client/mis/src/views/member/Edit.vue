<template>
    <div>
         <div class="columns">
            <div class="column is-4">
                <label class="label is-small">Lastname</label>
                <input class="input is-small" type="text" v-model="member.lastName" placeholder="Lastname">
            </div>
            <div class="column is-4">
                <div class="field">
                    <label class="label is-small">Firstname</label>
                    <div class="control">
                        <input class="input is-small" type="text" v-model="member.firstName" placeholder="Firstname">
                    </div>
                </div>
            </div>
            <div class="column is-4">
                <div class="field">
                    <label class="label is-small">Middlename</label>
                    <div class="control">
                        <input class="input is-small" type="text" v-model="member.middleName" placeholder="Middlename">
                    </div>
                </div>
            </div>
        </div>
        <div class="columns">
             <div class="column is-4">
                <div class="field">
                    <label class="label is-small">Birth Date</label>
                    <div class="control">
                        <input class="input is-small" type="date" v-model="member.dateOfBirth" placeholder="Firstname">
                    </div>
                </div>
            </div>
             <div class="column is-4">
                <div class="field">
                    <label class="label is-small">Address</label>
                    <div class="control">
                        <input class="input is-small" type="text" v-model="member.address" placeholder="Address">
                    </div>
                </div>
            </div>
             <div class="column is-4">
                <div class="field">
                    <label class="label is-small">Contact #</label>
                    <div class="control">
                        <input class="input is-small" type="text" v-model="member.contactNumber" placeholder="Contact Number">
                    </div>
                </div>
            </div>
        </div>
        <div class="columns">
             <div class="column">
                <div class="field">
                    <label class="label is-small">Kapisanan</label>
                    <div class="control">
                        <div class="select is-small">
                            <select>
                                <option>Kids</option>
                                <option>Youth</option>
                                <option>YMC</option>
                                <option>Kalalakihan</option>
                                <option>Kababaihan</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
             <div class="column">
                <div class="field">
                    <label class="label is-small">Occupation</label>
                    <div class="control">
                        <input class="input is-small" type="text" v-model="member.address" placeholder="Occupation">
                    </div>
                </div>
            </div>
            <div class="column">
                <div class="field">
                    <label class="label is-small">Is Baptized?</label>
                    <!-- <div class="control">
                        <input class="input is-small" type="text" v-model="member.contactNumber" placeholder="Contact Number">
                    </div> -->
                     <div class="block">
                        <b-radio v-model="member.isBaptized"
                            native-value="true"
                            size="is-small">
                            Yes
                        </b-radio>
                        <b-radio v-model="member.isBaptized"
                            native-value="false"
                            size="is-small">
                            No
                        </b-radio>
                    </div>
                </div>
            </div>
            <div class="column">
                <div class="field">
                    <label class="label is-small">Spiritual Birth Date</label>
                    <div class="control">
                        <input class="input is-small" type="date" v-model="member.spiritualBirthDate" >
                    </div>
                </div>
            </div>
        </div>
        <div class="field is-grouped">
            <div class="control">
                <button class="button is-success" @click="save" :class="isSaving">Save</button>
            </div>
            <div class="control">
                <button class="button" @click="$router.push('/members')">Back to List</button>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data () {
        return {
            member: {}
        }
    },
    methods: {
        update () {
            this.$axios.put("api/members", this.member)
                .then(response => {
                    this.$router.push("/members")
                })
                .catch(error => console.log(error));
        }
    }
}
</script>

