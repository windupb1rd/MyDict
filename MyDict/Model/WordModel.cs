using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDict.Model
{
    public class WordModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string EnglishWord { get; set; }

        [StringLength(50)]
        public string? Transcription { get; set; }
        public string? Definition1 { get; set; }
        public string? Definition2 { get; set; }
        public string? Definition3 { get; set; }
        public string? Definition4 { get; set; }
        public string? Definition5 { get; set; }
        public string? Example1 { get; set; }
        public string? Example2 { get; set; }
        public string? Example3 { get; set; }
        public string? Example4 { get; set; }
        public string? Example5 { get; set; }
        public string? Translations { get; set; }
        public DateTime NextReview { get; private set; }
        public bool IsOnLearning { get; private set; }

        public void CalculateNextReviewDate()
        {
            NextReview = DateTime.Now;
        }

        public void SetStatus()
        {
            IsOnLearning = true;
        }
    }
}
