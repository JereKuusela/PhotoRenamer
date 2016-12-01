using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valokuva
{
  public class ProgressBox : TextBox
  {
    private string StartText;
    private int Total;
    private int Counter;
    private int OldPercent;
    public void Init(string text, int total)
    {
      StartText = text;
      Total = total;
      Counter = 0;
      OldPercent = 0;
      Text = StartText + " (" + OldPercent + "%)";
    }

    public void Tick()
    {
      Counter++;
      var newPercent = 100 * Counter / Total;
      if (newPercent != OldPercent)
      {
        OldPercent = newPercent;
        Text = StartText + " (" + newPercent + "%)";
        Update();
      }
    }

  }
}
