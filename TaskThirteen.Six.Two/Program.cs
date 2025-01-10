using System;
using System.ComponentModel.Design;

namespace TaskThirteen.Six.Two
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение текста из файла
            string text = File.ReadAllText("C:\\Users\\user\\Desktop\\input.txt");

            // Удаление знаков пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Приведение текста к нижнему регистру и разделение на слова
            var words = noPunctuationText.ToLower().Split(new char[] { ' ', '\n', '\r' });

            // Подсчет частоты слов
            var wordCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            // Получение 10 самых частых слов
            var topWords = wordCounts.OrderByDescending(kvp => kvp.Value).Take(10);

            //Вывод результата
            foreach (var kvp in topWords)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
