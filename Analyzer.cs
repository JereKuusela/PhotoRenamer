using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Valokuva
{
  static public class Analyzer
  {
    /// <summary>
    /// Analyzes medial files from a given path and returns relevant information.
    /// </summary>
    /// <returns>Found cameras with media files inside them.</returns>
    static public List<CameraInfo> GetCamerasWithMediaFiles(string path, ProgressBox progressBox)
    {
      var cameras = new List<CameraInfo>();
      Debug.Assert(Directory.Exists(path));
      var filePaths = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
      if (progressBox != null)
        progressBox.Init("Analyzing " + filePaths.Count() + " files.", filePaths.Count());
      foreach (var filePath in filePaths)
      {
        Debug.Assert(File.Exists(filePath));
        var file = new MediaFile(filePath);
        var camera = Analyze(file);
        Debug.Assert(cameras != null);
        if (!cameras.Contains(camera))
          cameras.Add(camera);
        cameras.Find(x => x.Equals(camera)).Files.Add(file);
        if (progressBox != null)
          progressBox.Tick();
      }
      return cameras;
    }

    static private CameraInfo Analyze(MediaFile file)
    {
      file.Type = MediaType.None;
      CameraInfo camera;
      using (FileStream fs = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        file.Type = MediaType.Video;
        file.NewDate = File.GetLastWriteTime(file.FilePath);
        try
        {
          BitmapSource img = BitmapFrame.Create(fs);
          file.Type = MediaType.Image;
          var bm = (BitmapMetadata)img.Metadata;
          // Accessing values can throw exceptions so pre-check them.
          var dummy = bm.CameraManufacturer;
          dummy = bm.CameraModel;
          file.Type = MediaType.Photo;
          if (bm.DateTaken != null)
            file.NewDate = DateTime.Parse(bm.DateTaken);
          camera = new CameraInfo(bm);
          // NOTICE: Metadata is lost after closing the file.
        }
        catch (NotSupportedException)
        {
          camera = new CameraInfo("Format: " + Path.GetExtension(file.FilePath), Regex.Replace(Path.GetFileName(file.FilePath), @"(\p{L}+).*", "$1"));
        }
      }
      file.OldDate = file.NewDate;
      return camera;
    }
  }
}
