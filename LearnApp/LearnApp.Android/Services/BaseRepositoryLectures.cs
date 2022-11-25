using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Util;
using LearnApp.Droid.Extensions;
using LearnApp.Droid.ServiceListeners;
using LearnApp.Models;
using LearnApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Droid.Services
{
    public abstract class BaseRepositoryLectures<T> : IRepositoryLectures<T> where T : IIdentifiableLectureLecture
    {
        protected abstract string DocumentPath { get; }
        public Task<bool> Delete(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(item.Id)
                .Delete()
                .AddOnCompleteListener(new OnDeleteCompleteListener(tcs));

            return tcs.Task;
        }

     

        public Task<IList<T>> GetAll()
        {
            var tcs = new TaskCompletionSource<IList<T>>();
            var list = new List<T>();

            FirebaseFirestore.Instance
             .Collection(DocumentPath)
             .Get()
             .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;    
        }

        public Task<string> Save(T item)
        {
            var tcs = new TaskCompletionSource<string>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document("Id")
                //.Update(item.Convert())
                .Set(new HashMap(item.Convert()))
                .AddOnCompleteListener(new OnCreateCompleteListener(tcs));

            return tcs.Task;
        }

        public Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));
            return tcs.Task;
        }

        public Task<bool> Update(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document("Id")
                .Update(item.Convert())
                .AddOnCompleteListener(new OnUpdateCompleteListener(tcs));

            return tcs.Task;
        }
    }
}