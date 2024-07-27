﻿/*
 *   This is free and unencumbered software released into the public domain.

 *   Anyone is free to copy, modify, publish, use, compile, sell, or
 *   distribute this software, either in source code form or as a compiled
 *   binary, for any purpose, commercial or non-commercial, and by any
 *   means.

 *   For more information, please visit https://github.com/hanav00.
 */

using Chart.ViewModel;
using System.Windows;

namespace Chart
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}