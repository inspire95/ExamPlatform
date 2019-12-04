using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class AnswerSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var answer1 = new DBAnswer
            {
                AnswerId = 1,
                IsCorrect = false,
                QuestionId = 1,
                Content = "Oznacza dostanie spadku po zmarłym przodku.",
                Points = 0
            };
            var answer2 = new DBAnswer
            {
                AnswerId = 2,
                IsCorrect = true,
                QuestionId = 1,
                Content = "To mechanizm współdzielenia funkcjonalności między klasami.",
                Points = 1
            };
            var answer3 = new DBAnswer
            {
                AnswerId = 3,
                IsCorrect = true,
                QuestionId = 1,
                Content = "Z dziedziczeniem mamy do czynienia, gdy klasa pochodna dziedziczy po dokładnie jednej klasie bazowej.",
                Points = 1
            };
            var answer4 = new DBAnswer
            {
                AnswerId = 4,
                IsCorrect = false,
                QuestionId = 3,
                Content = "Wyjechało w bieszczady na ferie.",
                Points = 0
            };
            var answer5 = new DBAnswer
            {
                AnswerId = 5,
                IsCorrect = false,
                QuestionId = 3,
                Content = "Ewoluowało w pytanie o QuestionId = 4.",
                Points = 0
            };
            var answer6 = new DBAnswer
            {
                AnswerId = 6,
                IsCorrect = true,
                QuestionId = 3,
                Content = "Jakiś głąb nie dodał.",
                Points = 1
            };
            var answer7 = new DBAnswer
            {
                AnswerId = 7,
                IsCorrect = false,
                QuestionId = 4,
                Content = "Private, Public, Public, Abstract",
                Points = 0
            };
            var answer8 = new DBAnswer
            {
                AnswerId = 8,
                IsCorrect = false,
                QuestionId = 4,
                Content = "Private, Public, Static, Protected internal",
                Points = 0
            };
            var answer9 = new DBAnswer
            {
                AnswerId = 9,
                IsCorrect = true,
                QuestionId = 4,
                Content = "Private, Protected, Public, Internal, Protected internal",
                Points = 1
            };
            var answer10 = new DBAnswer
            {
                AnswerId = 10,
                IsCorrect = false,
                QuestionId = 5,
                Content = "Definicja abstrakcyjnego typu posiadającego jedynie operacje, a nie dane.",
                Points = 0
            };
            var answer11 = new DBAnswer
            {
                AnswerId = 11,
                IsCorrect = false,
                QuestionId = 5,
                Content = "Klasa, która nie może mieć swoich reprezentantów pod postacią obiektów.",
                Points = 0
            };
            var answer12 = new DBAnswer
            {
                AnswerId = 12,
                IsCorrect = true,
                QuestionId = 5,
                Content = "Specjalna metoda danej klasy, wywoływana podczas tworzenia jej instancji.",
                Points = 1
            };
            var answer13 = new DBAnswer
            {
                AnswerId = 13,
                IsCorrect = false,
                QuestionId = 6,
                Content = "Paradygmat programowania, w którym programy definiuje się za pomocą obiektów – elementów łączących stan (",
                Points = 0
            };
            var answer14 = new DBAnswer
            {
                AnswerId = 14,
                IsCorrect = false,
                QuestionId = 6,
                Content = "Może oznaczać wzór jednostki miary, wzór rzeczy, wyrobu albo zalecany wygląd lub zachowanie się osoby",
                Points = 0
            };
            var answer15 = new DBAnswer
            {
                AnswerId = 15,
                IsCorrect = true,
                QuestionId = 6,
                Content = "Uniwersalne, sprawdzone w praktyce rozwiązanie często pojawiających się, powtarzalnych problemów projektowych",
                Points = 1
            };
            
            AddOrUpdateAnswer(answer1, context);
            AddOrUpdateAnswer(answer2, context);
            AddOrUpdateAnswer(answer3, context);
            AddOrUpdateAnswer(answer4, context);
            AddOrUpdateAnswer(answer5, context);
            AddOrUpdateAnswer(answer6, context);
            AddOrUpdateAnswer(answer7, context);
            AddOrUpdateAnswer(answer8, context);
            AddOrUpdateAnswer(answer9, context);
            AddOrUpdateAnswer(answer10, context);
            AddOrUpdateAnswer(answer11, context);
            AddOrUpdateAnswer(answer12, context);
            AddOrUpdateAnswer(answer13, context);
            AddOrUpdateAnswer(answer14, context);
            AddOrUpdateAnswer(answer15, context);

            DataSeed.ResetSequence(context, "Answers_AnswerId_seq", context.Answers.Max(x => x.AnswerId) + 1);
        }

        private static void AddOrUpdateAnswer(DBAnswer answer, ExamPlatformContext context)
        {
            var answerToChange = context.Answers
                .Where(x => x.AnswerId == answer.AnswerId)
                .FirstOrDefault();

            if (answerToChange == null)
            {
                context.Answers.Add(answer);
            }
            else
            {
                answerToChange.Content = answer.Content;
                answerToChange.Points = answer.Points;
                answerToChange.IsCorrect = answer.IsCorrect;
                answerToChange.QuestionId = answer.QuestionId;
            }
            context.SaveChanges();
        }
    }
}
