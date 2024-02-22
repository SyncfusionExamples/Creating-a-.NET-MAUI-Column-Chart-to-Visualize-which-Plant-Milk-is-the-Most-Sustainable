using Syncfusion.Maui.Charts;
using Microsoft.Maui.Graphics;

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
            if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)
            {
                var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));
                var trackRect = new RectF() { Left = Left, Top = (float)top, Right = Right, Bottom = Bottom };
                DrawTrackPath(canvas, trackRect);
                canvas.SaveState();
                DrawColumn(canvas);
                canvas.RestoreState();
            }
        }

        private void DrawColumn(ICanvas canvas)
        {
            var path = new PathF();

#if ANDROID || IOS

            path.MoveTo(Left + 20, Bottom);
            path.LineTo(Right - 20, Bottom);
            path.LineTo(Right - 20, Top);
            path.LineTo(Left + 20, Top);
            path.Close();

#elif WINDOWS || MACCATALYST

            path.MoveTo(Left + 10, Bottom);
            path.LineTo(Right - 10, Bottom);
            path.LineTo(Right - 10, Top);
            path.LineTo(Left + 10, Top);
            path.Close();
#endif

            var color = (Fill is SolidColorBrush brush) ? brush.Color : Colors.Transparent;
            canvas.FillColor = color;
            canvas.FillPath(path);
        }

        private void DrawTrackPath(ICanvas canvas, RectF trackRect)
        {
            var path = new PathF();

#if ANDROID || IOS

            path.MoveTo(Left + 20, Bottom);
            path.LineTo(Right - 20, Bottom);
            path.LineTo(Right - 20, trackRect.Top + 10);
            path.LineTo(Right - 40, trackRect.Top + 5);
            path.LineTo(Right - 40, trackRect.Top);
            path.LineTo(Left + 40, trackRect.Top);
            path.LineTo(Left + 40, trackRect.Top + 5);
            path.LineTo(Left + 20, trackRect.Top + 10);
            path.Close();

#elif WINDOWS || MACCATALYST

            path.MoveTo(Left + 10, Bottom);
            path.LineTo(Right - 10, Bottom);
            path.LineTo(Right - 10, trackRect.Top + 30);
            path.LineTo(Right - 30, trackRect.Top + 15);
            path.LineTo(Right - 30, trackRect.Top);
            path.LineTo(Left + 30, trackRect.Top);
            path.LineTo(Left + 30, trackRect.Top + 15);
            path.LineTo(Left + 10, trackRect.Top + 30);
            path.Close();
#endif

            canvas.FillColor = Color.FromRgb(243, 241, 255);
            canvas.FillPath(path);
        }
    }
}