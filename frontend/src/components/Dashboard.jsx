import React, { useState, useEffect } from 'react';
import { ApiPostRequest } from '../actions/api';
import Cookies from 'js-cookie';

const Dashboard = ({ user, setUser }) => {
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(false);
            } catch (error) {
                console.error('Error fetching user:', error.message);
                setLoading(false);
            }
        };
        fetchData();
    }, [setUser]);


    const handleLogout = async () => {
        Cookies.remove('X-Key');
        setUser(null);
        try {
            const userId = user.id;
            const response = await fetch('https://localhost:7273/api/Auth/logout?userId=' + userId, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ userId: userId }),
            });

            if (response.ok) {
                console.log('Logout successful for user:', user.id);
            } else {
                const errorData = await response.json();
                console.error(`Logout failed: ${errorData}`);
            }
        } catch (error) {
            console.error(`Error during logout: ${error.message}`);
        }
    };

    if (loading) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h1>Dashboard</h1>
            <p>Bun venit, {user ? user.username : 'Oaspete'}</p>
            <button onClick={handleLogout}>Deconectare</button>
            {/* Restul conținutului pentru Dashboard */}
        </div>
    );
};

export default Dashboard;
