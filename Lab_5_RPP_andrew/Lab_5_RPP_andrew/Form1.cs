using System.Drawing.Drawing2D;

namespace Lab_5_RPP_andrew;

public partial class Form1 : Form
{
    private Color arcColor = Color.Red;
    private Color curveColor = Color.Blue;
    private Color polygonColor = Color.Green;
    private Font textFont = new Font("Arial", 14, FontStyle.Bold);
    private string text = "Hello, Graphics!";
    private Image loadedImage = null;
    private Image resourceImage = Properties.Resources.cows;
    private GraphicsPath customPath = null;
    private Point clickPoint = new Point(100, 100);

    public Form1()
    {
        InitializeComponent();
        this.Paint += Form1_Paint;
    }


    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        
        Point[] polygonPoints = {
                new Point(50, 200),
                new Point(150, 250),
                new Point(100, 300),
                new Point(30, 270)
            };


        if (comboBoxColor.SelectedItem == "зеленый")
        {

            using (Pen penArc = new Pen(Color.Green, 3))
            {
                penArc.DashPattern = new float[] { 4, 2 };
                g.DrawArc(penArc, new Rectangle(500, 20, 150, 100), 30, 180);
            }

 
            using (Pen penCurve = new Pen(Color.Green, 2))
            {
                penCurve.DashPattern = new float[] { 2, 2, 6, 2 };
                Point p1 = new Point(700, 50);
                Point p2 = new Point(750, 150);
                Point p3 = new Point(800, 20);
                Point p4 = new Point(850, 100);
                g.DrawBezier(penCurve, p1, p2, p3, p4);
            }


            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(30, 200, 150, 100),
                Color.Green,
                Color.Orange,
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillPolygon(brush, polygonPoints);
            }
        }
        else if (comboBoxColor.SelectedItem == "красный")
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(30, 200, 150, 100),
                Color.Red,
                Color.Orange,
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillPolygon(brush, polygonPoints);
            }


            using (Pen penArc = new Pen(Color.Red, 3))
            {
                penArc.DashPattern = new float[] { 4, 2 }; 
                g.DrawArc(penArc, new Rectangle(500, 20, 150, 100), 30, 180);
            }


            using (Pen penCurve = new Pen(Color.Red, 2))
            {
                penCurve.DashPattern = new float[] { 2, 2, 6, 2 };
                Point p1 = new Point(700, 50);
                Point p2 = new Point(750, 150);
                Point p3 = new Point(800, 20);
                Point p4 = new Point(850, 100);
                g.DrawBezier(penCurve, p1, p2, p3, p4);
            }

        }
        else
        {

            using (Pen penArc = new Pen(Color.Blue, 3))
            {
                penArc.DashPattern = new float[] { 4, 2 };
                g.DrawArc(penArc, new Rectangle(500, 20, 150, 100), 30, 180);
            }


            using (Pen penCurve = new Pen(Color.Blue, 2))
            {
                penCurve.DashPattern = new float[] { 2, 2, 6, 2 };
                Point p1 = new Point(700, 50);
                Point p2 = new Point(750, 150);
                Point p3 = new Point(800, 20);
                Point p4 = new Point(850, 100);
                g.DrawBezier(penCurve, p1, p2, p3, p4);
            }


            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(30, 200, 150, 100),
                Color.Blue,
                Color.Orange,
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillPolygon(brush, polygonPoints);
            }
        }


        using (Pen penPolygon = new Pen(Color.Black, 2))
        {
            penPolygon.DashPattern = new float[] { 5, 1 };
            g.DrawPolygon(penPolygon, polygonPoints);
        }

        using (Bitmap bmp = new Bitmap(20, 20))
            using (Graphics gBmp = Graphics.FromImage(bmp))
            {
                gBmp.Clear(Color.LightGray);
                gBmp.FillEllipse(Brushes.DarkGreen, 5, 5, 10, 10);

                using (TextureBrush tBrush = new TextureBrush(bmp))
                {
                    Font font = new Font("Arial", 20, FontStyle.Bold);
                    g.DrawString("привет мир", font, tBrush, new PointF(1000, 50));
                }
            }
        if (resourceImage != null)
        {
            PictureBoxSizeMode mode = GetSizeModeFromComboBox();
            Rectangle destRect = new Rectangle(150, 200, 150, 150);

            if (mode == PictureBoxSizeMode.StretchImage)
                g.DrawImage(resourceImage, destRect);
            else if (mode == PictureBoxSizeMode.Normal)
                g.DrawImage(resourceImage, new Point(150, 200));
        }
    }

    private PictureBoxSizeMode GetSizeModeFromComboBox()
    {
        if (comboBoxSize.SelectedItem?.ToString() == "с масштабированием")
            return PictureBoxSizeMode.StretchImage;
        else
            return PictureBoxSizeMode.Normal;
    }

    private void buttonDraw_Click(object sender, EventArgs e)
    {

        this.Invalidate(); 
    }


    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);


        customPath = new GraphicsPath();
        PointF[] star = {
        new PointF(0, -30),
        new PointF(8.5f, -8.5f),
        new PointF(30, -8.5f),
        new PointF(12, 3),
        new PointF(18, 25),
        new PointF(0, 12),
        new PointF(-18, 25),
        new PointF(-12, 3),
        new PointF(-30, -8.5f),
        new PointF(-8.5f, -8.5f)
    };
        customPath.AddLines(star);
        customPath.CloseFigure();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            clickPoint = e.Location;
            Invalidate();
        }
    }


    private Bitmap ModifyImage(Bitmap original)
    {
        Bitmap modified = new Bitmap(original.Width, original.Height);
        for (int x = 0; x < original.Width; x++)
        {
            for (int y = 0; y < original.Height; y++)
            {
                Color c = original.GetPixel(x, y);
                modified.SetPixel(x, y, Color.FromArgb(255, 255 - c.R, 255 - c.G, 255 - c.B));
            }
        }
        return modified;
    }
}
