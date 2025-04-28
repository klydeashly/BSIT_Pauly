using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BSIT_Pauly.Models;
using BSIT_Pauly.BusLogic;
using BSIT_Pauly.BusLogic.Service;
using BSIT_Pauly.BusLogic.Models;

namespace BSIT_Pauly.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StudentService _studentService = new StudentService();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var student = _studentService.GetAll(); 
        return View(student);
    }

    public IActionResult AddNewStudent()
    {
        var student = _studentService.GetAll();
        return View(student);

    }

    [HttpPost]
    public IActionResult InsertStudent(tblStudentt student)
    {
        try
        {
            bool result = _studentService.Insert(student);
            return Json(new { success = result, message = result ? "Student Added Successfully!" : "Failed to Add Student" });
        }
        
        catch (Exception ex)
        {
            return Json(new { success = false, message = "An error occurred!" });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
