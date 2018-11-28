<template>
  <q-layout view="lHh Lpr lFf">
    <q-layout-header>
      <q-toolbar
        color="primary"
        :inverted="$q.theme === 'ios'"
      >
        <q-btn
          flat
          dense
          round
          @click="leftDrawerOpen = !leftDrawerOpen"
          aria-label="Menu"
        >
          <q-icon name="menu" />
        </q-btn>

        <q-toolbar-title>
          MIS App
          <div slot="subtitle">Running on Quasar v{{ $q.version }}</div>
        </q-toolbar-title>
      </q-toolbar>
    </q-layout-header>

    <q-layout-drawer
      behavior="default"
      v-model="leftDrawerOpen"
      :content-class="$q.theme === 'mat' ? 'white': 'white'"
    >
      <q-list
        no-border
        link
        inset-delimiter
      >
        <q-list-header class="q-header">Navigation</q-list-header>
        <q-item v-for="(route, index) in routes" v-bind:key="index" :to="{ path: route.path }" v-if="route.path !== '*'" exact>
          <q-item-side :icon="route.icon" />
          <q-item-main>
            <q-item-tile label>{{route.text}}</q-item-tile>
            <q-item-tile sublabel></q-item-tile>
          </q-item-main>
        </q-item>
      </q-list>
    </q-layout-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { openURL } from 'quasar'
import routes from '../router/routes'
export default {
  name: 'MyLayout',
  data () {
    return {
      leftDrawerOpen: this.$q.platform.is.desktop,
      routes
    }
  },
  methods: {
    openURL
  }
}
</script>

<style>
.q-header {
  height: 80px;
}
</style>
