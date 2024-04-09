using Microsoft.AspNetCore.Http;

namespace Carvajar_2._1.Models
{
    public class UploadModel
    {
        public IFormFile? ReqFuncFile { get; set; }
        public IFormFile? ReqNoFuncFile { get; set; }
        public IFormFile? ReqAmbienteFile { get; set; }
   

    }
}
