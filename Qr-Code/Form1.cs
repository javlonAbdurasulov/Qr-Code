using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Glimpse.Mvc.Message;
using QRCoder;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode;


namespace Qr_Code
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private FilterInfoCollection CaptureDevice;
		private VideoCaptureDevice FinalFrame;
		private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			pictureBox1.Image = (Image)eventArgs.Frame.Clone();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			foreach (FilterInfo Device in CaptureDevice)
			{
				comboBox1.Items.Add(Device.Name);
			}
			comboBox1.SelectedIndex = 0;
			FinalFrame = new VideoCaptureDevice();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (FinalFrame.IsRunning == true)
			{
				FinalFrame.SignalToStop();
				FinalFrame.WaitForStop();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
			FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
			FinalFrame.Start();
			button1.Enabled = false;
			button2.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			timer1.Start();
			button2.Enabled = false;
			textBox1.Text = "";
		}
		private byte[] ConvertBitmapToByteArray(Bitmap bitmap)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

				return stream.ToArray();
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			Bitmap bitmap = new Bitmap(pictureBox1.Image);

			BitmapLuminanceSource source = new BitmapLuminanceSource(bitmap);
			BinaryBitmap binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));
			QRCodeReader qrCodeReader = new QRCodeReader();
			
			try
			{
				Result result = qrCodeReader.decode(binaryBitmap);
				if (result != null)
				{
					string decodedData = result.Text;
					textBox1.Text = decodedData;
				}
			}
			catch (ReaderException rex)
			{
				Console.WriteLine("Error decoding QR Code: " + rex.Message);
			}
			#region MyRegion

			//string imagePath = "путь_к_изображению";
			////Image image = (Image)pictureBox1.Image;
			////BinaryBitmap binary = (BinaryBitmap)image;
			////QRCodeReader QrReader = new QRCodeReader();
			////QRCodeData qrdata = QrReader.decode(binary);
			//// Загрузите изображение
			//var bitmap = (Bitmap)Image.FromFile(imagePath);
			////ZXing.LuminanceSource luminanceSource = new ZXing.RGBLuminanceSource(bitmap, bitmap.Width, bitmap.Height);
			////BinaryBitmap binaryBitmap = new BinaryBitmap(new HybridBinarizer(luminanceSource));

			//// Прочтите QR-код с изображения
			////var result = QrReader.decode();

			//// Выведите результат
			////if (result != null)
			////{
			////	Console.WriteLine("Содержимое QR-кода: " + result.Text);
			////}
			////else
			////{
			////	Console.WriteLine("QR-код не обнаружен.");
			////}
			//////BarcodeReader Reader = new BarcodeReader();
			/////*using (*/
			//////var ms = new MemoryStream();/*)*/
			//////	//{

			//////	pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			//////	byte[] bytes = ms.ToArray();
			////Bitmap bitmap = new Bitmap(pictureBox1.Image);

			//////ZXing.LuminanceSource luminanceSource = new ZXing.Windows.Compatibility.WindowsImageLuminanceSource(bitmap);
			////ZXing.LuminanceSource luminanceSource = new ZXing.RGBLuminanceSource(bitmap, bitmap.Width, bitmap.Height);

			//////LuminanceSource luminanceSource = new LuminanceSource(bitmap);
			////Result result = Reader.Decode(luminanceSource);
			////	//}

			////try
			////{
			////	string decoded = result.ToString().Trim();
			////	//ms.Close();
			////	textBox1.Text = decoded;

			////	if(decoded != "123")
			////	{
			////		timer1.Stop();
			////		button2.Enabled=true;
			////		MessageBox.Show("Welcome");
			////		textBox1.Text=decoded;
			////	}
			////}
			////catch(Exception ex)
			////{
			////         }

			#endregion


		}
	}
}
