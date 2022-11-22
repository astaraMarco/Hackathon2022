namespace Reuse_it.Models.images
{
    public class image
    {
        public int Id { get; set; }
        public string pathFoto { get; set; }
        public image(int i, string imagePath)
        {
            this.Id = i;
            this.pathFoto = imagePath;
        }

    }
}
