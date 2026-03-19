import "./HomePage.css";
import { useState, useEffect } from "react";
import { authService } from "../../../auth/services/authService";
import UserProfileCard from "../../../../shared/components/Cards/UserProfileCard/UserProfileCard";
import { Outlet } from "react-router-dom"

export default function HomePage() {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        setLoading(true);
        const result = await authService.getCurrentUser();

        if (result.success) {
          setUser(result.data);
        } else {
          setError(result.error);
        }
      } catch {
        setError("فشل جلب البيانات");
      } finally {
        setLoading(false);
      }
    };

    fetchUserData();
  }, []);

  if (loading) {
    return (
      <div className="home-page">
        <div className="home-page__loading">
          <div className="spinner"></div>
          <p>جاري تحميل البيانات...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="home-page">
        <div className="home-page__error">
          <p>{error}</p>
          <button onClick={() => window.location.reload()}>
            إعادة المحاولة
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="home-page">
     
      <div className="home-page__container">
        <aside className="home-page__sidebar">
          <UserProfileCard user={user} showEdit={true} />
        </aside>
        <main className="home-page__content">
          <Outlet />
        </main>
      </div>
    </div>
  );
}
