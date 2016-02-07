using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollectionViewSource
{
    public class AlternatingStyleSelector : StyleSelector
    {
        public Style ItemStyle { get; set; }

        public Style AlternateItemStyle { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var control = container as ListViewItem;
            var listView = ItemsControl.ItemsControlFromItemContainer(control) as ListView;
            if (listView != null && listView.IndexFromContainer(container)%2 == 0)
                return ItemStyle;

            return AlternateItemStyle;
        }
    }
}