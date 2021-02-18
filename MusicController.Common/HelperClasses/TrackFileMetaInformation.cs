using System;
using System.IO;
using System.Linq;

namespace MusicController.Common.HelperClasses
{
    public class TrackFileMetaInformation
    {
        private readonly string[] _validExtensions = { ".mp3", ".mp4", ".wmv", ".mov", ".AVI" };
        public string FileName { get; set; }
        public string FolderName => "Playlists";
        public string Extension => Path.GetExtension(FileName).ToLower();
        public string UniqueName { get; set; }
        public string UniqueNameWithextension => UniqueName + Extension;
        public string RelivtivePath => Path.Combine(FolderName, UniqueNameWithextension);
        public bool IsTrack => _validExtensions.Contains(Extension.ToLower());
    }
}
