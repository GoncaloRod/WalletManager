   M S B A M L   `   `   `  ����H  DWalletManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WalletManagerWalletManager  5   	       WalletManager.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:WalletManager  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Login��5   	   $	��400��6   $	��650��6$   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $
��100* �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5       $
��100* �6   .+�5$   
   �� $��1��6   $��1��6%   $��2��62    �� Orientation$ 
Horizontal=�6F   .+�5%      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6&   $��30��6r   $��20��6~   ��65   ��  �� ElementName$ cmbUser��	 �� Path$	 BorderBrush�6~   �� 5&      -   5        
 ��Name$
 cmbUser��5&      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Account��6(   $	��175��6Q   $��5,0,0,0q�6]   5'      �� 5*   
   $��1��6   $��3��6%   $��2��62   $ 
Horizontal=�6F   .+�5+        $	 Key=�6&   $��30��6r   $��20��6~   ��61   �� $ txtPassword��$	 BorderBrush�6~   G� 5,      -   5         G�Name$ txtPassword��5,      $ Password��6/   $	��175��6Y   $��5,0,0,0q�6e   5-      �� 50   
   -   5         ��Name$ btnLogin��50      $��2��6#   $��5��63   $��Login��6@   $��
2, 0, 0, 0q�6P    �� 	IsDefault . 6u   �� 53   
   -   5        $ btnRegister��53      $��1��6&   $��5��66   $��Register��6C   $��
0, 0, 2, 0q�6V   6j   54      55      