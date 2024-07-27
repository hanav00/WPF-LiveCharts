/*
 *   This is free and unencumbered software released into the public domain.

 *   Anyone is free to copy, modify, publish, use, compile, sell, or
 *   distribute this software, either in source code form or as a compiled
 *   binary, for any purpose, commercial or non-commercial, and by any
 *   means.

 *   For more information, please visit https://github.com/hanav00.
 */

using Chart.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Chart.ViewModel
{
    internal class MainViewModel
    {
        public SeriesCollection SeriesCollection { get; set; } = [];
        public string[] Labels { get; set; }

        public MainViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var dataPoints = BuildGymDiscountDataList();

            SeriesCollection = BuildSeriesCollection(dataPoints);
            Labels = Enumerable.Range(1, dataPoints.Max(dp => dp.RegistrationMonths)).Select(x => x.ToString()).ToArray();
        }

        private static SeriesCollection BuildSeriesCollection(ObservableCollection<GymDiscountData> dataPoints)
        {
            var seriesCollection = new SeriesCollection();
            var groupedData = dataPoints.GroupBy(dp => dp.Month);

            foreach (var group in groupedData) {
                var columnSeries = new ColumnSeries {
                    Title = $"{group.Key}월",
                    Values = new ChartValues<double>(new double[dataPoints.Max(dp => dp.RegistrationMonths) + 1]), // 배열 인덱스가 0부터 시작하므로, 최대값에 맞는 배열을 생성
                    MaxColumnWidth = 7,
                    DataLabels = true,
                    LabelPoint = point => point.Y > 0 ? point.Y.ToString() : string.Empty,
                };

                foreach (var dataPoint in group) {
                    columnSeries.Values[dataPoint.RegistrationMonths - 1] = dataPoint.Price; // 값이 3인 경우, 배열의 2번 인덱스에 값을 설정
                    if (dataPoint.IsSportWearFree) {
                        columnSeries.StrokeThickness = 1;
                        columnSeries.Stroke = Brushes.Black;
                    }
                }

                seriesCollection.Add(columnSeries);
            }

            return seriesCollection;
        }

        private static ObservableCollection<GymDiscountData> BuildGymDiscountDataList()
        {
            return
            [
                // 행사 month, 등록 개월 수, 가격, 운동복 여부
                new(2, 3, 12, false),
                new(2, 7, 21, false),
                new(2, 14, 27, false),
                new(3, 7, 21, true),
                new(3, 14, 26.6, true),
                new(4, 5, 15, true),
                new(4, 10, 21, true),
                new(4, 8, 20, false),
                new(4, 15, 24, false),
                new(5, 6, 24, false),
                new(5, 12, 29, false),
                new(5, 5, 19, false),
                new(5, 10, 26, false),
                new(5, 15, 32, false),
                new(6, 14, 32, false),
                new(6, 7, 25, false),
                new(6, 7, 25, true),
                new(6, 13, 28, false),
                new(7, 9, 27, true),
                new(7, 15, 32, false),
                new(7, 5, 23, true),
                new(7, 12, 29, false),
                new(7, 12, 38, true),
            ];
        }
    }
}
