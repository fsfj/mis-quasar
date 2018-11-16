<template>
    <q-layout>
        <q-page-container>
            <q-page class="flex flex-center">
                <q-card class="login-card">
                    <q-card-title>
                        <q-icon name="lock" size="2em" color="primary" />
                    </q-card-title>
                    <q-card-separator />
                    <q-card-main>
                        <q-input float-label="Username" v-model="user.username"/>
                        <div class="q-pa-xs"></div>
                        <q-input float-label="Password" type="password" v-model="user.password"/>
                        <div class="q-pa-xs"></div>
                        <q-toggle v-model="user.rememberMe" label="Remember Me" />
                        <div class="q-pa-xs"></div>
                        <q-btn color="primary" @click="login">Login</q-btn>
                        <div class="q-pa-xs"></div>
                    </q-card-main>
                </q-card>
            </q-page>
        </q-page-container>
    </q-layout>
</template>
<script>
export default {
    data () {
        return {
            user: {},
            username: '',
            password: '',
            rememberMe: false
        }
    },
    methods: {
        login () {
            this.$axios.post('/api/Users/authenticate', this.user)
                .then(response => {
                    if(response.data.hasError){
                       return this.$q.notify(
                        {
                            message: response.data.message
                        })
                    }

                    if(response.data.token){
                        localStorage.setItem('user', JSON.stringify(response.data));
                        this.$router.push('/members');
                    }
                })
                .catch(error => console.log(error));
        }
    }
}
</script>
<style>
.login-card {
    width: 500px;
}
</style>


