export function authHeader() {
  // return authorization header with jwt token
  let t = JSON.parse(localStorage.getItem("_t"));

  if (t) {
    return { Authorization: "Bearer " + t };
  } else {
    return {};
  }
}
