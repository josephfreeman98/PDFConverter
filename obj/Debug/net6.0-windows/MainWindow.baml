   M S B A M L   `   `   `  ????Q  MPDFConverterSyncfusion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PDFConverterSyncfusionPDFConverterSyncfusion  5   	   '    !PDFConverterSyncfusion.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PDFConverterSyncfusion     5   	   h dSyncfusion.SfSkinManager.WPF, Version=19.3500.0.48, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=19.3500.0.48, Culture=neutral, PublicKeyToken=3d67ed1f87d44c894
syncfusion!http://schemas.syncfusion.com/wpf   5   	   -   5          ?Name$  myMainWindow??5   	    ? Icon$ Images/favicon.ico??5       ? Title$ The great PDF Converter??5   	   $	??299??6)   $	??510??66   .??5      ? -   5         ?Name$ myGrid??5       ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   $	??135??6,   6=   ?? 5      $
??auto ?6   $??218.757??6,   6A   ?? 5      $
??auto ?6   $??76.243??6,   6@    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   $??92??6*   6;   ?? 5      $
??auto ?6   $??31??6*   6;   ?? 5      $
??auto ?6   $??42??6*   6;   ?? 5      $
??auto ?6   $??42??6*   6;   .+?5    
   ?? $??1??6   $??0??6    $??Images/freeman_blue.png??6-   $
??Fill=?6N   $??Center=?5!      $	??Top=?5"      $??98??6(   $	??180??64   $??0,3,0,0q?6@   $??2??6Q   ?? 5$   
   $??1??6   $??1??6    $??Super PDF Converter??6-   $??Center=?5%      $	??Top=?5&      $
??Bold"?5'      $??16(?6"   $??31??61   $	??166??6=   $??0,9,0,0q?6I   $??2??6Z   1  +Syncfusion.Windows.Tools.Controls.ButtonAdv  5(   
   -   5        $??Select file??5(      $??Center=?65   $??42??6R      Label$ Select file??6^   $??2??6r   $??Center=?6   $	??114??5)         	SmallIcon$  /Images/SelectFileIcon.png??6+   ???	#FFEE256B???#fff5+   1   ?? 5.   
   -   5         ??Name$ pathTextBox??5.      $??1??6'   $??2??67   	 ?? TextWrapping$	 NoWrap=?6D   
 ?? AcceptsReturn$
 False??6Z   $??
10,15,10,5q?5/      3  -Syncfusion.Windows.Tools.Controls.ComboBoxAdv  52   
   -   5          Name$ conversionDropDown??52   !   $??2??6=   $??2??6M      AllowMultiSelect$ False??6Z      DefaultText$ Select??53   !   
??????????	#FFEF2F5A$??10,10,10,10q?54   !   .@?56      7  1Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv  $??  Doc to PDF??6)     57      $??  PDF to Doc??6)     58      $??  PNG to PDF??6)   59        5;   
   -   5        $??Convert??5;      $# /Images/ConvertButtonIcon.png??61   $??Center=?5<      $??42??6<   $ Convert??6H   $??3??5=      $??1??6,   $	??Top=?6<   $	??114??6T   ???	#FFEF2F5A
???????$??0,21,0,0q?5?   N   5E      5G      