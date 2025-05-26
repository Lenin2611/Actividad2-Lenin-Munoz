using System;

internal class Program
{
    private static readonly string defaultUser = "admin";
    private static readonly string defaultPassword = "1234";

    private static int totalUsers = 0;
    private static string userName1 = "", userName2 = "", userName3 = "", userName4 = "", userName5 = "";
    private static string userName6 = "", userName7 = "", userName8 = "", userName9 = "", userName10 = "";
    private static string userId1 = "", userId2 = "", userId3 = "", userId4 = "", userId5 = "";
    private static string userId6 = "", userId7 = "", userId8 = "", userId9 = "", userId10 = "";

    private static int totalItems = 0;
    private static string itemName1 = "", itemName2 = "", itemName3 = "", itemName4 = "", itemName5 = "";
    private static string itemName6 = "", itemName7 = "", itemName8 = "", itemName9 = "", itemName10 = "";
    private static int itemPrice1 = 0, itemPrice2 = 0, itemPrice3 = 0, itemPrice4 = 0, itemPrice5 = 0;
    private static int itemPrice6 = 0, itemPrice7 = 0, itemPrice8 = 0, itemPrice9 = 0, itemPrice10 = 0;

    static int totalSaleItems = 5;
    static string saleItemName1 = "", saleItemName2 = "", saleItemName3 = "", saleItemName4 = "", saleItemName5 = "";
    static int saleItemQuantity1 = 0, saleItemQuantity2 = 0, saleItemQuantity3 = 0, saleItemQuantity4 = 0, saleItemQuantity5 = 0;
    static int soldItemQuantity1 = 0, soldItemQuantity2 = 0, soldItemQuantity3 = 0, soldItemQuantity4 = 0, soldItemQuantity5 = 0;


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

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Ingrese el nombre completo del usuario {i + 1}: ");
            string name = Console.ReadLine()!;
            Console.Write($"Ingrese la cédula del usuario {i + 1}: ");
            string id = Console.ReadLine()!;
            Console.Clear();
            SetUserName(i, name);
            SetUserId(i, id);
            totalUsers++;
        }

        bool pass = true;
        while (pass)
        {
            Console.Clear();
            switch (showMenu("usuarios"))
            {
                case "1":
                    ShowUser();
                    break;
                case "2":
                    AddUser();
                    break;
                case "3":
                    EditUser();
                    break;
                case "4":
                    pass = false;
                    clearUsers();
                    break;
                default:
                    showMessage("Opción no válida.", true);
                    break;
            }
        }
    }

    private static void ShowUser()
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("Lista de usuarios:");
            for (int i = 0; i < totalUsers; i++)
            {
                Console.WriteLine($"{i + 1}. {GetUserId(i)}");
            }

            Console.Write($"Ingrese el número del usuario que quiere observar (1-{totalUsers}): ");
            string input = Console.ReadLine()!;
            Console.Clear();

            if (int.TryParse(input, out int index) && index > 0 && index <= totalUsers)
            {
                string id = GetUserId(index - 1);
                string name = GetUserName(index - 1);
                showMessage($"{id} {name}", true);
                loop = false;
            }
            else
            {
                showMessage("Ingrese una opción del menú válida.", false);
            }
        }
    }

    private static void AddUser()
    {
        if (totalUsers >= 10)
        {
            showMessage("No se pueden agregar más usuarios. Límite alcanzado.", false);
            return;
        }

        Console.Write("Ingrese el nombre del nuevo usuario: ");
        string name = Console.ReadLine()!;
        Console.Write("Ingrese la cédula del nuevo usuario: ");
        string id = Console.ReadLine()!;
        Console.Clear();

        SetUserName(totalUsers, name);
        SetUserId(totalUsers, id);
        totalUsers++;

        showMessage("Usuario agregado exitosamente.", false);
    }

    private static void EditUser()
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("Lista de usuarios:");
            for (int i = 0; i < totalUsers; i++)
            {
                Console.WriteLine($"{i + 1}. {GetUserId(i)}");
            }

            Console.Write($"Ingrese el número del usuario que quiere editar (1-{totalUsers}): ");
            string input = Console.ReadLine()!;
            Console.Clear();

            if (int.TryParse(input, out int index) && index > 0 && index <= totalUsers)
            {
                string oldName = GetUserName(index - 1);
                Console.Write($"Ingrese el nuevo nombre para el usuario {oldName}: ");
                SetUserName(index - 1, Console.ReadLine()!);
                Console.Clear();
                showMessage($"Nombre de usuario {oldName} fue actualizado a {GetUserName(index - 1)}.", true);
                loop = false;
            }
            else
            {
                showMessage("Ingrese una opción del menú válida.", false);
            }
        }
    }

    private static void clearUsers()
    {
        userName1 = userName2 = userName3 = userName4 = userName5 = "";
        userName6 = userName7 = userName8 = userName9 = userName10 = "";
        userId1 = userId2 = userId3 = userId4 = userId5 = "";
        userId6 = userId7 = userId8 = userId9 = userId10 = "";
        totalUsers = 0;
    }

    private static string GetUserName(int index) => index switch
    {
        0 => userName1,
        1 => userName2,
        2 => userName3,
        3 => userName4,
        4 => userName5,
        5 => userName6,
        6 => userName7,
        7 => userName8,
        8 => userName9,
        9 => userName10,
        _ => ""
    };

    private static string GetUserId(int index) => index switch
    {
        0 => userId1,
        1 => userId2,
        2 => userId3,
        3 => userId4,
        4 => userId5,
        5 => userId6,
        6 => userId7,
        7 => userId8,
        8 => userId9,
        9 => userId10,
        _ => ""
    };

    private static void SetUserName(int index, string name)
    {
        switch (index)
        {
            case 0: userName1 = name; break;
            case 1: userName2 = name; break;
            case 2: userName3 = name; break;
            case 3: userName4 = name; break;
            case 4: userName5 = name; break;
            case 5: userName6 = name; break;
            case 6: userName7 = name; break;
            case 7: userName8 = name; break;
            case 8: userName9 = name; break;
            case 9: userName10 = name; break;
        }
    }

    private static void SetUserId(int index, string id)
    {
        switch (index)
        {
            case 0: userId1 = id; break;
            case 1: userId2 = id; break;
            case 2: userId3 = id; break;
            case 3: userId4 = id; break;
            case 4: userId5 = id; break;
            case 5: userId6 = id; break;
            case 6: userId7 = id; break;
            case 7: userId8 = id; break;
            case 8: userId9 = id; break;
            case 9: userId10 = id; break;
        }
    }

    private static void Items()
    {
        showMessage("¡Bienvenido al módulo de Gestión de Artículos!", true);

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            string itemName = Console.ReadLine()!;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"Ingrese el valor unitario del artículo {i + 1}: ");
                string price = Console.ReadLine()!;
                if (int.TryParse(price, out int p) && p > 0)
                {
                    SetItem(i, itemName, p);
                    valid = true;
                    totalItems++;
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
        while (pass)
        {
            Console.Clear();
            switch (showMenu("articulos"))
            {
                case "1":
                    ShowItem();
                    break;
                case "2":
                    AddItem();
                    break;
                case "3":
                    EditItem();
                    break;
                case "4":
                    clearItems();
                    pass = false;
                    break;
                default:
                    showMessage("Opción no válida.", false);
                    break;
            }
        }
    }

    private static void ShowItem()
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("Lista de artículos:");
            for (int j = 0; j < totalItems; j++)
            {
                Console.WriteLine($"{j + 1}. {GetItemName(j)}");
            }

            Console.Write($"Ingrese el número del artículo que quiere observar (1-{totalItems}): ");
            string item = Console.ReadLine()!;
            Console.Clear();

            if (int.TryParse(item, out int i) && i > 0 && i <= totalItems)
            {
                showMessage($"{GetItemName(i - 1)} {GetItemPrice(i - 1)}", true);
                loop = false;
            }
            else
            {
                showMessage("Ingrese una opción del menú válida.", false);
            }
        }
    }

    private static void AddItem()
    {
        if (totalItems >= 10)
        {
            showMessage("No se pueden agregar más artículos. Límite alcanzado.", false);
            return;
        }

        Console.Write("Ingrese el nombre del nuevo artículo: ");
        string newItemName = Console.ReadLine()!;
        bool valid = false;
        while (!valid)
        {
            Console.Write("Ingrese el valor unitario del nuevo artículo: ");
            string price = Console.ReadLine()!;
            if (int.TryParse(price, out int p) && p > 0)
            {
                SetItem(totalItems, newItemName, p);
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
    }

    private static void EditItem()
    {
        bool loop = true;
        while (loop)
        { 

            Console.WriteLine("Lista de artículos:");
            for (int j = 0; j < totalItems; j++)
            {
                Console.WriteLine($"{j + 1}. {GetItemName(j)}");
            }

            Console.Write($"Ingrese el número del artículo que quiere editar (1-{totalItems}): ");
            string item = Console.ReadLine()!;
            Console.Clear();

            if (int.TryParse(item, out int i) && i > 0 && i <= totalItems)
            {
                string itemNameToUpdate = GetItemName(i - 1);
                int itemPriceToUpdate = GetItemPrice(i - 1);
                bool valid = false;
                while (!valid)
                {
                    Console.Write($"Ingrese el nuevo valor unitario para el artículo {itemNameToUpdate}, valor actual {itemPriceToUpdate}: ");
                    string price = Console.ReadLine()!;
                    if (int.TryParse(price, out int p) && p > 0)
                    {
                        SetItem(i - 1, itemNameToUpdate, p);
                        valid = true;
                    }
                    else
                    {
                        Console.Clear();
                        showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                    }
                }
                Console.Clear();
                showMessage($"Valor de artículo {itemNameToUpdate} fue actualizado a {GetItemPrice(i - 1)}.", true);
                loop = false;
            }
            else
            {
                showMessage("Ingrese una opción del menú válida.", false);
            }
        }
    }

    private static void clearItems()
    {
        itemName1 = itemName2 = itemName3 = itemName4 = itemName5 = "";
        itemName6 = itemName7 = itemName8 = itemName9 = itemName10 = "";
        itemPrice1 = itemPrice2 = itemPrice3 = itemPrice4 = itemPrice5 = 0;
        itemPrice6 = itemPrice7 = itemPrice8 = itemPrice9 = itemPrice10 = 0;
        totalItems = 0;
    }

    private static string GetItemName(int index) => index switch
    {
        0 => itemName1,
        1 => itemName2,
        2 => itemName3,
        3 => itemName4,
        4 => itemName5,
        5 => itemName6,
        6 => itemName7,
        7 => itemName8,
        8 => itemName9,
        9 => itemName10,
        _ => ""
    };

    private static int GetItemPrice(int index) => index switch
    {
        0 => itemPrice1,
        1 => itemPrice2,
        2 => itemPrice3,
        3 => itemPrice4,
        4 => itemPrice5,
        5 => itemPrice6,
        6 => itemPrice7,
        7 => itemPrice8,
        8 => itemPrice9,
        9 => itemPrice10,
        _ => 0
    };

    private static void SetItem(int index, string name, int price)
    {
        switch (index)
        {
            case 0: itemName1 = name; itemPrice1 = price; break;
            case 1: itemName2 = name; itemPrice2 = price; break;
            case 2: itemName3 = name; itemPrice3 = price; break;
            case 3: itemName4 = name; itemPrice4 = price; break;
            case 4: itemName5 = name; itemPrice5 = price; break;
            case 5: itemName6 = name; itemPrice6 = price; break;
            case 6: itemName7 = name; itemPrice7 = price; break;
            case 7: itemName8 = name; itemPrice8 = price; break;
            case 8: itemName9 = name; itemPrice9 = price; break;
            case 9: itemName10 = name; itemPrice10 = price; break;
        }
    }

    private static void Sales()
    {
        showMessage("¡Bienvenido al módulo de Gestión de Ventas!", true);
        int allSoldItems = 0;

        for (int i = 0; i < totalSaleItems; i++)
        {
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            string saleItemName = Console.ReadLine()!;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"Ingrese la cantidad de unidades del artículo {i + 1}: ");
                string quantity = Console.ReadLine()!;
                if (int.TryParse(quantity, out int q) && q > 0)
                {
                    SetSaleItem(i, saleItemName, q);
                    allSoldItems += q;
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
        while (pass)
        {
            Console.Clear();
            switch (showMenu("ventas"))
            {
                case "1":
                    bool loop = true;
                    while (loop)
                    {
                        Console.WriteLine("Lista de artículos:");
                        for (int j = 0; j < totalSaleItems; j++)
                        {
                            Console.WriteLine($"{j + 1}. {GetSaleItemName(j)}");
                        }

                        Console.Write($"Ingrese el número del artículo que quiere comprar (1-{totalSaleItems}): ");
                        string item = Console.ReadLine()!;
                        Console.Clear();

                        if (!int.TryParse(item, out int i) || i > totalSaleItems || i <= 0)
                        {
                            showMessage("Ingrese una opción del menú válida.", false);
                        }
                        else
                        {
                            i -= 1;
                            if (GetSaleItemQuantity(i) == 0)
                            {
                                showMessage($"No hay más unidades de {GetSaleItemName(i)} disponibles.", false);
                            }
                            else
                            {
                                bool valid = false;
                                while (!valid)
                                {
                                    Console.WriteLine($"{GetSaleItemName(i)} - {GetSaleItemQuantity(i)} unidades disponibles\n");
                                    Console.Write($"Ingrese la cantidad de unidades que desea comprar: ");
                                    string saleQuantity = Console.ReadLine()!;
                                    if (int.TryParse(saleQuantity, out int q) && q > 0)
                                    {
                                        if (q > GetSaleItemQuantity(i))
                                        {
                                            Console.Clear();
                                            showMessage("No hay cantidad suficiente del artículo.", false);
                                        }
                                        else
                                        {
                                            UpdateSaleQuantity(i, q);
                                            allSoldItems -= q;
                                            Console.Clear();
                                            Console.WriteLine($"Producto comprado: {GetSaleItemName(i)} - {q} unidades.");
                                            valid = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        showMessage("Entrada inválida. Por favor, ingrese un número entero positivo.", false);
                                    }
                                }

                                if (allSoldItems == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Productos Comprados:");
                                    for (int j = 0; j < totalSaleItems; j++)
                                    {
                                        int sold = GetSoldItemQuantity(j);
                                        if (sold > 0)
                                            Console.WriteLine($"{GetSaleItemName(j)} - {sold}");
                                    }
                                    showMessage("Compra exitosa. No hay más productos para comprar.", true);
                                    ResetSales();
                                    loop = false;
                                    pass = false;
                                }
                                else
                                {
                                    bool loop1 = true;
                                    while (loop1)
                                    {
                                        switch (showMenu("nuevaVenta"))
                                        {
                                            case "1":
                                                loop1 = false;
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.WriteLine("Productos Comprados:");
                                                for (int j = 0; j < totalSaleItems; j++)
                                                {
                                                    int sold = GetSoldItemQuantity(j);
                                                    if (sold > 0)
                                                        Console.WriteLine($"{GetSaleItemName(j)} - {sold}");
                                                }
                                                showMessage("Compra exitosa.", true);
                                                ResetSales();
                                                loop = false;
                                                loop1 = false;
                                                pass = false;
                                                break;
                                            default:
                                                showMessage("Opción no válida.", false);
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "2":
                    pass = false;
                    break;

                default:
                    showMessage("Opción no válida.", true);
                    break;
            }
        }
    }

    private static string GetSaleItemName(int index) => index switch
    {
        0 => saleItemName1,
        1 => saleItemName2,
        2 => saleItemName3,
        3 => saleItemName4,
        4 => saleItemName5,
        _ => ""
    };

    private static int GetSaleItemQuantity(int index) => index switch
    {
        0 => saleItemQuantity1,
        1 => saleItemQuantity2,
        2 => saleItemQuantity3,
        3 => saleItemQuantity4,
        4 => saleItemQuantity5,
        _ => 0
    };

    private static int GetSoldItemQuantity(int index) => index switch
    {
        0 => soldItemQuantity1,
        1 => soldItemQuantity2,
        2 => soldItemQuantity3,
        3 => soldItemQuantity4,
        4 => soldItemQuantity5,
        _ => 0
    };

    private static void SetSaleItem(int index, string name, int quantity)
    {
        switch (index)
        {
            case 0: saleItemName1 = name; saleItemQuantity1 = quantity; break;
            case 1: saleItemName2 = name; saleItemQuantity2 = quantity; break;
            case 2: saleItemName3 = name; saleItemQuantity3 = quantity; break;
            case 3: saleItemName4 = name; saleItemQuantity4 = quantity; break;
            case 4: saleItemName5 = name; saleItemQuantity5 = quantity; break;
        }
    }

    private static void UpdateSaleQuantity(int index, int quantity)
    {
        switch (index)
        {
            case 0: saleItemQuantity1 -= quantity; soldItemQuantity1 += quantity; break;
            case 1: saleItemQuantity2 -= quantity; soldItemQuantity2 += quantity; break;
            case 2: saleItemQuantity3 -= quantity; soldItemQuantity3 += quantity; break;
            case 3: saleItemQuantity4 -= quantity; soldItemQuantity4 += quantity; break;
            case 4: saleItemQuantity5 -= quantity; soldItemQuantity5 += quantity; break;
        }
    }

    private static void ResetSales()
    {
        saleItemName1 = saleItemName2 = saleItemName3 = saleItemName4 = saleItemName5 = "";
        saleItemQuantity1 = saleItemQuantity2 = saleItemQuantity3 = saleItemQuantity4 = saleItemQuantity5 = 0;
        soldItemQuantity1 = soldItemQuantity2 = soldItemQuantity3 = soldItemQuantity4 = soldItemQuantity5 = 0;
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