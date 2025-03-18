using System.Windows;

namespace WpfCore.Services
{
    /// <summary>
    /// The view model locator, which will wire up the view with a respective view model by obeying MVVM patter.
    /// </summary>
    public class ViewModelLocator
    {
        public static readonly DependencyProperty AutoWireViewModelProperty = DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoWireViewModelPropertyChanged));

        public static void SetAutoWireViewModel(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(AutoWireViewModelProperty, value);
        }

        public static object GetAutoWireViewModel(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(AutoWireViewModelProperty);
        }

        /// <summary>
        /// Gets the viewModel instance for a view using reflection and wires them up.
        /// </summary>
        /// <param name="dependencyObject"> The view or UI element on which AutoWireViewModel property is set. </param>
        /// <param name="e"> Event args. </param>
        private static void AutoWireViewModelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var view = dependencyObject;
            if (view != null && view is FrameworkElement element) 
            {
                var viewType = view.GetType();
                var viewFullName = viewType.Namespace + "." + viewType.Name;
                var viewModelFullName = GetViewModelName(viewFullName);

                var viewModelInstance = Activator.CreateInstance(viewType.Assembly.FullName, viewModelFullName);
                element.DataContext = viewModelInstance;
            }
        }

        private static string GetViewModelName(string input)
        {
            return input.Replace("View", "ViewModel");
        }
    }
}
