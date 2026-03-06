<role>
Actúa como un Arquitecto de Bases de Datos experto en SQL Server y diseño de modelos relacionales para sistemas transaccionales.
</role>

<context>
El proyecto "FoodCampus" es un sistema de delivery universitario desarrollado en .NET 10. La base de datos estará alojada en Somee.com y debe respetar un límite máximo de almacenamiento.
El sistema manejará restaurantes y pedidos realizados por estudiantes.
</context>

<task>
Generar el script SQL necesario para crear las tablas del sistema siguiendo el modelo de datos definido.
</task>

<requirements>
El modelo debe incluir las siguientes tablas:

Restaurante:
Id
Nombre (obligatorio)
Especialidad
HorarioApertura
HorarioCierre

Pedido:
IdPedido (PK)
IdRestaurante (FK)
IdUsuario
FechaHora
CostoEnvio (no negativo)

DetallePedido:
IdDetalle
IdPedido
IdPlatillo
Cantidad (mayor a 0)
Subtotal

Debe incluir:

Primary Keys
Foreign Keys
Constraints de validación
Tipos de datos adecuados
</requirements>

<coding_standards>
SQL Server compatible con Somee
Uso de CHECK constraints para reglas de negocio
Uso de NOT NULL en campos obligatorios
Buenas prácticas de normalización
</coding_standards>

<output_format>
Genera:
Explicación breve del modelo
Script SQL completo de creación de tablas
Orden correcto de ejecución del script
</output_format>