using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valokuva
{
  /// <summary>
  /// Renames given media files (within cameras) based on their date.
  /// </summary>
  static public class Renamer
  {
    static public void RenameFiles(List<CameraInfo> cameras, ProgressBox progressBox)
    {
      var sourcePath = Directory.GetCurrentDirectory();
      int totalCount = 0;
      foreach (var camera in cameras)
        totalCount += camera.Files.Count;
      if (progressBox != null)
        progressBox.Init("Renaming " + totalCount + " files.", totalCount);
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          Debug.Assert(File.Exists(mediaFile.FilePath));
          if (mediaFile.NewDate.Ticks != 0)
            mediaFile.NewName = mediaFile.NewDate.ToString(MediaFile.STRING_FORMAT);
          else
            mediaFile.NewName = "NO_DATE";
          if (camera.Tag.Length > 0)
            mediaFile.NewName += "_" + camera.Tag;
          mediaFile.NewName += Path.GetExtension(mediaFile.FilePath);
          if (progressBox != null)
            progressBox.Tick();
        }
      }
    }

    static public void ShowFiles(List<CameraInfo> cameras, ListView view)
    {
      view.Items.Clear();
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          var dateStr = mediaFile.NewDate.Ticks == 0 ? "" : mediaFile.NewDate.ToString(MediaFile.STRING_FORMAT);
          var item = new ListViewItem(dateStr);
          item.SubItems.Add(mediaFile.Type.ToString());
          item.SubItems.Add(Path.GetFileName(mediaFile.FilePath));
          item.SubItems.Add(mediaFile.NewName);
          view.Items.Add(item);
        }
      }
    }

    static public bool CollectNames(List<CameraInfo> cameras, ListView view)
    {
      var Success = true;
      int Index = -1;
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          Index++;
          if (view.Items[Index].Text.Length == 0)
            continue;
          DateTime date;
          if (DateTime.TryParseExact(view.Items[Index].Text, MediaFile.STRING_FORMAT, null, DateTimeStyles.None, out date))
            mediaFile.NewDate = date;
          else
            Success = false;

        }
      }
      return Success;
    }
  }
}
