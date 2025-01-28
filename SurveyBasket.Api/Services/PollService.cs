
using SurveyBasket.Api.Model;

namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
          new Poll {Id=1,Title="num1",Description="hi"}
          ];

        public Poll? Get(int id)=> _polls.FirstOrDefault(i => i.Id == id);

        public IEnumerable<Poll>? GetAll() => _polls;
        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count+1;
            _polls.Add(poll);
            return poll;
        }

        public bool Update(int id, Poll poll)
        {
            var current = Get(id);
            if(current != null)
            {
                current.Title = poll.Title;
                current.Description = poll.Description;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var current = Get(id);
            if (current != null)
            {
                _polls.Remove(current);
                return true;
            }
            return false;
        }
    }
}
