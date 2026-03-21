// features/partners/pages/PartnerPage/PartnerPage.jsx
import React, { useState, useEffect } from 'react';
import { getTeamFormations } from '../../services/partnersService';
import CreateTeamFormationCard from '../../components/Cards/CreateTeamFormationCard/CreateTeamFormationCard.jsx';
import TeamFormationCard from '../../components/Cards/TeamFormationCard/TeamFormationCard.jsx';
import './PartnerPage.css';

const PartnerPage = () => {
  const [formations, setFormations] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [searchTerm, setSearchTerm] = useState('');
  const [filter, setFilter] = useState('all'); // all, open, closed, full

  useEffect(() => {
    const fetchFormations = async () => {
      try {
        setLoading(true);
        const data = await getTeamFormations();
        console.log('📦 البيانات:', data);
        setFormations(Array.isArray(data) ? data : []);
        setError(null);
      } catch (err) {
        console.error('❌ خطأ:', err);
        setError('فشل في تحميل البيانات');
        setFormations([]);
      } finally {
        setLoading(false);
      }
    };

    fetchFormations();
  }, []);

  const handleFormationCreated = (newFormation) => {
    setFormations(prev => [newFormation, ...prev]);
  };

  // تصفية التشكيلات
  const filteredFormations = formations.filter(formation => {
    // فلتر البحث
    const matchesSearch = 
      (formation.title?.toLowerCase().includes(searchTerm.toLowerCase()) ||
      formation.description?.toLowerCase().includes(searchTerm.toLowerCase()) ||
      formation.programName?.toLowerCase().includes(searchTerm.toLowerCase()));
    
    // فلتر الحالة
    if (filter === 'all') return matchesSearch;
    if (filter === 'open') return matchesSearch && formation.status === 0;
    if (filter === 'full') return matchesSearch && formation.status === 1;
    if (filter === 'closed') return matchesSearch && formation.status === 2;
    
    return matchesSearch;
  });

  return (
    <div className="partner-page">
    
      <div className="filters-section">
        <div className="filters-container">
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

          {/* أزرار التصفية */}
          <div className="filter-buttons">
            <button
              className={`filter-btn ${filter === 'all' ? 'active' : ''}`}
              onClick={() => setFilter('all')}
            >
              الكل
            </button>
            <button
              className={`filter-btn ${filter === 'open' ? 'active' : ''}`}
              onClick={() => setFilter('open')}
            >
              <span className="status-dot open"></span>
              مفتوح
            </button>
            <button
              className={`filter-btn ${filter === 'full' ? 'active' : ''}`}
              onClick={() => setFilter('full')}
            >
              <span className="status-dot full"></span>
              مكتمل
            </button>
            <button
              className={`filter-btn ${filter === 'closed' ? 'active' : ''}`}
              onClick={() => setFilter('closed')}
            >
              <span className="status-dot closed"></span>
              مغلق
            </button>
          </div>
        </div>
      </div>
        
      <div className="create-section">
        <CreateTeamFormationCard onFormationCreated={handleFormationCreated} />
      </div>

      {/* 3. البطاقات - في الأسفل */}
      <div className="formations-section">
        {loading && (
          <div className="loading-state">
            <div className="spinner"></div>
            <p>جاري تحميل التشكيلات...</p>
          </div>
        )}
        
        {error && (
          <div className="error-state">
            <p className="error-message">{error}</p>
            <button onClick={() => window.location.reload()}>إعادة المحاولة</button>
          </div>
        )}
        
        {!loading && !error && filteredFormations.length === 0 && (
          <div className="empty-state">
            <p>لا توجد تشكيلات متاحة حالياً</p>
          </div>
        )}
        
        <div className="formations-grid">
          {filteredFormations.map(formation => (
            <TeamFormationCard key={formation.id} formation={formation} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default PartnerPage;