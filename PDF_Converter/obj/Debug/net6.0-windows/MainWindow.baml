   M S B A M L   `   `   `  ????H  DPDF_Converter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PDF_ConverterPDF_Converter  5   	       PDF_Converter.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PDF_Converter     5   	   h dSyncfusion.SfSkinManager.WPF, Version=20.4600.0.49, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.4600.0.49, Culture=neutral, PublicKeyToken=3d67ed1f87d44c894
syncfusion!http://schemas.syncfusion.com/wpf   5   	   -   5          ?Name$  
mainWindow??5	   	    ? Icon$ /Images/icon.png??5
   	    ? Title$ PDF Converter??5   	   $	??300??6   $	??800??6,   $	??300??5   	   $	??800??6   .??5      ? -   5         ?Name$ myGrid??5       ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   6.   ?? 5      $
??auto ?6   6.   ?? 5      $
??auto ?6   6.    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   6,   ?? 5      $
??auto ?6   6,   ?? 5      $
??auto ?6   6,   ?? 5      $
??auto ?6   6,   .+?5   
   ?? $??	/logo.png??6   $
??Fill=?6#   $??Center=?5      $	??Top=?5       $	??100??5!      $	??100??6!   $??0,0,0,0q?6-   $??1??5"      $??0??6$   ?? 5$   
   $'??!File converter .PDF | .DOC | .PNG??6   $??Center=?5%      $	??Top=?5&      $??25(?5'      $
??Bold"?6"   $??Arial Black)?64   
???   ?$
??auto??5(      $
??auto??6"   $??0,0,0,0q?6/   $??1??5)      $??1??6$   1  +Syncfusion.Windows.Tools.Controls.ButtonAdv  5+   
   -   5          Name$ selectFileButton??5+      $??Select File??5,         	SmallIcon$ /Images/selectFile.png??65   $??Center=?5-      $??35??6<      Label$ Select File??5.      $??10,10,10,10q?63   $??2??6H   $??Center=?5/      $	??125??6:   
???<??
???????$
??Bold"?50   G   51      ?? 53   
   -   5        	 ??Name$	 pathTextBox??53      $??1??54      $??2??6"   $??35??6/   $	??470??6;   
 ?? TextWrapping$
 NoWrap=?55       ?? TextAlignment$ Center=?6(    ?? AcceptsReturn$ False??56      $??10, 10, 10, 10q?6(   3  -Syncfusion.Windows.Tools.Controls.ComboBoxAdv  58   
   -   5          Name$ selectConversionComboBox??58   !      AllowMultiSelect$
 True??59   !      DefaultText$ Select conversion??69   
???<??
???????$
??Bold"?5:   I   $??35??5;   !   $	??125??6-   $??2??69   $??2??6F   $??10, 10, 0, 10q?6V   .@?5<      7  1Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv  $??
DOC to PDF??6)     5=      $??
PDF to DOC??6)     5>      $??
PNG to PDF??6)   5?        5A   
   -   5        $ convertButton??5A      $??Convert File??5B      $ /Images/convertFile.png??66   $??Center=?5C      $??35??6<   $ Convert File??5D      $??10,10,10,10q?64   $??3??6I   $??1??6V   $??Center=?5E      $	??125??6:   
???<??
???????$
??Bold"?5F   G   5G      5H      5I      