using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleNearestNeighborWinFormCSharp
{
    public partial class FormMain : Form
    {
        private Point m_mousePoint;
        private string m_strOpenFileName;
        private ScaleNearestNeighbor m_scaleImgProc;
        private CancellationTokenSource m_tokenSource;

        public FormMain()
        {
            InitializeComponent();

            lblTitle.MouseDown += new MouseEventHandler(OnMouseDownFormMain);
            lblTitle.MouseMove += new MouseEventHandler(OnMouseMoveFormMain);

            m_scaleImgProc = new ScaleNearestNeighbor(progressBar);

            labelValue.Text = "1";
            btnSaveImage.Enabled = false;
        }

        private void OnMouseDownFormMain(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_mousePoint = new Point(e.X, e.Y);
            }
        }

        private void OnMouseMoveFormMain(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - m_mousePoint.X;
                this.Top += e.Y - m_mousePoint.Y;
            }
        }

        private void OnClickBtnFileSelect(object sender, EventArgs e)
        {
            ComOpenFileDialog openFileDlg = new ComOpenFileDialog();
            openFileDlg.Filter = "JPG|*.jpg|PNG|*.png";
            openFileDlg.Title = "Open the file";
            if (openFileDlg.ShowDialog() == true)
            {
                pictureBox.Image = null;
                m_strOpenFileName = openFileDlg.FileName;
                pictureBox.ImageLocation = m_strOpenFileName;
                lblSelectFileName.Text = m_strOpenFileName;
                m_scaleImgProc.Init();
            }

            return;
        }

        private void OnClickBtnClose(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Close the application ?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void OnClickBtnInit(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(m_strOpenFileName))
            {
                pictureBox.ImageLocation = m_strOpenFileName;
            }
            m_scaleImgProc.Init();
            btnSaveImage.Enabled = false;
        }

        private void OnScrollSliderScale(object sender, EventArgs e)
        {
            labelValue.Text = (sliderScale.Value * 0.1).ToString();

            return;
        }

        private async void OnClickBtnGo(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(m_strOpenFileName))
            {
                return;
            }

            btnFileSelect.Enabled = false;
            btnSaveImage.Enabled = false;
            btnInit.Enabled = false;
            btnClose.Enabled = false;
            sliderScale.Enabled = false;
            btnGo.Enabled = false;

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            float fScale = (float)(sliderScale.Value * 0.1);
            var bitmap = new Bitmap(m_strOpenFileName);
            int nWidth = (int)(bitmap.Width * fScale);
            int nHeight = (int)(bitmap.Height * fScale);
            progressBar.Maximum = nWidth * nHeight;

            pictureBox.Image = null;

            bool bResult = await TaskWorkImageProcessing();
            if (bResult)
            {
                pictureBox.Image = m_scaleImgProc.bitmap;
                btnSaveImage.Enabled = true;
            }
            else
            {
                pictureBox.ImageLocation = m_strOpenFileName;
            }

            btnFileSelect.Enabled = true;
            btnInit.Enabled = true;
            btnClose.Enabled = true;
            sliderScale.Enabled = true;
            btnGo.Enabled = true;

            bitmap.Dispose();

            return;
        }

        private async Task<bool> TaskWorkImageProcessing()
        {
            m_tokenSource = new CancellationTokenSource();
            CancellationToken token = m_tokenSource.Token;
            float fScale = (float)(sliderScale.Value * 0.1);
            var bitmap = new Bitmap(m_strOpenFileName);
            bool bRst = await Task.Run(() => m_scaleImgProc.GoImgProc(bitmap, fScale, token, this));
            bitmap.Dispose();
            return bRst;
        }

        private void OnClickBtnSaveImage(object sender, EventArgs e)
        {
            ComSaveFileDialog saveDialog = new ComSaveFileDialog();
            saveDialog.Filter = "PNG|*.png";
            saveDialog.Title = "Save the file";
            if (saveDialog.ShowDialog() == true)
            {
                string strFileName = saveDialog.FileName;
                var bitmap = m_scaleImgProc.bitmap;
                if (bitmap != null)
                {
                    try
                    {
                        bitmap.Save(strFileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Save Image File Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    bitmap.Dispose();
                }
            }

            return;
        }

        private void OnClickBtnStop(object sender, EventArgs e)
        {
            if (m_tokenSource != null)
            {
                m_tokenSource.Cancel();
            }

            return;
        }
    }
}