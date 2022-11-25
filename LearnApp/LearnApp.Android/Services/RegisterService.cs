using Firebase.Auth;
using System.Threading.Tasks;
using Xamarin.Forms;
using LearnApp.Droid.Services;
using LearnApp.Services.Register;

[assembly: Dependency(typeof(RegisterService))]
namespace LearnApp.Droid.Services
{
    class RegisterService : IRegisterService
    {
        public bool IsVerif()
        {
            return FirebaseAuth.Instance.CurrentUser.IsEmailVerified;
        }

        public Task<bool> RegisterAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(username, password)
            .ContinueWith((task) => OnAuthComplited(task, tcs));
            return tcs.Task;
        }

        public void SendEmail()
        {
            FirebaseAuth.Instance.CurrentUser.SendEmailVerification();
        }

        private void OnAuthComplited(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                tcs.SetResult(false);
                return;
            }
            tcs.SetResult(true);
        }
    }
}