<template>
    <div class="container">
        <nav class="navbar" style="border-bottom: 2px solid #E6E9ED">
            <div class="navbar-brand">
                <a class="navbar-item" :to="{ name: 'home' }">
                    MIS
                </a>
                <div class="navbar-burger burger" onclick="document.querySelector('.navbar-menu').classList.toggle('is-active');">
                <span></span>
                <span></span>
                <span></span>
                </div>
            </div>

            <div id="navbarExampleTransparentExample" class="navbar-menu">
                <div class="navbar-end">
                    <router-link class="navbar-item" to="/">Home</router-link>
                    <router-link class="navbar-item" to="/members">Members</router-link>
                    <!-- <div class="navbar-item has-dropdown is-hoverable">
                        <a class="navbar-link" href="#">
                            Physician
                        </a>
                        <div class="navbar-dropdown is-boxed">
                            <router-link class="navbar-item" to="/physicians">Physician Info</router-link>
                        </div>
                    </div> -->
                    <router-link class="navbar-item" to="/users">
                        Account
                    </router-link>
                    <a class="navbar-item" href="#" @click="logout">
                        Logout
                    </a>
                </div>
            </div>
        </nav>
        <br/>
        <router-view></router-view>
        <br/>
        <footer class="footer">
        <div class="content has-text-centered">
            <p>
                © 2018 IRMEC AREA-E
            </p>
        </div>
        </footer>
    </div>
</template>
<script>
export default {
    methods: {
        logout () {
            
        }
    }
}
</script>

