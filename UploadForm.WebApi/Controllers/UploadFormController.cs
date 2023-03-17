using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadForm.Application.Common;
using UploadForm.Domain;
using UploadForm.Persistence.Context;

namespace UploadForm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFormController : ControllerBase
    {
        private UploadFormContext _context;
        private IWebHostEnvironment _environment;

        public UploadFormController(UploadFormContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> PostForm(PersonDTO personDTO)
        {
            if (personDTO == null)
                return BadRequest("Data is null");

            Person person = new Person() { Name = personDTO.Name, SurName = personDTO.SurName, MiddleName = personDTO.MiddleName };

            await _context.People.AddAsync(person);

            if (personDTO.Image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(personDTO.Image))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    string path = _environment.WebRootPath + "/Photo/";                    
                    using (FileStream fileStream = new FileStream(path + personDTO.FileName,FileMode.Create))
                    {
                        await memoryStream.CopyToAsync(fileStream);
                    }

                    FileModel file = new FileModel() { Name = personDTO.FileName, Path = path, Person = person };
                    await _context.FileModels.AddAsync(file);
                }
            }

            await _context.SaveChangesAsync();

            return StatusCode(201, person);
        }
       
    }
}
