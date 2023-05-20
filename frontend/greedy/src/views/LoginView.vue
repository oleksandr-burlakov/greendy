<script>
import { RouterLink } from 'vue-router'
import { useAuthorizationStore } from '../stores/authorization'
export default {
    data() {
		return {
			valid: false, 
        	login: "",
        	password: "",
			loginException: "",
        	nameRules: [
            	value => {
                	if (value)
                    	return true;
                	return "Login is requred.";
            	}
        	],
        	passwordRules: [
            	value => {
                	if (value)
                    	return true;
                	return "Password is requred.";
            	},
            	value => {
                	if (value?.length >= 8)
                    	return true;
                	return "Password must be at least 8 letters.";
            	},
            	value => {
                	if (/(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}/.test(value))
                    	return true;
                	return "Password must contain at leat one letter and one number.";
            	}
        	],
		}
    },
	methods: {	
		makeLoginRequest() {
			const self = this;
			const authorization = useAuthorizationStore();
			self.loginException = null;
			this.$axios.post('/api/Account/login', {
				login: this.login,
				password: this.password
			})
				.then(function (response) {
					authorization.setToken(response.data.token);
					self.$router.push("/home");
				})
				.catch(function (error) {
					console.error(error);
					self.loginException = error.response.data.Message;
				});
		}	
	},
    components: { RouterLink }
}


</script>

<template>
    <div class="login-page-wrapper">
        <div class="login-section">
            <div class="logo">
            </div>
            <div class="content">
                <v-row>
                    <v-col cols="12">
                        <h1>Login to Your Account</h1>
                    </v-col>
                </v-row>
                <v-form v-model="valid" v-on:submit.prevent>
                    <v-container>
                        <v-row>
                            <v-text-field
                            v-model="login"
                            :rules="nameRules"
                            label="Login"
                            required
                            variant="outlined"
                            style="margin-bottom:20px;"
							@input="() => {loginException = null;}"
                            ></v-text-field>
                        </v-row>
                        <v-row>
                            <v-text-field
                                v-model="password"
                                :rules="passwordRules"
                                type="password"
                                label="Password"
                                variant="outlined"
                                required
								@input="() => {loginException = null;}"
                            ></v-text-field>
                        </v-row>
                        <v-row> 
							<p v-if="loginException" class="text-error">
								{{ loginException}}
							</p>
                            <v-btn
								type="submit"
								:disabled="!valid"
								@click="makeLoginRequest"
                                variant="flat"
                                color="primary"
                                block
                                class="login-btn"
                            >
                                Sign-in
                            </v-btn>
                        </v-row>
                    </v-container>
                </v-form>
            </div>
        </div>
        <div class="register-section">
            <div class="content">
                <h1>New Here?</h1>
                <p>Sign up and discover great amount of oportunities!</p>
                <router-link to="/registration">
                    <v-btn block class="sign-btn" variant="flat">Sign-Up</v-btn>
                </router-link>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .logo {
        background-image: url("../assets/images/icon_with_text.svg");
        width:100px;
        height:50px;
        background-size:100% 100%;
        position: absolute;
        top:20px;
        left: 20px;
    }
    .login-page-wrapper {
        display: flex;
        height:100vh;
    }

    .login-section {
        width:70%;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .register-section {
        width:30%;
        color: var(--main-color);
        background-color: var(--secondary-color);
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .register-section .content {
        padding-right:30px;
        padding-left:30px;
        justify-content: center;
        display: flex;
        flex-direction: column;
    }

    .register-section .content h1 {
        text-align: center;
        font-size: 36px;
        margin-bottom: 20px;
    }

    .register-section .content p {
        text-align: justify;
        font-size: 18px;
        font-weight: 400;
        margin-bottom: 60px;
    }

    .register-section .content .sign-btn {
        margin:auto;
    }

    .login-section .content {
        width:460px;
    }

    .login-section .content h1 {
        text-align: center;
        font-size: 42px;
        margin-bottom: 20px;
    }

    .login-section .content .v-form {
        margin-left: 20px;
        margin-right: 20px;
    }

    .login-section .content .v-form .v-btn {
        margin-top: 10px;
    }


    @media screen and (max-width: 767px) {
        .login-page-wrapper {
            flex-direction: column;
            min-width: max(100%, 100vmin);
        }
        .register-section {
            min-width:100%;
            min-height: 100vh;
        }
        .login-section {
            width:100%;
            min-height: 100vh;
        }

        .login-section .content {
            width:260px;
            font-size: 20px;
        }
        .login-section .content h1 {
            font-size: 32px;
        }
    }
</style>
