import {
  FaUserCircle,
  FaChalkboardTeacher,
  FaBook,
  FaGraduationCap,
  FaUsers,
  FaInfoCircle,
  FaMapMarkerAlt,
  FaEnvelope,
  FaQuoteRight,
  FaUser,
  FaCheckCircle,
  FaRegCommentDots,
  FaClock
} from "react-icons/fa";
import { MdOutlinePending, MdDone, MdClose } from "react-icons/md";
import "./TeamFormationDetailsCard.css";

const TeamFormationDetailsCard = ({ formation }) => {
  const {
    creatorName,
    creatorUsername,
    creatorPhoto,
    creatorSVUMail,
    creatorCity,
    creatorCountry,
    creatorProfileBio,
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
    <div className="team-formation-details-card">
      <div className="formation-container">
        
      <div className="details-header">
        <span className={`status-badge ${statusClass}`}>
          <StatusIcon size={16} />
          {statusText}
        </span>
        <h1 className="details-title">{subjectName}</h1>
      </div>

      <div className="details-info-grid">
        <div className="info-card">
          <FaChalkboardTeacher className="info-icon" />
          <div className="info-content">
            <label>المدرس</label>
            <span>{tutorName}</span>
          </div>
        </div>
        <div className="info-card">
          <FaBook className="info-icon" />
          <div className="info-content">
            <label>المادة</label>
            <span>{subjectName}</span>
          </div>
        </div>
        <div className="info-card">
          <FaGraduationCap className="info-icon" />
          <div className="info-content">
            <label>البرنامج</label>
            <span>{programName}</span>
          </div>
        </div>
        <div className="info-card">
          <FaInfoCircle className="info-icon" />
          <div className="info-content">
            <label>الصف</label>
            <span>{className}</span>
          </div>
        </div>
      </div>

      <div className="description-section">
        <div className="section-header">
          <FaRegCommentDots size={18} />
          <h3>التفاصيل</h3>
        </div>
        <p>{description}</p>
      </div>

      <div className="members-section">
        <div className="members-header">
          <div className="members-label">
            <FaUsers size={16} />
            <span>الأعضاء</span>
          </div>
          <span className="members-count">
            <span className="current">{currentMembersCount}</span> / {maxMembers}
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
        {status === 2 ? (
          <>
            <MdClose size={18} /> مغلق
          </>
        ) : (
          <>
            <FaUsers size={18} /> انضمام إلى التشكيل
          </>
        )}
      
      </button>
      </div>

      <h3 className="creator-section-beginer">عن الناشر:</h3>

      <div className="creator-section">
        <div className="creator-avatar-wrapper">
          {creatorPhoto ? (
            <img className="creator-avatar" src={creatorPhoto} alt={creatorName} />
          ) : (
            <FaUserCircle className="creator-avatar-placeholder" size={80} />
          )}
        </div>
        <div className="creator-info">
          <h2 className="creator-name">{creatorName}</h2>
          <p className="creator-username">
            <FaUser size={14} /> @{creatorUsername}
          </p>
          {creatorSVUMail && (
            <p className="creator-email">
              <FaEnvelope size={14} /> {creatorSVUMail}
            </p>
          )}
          {(creatorCity || creatorCountry) && (
            <p className="creator-location">
              <FaMapMarkerAlt size={14} />
              {[creatorCity, creatorCountry].filter(Boolean).join("، ")}
            </p>
          )}
          {creatorProfileBio && (
            <p className="creator-bio">
              <FaQuoteRight size={14} /> {creatorProfileBio}
            </p>
          )}
        </div>
      </div>

    </div>
  );
};

export default TeamFormationDetailsCard;