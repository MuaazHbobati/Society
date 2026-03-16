import "./HeroSection.css";
import "../../../../shared/styles/buttons.css";
import societylogo from "../../../../shared/assets/society-logo-big.png";
import { Link } from "react-router-dom";


export default function HeroSection() {
  return (
    <div className="hero-container">
      <div className="hero-background"></div>
      
      <div className="hero-content">
        <div className="father-hero-paragraph">
          <div>
            <h1 className="title">
              منصة{" "}
              <span style={{ color: "var(--blue)", fontWeight: "900" }}>
                Society
              </span>{" "}
              الاجتماعية
            </h1>
            <h1 className="sub-title">
              Society هي المنصة الأولى والوحيدة لطلاب التخصصات التقنية في{" "}
              <span style={{ color: "var(--blue)" }}>
                الجامعة السورية الافتراضية
              </span>
              ، تمكنهم من كسر العزلة الرقمية من خلال تبادل المعرفة وتشكيل الفرق
              بشكل منظم بعيداً عن الفوضى.{" "}
            </h1>
          </div>

          <div className="btn-hero-container">
            <Link to={"/register"}><button className="normalButton" style={{ fontSize: "20px" }}>
              ابدأ رحلتك الآن
            </button></Link>

          </div>
        </div>

        <div>
          <div className="logo-container">
            <img className="logopng" src={societylogo} alt="Society logo" />
          </div>
        </div>
      </div>

      <div className="custom-shape-divider-bottom-1772391931">
        <svg
          data-name="Layer 1"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 1200 120"
          preserveAspectRatio="none"
        >
          <path
            d="M985.66,92.83C906.67,72,823.78,31,743.84,14.19c-82.26-17.34-168.06-16.33-250.45.39-57.84,11.73-114,31.07-172,41.86A600.21,600.21,0,0,1,0,27.35V120H1200V95.8C1132.19,118.92,1055.71,111.31,985.66,92.83Z"
            className="shape-fill"
          ></path>
        </svg>
      </div>
    </div>
  );
}