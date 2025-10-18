## Generación de un web service REST
Los servicios web nos ayudan a generar canales de comunicación ágiles para módulos de desarrollo pequeños. Con un web service podemos, por ejemplo, realizar operaciones CRUD (Create, Read, Update, Delete) sobre una base de datos.

REST es cualquier interfaz entre sistemas que use HTTP para obtener datos o generar operaciones sobre esos datos en todos los formatos posibles, como XML y JSON. Un web service basado en REST nos devolverá una respuesta, seguida del estatus del servicio, en uno de estos formatos, según se haya configurado.

### Objetivos
Crear un web service que genere las operaciones:
- **GET**: Sobre el listado completo de registros en base de datos
- **GET Parametrizado**: Con el identificador de un registro, para obtener el valor del mismo exclusivamente
- **POST**: Insertar un registro nuevo

Las operaciones deberán retornar una respuesta en JSON.

## Tecnologías
- .NET Core 9.0
- Entity Framework Core
- PostgreSQL [Npgsql](https://www.npgsql.org/efcore/index.html)

## Estructura de archivos
- `Program.cs`: Archivo principal que contiene la configuración del web service, servicios y configuración de .NET Core.
- `Startup.cs`: Archivo de configuración del servicio web, donde se definen los servicios y middlewares. Así como la cadena de conexión a la base de datos.
- `Models/CatPersonal.cs`: Clase que representa el modelo de datos para los registros de personal.
- `Controllers/CatPersonalController.cs`: Controlador que maneja las solicitudes HTTP y define las rutas para las operaciones CRUD:
  - `GET /api/CatPersonal`: Obtiene todos los registros de personal.
  - `GET /api/CatPersonal/{id}`: Obtiene un registro de personal por su ID.
  - `POST /api/CatPersonal/create`: Inserta un nuevo registro de personal.
- `DataAccess/IDataAccessProvider.cs`: Interfaz que define las operaciones de acceso a datos.
- `DataAccess/DataAccessProvider.cs`: Clase que maneja la conexión a la base de datos y las operaciones CRUD utilizando Entity Framework Core.
- `DataAccess/PostgreSqlContext.cs`: Clase que representa el contexto de la base de datos PostgreSQL y define el DbSet para los registros de personal.

## Ejecución local
1. Asegúrate de tener PostgreSQL instalado y en ejecución.
2. Configura la cadena de conexión en `appsettings.Development.json` con los detalles de tu base de datos. Puedes usar la plantilla proporcionada en `appsettings.Development.json.bak`.
3. Abre una terminal en la raíz del proyecto y ejecuta el siguiente comando para restaurar las dependencias:
   ```bash
   dotnet restore
   ```
4. Ejecuta el proyecto con el siguiente comando:
   ```bash
   dotnet run
   ```
5. El web service estará disponible en `http://localhost:5229`.

## Pruebas de las operaciones
Puedes usar herramientas como Postman o cURL para probar las operaciones del web service.
- **GET Todos los registros**:
<img width="738" height="440" alt="list" src="https://github.com/user-attachments/assets/0877d1b2-1e9a-462d-94f7-86ca27ad82d5" />

   ```bash
   curl -X GET http://localhost:5229/api/CatPersonal
   ```
- **GET Registro por ID**:
<img width="693" height="219" alt="get" src="https://github.com/user-attachments/assets/c0e3cebd-9806-4677-a479-aa1e03af8921" />

   ```bash
   curl -X GET http://localhost:5229/api/CatPersonal/{id}
   ```
- **POST Nuevo registro**:
<img width="693" height="208" alt="create" src="https://github.com/user-attachments/assets/8bb4291b-b444-415e-92a1-c716a66cf997" />

   ```bash
   curl -X POST http://localhost:5229/api/CatPersonal/create -H "Content-Type: application/json" \ 
      -d '{"nombre":"Juan","cargo":"Desarrollador"}'
   ```

## Despliegue en Heroku
1. Asegúrate de tener una cuenta en [Heroku](https://www.heroku.com/) y tener instalado el [Heroku CLI](https://devcenter.heroku.com/articles/heroku-cli).
2. Inicia sesión en Heroku desde la terminal:
   ```bash
   heroku login
   ```
3. Crea una nueva aplicación en Heroku:
   ```bash
   heroku create nombre-de-tu-app
   ```
   o desde el panel de control de Heroku en `https://dashboard.heroku.com/apps`.
4. Agrega el complemento de PostgreSQL a tu aplicación, puedes usar el CLI de Heroku:
   ```bash
   heroku addons:create heroku-postgresql:essential-0
   ```
   o desde el panel de control de Heroku en la sección de Resources: `https://dashboard.heroku.com/apps/<nombre-de-tu-app>/resources`.
5. Obtén la cadena de conexión a la base de datos PostgreSQL proporcionada por Heroku:
   ```bash
   heroku config:get DATABASE_URL -a nombre-de-tu-app
   ```
   o desde el panel de control de Heroku en la sección de Settings: `https://dashboard.heroku.com/apps/<nombre-de-tu-app>/settings` en la sección "Reveal Config Vars".
6. Configura la cadena de conexión configurando una nueva variable de entorno en Heroku llamada `ASPNETCORE_ConnectionStrings__DefaultConnection` con el siguiente formato:
   ```
   Host=<host>;Port=<port>;Database=<database>;Username=<username>;Password=<password>
   ```
   Puedes hacerlo desde el panel de control de Heroku en la sección de Settings: `https://dashboard.heroku.com/apps/<nombre-de-tu-app>/settings` en la sección "Reveal Config Vars" o usando el CLI de Heroku:
   ```bash
   heroku config:set ASPNETCORE_ConnectionStrings__DefaultConnection="Host=<host>;Port=<port>;Database=<database>;Username=<username>;Password=<password>" -a nombre-de-tu-app
   ```
7. Configura el buildpack de .NET Core para tu aplicación en Heroku. Para este proyecto, usaremos el buildpack de [jincod/dotnetcore](https://github.com/jincod/dotnetcore-buildpack). El cual tiene soporte para .NET 9.0:
   ```bash
   heroku buildpacks:set jincod/dotnetcore -a nombre-de-tu-app
    ```
    O desde el panel de control de Heroku en la sección de Settings: `https://dashboard.heroku.com/apps/<nombre-de-tu-app>/settings` en la sección "Buildpacks".

8. Realiza el despliegue de la aplicación a Heroku:
    ```bash
    git push heroku main
    ```
    Si no has configurado el remote de Heroku, puedes hacerlo con:
    ```bash
    heroku git:remote -a nombre-de-tu-app
    ```
9. En el log de Heroku, podrás ver la URL donde está desplegada tu aplicación. Por defecto, será algo como `https://nombre-de-tu-app-<random_string>.herokuapp.com`.
<img width="798" height="129" alt="heroku" src="https://github.com/user-attachments/assets/96ec4526-5656-46dd-a01d-49f9719a91a6" />


## Visualización de datos en PostgreSQL
Para visualizar y administrar los datos en tu base de datos PostgreSQL, puedes usar herramientas como [pgAdmin](https://www.pgadmin.org/) o [DBeaver](https://dbeaver.io/). Además el Addon de Heroku PostgreSQL incluye un comando llamado `heroku pg:psql` que te permite conectarte a la base de datos desde la terminal. Para usarlo, ejecuta el siguiente comando:
```bash
heroku pg:psql <nombre-de-tu-servicio> --app nombre-de-tu-app
```
<img width="622" height="195" alt="psql" src="https://github.com/user-attachments/assets/47601815-e855-4d1a-bcfa-8e3bb2d66e5b" />

