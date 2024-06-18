using System.Collections.Generic;
using WebForms.Data;

namespace WebForms.Interfaces
{
    internal interface IFile
    {
        File AddFile(File file);
        bool DeleteFile(int fileId);
        File GetFileById(int fileId);
        IEnumerable<File> GetAllFiles();
    }
}
