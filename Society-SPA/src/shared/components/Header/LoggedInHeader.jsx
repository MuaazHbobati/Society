import "./Header.css";
import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import societyLogo from "../../assets/society.ico";
import { authService } from "../../../features/auth/services/authService";

export default function LoggedInHeader() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const navigate = useNavigate();

  const toggleMenu = () => setIsMenuOpen(!isMenuOpen);
  const closeMenu = () => setIsMenuOpen(false);

  useEffect(() => {
    document.body.classList.toggle("menu-open", isMenuOpen);
    return () => document.body.classList.remove("menu-open");
  }, [isMenuOpen]);

  const handleLogout = () => {
    authService.logout();
    navigate("/");
  };

  return (
    <div className="header">
      <div className="header-container">
        <Link to="/" className="img-name-container" onClick={closeMenu}>
          <img className="logoico" src={societyLogo} alt="Society-Logo" />
          <h2>Society</h2>
        </Link>

        <button className={`burger-btn ${isMenuOpen ? "open" : ""}`} onClick={toggleMenu}>
          <span></span><span></span><span></span>
        </button>

        <nav className={`nav ${isMenuOpen ? "open" : ""}`}>
          <ul className="ul">
            <li><Link to="/" className="a" onClick={closeMenu}>المجتمع</Link></li>
            <li><Link to="/partners" className="a" onClick={closeMenu}>نظام الشركاء</Link></li>
          </ul>
          <div className="mobile-logout">
            <button onClick={handleLogout} className="borderButton">تسجيل خروج</button>
          </div>
        </nav>

        <div className="btn-container desktop-logout">
          <button onClick={handleLogout} className="borderButton">تسجيل خروج</button>
        </div>
      </div>
      {isMenuOpen && <div className="menu-overlay" onClick={closeMenu}></div>}
    </div>
  );
}