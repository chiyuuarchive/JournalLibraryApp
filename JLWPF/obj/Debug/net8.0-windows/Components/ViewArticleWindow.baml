   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:JLWPF.ComponentsJLWPF.Components  5   	   (    "JLWPF.Components.ViewArticleWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:JLWPF.Components     5   	   -   5          � Title$  Article Details��5   	   $	��600��6!   $	��500��6.    � WindowStartupLocation$ CenterOwner=�5	   	    � WindowStyle$
 None=�6-    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Styles.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.05* �6   �� 5      �� 5      $
��.35* �6   �� 5      $
��.25* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5    
      JLWPF.Components.Header  -   5          Name$ UIHeader��5    +   $��2��6   6+   �� 5"   
   $��1��6   $��15 10 15 10q�6"   $��2��67   .+�5#      �� -   5        	 ��Name$	 txtArticleTitle��5#      $"��Article Title: (placeholder)��61      ViewArticleTextBlocks#��[  6U   $��Center=�6�   
 �� Padding$
 5q�6�   $
��Wrap=�6�   $��10(�6�   �� 5$      $��	Abstract:��6   $
��Bold"�6)   �� 5&        ViewArticleBorders#��[ 6   ._�5'      �� $��Disabled=�6   $
��Auto=�6H   .��5(      �� -   5        $	 txtAbstract��5(       $��placeholder text��65   #��[  6M   $
��Wrap=�6|   $��10(�6�   5)      5*      5+      �� 5-   
   $��2��6   $
��15 0q�6"   $	��Top=�60   .+�5.      �� #��[ 6   ._�5/      �� -   5        $	 
txtAuthors��5/      $��
Author(s):��60   #��[  6B   $��10(�6q   $
��Wrap=�6   50      �� 52      $��20��6   �� 54      #��[ 6   ._�55      �� -   5        $	 txtPublishedAt��55      $��Published at: ��64   #��[  6J   $��10(�6y   $
��Wrap=�6�   56      57      �� 59   
   $��2��6   $��1��6"   $
��15 0q�62   $	��Top=�6@   .+�5;      �� #��[ 6   ._�5<      �� -   5        $	 txtYearOfPublication��5<      $��Year of Publication:��6:   #��[  6V   $��10(�6�   $
��Wrap=�6�   5=      �� 5?      $��20��6   �� 5@      #��[ 6   ._�5A      �� -   5        $	 txtCategory��5A      $��	Category:��61   #��[  6B   $��10(�6q   $
��Wrap=�6   5B      5C      �� 5E   
   $��3��6   $��15 20 -25 5q�6"   .+�5F      �� $��Source:��6   $
��Bold"�6'   $
��Left=�69   �� 5G      -	   5        $	 	txtSource��5G      $
��Left=�6+   $��Center=�6F   #��[  6a   
�������$��5q�6�   $
��Wrap=�6�   �� 5H      -
   5         ��Name$ 
linkSource��5H      $��10(�6]   5I      5J      �� 5K   
   $��3��6   $��1��6"   $��Center=�62   $��Center=�6O   .+�5L      �� -   5         ��Name$ 	btnSource��5L      $��5q�6(     ButtonsWithIcons#��[ 64   .��5M      ��  �� Orientation$ 
Horizontal=�6   .+�5N      �� $��../Images/download.png��6     InputFieldIcons#��[ 6<   �� 5O      $��Get Source Link��6    5P      5Q      5R      5S      5T      