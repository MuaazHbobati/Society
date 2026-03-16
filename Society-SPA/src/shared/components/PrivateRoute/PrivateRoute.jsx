// src/shared/components/PrivateRoute/PrivateRoute.jsx
import { Navigate } from "react-router-dom";

// دالة جلب التوكن من localStorage
const getToken = () => {
  return localStorage.getItem("token");
};

export default function PrivateRoute({ children }) {
  const token = getToken();

  // إذا ما في توكن → يروح لصفحة تسجيل الدخول
  if (!token) {
    return <Navigate to="/login" replace />;
  }

  // إذا في توكن → يشوف الصفحة المطلوبة
  return children;
}