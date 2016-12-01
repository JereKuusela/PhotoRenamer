namespace Valokuva
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.buttonAnalyze = new System.Windows.Forms.Button();
      this.sourceFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
      this.cameraView = new System.Windows.Forms.ListView();
      this.columnTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnCamera = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.buttonRename = new System.Windows.Forms.Button();
      this.buttonSave = new System.Windows.Forms.Button();
      this.listMedia = new System.Windows.Forms.ListView();
      this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnOldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.textProgress = new Valokuva.ProgressBox();
      this.SuspendLayout();
      // 
      // buttonAnalyze
      // 
      this.buttonAnalyze.Location = new System.Drawing.Point(12, 12);
      this.buttonAnalyze.Name = "buttonAnalyze";
      this.buttonAnalyze.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.buttonAnalyze.Size = new System.Drawing.Size(100, 34);
      this.buttonAnalyze.TabIndex = 0;
      this.buttonAnalyze.Text = "Analyze";
      this.buttonAnalyze.UseVisualStyleBackColor = true;
      this.buttonAnalyze.Click += new System.EventHandler(this.selectSourceButton_click);
      // 
      // cameraView
      // 
      this.cameraView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTag,
            this.columnCamera,
            this.columnModel});
      this.cameraView.ForeColor = System.Drawing.SystemColors.WindowText;
      this.cameraView.LabelEdit = true;
      this.cameraView.Location = new System.Drawing.Point(12, 52);
      this.cameraView.MultiSelect = false;
      this.cameraView.Name = "cameraView";
      this.cameraView.Size = new System.Drawing.Size(326, 402);
      this.cameraView.TabIndex = 2;
      this.cameraView.TileSize = new System.Drawing.Size(10, 10);
      this.cameraView.UseCompatibleStateImageBehavior = false;
      this.cameraView.View = System.Windows.Forms.View.Details;
      this.cameraView.Click += new System.EventHandler(this.cameraView_click);
      // 
      // columnTag
      // 
      this.columnTag.Text = "Tag";
      // 
      // columnCamera
      // 
      this.columnCamera.Text = "Camera";
      this.columnCamera.Width = 138;
      // 
      // columnModel
      // 
      this.columnModel.Text = "Model";
      this.columnModel.Width = 118;
      // 
      // buttonRename
      // 
      this.buttonRename.Location = new System.Drawing.Point(118, 12);
      this.buttonRename.Name = "buttonRename";
      this.buttonRename.Size = new System.Drawing.Size(100, 34);
      this.buttonRename.TabIndex = 3;
      this.buttonRename.Text = "Rename";
      this.buttonRename.UseVisualStyleBackColor = true;
      this.buttonRename.Click += new System.EventHandler(this.renameFilesButton_Click);
      // 
      // buttonSave
      // 
      this.buttonSave.Location = new System.Drawing.Point(224, 12);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(100, 34);
      this.buttonSave.TabIndex = 4;
      this.buttonSave.Text = "Rename + Sasve";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // listMedia
      // 
      this.listMedia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDate,
            this.columnType,
            this.columnOldName,
            this.columnNewName});
      this.listMedia.ForeColor = System.Drawing.SystemColors.WindowText;
      this.listMedia.LabelEdit = true;
      this.listMedia.Location = new System.Drawing.Point(344, 52);
      this.listMedia.MultiSelect = false;
      this.listMedia.Name = "listMedia";
      this.listMedia.Size = new System.Drawing.Size(598, 402);
      this.listMedia.TabIndex = 3;
      this.listMedia.TileSize = new System.Drawing.Size(10, 10);
      this.listMedia.UseCompatibleStateImageBehavior = false;
      this.listMedia.View = System.Windows.Forms.View.Details;
      this.listMedia.Click += new System.EventHandler(this.listMedia_Click);
      // 
      // columnDate
      // 
      this.columnDate.Text = "Date";
      this.columnDate.Width = 108;
      // 
      // columnOldName
      // 
      this.columnOldName.Text = "Old name";
      this.columnOldName.Width = 125;
      // 
      // columnNewName
      // 
      this.columnNewName.Text = "New name";
      this.columnNewName.Width = 125;
      // 
      // columnType
      // 
      this.columnType.Text = "Type";
      // 
      // textProgress
      // 
      this.textProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textProgress.Location = new System.Drawing.Point(330, 15);
      this.textProgress.Name = "textProgress";
      this.textProgress.ReadOnly = true;
      this.textProgress.Size = new System.Drawing.Size(326, 26);
      this.textProgress.TabIndex = 1;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1424, 529);
      this.Controls.Add(this.cameraView);
      this.Controls.Add(this.listMedia);
      this.Controls.Add(this.buttonAnalyze);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.textProgress);
      this.Controls.Add(this.buttonRename);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button buttonAnalyze;
    private System.Windows.Forms.FolderBrowserDialog sourceFolderBrowser;
    private System.Windows.Forms.ListView cameraView;
    private System.Windows.Forms.ColumnHeader columnTag;
    private System.Windows.Forms.ColumnHeader columnCamera;
    private System.Windows.Forms.ColumnHeader columnModel;
    private System.Windows.Forms.Button buttonRename;
    private System.Windows.Forms.ListView listMedia;
    private System.Windows.Forms.ColumnHeader columnDate;
    private System.Windows.Forms.ColumnHeader columnOldName;
    private System.Windows.Forms.ColumnHeader columnNewName;
    private System.Windows.Forms.Button buttonSave;
    private ProgressBox textProgress;
    private System.Windows.Forms.ColumnHeader columnType;
  }
}

