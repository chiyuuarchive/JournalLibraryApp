   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:JLWPF.MVVM.ViewsJLWPF.MVVM.Views  5      "    JLWPF.MVVM.Views.MembersView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:JLWPF.MVVM.Views     5      -   5          � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../../Styles/Styles.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.25* �6   �� 5      $	��.1* �6   �� 5      �� 5      $
��.25* �6   .+�5   
   �� $��Members��6   $��26(�6#   
����p��$��10q�6L   �� 5   
   -   5         ��Name$ 	btnReturn��5   !   $��1��6      ButtonsWithIcons#��[  64   $��Right=�6^   .��5      �� .+�5      �� $��../../Images/back.png��6   $��25��67   �� 5       $��Return��6   5!      5"      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ MembersDataGrid��5$      $��2��6,   $
��10 0q�69      AutoGenerateColumns$
 True��6G      
IsReadOnly$
 True��6b   6t   � 5&   
   $��4��6   $��Right=�6   $��25 10q�68   .+�5(      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5)      �� -   5        $ btnAdmin��5)      $��10q�6+   #��[  68   
������ .��5*      �� $ 
Horizontal=�6!   .+�5+      �� $��../../Images/admin.png��6      InputFieldHeaderIcons#��[ 6@   �� 5,      $��Grant admin access��6$   $��Center=�6>   5-      5.      �� 50      -   5        $ 	btnVerify��50      $��10q�6,   #��[  69   
������ .��51      �� $ 
Horizontal=�6!   .+�52      �� $��../../Images/edit.png��6    #��[ 6?   �� 53      $��Verify member��6$   $��Center=�69   54      55      �� 57      -   5        $ btnRemoveMember��57      $��10q�62   #��[  6?   
������ .��58      �� $ 
Horizontal=�6!   .+�59      �� $��../../Images/remove.png��6    #��[ 6A   �� 5:      $��Remove member��6$   $��Center=�69   5;      5<      �� 5>      -   5        $ btnViewDownloadLog��5>      $��10q�65   #��[  6B   
������ .��5?      �� $ 
Horizontal=�6!   .+�5@      �� $��../../Images/user.png��6    #��[ 6?   �� 5A      $��View download log��6$   $��Center=�6=   5B      5C      5D      5E      5F      5G      