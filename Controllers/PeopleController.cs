using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NET_Core_2.Models;

namespace NET_Core_2.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> _logger;

    public PeopleController(ILogger<PeopleController> logger)
    {
        _logger = logger;
    }

    public static List<PersonModel> people = new List<PersonModel>{
            new PersonModel{
                ID = 1,
                FirstName = "Thai",
                LastName = "Do Van",
                Gender = "Male",
                DOB = new DateTime(2001, 2, 15),
                PhoneNumber = "0989479615",
                Address = "Thai Binh",
                IsGraduated = false
            },
            new PersonModel{
                ID = 2,
                FirstName = "Hoc",
                LastName = "Nguyen Thai",
                Gender = "Male",
                DOB = new DateTime(2000, 2, 15),
                PhoneNumber = "0989479615",
                Address = "Ha Nam",
                IsGraduated = false
            },
            new PersonModel{
                ID = 3,
                FirstName = "Thanh",
                LastName = "Do Tien",
                Gender = "Male",
                DOB = new DateTime(1999, 2, 15),
                PhoneNumber = "0989479615",
                Address = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel{
                ID = 4,
                FirstName = "Anh",
                LastName = "Do Ngoc",
                Gender = "Male",
                DOB = new DateTime(1998, 3, 11),
                PhoneNumber = "0989479615",
                Address = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel{
                ID = 5,
                FirstName = "Duy",
                LastName = "Pham Tran",
                Gender = "Male",
                DOB = new DateTime(1998, 3, 11),
                PhoneNumber = "0989479615",
                Address = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel{
                ID = 6,
                FirstName = "Quan",
                LastName = "Pham Dinh",
                Gender = "Male",
                DOB = new DateTime(1996, 3, 11),
                PhoneNumber = "0989479615",
                Address = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel{
                ID = 7,
                FirstName = "Huy",
                LastName = "Nguyen Quang",
                Gender = "Female",
                DOB = new DateTime(1997, 3, 11),
                PhoneNumber = "0989479615",
                Address = "Bac Giang",
                IsGraduated = false
            }
        };

    public IActionResult Index()
    {
        return View(people);
    }

    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public IActionResult Add(PersonModel model){
        if(!ModelState.IsValid) return View();
        people.Add(model);
        return RedirectToAction("Index");  
    }

    public IActionResult Edit(int ID){
        var std = people.Where(s => s.ID == ID).FirstOrDefault();
        return View(std);
    }
    [HttpPost]
    public IActionResult Edit(PersonModel model){
        if(!ModelState.IsValid) return View();
        people[model.ID - 1] = model;
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int ID){
        if(ID <=0 && ID > people.Count)
           return RedirectToAction("Index");
        people.RemoveAt(ID - 1);
        return RedirectToAction("Index");
    }
    

    

    public IActionResult Detail(int ID)
    {
        var std = people.Where(s => s.ID == ID).FirstOrDefault();
        return View(std);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
