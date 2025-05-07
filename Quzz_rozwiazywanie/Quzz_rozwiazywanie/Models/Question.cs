namespace Quzz_rozwiazywanie.Models
{
    public class Question
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public int Points { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
            Points = 1;
        }
    }
}