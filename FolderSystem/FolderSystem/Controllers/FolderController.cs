﻿using BusinessLogic.Repositories;
using DataAccess.EF;
using DataAccess.Entities;
using FolderSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FolderSystem.Controllers
{
    public class FolderController : Controller
    {
        private readonly FoldersContext _context;
        private readonly FolderRepository _folderRepository;

        public FolderController(FoldersContext context, FolderRepository repository)
        {
            _context = context;
            _folderRepository = repository;
        }
        public async Task<IActionResult> Index(string folderPath)
        {
            var decodedFolderPath = System.Net.WebUtility.UrlDecode(folderPath);

            if (decodedFolderPath == null)
            {
                var rootFolder = await _context.Folders
                    .Include(f => f.Subfolders) 
                    .FirstOrDefaultAsync(f => f.Id == 1);

                return View(new FolderViewModel
                {
                    CurrentFolder = rootFolder,
                    Subfolders = rootFolder.Subfolders.ToList(),
                    FolderRepository = _folderRepository
                    
                });
            }

            var folders = decodedFolderPath.Split("/");
            var neededFolderName = folders[folders.Length - 1];

            var neededFolder = await _context.Folders
                .Include(f => f.Subfolders) 
                .FirstOrDefaultAsync(f => f.Name == neededFolderName);

            if (neededFolder == null)
            {
                return NotFound(); 
            }

            var subFolders = await _context.Folders.Where(f => f.ParentFolderId == neededFolder.Id).ToListAsync();

            return View(new FolderViewModel
            {
                CurrentFolder = neededFolder,
                Subfolders = subFolders,
                FolderRepository = _folderRepository
            });
            
        }


    }
}
