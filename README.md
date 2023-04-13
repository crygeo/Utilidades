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
