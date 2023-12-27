using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface ISettingService
    {
        public Task<List<Setting>> getAllSettingAsync();

        public Task<Setting> getSettingAsync(int id);

        public Task<Setting> AddSettingAsync(SettingDTO model);

        public Task<Setting> UploadLogoAsync(int SettingId, IFormFile file);

        public Task<Stream> DownloadLogoSetting(string SettingName);

        public Task<Setting> UpdateFileAsync(int id, IFormFile file);

        public Task DeleteSettingAsync(int id);
    }
}
