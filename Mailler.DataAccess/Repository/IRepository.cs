using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> query);

        T Get(Expression<Func<T, bool>> query);
        bool Exists(Expression<Func<T, bool>> query);
        void Add(T data);
        void AddRange(IEnumerable<T> data);

        void Update(T data);

        void Delete(Expression<Func<T, bool>> query);
        
        void FileUpload(string key, string filePath);
        void FileUpload(string key, string fileName, Stream stream);

        bool FileExists(string key);

        Stream FileDownload(string key);

        void FileDelete(string key);

    }
}
