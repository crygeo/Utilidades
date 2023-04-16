# Utilidades
## Creado por CryGeo.

Este proyecto tiene utilidades para usarlo como cualquier otro componente.
Por el momento solo cuenta con dos elemento.

- PickTime
- SelectElement

### PickTime
Como se nombre indica, elige un hora/tiempo, este te debuelve un TimeSpan, tiene la opcion de escojer la cantidad de dias.
Uso: El uso que yo le doy es selecionar un tiempo en que un mensaje se va a enviar, si yo quiero que el mensaje se envia cada 2 dias con 6 horas y 30 segundo, con este PickTime podria escojer la el tiempo.

### SelectElement
Con este componente podras mostrar una lista lo cual el usuario podra escojer cual desea. Tiene varios parametros visuales, que te gustaran mucho.


## Nota:

Para usarlo en tu proyecto agrega una referencia al la vista.

```
xmlns:util="clr-namespace:Utilidades;assembly=Utilidades"
```

y para usarlo
``` 
<util:PickTime/>
```

Para usar el estilo que trae el paquete.
En el archivo App.xaml, agrega el resouse dictionary.

```
<ResourceDictionary Source="pack://application:,,,/Utilidades;component/Style/StyleButton.xaml"/>
```

Ejemplo:

```
<Application x:Class="NombreDelProyecto.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                  <ResourceDictionary Source="pack://application:,,,/Utilidades;component/Style/StyleButton.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

Si quieres crear tu estilo para los botones, haz lo siguiente.

Crea tu archivo ResourceDictionary, y agregalo al proyecto, ejemplo:

```
<Application x:Class="NombreDelProyecto.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="NombreDelArchivo.xaml">
    <Application.Resources>
        
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="NombreDelArchivo.xaml" x:Name="CualquierNombre" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

PickTime tiene 5 botones que representa los estilos.

- Name = PickTimeButtonOpen
- Accion = Es el boton que abre el PickTime.

- Name = PickTImeButtonClose
- Accion = Es el boton que cierra el PickTime.

- Name = PickTImeButtonOk
- Accion = Es el boton que acepta los valores de PickTime.

- Name = PickTImeButtonNow
- Accion = Es el boton que escoje la hora actual el PickTime.

- Name = PickTimeElementos
- Accion = Los elementos que esta seleccion, y los que no.


Este es un ejemplo:
```
<Style TargetType="{x:Type Button}" x:Key="NameDelBotonAEditar">
    •••
</Style>
```

Para el caso de PickTimeElementos a su estructura se le agrega al mas.
El estilo fuera del DataTrigger, es el estilo de los elementos que no es el seleccionado, y el que esta dentro del DataTrigger es el seleccionado.

```
<Style TargetType="{x:Type Button}" x:Key="NameDelBotonAEditar">
    •••
    <Style.Triggers>
            <DataTrigger Binding="{Binding Position}" Value="0">
                •••
            </DataTrigger>
    </Style.Triggers>
</Style>
```

O si solo quieres cambiar los colores de algunos estilo puede copiar la clase y modificarlo a tu modo.
[Click](https://link-url-here.org)