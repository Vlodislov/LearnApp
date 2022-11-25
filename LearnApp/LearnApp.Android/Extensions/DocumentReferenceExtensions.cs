using Firebase.Firestore;
using LearnApp.Services;
using System;
using System.Collections.Generic;

namespace LearnApp.Droid.Extensions
{
    public static class DocumentReferenceExtensions
    {
        public static T Convert<T>(this DocumentSnapshot doc) where T : IIdentifiableLectureLecture
        {
            try
            {
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(doc.Data.ToDictionary());
                var item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                item.Id = doc.Id;
                return item;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("EXCEPTION THROWN");
            }
            return default;
        }

        public static List<T> Convert<T>(this QuerySnapshot docs) where T : IIdentifiableLectureLecture
        {
            var list = new List<T>();

            foreach (var doc in docs.Documents)
            {
                list.Add(doc.Convert<T>());
            }

            return list;
        } 
    }
}