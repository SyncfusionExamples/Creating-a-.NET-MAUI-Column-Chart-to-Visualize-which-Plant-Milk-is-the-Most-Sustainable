using Syncfusion.Maui.Charts;
using System.Drawing;

namespace SustainableMilk
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class ColumnSeriesExt : ColumnSeries
    {
        protected override ChartSegment CreateSegment()
        {
            return new ColumnSegmentExt();
        }
    }

    public class ColumnSegmentExt : ColumnSegment
    {
        protected override void Draw(ICanvas canvas)
        {
#if ANDROID || IOS
            var path = new PathF();
            path.MoveTo(Left + 20, Bottom);
            path.LineTo(Right - 20, Bottom);
            path.LineTo(Right - 20, Top + 10);
            path.LineTo(Right - 40, Top + 5);
            path.LineTo(Right - 40, Top);
            path.LineTo(Left + 40, Top);
            path.LineTo(Left + 40, Top + 5);
            path.LineTo(Left + 20, Top + 10);
            path.Close();

#elif WINDOWS || MACCATALYST

            var path = new PathF();
            path.MoveTo(Left + 10, Bottom);
            path.LineTo(Right - 10, Bottom);
            path.LineTo(Right - 10, Top + 30);
            path.LineTo(Right - 30, Top + 15);
            path.LineTo(Right - 30, Top);
            path.LineTo(Left + 30, Top);
            path.LineTo(Left + 30, Top + 15);
            path.LineTo(Left + 10, Top + 30);
            path.Close();
#endif

            var color = (Fill is SolidColorBrush brush) ? brush.Color : Colors.Transparent;
            canvas.FillColor = color;
            canvas.FillPath(path);
        }
    }
}