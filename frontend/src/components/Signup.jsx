import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { FormControl, InputLabel, Select, MenuItem } from '@mui/material';
import { useState, useEffect } from 'react';

import { ApiPostRequest } from '../actions/api';

export default function Signup() {

  const [districts, setDistricts] = useState([]);
  const [regions, setRegions] = useState([]);
  const [gender, setGender] = React.useState('');
  const [district, setDistrict] = React.useState('');
  const [region, setRegion] = React.useState('');

  const handleChange = (event, setter) => {
    setter(event.target.value);
    console.log(event.target);
  };


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

  console.log('Districts:', districts);
  console.log('Regions:', regions);

  const handleSignup = async () => {
    var email = document.getElementById('email').value;
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var confirmPassword = document.getElementById('confirm-password').value;
    
    var data = {
      email: email,
      username: username,
      password: password,
      confirmPassword: confirmPassword,
      gender: gender,
      district: districts[district - 1].name,
      region: regions[region - 1].name,
      loginIp: '',
      loginDateTime: '2021-10-10T10:10:10'
    };
    alert(JSON.stringify(data));
    await ApiPostRequest('SIGNUP', data, { 'Content-Type': 'application/json' });
    window.location.href = '/login';
  }

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <Box component="form" noValidate onSubmit={handleSignup} sx={{ mt: 3 }}>
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
                  value={gender}
                  onChange={(event) => handleChange(event, setGender)}
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
                  {regions.filter((region) => region.districtId === district).map((region) => (
                    <MenuItem key={region.id} value={region.id}>{region.name}</MenuItem>
                  ))}
                </Select>
              </FormControl>
            </Grid>

          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign Up
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link href="/login" variant="body2">
                Already have an account? Login
              </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
}