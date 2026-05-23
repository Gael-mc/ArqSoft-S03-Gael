# 🎮 GameVault

**GameVault** es una aplicación web desarrollada en ASP.NET Core MVC diseñada para gestionar un catálogo de videojuegos personal. El sistema permite a los usuarios registrarse, iniciar sesión y administrar su propia colección, utilizando un enfoque de persistencia de datos ligero basado en archivos JSON, sin necesidad de configurar un motor de base de datos externo.

---

## ✨ Características Principales

* **🔒 Autenticación Segura:** Sistema de registro, inicio y cierre de sesión utilizando autenticación por Cookies. Las contraseñas se almacenan de forma segura mediante encriptación SHA-256.
* **🗂️ Gestión de Catálogo:** Operaciones para ver y agregar nuevos videojuegos a la colección personal.
* **💾 Almacenamiento Ligero:** Persistencia de datos mediante lectura y escritura de archivos `.json` locales (`items.json` y `usuarios.json`), ideal para proyectos portables.
* **🎨 Diseño Moderno:** Interfaz de usuario responsiva y atractiva, construida con HTML, CSS puro y Bootstrap.

---

## 📸 Capturas de Pantalla

### Pantalla de Inicio / Dashboard
<img width="1917" height="1077" alt="Screenshot 2026-05-22 213235" src="https://github.com/user-attachments/assets/36d6ccb0-4f2c-48a9-a083-c75e444b47e0" />



### Catálogo de Videojuegos y registro de Videojuegos 
<img width="1919" height="1079" alt="Screenshot 2026-05-22 213243" src="https://github.com/user-attachments/assets/b28e88df-9b85-47c1-842a-e97afc01c5f2" />

<img width="1919" height="1079" alt="Screenshot 2026-05-22 213251" src="https://github.com/user-attachments/assets/7828b35a-0d2b-42ad-b2e1-16281bcbd91b" />

### Reeseñas
<img width="1918" height="1077" alt="Screenshot 2026-05-22 213303" src="https://github.com/user-attachments/assets/9ba8a068-c19f-4448-88db-e7ad7e385065" />

<img width="1902" height="1077" alt="Screenshot 2026-05-22 213308" src="https://github.com/user-attachments/assets/325c3815-f5fe-47d1-8b4f-609193f0f01f" />

### Registro e Inicio de Sesión
<img width="1917" height="1074" alt="Screenshot 2026-05-22 213326" src="https://github.com/user-attachments/assets/7451cb31-b546-4797-b15e-427d6a2f024a" />

<img width="1919" height="1079" alt="Screenshot 2026-05-22 213331" src="https://github.com/user-attachments/assets/f1304735-3d80-460e-abe8-822d4c65528f" />

### Politica de privacidad y contacto 
<img width="1916" height="1076" alt="Screenshot 2026-05-22 213319" src="https://github.com/user-attachments/assets/baa64df2-6c17-4b08-956e-18ba62ed04cf" />





---

## 🛠️ Tecnologías Utilizadas

* **Backend:** C# / ASP.NET Core MVC (.NET)
* **Frontend:** HTML5, CSS3, Bootstrap
* **Persistencia de Datos:** System.Text.Json (Archivos de texto plano)
* **Seguridad:** System.Security.Cryptography (SHA256) y System.Security.Claims

---

## 🚀 Instalación y Uso

1. Clona este repositorio o descarga el código fuente.
2. Abre la solución (`.sln`) en **Visual Studio**.
3. Asegúrate de que las carpetas `data/` existan en la raíz del proyecto. Si no, créalas y añade los archivos vacíos `items.json` (`[]`) y `usuarios.json` (`[]`).
4. Presiona `Ctrl + F5` o haz clic en "Iniciar sin depurar" para compilar y ejecutar el proyecto en tu navegador local.

---

## 👤 Autor

**Gael Magaña Chan** *Desarrollador del proyecto.*

---

## 🤖 Cláusula de Uso de Inteligencia Artificial

Durante la fase de desarrollo, estructuración de la arquitectura MVC (Model-View-Controller) y depuración de errores de este proyecto, se utilizó el apoyo de modelos de Inteligencia Artificial generativa. La IA funcionó como una herramienta de asistencia o "copiloto" para agilizar la escritura de código repetitivo (boilerplate), implementar algoritmos específicos (como el encriptado Hash y la lectura/escritura de JSON) y diagnosticar errores de compilación. Todo el código fue revisado, adaptado, integrado y probado manualmente para asegurar su correcto funcionamiento y alineación con los requerimientos del sistema.
