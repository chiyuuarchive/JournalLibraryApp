   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:JLWPFJLWPF  5   	   3clr-namespace:JLWPF.ComponentsJLWPF.Components  5   	       JLWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:JLWPF     5   	   5
componentsclr-namespace:JLWPF.Components     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanMinimize=�5   	    � AllowsTransparency$
 True��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��.05* �6   �� 5      .+�5   
      JLWPF.Components.Header  -   5          Name$ UIHeader��5   )      JLWPF.Components.Header   	MouseDown$ UIHeader_MouseDown��6;   $��0��6   6;   �� 5   
   -   5         ��Name$ ccMainWindow��5   &   $��1��6   ��6<   �� *CurrentViewModel+5      5      