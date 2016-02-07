using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ColumnPanelDemo.Controls
{
    public class ColumnPanel : Panel
    {
        public static readonly DependencyProperty ColumnWidthProperty =
            DependencyProperty.Register(nameof(ColumnWidth), typeof (double), typeof (ColumnPanel),
                new PropertyMetadata(3, (o, args) => (o as ColumnPanel).InvalidateMeasure()));

        private int _columnCount;

        public double ColumnWidth
        {
            get { return (double) GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            _columnCount = (int) Math.Floor(availableSize.Width/ColumnWidth);
            var columnHeights = new double[_columnCount];

            foreach (var child in Children)
            {
                var columnIndex = Array.IndexOf(columnHeights, columnHeights.Min());
                child.Measure(new Size(ColumnWidth, availableSize.Height));
                var elementSize = child.DesiredSize;
                columnHeights[columnIndex] += elementSize.Height;
            }

            return new Size(availableSize.Width, columnHeights.Max());
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var columnWidth = finalSize.Width/_columnCount;
            var columnHeights = new double[_columnCount];

            foreach (var child in Children)
            {
                var columnIndex = Array.IndexOf(columnHeights, columnHeights.Min());
                var bounds = new Rect(new Point(columnWidth*columnIndex, columnHeights[columnIndex]), child.DesiredSize);
                child.Arrange(bounds);
                columnHeights[columnIndex] += child.DesiredSize.Height;
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}