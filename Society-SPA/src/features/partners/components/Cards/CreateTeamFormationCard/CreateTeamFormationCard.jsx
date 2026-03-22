// features/partners/components/Cards/CreateTeamFormationCard/CreateTeamFormationCard.jsx
import React, { useState, useEffect } from "react";
import { createTeamFormation } from "../../../services/partnersService";
import { getMySubjects } from "../../../services/programService";
import "./CreateTeamFormationCard.css";

const CreateTeamFormationCard = ({ onFormationCreated }) => {
   
  const [subjects, setSubjects] = useState([]);
  const [loadingSubjects, setLoadingSubjects] = useState(false);
  const [errorSubjects, setErrorSubjects] = useState(false);

  const [tutorName, setTutorName] = useState("");
  const [description, setDescription] = useState("");
  const [className, setClassName] = useState("");
  const [subjectId, setSubjectId] = useState("");
  const [maxMembers, setMaxMembers] = useState(20);

  const [tutorNameTouched, setTutorNameTouched] = useState(false);
  const [descriptionTouched, setDescriptionTouched] = useState(false);
  const [classNameTouched, setClassNameTouched] = useState(false);
  const [subjectIdTouched, setSubjectIdTouched] = useState(false);
  const [maxMembersTouched, setMaxMembersTouched] = useState(false);

  const [loading, setLoading] = useState(false);
  const [apiError, setApiError] = useState("");

  // ✅ جلب المواد الخاصة ببرنامج المستخدم (بدون الحاجة لـ programId)
  useEffect(() => {
    const fetchMySubjects = async () => {
      setLoadingSubjects(true);
      setErrorSubjects(false);
      try {
        const data = await getMySubjects();
        setSubjects(data || []);
        if (!data || data.length === 0) {
          setErrorSubjects(true);
        }
      } catch (error) {
        console.error("Failed to fetch subjects:", error);
        setErrorSubjects(true);
        setSubjects([]);
      } finally {
        setLoadingSubjects(false);
      }
    };
    fetchMySubjects();
  }, []);

  const isTutorNameValid = tutorName.trim().length >= 3;
  const isDescriptionValid = description.trim().length >= 10;
  const isClassNameValid = className.trim().length >= 1 && className.trim().length <= 5;
  const isSubjectIdValid = subjectId !== "" && Number(subjectId) > 0;
  const isMaxMembersValid = maxMembers >= 2 && maxMembers <= 20;

  const isFormValid =
    isTutorNameValid &&
    isDescriptionValid &&
    isClassNameValid &&
    isSubjectIdValid &&
    isMaxMembersValid;

  const handleSubmit = async (e) => {
    e.preventDefault();

    setTutorNameTouched(true);
    setDescriptionTouched(true);
    setClassNameTouched(true);
    setSubjectIdTouched(true);
    setMaxMembersTouched(true);

    if (!isFormValid) return;

    setLoading(true);
    setApiError("");

    // ✅ نرسل فقط subjectId (بدون programId)
    const dataToSend = {
      tutorName,
      description,
      className,
      subjectId: Number(subjectId),
      maxMembers: Number(maxMembers),
    };

    try {
      const newFormation = await createTeamFormation(dataToSend);
      onFormationCreated(newFormation);

      // إعادة تعيين الحقول
      setTutorName("");
      setDescription("");
      setClassName("");
      setSubjectId("");
      setMaxMembers(20);

      setTutorNameTouched(false);
      setDescriptionTouched(false);
      setClassNameTouched(false);
      setSubjectIdTouched(false);
      setMaxMembersTouched(false);
    } catch (error) {
      setApiError(
        error.response?.data?.message || "فشل إنشاء التشكيل. حاول مرة أخرى",
      );
      console.error("Failed to create formation", error);
    } finally {
      setLoading(false);
    }
  };

  const handleReset = () => {
    setTutorName("");
    setDescription("");
    setClassName("");
    setSubjectId("");
    setMaxMembers(20);

    setTutorNameTouched(false);
    setDescriptionTouched(false);
    setClassNameTouched(false);
    setSubjectIdTouched(false);
    setMaxMembersTouched(false);

    setApiError("");
  };

  // ✅ حالة تحميل المواد
  if (loadingSubjects) {
    return (
      <div className="create-formation-card">
        <div className="create-form">
          <h3>تشكيل فريق جديد</h3>
          <div className="loading-state">جاري تحميل المواد...</div>
        </div>
      </div>
    );
  }

  // ✅ حالة عدم وجود مواد
  if (errorSubjects) {
    return (
      <div className="create-formation-card">
        <div className="create-form">
          <h3>تشكيل فريق جديد</h3>
          <div className="error-state">
            <p>لا توجد مواد متاحة لبرنامجك.</p>
            <p>يرجى التواصل مع الدعم الفني.</p>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="create-formation-card">
      <div className="create-form">
        <h3>تشكيل فريق جديد</h3>

        {apiError && <div className="form-error api-error">{apiError}</div>}

        <form onSubmit={handleSubmit} noValidate>
          <div className="form-grid">
            {/* اسم المدرس */}
            <div className="form-group form-col-half">
              <label htmlFor="tutorName">اسم المدرس</label>
              <input
                id="tutorName"
                type="text"
                className={`form-input ${tutorNameTouched && !isTutorNameValid ? "error" : ""}`}
                placeholder="مثال: أ. محمد أحمد"
                value={tutorName}
                onChange={(e) => setTutorName(e.target.value)}
                onBlur={() => setTutorNameTouched(true)}
              />
              {tutorNameTouched && !isTutorNameValid && (
                <span className="form-error-text">
                  اسم المدرس مطلوب (3 أحرف على الأقل)
                </span>
              )}
            </div>

            {/* الصف */}
            <div className="form-group form-col-half">
              <label htmlFor="className">الصف</label>
              <input
                id="className"
                type="text"
                className={`form-input ${classNameTouched && !isClassNameValid ? "error" : ""}`}
                placeholder="مثال: C12"
                value={className}
                onChange={(e) => setClassName(e.target.value)}
                onBlur={() => setClassNameTouched(true)}
                maxLength={5}
              />
              {classNameTouched && !isClassNameValid && (
                <span className="form-error-text">الصف مطلوب (1-5 أحرف)</span>
              )}
            </div>

            {/* الوصف */}
            <div className="form-group form-col-full">
              <label htmlFor="description">الوصف</label>
              <textarea
                id="description"
                className={`form-input ${descriptionTouched && !isDescriptionValid ? "error" : ""}`}
                placeholder="مثال: نحتاج الى مصمم للواجهة، منسق للتقرير على Word."
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                onBlur={() => setDescriptionTouched(true)}
                rows="3"
              />
              {descriptionTouched && !isDescriptionValid && (
                <span className="form-error-text">
                  الوصف مطلوب (10 أحرف على الأقل)
                </span>
              )}
            </div>

            {/* المادة - فقط! بدون برنامج */}
            <div className="form-group form-col-full">
              <label htmlFor="subjectId">المادة</label>
              <select
                id="subjectId"
                className={`form-input ${subjectIdTouched && !isSubjectIdValid ? "error" : ""}`}
                value={subjectId}
                onChange={(e) => setSubjectId(e.target.value)}
                onBlur={() => setSubjectIdTouched(true)}
              >
                <option value="">-- اختر المادة --</option>
                {subjects.map((subject) => (
                  <option key={subject.id} value={subject.id}>
                    {subject.name}
                  </option>
                ))}
              </select>
              {subjectIdTouched && !isSubjectIdValid && (
                <span className="form-error-text">الرجاء اختيار المادة</span>
              )}
            </div>

            {/* الحد الأقصى للأعضاء */}
            <div className="form-group form-col-half">
              <label htmlFor="maxMembers">الحد الأقصى للأعضاء</label>
              <input
                id="maxMembers"
                type="number"
                className={`form-input ${maxMembersTouched && !isMaxMembersValid ? "error" : ""}`}
                placeholder="الحد الأقصى للأعضاء"
                value={maxMembers}
                onChange={(e) => setMaxMembers(Number(e.target.value))}
                onBlur={() => setMaxMembersTouched(true)}
                min="2"
                max="20"
              />
              {maxMembersTouched && !isMaxMembersValid && (
                <span className="form-error-text">يجب أن يكون بين 2 و 20</span>
              )}
            </div>
          </div>

          <div className="form-row">
            <button
              type="submit"
              className="normalButton"
              disabled={loading || !isFormValid}
            >
              {loading ? "جاري النشر..." : "نشر التشكيل"}
            </button>

            <button
              type="button"
              className="normalButton"
              onClick={handleReset}
              disabled={loading}
            >
              إعادة تعيين
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default CreateTeamFormationCard;