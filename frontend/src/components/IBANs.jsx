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
import EditIBANModal from './EditIBANModal';
import { TextField } from '@mui/material';
import { useState, useEffect } from 'react';

export default function IBANs() {
  const [open, setOpen] = useState(false);
  const [ibans, setIbans] = useState([]);
  const [edit, setEdit] = useState(false);
  const [ibanId, setIbanId] = useState({});
  const [year, setYear] = useState({});

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


  const handleChange = (event) => {
    setYear(event.target.value);
  }

  const handleEdit = (id) => {
    setIbanId(id);
    setEdit(true);
  };

  const handleCloseEdit = () => {
    setEdit(false);
  };

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  async function handleDownload(year) {
    try {
      const response = await fetch(`https://localhost:7273/api/Dashboard/registry?year=${year}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
        credentials: 'include',
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const blob = await response.blob();

      const contentDisposition = response.headers.get('Content-Disposition');
      let fileName = 'registry_' + year + '.csv';
      if (contentDisposition) {
        const fileNameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
        const matches = fileNameRegex.exec(contentDisposition);
        if (matches != null && matches[1]) {
          fileName = matches[1].replace(/['"]/g, '');
        }
      }

      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = fileName;
      document.body.appendChild(a);
      a.click();

      window.URL.revokeObjectURL(url);
    } catch (error) {
      console.error('There was a problem with the fetch operation:', error);
    }
  }

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
        <AddIBANModal open={open} handleClose={handleClose} />
        <EditIBANModal open={edit} handleClose={handleCloseEdit} ibanId={ibanId} ibans={ibans} setIbans={setIbans} />
        <Grid container alignItems="center" justify="flex-end" spacing={2}>
          <Grid item>
            <TextField
              autoComplete="year"
              name="year"
              required
              id="year"
              label="Year"
              type="number"
              InputProps={{ inputProps: { min: 0 } }}
              onChange={(event) => handleChange(event)}
            />
          </Grid>
          <Grid item>
            <Button variant="info" color="success" className="m-1" onClick={() => handleDownload(year)}>
              Download Registry
            </Button>
          </Grid>
          <Grid item>
            <Button variant="success" color="success" className="m-1" onClick={handleOpen}>
              Add new IBAN
            </Button>
          </Grid>
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
                <Button variant="primary" className="m-1" onClick={() => handleEdit(iban.id)}>
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
