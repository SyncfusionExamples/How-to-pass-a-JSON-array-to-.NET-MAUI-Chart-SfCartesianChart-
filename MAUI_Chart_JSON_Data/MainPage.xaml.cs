using Newtonsoft.Json;

namespace MAUI_Chart_JSON_Data;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        string jsonData = @"{'Medal':[{'Country':'USA','Count':46},{'Country':'China','Count':36},{'Country':'Japan','Count':63},{'Country':'Australia','Count':54},{'Country':'France','Count':50}]}";

        var jsonDataCollection = JsonConvert.DeserializeObject<ViewModel>(jsonData);
        chart.BindingContext = jsonDataCollection;
    }
}

