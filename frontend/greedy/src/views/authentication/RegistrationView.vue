<script>
export default {
  data() {
    return {
      valid: false,
      registrationException: null,
      firstName: '',
      lastName: '',
      username: '',
      password: '',
      email: '',
      phoneNumber: null,
      requiredRules: [
        (value) => {
          if (value) {
            return true
          }
          return 'Field is required'
        }
      ],
      passwordRules: [
        (value) => {
          if (!value) {
            return 'Field is required'
          }
          return true
        },
        (value) => {
          if (value?.length >= 8) return true
          return 'Password must be at least 8 letters.'
        },
        (value) => {
          if (/(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}/.test(value)) return true
          return 'Password must contain at leat one letter and one number.'
        }
      ]
    }
  },
  methods: {
    sendRegistrationRequest() {
      const self = this
      self.registrationException = null
      this.$axios
        .post('/api/Account/register', {
          firstName: this.firstName,
          lastName: this.lastName,
          username: this.username,
          password: this.password,
          email: this.email,
          phoneNumber: this.phoneNumber
        })
        .then(function (response) {
          localStorage.setItem('token', response.data.token)
          self.authorization.toggleauthorized()
          self.$router.push('/home')
        })
        .catch(function (error) {
          console.log(error)
          self.registrationException = error.response.data.Message
        })
    },
    resetException() {
      this.registrationException = null
    }
  }
}
</script>

<template>
  <div class="registration-page-wrapper">
    <div class="logo"></div>
    <div class="left-section">
      <div class="content">
        <h1>Create your free account</h1>
        <v-form v-model="valid">
          <v-row>
            <v-col cols="6">
              <v-text-field
                v-model="firstName"
                variant="underlined"
                label="First name"
                required
                :rules="requiredRules"
                @input="resetException()"
                color="secondary"
              >
              </v-text-field>
            </v-col>
            <v-col cols="6">
              <v-text-field
                v-model="lastName"
                variant="underlined"
                label="Last name"
                :rules="requiredRules"
                required
                @input="resetException()"
                color="secondary"
              >
              </v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="6">
              <v-text-field
                variant="underlined"
                v-model="username"
                label="Username"
                :rules="requiredRules"
                required
                @input="resetException()"
                color="secondary"
              >
              </v-text-field>
            </v-col>
            <v-col cols="6">
              <v-text-field
                variant="underlined"
                label="Password"
                :rules="passwordRules"
                v-model="password"
                type="password"
                required
                @input="resetException()"
                color="secondary"
              >
              </v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="6">
              <v-text-field
                v-model="email"
                variant="underlined"
                :rules="requiredRules"
                label="Email"
                type="email"
                required
                @input="resetException()"
                color="secondary"
              >
              </v-text-field>
            </v-col>
            <v-col cols="6">
              <v-text-field
                v-model="phoneNumber"
                variant="underlined"
                label="Phone number"
                type="tel"
                @input="resetException()"
                color="secondary"
              >
              </v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <p v-if="registrationException != null" class="text-error">
                {{ registrationException }}
              </p>
            </v-col>
            <v-col cols="12">
              <v-btn
                color="primary"
                :disabled="!valid ? true : false"
                @click="sendRegistrationRequest"
                block
              >
                Next
                <v-icon icon="mdi-arrow-right-thick"></v-icon>
              </v-btn>
            </v-col>
          </v-row>
        </v-form>
        <v-row>
          <v-col cols="12">
            <p class="privacy-text">
              We’re committed to your privacy. Greendy uses the information you provide to us to
              contact you about our relevant content, products, and services. You may unsubscribe
              from these communications at any time. For more information, check out our
              <router-link to="/privacy" class="text-secondary"> Privacy Policy </router-link>
            </p>
          </v-col>
        </v-row>
      </div>
    </div>
    <div class="right-section">
      <img width="430" src="../../assets/images/reg_image.png" />
      <p class="text-secondary slogan">Unlock your potential with our achievement system</p>
    </div>
  </div>
</template>

<style scoped lang="scss">
.registration-page-wrapper {
  min-height: 100vh;
  display: flex;
  align-items: center;
  .right-section {
    width: 50%;
    display: flex;
    flex-direction: column;
    align-items: center;

    .slogan {
      margin-top: 20px;
      font-weight: bold;
    }
  }

  .left-section {
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
    .content {
      width: 400px;

      h1 {
        font-size: 36px;
        margin-bottom: 40px;
      }

      .privacy-text {
        font-weight: bold;
        text-align: justify;
        text-indent: 10px;
      }
    }
  }
}

@media screen and (max-width: 767px) {
  .registration-page-wrapper {
    padding: 18px;
    padding-top: 70px;
    min-width: max(100vw, 100%);
    flex-direction: column;
    .left-section {
      width: 100%;
      height: 100vh;
      .content {
        h1 {
          text-align: center;
        }
      }
    }

    .right-section {
      width: 100%;
      img {
        width: 300px;
      }
    }
  }
}

.logo {
  background-image: url('../../assets/images/icon_with_text.svg');
  width: 100px;
  height: 50px;
  background-size: 100% 100%;
  position: absolute;
  top: 20px;
  left: 20px;
}
</style>
