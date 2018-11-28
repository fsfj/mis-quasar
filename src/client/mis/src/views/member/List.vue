<template>
  <div class="content">
    <a class="button" @click="goToCreate">New Member</a>
    <b-table :data="data">
      <template slot-scope="props">
        <b-table-column field="id" label="ID" width="40" numeric>{{ props.row.id }}</b-table-column>

        <b-table-column field="name" label="Name">{{ props.row.name }}</b-table-column>

        <b-table-column field="kapisanan" label="Kapisanan" centered>
          <span class="tag is-success">{{ props.row.kapisanan }}</span>
        </b-table-column>

        <b-table-column field label="Actions" centered>
          <div class="field is-grouped">
            <div class="control">
              <button class="button is-primary" @click="edit(props.row.id)">Edit</button>
            </div>
            <div class="control">
              <button class="button is-danger" @click="deleteInfo(props.row.id)">Delete</button>
            </div>
          </div>
        </b-table-column>
      </template>
    </b-table>
    <div class="modal" :class="deleteModal | modalStatusFilter">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Delete Confirmation</p>
          <button class="delete" aria-label="close" @click="closeModal"></button>
        </header>
        <section class="modal-card-body">
          <!-- Content ... -->
          <h1 class="title is-4">Do you want to delete this information?</h1>
        </section>
        <footer class="modal-card-foot" style="justify-content: flex-end;">
          <button class="button is-danger" @click="deleteConfirmed" :class="isDeleting">Yes</button>
          <button class="button" @click="closeModal">No</button>
        </footer>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      data: [],
      deleteModal: false,
      selectedId: 0,
      isDeleting: ""
    };
  },
  created() {
    this.getAllMembers();
  },
  methods: {
    async getAllMembers() {
      let { data } = await this.$axios.get("api/members");
      this.data = data;
    },
    goToCreate() {
      this.$router.push("/members/create");
    },
    edit(id) {
      this.$router.push(`/members/${id}/edit`);
    },
    deleteInfo(id) {
      this.selectedId = id;
      this.deleteModal = true;
    },
    deleteConfirmed() {
      this.$axios
        .delete(`api/members/${this.selectedId}`)
        .then(() => {
          this.getAllMembers();
          this.closeModal();
        })
        .catch(error => alert(error));
    },
    closeModal() {
      this.deleteModal = false;
    }
  }
};
</script>
