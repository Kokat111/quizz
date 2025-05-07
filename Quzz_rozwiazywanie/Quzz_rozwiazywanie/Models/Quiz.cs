using System;
using System.Collections.Generic;

namespace Quzz_rozwiazywanie.Models
{
    public class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime CreatedDate { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();
            CreatedDate = DateTime.Now;
        }
    }
}

