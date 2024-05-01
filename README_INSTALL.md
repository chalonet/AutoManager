# Instalación de la Aplicación AutoManager

## Requisitos Previos
- IDE: [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) 💻
- Motor de base de datos: [Microsoft SQL Server Express](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) 🛢️
- Herramienta de gestión de bases de datos: [Microsoft SQL Management Studio](https://docs.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) 🖥️

## Pasos de Instalación

### 1. Descarga e Instalación de Herramientas ![Descargar](https://img.icons8.com/ios/50/000000/download.png)
1. Descarga e instala Visual Studio Community desde el sitio oficial.
2. Descarga e instala Microsoft SQL Server Express desde el sitio oficial.
3. Descarga e instala Microsoft SQL Management Studio desde el sitio oficial.

### 2. Clonación del Repositorio
1. Abre Visual Studio Community.
2. Clona el repositorio AutoManager desde [aquí](https://github.com/chalonet/AutoManager.git).
3. Abre la solución AutoManager en Visual Studio.

### 3. Configuración de la Base de Datos
1. Abre Microsoft SQL Management Studio.
2. Conéctate al servidor local.
3. Ejecuta el script de creación de la base de datos proporcionado en el repositorio "AutoManagerDB.sql".

### 4. Compilación y Ejecución de la Aplicación
1. Abre la solución AutoManager en Visual Studio.
2. Compila la solución para asegurarte de que no hay errores de compilación.
3. Ejecuta la aplicación haciendo clic en el botón de ejecución en Visual Studio.

### 5. Uso de la Aplicación
1. La aplicación permite crear personas y coches, así como asignar uno o más coches a una persona.
2. Puedes editar el nombre de una persona, coche o propietario según sea necesario.
3. Las validaciones se aplican automáticamente según las reglas definidas en los requisitos.
   - ❌ No puede existir personas con el mismo nombre y apellido.
   - ❌ No puede existir un coche con el mismo VIN.
   - 🚗 Una persona puede tener 1 o más coches.
   - 🚗 Un coche no puede pertenecer a más de 1 persona (Sólo puede existir 1 propietario por coche).
