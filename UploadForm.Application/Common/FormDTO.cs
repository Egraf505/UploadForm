using Microsoft.AspNetCore.Http;


namespace UploadForm.Application.Common
{
    public class PersonDTO
    {
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}
