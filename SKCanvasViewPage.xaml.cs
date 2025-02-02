namespace SKCanvasViewLeak;
using SkiaSharp;
using SkiaSharp.Views.Maui;

public partial class SKCanvasViewPage : ContentPage
{
	public SKCanvasViewPage()
	{
		InitializeComponent();
		canvasView.InvalidateSurface();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		canvasView.InvalidateSurface();
    }
    void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKImageInfo info = args.Info;
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        float strokeWidth = 50;
        float xRadius = (info.Width - strokeWidth) / 2;
        float yRadius = (info.Height - strokeWidth) / 2;

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = strokeWidth
        };
        canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, paint);
    }
}