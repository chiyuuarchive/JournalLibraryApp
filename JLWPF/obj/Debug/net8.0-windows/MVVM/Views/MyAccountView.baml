   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:JLWPF.MVVM.ViewsJLWPF.MVVM.Views  5      $    JLWPF.MVVM.Views.MyAccountView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:JLWPF.MVVM.Views     5      -   5          � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../../Styles/Styles.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.25* �6   �� 5      $	��.1* �6   �� 5      �� 5      $	��.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Account Details��6   $��26(�6+   
����p��$��10q�6T   �� 5!   
   -   5         ��Name$ 	btnReturn��5!   "   $��1��6      ButtonsWithIcons#��[  65   $��Right=�6_   .��5"      �� .+�5#      �� $��../../Images/back.png��6   $��25��67   �� 5$      $��Return��6   5%      5&      �� 5)   
   $��2��6   $
��Left=�6"   $��5q�6=   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   .+�5+      �� $��../../Images/user.png��6     InputFieldHeaderIcons#��[ 67   �� 5,      $��User information��6     InputFieldHeaders#��[ 64   5-      �� 5/      $
��10 0q�6   .+�50      �� $��
First Name��6   $
��Bold"�6.   �� 51      -   5         ��Name$ txtFirstName��51      $��First Name (e.g. John)��60     InputFields#��[ 6N   �� 52      $��	Last Name��6   $
��Bold"�6-   �� 53      -   5        $ txtLastName��53      $��Last Name (e.g. Doe)��6/   #��[ 6K   54      55      �� 57   
   $��2��6   $��1��6#   $
��Left=�63   .+�58      �� $ 
Horizontal=�6   $
��Left=�62   .+�59      �� $��../../Images/user.png��6   #��[ 67   �� 5:      $��Login information ��6   #��[ 66   5;      �� 5=      $��Email��6   $
��Bold"�6%   $
��10 0q�67   � 5?       5@      �� 5A      $
��.15* �6'   �� 5B      .+�5D      �� $��../../Images/email.png��6     InputFieldIcons#��[ 68   �� 5E      -   5        $ txtEmail��5E   *   $��1��6   $%��Email (e.g. john_doe@gmail.com)��6<   $��Right=�6c   #��[ 6   5F      �� 5H      $��Password��6   $
��Bold"�6(   $
��10 0q�6:   � 5J       5K      �� 5L      $
��.15* �6'   �� 5M      .+�5O      �� $��../../Images/password.png��6   #��[ 6;   �� 5P      -   5        $ txtPassword��5P   *   $��1��6   $��Password (e.g. Abc123)��6?   $��Right=�6^   #��[ 6z   5Q      5R      �� 5T   
   $��3��6   $��2��6"   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5U      �� -   5        $ btnClear��5U      #��[  6'   .��5V      �� .+�5W      �� $��../../Images/clear.png��6   $��25��6<   �� 5X      $��
Clear Form��6    $��Center=�62   5Y      5Z      �� 5\      $��75��6   �� 5^      -   5        $ 	btnSubmit��5^      #��[  6(   .��5_      �� .+�5`      �� $��../../Images/submit.png��6   $��25��6=   �� 5a      $��Submit Changes��6    $��Center=�66   5b      5c      5d      5e      5f      