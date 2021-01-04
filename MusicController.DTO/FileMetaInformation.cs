using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MusicController.Shared
{
    public class FileMetaInformation
    {
        private readonly string[] _validExtensions = { ".jpg", ".jpeg", ".png" };
        public string FileName { get; set; }
        public string FolderName => "Images";
        public string Extension => Path.GetExtension(FileName).ToLower();
        public string UniqueName { get; set; }
        public string UniqueNameWithextension => UniqueName + Extension;
        public string RelivtivePath => Path.Combine(FolderName, UniqueNameWithextension);
        public bool IsImage => _validExtensions.Contains(Extension.ToLower());

    }
}
