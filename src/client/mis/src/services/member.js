import "../plugins/axios";

let getAllMembers = async () => {
  return await this.axios.get("api/members");
};

export default {
  getAllMembers
};
