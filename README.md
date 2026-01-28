# Prueba_Ordenes_Pedido
Desarrollar un sistema de información que permita la  creación y edición de ORDENES DE PEDIDO por cliente. 

##Herramientas a utilizar
    Se Utilizo IA para la validacion de paquetes correctamente instalados y validación de errores durante el desarrollo

##Paquetes instalados desde consola
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
        dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
        dotnet add package Microsoft.EntityFrameworkCore.Tools  --version 8.0.0
        dotnet add package Swashbuckle.AspNetCore --version 8.0.0

##Ejecuciones
    Para ejecutar el .net desde consola se ingresa a cd backend/OrdeApi con el comando dotnet run 
    Para ejecutar el front desde consola se ingresa a cd frontend/pedidos-app con el comando ng serve

##Base de datos
    Se realiza directamente desde codigo creando una conexion a base de datos para posteriormente realizar una migración a PEDIDOS
##Github
https://github.com/Ctrl232/Prueba_Ordenes_Pedido