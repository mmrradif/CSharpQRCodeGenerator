using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using ZXing;
//using ZXing.QrCode;

namespace QRcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox1.Image = code.GetGraphic(2);

            var bmp = code.GetGraphic(2);
            pictureBox1.Image = bmp;

            SaveQR(bmp);

            //var writer = new BarcodeWriter();
            //writer.Format = BarcodeFormat.QR_CODE;
            //var text = textBox1.Text;
            //var result = writer.Write(text);
            //pictureBox1.Image = result;
        }

        //private void SaveQR(System.Drawing.Bitmap bmp)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveQR(Bitmap bitmap)
        {
            var directoryPath = Application.StartupPath + "\\Images";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            //var filename = "QR" + DateTime.Now.Millisecond + ".jpg";

            var filename = "Author" + ".jpg";

            filename = directoryPath + "\\" + filename;
            bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
