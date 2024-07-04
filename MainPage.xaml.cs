namespace SKCanvasViewLeak;

public partial class MainPage : ContentPage
{
    int count = 0;
	WeakReference pageRef;
    public MainPage()
    {
        InitializeComponent();
    }

	void OnOpenPage(object sender, EventArgs e)
	{
		var page = new SKCanvasViewPage();
		Navigation.PushAsync(page);
		pageRef = new WeakReference(page);
	}
	void OnCheckMemoryLeak(object sender, EventArgs e)
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		if (pageRef != null && pageRef.IsAlive)
		{
			DisplayAlert("Memory Leak", "Memory Leak Detected", "OK");
		}
		else
		{
			DisplayAlert("Memory Leak", "No Memory Leak Detected", "OK");
		}
	}
}