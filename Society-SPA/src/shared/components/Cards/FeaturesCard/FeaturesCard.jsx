import "./FeaturesCard.css";

export default function FeaturesCard({icon,Title, subTitel}) {
  return (
    <div className="featurescard-container">
      <div className="featurescard-icon">{icon}</div>
      <div>
        <h2 className="featurescard-titel">{Title}</h2>
        <h3 className="featurescard-sub-titel">{subTitel}</h3>
      </div>
    </div>
  );
}
