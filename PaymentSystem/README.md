# Tecnologias implementadas

1. **Entity Framework Core Tools**: Se utilizan principalmente para administrar migraciones y para andamiar tipos y entidades mediante ingeniería inversa del esquema de una base de datos.
2. **Entity Framework Core**: Se implemento para realizar el mapeo de las tablas de la base de datos a objetos dentro del proyecto.
3. **Entity FrameworkCore SqlServer**: Es el Proveedor de base de datos de Microsoft SQL Server para Entity Framework Core.
4. **AspNetCore Authentication JwtBearer**: Este paquete se implemento para generar los tokens de acceso a la aplicacion.

# Ejecucion del proyecto

1. Generar la base de datos con el script proporcionado.
2. Clonar clonar el repositorio del proyecto.
3. una vez ejecutado el proyecto, con postman o cualquir herramienta similar, ingresar a la URI /auth/login con las diguientes cresenciales "email":"admin@email.com" y "password":"1234".
```json
{
    "Email": "admin@email.com",
    "Password": "1234"
}
```
4. Una vez obtenido el token ingresar a el Endpoint REST del servicio de pago. /api/payments enviando una peticion como la que se muestra en el siguiente ejemplo, el id de los productos se obtiene de la Endpoint /api/products/ .
```json
{
    "idUser": 1,
    "orderDate": "2022-03-20",
    "orderDetails": [
        {
            "quantity": 1,
            "idProduct": 1,
            "value": 4697130.0000
        },
        {
            "quantity": 2,
            "idProduct": 3,
            "value": 1580490.0000
        }
    ]
}
```
