using Mailler.DataAccess.LiteDB.Repository;

using Mailler.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.DataAccess.LiteDB
{
    public class DataProvider
    {
        private GenericRepository<Contact> repo;
        private string RootPath;
        private static DataProvider _instance;

        private static object obj = new object();

        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        _instance = new DataProvider();
                    }
                }
                return _instance;
            }
        }
        
        public DataProvider()
        {
            RootPath = Environment.CurrentDirectory;
            RootPath = System.IO.Path.Combine(RootPath, "MaillerSettings.ldb");
            repo = new GenericRepository<Contact>(RootPath);


            #region Bulk Data Insert
            if (repo.GetAll().Count() == 0)
            {
                foreach (var item in Enumerable.Range(1, 10))
                {
                    repo.Add(new Contact()
                    {
                        Id = item,
                        EMail = string.Format("test{0}@testmail.com", item),
                        Name = string.Format("Name {0}", item),
                        Surname = string.Format("Surname {0}", item)
                    });
                }
            }
            #endregion
        }

        public IEnumerable<Contact> GetAll()
        {
            return repo.GetAll();
        }


        public IEnumerable<Contact> GetContactsById(int id)
        {
            return repo.GetAll(h => h.Id == id);
        }
        public void Add(Contact contact)
        {
            if (repo.GetAll(c => c.Id == contact.Id).Count() == 0)
            {
                repo.Add(contact);
            }
            else
            {
                throw new Exception("Doublicated Records Founded");
            }
        }

        public void Save(Contact contact)
        {
            repo.Update(contact);            
        }

    }
}
