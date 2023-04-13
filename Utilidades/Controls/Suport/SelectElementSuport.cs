using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Controls.Suport
{
    public class SelectElementSuport : INotifyPropertyChanged
    {

        private List<string> lista;
        public List<string> Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                updateAtAtribut();

            }
        }

        private string nameLista;
        public string NameLista
        {
            get { return nameLista; }
            set
            {
                nameLista = value;
                OnPropertyChanged(nameof(NameLista));
            }
        }

        private int maxItem;
        public int MaxItem
        {
            get { return maxItem; }
            set
            {
                maxItem = value;
                updateAtAtribut();
            }
        }

        private int positionSelect;
        public int PositionSelect
        {
            get { return positionSelect; }
            set
            {
                positionSelect = value;
                updateAtAtribut();
            }

        }

        private int cantNegative;
        private int cantPositive;

        private int selectIndex;
        public int SelectIndex
        {
            get
            {
                return selectIndex;
            }
            set
            {
                if (value == selectIndex) return;
                if (value >= lista.Count) return;
                if (value <=0) return;
                selectIndex = value;
                MoverElementos(value);
                Update();
                OnPropertyChanged(nameof(SelectIndex));
            }
        }

        public string Select
        {
            get
            {
                return listaDesorganizada[0].Element;
            }
        }



        private ObservableCollection<ModelItemSelect> listaView;
        public ObservableCollection<ModelItemSelect> ListaView
        {
            get { return listaView; }
            set
            {
                listaView = value;
                OnPropertyChanged(nameof(ListaView));
            }
        }

        private List<ModelItemSelect> listaDesorganizada;
        public List<ModelItemSelect> ListaDesorganizada
        {
            get { return listaDesorganizada; }
            set { listaDesorganizada = value; }
        }

        private List<ModelItemSelect> listaDesorganizadaOriginal;
        public SelectElementSuport()
        {
            lista = new List<string> { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            nameLista = "Dias";
            maxItem = 5;
            positionSelect = 1;
            listaView = new ObservableCollection<ModelItemSelect>();

            listaDesorganizada = new List<ModelItemSelect>();
            listaDesorganizadaOriginal = new List<ModelItemSelect>();

            updateAtAtribut();
            SelectIndex = Update();
        }

        private void updateAtAtribut()
        {
            listaView.Clear();
            listaDesorganizada.Clear();
            listaDesorganizadaOriginal.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                var item = new ModelItemSelect()
                {
                    Element = lista[i],
                    Index = i,
                };

                if (maxItem < i) { item.Position = i; }

                listaDesorganizada.Add(item);
                listaDesorganizadaOriginal.Add(item);
            }

            cantNegative = positionSelect - 1;
            cantPositive = maxItem - positionSelect;
        }


        private void MoverElementos(int index)
        {
            if(index == 0) { listaDesorganizada = listaDesorganizadaOriginal; return; }
            var temp = listaDesorganizadaOriginal;
            var secction1 = temp.GetRange(0, index);
            var secction2 = temp.GetRange(index , temp.Count - index);

            listaDesorganizada.Clear();
            listaDesorganizada.AddRange(secction2);
            listaDesorganizada.AddRange(secction1);

        }







        /// <summary>
        /// Sube un elemento en la lista.
        /// </summary>
        public void UpListe()
        {
            var temp = listaDesorganizada[listaDesorganizada.Count - 1];
            listaDesorganizada.RemoveAt(listaDesorganizada.Count - 1);
            listaDesorganizada.Insert(0, temp);
        }

        /// <summary>
        /// Baja un elemento en la lista.
        /// </summary>
        public void DownListe()
        {
            var temp = listaDesorganizada[0];
            listaDesorganizada.RemoveAt(0);
            listaDesorganizada.Add(temp);
        }

        /// <summary>
        /// Actualiza el ListaView para la vista.
        /// </summary>
        public int Update()
        {
            listaView.Clear();
            for (int i = 0; i < maxItem; i++)
            {
                ModelItemSelect temp;
                int index = 0;

                //Obtiene el indixe para los ultimos x cantidades negativos que van antes del la posicion inicial
                if (i <= cantNegative - 1)
                {
                    index = (listaDesorganizada.Count - 1 - cantNegative) + 1 + i;

                }
                else if (i >= (positionSelect - 1)) //Obtiene el indixe de la posicion inicial y los que sigue asta completar
                {
                    index = i - positionSelect + 1;
                }

                temp = listaDesorganizada[index];

                temp.Position = index;
                //if(index == 0) 
                //{
                //    SelectIndex = temp.Index; 
                //}

                listaView.Add(temp);

            }
            selectIndex = listaDesorganizada[0].Index;
            return listaDesorganizada[0].Index;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class ModelItemSelect : INotifyPropertyChanged
    {

        private string element = "";
        public string Element
        {
            get { return element; }
            set
            {
                element = value;
                OnPropertyChanged(nameof(Element));
            }
        }
        public int Index { get; set; }
        public int Position { get; set; }


        //I Notify
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
