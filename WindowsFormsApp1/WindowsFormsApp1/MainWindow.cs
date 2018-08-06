using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {
        private int MapWidth = 0;
        private int MapHeight = 0;

        //TODO: Make these settings save 
        private float scaling = 1.0f;
        private float sideTrim = 0;
        private bool grey = false;
        private int panelSize = 125;
        private int panelPadding = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Bitmap CombineImages(Image[] images, Point[] points, Size finalSize)
        {
            Bitmap bmp = new Bitmap(finalSize.Width, finalSize.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] == null) continue;
                g.DrawImage(images[i], points[i]);
            }
            if(grey)
                bmp = MakeGrayscale3(bmp);
            if(scaling != 1)
            {
                int newWidth = Convert.ToInt32(finalSize.Width * scaling);
                int newHeight = Convert.ToInt32(finalSize.Height * scaling);
                bmp = ResizeImage(bmp, newWidth, newHeight);
            }
            return bmp;
            //bmp.Save(@"D:\Programming\C#\output.jpg");
        }
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
                                            new float[][]
                                            {
                                                new float[] {.3f, .3f, .3f, 0, 0},
                                                new float[] {.59f, .59f, .59f, 0, 0},
                                                new float[] {.11f, .11f, .11f, 0, 0},
                                                new float[] {0, 0, 0, 1, 0},
                                                new float[] {0, 0, 0, 0, 1}
                                            });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
            0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        private void btnSettings_Clicked(object sender, EventArgs e)
        {
            SettingsDialog settings = new SettingsDialog();
            if(settings.ShowDialog() == DialogResult.OK)
            {
                scaling = settings.Scaling;
                sideTrim = settings.SideTrim;
                grey = settings.Greyscale;
            }
            else
            {

            }
        }

        private void ClearPanels()
        {
            foreach (Panel p in Controls.OfType<Panel>().Reverse())
            {
                Controls.Remove(p);
            }
        }

        private void btnApply_Clicked(object sender, EventArgs e)
        {
            if(MapWidth != 0)
                if(MessageBox.Show("This will clear your current data.\nAre you sure?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            MapWidth = int.Parse(boxWidth.Text);
            MapHeight = int.Parse(boxHeight.Text);
            CreatePanels(MapWidth, MapHeight);
        }

        private void CreatePanels(int w, int h)
        {
            ClearPanels();

            Panel[,] panels = new Panel[w, h];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Point p = new Point(panelSize * i + panelPadding * i, 
                                        panelSize * j + panelPadding * j);
                    Size size = new Size(panelSize, panelSize);
                    MapTile tile = new MapTile { Coords = new Point(i, j) };
                    Panel panel = GetNewPanel(p, size, tile);
                    /*Panel panel = new Panel();
                    panel.Size = new Size(panelSize, panelSize);
                    panel.Location = p;
                    panel.BackColor = Color.Black;
                    panel.AllowDrop = true;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    panel.DragEnter += Panel_DragEnter;
                    panel.DragLeave += Panel_DragLeave;
                    panel.DragDrop += Panel_DragDrop;
                    panel.DoubleClick += Panel_DoubleClick;
                    panel.Tag = new MapTile { Coords = new Point(i, j) };*/
                    Controls.Add(panel);
                }
            }
        }

        private Panel GetNewPanel(Point location, Size size, MapTile tile)
        {
            Panel panel = new Panel();
            panel.Size = size;
            panel.Location = location;
            panel.BackColor = Color.Black;
            panel.AllowDrop = true;
            panel.BackgroundImageLayout = ImageLayout.Stretch;
            panel.DragEnter += Panel_DragEnter;
            panel.DragLeave += Panel_DragLeave;
            panel.DragDrop += Panel_DragDrop;
            panel.DoubleClick += Panel_DoubleClick;
            panel.Tag = tile;
            return panel;
        }

        private void AddPanelColLeft(object sender, EventArgs e)
        {
            Size add = new Size(1, 0);
            Size locAdd = new Size(panelSize + panelPadding, 0);
            foreach (Panel p in Controls.OfType<Panel>())
            {
                MapTile mt = (MapTile)p.Tag;
                mt.Coords += add;
                p.Location += locAdd;
            }

            Size size = new Size(panelSize, panelSize);
            for (int i = 0; i < MapHeight; i++)
            {
                MapTile mt = new MapTile { Coords = new Point(0, i) };
                Point location = new Point(0, i * panelSize + i * panelPadding);
                Panel p = GetNewPanel(location, size, mt);
                Controls.Add(p);
            }

            MapWidth++;
        }

        private void AddPanelColRight(object sender, EventArgs e)
        {
            Size size = new Size(panelSize, panelSize);
            for (int i = 0; i < MapHeight; i++)
            {
                MapTile mt = new MapTile { Coords = new Point(MapWidth, i) };
                Point location = new Point(MapWidth * panelSize + MapWidth * panelPadding, i * panelSize + i * panelPadding);
                Panel p = GetNewPanel(location, size, mt);
                Controls.Add(p);
            }

            MapWidth++;
        }

        private void AddPanelRowTop(object sender, EventArgs e)
        {
            Size add = new Size(0, 1);
            Size locAdd = new Size(0, panelSize+panelPadding);
            foreach (Panel p in Controls.OfType<Panel>())
            {
                MapTile mt = (MapTile)p.Tag;
                mt.Coords += add;
                p.Location += locAdd;
            }

            Size size = new Size(panelSize, panelSize);
            for (int i = 0; i < MapWidth; i++)
            {
                MapTile mt = new MapTile { Coords = new Point(i, 0) };
                Point location = new Point(i * panelSize + i * panelPadding, 0);
                Panel p = GetNewPanel(location, size, mt);
                Controls.Add(p);
            }

            MapHeight++;
        }

        private void AddPanelRowBottom(object sender, EventArgs e)
        {
            Size size = new Size(panelSize, panelSize);
            for (int i = 0; i < MapWidth; i++)
            {
                MapTile mt = new MapTile { Coords = new Point(i, MapHeight) };
                Point location = new Point(i * panelSize + i * panelPadding, MapHeight * panelSize + MapHeight * panelPadding);
                Panel p = GetNewPanel(location, size, mt);
                Controls.Add(p);
            }

            MapHeight++;
        }

        private void Panel_DoubleClick(object sender, EventArgs e)
        {
            ((Panel)sender).BackgroundImage = null;
        }

        private void Panel_DragLeave(object sender, EventArgs e)
        {

        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (s.Length < 1)
                MessageBox.Show("Only one at a time please");
            else
            {
                Panel p = (Panel)sender;
                p.BackgroundImage = Image.FromFile(s[0]);
                ((MapTile)p.Tag).PathToImage = s[0];
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "png";
            saveFile.Filter = "PNG files (*.png)|*.png";
            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                List<Image> images = new List<Image>();
                List<Point> points = new List<Point>();
                Size tempSize = Size.Empty;
                foreach(Panel p in Controls.OfType<Panel>())
                {
                    if (p.BackgroundImage != null)
                    {
                        MapTile t = (MapTile)p.Tag;
                        int x = t.Coords.X;
                        int y = t.Coords.Y;
                        images.Add(p.BackgroundImage);
                        points.Add(new Point(p.BackgroundImage.Width * x, p.BackgroundImage.Height * y));
                        if(tempSize.IsEmpty)
                            tempSize = p.BackgroundImage.Size;
                        else if(tempSize != p.BackgroundImage.Size)
                        {
                            if (MessageBox.Show("Not all images are of the same size. Continue?", "Size Mismatch!", MessageBoxButtons.YesNo) == DialogResult.No)
                                return;
                        }
                    }
                }

                Size finalSize = new Size(MapWidth * tempSize.Width, MapHeight * tempSize.Height);
                Bitmap bmp = CombineImages(images.ToArray(), points.ToArray(), finalSize);

                bmp.Save(saveFile.FileName, ImageFormat.Png); //PNG is default
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "map";
            saveFile.Filter = "Map files (*.map)|*.map";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Map map = new Map();
                map.Name = Path.GetFileName(saveFile.FileName);
                map.MapWidth = MapWidth;
                map.MapHeight = MapHeight;

                foreach (Panel p in Controls.OfType<Panel>())
                {
                    map.AddTile((MapTile)p.Tag);
                }

                map.SaveMapToFile(saveFile.FileName);
            }
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Map files (*.map)|*.map";
            openFile.Multiselect = false;

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                Map m = new Map();
                m.LoadMapFromPath(openFile.FileName);
                MapWidth = m.MapWidth;
                MapHeight = m.MapHeight;

                CreatePanels(MapWidth, MapHeight);

                foreach (MapTile tile in m.GetTiles())
                {
                    Panel p = (from pan in Controls.OfType<Panel>()
                               where ((MapTile)pan.Tag).Coords == tile.Coords
                               select pan).First();
                    p.Tag = tile;
                    if (tile.PathToImage != "")
                        p.BackgroundImage = Image.FromFile(tile.PathToImage);
                }
            }
        }
    }
}
