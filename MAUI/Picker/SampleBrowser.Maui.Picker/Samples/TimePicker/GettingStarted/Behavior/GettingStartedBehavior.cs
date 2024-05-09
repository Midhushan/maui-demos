#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace SampleBrowser.Maui.Picker.SfTimePicker
{
    using SampleBrowser.Maui.Base;
    using Syncfusion.Maui.Inputs;
    using Syncfusion.Maui.Picker;
    using System.Collections.ObjectModel;
    using Syncfusion.Maui.Buttons;

    public class GettingStartedBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// Picker view 
        /// </summary>
        private SfTimePicker? timePicker;

        /// <summary>
        /// The show header switch
        /// </summary>
        private SfSwitch? showHeaderSwitch, showColumnHeaderSwitch, showFooterSwitch;

        /// <summary>
        /// The date format combo box.
        /// </summary>
        private SfComboBox? formatComboBox;

        /// <summary>
        /// The time format to set the combo box item source.
        /// </summary>
        private ObservableCollection<object>? formats;

        /// <summary>
        /// Check the application theme is light or dark.
        /// </summary>
        private bool isLightTheme = Application.Current?.RequestedTheme == AppTheme.Light;

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);

#if IOS || MACCATALYST
            Border border = bindable.Content.FindByName<Border>("border");
            border.IsVisible = true;
            border.Stroke = isLightTheme ? Color.FromArgb("#CAC4D0") : Color.FromArgb("#49454F");
            this.timePicker = bindable.Content.FindByName<SfTimePicker>("TimePicker1");
#else
            Frame frame = bindable.Content.FindByName<Frame>("frame");
            frame.IsVisible = true;
            frame.BorderColor = isLightTheme ? Color.FromArgb("#CAC4D0") : Color.FromArgb("#49454F");
            this.timePicker = bindable.Content.FindByName<SfTimePicker>("TimePicker");
#endif

            this.timePicker.HeaderView.Height = 50;
            this.timePicker.HeaderView.Text = "Select a Time";
            this.showHeaderSwitch = bindable.Content.FindByName<SfSwitch>("showHeaderSwitch");
            this.showColumnHeaderSwitch = bindable.Content.FindByName<SfSwitch>("showColumnHeaderSwitch");
            this.showFooterSwitch = bindable.Content.FindByName<SfSwitch>("showFooterSwitch");

            if (this.showHeaderSwitch != null)
            {
                this.showHeaderSwitch.StateChanged += ShowHeaderSwitch_Toggled;
            }

            if (this.showColumnHeaderSwitch != null)
            {
                this.showColumnHeaderSwitch.StateChanged += ShowColumnHeaderSwitch_Toggled;
            }

            if (this.showFooterSwitch != null)
            {
                this.showFooterSwitch.StateChanged += ShowFooterSwitch_Toggled;
            }

            formats = new ObservableCollection<object>()
            {
                "H mm", "H mm ss", "h mm ss tt", "h mm tt", "HH mm", "HH mm ss", "hh mm ss tt", "hh mm tt", "hh tt"
            };

            this.formatComboBox = bindable.Content.FindByName<SfComboBox>("formatComboBox");
            this.formatComboBox.ItemsSource = formats;
            this.formatComboBox.SelectedIndex = 1;
            this.formatComboBox.SelectionChanged += FormatComboBox_SelectionChanged;
        }

        /// <summary>
        /// Method for show header switch toggle changed.
        /// </summary>
        /// <param name="sender">Return the object.</param>
        /// <param name="e">The Event Arguments.</param>
        private void ShowHeaderSwitch_Toggled(object? sender, SwitchStateChangedEventArgs e)
        {
            if (this.timePicker != null && e.NewValue.HasValue)
            {
                if (e.NewValue.Value == true)
                {
                    this.timePicker.HeaderView.Height = 50;
                    this.timePicker.HeaderView.Text = "Select a time";
                }
                else if (e.NewValue.Value == false)
                {
                    this.timePicker.HeaderView.Height = 0;
                }
            }
        }

        /// <summary>
        /// Method for show column header switch toggle changed.
        /// </summary>
        /// <param name="sender">Return the object.</param>
        /// <param name="e">The Event Arguments.</param>
        private void ShowColumnHeaderSwitch_Toggled(object? sender, SwitchStateChangedEventArgs e)
        {
            if (this.timePicker != null && e.NewValue.HasValue)
            {
                if (e.NewValue.Value == true)
                {
                    this.timePicker.ColumnHeaderView = new TimePickerColumnHeaderView()
                    {
                        Height = 40,
                    };
                }
                if (e.NewValue.Value == false)
                {
                    this.timePicker.ColumnHeaderView = new TimePickerColumnHeaderView()
                    {
                        Height = 0,
                    };
                }
            }
        }

        /// <summary>
        /// Method for show footer switch toggle changed.
        /// </summary>
        /// <param name="sender">Return the object.</param>
        /// <param name="e">The Event Arguments.</param>
        private void ShowFooterSwitch_Toggled(object? sender, SwitchStateChangedEventArgs e)
        {
            if (this.timePicker != null && e.NewValue.HasValue)
            {
                if (e.NewValue.Value == true)
                {
                    this.timePicker.FooterView.Height = 40;
                }
                else if (e.NewValue.Value == false)
                {
                    this.timePicker.FooterView.Height = 0;
                }
            }
        }

        /// <summary>
        /// The format combo box selection changed event.
        /// </summary>
        /// <param name="sender">Return the object.</param>
        /// <param name="e">The Event Arguments.</param>
        private void FormatComboBox_SelectionChanged(object? sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
        {
            if (this.timePicker == null || e.AddedItems == null || this.formatComboBox == null)
            {
                return;
            }

            string? format = e.AddedItems[0].ToString();
            switch (format)
            {
                case "H mm":
                    this.timePicker.Format = PickerTimeFormat.H_mm;
                    break;

                case "H mm ss":
                    this.timePicker.Format = PickerTimeFormat.H_mm_ss;
                    break;

                case "h mm ss tt":
                    this.timePicker.Format = PickerTimeFormat.h_mm_ss_tt;
                    break;

                case "h mm tt":
                    this.timePicker.Format = PickerTimeFormat.h_mm_tt;
                    break;

                case "HH mm":
                    this.timePicker.Format = PickerTimeFormat.HH_mm;
                    break;

                case "HH mm ss":
                    this.timePicker.Format = PickerTimeFormat.HH_mm_ss;
                    break;

                case "hh mm ss tt":
                    this.timePicker.Format = PickerTimeFormat.hh_mm_ss_tt;
                    break;

                case "hh mm tt":
                    this.timePicker.Format = PickerTimeFormat.hh_mm_tt;
                    break;

                case "hh tt":
                    this.timePicker.Format = PickerTimeFormat.hh_tt;
                    break;
            }
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.showHeaderSwitch != null)
            {
                this.showHeaderSwitch.StateChanged -= ShowHeaderSwitch_Toggled;
                this.showHeaderSwitch = null;
            }

            if (this.showColumnHeaderSwitch != null)
            {
                this.showColumnHeaderSwitch.StateChanged -= ShowColumnHeaderSwitch_Toggled;
                this.showColumnHeaderSwitch = null;
            }

            if (this.showFooterSwitch != null)
            {
                this.showFooterSwitch.StateChanged -= ShowFooterSwitch_Toggled;
                this.showFooterSwitch = null;
            }
        }

        public GettingStartedBehavior()
        {
        }
    }
}