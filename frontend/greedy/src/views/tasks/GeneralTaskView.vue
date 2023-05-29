<template>
  <Loader :size="120" v-if="!isLoaded"></Loader>
  <div v-else>
    <v-card>
      <v-tabs v-model="tab" color="primary">
        <v-tab v-for="item of taskStorages" :value="item.trackStorageId" @click="loadTracks(item.trackStorageId)">{{item.name}}</v-tab>
        <add-track-storage-dialog @storage-create="handleTrackStorageCreate"></add-track-storage-dialog>
      </v-tabs>
    </v-card>
    <v-window v-model="tab">
    </v-window>
  </div>
</template>

<script>
import Loader from '../../components/Loader.vue';
import AddTrackStorageDialog from './AddTrackStorageDialog.vue';
export default {
  name: "GeneralTaskView.vue",
  components: {AddTrackStorageDialog, Loader},
  data() {
    return {
      tab: null,
      isLoaded: false,
      taskStorages: [
      ],
      openDialog: false
    }
  },
  created() {
    let self = this;
    this.loadStorages();
  },
  methods: {
    loadStorages() {
      const self = this;
      this.$axios.get('/api/TrackStorage/get-my')
          .then((response) => {
            self.taskStorages = response.data;
            self.isLoaded = true;
          })
          .catch((error) => {
            console.error(error);
          })
    },
    loadTracks(id) {
      console.log(id);
    },
    handleTrackStorageCreate(e) {
      if (e) {
        this.isLoaded = false;
        this.loadStorages();
      }
    }
  }
}
</script>

<style scoped>

</style>