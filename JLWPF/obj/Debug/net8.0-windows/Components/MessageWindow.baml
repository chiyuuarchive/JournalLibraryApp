   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:JLWPF.ComponentsJLWPF.Components  5   	   $    JLWPF.Components.MessageWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:JLWPF.Components     5   	   -   5          � Title$  MessageWindow��5   	   $	��150��6   $	��300��6,    � WindowStartupLocation$ CenterOwner=�68    � WindowStyle$
 None=�6\    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Styles.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.15* �6   �� 5      .+�5   
      JLWPF.Components.Header  -   5          Name$ UIHeader��5      �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5      �� -   5         ��Name$ 
txtMessage��5      $��Placeholder message��6,      
WindowText#��[  6G   �� 5      -   5        	 ��Name$	 
btnConfirm��5      $��Confirm��6)     WindowButtons#��[ 6;   6b   5      5      5      