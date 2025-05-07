using System;
using System.Collections.Generic;
using System.Linq;

namespace Quzz_rozwiazywanie.Models
{
    public class QuizAttempt
    {
        public Quiz Quiz { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Dictionary<Question, List<Answer>> UserAnswers { get; set; }
        public int TotalPoints { get; set; }
        public int MaxPoints { get; set; }

        public QuizAttempt(Quiz quiz)
        {
            Quiz = quiz;
            StartTime = DateTime.Now;
            UserAnswers = new Dictionary<Question, List<Answer>>();
            MaxPoints = CalculateMaxPoints();
        }

        private int CalculateMaxPoints()
        {
            return Quiz.Questions.Sum(q => q.Points);
        }

        public void AddAnswer(Question question, Answer answer)
        {
            if (!UserAnswers.ContainsKey(question))
            {
                UserAnswers[question] = new List<Answer>();
            }

            if (UserAnswers[question].Contains(answer))
            {
                UserAnswers[question].Remove(answer);
            }
            else
            {
                UserAnswers[question].Add(answer);
            }
        }

        public void EndAttempt()
        {
            EndTime = DateTime.Now;
            CalculateScore();
        }

        private void CalculateScore()
        {
            TotalPoints = 0;
            foreach (var question in Quiz.Questions)
            {
                if (IsQuestionCorrectlyAnswered(question))
                {
                    TotalPoints += question.Points;
                }
            }
        }

        private bool IsQuestionCorrectlyAnswered(Question question)
        {
            if (!UserAnswers.ContainsKey(question))
                return false;

            var userAnswers = UserAnswers[question];
            var correctAnswers = question.Answers.Where(a => a.IsCorrect).ToList();

            if (userAnswers.Count != correctAnswers.Count)
                return false;

            return userAnswers.All(ua => correctAnswers.Any(ca => ca.Text == ua.Text));
        }
    }
}