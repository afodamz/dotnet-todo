using Microsoft.AspNetCore.Mvc;
using todo.Data;
using todo.Models;

namespace todo.Controllers;
public class TodoController : Controller
{
    private readonly ApplicationDbContext _context;

    public TodoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Todo> todos = _context.Todos.ToList();
        // for (int i = 0; i < todos.Count; i++)
        // {
        //     var todo = todos[i];
        //     Console.WriteLine($"Id: {todo.Id}");
        //     Console.WriteLine($"Title: {todo.Title}");
        //     Console.WriteLine($"Description: {todo.Description}");
        //     Console.WriteLine();
        // }
        Console.WriteLine($" data output {string.Join(", ", todos)}");
        return View(todos);
    }

    public IActionResult Details(int? id)
    {
        if (id == null || _context.Todos == null)
        {
            return NotFound();
        }

        var todo = _context.Todos.FirstOrDefault(t => t.Id == id && !t.IsDeleted);
        if (todo == null)
        {
            return View("NotFound");
        }

        return View(todo);
    }

    public IActionResult Create()
    {
        return View();
    }

    // POST: /Todo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id, Title, Description")] Todo todo)
    {
        // Implement code to create a new task.
        if (ModelState.IsValid)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }

    // GET: /Todo/Edit/5
    public IActionResult Edit(int id)
    {
        if (id == null || _context.Todos == null)
        {
            return NotFound();
        }
        Todo existingTodo = _context.Todos.FirstOrDefault(t => t.Id == id);
        return View(existingTodo);
    }

    // POST: /Todo/Edit/5
    // [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Todo todo)
    {
        if (id != todo.Id)
        {
            return NotFound();
        }
        // Retrieve the existing Todo by its Id
        Todo existingTodo = _context.Todos.FirstOrDefault(t => t.Id == id);

        if (existingTodo == null)
        {
            return NotFound(); // Handle the case where the Todo with the given Id is not found
        }
        try
        {
            if (ModelState.IsValid)
            {
                // Update the properties of the existing Todo with the new values
                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                existingTodo.IsCompleted = todo.IsCompleted;

                // Save the changes to the database
                _context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the list of Todos or another appropriate action
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while updating the record.");
        }
        return View(existingTodo);
    }

    // GET: /Todo/Delete/5
    // public IActionResult Delete(int id)
    // {
    //     // Implement code to fetch the task for deletion.
    //     return View();
    // }

    // POST: /Todo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Todo existingTodo = _context.Todos.FirstOrDefault(t => t.Id == id && !t.IsDeleted);

        if (existingTodo == null)
        {
            return NotFound(); // Handle the case where the Todo with the given Id is not found
        }
        // Implement code to delete the task.
        _context.Todos.Remove(existingTodo);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    private bool JokeExists(int id)
        {
          return (_context.Todos?.Any(t => t.Id == id && !t.IsDeleted)).GetValueOrDefault();
        }
}

