import "./Footer.css";

export default function Footer() {
  const currentYear = new Date().getFullYear();

  return (
    <div className="footer-container">
      <div>
        <h1 className="footer-title">
          جميع الحقوق محفوظة © {currentYear} Society
        </h1>
        <h1 className="footer-title"><a className="a" href="https://www.linkedin.com/in/mohammed-mouaz-hbobati-54a2992a1"  target="_blank"
            rel="noopener noreferrer">Mohammad Muaaz Hbobati</a>, Founder</h1>
      </div>
    </div>
  );
}
