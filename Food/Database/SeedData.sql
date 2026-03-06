-- SQL Script to insert dummy data for FoodCampus

-- 1. Insert 15 restaurants
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES
('Pizza Campus', 'Italiana', '10:00', '22:00'),
('Burger Hall', 'Americana', '11:00', '21:00'),
('Taco Station', 'Mexicana', '08:00', '20:00'),
('Sushi University', 'Japonesa', '12:00', '22:00'),
('Veggie Garden', 'Vegetariana', '09:00', '19:00'),
('Chicken Lab', 'Pollo', '11:00', '21:30'),
('Healthy Bowl', 'Ensaladas', '10:00', '18:00'),
('Bakery Hub', 'Pastelería', '07:00', '18:00'),
('Pasta Place', 'Italiana', '11:30', '21:00'),
('Grill Masters', 'Carnes', '13:00', '23:00'),
('Oriental Express', 'China', '11:00', '21:00'),
('Juice Corner', 'Jugos', '08:00', '17:00'),
('Dessert Room', 'Postres', '12:00', '20:00'),
('Smoothie Factory', 'Bebidas', '09:00', '19:00'),
('Quick Snack', 'Snacks', '08:00', '22:00');

-- 2. Insert some historic orders
INSERT INTO Pedido (IdRestaurante, IdUsuario, FechaHora, CostoEnvio) VALUES
(1, 101, '2026-03-01 12:30:00', 15.00),
(2, 102, '2026-03-01 13:15:00', 10.00),
(3, 103, '2026-03-02 14:00:00', 12.50),
(1, 104, '2026-03-03 18:45:00', 15.00);

-- 3. Insert related order details
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES
(1, 10, 2, 200.00), -- Order 1: Pizza
(1, 11, 1, 30.00),  -- Order 1: Soda
(2, 20, 1, 85.00),  -- Order 2: Burger
(3, 30, 3, 45.00),  -- Order 3: Tacos
(4, 12, 1, 120.00); -- Order 4: Pasta
