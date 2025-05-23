using System;

internal class Program
{
    private static readonly string defaultUser = "admin";
    private static readonly string defaultPassword = "1234";

    private static readonly List<string> userNames = [];
    private static readonly List<string> userIds = [];
    private static int totalUsers = 5;

    private static readonly List<string> itemNames = [];
    private static readonly List<int> itemPrices = [];
    private static int totalItems = 5;

    private static readonly List<string> saleItemNames = [];
    private static readonly List<int> saleItemQuantities = [];
    private static int totalSaleItems = 5;

    private static void Main(string[] args)
    {
        AutenticarUsuario();
    }

    private static void AutenticarUsuario()
    {
        Console.Clear();
        bool loop = true;
        while (loop)
        {
            Console.Write("Ingrese el nombre de usuario: ");
            string inputUser = Console.ReadLine()!;

            Console.Write("Ingrese la contraseña: ");
            string inputPassword = Console.ReadLine()!;

            Console.Clear();
            if (inputUser == defaultUser && inputPassword == defaultPassword)
            {
                loop = false;
                showMessage("¡Bienvenido al sistema!", true);
                ShowMainMenu();
            }
            else
            {
                showMessage("Error de autenticación. Usuario o contraseña incorrectos.", false);
            }
        }
    }

    private static void ShowMainMenu()
    {
        bool loop = true;
        while (loop)
        {
            switch (showMenu("main"))
            {
                case "1":
                    Users();
                    break;
                case "2":
                    Items();
                    break;
                case "3":
                    Sales();
                    break;
                case "4":
                    Console.WriteLine("Se ha cerrado sesión en el programa. ¡Hasta luego!\n");
                    loop = false;
                    break;
                default:
                    showMessage("Entrada no válida. Por favor, ingrese un número del 1 al 4.", false);
                    break;
            }
        }
    }

    private static void Users()
    {
        showMessage("¡Bienvenido al módulo de Gestión de Usuarios!", true);
        for (int i = 0; i < totalUsers; i++)
        {
            Console.Write($"Ingrese el nombre completo del usuario {i + 1}: ");
            userNames.Add(Console.ReadLine()!);
            Console.Write($"Ingrese la cédula del usuario {i + 1}: ");
            userIds.Add(Console.ReadLine()!);
            Console.Clear();
        }

        bool pass = true;
        bool loop = true;
        while (pass)
        {
            Console.Clear();
            switch (showMenu("usuarios"))
            {
                case "1":
                    loop = true;
                    while (loop)
                    {
                        Console.WriteLine("Lista de usuarios:");
                        for (int i = 0; i < totalUsers; i++)
                        {
                            Console.WriteLine($"{i + 1}. {userIds[i]}");
                        }
                        Console.Write($"Ingrese el número del usuario que quiere observar (1-{totalUsers}): ");
                        string user = Console.ReadLine()!;
                        Console.Clear();
                        if (!int.TryParse(user, out int u) || u > totalUsers || u <= 0)
                        {
                            showMessage("Ingrese una opción del menú válida.", false);
                        }
                        else
                        {
                            showMessage($"{userIds[u - 1]} {userNames[u - 1]}", true);
                            loop = false;
                        }
                    }
                    break;
                case "2":
                    loop = true;
                    while (loop)
                    {
                        switch (showMenu("nuevoUsuario"))
                        {
                            case "1":
                                Console.Write("Ingrese el nombre del nuevo usuario: ");
                                userNames.Add(Console.ReadLine()!);
                                Console.Write("Ingrese la cédula del nuevo usuario: ");
                                userIds.Add(Console.ReadLine()!);
                                totalUsers++;
                                Console.Clear();
                                showMessage("Usuario agregado exitosamente.", false);
                                break;
                            case "2":
                                loop = false;
                                break;
                            default:
                                showMessage("Ingrese una opción del menú válida.", false);
                                break;
                        }
                    }
                    break;
                case "3":
                    loop = true;
                    while (loop)
                    {
                        Console.WriteLine("Lista de usuarios:");
                        for (int i = 0; i < totalUsers; i++)
                        {
                            Console.WriteLine($"{i + 1}. {userIds[i]}");
                        }
                        Console.Write($"Ingrese el número del usuario que quiere editar (1-{totalUsers}): ");
                        string user = Console.ReadLine()!;
                        Console.Clear();
                        if (!int.TryParse(user, out int u) || u > totalUsers || u <= 0)
                        {
                            showMessage("Ingrese una opción del menú válida.", false);
                        }
                        else
                        {
                            string userToUpdate = userNames[u - 1];
                            Console.Write($"Ingrese el nuevo nombre para el usuario {userToUpdate}: ");
                            userNames[u - 1] = Console.ReadLine()!;
                            Console.Clear();
                            showMessage($"Nombre de usuario {userToUpdate} fue actualizado a {userNames[u - 1]}.", true);
                            loop = false;
                        }
                    }
                    break;
                case "4":
                    pass = false;
                    break;
                default:
                    showMessage("Opción no valida.", true);
                    break;
            }
        }
    }


    private static void Items()
    {
        showMessage("¡Bienvenido al módulo de Gestión de Artículos!", true);
        bool valid = false;
        for (int i = 0; i < totalItems; i++)
        {
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            string itemName = Console.ReadLine()!;
            valid = false;
            while (!valid)
            {
                Console.Write($"Ingrese el valor unitario del artículo {i + 1}: ");
                string price = Console.ReadLine()!;
                if (int.TryParse(price, out int p) && p > 0)
                {
                    itemNames.Add(itemName);
                    itemPrices.Add(p);
                    valid = true;
                }
                else
                {
                    Console.Clear();
                    showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                    Console.WriteLine($"Ingrese el nombre del artículo {i + 1}: {itemName}");
                }
            }
            Console.Clear();
        }

        bool pass = true;
        bool loop = true;
        while (pass)
        {
            Console.Clear();
            switch (showMenu("articulos"))
            {
                case "1":
                    loop = true;
                    while (loop)
                    {
                        Console.WriteLine("Lista de artículos:");
                        for (int j = 0; j < totalItems; j++)
                        {
                            Console.WriteLine($"{j + 1}. {itemNames[j]}");
                        }
                        Console.Write($"Ingrese el número del artículo que quiere observar (1-{totalItems}): ");
                        string item = Console.ReadLine()!;
                        Console.Clear();
                        if (!int.TryParse(item, out int i) || i > totalItems || i <= 0)
                        {
                            showMessage("Ingrese una opción del menú válida.", false);
                        }
                        else
                        {
                            showMessage($"{itemNames[i - 1]} {itemPrices[i - 1]}", true);
                            loop = false;
                        }
                    }
                    break;
                case "2":
                    loop = true;
                    while (loop)
                    {
                        switch (showMenu("nuevoArticulo"))
                        {
                            case "1":
                                Console.Write("Ingrese el nombre del nuevo artículo: ");
                                string newItemName = Console.ReadLine()!;
                                valid = false;
                                while (!valid)
                                {
                                    Console.Write("Ingrese el valor unitario del nuevo artículo: ");
                                    string price = Console.ReadLine()!;
                                    if (int.TryParse(price, out int p) && p > 0)
                                    {
                                        itemPrices.Add(p);
                                        itemNames.Add(newItemName);
                                        totalItems++;
                                        valid = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                                        Console.WriteLine($"Ingrese el nombre del nuevo artículo: {newItemName}");
                                    }
                                }
                                Console.Clear();
                                showMessage("Artículo agregado exitosamente.", false);
                                break;
                            case "2":
                                loop = false;
                                break;
                            default:
                                showMessage("Ingrese una opción del menú válida.", false);
                                break;
                        }
                    }
                    break;
                case "3":
                    loop = true;
                    while (loop)
                    {
                        Console.WriteLine("Lista de artículos:");
                        for (int j = 0; j < totalItems; j++)
                        {
                            Console.WriteLine($"{j + 1}. {itemNames[j]}");
                        }
                        Console.Write($"Ingrese el número del artículo que quiere editar (1-{totalItems}): ");
                        string item = Console.ReadLine()!;
                        Console.Clear();
                        if (!int.TryParse(item, out int i) || i > totalItems || i <= 0)
                        {
                            showMessage("Ingrese una opción del menú válida.", false);
                        }
                        else
                        {
                            string itemNameToUpdate = itemNames[i - 1];
                            int itemPriceToUpdate = itemPrices[i - 1];
                            valid = false;
                            while (!valid)
                            {
                                Console.Write($"Ingrese el nuevo valor unitario para el artículo {itemNameToUpdate}, valor actual {itemPriceToUpdate}: ");
                                string price = Console.ReadLine()!;
                                if (int.TryParse(price, out int p) && p > 0)
                                {
                                    itemPrices[i - 1] = p;
                                    valid = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                                }
                            }
                            Console.Clear();
                            showMessage($"Valor de artículo {itemNameToUpdate} - {itemPriceToUpdate} fue actualizado a {itemPrices[i - 1]}.", true);
                            loop = false;
                        }
                    }
                    break;
                case "4":
                    pass = false;
                    break;
                default:
                    showMessage("Opción no valida.", false);
                    break;
            }
        }
    }


    private static void Sales()
    {
        showMessage("¡Bienvenido al módulo de Gestión de Ventas!", true);
        bool valid = false;
        for (int i = 0; i < totalSaleItems; i++)
        {
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            string saleItemName = Console.ReadLine()!;
            valid = false;
            while (!valid)
            {
                Console.Write($"Ingrese la cantidad de unidades del artículo {i + 1}: ");
                string quantity = Console.ReadLine()!;
                if (int.TryParse(quantity, out int q) && q > 0)
                {
                    saleItemNames.Add(saleItemName);
                    saleItemQuantities.Add(q);
                    valid = true;
                }
                else
                {
                    Console.Clear();
                    showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                    Console.WriteLine($"Ingrese el nombre del artículo {i + 1}: {saleItemName}");
                }
            }
            Console.Clear();
        }

        bool pass = true;
        bool loop = true;
        while (pass)
        {
            Console.Clear();
            switch (showMenu("ventas"))
            {
                case "1":
                    int count = 0;
                    loop = true;
                    while (loop)
                    {
                        Console.WriteLine("Lista de artículos:");
                        for (int j = 0; j < totalSaleItems; j++)
                        {
                            Console.WriteLine($"{j + 1}. {saleItemNames[j]}");
                        }
                        Console.Write($"Ingrese el número del artículo que quiere comprar (1-{totalSaleItems}): ");
                        string item = Console.ReadLine()!;
                        Console.Clear();
                        if (!int.TryParse(item, out int i) || i > totalItems || i <= 0)
                        {
                            showMessage("Ingrese una opción del menú válida.", false);
                        }
                        else
                        {
                            valid = false;
                            while (!valid)
                            {
                                Console.WriteLine($"{saleItemNames[i - 1]} - {saleItemQuantities[i - 1]}\n");
                                Console.Write($"Ingrese la cantidad de unidades del artículo {saleItemNames[i - 1]} que desea comprar: ");
                                string saleQuantity = Console.ReadLine()!;
                                if (int.TryParse(saleQuantity, out int q) && q > 0)
                                {
                                    if (q > saleItemQuantities[i - 1])
                                    {
                                        Console.Clear();
                                        showMessage("No hay cantidad suficiente del artículo.", false);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Producto comprado {saleItemNames[i - 1]} - {saleQuantity} unidades.");
                                        count++;
                                        totalSaleItems--;
                                        saleItemNames.Remove(saleItemNames[i - 1]);
                                        valid = true;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                                }
                            }
                            if (count == 5)
                            {
                                Console.Clear();
                                showMessage("Compra existosa. Máximo de productos alcanzado.", true);
                                totalSaleItems = 5;
                                loop = false;
                                pass = false;
                            }
                            else
                            {
                                switch (showMenu("nuevaVenta"))
                                {
                                    case "1":
                                        break;
                                    case "2":
                                        Console.Clear();
                                        showMessage("Compra exitosa.", true);
                                        totalSaleItems = 5;
                                        loop = false;
                                        pass = false;
                                        break;
                                    default:
                                        showMessage("Opción no valida.", false);
                                        break;
                                }
                            }
                        }
                    }
                    break;
                case "2":
                    pass = false;
                    break;
                default:
                    showMessage("Opción no valida.", true);
                    break;
            }
        }
    }
    private static void showMessage(string message, bool isContinue)
    {
        Console.Write($"{message} \n\nPresione cualquier tecla para " + (isContinue ? "continuar" : "volver") + ". . . ");
        Console.ReadKey();
        Console.Clear();
    }

    private static string showMenu(string menu)
    {
        switch (menu)
        {
            case "main":
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Gestión de usuarios");
                Console.WriteLine("2. Gestión de artículos");
                Console.WriteLine("3. Gestión de ventas");
                Console.WriteLine("4. Salir del programa");
                Console.Write("Seleccione una opción (1-4): ");
                break;
            case "usuarios":
                Console.WriteLine("===== GESTIÓN DE USUARIOS =====");
                Console.WriteLine("1. Ver lista de usuarios");
                Console.WriteLine("2. Nuevo usuario");
                Console.WriteLine("3. Editar información de usuario");
                Console.WriteLine("4. Salir de Gestión de usuarios");
                Console.Write("Seleccione una opción (1-4): ");
                break;
            case "nuevoUsuario":
                Console.WriteLine("===== NUEVO USUARIO =====");
                Console.WriteLine("1. Crear usuario");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción (1-2): ");
                break;
            case "articulos":
                Console.WriteLine("===== GESTIÓN DE ARTÍCULOS =====");
                Console.WriteLine("1. Ver lista de artículos");
                Console.WriteLine("2. Nuevo artículo");
                Console.WriteLine("3. Editar información del artículo");
                Console.WriteLine("4. Salir de Gestión de artículos");
                Console.Write("Seleccione una opción (1-4): ");
                break;
            case "nuevoArticulo":
                Console.WriteLine("===== NUEVO ARTÍCULO =====");
                Console.WriteLine("1. Crear artículo");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción (1-2): ");
                break;
            case "ventas":
                Console.WriteLine("===== GESTIÓN DE VENTAS =====");
                Console.WriteLine("1. Registrar venta");
                Console.WriteLine("2. Salir de Gestión de ventas");
                Console.Write("Seleccione una opción (1-2): ");
                break;
            case "nuevaVenta":
                Console.WriteLine("¿Desea ingresar un nuevo producto a su compra?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");
                Console.Write("Seleccione una opción (1-2): ");
                break;
        }
        string option = Console.ReadLine()!;
        Console.Clear();
        return option;

    }
}