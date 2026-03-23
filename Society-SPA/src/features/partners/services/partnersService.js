import axios from 'axios';

const API_BASE_URL = "http://192.168.252.75:5000/api";
const authHeaders = () => {
  const token = localStorage.getItem('token');
  return token ? { Authorization: `Bearer ${token}` } : {};
};

export const getTeamFormations = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/TeamFormation`, {
      headers: authHeaders()
    });
    
    console.log('استجابة API:', response);
    console.log('بيانات الاستجابة:', response.data);

    if (Array.isArray(response.data)) {
      return response.data;
    } else if (response.data?.data && Array.isArray(response.data.data)) {
      return response.data.data;
    } else if (response.data?.items && Array.isArray(response.data.items)) {
      return response.data.items;
    } else {
      console.warn('البيانات ليست مصفوفة، رجع مصفوفة فارغة');
      return [];
    }
  } catch (error) {
    console.error('Error fetching team formations:', error);
    return [];
  }
};

export const createTeamFormation = async (data) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/TeamFormation`, data, {
      headers: authHeaders()
    });
    return response.data;
  } catch (error) {
    console.error('Error creating team formation:', error);
    throw error;
  }
}

export const getTeamFormationById = async (id) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/TeamFormation/${id}`, {
      headers: authHeaders()
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching formation by id:', error);
    throw error;
  }
};