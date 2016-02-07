using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App22.Controls
{
    public class MyStackPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var height = 0d;
            foreach (var child in Children)
            {
                #region Horizontal Alignment

                child.Measure(availableSize);

                #endregion  

                #region Horizontal Alignment

                //var element = child as FrameworkElement;
                //if (element != null
                //    && double.IsNaN(element.Width)
                //    && element.HorizontalAlignment == HorizontalAlignment.Stretch)
                //{
                //    element.Width = availableSize.Width;
                //    element.Measure(availableSize);
                //}
                //else
                //{
                //    child.Measure(availableSize);
                //}

                #endregion  

                height += child.DesiredSize.Height;
            }
            return new Size(availableSize.Width, height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var height = 0d;
            foreach (var child in Children)
            {
                if ((height + child.DesiredSize.Height) > finalSize.Height)
                    break;
                child.Arrange(new Rect(new Point(0, height), child.DesiredSize));
                height += child.DesiredSize.Height;
            }
            return base.ArrangeOverride(new Size(finalSize.Width, height));
        }
    }
}
