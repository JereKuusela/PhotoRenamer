using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PhotoRenamer
{
  static public class Renamer
  {
    /// <summary>
    /// Renames media files (inside cameras) based on their date.
    /// Without date, "NULL" is added to find those files easily.
    /// </summary>
    static public void RenameFiles(List<Camera> cameras, ProgressBox progressBox, string defaultBame)
    {
      var fileCount = cameras.Sum(item => item.Files.Count);
      if (progressBox != null)
        progressBox.Init("Renaming " + fileCount + " files.", fileCount);
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          Debug.Assert(File.Exists(mediaFile.FilePath));
          if ((mediaFile.IsDateReal || defaultBame.Length == 0) && mediaFile.NewDate.Ticks > 0)
            mediaFile.NewName = mediaFile.NewDate.ToString(MediaFile.STRING_FORMAT);
          else if (defaultBame.Length > 0)
            mediaFile.NewName = defaultBame;
          else
            mediaFile.NewName = "NULL_" + Path.GetFileNameWithoutExtension(mediaFile.FilePath);
          if (camera.Tag.Length > 0)
            mediaFile.NewName += "_" + camera.Tag;
          mediaFile.NewName += Path.GetExtension(mediaFile.FilePath);
          if (progressBox != null)
            progressBox.Tick();
        }
      }
    }
  }
}
