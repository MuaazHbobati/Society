import "./App.css";
import "./shared/styles/inputs.css";
import "./shared/styles/Buttons.css";

import { BrowserRouter, Routes, Route, useLocation } from "react-router-dom";
import { useEffect, useRef } from "react";

import Header from "./shared/components/Header/Header.jsx";
import LandingPage from "./features/home/pages/LandingPage/LandingPage.jsx";
import Footer from "./shared/components/Footer/Footer.jsx";
import ScrollToTop from "./shared/components/ScrollToTop/ScrollToTop.jsx";
import AboutPage from "./features/about/page/AboutPage/AboutPage.jsx";
import ContactPage from "./features/contact/page/ContactPage/ContactPage.jsx";
import RegisterPage from "./features/auth/pages/RegisterPage/RegisterPage.jsx";
import LoginPage from "./features/auth/pages/LoginPage/LoginPage.jsx";
import HomePage from "./features/home/pages/HomePage/HomePage.jsx";
import HomeFeedPage from "./features/home/components/HomeFeedPage/HomeFeedPage.jsx"

import { getToken } from "./features/auth/services/authService"; 

import PartnerPage from "./features/partners/pages/PartnerPage/PartnerPage.jsx"; // <-- أضف هذا السطر

function AppContent() {
  const location = useLocation();
  const isHashLink = useRef(false);
  const token = getToken(); 
 
  useEffect(() => {
    const handleHashClick = () => {
      isHashLink.current = true;
    };

    document.querySelectorAll('a[href*="#"]').forEach(link => {
      link.addEventListener('click', handleHashClick);
    });

    return () => {
      document.querySelectorAll('a[href*="#"]').forEach(link => {
        link.removeEventListener('click', handleHashClick);
      });
    };
  }, []);
 
  useEffect(() => {
    if (!isHashLink.current) {
      setTimeout(() => {
        window.scrollTo({ top: 0, behavior: "smooth" });
      }, 50);
    }
    isHashLink.current = false;
  }, [location.pathname]);

  return (
    <>
      <Header />
      <ScrollToTop />
      <Routes>
        {/* الصفحة العامة (لغير المسجل) */}
        <Route path="/" element={!token ? <LandingPage /> : <HomePage />} />

        {/* الصفحات العامة الأخرى */}
        <Route path="/about" element={<AboutPage key={location.key} />} />
        <Route path="/contact" element={<ContactPage key={location.key} />} />
        <Route path="/register" element={<RegisterPage key={location.key} />} />
        <Route path="/login" element={<LoginPage key={location.key} />} />

        {/* المسارات المحمية التي يجب أن تظهر داخل HomePage */}
        {token && (
          <Route path="/" element={<HomePage />}>
            <Route index element={<HomeFeedPage />} />
            <Route path="partners" element={<PartnerPage />} />
          </Route>
        )}

       </Routes>
      <Footer />
    </>
  );
}

function App() {
  return (
    <BrowserRouter>
      <AppContent />
    </BrowserRouter>
  );
}

export default App;