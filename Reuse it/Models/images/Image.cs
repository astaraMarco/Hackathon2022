using System.ComponentModel.DataAnnotations;
using System.IO;
namespace Reuse_it.Models.images
{
    
    public class image
    {
        public int? Id { get; set; }
        public string pathFoto { get; set; }
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile PostedFile { get; set; }
        public image() { }
        public image(int? i,string imagePath)
        {
            Id= i;
            this.pathFoto = imagePath;
        }
        public async Task<bool> ConvertIFromFileInPath() {
            pathFoto = Path.Combine($"{Directory.GetCurrentDirectory()}/wwwroot/image/tmp/",PostedFile.FileName);
            using (var stream = new FileStream(pathFoto, FileMode.Create)) { 
                await PostedFile.CopyToAsync(stream);
                return true;
            }

        }
    }
}
/*
 [HttpPost]
    public ActionResult Index(HttpPostedFileBase postedFile)
    {
        string path = Server.MapPath("~/Uploads/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
 
        if (postedFile != null)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            postedFile.SaveAs(path + fileName);
            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
        }
 
        return View();
    }
 */