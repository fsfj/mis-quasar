import { authHeader } from "../helpers/auth-header";

export const userService = {
  login,
  logout,
  getAll
};

function login(username, password) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username, password })
  };

  return fetch(`/users/authenticate`, requestOptions)
    .then(handleResponse)
    .then(t => {
      // login successful if there's a jwt token in the response
      if (t) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem("_t", JSON.stringify(t));
      }

      return t;
    });
}

function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem("_t");
}

function getAll() {
  const requestOptions = {
    method: "GET",
    headers: authHeader()
  };

  return fetch(`/users`, requestOptions).then(handleResponse);
}

function handleResponse(response) {
  return response.text().then(text => {
    const data = text && JSON.parse(text);
    if (!response.ok) {
      if (response.status === 401) {
        // auto logout if 401 response returned from api
        logout();
        location.reload(true);
      }

      const error = (data && data.message) || response.statusText;
      return Promise.reject(error);
    }

    return data;
  });
}
