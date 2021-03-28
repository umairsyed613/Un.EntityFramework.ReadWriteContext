using System.Collections.Generic;

namespace Un.EntityFramework.ReadWriteContext.Tests
{
    public partial class Quiz
    {
        public Quiz()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }

    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int QuizId { get; set; }
        public int? CorrectAnswerId { get; set; }
        public virtual Answer CorrectAnswer { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Quiz Quiz { get; set; }
    }

    public class Answer
    {
        public Answer()
        {
            QuestionNavigation = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Question> QuestionNavigation { get; set; }
    }
}
