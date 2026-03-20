// features/partners/components/Cards/TeamFormationCard/TeamFormationCard.jsx
import "./TeamFormationCard.css";

const TeamFormationCard = ({ formation }) => {
  const {
    tutorName,
    description,
    className,
    programName,
    subjectName,
    maxMembers,
    currentMembersCount,
    status,
  } = formation;

  // تحويل status إلى نص
  const statusText = status === 0 ? "مفتوح" : status === 1 ? "مكتمل" : "مغلق";
  
  // تحديد كلاس الحالة
  const statusClass = status === 0 ? "open" : status === 1 ? "full" : "closed";

  return (
    <div className="formation-card">
      <div className="card-header">        
        <h4 className="card-title">{tutorName}</h4>
        <span className={`status-badge ${statusClass}`}>
          {statusText}
        </span>
      </div>
      
      <span className="detail-label">الوصف:</span>
      <p className="card-description">{description}</p>

      <div className="card-details">      
        <div className="detail-item">
          <span className="detail-label">الصف:</span>
          <span className="detail-value">{className}</span>
        </div>

        <div className="detail-item">
          <span className="detail-label">البرنامج:</span>
          <span className="detail-value">{programName}</span>
        </div>

        <div className="detail-item">
          <span className="detail-label">المادة:</span>
          <span className="detail-value">{subjectName}</span>
        </div>
      </div>

      <div className="members-section">
        <div className="members-header">
          <span className="members-count">
            <span className="current">{currentMembersCount}</span>/{maxMembers}
          </span>
          <span className="members-label">أعضاء</span>
        </div>
      </div>

      <button className="normalButton">انضمام</button>
    </div>
  );
};

export default TeamFormationCard;