using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizTrueFalsePage : ContentPage
    {
        Lecture gameManager;
        private Timer _timer;
        int contV = 0;
        public QuizTrueFalsePage(Lecture lecture)
        {
            InitializeComponent();
            gameManager = lecture;
            gameManager.currentindexquestion = 0;
            gameManager.currentQuestion = gameManager.QuestionTrueFalse[0];
            gameManager.CorrectCount = 0;
            gameManager.WrongCount = 0;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Enabled = false;
            count.Text = $"{contV}/5";
            // correctLabel.Text = "Correct = " + gameManager.CorrectCount;
            // wrongLabel.Text = "Wrong = " + gameManager.WrongCount;
            updateView();
        }


        private async void But_Clicked(object sender, EventArgs e)
        {
            Boolean answer = false;
            Button btn = (Button)sender;
            correctLabel.Text = "";
            correctText.Text = "";
            correctLabel.IsVisible = false;
            correctText.IsVisible = false;
            switch (btn.StyleId)
            {
                case "1":
                    answer = gameManager.checkAnswer(But1.Text);
                    if (answer)
                    {
                        correctLabel.IsVisible = true;
                        correctLabel.Text = $"{gameManager.getCurrentQuestion().answer}";
                        But3.IsVisible = true;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        correctLabel.TextColor = Color.LightGreen;
                    }
                    else
                    {
                        correctLabel.IsVisible = true;
                        correctText.IsVisible = true;
                        correctLabel.Text = $"Правильный ответ: {gameManager.getCurrentQuestion().answer}";
                        correctText.Text = gameManager.getCurrentQuestion().textAnswer;
                        But3.IsVisible = true;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        correctLabel.TextColor = Color.Red;
                    }
                    if (gameManager.currentindexquestion == gameManager.QuestionTrueFalse.Count - 1 && answer)
                    {
                        correctLabel.IsVisible = true;

                        correctLabel.Text = $"{gameManager.getCurrentQuestion().answer}";
                        correctText.Text = gameManager.getCurrentQuestion().textAnswer;
                        But3.IsVisible = false;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        But4.IsVisible = true;
                        correctLabel.TextColor = Color.LightGreen;


                    }
                    else if (gameManager.currentindexquestion == gameManager.QuestionTrueFalse.Count - 1 && answer == false)
                    {

                        correctLabel.IsVisible = true;
                        correctText.IsVisible = true;
                        correctLabel.Text = $"Правильный ответ: {gameManager.getCurrentQuestion().answer}";
                        correctText.Text = gameManager.getCurrentQuestion().textAnswer;
                        But3.IsVisible = false;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        But4.IsVisible = true;
                        correctLabel.TextColor = Color.Red;

                    }
                    break;
                case "2":
                    answer = gameManager.checkAnswer(But2.Text);
                    if (answer)
                    {
                        correctLabel.IsVisible = true;

                        correctLabel.Text = $"{gameManager.getCurrentQuestion().answer}";
                        But3.IsVisible = true;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        correctLabel.TextColor = Color.LightGreen;
                    }
                    else
                    {
                        correctLabel.IsVisible = true;
                        correctText.IsVisible = true;

                        correctLabel.Text = $"Правильный ответ: {gameManager.getCurrentQuestion().answer}";
                        correctText.Text = gameManager.getCurrentQuestion().textAnswer;
                        But3.IsVisible = true;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        correctLabel.TextColor = Color.Red;

                    }
                    if (gameManager.currentindexquestion == gameManager.QuestionTrueFalse.Count - 1 && answer)
                    {
                        correctLabel.IsVisible = true;

                        correctLabel.Text = $"{gameManager.getCurrentQuestion().answer}";
                        correctText.Text = gameManager.getCurrentQuestion().textAnswer;
                        But3.IsVisible = false;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        But4.IsVisible = true;
                        correctLabel.TextColor = Color.LightGreen;

                    }
                    else if (gameManager.currentindexquestion == gameManager.QuestionTrueFalse.Count - 1 && answer == false)
                    {
                        correctLabel.IsVisible = true;
                        correctText.IsVisible = true;
                        correctLabel.Text = $"Правильный ответ: {gameManager.getCurrentQuestion().answer}";
                        correctText.Text = gameManager.getCurrentQuestion().textAnswer;
                        But3.IsVisible = false;
                        But2.IsEnabled = false;
                        But1.IsEnabled = false;
                        But4.IsVisible = true;
                        correctLabel.TextColor = Color.Red;
                    }
                    break;
                case "3":
                    gameManager.generateQuestion();
                    updateView();
                    correctLabel.IsVisible = true;
                    correctText.IsVisible = true;

                    But3.IsVisible = false;
                    But2.IsEnabled = true;
                    But1.IsEnabled = true;
                    break;
                case "4":
                    switch (gameManager.TestNumber)
                    {
                        case "1":
                            var item1 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture1_test = gameManager.CorrectCount.ToString(),
                                    Lecture1_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "2":
                            var item2 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture2_test = gameManager.CorrectCount.ToString(),
                                    Lecture2_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "3":
                            var item3 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture3_test = gameManager.CorrectCount.ToString(),
                                    Lecture3_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "4":
                            var item4 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture4_test = gameManager.CorrectCount.ToString(),
                                    Lecture4_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "5":
                            var item5 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture5_test = gameManager.CorrectCount.ToString(),
                                    Lecture5_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "6":
                            var item6 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture6_test = gameManager.CorrectCount.ToString(),
                                    Lecture6_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "7":
                            var item7 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture7_test = gameManager.CorrectCount.ToString(),
                                    Lecture7_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "8":
                            var item8 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture8_test = gameManager.CorrectCount.ToString(),
                                    Lecture8_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "9":
                            var item9 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture9_test = gameManager.CorrectCount.ToString(),
                                    Lecture9_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;
                        case "10":
                            var item10 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>()
                                .Update(new DataLectures
                                {
                                    Lecture10_test = gameManager.CorrectCount.ToString(),
                                    Lecture10_comp = gameManager.CorrectCount == 5 ? "green" : "red"
                                });
                            break;

                    }
                    questionText.Text = $"Вы ответили правильно на {gameManager.CorrectCount} из 5";
                    AnswerBut.IsVisible = false;
                    AnswerField.IsVisible = false;
                    image.IsVisible = true;
                    But3.IsVisible = false;
                    But4.IsVisible = false;
                    But5.IsVisible = true;
                    count.IsVisible = false;
                    break;
                case "5":
                       await App.Current.MainPage.Navigation.PopAsync();
                        break;


            }

        }

        private void updateView()
        {

            // But1.Text = gameManager.getCurrentQuestion().getAnswerArray()[0].ToString();
            // But2.Text = gameManager.getCurrentQuestion().getAnswerArray()[1].ToString();
            contV += 1;
            count.Text = $"{contV}/5";
            questionText.Text = gameManager.getCurrentQuestion().getQuestionPhrase();

            // correctLabel.Text = "Correct = " + gameManager.CorrectCount;
            // wrongLabel.Text = "Wrong = " + gameManager.WrongCount;


        }
    }
    
}