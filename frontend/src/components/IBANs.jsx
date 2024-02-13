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
import AddIBANModal from './AddIBANModal';
import { useState, useEffect } from 'react';
import { ApiGetRequest } from '../actions/api';

export default function IBANs() {
  const [open, setOpen] = useState(false);
  const [ibans, setIbans] = useState([]);

  useEffect(() => {
    const fetchIBANs = async () => {
      try {
        const response = await fetch('https://localhost:7273/api/Dashboard/ibans');
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

  const handleDelete = (id) => {
    fetch('https://localhost:7273/api/Dashboard/iban?ibanId=' + id, {
      method: 'DELETE',
    })
      .then((response) => response.json())
      .then((data) => {
        console.log('IBAN deleted:', data);
        setIbans(ibans.filter(iban => iban.id !== id));
      })
      .catch((error) => {
        console.error('Error deleting IBAN:', error);
      });
  };

  return (
    <React.Fragment>
      <Grid container justifyContent="space-between" alignItems="center">
        <Typography component="h2" variant="h6" color="primary" gutterBottom>
          IBANs List
        </Typography>
        <Grid item>
          <Button variant="success" color="success" className="m-1" onClick={handleOpen}>
            Add new IBAN
          </Button>
          <AddIBANModal open={open} handleClose={handleClose} />
        </Grid>
      </Grid>

      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Year</TableCell>
            <TableCell>IBAN</TableCell>
            <TableCell>Eco Code</TableCell>
            <TableCell>District</TableCell>
            <TableCell>Region</TableCell>
            <TableCell>Actions</TableCell>
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
              <TableCell>
                <Button variant="primary" className="m-1">
                  Edit
                </Button>
                <Button variant="danger" className="m-1" onClick={() => handleDelete(iban.id)}>
                  Delete
                </Button>
              </TableCell>
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
