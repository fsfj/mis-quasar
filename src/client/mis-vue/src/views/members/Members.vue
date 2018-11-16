<template>
    <div>
        <h1>Members</h1>
        <button @click="inc">Increment</button>
        <p>{{ counter }}</p>
    </div>
</template>
<script lang="ts">
import Vue from 'vue'
import { mapState, mapActions } from 'vuex'
import Component from 'vue-class-component';

@Component({
    computed: mapState('Members', ['counter']),
    methods: mapActions('Members',['count']),
    watch: {
        counter(val) {
            return val++;
        }
    }
})
export default class Members extends Vue {
    counter: any;
    count: any;
    imagePath: string = "";
    inc(){
        this.count();
    }
  
    takePicture() {
        var api = navigator.getUserMedia;

        api.bind(navigator)()
    }
}
</script>

