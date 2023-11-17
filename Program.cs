Run();
void Run()
{
    EventHandler eventNew = new EventHandler();

    Console.WriteLine($"It's {eventNew.dateTime.DayOfWeek}, {eventNew.dateTime.ToString("m")}");

    while (true)
    {
        
        eventNew.DisplayListData();
        
        if (eventNew.GetActionFromUser(eventNew, eventNew.dateForFileName)) break;
        
    }
}
public class ListHandler
{
    public List<string> ListToHandle { get; private set; }
    public ListHandler()
    {
        ListToHandle = new List<string>();
    }
    public void AddTask(string fileNameDate)
    {
        Console.Clear();
        Console.Write("Enter a task you'd like to add to the list: ");
        string input = Console.ReadLine();
        ListToHandle.Add(input);
        File.WriteAllLines($"List_{fileNameDate}.txt", ListToHandle);
        Console.Clear();
    }
    public void RemoveTask()
    {
        Console.Clear();
        foreach (string task in ListToHandle)
        {
            Console.WriteLine($"{ListToHandle.IndexOf(task) + 1} - {task}");
        }
        Console.Write("Enter a number of the task you'd like to delete from the list: ");
        int input = Convert.ToInt32(Console.ReadLine());
        ListToHandle.RemoveAt(input - 1);
        Console.Clear();
    }
    public void EditTask()
    {
        Console.Clear();
        foreach (string task in ListToHandle)
        {
            Console.WriteLine($"{ListToHandle.IndexOf(task) + 1} - {task}");
        }
        Console.Write("Enter a task you'd like to edit in the list: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter new task instead of the old one: ");
        string editedTask = Console.ReadLine();
        ListToHandle[input - 1] = editedTask;
        File.WriteAllLines("List.txt", ListToHandle);
        Console.Clear();
    }
}

public class EventHandler : ListHandler
{
    public string CurrentDirectory { get; }
    public bool ZeroFilesInCurrentDirectory { get; }

    public DateTime dateTime = DateTime.Now;

    public string dateForFileName = DateTime.Now.ToString("ddMMyyyy");

    public EventHandler()
    {
        CurrentDirectory = Directory.GetCurrentDirectory();
        ZeroFilesInCurrentDirectory = Directory.GetFiles(CurrentDirectory, "*.txt").Length == 0;
    }
    private void DisplayEvents()
    {
        Console.Clear();
        if (ZeroFilesInCurrentDirectory)
        {
            Console.WriteLine("You've never created a TO-DO list for a single day! Let's create your first TO-DO list!");
        }
        else
        {
            Console.Clear();
            string[] existingLists = Directory.GetFiles(CurrentDirectory, "*.txt");
            foreach (string list in existingLists)
            {
                Console.WriteLine(Path.GetFileName(list));
            }
            
        }
    }
    public void DisplayListData()
    {
        if (this.ListToHandle.Count > 0)
        {
            Console.WriteLine($"Your list of things for {dateForFileName} looks like this: ");
            for (int i = 0; i < this.ListToHandle.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {this.ListToHandle[i]}");
            }
        }
    }
    public bool GetActionFromUser(EventHandler currentEvent, string fileNameDate)
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("0 - Display existing lists in direcorty");
        Console.WriteLine("1 - Add task");
        Console.WriteLine("2 - Remove task");
        Console.WriteLine("3 - Edit task");
        Console.WriteLine("4 - Nothing, exit the app");

        int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 0:
                DisplayEvents();
                break;
            case 1:
                currentEvent.AddTask(fileNameDate);
                break;
            case 2:
                currentEvent.RemoveTask();
                break;
            case 3:
                currentEvent.EditTask();
                break;
            case 4:
                Console.WriteLine("Exiting application");
                return true;
            default:
                Console.WriteLine("Please enter a valid number");
                break;
        }
        return false;

    }
}

