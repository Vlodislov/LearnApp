using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Droid.ServiceListeners
{
    public class OnSaveUserCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<string> _tcs;

        public OnSaveUserCompleteListener(TaskCompletionSource<string> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                if (task.Result is DocumentReference doc)
                {
                    _tcs.TrySetResult(doc.Id);
                    return;
                }
            }
            _tcs.TrySetResult(default);
        }
    }
}