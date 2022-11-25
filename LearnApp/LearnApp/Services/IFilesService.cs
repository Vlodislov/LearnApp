using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnApp.Services
{
    public interface IFilesService
    {
        string StorageDirectory { get; }
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
        void OpenFile(string path);
    }
}
