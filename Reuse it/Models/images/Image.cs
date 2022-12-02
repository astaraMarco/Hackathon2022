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
            string tmp = Path.Combine($"{Directory.GetCurrentDirectory()}\\wwwroot\\image\\tmp\\",PostedFile.FileName);
            pathFoto = "";
            
            foreach (string s in tmp.Split("\\")) {
                pathFoto = Path.Combine(pathFoto, $"{s}/");
            }
            pathFoto=pathFoto.Remove(pathFoto.Length - 1);
            using (var stream = new FileStream(pathFoto, FileMode.Create)) { 
                await PostedFile.CopyToAsync(stream);
                return true;
            }

        }
        public byte[]? convertToByte() {

            if (this.PostedFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    PostedFile.CopyTo(ms);
                    return ms.ToArray();


                }
            }
            return null;
        }
        public static byte[]? convertToUpload(image im) {

            byte[]? data = im.convertToByte();
            if (data == null)
            {
                return null;
            }
            return data;
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