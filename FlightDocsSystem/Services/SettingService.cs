using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using FlightDocsSystem.Services;
using OpenQA.Selenium;



namespace FlightDocsSystem.Services
{
    public class SettingService : ISettingService
    {
        private readonly FlightDocsSystemContext _context;

        public SettingService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Setting>> getAllSettingAsync()
        {
            var Settings = await _context.Settings.ToListAsync();
            return Settings;
        }

        public async Task<Setting> getSettingAsync(int id)
        {
            var setting = await _context.Settings.FindAsync(id);
            if (_context.Settings == null || setting == null)
            {
                throw new NotFoundException("SettingID does not exist");
            }
            return setting;
        }

        public async Task<Setting> AddSettingAsync(SettingDTO SettingDTO)
        {
            if (SettingDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }

            var Setting = new Setting
            {
                UserID = SettingDTO.UserID
            };
            _context.Settings.Add(Setting);
            await _context.SaveChangesAsync();

            return Setting;
        }

        public async Task<Setting> UploadLogoAsync(int SettingId, IFormFile file)
        {
            var existingSetting = await _context.Settings.FirstOrDefaultAsync(d => d.SettingID == SettingId);
            if (existingSetting == null)
            {
                throw new NotFoundException("ID does not exist or file does not null");
            }
            else
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png","webp" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    throw new InvalidOperationException("Invalid file format. Only JPG or PNG or WEBP is allowed.");
                }

                existingSetting.Logo = await SaveFile(file);
                existingSetting.LogoName = Path.GetFileName(file.FileName);
                await _context.SaveChangesAsync();
            }

            return existingSetting;
        }


        public async Task<Stream> DownloadLogoSetting(string LogoName)
        {
            var Setting = await _context.Settings.FirstOrDefaultAsync(d => d.LogoName == LogoName);

            if (Setting == null || string.IsNullOrEmpty(Setting.Logo))
            {
                throw new NotFoundException("File not found.");
            }

            var filePath = Path.Combine("D:\\Alta SoftWare\\FlightDocsSytem_code\\FlightDocsSystem\\Uploads", Setting.Logo);

            if (!File.Exists(filePath))
            {
                throw new NotFoundException("File not found on the server.");
            }

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return stream;
        }


        public async Task<Setting> UpdateFileAsync(int id, IFormFile file)
        {
            var existingSetting = await _context.Settings.FirstOrDefaultAsync(d => d.SettingID == id);
            if (existingSetting == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingSetting.Logo = await SaveFile(file);
                existingSetting.LogoName = Path.GetFileName(file.FileName);
                await _context.SaveChangesAsync();
            }
            return existingSetting;
        }


        public async Task DeleteSettingAsync(int id)
        {
            var existingSetting = _context.Settings!.SingleOrDefault(b => b.SettingID == id);
            if (existingSetting != null)
            {
                _context.Settings.Remove(existingSetting);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
            
        private async Task<string> SaveFile(IFormFile file)
        {
            var filePath = Path.Combine("D:\\Alta SoftWare\\FlightDocsSytem_code\\FlightDocsSystem\\Uploads", file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }


    }
}
