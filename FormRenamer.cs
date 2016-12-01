using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoRenamer
{
  public partial class formRenamer : Form
  {
    List<Camera> Cameras;

    public formRenamer()
    {
      InitializeComponent();
      Cameras = new List<Camera>();
    }

    private void FormRenamer_load(object sender, EventArgs e)
    {
    }

    private void buttonAnalyze_click(object sender, EventArgs e)
    {
      sourceFolderBrowser.ShowDialog();
      if (sourceFolderBrowser.SelectedPath == "")
        return;
      Cameras = Analyzer.GetCamerasWithMediaFiles(sourceFolderBrowser.SelectedPath, textProgress);
      GUI.ShowCameras(Cameras, listCameras);
      GUI.ShowFiles(Cameras, listFiles);
    }

    private void listCameras_click(object sender, EventArgs e)
    {
      if (listCameras.SelectedItems.Count > 0)
        listCameras.SelectedItems[0].BeginEdit();
    }

    private void buttonRename_Click(object sender, EventArgs e)
    {
      GUI.CollectTags(Cameras, listCameras);
      if (GUI.CollectDates(Cameras, listFiles))
      {
        Renamer.RenameFiles(Cameras, textProgress);
        GUI.ShowFiles(Cameras, listFiles);
      }
      else
        textProgress.Text = "Incorrect dates. Unable to rename.";
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      sourceFolderBrowser.ShowDialog();
      if (sourceFolderBrowser.SelectedPath == "")
        return;
      if (GUI.CollectDates(Cameras, listFiles))
        Saver.SaveFiles(sourceFolderBrowser.SelectedPath, Cameras, textProgress);
      else
        textProgress.Text = "Incorrect dates. Unable to save.";
    }

    private void listFiles_click(object sender, EventArgs e)
    {
      if (listFiles.SelectedItems.Count > 0 && listFiles.SelectedItems[0].ForeColor != Color.Gray)
        listFiles.SelectedItems[0].BeginEdit();
    }
  }
}
