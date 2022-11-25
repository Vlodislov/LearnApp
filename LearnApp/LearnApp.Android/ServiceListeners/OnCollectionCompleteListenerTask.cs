﻿using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using LearnApp.Droid.Extensions;
using LearnApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnApp.Droid.ServiceListeners
{
    public class OnCollectionCompleteListenerTask<T> : Java.Lang.Object, IOnCompleteListener
       where T : IIdentifiableTask
    {

        private System.Threading.Tasks.TaskCompletionSource<IList<T>> _tcs;

        public OnCollectionCompleteListenerTask(System.Threading.Tasks.TaskCompletionSource<IList<T>> tcs)
        {
            _tcs = tcs;
        }
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                var docsObj = task.Result;
                if (docsObj is QuerySnapshot docs)
                {
                    _tcs.TrySetResult(docs.Convert<T>());
                }
            }
        }
    }
}