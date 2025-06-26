<template>
  <form @submit.prevent="registerData">
    <h1>Register Page</h1>
    <div>
      <label for="username">UserName:</label>
      <input type="text" id="username" name="username" v-model="username" />
    </div>
    <div>
      <label for="password">Password:</label>
      <input type="password" id="password" name="password" v-model="password" />
    </div>
    <div>
      <label for="Role">Role:</label>
      <select id="Role" name="Role" v-model="Role">
        <option value="User">User</option>
        <option value="Admin">Admin</option>
      </select>
    </div>
    <button type="submit">Submit</button>
  </form>
</template>

<script>
import axios from "axios";
export default {
  name: "Register",
  data() {
    return {
      username:"",
      password:"",
      Role: "User", // Default role

    };
  },
  methods: {
    registerData() {
      const userData = {
        UserName: this.username,
        Password: this.password,
        Role: this.Role,

      };
      console.log("Sending username:", this.username);
      axios
        .post("http://localhost:5096/Auth/register", userData)
        .then((response) => {
          alert("Register successfully");
          console.log("Register successfully:", response.data);
          this.username = "";
          this.password = "";
          this.Role = "User"; // Reset to default role
          this.$router.push("/login");
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
