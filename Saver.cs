using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoRenamer
{
  static public class Saver
  {
    /// <summary>
    /// Copies media files with new names and dates.
    /// </summary>
    static public void SaveFiles(string directory, List<Camera> cameras, ProgressBox progressBox)
    {
      if (!Directory.Exists(directory))
        Directory.CreateDirectory(directory);
      var fileCount = cameras.Sum(item => item.Files.Count);
      if (progressBox != null)
        progressBox.Init("Copying " + fileCount + " files.", fileCount);
      foreach (var camera in cameras)
      {
        foreach (var file in camera.Files)
        {
          Debug.Assert(File.Exists(file.FilePath));
          SaveFile(file, GetTargetPath(directory, file));
          if (progressBox != null)
            progressBox.Tick();
        }
      }
    }

    /// <summary>
    /// Returns a full file path for a given name. Handles duplicates properly.
    /// </summary>
    static private string GetTargetPath(string directory, MediaFile file)
    {
      var targetPath = directory + Path.DirectorySeparatorChar + file.NewName;
      var duplicates = 0;
      while (File.Exists(targetPath))
      {
        duplicates++;
        targetPath = directory + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(file.NewName) + "_" + duplicates + Path.GetExtension(file.NewName);
      }
      return targetPath;
    }

    /// <summary>
    /// Saves a given media file. Updates date taken value for photos if needed.
    /// </summary>
    static private void SaveFile(MediaFile file, string filePath)
    {
      Debug.Assert(!File.Exists(filePath));
      if (file.Type != MediaType.Photo || file.OldDate == file.NewDate)
        File.Copy(file.FilePath, filePath);
      else
      {
        Image image = new Bitmap(file.FilePath);
        ChangeDateTaken(image, file.NewDate);
        image.Save(filePath);
        image.Dispose();
      }
    }

    /// <summary>
    /// Changes date taken for a give photo.
    /// This is quite hacky but doesn't require any image encoding.
    /// </summary>
    static private void ChangeDateTaken(Image image, DateTime date)
    {
      PropertyItem[] propItems = image.PropertyItems;
      Encoding _Encoding = Encoding.UTF8;
      var DataTakenProperty1 = propItems.Where(a => a.Id.ToString("x") == "9004").FirstOrDefault();
      var DataTakenProperty2 = propItems.Where(a => a.Id.ToString("x") == "9003").FirstOrDefault();
      Debug.Assert(DataTakenProperty1 != null && DataTakenProperty2 != null);
      DataTakenProperty1.Value = _Encoding.GetBytes(date.ToString("yyyy\":\"MM\":\"dd HH\":\"mm\":\"ss") + '\0');
      DataTakenProperty2.Value = _Encoding.GetBytes(date.ToString("yyyy\":\"MM\":\"dd HH\":\"mm\":\"ss") + '\0');
      image.SetPropertyItem(DataTakenProperty1);
      image.SetPropertyItem(DataTakenProperty2);
    }
  }
}
