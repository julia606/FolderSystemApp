using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Folder
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ParentFolderId { get; set; }

        public Folder? ParentFolder { get; set; }

        public ICollection<Folder> Subfolders { get; set; }
    }
}
