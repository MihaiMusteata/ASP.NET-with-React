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
import { uRole } from '../actions/uRole';
import AddUserModal from './AddUserModal';
import { useState, useEffect } from 'react';
import { ApiGetRequest } from '../actions/api';

// Generate Users Data
function createData(id, username, email, password, district, region, role) {
  return { id, username, email, password, district, region, role };
}

export default function Users() {
  const [open, setOpen] = useState(false);
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await fetch('https://localhost:7273/api/Dashboard/users');
        const data = await response.json();
        setUsers(data);
      } catch (error) {
        console.error('Error fetching users:', error);
      }
    };

    fetchUsers();
  }, [open]); 

  console.log('Users:', users);

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleDelete = (id) => {
    fetch('https://localhost:7273/api/Dashboard/user?userId=' + id, {
      method: 'DELETE',
    })
      .then((response) => response.json())
      .then((data) => {
        console.log('User deleted:', data);
        setUsers(users.filter(user => user.id !== id));
      })
      .catch((error) => {
        console.error('Error deleting user:', error);
      });
  };

  return (
    <React.Fragment>
      <Grid container justifyContent="space-between" alignItems="center">
        <Typography component="h2" variant="h6" color="primary" gutterBottom>
          Users List
        </Typography>
        <Grid item>
          <Button variant="success" color="success" className="m-1" onClick={handleOpen}>
            Add new User
          </Button>
          <AddUserModal open={open} handleClose={handleClose} />
        </Grid>
      </Grid>

      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Username</TableCell>
            <TableCell>Email</TableCell>
            <TableCell>Password</TableCell>
            <TableCell>Gender</TableCell>
            <TableCell>District</TableCell>
            <TableCell>Region</TableCell>
            <TableCell>Role</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {users.map((user) => (
            <TableRow key={user.id}>
              <TableCell>{user.username}</TableCell>
              <TableCell>{user.email}</TableCell>
              <TableCell>********</TableCell> {/* Display 'password' as asterisks */}
              <TableCell>{user.gender}</TableCell>
              <TableCell>{user.district}</TableCell>
              <TableCell>{user.region}</TableCell>
              <TableCell>{uRole[user.level]}</TableCell>
              <TableCell>
                <Button variant="primary" className="m-1">
                  Edit
                </Button>
                <Button variant="danger" className="m-1" onClick={() => handleDelete(user.id)}>
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
