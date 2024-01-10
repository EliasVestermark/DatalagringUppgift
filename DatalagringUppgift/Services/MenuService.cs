using DatalagringUppgift.Interfaces;
using DatalagringUppgift.Interfaces.IServices;
using DatalagringUppgift.Models;
using DatalagringUppgift.Models.Entities;

namespace DatalagringUppgift.Services;

public class MenuService : IMenuService
{

    private readonly IProductService _productService;
    private readonly IBookingService _bookingService;

    public MenuService(IBookingService bookingService, IProductService productService)
    {
        _bookingService = bookingService;
        _productService = productService;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            DisplayTitle("MAIN MENU");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Show all products");
            Console.WriteLine("3. Add booking");
            Console.WriteLine("4. Show all bookings");
            Console.WriteLine("x. Exit application");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowAddProductMenu();
                    break;

                //case "2":
                //    ShowAllProductsMenu();
                //    break;

                case "3":
                    ShowAddBookingMenu();
                    break;

                case "4":
                    ShowAllBookingsMenu();
                    break;

                case "x":
                    ShowExitMenu();
                    break;

                default:
                    Console.WriteLine("Invalid option, press any key then try again");
                    Console.ReadKey();
                    break;

            }
        }
    }

    private void ShowAddProductMenu()
    {
        DisplayTitle("ADD PRODUCT");

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Description: ");
        string description = Console.ReadLine()!;

        Console.Write("Ingridients, one ingridient at a time, press x when you are done: ");
        string ingridient = Console.ReadLine()!;

        while (ingridient != "x")
        {
            List<string> ingridients = [];
            ingridients.Add(ingridient);
            Console.WriteLine(ingridient);

            Console.Write("Next ingridient: ");
            ingridient = Console.ReadLine()!;
        }

        //Console.Write("Price: ");
        //string price = Console.ReadLine()!;

        //while (!_productService.NumberValidation(price!))
        //{
        //    Console.Write("Please enter a price number: ");
        //    price = Console.ReadLine()!;
        //}

        Console.WriteLine("Choose a category:");
        Console.WriteLine("1. Starter");
        Console.WriteLine("2. Main");
        Console.WriteLine("3. Dessert");

        var option = Console.ReadLine();
        string category = "";

        while (category == "")
        {
            switch (option)
            {
                case "1":
                    category = "starter";
                    break;

                case "2":
                    category = "main";
                    break;

                case "3":
                    category = "dessert";
                    break;

                default:
                    Console.WriteLine("Invalid option, try again");
                    option = Console.ReadLine()!;
                    break;
            }
        }
        
        //Product product = new(firstName, lastName, phoneNumber, email, address, postalCode, city);
        //var result = _productService.AddContact(contact);

        //switch (result.Status)
        //{
        //    case Enums.ServiceStatus.SUCCESS:
        //        Console.WriteLine("The contact has been added successfully");
        //        Console.WriteLine("Press any button to continue");
        //        break;

        //    case Enums.ServiceStatus.ALREADY_EXISTS:
        //        Console.WriteLine("A contact with the same email already exists");
        //        Console.WriteLine("Press any button to continue");
        //        break;

        //    case Enums.ServiceStatus.FAILED:
        //        Console.WriteLine("An error occured when trying to add the contact, please try again");
        //        Console.WriteLine("Press any button to continue");
        //        break;
        //}

        Console.ReadKey();
    }

    //private void ShowAllProductsMenu()
    //{
    //    bool run = true;

    //    while (run)
    //    {
    //        DisplayTitle("SHOW ALL CONTACTS");

    //        var result = _productService.GetAllContacts();

    //        switch (result.Status)
    //        {
    //            case Enums.ServiceStatus.SUCCESS:
    //                int index = 1;

    //                if (result.Result is List<IContact> contactList)
    //                {
    //                    if (!contactList.Any())
    //                    {
    //                        Console.WriteLine("No contacts has been added, the list is empty");
    //                        Console.WriteLine("Press any button to continue");
    //                        Console.ReadKey();
    //                        run = false;
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine($"View contact details or press (x) to go back to the main menu");
    //                        Console.WriteLine();

    //                        foreach (var contact in contactList)
    //                        {
    //                            Console.WriteLine($"{index}. Name: {contact.FirstName} {contact.LastName}");
    //                            index++;
    //                        }

    //                        var option = Console.ReadLine();

    //                        if (option!.Equals("x", StringComparison.CurrentCultureIgnoreCase))
    //                        {
    //                            run = false;
    //                        }
    //                        else if (int.TryParse(option, out int optionInt) && optionInt <= index - 1 && optionInt >= 1)
    //                        {
    //                            ShowContactInformationMenu(optionInt);
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("Invalid option, press any key then try again");
    //                            Console.ReadKey();
    //                        }
    //                    }
    //                }
    //                break;

    //            case Enums.ServiceStatus.NOT_FOUND:
    //                Console.WriteLine("No contacts has been added, the list is empty");
    //                Console.WriteLine("Press any button to continue");
    //                Console.ReadKey();
    //                run = false;
    //                break;

    //            case Enums.ServiceStatus.FAILED:
    //                Console.WriteLine("An error occured when trying to show the contact list, please try again");
    //                Console.WriteLine("Press any button to continue");
    //                Console.ReadKey();
    //                break;
    //        }
    //    }
    //}

    //private void ShowContactInformationMenu(int option)
    //{
    //    DisplayTitle("CONTACT INFORMATION");

    //    bool run = true;

    //    while (run)
    //    {
    //        var result = _productService.GetContactInformation(option);

    //        switch (result.Status)
    //        {
    //            case Enums.ServiceStatus.SUCCESS:
    //                if (result.Result is IContact contact)
    //                {
    //                    DisplayTitle("CONTACT OPTIONS");

    //                    Console.WriteLine($"Press (r) to remove contact, (u) to update contact information or (x) to go back to the list");
    //                    Console.WriteLine();
    //                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
    //                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
    //                    Console.WriteLine($"Email: {contact.Email}");
    //                    Console.WriteLine($"Address: {contact.Address}");
    //                    Console.WriteLine($"       : {contact.PostalCode} {contact.City}");

    //                    var menuOption = Console.ReadLine();

    //                    switch (menuOption)
    //                    {
    //                        case "r":
    //                            ShowRemoveContactMenu($"{contact.FirstName} {contact.LastName}", contact.Email);

    //                            run = false;
    //                            break;

    //                        case "u":
    //                            ShowUpdateContactMenu($"{contact.FirstName} {contact.LastName}", contact.Email);
    //                            break;

    //                        case "x":
    //                            run = false;
    //                            break;

    //                        default:
    //                            Console.WriteLine("Invalid option, press any key then try again");
    //                            Console.ReadKey();
    //                            break;
    //                    }
    //                }
    //                break;

    //            case Enums.ServiceStatus.FAILED:
    //                Console.WriteLine("An error occured when trying to show contact information.");
    //                Console.WriteLine("Press any button to continue");
    //                Console.ReadKey();
    //                break;
    //        }
    //    }
    //}

    //private void ShowRemoveContactMenu(string name, string email)
    //{
    //    DisplayTitle("REMOVE CONTACT");
    //    Console.WriteLine($"Are you sure you want to remove \"{name}\" from the contact list? Confirm by typing the email ({email})");

    //    var option = Console.ReadLine();

    //    if (option == email)
    //    {
    //        var result = _productService.RemoveContact(email);

    //        switch (result.Status)
    //        {
    //            case Enums.ServiceStatus.SUCCESS:
    //                Console.WriteLine($"\"{name}\" has been removed from the contact list");
    //                Console.WriteLine("Press any key to go back to the list");
    //                Console.ReadKey();
    //                break;

    //            case Enums.ServiceStatus.FAILED:
    //                Console.WriteLine("An error occured when trying to remove the contact, please try again");
    //                Console.WriteLine("Press any key to go back to the list");
    //                Console.ReadKey();
    //                break;

    //            case Enums.ServiceStatus.NOT_FOUND:
    //                Console.WriteLine($"Contact \"{name}\", email: {email}, does not seem to exist");
    //                Console.WriteLine("Press any key to go back to the list");
    //                Console.ReadKey();
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Your input doesn't match the email so the contact has not been deleted");
    //        Console.ReadKey();
    //    }
    //}

    //private void ShowUpdateContactMenu(string name, string email)
    //{
    //    DisplayTitle("UPDATE CONTACT INFORMATION");

    //    Console.Write("First Name: ");
    //    string newFirstName = Console.ReadLine()!;

    //    Console.Write("Last Name: ");
    //    string newLastName = Console.ReadLine()!;

    //    Console.Write("Phone Number: ");
    //    string newPhoneNumber = Console.ReadLine()!;

    //    while (!_productService.NumberValidation(newPhoneNumber!))
    //    {
    //        Console.Write("Please enter a valid phone number: ");
    //        newPhoneNumber = Console.ReadLine()!;
    //    }

    //    Console.Write("Email: ");
    //    string newEmail = Console.ReadLine()!;

    //    Console.Write("Address: ");
    //    string newAddress = Console.ReadLine()!;

    //    Console.Write("Postal Code: ");
    //    string newPostalCode = Console.ReadLine()!;

    //    while (!_productService.NumberValidation(newPostalCode!))
    //    {
    //        Console.Write("Please enter a valid postal code: : ");
    //        newPostalCode = Console.ReadLine()!;
    //    }

    //    Console.Write("City: ");
    //    string newCity = Console.ReadLine()!;

    //    var result = _productService.UpdateContact(email, newFirstName, newLastName, newPhoneNumber, newEmail, newAddress, newPostalCode, newCity);

    //    switch (result.Status)
    //    {
    //        case Enums.ServiceStatus.SUCCESS:
    //            Console.WriteLine("The contact information has been updates successfully");
    //            Console.WriteLine("Press any key to go back to the list");
    //            Console.ReadKey();
    //            break;

    //        case Enums.ServiceStatus.FAILED:
    //            Console.WriteLine("An error occured when trying to update the contact, please try again");
    //            Console.WriteLine("Press any key to go back to the list");
    //            Console.ReadKey();
    //            break;

    //        case Enums.ServiceStatus.NOT_FOUND:
    //            Console.WriteLine($"Contact \"{name}\", email: {email}, does not seem to exist");
    //            Console.WriteLine("Press any key to go back to the list");
    //            Console.ReadKey();
    //            break;
    //    }
    //}

    private void ShowAddBookingMenu()
    {
        DisplayTitle("ADD BOOKING");

        Console.Write("Client First Name: ");
        string firstName = Console.ReadLine()!;

        Console.Write("Client Last Name: ");
        string lastName = Console.ReadLine()!;

        Console.Write("Client Phone Number: ");
        string phoneNumber = Console.ReadLine()!;

        while (!_bookingService.NumberValidation(phoneNumber!) && phoneNumber.Length <= 20)
        {
            Console.Write("Please enter a valid phone number: ");
            phoneNumber = Console.ReadLine()!;
        }

        Console.Write("Client Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Booking Address: ");
        string address = Console.ReadLine()!;

        Console.Write("Booking Postal Code: ");
        string postalCode = Console.ReadLine()!;

        while (!_bookingService.NumberValidation(postalCode!) && postalCode.Length <= 6)
        {
            Console.Write("Please enter a valid postal code: : ");
            postalCode = Console.ReadLine()!;
        }

        Console.Write("Booking City: ");
        string city = Console.ReadLine()!;

        Console.Write("Date (example: 2024-12-31): ");
        string date = Console.ReadLine()!;

        while (date.Length != 10)
        {
            Console.Write("Please enter a valid date: ");
            date = Console.ReadLine()!;
        }

        Console.WriteLine("Choose the requested time:");
        Console.WriteLine("1. 0800 - 1100");
        Console.WriteLine("2. 1200 - 1500");
        Console.WriteLine("3. 1700 - 2100");

        var menuOption1 = Console.ReadLine();
        int timeId = 0;

        while (timeId == 0)
        {
            switch (menuOption1)
            {
                case "1":
                    timeId = 1;
                    break;

                case "2":
                    timeId = 2;
                    break;

                case "3":
                    timeId = 3;
                    break;

                default:
                    Console.WriteLine("Invalid option, try again");
                    menuOption1 = Console.ReadLine()!;
                    break;
            }
        }

        Console.WriteLine("Choose the requested amount of participants:");
        Console.WriteLine("1. 1 - 9");
        Console.WriteLine("2. 10 - 19");
        Console.WriteLine("3. 20+");

        var menuOption2 = Console.ReadLine();
        int participantsId = 0;

        while (participantsId == 0)
        {
            switch (menuOption2)
            {
                case "1":
                    participantsId = 1;
                    break;

                case "2":
                    participantsId = 2;
                    break;

                case "3":
                    participantsId = 3;
                    break;

                default:
                    Console.WriteLine("Invalid option, try again");
                    menuOption2 = Console.ReadLine()!;
                    break;
            }
        }

        //Corresponds to status "booked" in the database
        int statusId = 1;

        BookingForm booking = new(firstName, lastName, phoneNumber, email, address, postalCode, city, date, statusId, participantsId, timeId);
        var result = _bookingService.CreateBooking(booking);


        switch (result)
        {
            case true:
                Console.WriteLine("The booking has been added successfully");
                Console.WriteLine("Press any button to continue");
                break;

            case false:
                Console.WriteLine("An error occured when trying to add the booking");
                Console.WriteLine("Press any button to continue");
                break;
        }

        Console.ReadKey();
    }

    private void ShowAllBookingsMenu()
    {

    }

    private void ShowExitMenu()
    {
        bool run = true;

        while (run)
        {
            DisplayTitle("EXIT APPLICATION");

            Console.WriteLine("Are you sure you want to exit? (y/n)");
            var option = Console.ReadLine();

            switch (option)
            {
                case "y":
                    Environment.Exit(0);
                    break;

                case "n":
                    run = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, press any key then try again");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void DisplayTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"## {title} ##");
        Console.WriteLine();
    }
}
