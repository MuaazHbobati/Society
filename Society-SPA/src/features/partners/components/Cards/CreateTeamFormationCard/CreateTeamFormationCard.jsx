// features/partners/components/Cards/CreateTeamFormationCard/CreateTeamFormationCard.jsx
import React, { useState, useEffect } from "react";
import { createTeamFormation } from "../../../services/partnersService";
import {getAllPrograms, getSubjectsByProgram,} from "../../../services/programService";
import "./CreateTeamFormationCard.css";

const CreateTeamFormationCard = ({ onFormationCreated }) => {
   
  const [programs, setPrograms] = useState([]);
  const [subjects, setSubjects] = useState([]);
  const [loadingPrograms, setLoadingPrograms] = useState(false);
  const [loadingSubjects, setLoadingSubjects] = useState(false);

  
  const [tutorName, setTutorName] = useState("");
  const [description, setDescription] = useState("");
  const [className, setClassName] = useState("");
  const [programId, setProgramId] = useState("");
  const [subjectId, setSubjectId] = useState("");
  const [maxMembers, setMaxMembers] = useState(20);

  const [tutorNameTouched, setTutorNameTouched] = useState(false);
  const [descriptionTouched, setDescriptionTouched] = useState(false);
  const [classNameTouched, setClassNameTouched] = useState(false);
  const [programIdTouched, setProgramIdTouched] = useState(false);
  const [subjectIdTouched, setSubjectIdTouched] = useState(false);
  const [maxMembersTouched, setMaxMembersTouched] = useState(false);

  const [loading, setLoading] = useState(false);
  const [apiError, setApiError] = useState("");

  
  useEffect(() => {
    fetchPrograms();
  }, []);
  
  useEffect(() => {
    if (programId) {
      fetchSubjectsByProgram(programId);
      setSubjectId("");
    } else {
      setSubjects([]);
    }
  }, [programId]);

  const fetchPrograms = async () => {
    setLoadingPrograms(true);
    try {
      const data = await getAllPrograms();
      setPrograms(data || []);
    } catch (error) {
      console.error("Failed to fetch programs:", error);
    } finally {
      setLoadingPrograms(false);
    }
  };

  const fetchSubjectsByProgram = async (id) => {
    setLoadingSubjects(true);
    try {
      const data = await getSubjectsByProgram(id);
      setSubjects(data || []);
    } catch (error) {
      console.error("Failed to fetch subjects:", error);
    } finally {
      setLoadingSubjects(false);
    }
  };

  const isTutorNameValid = tutorName.trim().length >= 3;
  const isDescriptionValid = description.trim().length >= 10;
  const isClassNameValid =
    className.trim().length >= 1 && className.trim().length <= 5;
  const isProgramIdValid = programId !== "" && Number(programId) > 0;
  const isSubjectIdValid = subjectId !== "" && Number(subjectId) > 0;
  const isMaxMembersValid = maxMembers >= 2 && maxMembers <= 20;

  const isFormValid =
    isTutorNameValid &&
    isDescriptionValid &&
    isClassNameValid &&
    isProgramIdValid &&
    isSubjectIdValid &&
    isMaxMembersValid;

  const handleSubmit = async (e) => {
    e.preventDefault();

    setTutorNameTouched(true);
    setDescriptionTouched(true);
    setClassNameTouched(true);
    setProgramIdTouched(true);
    setSubjectIdTouched(true);
    setMaxMembersTouched(true);

    if (!isFormValid) return;

    setLoading(true);
    setApiError("");

    const dataToSend = {
      tutorName,
      description,
      className,
      programId: Number(programId),
      subjectId: Number(subjectId),
      maxMembers: Number(maxMembers),
    };

    try {
      const newFormation = await createTeamFormation(dataToSend);
      onFormationCreated(newFormation);

      setTutorName("");
      setDescription("");
      setClassName("");
      setProgramId("");
      setSubjectId("");
      setMaxMembers(20);

      setTutorNameTouched(false);
      setDescriptionTouched(false);
      setClassNameTouched(false);
      setProgramIdTouched(false);
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
    setProgramId("");
    setSubjectId("");
    setMaxMembers(20);

    setTutorNameTouched(false);
    setDescriptionTouched(false);
    setClassNameTouched(false);
    setProgramIdTouched(false);
    setSubjectIdTouched(false);
    setMaxMembersTouched(false);

    setApiError("");
  };

  return (
    <div className="create-formation-card">
      <div className="create-form">
        <h3>تشكيل فريق جديد</h3>

        {apiError && <div className="form-error api-error">{apiError}</div>}

        <form onSubmit={handleSubmit} noValidate>
          <div className="form-grid">
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

            {/* الوصف كامل العرض */}
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

            {/* البرنامج والمادة */}
            <div className="form-group form-col-half">
              <label htmlFor="programId">البرنامج</label>
              <select
                id="programId"
                className={`form-input ${programIdTouched && !isProgramIdValid ? "error" : ""}`}
                value={programId}
                onChange={(e) => setProgramId(e.target.value)}
                onBlur={() => setProgramIdTouched(true)}
                disabled={loadingPrograms}
              >
                <option value="">-- اختر البرنامج --</option>
                {programs.map((program) => (
                  <option key={program.id} value={program.id}>
                    {program.name}
                  </option>
                ))}
              </select>
              {programIdTouched && !isProgramIdValid && (
                <span className="form-error-text">الرجاء اختيار البرنامج</span>
              )}
              {loadingPrograms && (
                <span className="loading-text">جاري تحميل البرامج...</span>
              )}
            </div>

            <div className="form-group form-col-half">
              <label htmlFor="subjectId">المادة</label>
              <select
                id="subjectId"
                className={`form-input ${subjectIdTouched && !isSubjectIdValid ? "error" : ""}`}
                value={subjectId}
                onChange={(e) => setSubjectId(e.target.value)}
                onBlur={() => setSubjectIdTouched(true)}
                disabled={!programId || loadingSubjects}
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
              {loadingSubjects && (
                <span className="loading-text">جاري تحميل المواد...</span>
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
              disabled={loading || loadingPrograms || !isFormValid}
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