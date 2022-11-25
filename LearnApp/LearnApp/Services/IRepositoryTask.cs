using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services
{
    public interface IIdentifiableTask
    {
        string Id { get; set; }
         string Task1 { get; set; }
         string Task2 { get; set; }
         string Task3 { get; set; }
         string Task4 { get; set; }
         string Task5 { get; set; }
         string Task6 { get; set; }
         string Task7 { get; set; }
         string Task8 { get; set; }
         string Task9 { get; set; }
         string Task10 { get; set; }
        string Task1_comp { get; set; }
        string Task2_comp { get; set; }
        string Task3_comp { get; set; }
        string Task4_comp { get; set; }
        string Task5_comp { get; set; }
        string Task1_answer { get; set; }
        string Task2_answer { get; set; }
        string Task3_answer { get; set; }
        string Task4_answer { get; set; }
        string Task5_answer { get; set; }

    }

    public interface IRepositoryTask<T> where T : IIdentifiableTask
    {
        Task<T> Get(string id);
        Task<IList<T>> GetAll();
        Task<string> Save(T item);
        Task<bool> Delete(T item);
        Task<bool> Update(T item);

    }
}
