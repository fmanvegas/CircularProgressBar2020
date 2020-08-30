using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CircularProgressBar2020
{
    public class GuageClass : UserControl
    {
        public GuageClass()
        {
        }
        protected static readonly DependencyProperty ColorProperty =
               DependencyProperty.Register("ColorProperty", typeof(Color), typeof(GuageClass), new PropertyMetadata(Colors.Red));

        // Using a DependencyProperty as the backing store for Brush.  This enables animation, styling, binding, etc...
        protected static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("MyBrush", typeof(Brush), typeof(GuageClass), new PropertyMetadata(Brushes.Red));


        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        protected static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(int), typeof(GuageClass), new PropertyMetadata(-90));



        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        protected static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(GuageClass), new PropertyMetadata(0, valueChangedCallback));


        public Brush MyBrush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        public int Angle
        {
            get { return (int)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void valueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GuageClass guage)
            {
                var p = ((double)guage.Value / 100 * 180);
                guage.Angle = (int)p - 90;
            }
        }
    }
}
