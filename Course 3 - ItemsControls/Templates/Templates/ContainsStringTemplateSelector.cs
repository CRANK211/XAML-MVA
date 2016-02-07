using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Templates
{
    public class ContainsStringTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemDataTemplate { get; set; }

        public DataTemplate AlternateItemDataTemplate { get; set; }

        public string SearchString { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var customer = item as Customer;
            if (customer != null && customer.DisplayName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return AlternateItemDataTemplate;
            }
            return ItemDataTemplate;
        }
    }
}