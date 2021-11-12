﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows;

namespace WPFUI.Controls
{
    /// <summary>
    /// Displays a large card with a slightly transparent background and two action buttons.
    /// </summary>
    public class Dialog : System.Windows.Controls.ContentControl
    {
        /// <summary>
        /// Property for <see cref="Show"/>.
        /// </summary>
        public static readonly DependencyProperty ShowProperty = DependencyProperty.Register("Show",
            typeof(bool), typeof(Dialog), new PropertyMetadata(false));

        /// <summary>
        /// Property for <see cref="ButtonLeftCommand"/>.
        /// </summary>
        public static readonly DependencyProperty ButtonLeftCommandProperty =
            DependencyProperty.Register("ButtonLeftCommand",
                typeof(Common.RelayCommand), typeof(Dialog), new PropertyMetadata(null));

        /// <summary>
        /// Property for <see cref="ButtonRightCommand"/>.
        /// </summary>
        public static readonly DependencyProperty ButtonRightCommandProperty =
            DependencyProperty.Register("ButtonRightCommand",
                typeof(Common.RelayCommand), typeof(Dialog), new PropertyMetadata(null));

        /// <summary>
        /// Triggered after clicking action button.
        /// </summary>
        public event RoutedEventHandler Click;

        /// <summary>
        /// Gets or sets information whether the dialog should be displayed.
        /// </summary>
        public bool Show
        {
            get => (bool)GetValue(ShowProperty);
            set => SetValue(ShowProperty, value);
        }

        /// <summary>
        /// Gets the <see cref="Common.RelayCommand"/> triggered after clicking left action button.
        /// </summary>
        public Common.RelayCommand ButtonLeftCommand => (Common.RelayCommand)GetValue(ButtonLeftCommandProperty);

        /// <summary>
        /// Gets the <see cref="Common.RelayCommand"/> triggered after clicking right action button.
        /// </summary>
        public Common.RelayCommand ButtonRightCommand => (Common.RelayCommand)GetValue(ButtonRightCommandProperty);

        /// <summary>
        /// Creates new instance and sets default <see cref="ButtonLeftCommand"/> and <see cref="ButtonRightCommand"/>.
        /// </summary>
        public Dialog()
        {
            SetValue(ButtonLeftCommandProperty,
                new Common.RelayCommand(o => Click?.Invoke(this, new RoutedEventArgs { })));
            SetValue(ButtonRightCommandProperty, new Common.RelayCommand(o => SetValue(ShowProperty, false)));
        }
    }
}