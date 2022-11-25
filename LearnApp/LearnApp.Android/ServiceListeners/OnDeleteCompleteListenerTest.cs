using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Droid.ServiceListeners
{
    public class OnDeleteCompleteListenerTest : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<bool> _tcs;

        public OnDeleteCompleteListenerTest(TaskCompletionSource<bool> tcs)
        {
            _tcs = tcs;
        }
        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            _tcs.TrySetResult(task.IsSuccessful);
        }
    }
}