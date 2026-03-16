import "./HowToStartCard.css";

export default function HowToStartCard({ icon, stepNumber, title, description, color }) {
  return (
    <div className="how-to-start-card">
      <div className="step-number" style={{ background: color }}>
        {stepNumber}
      </div>
      <div className="step-icon" style={{ color: color }}>
        {icon}
      </div>
      <h3 className="step-title">{title}</h3>
      <p className="step-description">{description}</p>
    </div>
  );
}