## Instalar Visual Studio Community

### Introducción
Debido a que mi entorno de desarrollo es MacOS, en lugar de descargar Visual Studio Community estaré utilizando [Visual Studio Code](https://code.visualstudio.com/) como editor de código. Afortunadamente, Visual Studio Code es un editor muy versátil y potente que puede ser utilizado para desarrollar aplicaciones en múltiples lenguajes de programación, incluyendo C# y .NET MAUI. Esto gracias a la plataforma [.NET Core](https://dotnet.microsoft.com/) que es multiplataforma.

### Instalación y configuración de Visual Studio Code
1. **Descargar Visual Studio Code**: Ve a la página oficial de [Visual Studio Code](https://code.visualstudio.com/) y descarga la versión para MacOS.
2. **Instalar Visual Studio Code**: Abre el archivo descargado y sigue las instrucciones para instalar Visual Studio en tu sistema.
3. **Abrir Visual Studio Code**: Una vez instalado, abre Visual Studio Code desde la carpeta de Aplicaciones o desde Launchpad.
4. **Instalar Extensiones Recomendadas**: Para trabajar con .NET MAUI, es recomendable instalar las siguientes extensiones:
   - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
   - [.NET MAUI](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-maui)
5. Iniciar sesión con una cuenta de Microsoft para sincronizar configuraciones y extensiones. Además se requiere para desarrollar aplicaciones con .NET.

### Instalación de .NET SDK y .NET MAUI
1. **Instalar .NET SDK**: Primero, necesitas instalar el SDK de .NET. Puedes descargarlo desde la página oficial de [.NET](https://dotnet.microsoft.com/en-us/download). Asegúrate de descargar la versión más reciente compatible con MAUI (actualmente .NET 9.0 o superior).  
   - Sigue las instrucciones de instalación específicas para MacOS.
   - Una vez instalado, puedes verificar la instalación abriendo una terminal y ejecutando:
     ```bash
     dotnet --version
     ```
     Esto debería mostrar la versión del SDK de .NET que acabas de instalar.
2. **Instalar .NET MAUI**: Una vez que tengas el SDK de .NET instalado, puedes instalar .NET MAUI utilizando el siguiente comando en la terminal:
   ```bash
   dotnet workload install maui
   ```

### Crear un nuevo proyecto de .NET MAUI
1. **Abrir una terminal**: Puedes abrir la terminal integrada en Visual Studio Code o usar la terminal de tu sistema.
2. **Crear un nuevo proyecto**: Navega al directorio donde deseas crear tu proyecto y ejecuta el siguiente comando:
   ```bash
   dotnet new maui -n NombreDeTuProyecto
   ```
   Alternativamente si estás en la carpeta donde quieres crear el proyecto, puedes usar:
   ```bash
    dotnet new maui
    ```
3. **Abrir el proyecto en Visual Studio Code**: Navega al directorio del proyecto y abre Visual Studio Code con el siguiente comando:
   ```bash
   cd NombreDeTuProyecto
   code .
   ```
   Si `code` no funciona, asegúrate de que el comando de línea de comandos de Visual Studio Code esté instalado. Puedes hacerlo desde la paleta de comandos (Cmd + Shift + P) y buscando "Shell Command: Install 'code' command in PATH".
4. **Compilar y ejecutar el proyecto**: Para compilar y ejecutar tu proyecto, puedes usar el siguiente comando en la terminal:
   ```bash
   dotnet build -t:Run -f net9.0-maccatalyst
   ```
   Esto compilará y ejecutará tu aplicación en el simulador de Mac Catalyst.
   <img width="590" height="474" alt="maui" src="https://github.com/user-attachments/assets/13b8149e-ef3f-4233-9d81-7ecf53cf3eb9" />
   
5. ¡Listo! Ahora tienes un entorno de desarrollo configurado para trabajar con .NET MAUI en MacOS utilizando Visual Studio Code.
