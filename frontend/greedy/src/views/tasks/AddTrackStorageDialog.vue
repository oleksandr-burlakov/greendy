<template>
  <v-dialog
    v-model="dialog"
    persistent
    >
    <template v-slot:activator="{ props }">
      <v-btn variant="text" icon="mdi-plus" class="add-storage-icon" v-bind="props">
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        Add new track storage
      </v-card-title>
      <v-card-text>
        <v-form v-model="valid">
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="name"
                  :rules="nameRules"
                  label="Name*"
                  required>
                </v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="12">
                <v-textarea
                    v-model="description"
                    label="Description"
                ></v-textarea>
              </v-col>
            </v-row>
          </v-container>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-btn variant="outlined" color="primary" :disabled="!this.valid" @click="createNew()">Create</v-btn>
        <v-btn variant="outlined" color="secondary" @click="dialog = false">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "AddTrackStorageDialog.vue",
  data() {
    return {
      dialog: false,
      valid: false,
      name: null,
      description: null,
      nameRules: [
          value => {
            if (value) return true;
            return 'Name is required';
          }
      ]
    }
  },
  methods: {
    createNew() {
      let data = {
        name: this.name,
        description: this.description
      };
      this.$axios.post('/api/TrackStorage/create', data)
          .then((response) => {
            this.$emit('storage-create', true);
            this.isDialogShow = false;
          })
          .catch((error) => console.error(error));
    }
  }
}
</script>

<style scoped>
  .v-card-actions {
    display: flex;
    justify-content: space-between;
  }
  .add-storage-icon {
    margin-left:auto;
    height:100%;
  }
</style>