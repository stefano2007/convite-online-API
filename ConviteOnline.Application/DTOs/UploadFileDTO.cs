namespace ConviteOnline.Application.DTOs
{
    public class UploadFileDTO
    {
        public string FileName { get; set; }
        public MemoryStream Stream { get; set; }
        public string NewFileName { get; private set; }
        public string NewId { get; private set; }
        public UploadFileDTO(string fileName, MemoryStream stream)
        {
            FileName = fileName;
            Stream = stream;
            //Para facilita a busca no s3 usar o New Id na entidade Foto com o mesmo nome do arquivo.
            NewId = Guid.NewGuid().ToString();

            var fileExt = Path.GetExtension(fileName);
            NewFileName = $"{NewId}{fileExt}";
        }
    }
}
