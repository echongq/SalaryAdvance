Prueba Tecnica Salary Advance

Este proyecto implementa una aplicación basada en ASP.NET Core para la gestión de solicitudes de adelanto de salario. Se organiza siguiendo los principios de arquitectura limpia y utiliza patrones como CQRS y Event Driven Design.

Requisitos Previos

.NET 8 SDK

SQL Server

///////////////////////////////

Configuración y Ejecución

Clonación del Repositorio

git clone https://github.com/echongq/salary-advance.git
cd salary-advance

Configuración de la Base de Datos



Actualizar la cadena de conexión en appsettings.json dentro del proyecto SalaryAdvance.API:

"ConnectionStrings": {
  "Connection": "Server={ServidorSqlServer};Database=SalaryAdvanceDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
Puedes Crear una base de datos en SQL Server con el nombre SalaryAdvanceDB o Ejecutar el comando(consola Administrador de Nuget)  para generar automaticamente:
dotnet ef migrations add InitialMigration

Aplicar las migraciones de Entity Framework para generar las tablas:

dotnet ef database update

Ejecutar la aplicacion y se abrira el navegador con la interface de Swagger para poder probar
//////////////////////////////////////////////////////////////////////////////////////////

Decisiones Arquitectónicas

- Separación por Capas
  Se dividio la solución en Controller, Dominio, Aplicacion e Infraestructura

- Swagger: Proporciona una interface para los endpoints, exponiendolos para pruebas basicas.

- Implementación de CQRS
  Se utilizó MediatR para separar las operaciones de lectura (Queries) y escritura (Commands).

- Event Driven Design
- Validaciones
  Se usó FluentValidation para validar los datos entrantes.
