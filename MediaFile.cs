using System;
namespace PhotoRenamer
{
  public enum MediaType
  {
    None, Image, Photo, Video
  }

  /// <summary>
  /// A struct representing an image, a photo or a video. Includes necessary information to do the rename.
  /// Photos are image files with a date value. Technically videos could include date but unfortunately it's not stored.
  /// </summary>
  public class MediaFile
  {
    public static string STRING_FORMAT = "yyyy-MM-dd_HH-mm-ss";

    public DateTime OldDate { get; set; }
    public DateTime NewDate { get; set; }
    public string FilePath { get; set; }
    public string NewName { get; set; }
    public MediaType Type { get; set; }
    public bool IsDateReal { get; set; }

    public MediaFile(string filePath)
    {
      FilePath = filePath;
      NewName = "";
    }
  }
}
