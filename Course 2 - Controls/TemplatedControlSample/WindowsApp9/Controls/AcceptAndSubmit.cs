using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace WindowsApp9.Controls
{
    public sealed class AcceptAndSubmit : Control
    {
        public AcceptAndSubmit()
        {
            this.DefaultStyleKey = typeof(AcceptAndSubmit);
        }

        private const string PART_BUTTON_NAME = "SubmitButton";
        private Button PART_BUTTON = default(Button);

        private const string PART_CHECKBOX_NAME = "AcceptCheckBox";
        private CheckBox PART_CHECKBOX = default(CheckBox);

        protected override void OnApplyTemplate()
        {
            PART_BUTTON = GetTemplateChild<Button>(PART_BUTTON_NAME);
            PART_BUTTON.Click += (s, e) => Clicked?.Invoke(this, e);

            PART_CHECKBOX = GetTemplateChild<CheckBox>(PART_CHECKBOX_NAME);
            PART_CHECKBOX.Checked += (s, e) => Checked?.Invoke(this, e);
        }

        T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            var child = GetTemplateChild(name) as T;
            if (child == null)
                throw new NullReferenceException(name);
            return child;
        }

        public event EventHandler<RoutedEventArgs> Checked;
        public event EventHandler<RoutedEventArgs> Clicked;

        public string AcceptText { get { return (string)GetValue(AcceptTextProperty); } set { SetValue(AcceptTextProperty, value); } }
        public static readonly DependencyProperty AcceptTextProperty = DependencyProperty.Register(nameof(AcceptText), typeof(string), typeof(AcceptAndSubmit), new PropertyMetadata("Accept terms"));

        public string ButtonText { get { return (string)GetValue(ButtonTextProperty); } set { SetValue(ButtonTextProperty, value); } }
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register(nameof(ButtonText), typeof(string), typeof(AcceptAndSubmit), new PropertyMetadata("Submit"));

        public bool IsChecked { get { return (bool)GetValue(IsCheckedProperty); } set { SetValue(IsCheckedProperty, value); } }
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(nameof(IsChecked), typeof(bool), typeof(AcceptAndSubmit), new PropertyMetadata(false));

        public ICommand Command { get { return (ICommand)GetValue(CommandProperty); } set { SetValue(CommandProperty, value); } }
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(AcceptAndSubmit), new PropertyMetadata(null));
    }
}
;