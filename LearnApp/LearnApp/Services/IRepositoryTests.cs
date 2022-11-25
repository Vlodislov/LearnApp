using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services
{
    public interface IIdentifiableTests
    {
         string Id { get; set; }
         string Test1 { get; set; }
         string Test2 { get; set; }
         string Test3 { get; set; }
         string Test4 { get; set; }
         string Test5 { get; set; }
         string Test6 { get; set; }
         string Test7 { get; set; }
         string Test8 { get; set; }
         string Test9 { get; set; }
         string Test10 { get; set; }
        string Task1_comp { get; set; }
        string Task2_comp { get; set; }
        string Task3_comp { get; set; }
        string Task4_comp { get; set; }
        string Task5_comp { get; set; }

    }
    public interface IRepositoryTests<T> where T : IIdentifiableTests
    {
        Task<T> Get(string id);
        Task<IList<T>> GetAll();
        Task<string> Save(T item);
        Task<bool> Delete(T item);
        Task<bool> Update(T item);

    }
}
