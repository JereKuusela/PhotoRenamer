using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
namespace Valokuva
{
  public enum MediaType
  {
    None, Image, Photo, Video
  }

  public class MediaFile
  {
    public static string STRING_FORMAT = "yyyy-MM-dd_HH-mm-ss";

    public DateTime OldDate { get; set; }
    public DateTime NewDate { get; set; }
    public string FilePath { get; set; }
    public string NewName { get; set; }
    public MediaType Type { get; set; }

    public MediaFile(string filePath)
    {
      FilePath = filePath;
      NewName = Path.GetFileName(FilePath);
    }
  }
}
