using System;
using System.Collections.Generic;

public static class ToDoListExtensions
{
   
    public static void AddTask(this List<string> tasks, string task)
    {
        try
        {
            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding task: {ex.Message}");
        }
    }

    public static void UpdateTask(this List<string> tasks, int index, string newTask)
    {
        try
        {
            if (index < 0 || index >= tasks.Count)
            {
                throw new IndexOutOfRangeException("The index is outside the task list.");
            }
            tasks[index] = newTask;
            Console.WriteLine("Task updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when changing the task: {ex.Message}");
        }
    }


    public static void RemoveTask(this List<string> tasks, int index)
    {
        try
        {
            if (index < 0 || index >= tasks.Count)
            {
                throw new IndexOutOfRangeException("The index is outside the task list.");
            }
            tasks.RemoveAt(index);
            Console.WriteLine("Task deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting task: {ex.Message}");
        }
    }

    
    public static void DisplayTasks(this List<string> tasks)
    {
        try
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("The task list is empty.");
            }
            else
            {
                Console.WriteLine("List of tasks:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i}. {tasks[i]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\r\nError displaying tasks: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        List<string> toDoList = new List<string>();

        while (true)
        {
            Console.WriteLine("Choose an action: (1) Add task, (2) Change task, (3) Delete task, (4) Show all tasks, (5) Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter a new task:");
                    string newTask = Console.ReadLine();
                    toDoList.AddTask(newTask);
                    break;

                case "2":
                    Console.WriteLine("Enter the index of the task you want to change:");
                    if (int.TryParse(Console.ReadLine(), out int updateIndex))
                    {
                        Console.WriteLine("Enter a new task text:");
                        string updatedTask = Console.ReadLine();
                        toDoList.UpdateTask(updateIndex, updatedTask);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Enter the index of the task you want to delete:");
                    if (int.TryParse(Console.ReadLine(), out int removeIndex))
                    {
                        toDoList.RemoveTask(removeIndex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;

                case "4":
                    toDoList.DisplayTasks();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Incorrect choice. Try again.");
                    break;
            }
        }
    }
}
