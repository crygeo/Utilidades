using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Controls.Suport
{
    public class PickTimeSuport : INotifyPropertyChanged
    {

        public string TextD { get; set; }
        public string TextH { get; set; }
        public string TextM { get; set; }
        public string TextS { get; set; }

        public PickTimeModelD? ListaD { get; set; }
        public PickTimeModelD? ListaH { get; set; }
        public PickTimeModelD? ListaM { get; set; }
        public PickTimeModelD? ListaS { get; set; }


        private TimeSpan time;
        private bool days;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                if (time == value) return;
                time = value;
                if (ListaD != null && ListaH != null && ListaM != null && ListaS != null)
                {
                    ListaD.IndexSelect = time.Days;
                    ListaH.IndexSelect = time.Hours;
                    ListaM.IndexSelect = time.Minutes;
                    ListaS.IndexSelect = time.Seconds;
                }

                OnTimeChanged();
                OnPropertyChanged(nameof(Time));
            }
        }

        public bool Days
        {
            get { return days; }
            set
            {
                if (ListaD == null) return;
                days = value;
                ListaD.Visible = days ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged(nameof(Days));
            }
        }

        public PickTimeSuport()
        {
            days = false;

            TextD = "Dias";
            TextH = "Horas";
            TextM = "Minut";
            TextS = "Segun";

            #region crear Listas
            var dias = new List<string>();
            for (int i = 0; i <= 99; i++)
            {
                dias.Add(i.ToString());
            }

            var horas = new List<string>();
            for (int i = 0; i <= 23; i++)
            {
                horas.Add(i.ToString());
            }

            var minutos = new List<string>();
            for (int i = 0; i <= 59; i++)
            {
                minutos.Add(i.ToString());
            }

            var segundos = new List<string>();
            for (int i = 0; i <= 59; i++)
            {
                segundos.Add(i.ToString());
            }
            #endregion

            #region crear Listas Model
            ListaD = new PickTimeModelD()
            {
                Lista = dias,
                NameLista = TextD,
                IndexSelect = 0,
                Visible = days ? Visibility.Visible : Visibility.Collapsed
            };
            ListaH = new PickTimeModelD()
            {
                Lista = horas,
                NameLista = TextH,
                IndexSelect = 0,
                Visible = Visibility.Visible
            };
            ListaM = new PickTimeModelD()
            {
                Lista = minutos,
                NameLista = TextM,
                IndexSelect = 0,
                Visible = Visibility.Visible
            };
            ListaS = new PickTimeModelD()
            {
                Lista = segundos,
                NameLista = TextS,
                IndexSelect = 0,
                Visible = Visibility.Visible
            };
            #endregion

            #region eventos
            ListaD.IndexSelectChanged += ListaD_IndexSelectChanged;
            ListaH.IndexSelectChanged += ListaH_IndexSelectChanged;
            ListaM.IndexSelectChanged += ListaM_IndexSelectChanged;
            ListaS.IndexSelectChanged += ListaS_IndexSelectChanged;
            #endregion

            TimeChanged = delegate { };
        }



        private void ListaD_IndexSelectChanged(object? sender, EventArgs e)
        {
            if (sender is PickTimeModelD)
            {
                var item = (PickTimeModelD)sender;
                int index = item.IndexSelect;
                Time = new TimeSpan(index, time.Hours, time.Minutes, time.Seconds);
            }
        }
        private void ListaH_IndexSelectChanged(object? sender, EventArgs e)
        {
            if (sender is PickTimeModelD)
            {
                var item = (PickTimeModelD)sender;
                int index = item.IndexSelect;
                Time = new TimeSpan(time.Days, index, time.Minutes, time.Seconds);
            }
        }
        private void ListaM_IndexSelectChanged(object? sender, EventArgs e)
        {
            if (sender is PickTimeModelD)
            {
                var item = (PickTimeModelD)sender;
                int index = item.IndexSelect;
                Time = new TimeSpan(time.Days, time.Hours, index, time.Seconds);
            }
        }
        private void ListaS_IndexSelectChanged(object? sender, EventArgs e)
        {
            if (sender is PickTimeModelD)
            {
                var item = (PickTimeModelD)sender;
                int index = item.IndexSelect;
                Time = new TimeSpan(time.Days, time.Hours, time.Minutes, index);
            }
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public event EventHandler TimeChanged;
        private void OnTimeChanged()
        {
            TimeChanged?.Invoke(Time, EventArgs.Empty);
        }

    }
    public class PickTimeModelD : INotifyPropertyChanged
    {
        private int indexSelect;
        private Visibility visible;

        public string? NameLista { get; set; }
        public List<string>? Lista { get; set; }

        public int IndexSelect
        {
            get { return indexSelect; }
            set
            {
                indexSelect = value;
                OnIndexSelectChanged();
                OnPropertyChanged(nameof(IndexSelect));
            }
        }
        public Visibility Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler IndexSelectChanged;

        private void OnIndexSelectChanged()
        {
            IndexSelectChanged?.Invoke(this, EventArgs.Empty);
        }

        public PickTimeModelD()
        {
            IndexSelectChanged = delegate { };
        }
    }

}
