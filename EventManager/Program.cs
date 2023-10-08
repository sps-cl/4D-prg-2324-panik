using System;
using System.Collections.Generic;

// Abstraktní třída pro účastníka
public abstract class Participant
{
    public string Name { get; set; }
    public bool Invited { get; set; }
    public abstract void DisplayDetails();
}

// Třída pro hosty
public class Guest : Participant
{
    public string GuestType { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Performance Type: {GuestType}");
        if (Invited == true)
        {
            Console.WriteLine($"Is Invited: Yes");
        }
        else
        {
            Console.WriteLine($"Is invited: No");
        }
    }
}

// Třída pro vystupující
public class Performer : Participant
{
    public string PerformanceType { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine("");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Performance Type: {PerformanceType}");
        Console.WriteLine($"Is invited: {Invited}");
    }
}

// Třída pro správu událostí
public class EventManager
{
    private List<Participant> participants = new List<Participant>();

    public void AddParticipant(Participant participant)
    {
        participants.Add(participant);
    }

    public void InviteAllParticipants()
    {
        foreach (var participant in participants)
        {
            participant.Invited = true;
        }
    }

    public void DisplayParticipants()
    {
        Console.WriteLine("Event Participants:");
        Console.WriteLine("");
        foreach (var participant in participants)
        {
            participant.DisplayDetails();
        }
    }
}

// Třída Program pro uživatelské rozhraní
class Program
{
    static void Main(string[] args)
    {
        EventManager eventManager = new EventManager();
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Guest or Performer");
            Console.WriteLine("2. Invite participants");
            Console.WriteLine("3. Display participan¨ts");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");


            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))

            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.Write("Enter 'Guest' or 'Performer': ");
                        string participantType = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();


                        if (participantType == "Guest")
                        {
                            Console.Write("Enter Guest Type: ");
                            string guestType = Console.ReadLine();
                            eventManager.AddParticipant(new Guest { Name = name, GuestType = guestType, Invited = false });
                            Console.WriteLine("");

                        }
                        else if (participantType == "Performer")
                        {
                            Console.Write("Enter Performance Type: ");
                            string performanceType = Console.ReadLine();
                            eventManager.AddParticipant(new Performer { Name = name, PerformanceType = performanceType, Invited = false });
                            Console.WriteLine("");

                        }
                        else
                        {
                            Console.WriteLine("Invalid participant type.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Invite everyone? Type 'Yes' or 'No' ");
                        Console.WriteLine("");
                        string inviteAll = Console.ReadLine();
                        if (inviteAll.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                        {
                            eventManager.InviteAllParticipants();
                            Console.WriteLine("");
                            Console.WriteLine("All participants have been invited.");
                            Console.WriteLine("");
                        }
                        break;
                    case 3:
                        Console.WriteLine("");
                        eventManager.DisplayParticipants();
                        Console.WriteLine("");
                        break;
                    case 4:
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
