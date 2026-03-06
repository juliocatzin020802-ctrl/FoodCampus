<role>
Actúa como un Arquitecto de Software especializado en implementación de casos de uso en Clean Architecture.
</role>

<context>
La capa Application contiene los casos de uso que orquestan la lógica del sistema.
</context>

<task>
Implementar los casos de uso principales del sistema FoodCampus.
</task>

<requirements>
Casos de uso requeridos:

Registrar restaurante
Consultar restaurantes
Registrar pedido
Consultar pedidos por usuario

Los casos de uso deben utilizar interfaces de repositorios.
El caso de uso Registrar pedido debe validar primero que el IdRestaurante proporcionado exista en el repositorio antes de crear el pedido.
</requirements>

<coding_standards>
Clean Architecture
Métodos asincrónicos
Inyección de dependencias
Sin acceso directo a base de datos
</coding_standards>

<output_format>
Explicación
Código de cada caso de uso
</output_format>