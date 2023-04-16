using System;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Shapes;

namespace Utilidades.Style
{
    internal class ClasesDeAnimaciones
    {
        public static ObjectAnimationUsingKeyFrames animateGiro(double To, double From, double Speed, double SaltoFotrograma = 1)
        {
            var anim = new ObjectAnimationUsingKeyFrames();

            double Diferencia = (From - To);

            double va = 1;

            if (Diferencia < 0) { Diferencia *= -1; va = -1; }

            for (double i = 1; i <= Diferencia; i += SaltoFotrograma)
            {
                //    < Button.RenderTransform >
                //    < TransformGroup >
                //        < ScaleTransform />
                //        < SkewTransform />
                //        < RotateTransform Angle = "45" />
                //        < TranslateTransform />
                //    </ TransformGroup >
                //</ Button.RenderTransform >

                RotateTransform myRotateTransform = new RotateTransform();
                myRotateTransform.Angle = To + (i * va);

                TransformGroup myTransformGroup = new TransformGroup();
                myTransformGroup.Children.Add(myRotateTransform);


                ObjectKeyFrame temp = new DiscreteObjectKeyFrame
                {
                    Value = myTransformGroup,
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(Speed * i))
                };

                //Console.WriteLine($"CorneRadius: {To + (i*va) }, KeyTime: {TimeSpan.FromMilliseconds(Speed * i).ToString()}");

                anim.KeyFrames.Add(temp);
            }

            return anim;
        }

        public static ObjectAnimationUsingKeyFrames animatedCornerRadius(double To, double From, double Speed, double SaltoFotrograma = 1)
        {
            var anim = new ObjectAnimationUsingKeyFrames();

            double Diferencia = (From - To);

            double va = 1;

            if (Diferencia < 0) { Diferencia *= -1; va = -1; }

            for (double i = 1; i <= Diferencia; i += SaltoFotrograma)
            {
                ObjectKeyFrame temp = new DiscreteObjectKeyFrame
                {
                    Value = new CornerRadius(To + (i * va)),
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(Speed * i))
                };

                //Console.WriteLine($"CorneRadius: {To + (i*va) }, KeyTime: {TimeSpan.FromMilliseconds(Speed * i).ToString()}");

                anim.KeyFrames.Add(temp);
            }

            return anim;
        }

        //public static ObjectAnimationUsingKeyFrames animetedSize(double fromX, double toX, double fromY, double toY, double speed, double saltoFotograma = 1)
        //{
        //    var anim = new ObjectAnimationUsingKeyFrames();

        //    double diferenciaX = (toX - fromX);
        //    double diferenciaY = (toY - fromY);

        //    double distanciaMaxima = Math.Max(Math.Abs(diferenciaX), Math.Abs(diferenciaY));
        //    int fotogramasTotales = (int)(distanciaMaxima / saltoFotograma);


        //    for (int i = 0; i <= fotogramasTotales; i++)
        //    {
        //        double progress = (double)i / fotogramasTotales;
        //        double x = fromX + diferenciaX * progress;
        //        double y = fromY + diferenciaY * progress;

        //        ObjectKeyFrame temp = new DiscreteObjectKeyFrame
        //        {
        //            Value = new ScaleTransform(x, y),
        //            KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(speed * i))
        //        };


        //        anim.KeyFrames.Add(temp);
        //    }

        //    return anim;
        //}

        //public Storyboard storyboardButtonanimetedSize(double fromX, double toX, double fromY, double toY, double speed, double saltoFotograma = 1, Button button)
        //{
        //    var sb = new Storyboard();
        //    var animacion = animetedSize(fromX, toX, fromY, toY, speed, saltoFotograma);

        //    sb.Children.Add(animacion);
        //    Storyboard.SetTarget(animacion, button);
        //    Storyboard.SetTargetProperty(animacion, new PropertyPath("CornerRadius"));
        //}

        public static Storyboard sbButtonAnimetedSize(double fromX, double toX, double fromY, double toY, double duration, Button button, Storyboard sb)
        {
            var duracion = new Duration(TimeSpan.FromMilliseconds(duration));

            var animButtonWidth = new DoubleAnimation(fromX, toX, duracion);
            var animButtonHeight = new DoubleAnimation(fromY, toY, duracion);

            sb.Children.Add(animButtonWidth);
            Storyboard.SetTarget(animButtonWidth, button);
            Storyboard.SetTargetProperty(animButtonWidth, new PropertyPath("Width"));

            sb.Children.Add(animButtonHeight);
            Storyboard.SetTarget(animButtonHeight, button);
            Storyboard.SetTargetProperty(animButtonHeight, new PropertyPath("Height"));

            return sb;
        }
        public static Storyboard sbPathAnimetedSize(double fromX, double toX, double fromY, double toY, double duration, Path path, Storyboard sb)
        {
            var duracion = new Duration(TimeSpan.FromMilliseconds(duration));

            var animButtonWidth = new DoubleAnimation(fromX, toX, duracion);
            var animButtonHeight = new DoubleAnimation(fromY, toY, duracion);

            sb.Children.Add(animButtonWidth);
            Storyboard.SetTarget(animButtonWidth, path);
            Storyboard.SetTargetProperty(animButtonWidth, new PropertyPath("Width"));

            sb.Children.Add(animButtonHeight);
            Storyboard.SetTarget(animButtonHeight, path);
            Storyboard.SetTargetProperty(animButtonHeight, new PropertyPath("Height"));

            return sb;
        }

        public static Storyboard sbButtonBackground(System.Windows.Media.Color fromColor, System.Windows.Media.Color toColor, double duration, Button button, Storyboard sb)
        {
            var duracion = new Duration(TimeSpan.FromMilliseconds(duration));

            ColorAnimation animaColor = new ColorAnimation
            {
                From = fromColor,
                To = toColor,
                Duration = duracion
            };

            sb.Children.Add(animaColor);
            Storyboard.SetTarget(animaColor, button);
            Storyboard.SetTargetProperty(animaColor, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

            return sb;
        }
    }
}
