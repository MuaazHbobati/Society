// src/features/auth/services/authService.js

const API_BASE_URL = "http://192.168.1.109:5000/api";

// ✅ دوال تخزين التوكن
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
  // ✅ Register
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

  // ✅ Login
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

  // ✅ Logout
  logout() {
    removeToken();
  },

  // ✅ NEW: جلب بيانات المستخدم الحالي
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