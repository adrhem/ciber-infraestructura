## Instalar MySQL Workbench + MySQL Server Local

### Introducción
MySQL Workbench es una herramienta visual unificada para arquitectos de bases de datos, desarrolladores y administradores de bases de datos. Proporciona herramientas para el diseño, desarrollo y administración de bases de datos [MySQL](https://www.mysql.com/) (hasta la versión 8.0, después soporte parcial) y [MariaDB](https://mariadb.org/) (Con soporte parcial). En esta guía, se detallan los pasos para instalar MySQL Workbench junto con un servidor MySQL local en un entorno MacOS.

### Instalación de MySQL Server Local
Recomiendo dos opciones para instalar MySQL Server en MacOS. La primera usando [Homebrew](https://brew.sh/) y la segunda usando [Docker](https://www.docker.com/).
#### Opción 1: Usando Homebrew
1. **Instalar Homebrew**: Si no tienes Homebrew instalado, abre la terminal y ejecuta el siguiente comando:
   ```bash
   /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
   ```
2. **Actualizar Homebrew**: Asegúrate de que Homebrew esté actualizado ejecutando:
    ```bash
    brew update
    ```
3. **Instalar MySQL**: Ejecuta el siguiente comando para instalar MySQL:
   ```bash
   brew install mysql
   ```
4. **Iniciar el servicio de MySQL**: Una vez instalado, inicia el servicio de MySQL con el siguiente comando:
   ```bash
   brew services start mysql
   ```
5. **Configurar MySQL**: Ejecuta el siguiente comando para asegurar la instalación y configurar la contraseña del usuario root:
   ```bash
   mysql_secure_installation
   ```
   Sigue las instrucciones en pantalla para completar la configuración.
6. **Verificar la instalación**: Puedes verificar que MySQL está funcionando correctamente ejecutando:
   ```bash
   mysql -u root -p
   ```
   Ingresa la contraseña que configuraste anteriormente para acceder al shell de MySQL. Si ves el prompt de MySQL, la instalación fue exitosa.

#### Opción 2: Usando Docker
1. **Instalar Docker**: Si no tienes Docker instalado, puedes descargarlo desde [aquí](https://www.docker.com/products/docker-desktop).
2. Si bien puedes usar la interfaz gráfica de Docker Desktop, en esta guía usaremos la [docker compose](https://docs.docker.com/compose/) para facilitar la configuración.
3. **Crear un archivo `docker-compose.yml`**: Crea un nuevo directorio para tu proyecto y dentro de él, crea un archivo llamado `[docker-]compose.yml` con el siguiente contenido:
   ```yaml
   services:
     db:
       image: mysql:8.0 # Esta es la ultima versión con soporte completo en MySQL Workbench
       environment:
         MYSQL_ROOT_PASSWORD: tu_contraseña_segura
       # Si ya tienes un MySQL o MariaDB corriendo en tu máquina con el puerto 3306, cambia el puerto mapeado a otro, por ejemplo 3307
       # ports:
       #  - "3306:3306" 
   ```
   Asegúrate de reemplazar `tu_contraseña_segura` con valores adecuados.
4. **Iniciar el contenedor**: Abre una terminal, navega al directorio donde creaste el archivo `[docker-]compose.yml` y ejecuta el siguiente comando:
   ```bash
   docker-compose pull
   docker-compose up -d
   ```
   Esto descargará la imagen de MySQL y levantará un contenedor con el servidor MySQL corriendo en segundo plano.
5. **Verificar la instalación**: Puedes verificar que el contenedor está corriendo correctamente ejecutando:
   ```bash
   docker ps
   ```
   Deberías ver el contenedor de MySQL en la lista de contenedores activos.
   <img width="569" height="70" alt="docker" src="https://github.com/user-attachments/assets/57a5d9eb-4f23-46d3-8004-ed1551a30ef1" />


### Instalación de MySQL Workbench
1. **Descargar MySQL Workbench**: Ve a la página oficial de [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) y descarga la versión para MacOS.
2. **Instalar MySQL Workbench**: Abre el archivo descargado y sigue las instrucciones para instalar MySQL Workbench en tu sistema.
3. **Abrir MySQL Workbench**: Una vez instalado, abre MySQL Workbench desde la carpeta de Aplicaciones o desde Launchpad.
4. **Configurar una nueva conexión**:
   <img width="830" height="496" alt="new-connection" src="https://github.com/user-attachments/assets/98926cc0-3e53-4c10-99a0-06ae8a602678" />
   - Haz clic en el ícono de `+` junto a "MySQL Connections".
   - En el campo "Connection Name", ingresa un nombre para tu conexión (por ejemplo, "Local MySQL").
   - En el campo "Hostname", ingresa `localhost`.
   - En el campo "Port", ingresa `3306` (o el puerto que hayas configurado si usaste Docker).
   - En el campo "Username", ingresa `root`.
   - Haz clic en "Store in Vault..." para ingresar la contraseña que configuraste durante la instalación de MySQL.
   - Haz clic en "Test Connection" para verificar que la conexión sea exitosa.
   - Si la conexión es exitosa, haz clic en "OK" para guardar la conexión.
5. **Usar MySQL Workbench**: Ahora puedes usar MySQL Workbench para gestionar tu servidor MySQL local, crear bases de datos, ejecutar consultas SQL y mucho más.
<img width="1019" height="717" alt="workbench" src="https://github.com/user-attachments/assets/561b4de7-282c-4e1d-b889-1bc718252e3d" />
