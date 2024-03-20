import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle } from '@mui/material';



function App() {
  const [contribuyentes, setContribuyentes] = useState([]);
  const [comprobantes, setComprobantes] = useState([]);
  const [open, setOpen] = useState(false); // Nuevo estado para manejar la visibilidad

    // La función para cerrar el panel removible
    const handleClose = () => {
      setOpen(false);
    };
   // Función modificada para incluir la apertura del panel y almacenar los datos
   const fetchComprobantesFiscales = (rncCedula) => {
    axios.get(`http://localhost:5107/Contribuyentes/GetListadoComprobastesFiscales/${rncCedula}`)
      .then(response => {
        setComprobantes(response.data);
        setOpen(true); // Abre el panel removible
      })
      .catch(error => {
        console.error('Hubo un error en la petición!', error);
      });
  };

  useEffect(() => {
    // Asegúrate de actualizar la URL con la ruta correcta a tu API
    axios.get('http://localhost:5107/Contribuyentes/GetListadoContribuyentes')
      .then(response => {
        console.log(response.data)
        setContribuyentes(response.data);
      })
      .catch(error => {
        console.error('Hubo un error!', error);
      });
  }, []);

  return (
    <>
    <Dialog open={open} onClose={handleClose} aria-labelledby="dialog-title" fullWidth={true} maxWidth="sm">
  <DialogTitle id="dialog-title">Comprobantes Fiscales</DialogTitle>
  <DialogContent>
    <TableContainer component={Paper}>
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell><strong>RNC/Cédula</strong></TableCell>
            <TableCell align="right"><strong>NCF</strong></TableCell>
            <TableCell align="right"><strong>Itbis18</strong></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {comprobantes.map((comprobante, index) => (
            <TableRow key={index}>
              <TableCell component="th" scope="row">
                {comprobante.rncCedula}
              </TableCell>
              <TableCell align="right">{comprobante.ncf}</TableCell>
              <TableCell align="right">
                {new Intl.NumberFormat('es-DO', { style: 'currency', currency: 'DOP' }).format(comprobante.itbis18)}
              </TableCell>
            </TableRow>
          ))}
          {/* Fila para el monto acumulado total */}
          <TableRow>
            <TableCell colSpan={2}><strong>Total Acumulado</strong></TableCell>
            <TableCell align="right"><strong>{
              new Intl.NumberFormat('es-DO', { style: 'currency', currency: 'DOP' }).format(
                comprobantes.reduce((acc, current) => acc + current.itbis18, 0)
              )
            }</strong></TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </TableContainer>
  </DialogContent>
  <DialogActions>
    <Button onClick={handleClose}>Cerrar</Button>
  </DialogActions>
</Dialog>

    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>RNC/Cédula</TableCell>
            <TableCell align="right">Nombre</TableCell>
            <TableCell align="right">Tipo</TableCell>
            <TableCell align="right">Estatus</TableCell>
            <TableCell align="right">Accion</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {contribuyentes.map((contribuyente) => (
            <TableRow
              key={contribuyente.rncCedula}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {contribuyente.rncCedula}
              </TableCell>
              <TableCell align="right">{contribuyente.nombre}</TableCell>
              <TableCell align="right">{contribuyente.tipo}</TableCell>
              <TableCell align="right">{contribuyente.estatus}</TableCell>
              <TableCell align="right">
                  <Button variant="contained" color="primary" onClick={() => fetchComprobantesFiscales(contribuyente.rncCedula)}>
                    Comprobante Fiscales
                  </Button>
                </TableCell>

            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </>
  );
  
}

export default App;
