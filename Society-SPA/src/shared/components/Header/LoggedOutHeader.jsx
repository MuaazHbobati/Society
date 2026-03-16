import "./Header.css";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { HashLink } from "react-router-hash-link";
import societyLogo from "../../assets/society.ico";

export default function LoggedOutHeader() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleMenu = () => setIsMenuOpen(!isMenuOpen);
  const closeMenu = () => setIsMenuOpen(false);

  useEffect(() => {
    document.body.classList.toggle("menu-open", isMenuOpen);
    return () => document.body.classList.remove("menu-open");
  }, [isMenuOpen]);

  const scrollWithOffset = (element) => {
    const yCoordinate = element.getBoundingClientRect().top + window.pageYOffset;
    window.scrollTo({ top: yCoordinate - 80, behavior: "smooth" });
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
            <li><HashLink smooth to="/#features" className="a" onClick={closeMenu} scroll={scrollWithOffset}>الميزات</HashLink></li>
            <li><HashLink smooth to="/#how-to-start" className="a" onClick={closeMenu} scroll={scrollWithOffset}>كيف تبدأ</HashLink></li>
            <li><Link to="/about" className="a" onClick={closeMenu}>من نحن</Link></li>
            <li><Link to="/contact" className="a" onClick={closeMenu}>اتصل بنا</Link></li>
          </ul>

          <div className="mobile-btns">
            <Link to="/register" onClick={closeMenu}><button className="normalButton">انشاء حساب</button></Link>
            <Link to="/login" onClick={closeMenu}><button className="borderButton">تسجيل دخول</button></Link>
          </div>
        </nav>

        <div className="btn-container desktop-btns">
          <Link to="/register"><button className="normalButton">انشاء حساب</button></Link>
          <Link to="/login"><button className="borderButton">تسجيل دخول</button></Link>
        </div>
      </div>
      {isMenuOpen && <div className="menu-overlay" onClick={closeMenu}></div>}
    </div>
  );
}