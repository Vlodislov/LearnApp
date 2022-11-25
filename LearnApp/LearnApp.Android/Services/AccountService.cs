using LearnApp.Services.Account;
using Firebase.Auth;
using System.Threading.Tasks;
using Xamarin.Forms;
using LearnApp.Droid.Services;
using System;
using Xamarin.Essentials;
using Firebase;
using Java.Util.Concurrent;
using LearnApp.Models;
using Firebase.Firestore;
using LearnApp.Droid.ServiceListeners;

[assembly: Dependency(typeof(AccountService))]
namespace LearnApp.Droid.Services
{
    class AccountService : PhoneAuthProvider.OnVerificationStateChangedCallbacks, IAccountService
    {
        const int OTP_TIMEOUT = 30;
        private TaskCompletionSource<bool> _phoneAuthTcs;
        private string _verificationId;

        public async Task<bool> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password).ContinueWith((task) => OnAuthComplited(task, tcs));

            }
            catch (Java.Lang.IllegalArgumentException e)
            {

            }
            return await tcs.Task;
        }
        public void LogOut()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            if (!(user is null))
                FirebaseAuth.Instance.SignOut();
            else 
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ошибка", "Пользователь не найден", "Oк");
        }
        public bool GetU()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            if (!(user is null))
                return true;
            else
                return false;
        }

        private void OnAuthComplited(Task task, TaskCompletionSource<bool> tcs)
        {
            if(task.IsCanceled || task.IsFaulted)
            {
                tcs.SetResult(false);
                return;
            }
            _verificationId = null;
            tcs.SetResult(true);
        }

        public bool GetCurrendUser()
        {
            throw new NotImplementedException();
        }

        public void SendEmailVerify()
        {
            FirebaseAuth.Instance.CurrentUser.SendEmailVerification();
        }

        public bool IsVerify()
        {
            return FirebaseAuth.Instance.CurrentUser.IsEmailVerified;
        }

        public bool SendResetPass(string email)
        {
            try
            {
                FirebaseAuth.Instance.SendPasswordResetEmail(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetNameAccount()
        {
            var email = FirebaseAuth.Instance.CurrentUser.Email;
            return email;
        }

        [Obsolete]
        public async Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            _phoneAuthTcs = new TaskCompletionSource<bool>();
            PhoneAuthProvider.Instance.VerifyPhoneNumber(phoneNumber,
                OTP_TIMEOUT,
                TimeUnit.Seconds,
                Platform.CurrentActivity,
                this);
            return await _phoneAuthTcs.Task;
        }

        public override void OnVerificationCompleted(PhoneAuthCredential credential)
        {
            System.Diagnostics.Debug.WriteLine("Created Automatically");
        }

        public override void OnVerificationFailed(FirebaseException exception)
        {
            System.Diagnostics.Debug.WriteLine("Failed: "  + exception.Message);
            _phoneAuthTcs.TrySetResult(false);
        }
        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResendingToken)
        {
            base.OnCodeSent(verificationId, forceResendingToken);
            _verificationId = verificationId;
            _phoneAuthTcs.TrySetResult(true);
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            if (!string.IsNullOrWhiteSpace(_verificationId))
            {
                var credential = PhoneAuthProvider.GetCredential(_verificationId, code);
                var tcs = new TaskCompletionSource<bool>();
                FirebaseAuth.Instance.SignInWithCredentialAsync(credential)
                    .ContinueWith((task) => OnAuthComplited(task, tcs));
                return tcs.Task;
            }
            return Task.FromResult(false);
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<AuthenticatedUser>();

            FirebaseFirestore.Instance
                .Collection("users")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnCompleteListener(tcs));

            return tcs.Task;
        }

        public string GetEmailAccount()
        {
            return FirebaseAuth.Instance.CurrentUser.Email;
        }

        public void SendChangeEmail(string email)
        {
            
        }
    }
}