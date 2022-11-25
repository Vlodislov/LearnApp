using Android.App;
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
using System.Threading.Tasks;

namespace LearnApp.Droid.ServiceListeners
{
    public class OnDocumentCompleteListenerTask<T> : Java.Lang.Object, IOnCompleteListener
         where T : IIdentifiableTask
    {
        private TaskCompletionSource<T> _tcs;

        public OnDocumentCompleteListenerTask(TaskCompletionSource<T> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var docObj = task.Result;
                if (docObj is DocumentSnapshot docRef)
                {
                    _tcs.TrySetResult(docRef.Convert<T>());
                    return;
                }
            }
            // something went wrong
            _tcs.TrySetResult(default);
        }
    }
}