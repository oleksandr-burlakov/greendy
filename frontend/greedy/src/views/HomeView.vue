<script setup>
</script>

<template>
    <v-container>
      <v-row justify="center" >
        <v-col lg="6" cols="12">
          <v-row class="bg-grey-lighten-4">
            <v-col cols="10">
              <h2>Posts</h2>
              <v-row v-for="index in 25" justify="center">
                <v-col cols="8" >
                  <v-card text="
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Corporis dignissimos distinctio incidunt modi
                ratione voluptates! Earum eligendi inventore magni minima nam natus nesciunt non, nostrum obcaecati
                perspiciatis, quo sequi sint." variant="tonal">
                    <template v-slot:title>
                      Post {{ index }}
                    </template>
                  </v-card>
                </v-col>
              </v-row>
            </v-col>
            <v-col cols="2">
             Profile
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
</template>

<style scoped>
</style>