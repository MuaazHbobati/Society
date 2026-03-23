import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getTeamFormationById } from "../../services/partnersService";
import TeamFormationDetailsCard from "../../components/Cards/TeamFormationDetailsCard/TeamFormationDetailsCard";
import "./FormationDetailsPage.css";

export default function FormationDetailsPage() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [formation, setFormation] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchFormation = async () => {
      try {
        setLoading(true);
        const data = await getTeamFormationById(id);
        setFormation(data);
        setError(null);
      } catch (err) {
        console.error("Error fetching formation:", err);
        setError(err.response?.data?.message || "فشل في تحميل تفاصيل التشكيل");
      } finally {
        setLoading(false);
      }
    };

    if (id) {
      fetchFormation();
    }
  }, [id]);

  const handleBack = () => {
    navigate("/partners");
  };

  if (loading) {
    return (
      <div className="formation-details-page">
        <div className="loading-container">
          <div className="spinner"></div>
          <p>جاري تحميل تفاصيل التشكيل...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="formation-details-page">
        <div className="error-container">
          <div className="error-icon">⚠️</div>
          <p className="error-message">{error}</p>
          <button onClick={handleBack} className="normalButton">
            العودة إلى التشكيلات
          </button>
        </div>
      </div>
    );
  }

  if (!formation) {
    return (
      <div className="formation-details-page">
        <div className="error-container">
          <div className="error-icon">🔍</div>
          <p className="error-message">التشكيل غير موجود</p>
          <button onClick={handleBack} className="normalButton">
            العودة إلى التشكيلات
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="formation-details-page">
      <TeamFormationDetailsCard formation={formation} />
        <button onClick={handleBack} className="normalButton">
        ← العودة إلى التشكيلات
      </button>
    </div>
  );
}