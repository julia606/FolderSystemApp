using BusinessLogic.Repositories;
using DataAccess.Entities;

namespace FolderSystem.Models
{
    public class FolderViewModel
    {
        public Folder CurrentFolder { get; set; }

        public List<Folder> Subfolders { get; set; }

        public FolderRepository FolderRepository { get; set; }

    }
}
