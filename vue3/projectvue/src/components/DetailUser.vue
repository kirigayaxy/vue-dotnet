<template>
  <div>
    <div>
      <button @click.prevent="showDetails">show detail</button>
    </div>
    <div v-if="isShow && UserData.data && UserData.data.role === 'User'">
      <ul>
        <li>{{ UserData.data.userName }}</li>
        <li>{{ UserData.data.firstName }}</li>
        <li>{{ UserData.data.lastName }}</li>
        <li>{{ UserData.data.email }}</li>
        <li>{{ UserData.data.role }}</li>
      </ul>
      <button @click="edit">Edit</button>
      <div v-if="isEdit && UserData.data">
        <form @submit.prevent="submitEdit">
          <label for="FirstName">FirstName</label>
          <input
            type="text"
            id="FirstName"
            placeholder="FirstName"
            v-model="UserData.data.firstName"
          />
          <label for="LastName">LastName</label>
          <input
            type="text"
            id="LastName"
            placeholder="LastName"
            v-model="UserData.data.lastName"
          />
          <label for="Email">Email</label>
          <input
            type="email"
            id="Email"
            placeholder="Email"
            v-model="UserData.data.email"
          />
          <label for="Role">Email</label>
          <select id="Role" name="Role" v-model="Role">
            <option value="User">User</option>
            <option value="Admin">Admin</option>
          </select>
          <button type="submit">Update</button>
        </form>
      </div>
    </div>
    <div  v-else-if="isShow && UserData.data && UserData.data.role === 'Admin'">
      <ul v-for="(item, index) in users.data" :key="index">
        <li>UserName : {{ item.userName }}</li>
        <li>FirstName : {{ item.firstName }}</li>
        <li>LastName : {{ item.lastName }}</li>
        <li>Email : {{ item.email }}</li>
        <li>Role : {{ item.role }}</li>
      </ul>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "DetailUser",
  data() {
    return {
      users: [],
      UserData: {
        data: null,
        success: false,
        message: "",
      },
      isShow: false,
      isEdit: false,
      Role: "User", // Default role
      
    };
  },

  methods: {
    showDetails() {
      const API_URL = "http://13.55.120.192:5096" || "http://localhost:5096"; // fallback local
      if (this.UserData.data && this.UserData.data.role !== "User") {
        axios
          .get(`${API_URL}/api/User/allusers`)
          .then((response) => {
            this.users = response.data;
            console.log(this.users);
            this.isShow = !this.isShow;
          })
          .catch((error) => {
            console.error("Error fetching weather data:", error);
          });
      } else {
        axios
          .get(`${API_URL}/api/User/data`)
          .then((response) => {
            this.UserData = response.data;
            console.log(this.UserData);
            this.isShow = !this.isShow;
          })
          .catch((error) => {
            console.error("Error fetching weather data:", error);
          });
      }
    },
    submitEdit() {
      const API_URL = "http://13.55.120.192:5096" || "http://localhost:5096";
      this.UserData.data.role = this.Role
      axios
        .put(`${API_URL}/api/User/update`, this.UserData.data)
        .then((response) => {
          alert("update success");
          console.log("Update successfully:", response.data);
          this.$router.push("/detail");
        });
    },
    edit() {
      this.isEdit = !this.isEdit;
    },
  },
};
</script >

<style >

</style>
