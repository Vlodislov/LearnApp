using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using LearnApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnApp.Droid.Extensions
{
    public static class DocumentReferenceExtensionsTests
    {
        public static T Convert<T>(this DocumentSnapshot doc) where T : IIdentifiableTests
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

        public static List<T> Convert<T>(this QuerySnapshot docs) where T : IIdentifiableTests
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