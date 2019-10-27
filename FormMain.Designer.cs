﻿namespace ScaleNearestNeighborWinFormCSharp
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.groupBoxAffine = new System.Windows.Forms.GroupBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.sliderScale = new System.Windows.Forms.TrackBar();
            this.btnGo = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblSelectFileName = new System.Windows.Forms.Label();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxOperation.SuspendLayout();
            this.groupBoxAffine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScale)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(847, 29);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Scale Nearest Neighbor";
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.lblSelectFileName);
            this.groupBoxImage.Controls.Add(this.pictureBox);
            this.groupBoxImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxImage.Location = new System.Drawing.Point(267, 37);
            this.groupBoxImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBoxImage.Size = new System.Drawing.Size(568, 578);
            this.groupBoxImage.TabIndex = 6;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Image";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(9, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(550, 518);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // btnInit
            // 
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Location = new System.Drawing.Point(44, 148);
            this.btnInit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(150, 50);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.OnClickBtnInit);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(44, 208);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.OnClickBtnClose);
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSelect.Location = new System.Drawing.Point(44, 28);
            this.btnFileSelect.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(150, 50);
            this.btnFileSelect.TabIndex = 1;
            this.btnFileSelect.Text = "File Select...";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.OnClickBtnFileSelect);
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.btnSaveImage);
            this.groupBoxOperation.Controls.Add(this.btnInit);
            this.groupBoxOperation.Controls.Add(this.btnClose);
            this.groupBoxOperation.Controls.Add(this.btnFileSelect);
            this.groupBoxOperation.Controls.Add(this.groupBoxAffine);
            this.groupBoxOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxOperation.Location = new System.Drawing.Point(15, 37);
            this.groupBoxOperation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBoxOperation.Size = new System.Drawing.Size(240, 578);
            this.groupBoxOperation.TabIndex = 5;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "Operation";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.Location = new System.Drawing.Point(44, 88);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(150, 50);
            this.btnSaveImage.TabIndex = 2;
            this.btnSaveImage.Text = "Save Image...";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.OnClickBtnSaveImage);
            // 
            // groupBoxAffine
            // 
            this.groupBoxAffine.Controls.Add(this.labelValue);
            this.groupBoxAffine.Controls.Add(this.sliderScale);
            this.groupBoxAffine.Controls.Add(this.btnGo);
            this.groupBoxAffine.Location = new System.Drawing.Point(31, 302);
            this.groupBoxAffine.Name = "groupBoxAffine";
            this.groupBoxAffine.Size = new System.Drawing.Size(183, 148);
            this.groupBoxAffine.TabIndex = 8;
            this.groupBoxAffine.TabStop = false;
            this.groupBoxAffine.Text = "Scale";
            // 
            // labelValue
            // 
            this.labelValue.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelValue.Location = new System.Drawing.Point(71, 23);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(40, 28);
            this.labelValue.TabIndex = 11;
            this.labelValue.Text = "0.1";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sliderScale
            // 
            this.sliderScale.AutoSize = false;
            this.sliderScale.LargeChange = 1;
            this.sliderScale.Location = new System.Drawing.Point(19, 49);
            this.sliderScale.Maximum = 20;
            this.sliderScale.Minimum = 1;
            this.sliderScale.Name = "sliderScale";
            this.sliderScale.Size = new System.Drawing.Size(150, 40);
            this.sliderScale.TabIndex = 5;
            this.sliderScale.Value = 10;
            this.sliderScale.Scroll += new System.EventHandler(this.OnScrollSliderScale);
            // 
            // btnGo
            // 
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(19, 97);
            this.btnGo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(150, 37);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.OnClickBtnGo);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 624);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(820, 15);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 8;
            // 
            // lblSelectFileName
            // 
            this.lblSelectFileName.Location = new System.Drawing.Point(9, 25);
            this.lblSelectFileName.Name = "lblSelectFileName";
            this.lblSelectFileName.Size = new System.Drawing.Size(550, 21);
            this.lblSelectFileName.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxOperation);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.groupBoxImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxOperation.ResumeLayout(false);
            this.groupBoxAffine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sliderScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.GroupBox groupBoxAffine;
        private System.Windows.Forms.TrackBar sliderScale;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblSelectFileName;
    }
}
