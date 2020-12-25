namespace RentCars.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;

    public interface IImagesService
    {
         Task<List<string>> UploadImage(Cloudinary cloudinary, ICollection<IFormFile> files);
    }
}
