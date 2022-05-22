using BayviewDataAcess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Threading.Tasks;

namespace RealBridgeWebAPI.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly BayviewDBEntities _bayviewDBEntities;

        public GalleryService(BayviewDBEntities BayviewDBEntities)
        {
            _bayviewDBEntities = BayviewDBEntities;
        }

        public async Task<List<Image>> GetAllImages() =>
            await _bayviewDBEntities.Images.AsNoTracking().ToListAsync().ConfigureAwait(false);

        public async Task<Image> GetImageById(int id) =>
            await _bayviewDBEntities.Images.AsNoTracking().FirstOrDefaultAsync(img => img.Id == id);

        public async Task<List<Image>> AddImage(Image image)
        {
            _bayviewDBEntities.Images.Add(image);
            await _bayviewDBEntities.SaveChangesAsync();

            return await _bayviewDBEntities.Images.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateImageDetails(Image updatedImage)
        {
            var image = await _bayviewDBEntities.Images.FirstOrDefaultAsync(img => img.Id == updatedImage.Id).ConfigureAwait(false);
            if (image.Id != 0)
            {
                image.Title = updatedImage.Title;
                image.Description = updatedImage.Description;
                await _bayviewDBEntities.SaveChangesAsync();
            }
            else
                throw new ObjectNotFoundException();
        }

        public async Task DeleteImageById(int id)
        {
            Image image = await _bayviewDBEntities.Images.FirstOrDefaultAsync(img => img.Id == id).ConfigureAwait(false);
            if (image.Id != 0)
            {
                _bayviewDBEntities.Images.Remove(image);
                await _bayviewDBEntities.SaveChangesAsync();
            }
            else
                throw new ObjectNotFoundException();
        }
    }
}