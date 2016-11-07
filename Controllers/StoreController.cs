using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

using StoreModel;
using StoreRepo;

[Route("/api/store")]
public class StoreController : Controller {
    public List<Store> stores;
    public StoreController(IStore singletonS){
        stores = singletonS;
    }
    [HttpGet]
    public IActionResult GetAll(){
        return View(stores);
    }
    [HttpGet("{id})")]
    public IActionResult GetOne(int id){
        var store = stores.get(id);
        if (store == null)
        return NotFound();
        
        return View(store);
    }

    [HttpPost("{id}/edit")]
    public IActionResult Update([FromForm] Store store, int id){
        var s = stores.get(id);
        if(s != null)
        stores.delete(id);

        stores.Id = id;
        stores.create(store);
        return RedirectToAction("GetAll");
    }
    [HttpGet("new")]
    public IActionResult Create(){
        return View();
    }
    [HttpPost("new")]
    public IActionResult HandleCreate([FromForm] Store store, int id){
        stores.create(store);
        return RedirectToAction("GetAll");
    }
}
