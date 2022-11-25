using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace LearnApp.PageModels.Data
{
    public static class TaskData
    {
        public static async Task<ObservableRangeCollection<Task_>> GetDataAsync()
        {
            var task = new ObservableRangeCollection<Task_>();
            var item = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>().Get("Id");
            task.Add(new Task_
            {
                Chapter = "Глава 2",
                Aswer = "string a = \"Tom\";",
                TextTask = "Объявите строковую переменную \"a\" со значением \"Tom\".",
                Complited = item.Task1_comp,
                TaskNumber = "1",
                AnswerText = item.Task1_answer
            });
            task.Add(new Task_
            {
                Chapter = "Глава 2",
                Aswer = "int[] a = new int[4];",
                TextTask = "Объявите целочисленный массив \"a\" c количеством элементов 4.",
                Complited = item.Task2_comp,
                TaskNumber = "2",
                AnswerText = item.Task2_answer
            });
            task.Add(new Task_
            {
                Chapter = "Глава 2",
                Aswer = "for(int i = 1; i < 6; i++)\n{\nConsole.WriteLine(i);\n}",
                TextTask = "Выведите на экран \n1\n2\n3\n4\n5\n с помощью цикла for.",
                Complited = item.Task3_comp,
                TaskNumber = "3",
                AnswerText = item.Task3_answer
            });
            task.Add(new Task_
            {
                Chapter = "Глава 2",
                Aswer = "int[][] a = new int[444][4];",
                TextTask = "Объявите целочисленный зубчатый массив \"a\" c количеством элементов по горизонтали 444 и 4 по вертикали.",
                Complited = item.Task4_comp,
                TaskNumber = "4",
                AnswerText = item.Task4_answer
            });
            task.Add(new Task_
            {
                Chapter = "Глава 2",
                Aswer = "int[] a = new int[4];\nfor(int i = 0; i < a.Lenght; i++)\n{\nConsole.WriteLine(a[i]);\n}",
                TextTask = "Объявите целочисленный массив \"a\" c количеством элементов 4. Выведите его на экран в формате \n1\n2\n3\n4.",
                Complited = item.Task5_comp,
                TaskNumber = "5",
                AnswerText = item.Task5_answer
            });
            return task;
        }
    }
}
