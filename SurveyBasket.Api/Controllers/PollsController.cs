namespace SurveyBasket.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        private readonly IPollService _pollService = pollService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();
            var res = polls.Adapt<IEnumerable<PollResponse>>();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var poll = _pollService.Get(id);
            if (poll == null)
                return NotFound();

            var response = poll.Adapt<PollResponse>();
            return Ok(response);
        }

        [HttpPost("")]
        public IActionResult Add(PollRequest x)
        {

            var NewPoll = _pollService.Add(x.Adapt<Poll>());
            return CreatedAtAction(nameof(Get), new { id = NewPoll.Id }, NewPoll);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PollRequest x)
        {
            bool res = _pollService.Update(id, x.Adapt<Poll>());
            if (!res)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            bool res = _pollService.Delete(id);
            if (!res)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}