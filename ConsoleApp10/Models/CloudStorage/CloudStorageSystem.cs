namespace CloudBackend.Models.CloudStorage
{
    public class CloudStorageSystemModule
    {
        public string uniqueFilename { get; set; }
        public string filename { get; set; }
        public string hash { get; set; }
        public string hash256 { get; set; }
        public long length { get; set; }
        public string contentType { get; set; }
        public string uploaded { get; set; }
        public string storageType { get; set; }
        public bool doNotCache { get; set; }
    }
}
