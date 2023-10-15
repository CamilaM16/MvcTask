using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    //
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Extra(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }


    //
    // GET: /HelloWorld/Welcome/
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }

    // GET: /HelloWorld/Welcome/
    // Requires using System.Text.Encodings.Web;
    public string Welcome2(string name, int age = 1, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"ID:{ID} Hello {name}, NumTimes is: {age}");
    }
}
