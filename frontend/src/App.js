import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import './styles/style.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Welcome from './components/Welcome';
import Dashboard from './components/Dashboard';
import Login from './components/Login';
import Signup from './components/Signup';

function App() {
  const [user, setUser] = useState(null);
  const [dataFetched, setDataFetched] = useState(false); // Variabilă de stare pentru a urmări dacă datele au fost deja obținute
  const url = 'https://localhost:7273/api/Auth/profile';

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
      setDataFetched(true); // Actualizați variabila de stare pentru a indica că datele au fost obținute
    } catch (error) {
      console.error('Error fetching user:', error.message);
    }
  };

  useEffect(() => {
    if (!dataFetched) { // Verificați dacă datele nu au fost încă obținute
      fetchData();
    }
  }, [dataFetched]); // Apelul se face doar dacă variabila de stare dataFetched se modifică

  console.log('App User:', user);

  return (
    <div>
      <Router>
        <Routes>
          <Route path="*" Component={Welcome} />
          <Route path="/login" element={user ? <Navigate to="/dashboard" /> : <Login />} />
          <Route path="/signup" element={user ? <Navigate to="/dashboard" /> : <Signup />} />
          <Route path="/dashboard" element={user ? <Dashboard user={user} /> : <Navigate to="/login" />} />
        </Routes>
      </Router>
    </div>
  );
}
export default App;

