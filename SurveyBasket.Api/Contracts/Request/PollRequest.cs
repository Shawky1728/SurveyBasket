
using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.Api.Contracts.Request
{
    public record PollRequest(
       string ?Title,
        string Description);
}
