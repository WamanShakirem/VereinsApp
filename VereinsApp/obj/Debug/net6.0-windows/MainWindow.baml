   M S B A M L   `   `   `  ????E  AVereinsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:VereinsApp
VereinsApp  5   	       VereinsApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:VereinsApp     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $
??197* ?6   ?? 5      $??3* ?6   .+?5   
   ?? $??1??6   $??10q?6%   .+?5      ?? -   5         ??Name$ SearchTextBox??5      6-   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ PersonenDatenGrid??5      $??
0,46,0,176q?6Y   $??2??6m   ?? 5   
   $??Neue Mitglieder??6   $
??Left=?6*   $??8,17,0,0q?6E   $	??Top=?6W    J? RenderTransformOrigin$ -4.053,-8.704&?6o   ?? 5   
   -   5        $
??Left=?5      $??
596,21,0,0q?6-    ?? TextWrapping$
 Wrap=?6A   $	??Top=?6U   $	??120??6m   6y   ?? 5   
   -   5         ??Name$ btn_add_mitglied??5      $??Mitglied hinzufügen??6+   $
??Left=?6I   $??
78,313,0,0q?6d   $	??Top=?6x   $	??165??6?   $??40??6?   ?? 5   
   -   5        $ btn_change_mitglied??5      $??Mitglied ändern??6.   $
??Left=?6H   $??242,313,0,0q?6c   $	??Top=?6x   $	??165??6?   $??40??6?   ?? 5   
   -   5        $ btn_dele_mitglied??5      $??Mitglied löschen??6-   $
??Left=?6H   $??406,313,0,0q?6c   $	??Top=?6x   $	??165??6?   $??40??6?   ?? 5   
   -   5        $??Suchen??5      $??Suchen??6   $
??Left=?6/   $??
547,16,0,0q?6J   $	??Top=?6^   $ -4.053,-8.704&?6v   ?? 5   
   -   5        $ btn_uebersicht??5      $??
Übersicht??6)   $
??Left=?6=   $??570,313,0,0q?6X   $	??Top=?6m   $	??122??6?   $??40??6?   6?   ?? 5   
   -	   5        $ btn_email_senden??5      $??E-Mail senden??6+   $
??Left=?6C   $??305,361,0,0q?6^   $	??Top=?6s   $	??165??6?   $??40??6?   5      5      