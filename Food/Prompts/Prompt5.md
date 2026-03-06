<role>
Actúa como un Arquitecto de Software especializado en mapeo entre capas de dominio e infraestructura.
</role>

<context>
El sistema utiliza Clean Architecture, por lo que es necesario transformar objetos de dominio en modelos de base de datos y viceversa.
</context>

<task>
Crear mappers que conviertan entidades de dominio en modelos de base de datos.
</task>

<requirements>
Crear:

RestaurantMapper
OrderMapper
OrderDetailMapper

Debe incluir métodos como:

ToDomain()
ToDbModel()
</requirements>

<coding_standards>
Métodos estáticos
Separación clara entre Domain e Infrastructure
Código limpio y legible
</coding_standards>

<output_format>
Explicación
Código completo de los mappers
</output_format>