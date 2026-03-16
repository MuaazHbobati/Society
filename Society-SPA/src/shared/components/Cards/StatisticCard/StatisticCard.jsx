import "./StatisticCard.css";

export default function StatisticCard({ icon, number, label }) {
  return (
    <div className="statistic-card">
      <div className="statistic-card-icon">{icon}</div>
      <div className="statistic-card-number">{number}</div>
      <div className="statistic-card-label">{label}</div>
    </div>
  );
}