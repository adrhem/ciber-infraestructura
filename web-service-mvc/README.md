## Generación de un web service REST
Los servicios web nos ayudan a generar canales de comunicación ágiles para módulos de desarrollo pequeños. Con un web service podemos, por ejemplo, realizar operaciones CRUD (Create, Read, Update, Delete) sobre una base de datos.

REST es cualquier interfaz entre sistemas que use HTTP para obtener datos o generar operaciones sobre esos datos en todos los formatos posibles, como XML y JSON. Un web service basado en REST nos devolverá una respuesta, seguida del estatus del servicio, en uno de estos formatos, según se haya configurado.

### Objetivos
Crear un web service que genere las operaciones:
- **GET**: Sobre el listado completo de registros en base de datos
- **GET Parametrizado**: Con el identificador de un registro, para obtener el valor del mismo exclusivamente
- **POST**: Insertar un registro nuevo

Las operaciones deberán retornar una respuesta en JSON.
