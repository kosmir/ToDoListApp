```markdown
# To-Do List Console App Project

This is a simple console application for managing daily to-do lists. The application allows users to add, remove, and edit tasks for a specific day.

## Code Overview

### `Run()` Function

The `Run` function initializes an `EventHandler` and displays the current date. It then enters a loop where the user can interact with the to-do list by adding, removing, or editing tasks.

```csharp
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
```

### `ListHandler` Class

This class provides functionality to handle the to-do list, including adding, removing, and editing tasks.

### `EventHandler` Class

This class extends `ListHandler` and adds event-related functionalities. It manages the current directory, checks for existing to-do lists, and interacts with the user to perform actions on the to-do list.

## Usage

1. **Display Existing Lists:**
   - Enter `0` to display existing to-do lists in the current directory.

2. **Add Task:**
   - Enter `1` to add a task to the to-do list. Follow the prompts to enter the task.

3. **Remove Task:**
   - Enter `2` to remove a task from the to-do list. Follow the prompts to select the task to remove.

4. **Edit Task:**
   - Enter `3` to edit a task in the to-do list. Follow the prompts to select and edit the task.

5. **Exit:**
   - Enter `4` to exit the application.

## File Storage

To-do lists are stored in text files named according to the date (e.g., `List_03112023.txt`).

## Notes

- If no to-do lists exist for the current day, the application prompts the user to create a new one.

- The application continuously runs until the user chooses to exit.

Feel free to explore and enhance the functionality of this simple to-do list console application!
```
