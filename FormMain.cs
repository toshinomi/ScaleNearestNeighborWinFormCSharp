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
        private Point   m_mousePoint;
        private string  m_strOpenFileName;
        private Bitmap  m_bitmapOrg;
        private Bitmap  m_bitmapAfter;
        private CancellationTokenSource m_tokenSource;

        public FormMain()
        {
            InitializeComponent();

            lblTitle.MouseDown += new MouseEventHandler(OnMouseDownFormMain);
            lblTitle.MouseMove += new MouseEventHandler(OnMouseMoveFormMain);

            labelValue.Text = "1";
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
                m_bitmapOrg = new Bitmap(openFileDlg.FileName);

                pictureBox.Image = null;
                m_strOpenFileName = openFileDlg.FileName;
                pictureBox.ImageLocation = m_strOpenFileName;
                lblSelectFileName.Text = m_strOpenFileName;
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

            if (string.IsNullOrWhiteSpace(labelValue.Text))
            {
                return;
            }

            btnFileSelect.Enabled = false;
            btnSaveImage.Enabled = false;
            btnInit.Enabled = false;
            btnClose.Enabled = false;
            groupBoxAffine.Enabled = false;

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            float fScale = (float)(sliderScale.Value * 0.1);
            int nWidth = (int)(m_bitmapOrg.Width * fScale);
            int nHeight = (int)(m_bitmapOrg.Height * fScale);
            progressBar.Maximum = nWidth * nHeight;

            pictureBox.Image = null;

            bool bResult = await TaskWorkImageProcessing();
            if (bResult)
            {
                pictureBox.Image = m_bitmapAfter;
            }

            btnFileSelect.Enabled = true;
            btnSaveImage.Enabled = true;
            btnInit.Enabled = true;
            btnClose.Enabled = true;
            groupBoxAffine.Enabled = true;

            return;
        }

        private async Task<bool> TaskWorkImageProcessing()
        {
            m_tokenSource = new CancellationTokenSource();
            CancellationToken token = m_tokenSource.Token;
            float fScale = (float)(sliderScale.Value * 0.1);
            bool bRst = await Task.Run(() => ScaleNearestNeighbor(fScale, token));
            return bRst;
        }

        private bool ScaleNearestNeighbor(float _fScale, CancellationToken _token)
        {
            bool bRst = true;

            int nWidthSize = (int)(m_bitmapOrg.Width * _fScale);
            int nHeightSize = (int)(m_bitmapOrg.Height * _fScale);

            m_bitmapAfter = new Bitmap(nWidthSize, nHeightSize);

            BitmapData bitmapDataOrg = m_bitmapOrg.LockBits(new Rectangle(0, 0, m_bitmapOrg.Width, m_bitmapOrg.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bitmapDataAfter = m_bitmapAfter.LockBits(new Rectangle(0, 0, m_bitmapAfter.Width, m_bitmapAfter.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int nIdxWidth;
            int nIdxHeight;
            int nCount = 0;

            unsafe
            {
                for (nIdxHeight = 0; nIdxHeight < nHeightSize; nIdxHeight++)
                {
                    if (_token.IsCancellationRequested)
                    {
                        bRst = false;
                        break;
                    }

                    for (nIdxWidth = 0; nIdxWidth < nWidthSize; nIdxWidth++)
                    {
                        if (_token.IsCancellationRequested)
                        {
                            bRst = false;
                            break;
                        }

                        int nWidth = (int)Math.Round(nIdxWidth / _fScale);
                        int nHeight = (int)Math.Round(nIdxHeight / _fScale);

                        if (nWidth < m_bitmapOrg.Width && nHeight < m_bitmapOrg.Height)
                        {

                            byte* pPixelOrg = (byte*)bitmapDataOrg.Scan0 + nHeight * bitmapDataOrg.Stride + nWidth * 4;
                            byte* pPixelAfter = (byte*)bitmapDataAfter.Scan0 + nIdxHeight * bitmapDataAfter.Stride + nIdxWidth * 4;


                            pPixelAfter[(int)ComInfo.Pixel.B] = pPixelOrg[(int)ComInfo.Pixel.B];
                            pPixelAfter[(int)ComInfo.Pixel.G] = pPixelOrg[(int)ComInfo.Pixel.G];
                            pPixelAfter[(int)ComInfo.Pixel.R] = pPixelOrg[(int)ComInfo.Pixel.R];
                            pPixelAfter[(int)ComInfo.Pixel.A] = pPixelOrg[(int)ComInfo.Pixel.A];

                            nCount++;
                        }
                    }
                    Invoke(new Action<int>(SetProgressBar), nCount);
                }
                m_bitmapOrg.UnlockBits(bitmapDataOrg);
                m_bitmapAfter.UnlockBits(bitmapDataAfter);
            }

            return bRst;
        }

        private void SetProgressBar(int nCount)
        {
            progressBar.Value = nCount;
        }

        private void OnClickBtnSaveImage(object sender, EventArgs e)
        {
            ComSaveFileDialog saveDialog = new ComSaveFileDialog();
            saveDialog.Filter = "PNG|*.png";
            saveDialog.Title = "Save the file";
            if (saveDialog.ShowDialog() == true)
            {
                string strFileName = saveDialog.FileName;
                var bitmap = m_bitmapAfter;
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
    }
}