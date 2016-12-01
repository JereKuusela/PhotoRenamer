using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Valokuva
{
  /// <summary>
  /// Copies media files with new names.
  /// </summary>
  static public class Saver
  {
    static public void SaveFiles(string targetPath, List<CameraInfo> cameras, ProgressBox progressBox)
    {
      var sourcePath = Directory.GetCurrentDirectory();
      if (!Directory.Exists(targetPath))
        Directory.CreateDirectory(targetPath);
      int totalCount = 0;
      foreach (var camera in cameras)
        totalCount += camera.Files.Count;
      if (progressBox != null)
        progressBox.Init("Copying " + totalCount + " files.", totalCount);
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          Debug.Assert(File.Exists(mediaFile.FilePath));
          var targetFile = targetPath + Path.DirectorySeparatorChar + mediaFile.NewName;
          if (File.Exists(targetFile))
          {
            int nameCounter = 1;
            targetFile = targetPath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(mediaFile.NewName) + "_" + nameCounter + Path.GetExtension(mediaFile.NewName);
            while (File.Exists(targetFile))
            {
              nameCounter++;
              targetFile = targetPath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(mediaFile.NewName) + "_" + nameCounter + Path.GetExtension(mediaFile.NewName);
            }
          }
          Debug.Assert(!File.Exists(targetFile));
          if (mediaFile.OldDate != mediaFile.NewDate && mediaFile.Type == MediaType.Photo)
          {
            Image image = new Bitmap(mediaFile.FilePath);
            Helper.ChangeDateTaken(image, mediaFile.NewDate);
            image.Save(targetFile);
            image.Dispose();
          }
          else
            File.Copy(mediaFile.FilePath, targetFile);
          if (progressBox != null)
            progressBox.Tick();
        }
      }
    }
  }
}
