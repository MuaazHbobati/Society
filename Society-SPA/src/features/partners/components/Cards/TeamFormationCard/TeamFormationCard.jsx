import "./TeamFormationCard.css";
import { FaUserCircle, FaChalkboardTeacher, FaBook, FaGraduationCap, FaUsers, FaLock, FaPlus, FaRegCommentDots, FaTag, FaUser } from "react-icons/fa";
import { MdOutlinePending, MdDone, MdClose } from "react-icons/md";

const TeamFormationCard = ({ formation }) => {
  const {
    creatorPhoto,
    creatorName,
    creatorUsername,
    tutorName,
    description,
    className,
    programName,
    subjectName,
    maxMembers,
    currentMembersCount,
    status,
  } = formation;

  const statusText = status === 0 ? "مفتوح" : status === 1 ? "مكتمل" : "مغلق";

  const statusClass = status === 0 ? "open" : status === 1 ? "full" : "closed";

  const percentage = Math.min((currentMembersCount / maxMembers) * 100, 100);

  const StatusIcon = status === 0 ? MdOutlinePending : status === 1 ? MdDone : MdClose;
  return (
    <div className="formation-card">
      {/* قسم الناشر */}
      <div className="creator">
        {creatorPhoto ? (
          <img
            className="creator-photo"
            src={creatorPhoto}
            alt={`صورة ${creatorName}`}
            loading="lazy"
          />
        ) : (
          <FaUserCircle className="creator-photo-placeholder" size={48} />
        )}
        <div className="creator-info">
          <h3 className="creator-name">{creatorName}</h3>
          {creatorUsername && (
            <p className="creator-username">
              <FaUser size={12} /> @{creatorUsername}
            </p>
          )}
        </div>
      </div>

      <div className="card-header">
        <span className={`status-badge ${statusClass}`}>
          <StatusIcon size={14} />
          {statusText}
        </span>
        <h4 className="card-title">{subjectName}</h4>
      </div>

      <div className="card-details">
        <div className="detail-item">
          <FaRegCommentDots className="detail-icon" size={14} />
          <span className="detail-label">ملاحظات:</span>
          <p className="card-value">
            {description}
          </p>
        </div>
        <div className="detail-item">
          <FaTag className="detail-icon" size={14} />
          <span className="detail-label">الصف:</span>
          <span className="detail-value">{className}</span>
        </div>
        <div className="detail-item">
          <FaGraduationCap className="detail-icon" size={14} />
          <span className="detail-label">البرنامج:</span>
          <span className="detail-value">{programName}</span>
        </div>
        <div className="detail-item">
          <FaChalkboardTeacher className="detail-icon" size={14} />
          <span className="detail-label">الدكتور:</span>
          <span className="detail-value">{tutorName}</span>
        </div>
      </div>

      <div className="members-section">
        <div className="members-header">
          <span className="members-count">
            <span className="current">{currentMembersCount}</span>/
            {maxMembers}
          </span>
          <span className="members-label">
            <FaUsers size={12} /> أعضاء
          </span>
        </div>
        <div className="progress-bar">
          <div
            className={`progress-fill ${statusClass}`}
            style={{ width: `${percentage}%` }}
          ></div>
        </div>
      </div>

      <button className="normalButton">
        عرض تفاصيل أكثر
      </button>
    </div>
  );
};

export default TeamFormationCard;