<template>
  <div class="main-container">
    <div class="side-toggler bg-primary" :class="{ 'toggle-open': sidebarVisible }">
      <div class="active-buttons">
        <router-link to="/home" style="text-decoration: none; color: inherit">
          <v-btn size="small" variant="text" color="white">
            <v-icon size="20" icon="mdi-home"></v-icon>
            <p v-if="sidebarVisible">Home</p>
          </v-btn>
        </router-link>
        <v-btn size="small" variant="text" color="white">
          <v-icon size="20" icon="mdi-trophy-award"></v-icon>
          <p v-if="sidebarVisible">Achievments</p>
        </v-btn>
        <router-link to="/tasks" style="text-decoration: none; color: inherit">
          <v-btn size="small" variant="text" color="white">
            <v-icon size="20" icon="mdi-checkbox-marked-circle-auto-outline"></v-icon>
            <p v-if="sidebarVisible">Tasks</p>
          </v-btn>
        </router-link>
        <v-btn size="small" variant="text" color="white">
          <v-icon size="20" icon="mdi-account-group"></v-icon>
          <p v-if="sidebarVisible">Groups</p>
        </v-btn>
        <v-btn size="small" variant="text" color="white">
          <v-icon size="20" icon="mdi-compass"></v-icon>
          <p v-if="sidebarVisible">Explore</p>
        </v-btn>
        <v-btn size="small" variant="text" color="white">
          <v-icon size="20" icon="mdi-cog-outline"></v-icon>
          <p v-if="sidebarVisible">Setting</p>
        </v-btn>
      </div>
      <div class="toggler">
        <v-btn class="toggle-btn" size="small" variant="text" color="secondary" @click="toggle()">
          <v-icon v-if="sidebarVisible" size="20" icon="mdi-arrow-left-bold-circle"></v-icon>
          <v-icon v-else size="20" icon="mdi-arrow-right-bold-circle"></v-icon>
        </v-btn>
      </div>
    </div>
    <div class="center-container" :class="{ 'center-closed': sidebarVisible }">
      <RouterView />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      sidebarVisible: false
    }
  },
  methods: {
    toggle() {
      this.sidebarVisible = !this.sidebarVisible
    }
  }
}
</script>

<style scoped lang="scss">
.center-container {
  width: 100%;
  margin-left: 50px;
  transition: margin-left 0.1s;
  &.center-closed {
    margin-left: 180px;
  }
}

.main-container {
  display: flex;
}

.side-toggler {
  width: 50px;
  transition: width 0.1s;

  &.toggle-open {
    width: 180px;
  }

  height: 100vh;
  position: fixed;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;

  .logo {
    width: 80%;

    img {
      width: 100%;
      heigth: 100%;
    }
  }

  .active-buttons {
    width: 100%;

    .v-btn {
      padding-top: 20px;
      padding-bottom: 20px;
      width: 100%;
      display: flex;
      justify-content: space-between;

      p {
        margin-left: 10px;
      }
    }
  }

  .toggler {
    width: 100%;

    .toggle-btn {
      height: 100%;
      padding-top: 10px;
      padding-bottom: 10px;
      width: 100%;
    }
  }
}
</style>
