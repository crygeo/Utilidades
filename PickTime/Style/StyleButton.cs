using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CryGeo.Style
{
    public partial class StyleButton
    {
        private Storyboard sbAnimacionEntrada;
        private Storyboard sbAnimacionSalida;

        private double speed;
        private double sizeStart;
        private double sizeFinal;
        private Color buttonSalidaColor1;
        private Color buttonSalidaColor2;

        public StyleButton()
        {
            sbAnimacionEntrada = new Storyboard();
            sbAnimacionSalida = new Storyboard();

            speed = 150;
            sizeStart = 40;
            sizeFinal = 50;
            buttonSalidaColor1 = (Color)ColorConverter.ConvertFromString("#000");
            buttonSalidaColor2 = (Color)ColorConverter.ConvertFromString("#fff");
        }

        private bool buttonEntradaBandera = true;
        private void buttonEntrada(object sender, MouseEventArgs e)
        {
            if (buttonEntradaBandera)
            {
                Button button = (Button)sender;
                sbAnimacionEntrada = ClasesDeAnimaciones.sbButtonAnimetedSize(sizeStart, sizeFinal, sizeStart, sizeFinal, speed, button, sbAnimacionEntrada);
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
                Button? button = (Button)sender;
                sbAnimacionSalida = ClasesDeAnimaciones.sbButtonAnimetedSize(sizeFinal, sizeStart, sizeFinal, sizeStart, speed, button, sbAnimacionSalida);
                sbAnimacionSalida = ClasesDeAnimaciones.sbButtonBackground(
                    buttonSalidaColor2,
                    buttonSalidaColor1,
                    speed,
                    button,
                    sbAnimacionSalida
                    );

                buttonSalidaBandera = false;
            }
            sbAnimacionSalida.Begin();
        }
    }
}
