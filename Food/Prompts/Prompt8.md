<role>
Actúa como un desarrollador experto en aplicaciones de consola en .NET 10.
</role>

<context>
El sistema FoodCampus permite a los estudiantes interactuar con pedidos. 
La base de datos está en SQL Server (Somee).
</context>

<task>
Implementar el menú interactivo de la aplicación de consola con inyección de dependencias.
</task>

<requirements>
El menú debe incluir:
1. Registrar restaurante
2. Consultar restaurantes
3. Registrar pedido (Flujo mejorado):
   - Al seleccionar esta opción, el sistema debe llamar a 'Consultar restaurantes' y mostrar la lista.
   - El usuario debe elegir un restaurante ingresando su ID.
   - Validar que el ID exista.
   - Solicitar los datos del pedido (Usuario, Platillos, Cantidad).
4. Consultar pedidos por usuario
5. Salir

Reglas técnicas:
- Manejo de errores con bloques try-catch.
- Mensajes de error en ConsoleColor.Red.
- Uso de Console.Clear() para mantener la interfaz limpia.
- El ConnectionString de Somee debe leerse desde un archivo de configuración o constante centralizada.
</requirements>

<coding_standards>
C# 14, Programación Asincrónica (async/await), Clean Code.
</coding_standards>

<output_format>
Explicación del flujo de selección de restaurante y código completo de la clase Program y el menú.
</output_format>