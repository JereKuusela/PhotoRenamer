using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoRenamer
{
  /// <summary>
  /// Contains various functions for data/user interface interaction.
  /// </summary>
  public static class GUI
  {
    /// <summary>
    /// Puts cameras to a given list view.
    /// </summary>
    static public void ShowCameras(List<Camera> cameras, ListView view)
    {
      view.Items.Clear();
      foreach (var camera in cameras)
      {
        var item = new ListViewItem(camera.Tag);
        item.SubItems.Add(camera.Manufacter);
        item.SubItems.Add(camera.Model);
        Debug.Assert(item.SubItems.Count == 3);
        view.Items.Add(item);
      }
    }

    /// <summary>
    /// Collects camera tags from a given list.
    /// </summary>
    static public void CollectTags(List<Camera> cameras, ListView view)
    {
      Debug.Assert(view.Items.Count == cameras.Count);
      var index = 0;
      foreach (var camera in cameras)
      {
        Debug.Assert(view.Items[index].SubItems.Count == 3);
        camera.Tag = view.Items[index].Text;
        index++;
      }
    }

    /// <summary>
    /// Puts media files to a given list view.
    /// </summary>
    static public void ShowFiles(List<Camera> cameras, ListView view, string defaultDate)
    {
      view.Items.Clear();
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          var dateStr = mediaFile.NewDate.Ticks == 0 ? "" : mediaFile.NewDate.ToString(MediaFile.STRING_FORMAT);
          var item = new ListViewItem(dateStr);
          if (!mediaFile.IsDateReal)
          {
            item.ForeColor = Color.Gray;
            if (defaultDate.Length > 0)
              item.Text = defaultDate;
          }
          item.SubItems.Add(mediaFile.Type.ToString());
          item.SubItems.Add(Path.GetFileName(mediaFile.FilePath));
          item.SubItems.Add(mediaFile.NewName);
          Debug.Assert(item.SubItems.Count == 4);
          view.Items.Add(item);
        }
      }
    }

    /// <summary>
    /// Collects dates from a given list view. Returns whether all dates were valid or not.
    /// </summary>
    static public bool CollectDates(List<Camera> cameras, ListView view)
    {
      Debug.Assert(view.Items.Count == cameras.Sum(item => item.Files.Count));
      var invalidDate = false;
      int index = -1;
      foreach (var camera in cameras)
      {
        foreach (var mediaFile in camera.Files)
        {
          index++;
          Debug.Assert(view.Items[index].SubItems.Count == 4);
          if (view.Items[index].Text.Length == 0)
            continue;
          DateTime date;
          if (DateTime.TryParseExact(view.Items[index].Text, MediaFile.STRING_FORMAT, null, DateTimeStyles.None, out date))
            mediaFile.NewDate = date;
          else
            invalidDate = true;
        }
      }
      return !invalidDate;
    }
  }
}
