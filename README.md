# TodoList

Este repositorio es el Backend de un proyecto para administrar un TODO list (listado de tareas por hacer). Para el desarrollo de este repositorio se utilizo asp `.net core 3.0.`

### Requisitos
- Visual Studio 2019
- Installed .NET Core 3.0 SDK
- Sql Server >= 2014

### Instalación en Entorno de desarrollo
- Abrir el directorio clonado usando visual studio 2019
- 
- hacer el `Build` de la solucion
- Actualizacion de la base de datos

- Actualizacion de la base de datos
  - Usando Migrations
    - Abrir el archivo `appsettings.json` que se encuentra en el proyecto `Todo.Api`
    - Modificar el connectionString ingresando el servidor y credenciales correspondientes (las credenciales de un usuario con permisos de administrador)
    - En `Package Manager Console` ejecutar el comando `dotnet ef --startup-project Todo.Api/Todo.Api.csproj database update`


 - Usando Migrations
  - Modificar el connectionString ingresando el servidor y credenciales correspondientes (las credenciales de un usuario con permisos de administrador)
- hacer el `Build` de la solucion
- 
- Ejecutar el comando `npm install`
- Ejecutar el comando `ng serve`
- En el navegador (por ejemplo Chrome), abrir `http://localhost:4200/`

