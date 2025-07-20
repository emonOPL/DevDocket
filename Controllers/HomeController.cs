using System.Diagnostics;
using DevDocket.Getway;
using DevDocket.Models;
using Microsoft.AspNetCore.Mvc;


namespace DevDocket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        TaskGetway taskGetway = new TaskGetway();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTask() {
            var tasks = taskGetway.GetTask();
            return Json(tasks);
        }

        [HttpGet]
        public JsonResult GetSingleTask(int taskId)
        {
            var tasks = taskGetway.GetTask(taskId);
            return Json(tasks);
        }

        [HttpPost]
        public void UpdateTask(int id, string title, string details, string techTag, int priority, DateTime deadline, int status) { 
            Models.Task aTask = new Models.Task();
            aTask.Id = id;
            aTask.Title = title;
            aTask.Details = details;
            aTask.TechTag = techTag;
            aTask.Priority = priority;
            aTask.Deadline = deadline;
            aTask.Status = status;

            int rowCount = taskGetway.UpdateTask(aTask);
        }

        [HttpPost]
        public void AddTask(string title, string details, string techTag, int priority, DateTime deadline, int status)
        {
            Models.Task aTask = new Models.Task();
            aTask.Title = title;
            aTask.Details = details;
            aTask.TechTag = techTag;
            aTask.Priority = priority;
            aTask.Deadline = deadline;
            aTask.Status = status;

            int rowCount = taskGetway.AddTask(aTask);
        }

        [HttpPost]
        public JsonResult DeleteTask(int taskId)
        {
            int rowCount = taskGetway.DeleteTask(taskId);
            if (rowCount > 0)
            {
                return Json(new { success = true, message = "Task deleted successfully." });
            }
            return Json(new { success = false, message = "Failed to delete task." });
        }

        //[HttpPost]
        //public void UpdateTask(int taskId, Models.Task task) { 

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
