// features/partners/components/Cards/CreateTeamFormationCard/CreateTeamFormationCard.jsx
import React, { useState, useEffect } from 'react';
import { createTeamFormation } from '../../../services/partnersService';
import { getAllPrograms, getSubjectsByProgram } from '../../../services/programService';

const CreateTeamFormationCard = ({ onFormationCreated }) => {
  // State للقوائم المنسدلة
  const [programs, setPrograms] = useState([]);
  const [subjects, setSubjects] = useState([]);
  const [loadingPrograms, setLoadingPrograms] = useState(false);
  const [loadingSubjects, setLoadingSubjects] = useState(false);

  // State للحقول
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [programId, setProgramId] = useState(''); // Program ID
  const [subjectId, setSubjectId] = useState(''); // Subject ID
  const [maxMembers, setMaxMembers] = useState(20);

  // Flags للتحقق
  const [titleTouched, setTitleTouched] = useState(false);
  const [descriptionTouched, setDescriptionTouched] = useState(false);
  const [programIdTouched, setProgramIdTouched] = useState(false);
  const [subjectIdTouched, setSubjectIdTouched] = useState(false);
  const [maxMembersTouched, setMaxMembersTouched] = useState(false);

  const [loading, setLoading] = useState(false);
  const [apiError, setApiError] = useState('');

  // ✅ جلب البرامج عند تحميل المكون
  useEffect(() => {
    fetchPrograms();
  }, []);

  // ✅ جلب المواد عند تغيير البرنامج
  useEffect(() => {
    if (programId) {
      fetchSubjectsByProgram(programId);
      setSubjectId(''); // إعادة تعيين المادة المختارة
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
      console.error('Failed to fetch programs:', error);
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
      console.error('Failed to fetch subjects:', error);
    } finally {
      setLoadingSubjects(false);
    }
  };

  // دوال التحقق
  const isTitleValid = title.trim() !== '' && title.length >= 3;
  const isDescriptionValid = description.trim() !== '' && description.length >= 10;
  const isProgramIdValid = programId !== '' && Number(programId) > 0;
  const isSubjectIdValid = subjectId !== '' && Number(subjectId) > 0;
  const isMaxMembersValid = maxMembers >= 2 && maxMembers <= 100;

  const isFormValid = 
    isTitleValid &&
    isDescriptionValid &&
    isProgramIdValid &&
    isSubjectIdValid &&
    isMaxMembersValid;

  const handleSubmit = async (e) => {
    e.preventDefault();

    setTitleTouched(true);
    setDescriptionTouched(true);
    setProgramIdTouched(true);
    setSubjectIdTouched(true);
    setMaxMembersTouched(true);

    if (!isFormValid) return;

    setLoading(true);
    setApiError('');

    const dataToSend = {
      title,
      description,
      programId: Number(programId),
      subjectId: Number(subjectId), // هذا هو ProgramSubjectId
      maxMembers: Number(maxMembers)
    };

    try {
      const newFormation = await createTeamFormation(dataToSend);
      onFormationCreated(newFormation);
      
      // Reset form
      setTitle('');
      setDescription('');
      setProgramId('');
      setSubjectId('');
      setMaxMembers(20);
      
      setTitleTouched(false);
      setDescriptionTouched(false);
      setProgramIdTouched(false);
      setSubjectIdTouched(false);
      setMaxMembersTouched(false);
      
    } catch (error) {
      setApiError(error.response?.data?.message || 'فشل إنشاء التشكيل. حاول مرة أخرى');
      console.error('Failed to create formation', error);
    } finally {
      setLoading(false);
    }
  };

  const handleReset = () => {
    setTitle('');
    setDescription('');
    setProgramId('');
    setSubjectId('');
    setMaxMembers(20);
    
    setTitleTouched(false);
    setDescriptionTouched(false);
    setProgramIdTouched(false);
    setSubjectIdTouched(false);
    setMaxMembersTouched(false);
    
    setApiError('');
  };

  return (
    <div className="form-container">
      <h3 className="form-title">تشكيل فريق جديد</h3>
      
      {apiError && (
        <div className="form-error api-error">{apiError}</div>
      )}
      
      <form onSubmit={handleSubmit} noValidate>
        <div className="form-grid">
          {/* العنوان */}
          <div className="form-group form-col-full">
            <label htmlFor="title">العنوان</label>
            <input
              id="title"
              type="text"
              className={`form-input ${titleTouched && !isTitleValid ? 'error' : ''}`}
              placeholder="مثال: برمجة ويب 1"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              onBlur={() => setTitleTouched(true)}
            />
            {titleTouched && !isTitleValid && (
              <span className="form-error-text">العنوان مطلوب (3 أحرف على الأقل)</span>
            )}
          </div>

          {/* الوصف */}
          <div className="form-group form-col-full">
            <label htmlFor="description">الوصف</label>
            <textarea
              id="description"
              className={`form-input ${descriptionTouched && !isDescriptionValid ? 'error' : ''}`}
              placeholder="مثال: نحتاج الى مصمم للواجهة، منسق للتقرير على Word."
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              onBlur={() => setDescriptionTouched(true)}
              rows="4"
            />
            {descriptionTouched && !isDescriptionValid && (
              <span className="form-error-text">الوصف مطلوب (10 أحرف على الأقل)</span>
            )}
          </div>

          {/* 🔽 البرنامج - Dropdown */}
          <div className="form-group form-col-half">
            <label htmlFor="programId">البرنامج</label>
            <select
              id="programId"
              className={`form-input ${programIdTouched && !isProgramIdValid ? 'error' : ''}`}
              value={programId}
              onChange={(e) => setProgramId(e.target.value)}
              onBlur={() => setProgramIdTouched(true)}
              disabled={loadingPrograms}
            >
              <option value="">-- اختر البرنامج --</option>
              {programs.map(program => (
                <option key={program.id} value={program.id}>
                  {program.name}
                </option>
              ))}
            </select>
            {programIdTouched && !isProgramIdValid && (
              <span className="form-error-text">الرجاء اختيار البرنامج</span>
            )}
            {loadingPrograms && <span className="loading-text">جاري تحميل البرامج...</span>}
          </div>

          {/* 🔽 المادة - Dropdown (مش Enabled إذا ما في برنامج) */}
          <div className="form-group form-col-half">
            <label htmlFor="subjectId">المادة</label>
            <select
              id="subjectId"
              className={`form-input ${subjectIdTouched && !isSubjectIdValid ? 'error' : ''}`}
              value={subjectId}
              onChange={(e) => setSubjectId(e.target.value)}
              onBlur={() => setSubjectIdTouched(true)}
              disabled={!programId || loadingSubjects}
            >
              <option value="">-- اختر المادة --</option>
              {subjects.map(subject => (
                <option key={subject.id} value={subject.id}>
                  {subject.name}
                </option>
              ))}
            </select>
            {subjectIdTouched && !isSubjectIdValid && (
              <span className="form-error-text">الرجاء اختيار المادة</span>
            )}
            {loadingSubjects && <span className="loading-text">جاري تحميل المواد...</span>}
          </div>

          {/* الحد الأقصى للأعضاء */}
          <div className="form-group form-col-half">
            <label htmlFor="maxMembers">الحد الأقصى للأعضاء</label>
            <input
              id="maxMembers"
              type="number"
              className={`form-input ${maxMembersTouched && !isMaxMembersValid ? 'error' : ''}`}
              placeholder="الحد الأقصى للأعضاء"
              value={maxMembers}
              onChange={(e) => setMaxMembers(Number(e.target.value))}
              onBlur={() => setMaxMembersTouched(true)}
              min="2"
              max="100"
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
            disabled={loading || loadingPrograms}
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
  );
};

export default CreateTeamFormationCard;