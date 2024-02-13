import * as React from 'react';
import Link from '@mui/material/Link';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Typography from '@mui/material/Typography';
import { Button } from 'react-bootstrap';
import Grid from '@mui/material/Grid';
import { useState, useEffect } from 'react';
import { ApiGetRequest } from '../actions/api';

export default function RegionIBANs({ user, setUser }) {
  const [open, setOpen] = useState(false);
  const [ibans, setIbans] = useState([]);

  useEffect(() => {
    const fetchIBANs = async () => {
      try {
        const response = await fetch('https://localhost:7273/api/Dashboard/region_ibans?region=' + user.region);
        const data = await response.json();
        console.log("IBANs data:", data);
        setIbans(data);
      } catch (error) {
        console.error('Error fetching IBANs:', error);
      }
    };

    fetchIBANs();
  }, [open]); 

  console.log('IBANs:', ibans);

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <React.Fragment>
      <Grid container justifyContent="space-between" alignItems="center">
        <Typography component="h2" variant="h6" color="primary" gutterBottom>
          IBANs List for {user.region}
        </Typography>
      </Grid>

      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Year</TableCell>
            <TableCell>IBAN</TableCell>
            <TableCell>Eco Code</TableCell>
            <TableCell>District</TableCell>
            <TableCell>Region</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {ibans.map((iban) => (
            <TableRow key={iban.id}>
              <TableCell>{iban.year}</TableCell>
              <TableCell>{iban.iban}</TableCell>
              <TableCell>{iban.ecoCode}</TableCell>
              <TableCell>{iban.district}</TableCell>
              <TableCell>{iban.region}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <Link color="primary" href="#" onClick={(event) => event.preventDefault()} sx={{ mt: 3 }}>
        See more
      </Link>
    </React.Fragment>
  );
}
