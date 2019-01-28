# Tiendeo Assesment
--------

## Tecnologias

Las tecnologias utilizadas son las siguientes:

- React + redux (**Front end**)
- Net Core 2.1 (**Api**)
- Entity Framework Core
- Docker
- Git

## Herramientas:

- Visual Studio Code
- Visual Studio 2017
- Docker
- Fork/Git Extensions
- Github

## Puesta en marcha

### Configuración del entorno

**API:** Es necesario tener instalado las versiones mas actualizadas del **SDK de Net Core (2.1)**.

**Cliente:** Encontraremos en el cliente un archivo llamado _Config.js_ donde será necesario introducir una **key de google maps** para poder mostrar el mapa en el cliente.

### Run

1. Crear la imagen de Docker del backend utilizando el siguiente comando: `docker build --rm -f "Dockerfile" -t tiendeoapi:latest .` ejecutado en el path del proyecto donde se encuentra el archivo Dockerfile.

2. Hacer el run de la imagen previamente creada con el siguiente comando: `docker run --rm -it -p 5001:80/tcp tiendeoapi:latest`

3. Ejecutar el cliente web situandose en el path del cliente web y ejecutar `npm start` o realizar `npm build` y utilizar los archivos generados para correr la web utilizando algun servidor o herramienta.

### Anotaciones

**.Net core api**

En el proyecto .Net de la api encontraremos un archivo de configuracion _appsettings.json_ donde podremos encontrar las diferentes configuraciones de la aplicacion:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "AppSettings": {
    "DataBaseConnection": "Server=localhost;Database=Users;UserID=test;Password=test",
    "UseMockData": true
  }
}
```

En la seccion de _AppSettings_ podremos encontrar la _DataBaseConnection_ que podremos configurar para usar nuestra base de datos. También podemos encontrar la variable UseMockData con la cual al tenerla activada se usará una base de datos local y se hará un mock de los datos estos datos los podremos encontrar en el fichero _Data.json_.

Es importante tener en cuenta que una vez el servicio esté corriendo en un docker las peticiones se realizaran con **http** en la url a diferencia de si corremos el proyecto en Visual studio que serian con **https**

**Cliente**

En el cliente hay que tener en cuenta que el renderizado de las imagenes de los negocios de las stores no funciona dado que las url no permiten acceso a estos _.png_.

La URL de la Api no está por configuración(lo sé, no me dió tiempo) por lo que si se cambia de puerto o url habrá que modificarlo también a nivel de código.

**Base de datos**

Dado que se está utilizando **Entity framework core** hay que destacar ciertos aspectos.

1. Se puede usar una base de datos solo necesitando conectarla y crear una estructura de datos.
2. Hay que tener en cuenta que la version de entity framework core actual solo permite hacer herencia con el patrón **TPH(patrón por jerarquía)** por lo que la base de datos generada deberá tener una tabla _local_ que contenga tanto los datos de las _stores_ como de los _services_ puesto que en el proyectos estos últimos heredan de local, esta tabla tendrá un campo _Discriminator_ con el que hará referencia a que tipo es.

   <https://docs.microsoft.com/es-es/ef/core/modeling/relational/inheritance>

# Créditos

<sub>Proyecto desarrollado por Javier Molpeceres Gómez como Assesment para Tiendeo, la explotación y utilización de este proyecto sin el consentimiento del desarrollador queda totalmente prohibida.
