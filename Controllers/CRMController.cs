using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_mvc.Models;
using webapp_mvc.Repository;
namespace webapp_mvc.Controllers;

public class CRMController: Controller
{
    private readonly ApplicationDbContext _db;
     private readonly IRepository<SuperAdmin> _repository;
    //make constructure like typescript
    public CRMController(ApplicationDbContext db,IRepository<SuperAdmin> repository)
    {
        _db = db;
        _repository = repository;
    }
      //Get login page
    public IActionResult Login(){


        return View();
    }
    //Post login page
    [HttpPost,ActionName("Login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Loginn(string username, string pwd){
        var admin = new SuperAdmin();
        var data = await _repository.GetAllAsync();
        var user = data.FirstOrDefault(u => u.username == username && u.pwd== pwd);

        if(user != null){

            TempData["success"] = "Welcome Home";
            return RedirectToAction("Home");
        }
        else{
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            TempData["error"] = "Invalid username or password, please try again";
            return View();
        }

          
      
    }
    //home page

    public IActionResult Home(){
      IEnumerable<Meida> objMedia = _db.Meidas;

        return View(objMedia);
    }




    //GET
    public IActionResult Index(){
      
                     
       
        
         return RedirectToAction("Login");
       
    
    }
  


 

    //GET MEDIA
  
    public async Task<IActionResult> Upload()
    {
      
        return View();
        
    }
    //POST MEDIA
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Upload(IFormFile file)
    // {
    //     if (file != null && file.Length > 0)
    //     {
    //         using (var memoryStream = new MemoryStream())
    //         {
    //             await file.CopyToAsync(memoryStream);

    //             var media = new Meida
    //             {
    //                 Filename = file.FileName,
    //                 FileType = file.ContentType,
    //                 FileData = memoryStream.ToArray()
    //             };

    //             _db.Meidas.Add(media);
    //             await _db.SaveChangesAsync();
                 

               
    //         }
    //     }
    //   return RedirectToAction("Index");     
    // }
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Upload(Meida media)
{
    //   if(ModelState.IsValid)
    // {
      
           if (media.File != null && media.File.Length > 0)
            {
       
        using (var memoryStream = new MemoryStream())
        {
            await media.File.CopyToAsync(memoryStream);

            media.Filename = media.File.FileName;
            media.FileType = media.File.ContentType;
            media.FileData = memoryStream.ToArray();
             try{
            _db.Meidas.Add(media);
            await _db.SaveChangesAsync();
            TempData["success"] = "Your product has been uploaded!";
            return RedirectToAction("Home");
             
              }catch(Exception ex){
            TempData["error"] = "An Unhandled error, try again";
               return RedirectToAction("Home");
        }
  }
           
        }
       
    // }
    // else
    //     {
    //          TempData["error"] = "An Unhandled error, try again";
    //            return RedirectToAction("Index");
    //     }
   return View();
    
}

//Get
public async Task<IActionResult> Update(int id){
    
    if(id == 0){
        return NotFound();
    }
  
    var fileFormDb = _db.Meidas.Find(id);
    if(fileFormDb == null){
        return NotFound();
    }
      ViewBag.FileValue = fileFormDb.Filename;

    return View(fileFormDb);
}


//Post
[HttpPost,ActionName("Update")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Updatee(Meida meida)

{
    
         
         
     if (meida.File != null && meida.File.Length > 0  )
    {
        using (var memoryStream = new MemoryStream())
        {
            await meida.File.CopyToAsync(memoryStream);

            meida.Filename = meida.File.FileName;
            meida.FileType = meida.File.ContentType;
            meida.FileData = memoryStream.ToArray();
           
              _db.Meidas.Update(meida);
              await _db.SaveChangesAsync();
              TempData["success"] = "Your image has been updated!";
              return RedirectToAction("Home");
             
            
      
    }
    }
  
        return View();
    
}
 
   
    // if(ModelState.IsValid)
    // {
    //      try{
                  
    //   _db.Meidas.Update(meida);
    //   await _db.SaveChangesAsync();
    //   TempData["success"] = "Your image has been updated!";

    //        } catch(DbUpdateException ex){
    //              TempData["error"] = "An error occurred while updating the image.";
    //             }


    // }
    
 
    
    // if (meida.File != null && meida.File.Length > 0)
    // {
    //     using (var memoryStream = new MemoryStream())
    //     {
    //         await meida.File.CopyToAsync(memoryStream);

    //         fileFormDb.Filename = meida.File.FileName;
    //         fileFormDb.FileType = meida.File.ContentType;
    //         fileFormDb.FileData = memoryStream.ToArray();

           
    //              _db.Entry(fileFormDb).State = EntityState.Detached; // Detach the fileFormDb entity
    //             _db.Entry(meida).State = EntityState.Modified; // Attach the updated entity
        
    //     }
    // }


//Get
public async Task<IActionResult> Delete(int id ){
    if(id == 0){
        return NotFound();
    }
    var fileFormDb = _db.Meidas.Find(id);
    if(fileFormDb == null){
        return NotFound();
    }
     ViewBag.FileValue = fileFormDb.Filename;
    return View(fileFormDb);
}
[HttpPost,ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Deletee(int id)
{
    var media = await _db.Meidas.FindAsync(id);
    if (media == null)
    {
        return NotFound();
    }

    _db.Meidas.Remove(media);
    await _db.SaveChangesAsync();
    TempData["success"] = "Your image has been deleted!";

    return RedirectToAction("Index");
}


}