   M S B A M L   `   `   `  ����H  DWalletManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WalletManagerWalletManager  5   	       WalletManager.Register   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:WalletManager  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Register��5   	   $	��400��6   $	��650��6'   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $	��200 �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $
��100* �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5       $��30 �6   �� 5!      $��10 �6   �� 5"      $��30 �6   �� 5#      $��10 �6   �� 5$      $��30 �6   �� 5%      $��10 �6   �� 5&      $
��100* �6   .+�5*   
   �� $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6&   $��30��6r   $��20��6~   ��65   ��  �� ElementName$ txtName��	 �� Path$	 BorderBrush�6~   �� 5,      -   5        
 ��Name$
 txtName��5,      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��6'   $	��175��6M   $��5,0,0,0q�6Y   5-      �� 51   
   $��1��6   $��3��6%   $ 
Horizontal=�62   .+�52        $ At=�6&   $��30��6n   $��20��6z   ��60   �� $ txtEmail��$	 BorderBrush�6z   �� 53      -   5        $
 txtEmail��53      $ Email��6(   $	��175��6O   $��5,0,0,0q�6[   54      �� 57   
   $��1��6   $��5��6%   $ 
Horizontal=�62   .+�58        $	 Key=�6&   $��30��6r   $��20��6~   ��61   �� $ txtPassword��$	 BorderBrush�6~   G� 59      -   5         G�Name$ txtPassword��59      $ Password��6/   $	��175��6Y   $��5,0,0,0q�6e   5:      �� 5>   
   $��1��6   $��7��6%   $ 
Horizontal=�62   .+�5?        $	 Key=�6&   $��30��6~   $��20��6�   ��61   �� $ txtPasswordConfirmation��$	 BorderBrush�6�   G� 5@      -   5        $ txtPasswordConfirmation��5@      $ Confirm Password��6;   $	��175��6m   $��5,0,0,0q�6y   5A      �� 5E   
   $��1��6   $��9��6%   $ 
Horizontal=�62   .+�5F        $ CurrencyUsd=�6&   $��30��6z   $��20��6�   ��69   �� $ cmbCurrency��$	 BorderBrush�6�   �� 5G      -   5         ��Name$ cmbCurrency��5G      $ Currency��6,   $	��175��6V   $��5,0,0,0q�6b   5H      �� 5L   
   -   5         ��Name$ btnRegister��5L      $��1��6&   $��11��66   $��Register��6D   6W   5M      5N      