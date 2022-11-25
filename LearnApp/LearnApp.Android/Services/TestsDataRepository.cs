using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LearnApp.Droid.Services;
using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestsDataRepository))]
namespace LearnApp.Droid.Services
{
    public class TestsDataRepository : BaseRepositoryTests<DataTests>
    {
        protected override string DocumentPath =>
            "users/" +
            Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/tests";
    }
    
    
}