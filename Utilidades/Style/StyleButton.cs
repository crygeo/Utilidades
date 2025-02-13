using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Utilidades.Style
{
    public partial class StyleButton
    {
        private Storyboard sbAnimacionEntrada;
        private Storyboard sbAnimacionSalida;

        private readonly double speed;
        private double sizeStart;
        private double sizeFinal;
        private Color buttonSalidaColor1;
        private Color buttonSalidaColor2;

        public StyleButton()
        {
            sbAnimacionEntrada = new Storyboard();
            sbAnimacionSalida = new Storyboard();

            sizeFinal = 3;
            sizeStart = 10;
            speed = 150;
        }

        private bool buttonEntradaBandera = true;
        private void buttonEntrada(object sender, MouseEventArgs e)
        {


            if (buttonEntradaBandera)
            {
                Button button = (Button)sender;
                var pt = (Path)button.Template.FindName("myPath", button);

                buttonSalidaColor1 = ((SolidColorBrush)((Brush)button.Background)).Color;
                buttonSalidaColor2 = ((SolidColorBrush)((Brush)button.Foreground)).Color;

                sbAnimacionEntrada = ClasesDeAnimaciones.sbPathAnimetedMargin(new Thickness(sizeStart), new Thickness(sizeFinal), speed, pt, sbAnimacionEntrada);

                sbAnimacionEntrada = ClasesDeAnimaciones.sbButtonBackground(
                    buttonSalidaColor1,
                    buttonSalidaColor2,
                    speed,
                    button,
                    sbAnimacionEntrada
                    );
                buttonEntradaBandera = false;
            }

            sbAnimacionEntrada.Begin();
        }

        private bool buttonSalidaBandera = true;
        private void buttonSalida(object sender, MouseEventArgs e)
        {

            if (buttonSalidaBandera)
            {
                Button button = (Button)sender;
                var pt = (Path)button.Template.FindName("myPath", button);

                sbAnimacionSalida = ClasesDeAnimaciones.sbPathAnimetedMargin(new Thickness(sizeFinal), new Thickness(sizeStart), speed, pt, sbAnimacionSalida);

                sbAnimacionSalida = ClasesDeAnimaciones.sbButtonBackground(buttonSalidaColor2,
                                                                           buttonSalidaColor1,
                                                                           speed,
                                                                           button,
                                                                           sbAnimacionSalida);

                buttonSalidaBandera = false;
            }
            sbAnimacionSalida.Begin();
        }
    }
}
