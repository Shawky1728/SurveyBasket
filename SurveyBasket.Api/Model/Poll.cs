using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyBasket.Api.Model
{
    public class Poll
    {
        public int Id { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ? Description { get; set; } = string.Empty;
    }
}
