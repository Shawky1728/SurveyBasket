

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
            return Ok(_pollService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var poll = _pollService.Get(id);
            return poll is null ? NotFound() : Ok(_pollService.Get(id));
        }

        [HttpPost("")]
        public IActionResult Add(Poll x)
        {

            var NewPoll = _pollService.Add(x);
            return CreatedAtAction(nameof(Get), new { id = NewPoll.Id }, NewPoll);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Poll x)
        {
           bool res = _pollService.Update(id, x);
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