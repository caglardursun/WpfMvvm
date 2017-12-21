using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.DataAccess.LiteDB.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region Private Variables
        private LiteDatabase db;
        private LiteCollection<T> table;
        private LiteStorage files;
        #endregion
        #region Construct
        public GenericRepository(string dbPath)
        {
            var cstr = new ConnectionString()
            {
                Filename = dbPath,
                CacheSize = 1048576,/// 1mb
                LimitSize = 524288000
            };

            db = new LiteDatabase(cstr);


            var tbName = typeof(T).Name;
            table = db.GetCollection<T>(tbName);

            files = db.FileStorage;
        }
        #endregion
        #region Table Methods
        public IEnumerable<T> GetAll()
        {
            return table.FindAll();            
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> query)
        {
            return table.Find(query);
        }
        public T Get(Expression<Func<T, bool>> query)
        {
            return table.FindOne(query);
        }
        public bool Exists(Expression<Func<T, bool>> query)
        {
            return table.Exists(query);
        }
        public void Add(T data)
        {            
            table.Insert(data);                        
        }
        public void AddRange(IEnumerable<T> data)
        {
            table.Insert(data);           
        }

        public void Update(T data)
        {            
            table.Update(data);            
        }

        public void Delete(Expression<Func<T, bool>> query)
        {            
            table.Delete(query);            
        }

        #endregion
        #region File Methods

        public bool FileExists(string key)
        {
            return files.Exists(key);
        }

        public void FileUpload(string key, string filePath)
        {          
            files.Upload(key, filePath); 
        }

        public void FileUpload(string key, string fileName, Stream stream)
        {
            
            files.Upload(key, fileName, stream);
                
        }

        public Stream FileDownload(string key)
        {
            Stream result = null;
            files.Download(key, result);
            return result;
        }

        public void FileDelete(string key)
        {

            files.Delete(key);            
        }

        #endregion
    }
}
