namespace RentCars.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class ImagesService : IImagesService
    {
        public async Task<List<string>> UploadImage(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            List<string> list = new List<string>();
            foreach (var file in files)
            {
                byte[] destinationImage;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream),
                    };

                    var uploadResult = await cloudinary.UploadAsync(uploadParams);
                    list.Add(uploadResult.Uri.AbsoluteUri);
                }
            }

            return list;
        }
    }
}
