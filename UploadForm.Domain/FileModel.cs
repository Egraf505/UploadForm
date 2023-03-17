
namespace UploadForm.Domain
{
    public class FileModel
    {
        public int Id { get; set; }
        public Person Person { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
    }
}
