using DataAccess.EF;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class FolderRepository
    {
        private readonly FoldersContext _context;

        public FolderRepository()
        {
            _context = new FoldersContext();
        }

        public async Task<string> GetFolderPathAsync(Folder folder)
        {
            if (folder == null)
            {
                return string.Empty;
            }

            var pathBuilder = new StringBuilder();
            await BuildFolderPathRecursiveAsync(folder, pathBuilder);
            return pathBuilder.ToString();
        }

        private async Task BuildFolderPathRecursiveAsync(Folder folder, StringBuilder pathBuilder)
        {
            if (folder.ParentFolder != null)
            {
                await BuildFolderPathRecursiveAsync(folder.ParentFolder, pathBuilder);
                pathBuilder.Append("/");
            }

            pathBuilder.Append(folder.Name);
        }
    }
}
