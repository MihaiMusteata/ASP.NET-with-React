import React, { useState } from 'react';
import { Modal, TextField, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
import Button from 'react-bootstrap/Button';
import Grid from '@mui/material/Grid';
import { useEffect } from 'react';
const AddUserModal = ({ open, handleClose }) => {
    const [districts, setDistricts] = useState([]);
    const [regions, setRegions] = useState([]);
    const [gender, setGender] = React.useState('');
    const [role, setRole] = React.useState('');
    const [district, setDistrict] = React.useState('');
    const [region, setRegion] = React.useState('');

    useEffect(() => {
        const fetchDistricts = async () => {
            try {
                const response = await fetch('https://localhost:7273/api/Location/districts');
                const data = await response.json();
                setDistricts(data);
            } catch (error) {
                console.error('Error fetching districts:', error);
            }
        };
        fetchDistricts();
        const fetchRegions = async () => {
            try {
                const response = await fetch('https://localhost:7273/api/Location/regions');
                const data = await response.json();
                setRegions(data);
            } catch (error) {
                console.error('Error fetching regions:', error);
            }
        };
        fetchRegions();
    }, []);

    const handleChange = (event, setter) => {
        setter(event.target.value);
        console.log(event.target);
    };

    const handleSubmit = async () => {
        // convert year to number
        var data = {
            year: parseInt(document.getElementById('year').value),
            iban: document.getElementById('iban').value,
            ecoCode: document.getElementById('ecoCode').value,
            district: districts[district - 1].name,
            region: regions[region - 1].name,
        };

        const response = await fetch('https://localhost:7273/api/Dashboard/iban', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
            body: JSON.stringify(data),
        });
        console.log(JSON.stringify(data));
        console.log(response);
        handleClose();
    };

    return (
        <Modal open={open} onClose={handleClose}>
            <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', backgroundColor: 'white', padding: 20 }}>
                <h2>Add New IBAN</h2>
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        <TextField
                            autoComplete="year"
                            name="year"
                            required
                            fullWidth
                            id="year"
                            label="Year"
                            autoFocus
                            type="number" 
                            InputProps={{ inputProps: { min: 0 } }}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            autoComplete="iban"
                            name="iban"
                            required
                            fullWidth
                            id="iban"
                            label="IBAN"
                            autoFocus
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            id="ecoCode"
                            label="Eco Code "
                            name="ecoCode"
                            autoComplete="ecoCode"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="district-label">District</InputLabel>
                            <Select
                                labelId="district-label"
                                id="district"
                                label="District"
                                onChange={(event) => handleChange(event, setDistrict)}
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
                                onChange={(event) => handleChange(event, setRegion)}
                            >
                                {regions.filter(region => region.districtId === district).map((region) => (
                                    <MenuItem key={region.id} value={region.id}>{region.name}</MenuItem>
                                ))}
                            </Select>
                        </FormControl>
                    </Grid>
                </Grid>
                <div className="d-flex justify-content-center mt-4">
                    <Button variant="success" onClick={handleSubmit}>Add IBAN</Button>
                </div>
            </div>
        </Modal >
    );
};

export default AddUserModal;
