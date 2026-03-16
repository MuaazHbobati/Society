import "./UserProfileCard.css";
import '../../../styles/buttons.css'
import { FaUserCircle, FaEdit, FaMapMarkerAlt, FaGraduationCap, FaUniversity } from "react-icons/fa";
import { Link } from "react-router-dom";

export default function UserProfileCard({ user, showEdit = false }) {
  return (
    <div className="user-profile-card">
      {/* صورة البروفايل */}
      <div className="profile-avatar">
        {user?.profilePictureUrl ? (
          <img src={user.profilePictureUrl} alt={user?.firstName} />
        ) : (
          <FaUserCircle size={100} />
        )}
      </div>

      {/* الاسم الكامل */}
      <h3 className="profile-name">
        {user?.firstName} {user?.lastName}
      </h3>

      {/* اسم المستخدم */}
      {user?.userName && (
        <p className="profile-username">@{user.userName}</p>
      )}

      {/* معلومات إضافية */}
      <div className="profile-details">
        {user?.bio && (
          <p className="profile-bio">{user.bio}</p>
        )}

        {user?.major && user?.faculty && (
          <p className="profile-education">
            <FaGraduationCap className="detail-icon" />
            {user.major} - {user.faculty}
          </p>
        )}

        {user?.university && (
          <p className="profile-university">
            <FaUniversity className="detail-icon" />
            {user.university}
          </p>
        )}

        {user?.city && (
          <p className="profile-city">
            <FaMapMarkerAlt className="detail-icon" />
            {user.city}
          </p>
        )}
      </div>

      {/* زر التعديل (يظهر فقط إذا showEdit = true) */}
      {showEdit && (
        <Link to="/profile/edit" className="edit-profile-btn">
          <FaEdit /> تعديل الملف الشخصي
        </Link>
      )}
    </div>
  );
}