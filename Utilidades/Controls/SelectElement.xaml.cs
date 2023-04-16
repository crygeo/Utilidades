using Utilidades.Suport;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Utilidades
{

    public partial class SelectElement : UserControl
    {
        #region DependencyProperty

        public static readonly DependencyProperty ListaProperty = DependencyProperty.Register(nameof(Lista),
                                                                                              typeof(List<string>),
                                                                                              typeof(SelectElement),
                                                                                              new PropertyMetadata(null, ListaPropertyChanged));


        public static readonly DependencyProperty NameListaProperty = DependencyProperty.Register(nameof(NameLista),
                                                                                                  typeof(string),
                                                                                                  typeof(SelectElement),
                                                                                                  new PropertyMetadata(null, NamePropertyChanged));


        public static readonly DependencyProperty MaxItemProperty = DependencyProperty.Register(nameof(MaxItem),
                                                                                                typeof(int),
                                                                                                typeof(SelectElement),
                                                                                                new PropertyMetadata(0, MaxItemPropertyChanged));


        public static readonly DependencyProperty PositionSelectProperty = DependencyProperty.Register(nameof(PositionSelect),
                                                                                                       typeof(int),
                                                                                                       typeof(SelectElement),
                                                                                                       new PropertyMetadata(0, PositionSelectPropertyChanged));


        public static readonly DependencyProperty SelectIndexProperty = DependencyProperty.Register(nameof(SelectIndex),
                                                                                                    typeof(int),
                                                                                                    typeof(SelectElement),
                                                                                                    new FrameworkPropertyMetadata(0,
                                                                                                                                  FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                                                  SelectIndexPropertyChanged));
        #endregion


        #region Propertys
        public List<string> Lista
        {
            get => (List<string>)GetValue(ListaProperty);
            set { SetValue(ListaProperty, value); SelectElementSp.Lista = value; }
        }

        internal string NameLista
        {
            get => (string)GetValue(NameListaProperty);
            set { SetValue(NameListaProperty, value); SelectElementSp.NameLista = value; }
        }

        public int MaxItem
        {
            get => (int)GetValue(MaxItemProperty);
            set { SetValue(MaxItemProperty, value); SelectElementSp.MaxItem = value; }

        }


        public int PositionSelect
        {
            get => (int)GetValue(PositionSelectProperty);
            set { SetValue(PositionSelectProperty, value); SelectElementSp.PositionSelect = value; }
        }

        public int SelectIndex
        {
            get => (int)GetValue(SelectIndexProperty);
            set { SetValue(SelectIndexProperty, value); SelectElementSp.SelectIndex = value; }
        }

        #endregion

        public SelectElementSuport SelectElementSp { get; set; }

        public SelectElement()
        {
            SelectElementSp = new SelectElementSuport();

            InitializeComponent();

        }



        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            if (e.Delta > 0)
            {
                SelectElementSp.UpListe();
            }

            if (e.Delta < 0)
            {
                SelectElementSp.DownListe();
            }

            SelectIndex = SelectElementSp.Update();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dc = ((sender as Button).DataContext as ModelItemSelect);

            bool down = (dc.Position > 0);
            int cants = down ? dc.Position : dc.Position * -1;

            //Console.WriteLine("up: " + up + "  position: " + dc.Position + "  cants:" + cants);
            for (int i = 0; i < cants; i++)
            {

                if (down)
                {
                    SelectElementSp.DownListe();
                }
                else
                {
                    SelectElementSp.UpListe();
                }
            }

            SelectIndex = SelectElementSp.Update();
        }










        private static void ListaPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectElement selectElement)
            {
                List<string> newValue = (List<string>)e.NewValue;
                selectElement.Lista = newValue;
                selectElement.SelectElementSp.Lista = newValue;
                selectElement.SelectElementSp.Update();
            }
        }
        private static void NamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectElement selectElement)
            {
                string newValue = (string)e.NewValue;
                selectElement.NameLista = newValue;
                selectElement.SelectElementSp.NameLista = newValue;
                selectElement.SelectElementSp.Update();
            }
        }
        private static void MaxItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectElement selectElement)
            {
                int newValue = (int)e.NewValue;
                selectElement.MaxItem = newValue;
                selectElement.SelectElementSp.MaxItem = newValue;
                selectElement.SelectElementSp.Update();
            }
        }
        private static void PositionSelectPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectElement selectElement)
            {
                int newValue = (int)e.NewValue;
                selectElement.PositionSelect = newValue;
                selectElement.SelectElementSp.PositionSelect = newValue;
                selectElement.SelectElementSp.Update();
            }
        }
        private static void SelectIndexPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectElement selectElement)
            {
                int newValue = (int)e.NewValue;
                selectElement.SelectIndex = newValue;
                selectElement.SelectElementSp.SelectIndex = newValue;
                selectElement.SelectElementSp.Update();
            }
        }

    }
}
