using System.Collections.Generic;
using WebForms.Data;
using WebForms.Interfaces;
using WebForms.Services;

namespace WebForms.Repository
{
    public class SQLFile : IFile
    {
        private readonly AppDbContext context;
        public SQLFile(AppDbContext context)
        {
            this.context = context;
        }
        public File AddFile(File file)
        {
            context.Files.Add(file);
            context.SaveChanges();
            return file;
        }

        public bool DeleteFile(int fileId)
        {
            File file = context.Files.Find(fileId);
            if (file != null)
            {
                context.Files.Remove(file);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<File> GetAllFiles()
        {
            return context.Files;
        }

        public File GetFileById(int fileId)
        {
            File file = context.Files.Find(fileId);
            if (file == null)
            {
                return null;
            }
            return file;
        }
    }
}