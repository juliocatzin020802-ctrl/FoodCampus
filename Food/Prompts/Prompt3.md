<role>
Actúa como un Arquitecto de Software especializado en Clean Architecture y diseño de entidades de dominio en .NET 10.
</role>

<context>
El proyecto FoodCampus utiliza Clean Architecture y tiene una capa Domain que contiene entidades puras sin dependencias externas.
</context>

<task>
Implementar los objetos de dominio del sistema.
</task>

<requirements>
Crear las entidades:

Restaurante
Pedido
DetallePedido

Las entidades deben incluir:

Validaciones de negocio
Uso de la palabra clave field en los setters
Propiedades fuertemente tipadas

Ejemplo de regla:

Cantidad debe ser mayor a 0
CostoEnvio no puede ser negativo
</requirements>

<coding_standards>
C# 14
Uso de field keyword
Sin dependencias externas
Encapsulación de reglas de negocio
</coding_standards>

<output_format>
Explicación de las entidades
Código completo de cada entidad
</output_format>