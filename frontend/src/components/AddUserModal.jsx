import React, { useState } from 'react';
import { Modal, TextField, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
import Button from 'react-bootstrap/Button';
import Grid from '@mui/material/Grid';
const AddUserModal = ({ open, handleClose }) => {
    const [userData, setUserData] = useState({
        username: '',
        email: '',
        password: '',
        gender: '',
        role: ''
    });

    const handleChange = (e) => {
        setUserData({ ...userData, [e.target.name]: e.target.value });
    };

    const handleSubmit = () => {
        console.log(userData);
        handleClose();
    };

    return (
        <Modal open={open} onClose={handleClose}>
            <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', backgroundColor: 'white', padding: 20 }}>
                <h2>Add New User</h2>
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
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            autoComplete="new-password"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            name="confirm-password"
                            label="Confirm Password"
                            type="password"
                            id="confirm-password"
                            autoComplete="new-password"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="gender-label">Gender</InputLabel>
                            <Select
                                labelId="gender-label"
                                id="gender"
                                label="Gender"
                                onChange={handleChange}
                            >
                                <MenuItem value="male">Male</MenuItem>
                                <MenuItem value="female">Female</MenuItem>
                            </Select>
                        </FormControl>
                    </Grid>
                    {/* role */}
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="role-label">Role</InputLabel>
                            <Select
                                labelId="role-label"
                                id="role"
                                label="Role"
                                onChange={handleChange}
                            >
                                <MenuItem value="1">Operator</MenuItem>
                                <MenuItem value="2">Operator Raion</MenuItem>
                            </Select>
                        </FormControl>
                    </Grid>
                </Grid>
                <div className="d-flex justify-content-center mt-4">
                    <Button variant="success" onClick={handleSubmit}>Add User</Button>
                </div>
            </div>
        </Modal>
    );
};

export default AddUserModal;
