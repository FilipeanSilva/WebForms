using System.Collections.Generic;
using System.Linq;
using WebForms.Data;
using WebForms.Interfaces;
using WebForms.Repository;

namespace WebForms.Services
{
    public class FileServices
    {
        private readonly AppDbContext context;
        private readonly IFile sqlFileRepository;
        public FileServices()
        {
            context = new AppDbContext();
            sqlFileRepository = new SQLFile(context);
            //sqlFileRepository = new SQLFile(context);
        }

        public List<File> GetAllFiles(int userID)
        {
            return sqlFileRepository.GetAllFiles().ToList().FindAll(file => file.UserId == userID);
        }

        public File GetFileById(int fileId)
        {
            return sqlFileRepository.GetFileById(fileId);
        }
    }
}