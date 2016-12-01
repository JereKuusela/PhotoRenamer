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

namespace Valokuva
{
  public partial class Form1 : Form
  {
    List<CameraInfo> Cameras;

    public Form1()
    {
      InitializeComponent();
      Cameras = new List<CameraInfo>();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void selectSourceButton_click(object sender, EventArgs e)
    {
      sourceFolderBrowser.ShowDialog();
      if (sourceFolderBrowser.SelectedPath == "")
        return;
      Directory.SetCurrentDirectory(sourceFolderBrowser.SelectedPath);
      textProgress.Clear();
      Cameras = Analyzer.GetCamerasWithMediaFiles(sourceFolderBrowser.SelectedPath, textProgress);
      cameraView.Items.Clear();
      foreach (var camera in Cameras)
      {
        var item = new ListViewItem("");
        item.SubItems.Add(camera.Manufacter);
        item.SubItems.Add(camera.Model);
        cameraView.Items.Add(item);
      }
      Renamer.ShowFiles(Cameras, listMedia);
    }

    private void cameraView_click(object sender, EventArgs e)
    {
      if (cameraView.SelectedItems.Count > 0)
        cameraView.SelectedItems[0].BeginEdit();
    }

    private void renameFilesButton_Click(object sender, EventArgs e)
    {
      int cameraIndex = 0;
      foreach (ListViewItem item in cameraView.Items)
      {
        Debug.Assert(item.SubItems.Count == 3);
        Cameras[cameraIndex].Tag = item.Text;
        cameraIndex++;
      }
      if (Renamer.CollectNames(Cameras, listMedia))
      {
        Renamer.RenameFiles(Cameras, textProgress);
        Renamer.ShowFiles(Cameras, listMedia);
      }
      else
        textProgress.Text = "Incorrect dates. Unable to rename.";
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      sourceFolderBrowser.ShowDialog();
      if (sourceFolderBrowser.SelectedPath == "")
        return;
      if (Renamer.CollectNames(Cameras, listMedia))
        Saver.SaveFiles(sourceFolderBrowser.SelectedPath, Cameras, textProgress);
      else
        textProgress.Text = "Incorrect dates. Unable to save.";
    }

    private void listMedia_Click(object sender, EventArgs e)
    {
      if (listMedia.SelectedItems.Count > 0 && listMedia.SelectedItems[0].ForeColor != Color.Gray)
        listMedia.SelectedItems[0].BeginEdit();
    }
  }
}
