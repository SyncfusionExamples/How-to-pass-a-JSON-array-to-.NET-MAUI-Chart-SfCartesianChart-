# How to pass a JSON array to .NET MAUI Chart (SfCartesianChart)?

This example illustrates how to bind the JSON data to the [.NET MAUI charts](https://www.syncfusion.com/maui-controls/maui-charts).

JSON data cannot be bound directly to the [SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html?tabs=tabid-1), so you should deserialize the JSON data to a bindable format. Use the open-source NuGet [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) to serialize and deserialize the JSON objects.

The following steps explain how to pass JSON data to the [SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html?tabs=tabid-1).

**JSON data**

```
{
	'Country': 'USA',
	'Count': 46
}, {
	'Country': 'China',
	'Count': 36
}, {
	'Country': 'Japan',
	'Count': 63
}, {
	'Country': 'Australia',
	'Count': 54
}, {
	'Country': 'France',
	'Count': 50
}
```

**Step 1:** Add the [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) reference in your project.

**Step 2:** Create a data model to store JSON data.
```
public class Medal
{
    public string Country { get; set; }
    public int Count { get; set; }
}
```

**Step 3:** Create a ViewModel to store a collection of model objects.
```
public class ViewModel
{
    public ObservableCollection<Medal> Medal { get; set; }
}
```

**Step 4:** Deserialize the JSON data as a collection of data models.
```
using Newtonsoft.Json;

...
{
     ...
     string jsonData = @"{'Medal':[{'Country':'USA','Count':46},{'Country':'China','Count':36},{'Country':'Japan','Count':63},{'Country':'Australia','Count':54},{'Country':'France','Count':50}]}";

     var jsonDataCollection = JsonConvert.DeserializeObject<ViewModel>(jsonData);
     chart.DataContext = jsonDataCollection;
}
```

**Step 5:** Bind the deserialized JSON data to the ChartSeries [ItemsSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_ItemsSource) property and set the [XBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.XYDataSeries.html#Syncfusion_Maui_Charts_XYDataSeries_YBindingPath) properties, so that chart would fetch values from the respective properties in the data model to plot the series.

```
<chart:SfCartesianChart x:Name="chart">
    …
    <chart:ColumnSeries ItemsSource="{Binding Medal}"
                        XBindingPath="Country" 
                        YBindingPath="Count">
    </chart:ColumnSeries>
</chart:SfCartesianChart>
```

## Output:

![.NET MAUI column chart with JSON data]()

KB article - [How to pass a JSON array to .NET MAUI Chart (SfCartesianChart)?]()