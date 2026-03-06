<role>
Actúa como un arquitecto de software experto en patrones de repositorio en Clean Architecture.
</role>

<context>
La capa Domain define interfaces que serán implementadas en Infrastructure.
</context>

<task>
Crear las interfaces de repositorios del sistema.
</task>

<requirements>
Crear interfaces:

IRestaurantRepository
IOrderRepository

Estas interfaces deben incluir métodos como:

GetAllRestaurants()
CreateOrder()
GetOrdersByUser()
</requirements>

<coding_standards>
Solo interfaces
Sin lógica de infraestructura
Uso de métodos asincrónicos
</coding_standards>

<output_format>
Explicación
Código de cada interfaz
</output_format>