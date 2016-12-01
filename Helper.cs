using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Valokuva
{
  static public class Helper
  {
      /// <summary>
      /// Changes date taken for a photo.
      /// </summary>
      static public void ChangeDateTaken(Image image, DateTime date)
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
