import AppRoutes from './AppRoutes.js';
import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import './styles/style.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Weather from './components/Weather';
import Welcome from './components/Welcome';
import NavBar from './components/NavBar';
import Authentication from './components/Authentication';
import Dashboard from './components/Dashboard';
import AdminPanel from './components/AdminPanel';

function App() {
  const [user, setUser] = useState(null);
  const url = 'https://localhost:7273/api/Auth/profile';
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(url, {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
          credentials: 'include',
        });
  
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
  
        const data = await response.json();
        setUser(data);
      } catch (error) {
        console.error('Error fetching user:', error.message);
      }
    };
  
    fetchData();
  }, []);
  
  console.log('App User:', user);
  


  return (
    <div>
      <Router>
        <NavBar />
        <Routes>
          <Route path="/" Component={AdminPanel} />
          <Route path="*" Component={Welcome} />
          <Route path="/weather" Component={Weather} />
          <Route path="/authentication" element={user ? <Navigate to="/" /> : <Authentication />} />
          {/* <Route path="/dashboard" element={user ? <Dashboard user={user} /> : <Navigate to="/authentication" />} /> */}
          <Route path="/dashboard" element={<Dashboard user={user} setUser={setUser} />} />

        </Routes>
      </Router>
    </div>
  );
}
export default App;

