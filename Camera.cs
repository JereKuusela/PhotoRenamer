using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace PhotoRenamer
{
  /// <summary>
  /// A struct representing a camera and its files. Dummy cameras used for files without the camera information.
  /// </summary>
  public class Camera
  {
    /// <summary>
    /// Camera manufacter directly from the metadata. For images and videos, file extension is used to give some information.
    /// </summary>
    public string Manufacter { get; set; }
    /// <summary>
    /// Camera model directly from the metadata. For images and videos, first letters from the file name are used to give some information.
    /// </summary>
    public string Model { get; set; }
    /// <summary>
    /// Media files taken with this camera.
    /// </summary>
    public List<MediaFile> Files;
    /// <summary>
    /// Tag for this camera which gets applied to the file names of its files.
    /// </summary>
    public string Tag { get; set; }

    public Camera(string manufacter, string model)
    {
      Debug.Assert(manufacter != null);
      Debug.Assert(model != null);
      Manufacter = manufacter;
      Model = model;
      Files = new List<MediaFile>();
      Tag = "";
    }

    public Camera(BitmapMetadata metaData)
    {
      if (metaData != null)
      {
        Manufacter = metaData.CameraManufacturer;
        Model = metaData.CameraModel;
      }
      if (Manufacter == null)
        Manufacter = "None";
      if (Model == null)
        Model = "None";
      Files = new List<MediaFile>();
      Tag = "";
    }

    public override bool Equals(object obj)
    {
      Camera objCam = (Camera)obj;
      if (objCam == null)
        return false;
      return objCam.Manufacter.Equals(Manufacter) && objCam.Model.Equals(Model);
    }

    public override int GetHashCode()
    {
      return Manufacter.GetHashCode() + Model.GetHashCode();
    }
  }
}
