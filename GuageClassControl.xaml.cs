using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CircularProgressBar2020
{
    /// <summary>
    /// Interaction logic for GuageClassControl.xaml
    /// </summary>
    public partial class GuageClassControl : UserControl, INotifyPropertyChanged
    {
        public Brush MyBrush
        {
            get { return (Brush)GetValue(MyBrushProperty); }
            set { SetValue(MyBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyBrushProperty =
            DependencyProperty.Register("MyBrush", typeof(Brush), typeof(GuageClassControl), new PropertyMetadata(Brushes.Blue));


        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(int), typeof(GuageClass), new PropertyMetadata(-90));


        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), 
                typeof(GuageClass), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, valueChange));

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private static void valueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Here");
        }

      

        public int Angle
        {
            get { return (int)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); OnPropertyChanged(); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); OnPropertyChanged(); update(); }
        }

        private void update()
        {
            var p = ((double)Value / 100 * 180);
            Angle = (int)p - 90;
        }

      
        public GuageClassControl()
        {
            InitializeComponent();
        }
    }
}
