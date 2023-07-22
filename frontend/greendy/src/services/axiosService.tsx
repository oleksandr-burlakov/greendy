import axios from "axios";
import { useEffect } from "react";
import { useNavigate } from 'react-router-dom'
import { create } from "zustand";
import { combine } from "zustand/middleware";

export const client = axios.create({
    baseURL: 'http://localhost:5269/api/',
});

export const getToken = () => localStorage.getItem("token")
  ? (localStorage.getItem("token") as string) : null;

export const useAuthStore = create(
  combine({ token: getToken() }, (set) => ({
    setToken: (token: string) => set({ token }),
    logout: () => set({ token: "" }),
  }))
);

client.interceptors.response.use(
  response => {
    return response
  },
  function (error) {
    const originalRequest = error.config

    if (error && error.response && error.response.status === 401 ) {
      localStorage.removeItem('token');
      useAuthStore.getState().logout();
      return Promise.reject(error)
    }

    return Promise.reject(error)
  }
)

client.interceptors.request.use(
  config => {
    const token = useAuthStore.getState().token;
    if (token) {
      config.headers['Authorization'] = 'Bearer ' + token
    }
    return config
  },
  error => {
    Promise.reject(error)
  }
)