import axios from 'axios';
import {API_BASE_URL} from "../../../shared/api/API_BASE_URL.js"

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

export const getMySubjects = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/Program/my-subjects`, {
      headers: authHeaders()
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching my subjects:', error);
    return [];
  }
};