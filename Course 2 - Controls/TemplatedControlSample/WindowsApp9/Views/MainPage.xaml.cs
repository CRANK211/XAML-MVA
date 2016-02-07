using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsApp9.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class MyItem
    {
        public int RowSpan { get; set; }
        public int ColSpan { get; set; }
    }

    public class MyListView : ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var model = item as MyItem;
            try
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, model.ColSpan);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, model.RowSpan);
            }
            catch
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
            }
            finally
            {
                element.SetValue(VerticalContentAlignmentProperty, VerticalAlignment.Stretch);
                element.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch);
                base.PrepareContainerForItemOverride(element, item);
            }
        }
    }
}