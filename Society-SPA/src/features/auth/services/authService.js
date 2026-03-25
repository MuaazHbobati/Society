import {API_BASE_URL} from "../../../shared/api/API_BASE_URL.js"

const setToken = (token) => {
  localStorage.setItem("token", token);
};

export const getToken = () => {
  return localStorage.getItem("token");
};

export const removeToken = () => {
  localStorage.removeItem("token");
};

export const authService = {
  async register(userData) {
    try {
      const response = await fetch(`${API_BASE_URL}/Auth/register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(userData),
      });

      const data = await response.json();

      if (!response.ok) {
        throw new Error(data.error || "حدث خطأ في التسجيل");
      }

      return { success: true, data };
    } catch (error) {
      return { success: false, error: error.message };
    }
  },

  async login(credentials) {
    try {
      const response = await fetch(`${API_BASE_URL}/Auth/Login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(credentials),
      });

      const data = await response.json();

      if (!response.ok) {
        throw new Error(data.message || "خطأ في تسجيل الدخول");
      }

      if (data.token) {
        setToken(data.token);
      }

      return { success: true, data };
    } catch (error) {
      return { success: false, error: error.message };
    }
  },

  logout() {
    removeToken();
  },

  async getCurrentUser() {
    try {
      const token = getToken();
      
      if (!token) {
        throw new Error("لا يوجد توكن");
      }

      const response = await fetch(`${API_BASE_URL}/profile/me`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`
        },
      });

      const data = await response.json();

      if (!response.ok) {
        throw new Error(data.message || "فشل جلب بيانات المستخدم");
      }

      return { success: true, data };
    } catch (error) {
      return { success: false, error: error.message };
    }
  }
};