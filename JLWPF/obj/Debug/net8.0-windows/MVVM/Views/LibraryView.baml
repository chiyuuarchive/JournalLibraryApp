   M S B A M L   `   `   `  ����@  <JLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:JLWPF.MVVM.AuxiliariesJLWPF.MVVM.Auxiliaries  5      3clr-namespace:JLWPF.ComponentsJLWPF.Components  5      3clr-namespace:JLWPF.MVVM.ViewsJLWPF.MVVM.Views  5      "    JLWPF.MVVM.Views.LibraryView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4aux$clr-namespace:JLWPF.MVVM.Auxiliaries     5      5
componentsclr-namespace:JLWPF.Components     5      0localclr-namespace:JLWPF.MVVM.Views     5      -   5          � 	Resources  5      8   2JLWPF.MVVM.Auxiliaries.BooleanToVisbilityConverter   	BoolToVis �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../../Styles/Styles.xaml?�6%   %   &	          5      6.   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.25* �6   �� 5      $	��.1* �6   �� 5      �� 5      $
��.25* �6   .+�5   
   �� $��Library��6   $��26(�6#   
����p��$��10q�6L   �� 5    
   -   5         ��Name$ 	btnReturn��5    !   $��1��6     ButtonsWithIcons#��[ 64   $��Right=�6^   .��5!      �� .+�5"      �� $��../../Images/back.png��6   $��25��67   �� 5#      $��Return��6   5$      5%      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ ArticleDataGrid��5'      $��2��6,   $
��10 0q�69      
IsReadOnly$
 True��6G      AutoGenerateColumns$
 True��6Y   6t   '   !JLWPF.Components.UserLibraryPanel  5)   
   -   5          Name$ UserLibrary��5)   &   $��4��6;   $��Right=�6H   $��25 10q�6d   y�6s   �� *IsUserLibraryPanelVisible+	 �� 	Converter#	 [  (   "JLWPF.Components.AdminLibraryPanel  5*      -   5        
  Name$
 AdminLibrary��5*      $��4��65   $��Right=�6B   $��25 10q�6^   y�6m   �� *IsAdminLibraryPanelVisible+#	 [  5+      5,      