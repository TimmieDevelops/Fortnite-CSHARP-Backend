using Microsoft.AspNetCore.Mvc;
using static CloudBackend.Workers.LightswitchController;
using System.Collections.Generic;
using System.Collections;
using System.Net.Mime;
using System.IO;
using System;

namespace CloudBackend.Workers
{
    [Route("fortnite/api")]
    [ApiController]
    public class CloudStorageController: ControllerBase
    {

        public class DefaultGamdecloudstoragesystemodule
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
   
        [HttpGet("cloudstorage/system")]
        public ActionResult<List<DefaultGamdecloudstoragesystemodule>> cloudstoragesystem(string ohno)
        {
            return new List<DefaultGamdecloudstoragesystemodule>
            {
               new DefaultGamdecloudstoragesystemodule() {
                   uniqueFilename = "DefaultGame.ini",
                   filename = "DefaultGame.ini",
                   hash = "603E6907398C7E74E25C0AE8EC3A03FFAC7C9BB4",
                   hash256 = "973124FFC4A03E66D6A4458E587D5D6146F71FC57F359C8D516E0B12A50AB0D9",
                   length = new FileInfo(Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "resources/ini/DefaultGame.ini")).Length,
                   contentType = "text/plain",
                   uploaded = "9999-9999-9999",
                   storageType = "S3",
                   doNotCache = false
               },
               new DefaultGamdecloudstoragesystemodule() { 
                   uniqueFilename = "DefaultEngine.ini", 
                   filename = "DefaultEngine.ini",
                   hash = "603E6907398C7E74E25C0AE8EC3A03FFAC7C9BB4",
                   hash256 = "973124FFC4A03E66D6A4458E587D5D6146F71FC57F359C8D516E0B12A50AB0D9",
                   length = new FileInfo(Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "resources/ini/DefaultEngine.ini")).Length,
                   contentType = "text/plain",
                   uploaded = "9999-9999-9999",
                   storageType = "S3",
                   doNotCache = false
               }
            };
        }
        [HttpGet("cloudstorage/system/{file}")]
        public ActionResult cloudstoragesystemfile(string file)
        {
            try
            {
                this.StatusCode(200);
                string lines = System.IO.File.ReadAllText(Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), $"resources/ini/{file}"));
                return this.Content(lines);
            }
            catch
            {
                return this.StatusCode(200);
            }
         
        }
        [HttpGet("cloudstorage/system/config")]
        public ActionResult<string[]> cloudstoragesystemconfig()
        {
            HttpContext.Response.Headers.Add("Content-Type", "application/json");
            this.StatusCode(200);
            return Array.Empty<string>();
        }
        [HttpGet("cloudstorage/user/{accountId}")]
        public ActionResult<string[]> cloudstorageuseraccountId()
        {
            HttpContext.Response.Headers.Add("Content-Type", "application/json");
            this.StatusCode(200);
            return Array.Empty<string>();
        }
        [HttpPut("cloudstorage/user/{accountId}/{fileName}")]
        public ActionResult cloudstorageuseraccountIdfileName()
        {
            this.StatusCode(200);
            return this.NoContent();
        }
    }
}
