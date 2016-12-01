using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Valokuva
{
  public class CameraInfo
  {
    public string Manufacter { get; set; }
    public string Model { get; set; }
    public List<MediaFile> Files;
    public string Tag { get; set; }

    public CameraInfo(string manufacter, string model)
    {
      Debug.Assert(manufacter != null);
      Debug.Assert(model != null);
      Manufacter = manufacter;
      Model = model;
      Files = new List<MediaFile>();
    }

    public CameraInfo(BitmapMetadata metaData)
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
    }

    public override bool Equals(object obj)
    {
      CameraInfo objCam = (CameraInfo)obj;
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
