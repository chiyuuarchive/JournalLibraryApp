   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:JLWPF.ComponentsJLWPF.Components  5   	   +    %JLWPF.Components.ArticleDetailsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:JLWPF.Components     5   	   -   5          � Title$  Article Details��5   	   $	��600��6!   $	��600��6.    � WindowStartupLocation$ CenterOwner=�5	   	    � WindowStyle$
 None=�6-    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Styles.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.05* �6   �� 5      $��.125* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
      JLWPF.Components.Header  -   5          Name$ UIHeader��5   +   $��2��6   6+   �� 5    
   $��1��6   $��Article Details��6!   $��26(�68   
����p��$��10q�6a   �� 5!   
   -   5        	 ��Name$	 	btnReturn��5!   /   $��1��6   $��1��6      ButtonsWithIcons#��[  6B   $��Right=�6l   $
��10 0q�6�   .��5"      �� .+�5#      �� $��../Images/back.png��6   $��25��64   �� 5$      $��Return��6   5%      5&      �� 5(   
   $��2��6   $
��Left=�6"   $��5q�6=   .+�5)      �� $
��10 0q�6   .+�5*      �� $��Article Title��6   $
��Bold"�61   �� 5+      -   5        
 ��Name$
 txtArticleTitle��5+      $�� ��63     InputFields#��[ 6;   �� 5,      $��	Author(s)��6   $
��Bold"�6-   �� 5-      -   5        $
 
txtAuthors��5-      $�� ��6.   #��[ 66   �� 5.      $��35��6   �� 5/      $��Abstract��6   $
��Bold"�6,   �� 50      -   5        $
 txtAbstract��50      #��[ 6/   $	��175��6T   $	��245��6d    �� AcceptsReturn$
 True��6s    �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   51      52      �� 54   
   $��2��6   $��2��6"   $
��Left=�62   $��5q�6M   .+�55      �� $
��10 0q�6   .+�56      �� $"��Published at (Journal title)��6   $
��Bold"�6@   �� 57      -   5        $
 txtJournalTitle��57      $�� ��63   #��[ 6;   �� 58      $��Year of Publication��6   $
��Bold"�67   �� 59      -   5        $
 txtYearOfPublication��59      $�� ��68   #��[ 6@   �� 5:      $��35��6   �� 5;      $��Source (Hyperlink)��6   $
��Bold"�66   �� 5<      -	   5        $
 txtHyperlink��5<      $�� ��60   #��[ 68   �� 5=      $��Category��6   $
��Bold"�6,   �� 5>      -
   5         ��Name$ cmbCategory��5>      $��10q�60   5?      5@      �� 5B   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Bottom=�6h   $
��0 35q�6�   .+�5C      �� -   5        $	 btnClear��5C      #��[  6'   .��5D      �� .+�5E      �� $��../Images/clear.png��6   $��25��69   �� 5F      $��Clear��6    $��Center=�6-   5G      5H      �� 5I      $��75��6   �� 5J      -   5        $	 	btnSubmit��5J      #��[  6(   .��5K      �� .+�5L      �� $��../Images/submit.png��6   $��25��6:   �� 5M      $��Submit Changes��6    $��Center=�66   5N      5O      5P      5Q      5R      