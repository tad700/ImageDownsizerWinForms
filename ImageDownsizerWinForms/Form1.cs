using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ImageDownsizerWinForms
{
    public partial class Form1 : Form
    {
        Image img;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imagePath = txtPath.Text;
            if (File.Exists(imagePath))
            {
                img = Image.FromFile(imagePath);
                pictureBox1.Image = img;
                MessageBox.Show("Image Loaded");
            }
            else
            {
                MessageBox.Show("Image file not found.");
            }
        }

        private Bitmap ImageToBitmap(Image image)
        {
            using (Bitmap bitmap = new Bitmap(image.Width, image.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                }
                // The Bitmap and Graphics objects are disposed when leaving this scope
                return new Bitmap(bitmap); // Create a new Bitmap to avoid using the disposed one
            }
        }


        private Bitmap ResizeImage(Bitmap sourceImage, int newWidth, int newHeight)
        {
            // Calculate the aspect ratio of the source image
            float aspectRatio = (float)sourceImage.Width / sourceImage.Height;

            // Calculate new dimensions while preserving the aspect ratio
            if (sourceImage.Width > sourceImage.Height)
            {
                newHeight = (int)(newWidth / aspectRatio);
            }
            else
            {
                newWidth = (int)(newHeight * aspectRatio);
            }

            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(sourceImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private void ResizeImageAndSave(Image img, int percent, string savePath)
        {
            float scale = percent / 100f;

            // Calculate new dimensions while preserving the aspect ratio
            int newWidth = (int)(img.Width * scale);
            int newHeight = (int)(img.Height * scale);

            using (Bitmap sourceBitmap = ImageToBitmap(img))
            using (Bitmap resizedImage = ResizeImage(sourceBitmap, newWidth, newHeight))
            {
                // Save the resized image
                resizedImage.Save(savePath, ImageFormat.Jpeg); // You can change the format as needed
            }
        }


        private void downSizeButton_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                if (int.TryParse(txtPercent.Text, out int percent))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JPEG Image|*.jpg";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveFileDialog.FileName;
                        // Measure time for sequential operation
                        Stopwatch stopwatchSequential = new Stopwatch();
                        stopwatchSequential.Start();

                        ResizeImageAndSave(img, percent, savePath);

                        stopwatchSequential.Stop();
                        MessageBox.Show($"Sequential operation took {stopwatchSequential.ElapsedMilliseconds} ms");
                        // Measure time for threaded operation
                        Stopwatch stopwatchThreaded = new Stopwatch();
                        stopwatchThreaded.Start();

                        // Create a separate thread for resizing and saving
                        Thread thread = new Thread(() =>
                        {
                            ResizeImageAndSave(img, percent, savePath);
                            stopwatchThreaded.Stop();

                            // Update UI directly on the main UI thread
                            this.Invoke((Action)(() =>
                            {
                                MessageBox.Show($"Threaded operation took {stopwatchThreaded.ElapsedMilliseconds} ms");
                            }));
                        });

                        thread.Start();
                        thread.Join();


                    }
                }
                else
                {
                    MessageBox.Show("Invalid percentage value.");
                }
            }
            else
            {
                MessageBox.Show("No image loaded.");
            }
        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
