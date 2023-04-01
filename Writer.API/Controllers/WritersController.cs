using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Writer.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Writer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {

        private readonly WritersDbContext context;
        //Constructor Injection
        public WritersController(WritersDbContext context)
        {
            this.context = context;
        }

        // GET: api/<WritersController>  // Yazarları getir.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Writer>>> WriterList()
        {
            List<Models.Writer> writerList = await context.Writers.ToListAsync();
            return writerList;
        }

        // GET api/<WritersController>/5 // Id sine göre yazarı getir
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Writer>> GetWriter(int id)
        {
            // select * from where Writer Id=id
            var writer = await context.Writers.FindAsync(id);
            if (writer==null)
            {
                return NotFound();
            }
            return writer;
        }

        // POST api/<WritersController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Models.Writer>>> AddWriter(Models.Writer writer)
        {   // insert into Writer() values(writer.Id, writer.name)
            context.Writers.Add(writer);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return CreatedAtAction("GetWriter", new { id = writer.Id, }, writer);
        }

        // PUT api/<WritersController>/5
        [HttpPut]
        public async Task<ActionResult<IEnumerable<Models.Writer>>> WriterUpdate(Models.Writer writer)
        {   // update Writer set Id=writerId, Name=writer.Name
            context.Entry(writer).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                ex.Message.ToString();
            }
            return CreatedAtAction("GetWriter", new { id = writer.Id }, writer);
        }

        // DELETE api/<WritersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Writer>> WriterDelete(int id)
        {
            var writer = await context.Writers.FindAsync(id);
            if (writer==null)
            {
                return NotFound();
            }
            context.Writers.Remove(writer);
            await context.SaveChangesAsync();
            return writer;
        }
    }
}
