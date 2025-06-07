API de Gestión de Contratos

Este proyecto es una API RESTful desarrollada en ASP.NET Core para la gestión de contratos. Permite realizar algunas operaciones CRUD (Crear, Leer) básicas sobre los datos de contratos.


1. Código Fuente

El código fuente de este proyecto se encuentra en el siguiente repositorio Git:

https://github.com/KirtAlexander/PruebaTenicaIntegralV6.git


Archivo README.md

 Estructura del Proyecto

El proyecto `ApiContrats` está organizado de la siguiente manera:

Controllers: Contiene los controladores API que manejan las solicitudes HTTP y dirigen las operaciones.
DTOs: Define los Objetos de Transferencia de Datos (Data Transfer Objects), utilizados para la entrada y salida de datos de la API.
Models: Contiene los modelos de dominio que representan la estructura de los datos del contrato.
Services: Incluye la lógica de negocio y la interacción con la "base de datos").
Program.cs: El punto de entrada de la aplicación, donde se configura el servidor web y se inyectan las dependencias.
appsettings.json: Archivo de configuración de la aplicación.
launchSettings.json: Configuración para la ejecución local de la aplicación en diferentes perfiles

Tecnologías Utilizadas

Lenguaje de Programación: C#
Framework: ASP.NET Core 6.0
Base de Datos: Simulación de base de datos en memoria (lista estática en `ContratService.cs`).
Gestor de Paquetes: NuGet
Herramientas de Desarrollo:
Visual Studio [versión, ej: 2022]
.NET SDK 6.0.x
 Swagger/OpenAPI (a través de Swashbuckle.AspNetCore para la documentación interactiva de la API).

Dependencias Necesarias

Antes de ejecutar el proyecto, asegúrate de tener instaladas las siguientes dependencias en tu sistema:

1.  .NET SDK 6.0.x](https://dotnet.microsoft.com/download/dotnet/):
    Asegúrate de tener instalado el SDK de .NET Core 6.0. 
 dotnet --version usa este comando en la terminal para saber la versión que tienes instalada

Instrucciones para Correr la API

Sigue estos pasos para poner en marcha la API en un entorno local:

1.  Clonar el Repositorio :
    Ya que el codigo esta en un repositorio git, abre una terminal (CMD, PowerShell, Git Bash) y ejecuta:

    git clone https://github.com/KirtAlexander/PruebaTenicaIntegralV6.git
    cd PruebaTenicaIntegralV6


2.  Navegar al Proyecto:
    Si estás en la carpeta de la solución (`.sln`), navega a la carpeta del proyecto específico:

    cd ApiContrats
  

3.  Restaura Dependencias de NuGet:
    En la carpeta del proyecto (`ApiContrats`), ejecuta:
    dotnet restore

    Esto descargará todas las librerías y paquetes NuGet que se necesitan.

4.  Compilar el Proyecto:
    En la misma terminal, compila el proyecto:

    dotnet build

    Si la compilación es exitosa, no verás errores.

5.  Ejecutar la API:
    Puedes ejecutar la API de dos maneras:

Desde la Terminal (dentro de la carpeta `ApiContrats`):

dotnet run

La API se iniciará y te mostrará la URL en la que está escuchando (ej: `https://localhost:70XX`).

Desde Visual Studio:
        Abre la solución (`ApiContrats.sln`) o la carpeta del proyecto `ApiContrats` en tu IDE y presiona `F5` o el botón "Iniciar Depuración".

6. Acceder a la API (Swagger UI):
    Una vez que la API esté corriendo, puedes acceder a la documentación interactiva de Swagger UI abriendo tu navegador y navegando a la URL proporcionada por la terminal

    Desde Swagger UI, podrás ver los endpoints disponibles, sus descripciones y probar las operaciones directamente.

Endpoints Principales

GET /api/contrats: Obtiene una lista de todos los contratos existentes.
POST /api/contrats: Crea un nuevo contrato.
Cuerpo de la solicitud (JSON):
        {
          "validity": "2024-06-07T00:00:00",
          "entity": "Mi Empresa S.A."
        }

**¡Gracias por revisar este proyecto!** Si tienes alguna pregunta o encuentras algún problema, no dudes en contactar al desarrollador.
