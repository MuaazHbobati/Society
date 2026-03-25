// features/partners/pages/PartnerPage/PartnerPage.jsx
import React, { useState, useEffect, useCallback, useRef } from 'react';
import { getFormations } from '../../services/partnersService';
import { getMySubjects } from '../../services/programService';
import CreateTeamFormationCard from '../../components/Cards/CreateTeamFormationCard/CreateTeamFormationCard.jsx';
import TeamFormationCard from '../../components/Cards/TeamFormationCard/TeamFormationCard.jsx';
import './PartnerPage.css';

const PartnerPage = () => {
  const [formations, setFormations] = useState([]);
  const [loading, setLoading] = useState(false);
  const [loadingMore, setLoadingMore] = useState(false);
  const [error, setError] = useState(null);
  const [hasMore, setHasMore] = useState(true);
  const [lastId, setLastId] = useState(null);
  
  // الفلاتر
  const [subjects, setSubjects] = useState([]);
  const [selectedSubjectId, setSelectedSubjectId] = useState(null);
  const [searchTerm, setSearchTerm] = useState('');
  const [loadingSubjects, setLoadingSubjects] = useState(false);
  
  const observerRef = useRef();

  // جلب المواد
  useEffect(() => {
    const fetchSubjects = async () => {
      setLoadingSubjects(true);
      try {
        const data = await getMySubjects();
        setSubjects(data || []);
      } catch (err) {
        console.error('Error fetching subjects:', err);
      } finally {
        setLoadingSubjects(false);
      }
    };
    fetchSubjects();
  }, []);

  // جلب التشكيلات
  const fetchFormations = useCallback(async (reset = false) => {
    if (loadingMore) return;
    
    const isLoading = reset ? setLoading : setLoadingMore;
    isLoading(true);
    
    try {
      const data = await getFormations(
        selectedSubjectId,
        reset ? null : lastId,
        searchTerm || null
      );
      
      if (reset) {
        setFormations(data.items || []);
      } else {
        setFormations(prev => [...prev, ...(data.items || [])]);
      }
      
      setHasMore(data.hasMore);
      
      if (data.items && data.items.length > 0) {
        setLastId(data.items[data.items.length - 1].id);
      }
      
      setError(null);
    } catch (err) {
      console.error('Error fetching formations:', err);
      setError('فشل في تحميل التشكيلات');
    } finally {
      isLoading(false);
    }
  }, [selectedSubjectId, lastId, searchTerm, loadingMore]);

  // إعادة تعيين عند تغيير الفلاتر
  useEffect(() => {
    setFormations([]);
    setLastId(null);
    setHasMore(true);
    fetchFormations(true);
  }, [selectedSubjectId, searchTerm]);

  // Intersection Observer
  const lastFormationRef = useCallback(node => {
    if (loadingMore) return;
    if (observerRef.current) observerRef.current.disconnect();
    
    observerRef.current = new IntersectionObserver(entries => {
      if (entries[0].isIntersecting && hasMore && !loadingMore) {
        fetchFormations(false);
      }
    });
    
    if (node) observerRef.current.observe(node);
  }, [loadingMore, hasMore, fetchFormations]);

  const handleSubjectChange = (subjectId) => {
    setSelectedSubjectId(subjectId === '' ? null : parseInt(subjectId));
  };

  const handleFormationCreated = (newFormation) => {
    setFormations(prev => [newFormation, ...prev]);
  };

  return (
    <div className="partner-page">
      {/* نموذج إنشاء تشكيل */}
      <div className="create-section">
        <CreateTeamFormationCard onFormationCreated={handleFormationCreated} />
      </div>
      
      {/* الفلاتر */}
      <div className="filters-section">
        <div className="filters-container">
          {/* فلتر المواد */}
          <div className="subject-filters">
            <button
              className={`filter-btn ${!selectedSubjectId ? 'active' : ''}`}
              onClick={() => handleSubjectChange('')}
            >
              جميع المواد
            </button>
            {subjects.map(subject => (
              <button
                key={subject.id}
                className={`filter-btn ${selectedSubjectId === subject.id ? 'active' : ''}`}
                onClick={() => handleSubjectChange(subject.id)}
              >
                {subject.name}
              </button>
            ))}
            {loadingSubjects && <span className="loading-text">جاري تحميل المواد...</span>}
          </div>
          
          {/* شريط البحث */}
          <div className="search-wrapper">
            <input
              type="text"
              placeholder="🔍 بحث عن تشكيلات..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="search-input"
            />
          </div>
        </div>
      </div>
      
      {/* البطاقات */}
      <div className="formations-section">
        {loading && formations.length === 0 && (
          <div className="loading-state">
            <div className="spinner"></div>
            <p>جاري تحميل التشكيلات...</p>
          </div>
        )}
        
        {error && (
          <div className="error-state">
            <p className="error-message">{error}</p>
            <button onClick={() => fetchFormations(true)}>إعادة المحاولة</button>
          </div>
        )}
        
        {!loading && !error && formations.length === 0 && (
          <div className="empty-state">
            <p>لا توجد تشكيلات متاحة حالياً</p>
          </div>
        )}
        
        <div className="formations-grid">
          {formations.map((formation, index) => {
            if (index === formations.length - 1) {
              return (
                <div ref={lastFormationRef} key={formation.id}>
                  <TeamFormationCard formation={formation} />
                </div>
              );
            }
            return <TeamFormationCard key={formation.id} formation={formation} />;
          })}
        </div>
        
        {loadingMore && (
          <div className="loading-more">
            <div className="spinner-small"></div>
            <p>جاري تحميل المزيد...</p>
          </div>
        )}
        
        {!hasMore && formations.length > 0 && (
          <div className="no-more">
            <p>لقد وصلت إلى النهاية</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default PartnerPage;