   M S B A M L   `   `   `  ����H  DWalletManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WalletManagerWalletManager  5   	       WalletManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:WalletManager  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Welcome to Wallet Manager��5   	   $	��600��6+   $
��1200��68   .��5      � $��15,15,15,15q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��60 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��10* �6   �� 5      $��20 �6   �� 5       $	��90* �6   .+�5$   
   '  !MaterialDesignThemes.Wpf.PopupBox  $��6��6"   $��0��62   $��Right=�6?   $	��Top=�6[      PlacementMode$ BottomAndAlignRightEdges=�6s      	StaysOpen .     PopupContent. 5%      �� .+�5&      �� -   5        	 ��Name$	 
btnAccount��5&      .��6E   	Account6N   �� 5'      �� 5(      -   5        $	 	btnLogOut��5(      .��6C   	Log Out6L   5)      5*      �� 5-   
   -   5        
 ��Name$
 tbName��5-      $��0��6$   $��0��64   $��6��6A   $��Center=�6U    # MaterialDesignDisplay2TextBlock#��[ 6p   $
��Name��6�   �� 5/   
   -   5        $
 	tbBalance��5/      $��0��6'   $��0��67   $��6��6D   $��Bottom=�6X      MaterialDesignBody1TextBlock#��[ 6s   Total Balance:6�   �� 52   
   $��0��6   $��2��6$    % !MaterialDesignSubheadingTextBlock#��[ 61   Transactions6z   &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ dgTransctions��54      $��0��6*   $��3��6:      CanUserAddRows .     CanUserSortColumns . 6^   �� 57   
   $��2��6   $��2��6$   #��[ 61   
Expenses6v     59   
   -   5        $ 
dgExpenses��59      $��2��6'   $��3��67    .   . 6[   �� 5<   
   $��4��6   $��2��6$   #��[ 61   
Salaries6v     5>   
   -   5        $ 
dgSalaries��5>      $��4��6'   $��3��67    .   . 6[   �� 5A   
   -   5        $	 btnAdd��5A      $��6��6!   $��3��61   $��Right=�6>   $��Bottom=�6Z    * &MaterialDesignFloatingActionDarkButton#��[ 6u    � ToolTip$+ %Add expenses, salaries and categories��6�   .��5B      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��6&   $��24��61   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�6=   5C      5D      5E      