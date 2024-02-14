import React, { useState, useEffect } from 'react';
import { Modal, TextField, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
import Button from 'react-bootstrap/Button';
import Grid from '@mui/material/Grid';
import uRole from '../actions/uRole';

const EditUserModal = ({ open, handleClose, userId, users, setUsers }) => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [gender, setGender] = useState('');
    const [role, setRole] = useState('');
    const [district, setDistrict] = useState('');
    const [region, setRegion] = useState('');
    const [districts, setDistricts] = useState([]);
    const [regions, setRegions] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);

    const userData = users.find(user => user.id === userId);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const [districtsRes, regionsRes] = await Promise.all([
                    fetch('https://localhost:7273/api/Location/districts'),
                    fetch('https://localhost:7273/api/Location/regions')
                ]);
                const [districtsData, regionsData] = await Promise.all([
                    districtsRes.json(),
                    regionsRes.json()
                ]);
                setDistricts(districtsData);
                setRegions(regionsData);
                setDataLoaded(true); // Set dataLoaded to true when both districts and regions are loaded
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);

    useEffect(() => {
        if (userData && dataLoaded) {
            setUsername(userData.username);
            setGender(userData.gender);
            setEmail(userData.email);
            setDistrict(districts.find(d => d.name === userData.district)?.id);
            setRegion(regions.find(r => r.name === userData.region)?.id);
            setRole(userData.level);
        }
    }, [userData, dataLoaded, districts, regions]);


    const handleSubmit = async () => {
        const data = {
            id: userData.id,
            username: username,
            email: email,
            gender: gender,
            district: districts[parseInt(district) - 1].name,
            region: regions[parseInt(region) - 1].name,
            level: role,
        };

        try {
            console.log("Trying to update user :", data);
            const response = await fetch('https://localhost:7273/api/Dashboard/user', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                credentials: 'include',
                body: JSON.stringify(data),
            });

            if (response.ok) {
                console.log('User updated successfully');
                setUsers(users.map(user => user.id === userId ? data : user));
                handleClose();
            } else {
                console.error('Failed to update user');
            }
        } catch (error) {
            console.error('Error submitting data:', error);
        }
    };


    return (
        <Modal open={open} onClose={handleClose}>
            <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', backgroundColor: 'white', padding: 20 }}>
                <h2>Update User</h2>
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        <TextField
                            autoComplete="username"
                            name="username"
                            required
                            fullWidth
                            id="username"
                            label="Username"
                            autoFocus
                            value={username}
                            onChange={(event) => setUsername(event.target.value)}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="email"
                            autoComplete="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="gender-label">Gender</InputLabel>
                            <Select
                                labelId="gender-label"
                                id="gender"
                                label="Gender"
                                value={gender}
                                onChange={(event) => setGender(event.target.value)}
                            >
                                <MenuItem value="male">Male</MenuItem>
                                <MenuItem value="female">Female</MenuItem>
                            </Select>
                        </FormControl>
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="district-label">District</InputLabel>
                            <Select
                                labelId="district-label"
                                id="district"
                                label="District"
                                value={district}
                                onChange={(event) => setDistrict(event.target.value)}
                            >
                                {districts.map((district) => (
                                    <MenuItem key={district.id} value={district.id}>{district.name}</MenuItem>
                                ))}
                            </Select>
                        </FormControl>
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="region-label">Region</InputLabel>
                            <Select
                                labelId="region-label"
                                id="region"
                                label="Region"
                                value={region}
                                onChange={(event) => setRegion(event.target.value)}
                            >
                                {regions.filter(r => r.districtId === parseInt(district)).map((region) => (
                                    <MenuItem key={region.id} value={region.id}>{region.name}</MenuItem>
                                ))}
                            </Select>
                        </FormControl>
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="role-label">Role</InputLabel>
                            <Select
                                labelId="role-label"
                                id="role"
                                label="Role"
                                value={role}
                                onChange={(event) => setRole(event.target.value)}
                            >
                                <MenuItem value={2}>Operator</MenuItem>
                                <MenuItem value={3}>Operator Raion</MenuItem>
                            </Select>
                        </FormControl>
                    </Grid>
                </Grid>
                <div className="d-flex justify-content-center mt-4">
                    <Button variant="success" onClick={handleSubmit}>Update User</Button>
                </div>
            </div>
        </Modal>
    );
};

export default EditUserModal;
