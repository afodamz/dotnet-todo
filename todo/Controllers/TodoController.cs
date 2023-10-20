using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers;
public class TodoController : Controller
{
    public IActionResult Index(){
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    // POST: /Todo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Todo todo)
    {
        // Implement code to create a new task.
        return RedirectToAction("Index");
    }

    // GET: /Todo/Edit/5
    public IActionResult Edit(int id)
    {
        // Implement code to fetch the task for editing.
        return View();
    }

    // POST: /Todo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Todo todo)
    {
        // Implement code to update the task.
        return RedirectToAction("Index");
    }

    // GET: /Todo/Delete/5
    public IActionResult Delete(int id)
    {
        // Implement code to fetch the task for deletion.
        return View();
    }

    // POST: /Todo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        // Implement code to delete the task.
        return RedirectToAction("Index");
    }
}

