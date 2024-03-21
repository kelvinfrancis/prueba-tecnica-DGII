# prueba-tecnica-DGII


# DGII API

Breve descripción del proyecto, incluyendo su propósito y cualquier información de contexto relevante.

## Descripción General

Este proyecto es una aplicación web desarrollada utilizando ASP.NET Core, diseñada para gestionar contribuyentes y comprobantes fiscales. Ofrece funcionalidades para listar contribuyentes activos e inactivos, así como para gestionar comprobantes fiscales asociados a cada contribuyente.

## Características

- **Gestión de Contribuyentes**: Permite a los usuarios listar contribuyentes y ver detalles específicos sobre cada uno.
- **Gestión de Comprobantes Fiscales**: Los usuarios pueden buscar comprobantes fiscales por RNC o cédula del contribuyente.

## Tecnologías Utilizadas

- ASP.NET Core
- Entity Framework Core (para el manejo de migraciones y acceso a datos)
- SQLite (como sistema de gestión de bases de datos)
- Swagger (para documentación y pruebas de la API)

## Configuración del Proyecto

### Prerrequisitos

- .NET Core SDK
- Un IDE como Visual Studio o Visual Studio Code

### Instalación y Ejecución

1. Clonar el repositorio: `git clone url_del_repositorio`
2. Navegar al directorio del proyecto: `cd ruta_del_proyecto`
3. Restaurar dependencias: `dotnet restore`
4. Ejecutar las migraciones: `dotnet ef migrations add MigracionInicial` y luego `dotnet ef database update`
5. Iniciar el proyecto: `dotnet run`

## Estructura del Proyecto

Descripción de la estructura del proyecto, incluyendo las principales carpetas y archivos, y su propósito dentro de la aplicación.

- **Controllers**: Contiene los controladores de ASP.NET Core que gestionan las peticiones HTTP.
- **Models**: Define las entidades del modelo de datos usadas en el proyecto.
- **Migrations**: Incluye las clases de migraciones de Entity Framework Core para la gestión de la base de datos.

## Uso

Instrucciones sobre cómo utilizar la aplicación, incluyendo ejemplos de peticiones HTTP para interactuar con la API.

### Listar Contribuyentes

`GET /Contribuyentes/GetListadoContribuyentes`

### Obtener Comprobantes Fiscales por RNC o Cédula

`GET /Contribuyentes/GetListadoComprobantesFiscales/{RncOCedula}`

## Problemas Comunes y Soluciones

- **Swagger no muestra el segundo método**: Asegúrate de que los métodos en los controladores tengan nombres únicos y las rutas estén correctamente configuradas.

Nota Importante:
Tomar en cuenta que el puerto utilizando para la conexion en la API es el siguiente: http://localhost:5107
Puerto de la app web (por defecto): http://localhost:3000 


# DGI-UI

Este proyecto implementa una interfaz de usuario que permite visualizar una lista de contribuyentes y los detalles de sus comprobantes fiscales asociados en una aplicación web desarrollada con React y Material UI.

## Características

- Lista de contribuyentes mostrada en una tabla.
- Botón en cada fila para cargar los comprobantes fiscales asociados al contribuyente.
- Visualización de comprobantes fiscales en un panel removible con una tabla detallada.
- Cálculo y muestra del monto total acumulado de los comprobantes fiscales.

## Tecnologías Utilizadas

- React
- Material UI
- Axios para las llamadas a la API

## Implementación

### Configuración del Proyecto

Asegúrate de tener Node.js instalado en tu sistema. Luego, crea tu proyecto React y añade las dependencias de Material UI y Axios:

```bash
npx create-react-app mi-aplicacion
cd mi-aplicacion
npm install @mui/material @emotion/react @emotion/styled axios
```

### Código Principal

El proyecto se basa en dos componentes principales: `App` y `DialogoComprobantes`. `App` gestiona la visualización de la lista de contribuyentes y el diálogo para los comprobantes fiscales. `DialogoComprobantes` se encarga de mostrar los detalles de los comprobantes fiscales en un panel removible.

#### App Component

El componente `App` realiza una llamada a la API para obtener los contribuyentes y muestra estos datos en una tabla. Cada fila tiene un botón que, al ser pulsado, realiza otra llamada a la API para obtener los comprobantes fiscales asociados a ese contribuyente específico, mostrándolos en un diálogo removible.

```jsx
// Importaciones básicas
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Dialog, DialogActions, DialogContent, DialogTitle } from '@mui/material';

function App() {
  // Estados y funciones
}

export default App;
```

#### Mostrar Comprobantes Fiscales

Los comprobantes fiscales se muestran en un diálogo removible, con cada comprobante presentado en una fila de una tabla interna. También se calcula y muestra un monto total acumulado de los comprobantes.

### Funcionalidad Adicional

Describir cualquier funcionalidad adicional que se haya discutido o implementado, como formateo de montos monetarios, manejo de errores, etc.

## Ejecución del Proyecto

Para iniciar la aplicación, ejecuta:

```bash
npm start
```

La aplicación se abrirá en tu navegador por defecto en `http://localhost:3000`.



# Mandato de la prueba:

Para este ejercicio debes crear una aplicación web y un API. Este API puede devolver los resultados en
formato XML o en JSON. Eres libre de escoger el formato con el que te sientas más cómodo (sólo es
necesario que se implemente uno de los formatos).

El API debe tener un método desde el cuál se pueda obtener el listado de todos los contribuyentes.
Otro método con el que se pueda obtener el listado de todos los comprobantes fiscales y cualquier otro
que consideres necesario.

Ejemplo JSON (Listado de todos los contribuyentes)
[
    {
        "rncCedula": "98754321012",
        "nombre": "JUAN PEREZ",
        "tipo": "PERSONA FISICA"
        ,
        "estatus": "activo"
    },
    {
        "rncCedula": "123456789”,
        "nombre": "FARMACIA TU SALUD",
        "tipo": "PERSONA JURIDICA"
        ,
        "estatus": "inactivo"
    }
]
Ejemplo JSON (Listado de los comprobantes fiscales)
[
    {
        "rncCedula": "98754321012",
        "NCF": "E310000000001",
        "monto": "200.00"
        ,
        "itbis18": "36.00"
    },
    {
        "rncCedula": "98754321012”,
        "NCF": "E310000000002",
        "monto": "1000.00"
        ,
        "itbis18": "180.00"
    }
]

En el último ejemplo cada entrada en la colección representa una transacción (se identifica mediante
los campos rncCedula/NCF), el monto de dicha factura (monto) y el 18% del ITBIS (itbis18).

Por último, una aplicación web que muestre el listado de los contribuyentes y al seleccionar uno de
ellos muestre un listado con todos los comprobantes fiscales y la suma total del ITBIS de todas las
transacciones de ese RNC/Cédula.

Por ejemplo, utilizando los datos anteriores, la suma total del ITBIS para el RNC/Cédula 98754321012
debería ser $216.00.

Requisitos:
⇒ Utilizar .Net Core para el Backend y cualquier framework para el Frontend (preferiblemente
React o Angular)
⇒ Puedes utilizar cualquier librería de terceros
⇒ Separación de responsabilidades en distintas capas
⇒ Implementación de log de error y manejo de excepciones en cada capa
⇒ Tener en cuenta los principios SOLID y correcta capitalización del código

Puntos extras (No son obligatorios)
⇒ Uso de Inyección de dependencias
⇒ Tests unitarios
⇒ Persistir los datos utilizando el sistema que prefieras, por ejemplo, en una base de datos
relacional.