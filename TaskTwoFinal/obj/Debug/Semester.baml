   M S B A M L   `   `   `  ????G  CTaskTwoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TaskTwoFinalTaskTwoFinal  5   	       TaskTwoFinal.Semester   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TaskTwoFinal     5   	     ? Title$  Semester??5   	   $	??450??6   $	??800??6'   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ??5   
   ?? 5       ?? ImageSource$ Images\time3.jpg??5       j? Stretch$
 Fill=?5      5      .+?5   
   ?? $??Semester Name??6   $??1??6(   $??0??65   $??Center=?6E   $??0,0,0,0q?6b   $??Center=?6s   ?? 5   
   $#??Number of Weeks This Semester??6   $??2??68   $??0??6E   $??Center=?6U   $??0,0,0,0q?6r   $??Center=?6?   ?? 5    
   $"??Start Date for this Semester??6   $??3??67   $??0??6D   $??Center=?6T   $??0,0,0,0q?6q   $??Center=?6?   ?? 5!   
   $??Add a Semester??6   $??0??6*   $??0??67   $??Italic$?6G   $??20(?6Z   $
??Bold"?6h   $??Center=?6z   $??0,0,0,0q?6?   $
??Wrap=?6?   $??Center=?6?   ?? 5"   
   -   5         ??Name$ tbName??5"      $??1??6"   $??1??6/   $??Center=?6?   $??0,0,0,0q?6\    ?? TextWrapping$
 Wrap=?6m   $?? ??6?   $??Center=?6?   $	??120??6?   ?? 5#   
   -   5        $ tbWeeks??5#      $??2??6#   $??1??60   $??Center=?6@   $??0,0,0,0q?6]   $
 Wrap=?6n   $?? ??6?   $??Center=?6?   $	??120??6?   ?? 5$   
   -   5        $??Add Semester??5$      $??4??6(   $??0??65   $??2??6E   $
??Left=?6Y   $??
128,25,0,0q?6t   $	??Top=?6?   $??28??6?   $	??140??6?   6?   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$	 dg1??5%      $y?Hidden=?6    $??	20,0,20,0q?64   $??1??6G   $??3??6T   $??2??6e   $??2??6u   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ dpStartDate??5&      $??3??6*   $??1??67   $??Center=?6G   $??0,0,0,0q?6d   $??Center=?6u   $	??120??6?   ?? 5'   
   -   5        $??Add a module??5'      $??4??6(   $??2??65   $??2??6E   $??Center=?6Y   $??0,0,0,0q?6v   $??Center=?6?   $	??140??6?   $??28??6?   6?   5(      5)      