using Microsoft.AspNetCore.Http;

namespace Authentication.Repository.Abstract
{
    public interface IImageRepository
    {
        public void SaveImage(IFormFile file, string fileName);
    }
}
