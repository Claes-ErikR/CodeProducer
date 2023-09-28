namespace Utte.Code.Forms
{
    partial class ManageSettings
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
            this.chkUseRegions = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bfdBaseFileDirectory = new Utte.Controls.Input.BrowseFileDirectory();
            this.SuspendLayout();
            // 
            // chkUseRegions
            // 
            this.chkUseRegions.AutoSize = true;
            this.chkUseRegions.Location = new System.Drawing.Point(40, 31);
            this.chkUseRegions.Name = "chkUseRegions";
            this.chkUseRegions.Size = new System.Drawing.Size(82, 17);
            this.chkUseRegions.TabIndex = 0;
            this.chkUseRegions.Text = "Use regions";
            this.chkUseRegions.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(128, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bfdBaseFileDirectory
            // 
            this.bfdBaseFileDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bfdBaseFileDirectory.FileName = "";
            this.bfdBaseFileDirectory.FileTypeExtension = null;
            this.bfdBaseFileDirectory.FileTypeName = null;
            this.bfdBaseFileDirectory.IncludeXmlSave = true;
            this.bfdBaseFileDirectory.Label = "Save directory for generated files";
            this.bfdBaseFileDirectory.Location = new System.Drawing.Point(24, 54);
            this.bfdBaseFileDirectory.Name = "bfdBaseFileDirectory";
            this.bfdBaseFileDirectory.OwnerForm = null;
            this.bfdBaseFileDirectory.Size = new System.Drawing.Size(1126, 40);
            this.bfdBaseFileDirectory.TabIndex = 3;
            this.bfdBaseFileDirectory.Type = Utte.Controls.Input.BrowseFileDirectory.BrowseType.Directory;
            // 
            // ManageSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1179, 147);
            this.ControlBox = false;
            this.Controls.Add(this.bfdBaseFileDirectory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkUseRegions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ManageSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Manage Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUseRegions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Utte.Controls.Input.BrowseFileDirectory bfdBaseFileDirectory;
    }
}