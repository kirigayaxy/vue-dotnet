<template>
  <form @submit.prevent="loginUser">
    <h1>Login Page</h1>
    <div>
      <label for="username">UserName:</label>
      <input type="text" id="username" name="username" v-model="username" />
    </div>
    <div>
      <label for="password">Password:</label>
      <input type="password" id="password" name="password" v-model="password" />
    </div>
    
    <button type="submit">Submit</button>
  </form>
</template>

<script>
import axios from "axios";
export default {
  name: "Login",
  data() {
    return {
      username:"",
      password:"",

    };
  },
  methods: {
    loginUser() {
      const userData = {
        UserName: this.username,
        Password: this.password,

      };
      const API_URL = "http://13.55.120.192:5096" || "http://localhost:5096";
      console.log("Sending username for login:", this.username);
      axios
        .post(`${API_URL}/Auth/login`, userData)
        .then((response) => {
          alert("Login success");
          console.log("Login successfully:", response.data);
          const token = response.data.data; // Extract the JWT from the response
          localStorage.setItem('token', token); // Store it for later use
          this.username = "";
          this.password = "";
          this.$router.push("/detail");
        })
        .catch((error) => {
          alert(error.response?.data?.message);
          console.error("Error regist data:", error);
        })
    },
  },
};
</script>

<style></style>
