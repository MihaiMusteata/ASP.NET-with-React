import React, { useState, useEffect } from 'react';
import { Modal, TextField, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
import Button from 'react-bootstrap/Button';
import Grid from '@mui/material/Grid';

const EditIBANModal = ({ open, handleClose, ibanId, ibans, setIbans }) => {
    const [districts, setDistricts] = useState([]);
    const [regions, setRegions] = useState([]);
    const [district, setDistrict] = useState('');
    const [region, setRegion] = useState('');
    const [dataLoaded, setDataLoaded] = useState(false);
    const [iban, setIban] = useState('');
    const [year, setYear] = useState('');
    const [ecoCode, setEcoCode] = useState('');

    const ibanData = ibans.find(iban => iban.id === ibanId);

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
                setDataLoaded(true);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);

    const handleChange = (event, setter) => {
        setter(event.target.value);
    };

    useEffect(() => {
        if (ibanData && dataLoaded) {
            setIban(ibanData.iban);
            setYear(ibanData.year);
            setEcoCode(ibanData.ecoCode);
            setDistrict(districts.find(d => d.name === ibanData.district)?.id);
            setRegion(regions.find(r => r.name === ibanData.region)?.id);
        }
    }, [ibanData, dataLoaded, districts, regions]);

    const handleSubmit = async () => {
        const data = {
            id: ibanId,
            iban: iban,
            year: year,
            ecoCode: ecoCode,
            district: districts[parseInt(district) - 1].name,
            region: regions[parseInt(region) - 1].name,
        };

        try {
            const response = await fetch('https://localhost:7273/api/Dashboard/iban', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                console.log('IBAN updated successfully');
                setIbans(ibans.map(iban => iban.id === ibanId ? data : iban));
                handleClose();
            } else {
                console.error('Failed to update IBAN');
            }
        } catch (error) {
            console.error('Error submitting data:', error);
        }
    };

    return (
        <Modal open={open} onClose={handleClose}>
            <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', backgroundColor: 'white', padding: 20 }}>
                <h2>Update IBAN</h2>
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
                            value={year}
                            onChange={(event) => handleChange(event, setYear)}
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
                            value={iban}
                            onChange={(event) => handleChange(event, setIban)}
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
                            value={ecoCode}
                            onChange={(event) => handleChange(event, setEcoCode)}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth>
                            <InputLabel id="district-label">District</InputLabel>
                            <Select
                                labelId="district-label"
                                id="district"
                                label="District"
                                value={district}
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
                                value={region}
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
                    <Button variant="success" onClick={handleSubmit}>Update IBAN</Button>
                </div>
            </div>
        </Modal >
    );
};

export default EditIBANModal;
