namespace ConviteOnline.Application.DTOs
{
    public class UploadFileDTO
    {
        public string FileName { get; set; }
        public MemoryStream Stream { get; set; }
        public string NewFileName { get; private set; }

        public UploadFileDTO(string fileName, MemoryStream stream)
        {
            FileName = fileName;
            Stream = stream;

            var fileExt = Path.GetExtension(fileName);
            NewFileName = $"{Guid.NewGuid()}{fileExt}";
        }
    }
}
