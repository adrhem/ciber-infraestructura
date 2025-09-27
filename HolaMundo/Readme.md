## Práctica 1: MAUI

Para esta práctica, se ha creado un nuevo proyecto de .NET MAUI llamado "HolaMundo" usando el comando `dotnet new maui`. El objetivo principal de esta aplicación es crear una interfaz de usuario sencilla que muestre un dos campos de entrada para el usuario y contraseña, así como un botón para iniciar sesión. La validación de los campos se realiza mediante expresiones regulares para asegurar que el nombre de usuario y la contraseña cumplan con ciertos requisitos de seguridad.

Una vez que el usuario ingresa sus credenciales y presiona el botón de "Iniciar Sesión", la aplicación valida los datos ingresados. Si los datos son correctos, se muestra un mensaje de bienvenida; de lo contrario, se notifica al usuario sobre el error en las credenciales.

### Capturas de Pantalla
#### Pantalla Inicial
<img width="394" height="319" alt="default" src="https://github.com/user-attachments/assets/e6a731cf-10bc-4839-b9d4-d5ee8e0846d4" />

#### Pantalla de Validación para Usuario
<img width="392" height="319" alt="username-wrong" src="https://github.com/user-attachments/assets/c1bbf457-6036-4e8b-bf46-4787a3e6b238" />

#### Pantalla de Validación para Contraseña
<img width="390" height="319" alt="password-wrong" src="https://github.com/user-attachments/assets/b863a16e-bb49-4bed-9072-d99eb122995d" />

#### Pantalla de Bienvenida
<img width="392" height="312" alt="success" src="https://github.com/user-attachments/assets/4a04250f-0ecf-4d94-970b-8f8630b8db4b" />

### Estructura del Proyecto
El proyecto está estructurado de la siguiente manera:
- **MainPage.xaml**: Define la interfaz de usuario de la aplicación, incluyendo los campos de entrada y el botón así como un Label para mostrar mensajes al usuario.
- **MainPage.xaml.cs**: Contiene la lógica de la aplicación, incluyendo la validación de las credenciales y la gestión de eventos.
