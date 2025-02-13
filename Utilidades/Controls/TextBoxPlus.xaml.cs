using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Utilidades.Controls
{
    /// <summary>
    /// Lógica de interacción para TextBoxPlus.xaml
    /// </summary>
    public partial class TextBoxPlus : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBoxPlus), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TextVerticalAlignmentProperty = DependencyProperty.Register(nameof(TextVerticalAlignment), typeof(VerticalAlignment), typeof(TextBoxPlus), new PropertyMetadata(VerticalAlignment.Center));
        public static readonly DependencyProperty TextHorizontalAlignmentProperty = DependencyProperty.Register(nameof(TextHorizontalAlignment), typeof(HorizontalAlignment), typeof(TextBoxPlus), new PropertyMetadata(HorizontalAlignment.Left));

        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(TextBoxPlus), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty PlaceholderForegroundProperty = DependencyProperty.Register(nameof(PlaceholderForeground), typeof(SolidColorBrush), typeof(TextBoxPlus), new PropertyMetadata(Brushes.Gray));
        public static readonly DependencyProperty PlaceholderFontSizeProperty = DependencyProperty.Register(nameof(PlaceholderFontSize), typeof(int), typeof(TextBoxPlus), new PropertyMetadata(12));
        public static readonly DependencyProperty PlaceholderVerticalAlignmentProperty = DependencyProperty.Register(nameof(PlaceholderVerticalAlignment), typeof(VerticalAlignment), typeof(TextBoxPlus), new PropertyMetadata(VerticalAlignment.Center));
        public static readonly DependencyProperty PlaceholderHorizontalAlignmentProperty = DependencyProperty.Register(nameof(PlaceholderHorizontalAlignment), typeof(HorizontalAlignment), typeof(TextBoxPlus), new PropertyMetadata(HorizontalAlignment.Left));


        public static readonly DependencyProperty CaretBrushProperty = DependencyProperty.Register(nameof(CaretBrush), typeof(SolidColorBrush), typeof(TextBoxPlus), new PropertyMetadata(Brushes.White));
        public static readonly DependencyProperty IsFocusedBoxProperty = DependencyProperty.Register(nameof(IsFocusedBox), typeof(bool), typeof(TextBoxPlus), new PropertyMetadata(false));


        #region Text
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public VerticalAlignment TextVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(TextVerticalAlignmentProperty);
            set => SetValue(TextVerticalAlignmentProperty, value);
        }
        public HorizontalAlignment TextHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
            set => SetValue(TextHorizontalAlignmentProperty, value);
        }
        #endregion
        #region Placeholder
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public SolidColorBrush PlaceholderForeground
        {
            get => (SolidColorBrush)GetValue(PlaceholderForegroundProperty);
            set => SetValue(PlaceholderForegroundProperty, value);
        }
        public int PlaceholderFontSize
        {
            get => (int)GetValue(PlaceholderFontSizeProperty);
            set => SetValue(PlaceholderFontSizeProperty, value);
        }
        public VerticalAlignment PlaceholderVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(PlaceholderVerticalAlignmentProperty);
            set => SetValue(PlaceholderVerticalAlignmentProperty, value);
        }
        public HorizontalAlignment PlaceholderHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(PlaceholderHorizontalAlignmentProperty);
            set => SetValue(PlaceholderHorizontalAlignmentProperty, value);
        }
        #endregion

        public SolidColorBrush CaretBrush
        {
            get => (SolidColorBrush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }
        public bool IsFocusedBox
        {
            get { return (bool)GetValue(IsFocusedBoxProperty); }
            set { SetValue(IsFocusedBoxProperty, value); }
        }



        public TextBoxPlus()
        {
            DataContext = this;
            InitializeComponent();

            this.MouseDown += (s, e) => MainTextBox.Focus();

            MainTextBox.TextChanged += (s, e) => UpdatePlaceholderVisibility();
            MainTextBox.GotFocus += (s, e) => IsFocusedBox = true;
            MainTextBox.LostFocus += (s, e) => IsFocusedBox = false;

            // Initialize visibility of placeholder
            UpdatePlaceholderVisibility();
        }



        private void UpdatePlaceholderVisibility()
        {
            if (string.IsNullOrEmpty(MainTextBox.Text))
            {
                PlaceholderText.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderText.Visibility = Visibility.Collapsed;
            }
        }
        
    }
}
