using BayviewDataAcess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealBridgeWebAPI.Services
{
    public interface IGalleryService
    {
        Task<List<Image>> GetAllImages();
        Task<Image> GetImageById(int id);
        Task<List<Image>> AddImage(Image image);
        Task UpdateImageDetails(Image updatedImage);
        Task DeleteImageById(int id);
    }
}
