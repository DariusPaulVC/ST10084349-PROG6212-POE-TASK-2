   M S B A M L   `   `   `  ????G  CTaskTwoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TaskTwoFinalTaskTwoFinal  5   	       TaskTwoFinal.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TaskTwoFinal     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ??5   
   ?? 5       ?? ImageSource$ Images\time3.jpg??5       j? Stretch$
 Fill=?5      5      .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 dg1??5      $??1??6    $??0??6-   $??4??6=   $??3??6Q   $??100,0,100,0q?6b   ?? 5    
   -   5        $??Add a semester??5       $??5??6*   $??0??67   $??Center=?6G   $??Center=?6d   $	??108??6?   ?? 5!   
   -   5         ??Name$ 
lblWelcome??5!      $??0??6$   $??0??61   $??Center=?6A   $??0,0,0,0q?6^   $??Center=?6o   $
??Bold"?6?   $??Italic$?6?   $??20(?6?   ?? 5"   
   -   5        $??5??5"      $??1??6   $??View your info??6.   $??Center=?6G   $??Center=?6d   $	??112??6?   ?? 5#   
   -   5        $??5??5#      $??3??6   $
??Exit??6.   $??Center=?6=   $??Center=?6Z   $	??112??6u   6?   5$      5%      