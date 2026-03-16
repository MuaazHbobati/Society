// features/partners/services/programService.js
import axios from 'axios';

const API_BASE_URL = "http://192.168.1.109:5000/api";

const authHeaders = () => {
  const token = localStorage.getItem('token');
  return token ? { Authorization: `Bearer ${token}` } : {};
};

export const getAllPrograms = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/Program/programs`, {
      headers: authHeaders()
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching programs:', error);
    return [];
  }
};

export const getSubjectsByProgram = async (programId) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/Program/subjects/${programId}`, {
      headers: authHeaders()
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching subjects:', error);
    return [];
  }
};