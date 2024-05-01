# Manual de Usuario de AutoManager 🚗💼

Bienvenido al Manual de Usuario de AutoManager, una aplicación para gestionar personas, coches y sus asignaciones. En este manual, aprenderás cómo utilizar todas las funciones de la aplicación y entenderás las validaciones que se aplican en cada caso.

## Funciones Principales

### Creación de Personas
👤 Desde la pantalla principal, haz clic en el botón "Añadir" de la lista de personas.

👉 Completa el formulario con el nombre y apellido de la persona.

💾 Haz clic en "Guardar" para crear la persona.

![Añadir persona](AutoManager/images/añadir_persona.png)

### Creación de Coches
🚘 Desde la pantalla principal, haz clic en el botón "Añadir" de la lista de coches.

📝 Completa el formulario con la marca, modelo y VIN del coche.

💾 Haz clic en "Guardar" para crear el coche. 

![Añadir coche](AutoManager/images/añadir_coche.png)

### Asignación de Coches a Personas
✏️ Desde la pantalla principal, selecciona el boton "Asignaciones".

👤 Selecciona una persona de la lista desplegable.

🚗 Selecciona un coche de la lista desplegable.

✔️ Haz clic en "Asignar" para asignar el coche a la persona.


![Asignar coche](AutoManager/images/asignar_coche.png)


### Edición de Personas y Coches
✏️ Desde la pantalla principal, selecciona el elemento que deseas editar de la lista de Personas, Coches o Asignaciones.

🔄 Haz clic en el botón "Editar" .

📝 Realiza los cambios necesarios en el formulario.

💾 Haz clic en "Guardar" para aplicar los cambios.


![Editar persona](AutoManager/images/editar_persona.png)

![Editar coche](AutoManager/images/editar_coche.png)

![Editar asignación](AutoManager/images/editar_asignacion.png)


### Eliminación de Personas y Coches
❌ Desde la pantalla principal, selecciona el elemento que deseas eliminar de la lista de Personas o Coches.

🗑️ Haz clic en el botón "Eliminar" .

⚠️ Haz clic en "Eliminar Coche" "Eliminar Persona" para aplicar los cambios.

![Eliminar coche](AutoManager/images/eliminar_coche.png)

## Validaciones

### Personas
🔒 No puede existir más de una persona con el mismo nombre y apellido.

![validación 1](AutoManager/images/validacion1.png)

### Coches
🔒 No puede existir más de un coche con el mismo VIN.

![validación 2](AutoManager/images/validacion2.png)

### Asignaciones
🔒 Una persona puede tener uno o más coches.

![validación 3](AutoManager/images/validacion3.png)

🔒 Un coche solo puede pertenecer a una persona (solo puede existir un propietario por coche).

![validación 4](AutoManager/images/validacion4.png)

## AutoManagerDB

🔍 Comprovació de que tot el que emfet fins ara s'ha realitzat a la base de daes.

![AutoManagerDB](AutoManager/images/AutoManagerDB.png)


