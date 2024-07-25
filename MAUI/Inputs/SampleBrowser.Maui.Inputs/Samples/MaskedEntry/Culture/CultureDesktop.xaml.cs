#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Maui.Base;
using System.Globalization;

namespace SampleBrowser.Maui.Inputs.SfMaskedEntry;

public partial class CultureDesktop : SampleView
{
	public CultureDesktop()
	{
		InitializeComponent();
        cultureMask.Culture = new CultureInfo("en-US");
    }

    private void IndiaImageButton_Clicked(object sender, EventArgs e)
    {
        cultureMask.Culture = new CultureInfo("en-IN");
        ResetColor();
        ResetSize();
        indiaBorder.SetAppThemeColor(Border.StrokeProperty, Color.FromArgb("#6750A4"), Color.FromArgb("#D0BCFF"));
        indiaStack.HeightRequest = 34;
        indiaStack.WidthRequest = 42;
#if MACCATALYST
        indiaImage.WidthRequest = 40;
        indiaImage.HeightRequest = 32;
#endif
    }

    private void USImageButton_Clicked(object sender, EventArgs e)
    {
        cultureMask.Culture = new CultureInfo("en-US");
        ResetColor();
        ResetSize();
        usBorder.SetAppThemeColor(Border.StrokeProperty, Color.FromArgb("#6750A4"), Color.FromArgb("#D0BCFF"));
        usStack.HeightRequest = 34;
        usStack.WidthRequest = 42;
#if MACCATALYST
        usImage.WidthRequest = 40;
        usImage.HeightRequest = 32;
#endif
    }

    private void RussiaImageButton_Clicked(object sender, EventArgs e)
    {
        cultureMask.Culture = new CultureInfo("ru-RU");
        ResetColor();
        ResetSize();
        russiaBorder.SetAppThemeColor(Border.StrokeProperty, Color.FromArgb("#6750A4"), Color.FromArgb("#D0BCFF"));
        russiaStack.HeightRequest = 34;
        russiaStack.WidthRequest = 42;
#if MACCATALYST
        russiaImage.WidthRequest = 40;
        russiaImage.HeightRequest = 32;
#endif
    }


    private void FranceImageButton_Clicked(object sender, EventArgs e)
    {
        cultureMask.Culture = new CultureInfo("fr-FR");
        ResetColor();
        ResetSize();
        franceBorder.SetAppThemeColor(Border.StrokeProperty, Color.FromArgb("#6750A4"), Color.FromArgb("#D0BCFF"));
        franceStack.HeightRequest = 34;
        franceStack.WidthRequest = 42;
#if MACCATALYST
        franceImage.WidthRequest = 40;
        franceImage.HeightRequest = 32;
#endif
    }

    void ResetColor()
    {
        indiaBorder.Stroke = Colors.Transparent;
        franceBorder.Stroke = Colors.Transparent;
        usBorder.Stroke = Colors.Transparent;
        russiaBorder.Stroke = Colors.Transparent;
    }

    void ResetSize()
    {
        usStack.WidthRequest = 36;
        usStack.HeightRequest = 28;
        indiaStack.WidthRequest = 36;
        indiaStack.HeightRequest = 28;
        russiaStack.WidthRequest = 36;
        russiaStack.HeightRequest = 28;
        franceStack.WidthRequest = 36;
        franceStack.HeightRequest = 28;
#if MACCATALYST
        usImage.WidthRequest = 36;
        usImage.HeightRequest = 28;
        indiaImage.WidthRequest = 36;
        indiaImage.HeightRequest = 28;
        russiaImage.WidthRequest = 36;
        russiaImage.HeightRequest = 28;
        franceImage.WidthRequest = 36;
        franceImage.HeightRequest = 28;
#endif
    }
}