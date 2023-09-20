# senasoft2023

Proyecto MongoDB

Lenguaje C#

Prerequisitos

    - Dotnet SDK 7.0 
      https://dotnet.microsoft.com/en-us/download

    - Visual Studio Code
      https://code.visualstudio.com/download
    
    - C# Extension para VS Code
      https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp

    - Cuenta mongo atlas
      https://www.mongodb.com/es

    - MongoDB Compass (GUI)
      https://www.mongodb.com/try/download/compass

    - Postman
      https://www.postman.com/downloads/




Vamos a crear un proyecto tipo api usando netcore y C#

1. Crear el nuevo proyecto
   en una terminal de comandos digitamos el siguiente comando
   
   dotnet new webapi -o MiProyectoApi
   esto generara la carpeta MiproyectoApi con los archivos base de un proyecto api

2. Ingresamos a la carpeta del proyecto e iniciamos visual studio code
   
   cd MiProyectoApi
   code .


3. Abrimos la terminal de vsCode e instalamos las librerias necesarias

   el siguiente comando nos permite instalar el driver de mongodb
   dotnet add package MongoDB.Driver --version 2.21.0

   se recomienda revisar siempre en https://www.nuget.org/ por nuevas versiones de los paquetes


4. Desde la consola instalamos el certificado local para que el proyecto funcione sobre https
   
   dotnet dev-certs https --trust


Documentacion adicional

- https://www.mongodb.com/docs/manual/
- https://www.mongodb.com/docs/manual/aggregation/
- https://learn.mongodb.com/
- https://mongodb.github.io/mongo-csharp-driver/2.8/apidocs/html/N_MongoDB_Bson_Serialization_Attributes.htm
- https://learn.microsoft.com/es-mx/azure/architecture/best-practices/api-design