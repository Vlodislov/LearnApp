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
    public static class TetsData
    {
        public static async Task<ObservableRangeCollection<Test>> GetDataAsync()
        {
            var Test = new ObservableRangeCollection<Test>();
            var item = await PageModelLocator.Resolve<IRepositoryTests<DataTests>>().Get("Id");
            Test.Add(new Test
            {
                Chapter = "Глава 2",
                Title = "Tест 1",
                Complited = item.Task1_comp,
                Preload = "Тест на проверку знаний по главе 2",
                TestNumber = "1",
                CorrectCount = Convert.ToInt32(item.Test1),
                Questions = {
                new Question { text = "Где правильно объявлена переменная?", answer = "string name;", textAnswer="тип имя_переменной;",answerArray=new string[4] { "str name;", "string name;", "string name:", "let name;" }  },
                new Question { text = "Что выведет код string name = \"Tom\";\nConsole.WriteLine(name);", answer = "Tom", textAnswer="Будет выведена объявленная переменная.", answerArray=new string[4] { "TOd", "mot", "tim", "Tom" } },
                new Question { text = "Какое служебное слово указывается при объявлении константы?", answer = "const", textAnswer="Слово const указывает, что переменная ясляется не изменяемой.", answerArray=new string[4] { "constant", "consts", "const", "st" }  },
                new Question { text = "Какой тип данных хранит значение true, flase?", answer = "bool", textAnswer="bool: хранит значение true или false (логические литералы).", answerArray=new string[4] { "long", "bool", "int", "byte" }  },
                new Question { text = "Как правильно объявить символьную переменную?", answer = "char a = 'a';", textAnswer="char: хранит одиночный символ в кодировке Unicode и занимает 2 байта.", answerArray=new string[4] { "char a = 'a';", "char a = \"a\";", "string a = 'a';", "char 1a = 'a';" }  },
                new Question { text = "Как объявить float переменную?", answer = "float b = 30.6f;", textAnswer="При присвоении значений надо иметь в виду следующую тонкость: все вещественные литералы (дробные числа) рассматриваются как значения типа double. И чтобы указать, что дробное число представляет тип float или тип decimal, необходимо к литералу добавлять суффикс: F/f - для float и M/m - для decimal.", answerArray=new string[4] { "float b = 30.6d;", "float b = 30.6f;", "int b = 30.6f;", "float b = 30.6;" }  },
                new Question { text = "int x = 10;\nint z = x + 12;\nКакой результат будет выведен?", answer = "22", textAnswer="", answerArray=new string[4] { "44", "2", "22", "10" }  },
                new Question { text = "double x = 10.0;\ndouble z = x % 4.0;\nКакой результат будет выведен?", answer = "2", textAnswer="", answerArray=new string[4] { "6", "16", "2", "4" }  },
                new Question { text = "int x2 = 5;\nint z2 = x2++;\nConsole.WriteLine($\"{x2} - {z2}\");?", answer = "1", textAnswer="", answerArray=new string[4] { "1", "0", "5", "6" }  },
                new Question { text = "Что такое .NET?", answer = "Framework", textAnswer="", answerArray=new string[4] { "Framework", "DDL", "Класс", "Переменная" }  },
                },
            });
            Test.Add(new Test
            {
                Chapter = "Глава 2",
                Title = "Tест 2",
                TestNumber = "2",
                Preload = "Тест на проверку знаний по главе 2",
                Complited = item.Task2_comp,
                CorrectCount = Convert.ToInt32(item.Test2),
                Questions = {
                new Question { text = "Сколько байт занимает long?", answer = "8", textAnswer="long: хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт. Представлен системным типом System.Int64.", answerArray=new string[4]{ "10", "7", "8", "11"} },
                new Question { text = "Сколько вмежает в себя float?(с одной стороны)", answer = "-3.4*10^38", textAnswer="float: хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта. Представлен системным типом S.", answerArray=new string[4]{ "-3.4*10^38", "-3.6*10^38", "-2324235235", "-6.4*10^38"} },
                new Question { text = "Как объявить строковую переменную?", answer = "string a = \"\";",  textAnswer="", answerArray=new string[4]{ "str a = \"\";", "string a = \'\';", "string a = \"\";", "string a = 4;" } },
                new Question { text = "Какой метод библиотеки Console. выводит данные на экран?", answer = "Write", textAnswer="",answerArray=new string[4]{ "ReadLine", "Write", "Math", "WriteMap" } },
                new Question { text = "int num1 = 8;\nint num2 = 6;\nif (num1 > num2)\n{\nConsole.WriteLine($\"Число {num1} больше числа {num2}\");\n}, что будет выведено на экран?", answer = "Число 8 больше числа 6",  textAnswer="", answerArray=new string[4]{ "Число 8 больше числа 6", "Число 6 больше числа 8", "Число 8 больше числа 10", "Число 4 больше числа 6" } },
                new Question { text = "double x = 10.0;\ndouble z = x % 4.0;\nКакой результат будет выведен?", answer = "2", textAnswer="", answerArray=new string[4] { "6", "16", "2", "4" }  },
                new Question { text = "int x2 = 5;\nint z2 = x2++;\nConsole.WriteLine($\"{x2} - {z2}\");?", answer = "1", textAnswer="", answerArray=new string[4] { "1", "0", "5", "6" }  },
                new Question { text = "Какое служебное слово указывается при объявлении константы?", answer = "const", textAnswer="Слово const указывает, что переменная ясляется не изменяемой.", answerArray=new string[4] { "constant", "consts", "const", "st" }  },
                new Question { text = "Какой цикл состоит из трех частей?", answer = "for", textAnswer="Объявление цикла for состоит из трех частей. Первая часть объявления цикла - некоторые действия, которые выполняются один раз до выполнения цикла. Обычно здесь определяются переменные, которые будут использоваться в цикле.", answerArray=new string[4] { "do while", "if", "while", "for" }  },
                new Question { text = "Какой оператор позволяет досрочно выйти из цикла?", answer = "break", textAnswer="Иногда возникает ситуация, когда требуется выйти из цикла, не дожидаясь его завершения. В этом случае мы можем воспользоваться оператором break.", answerArray=new string[4] { "continue", "break", "var", "let" }  },
                },

            }); Test.Add(new Test
            {
                Chapter = "Глава 2",
                Title = "Tест 3",
                Complited = item.Task3_comp,
                TestNumber = "3",
                Preload = "Тест на проверку знаний по главе 2",
                CorrectCount = Convert.ToInt32(item.Test3),
                Questions = {
                new Question { text = "Где правильно объявлен ступенчаытый массив?", answer = "int[][] a = new int[2][3];", textAnswer="", answerArray=new string[4]{ "int[][] a = new int[2][3];", "int[][] a = new int[2];", "int a = new int[2][3];", "int[] a = 4" } },
                new Question { text = "Какой версии C# нет?", answer = "16", textAnswer="C# уже не молодой язык и как и вся платформа .NET уже прошел большой путь. Первая версия языка вышла вместе с релизом Microsoft Visual Studio .NET в феврале 2002 года. Текущей версией языка является версия C# 10.0, которая вышла 8 ноября 2021 года вместе с релизом .NET 6.", answerArray=new string[4]{ "8", "16", "6", "7" } },
                new Question { text = "Console.WriteLine(\"Hello, World\");, что будет выведено на экран?", answer = "Hello, World", textAnswer="", answerArray=new string[4]{ "Helo, World", "Hollo, world", "hello, World;;;;", "Hello, World" } },
                new Question { text = "Как предотвратить закрытие консоли после выполнения программы?", answer = "ReadLine", textAnswer="", answerArray=new string[4]{ "WriteLine", "ReadTitle", "ReadLine", "Write" } },
                new Question { text = "Какой цикл сначало проверяет условие?", answer = "While",  textAnswer="", answerArray=new string[4]{ "Do While", "While", "break", "continue"} },
                new Question { text = "Поддерживает ли C# множественное наследование?", answer = "Да",  textAnswer="", answerArray=new string[4]{ "Нет", "Да", "При подключении бибилеотек", "Было раньше"} },
                new Question { text = "Где правильно объявлена переменная?", answer = "string name;", textAnswer="тип имя_переменной;",answerArray=new string[4] { "str name;", "string name;", "string name:", "let name;" }  },
                new Question { text = "Что выведет код string name = \"Tom\";\nConsole.WriteLine(name);", answer = "Tom", textAnswer="Будет выведена объявленная переменная.", answerArray=new string[4] { "TOd", "mot", "tim", "Tom" } },
                new Question { text = "Что такое .NET?", answer = "Framework", textAnswer="", answerArray=new string[4] { "Framework", "DDL", "Класс", "Переменная" }  },
                new Question { text = "Сколько байт занимает long?", answer = "8", textAnswer="long: хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт. Представлен системным типом System.Int64.", answerArray=new string[4]{ "10", "7", "8", "11"} },

                },
            });

            return Test;

        }
    }
}