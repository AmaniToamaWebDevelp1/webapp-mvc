using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_mvc.Models;
using webapp_mvc.Repository;

namespace webapp_mvc.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
     private readonly ApplicationDbContext _db;
      private readonly IRepository<Meida> _repository;
    //make constructure like typescript
    public HomeController(ApplicationDbContext db, IRepository<Meida> repository)
    {
        _db = db;
        _repository = repository;
    }
         //[FromQuery(Name = "SearchString")]
    public async Task<IActionResult> Index( string searchString)
    {
     if (_db.Meidas == null)
    {
        return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
    }
    var media = from m in _db.Meidas
                select m;

    if (!String.IsNullOrEmpty(searchString))
    {
        media = media.Where(w => w.ProductName.Contains(searchString) || w.Price.ToString() == searchString 
                                                || w.ProductDesc.Contains(searchString) || w.Gender == searchString || w.Filename.Contains(searchString));
    }
    // IEnumerable<Meida> objMedia = _db.Meidas;

        return View(await media.ToListAsync());
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
    // [HttpGet]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Search(string word)
    // {
    //     var data = await _repository.GetAllAsync();
    //     var wordSearched = data.FirstOrDefault(w => w.ProductName == word || w.Price.ToString() == word 
    //                                              || w.ProductDesc.Contains(word) || w.Gender == word || w.Filename.Contains(word) ) ;

    //      if(wordSearched != null)
    //      {
    //         return (IActionResult)wordSearched;
    //      }
    //      else{
    //         TempData["error"] = "OOps! no result" + "&#128566" ;
    //      }
    //     return Index();
    // }

    //Get 
    public IActionResult CreateOrder(int id, OrderInfo orderInfo, Meida meida){
        if(id == 0){
            return NotFound();
        }
        var findInDb = _db.Meidas.Find(id);
        if(findInDb == null){
            return NotFound();
        }
        ViewBag.ProductName = meida.ProductName;
        ViewBag.Id = meida.Id;
        ViewBag.Price = meida.Price;

       
        var order = new OrderInfo();
        // var combinedModel = new Tuple<Meida, OrderInfo>(findInDb, orderInfo);


        return View(orderInfo);
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrderr(OrderInfo orderInfo)
    {
             var media = new Meida();
            //  ViewBag.ProductId = media.Id;
                   
                 try{
                    _db.OrderInfos.Add(orderInfo);
                      await _db.SaveChangesAsync();
                      TempData["success"] = "Your order has been sended!";
                      return RedirectToAction("Index");
          
                 }catch(Exception ex){
                     TempData["error"] = "An Unhandled error, try again";
                     return RedirectToAction("Index");

 
                 }
        
                                

      //  return RedirectToAction("Index");
    }

 
}
