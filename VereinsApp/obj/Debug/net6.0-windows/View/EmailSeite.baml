   M S B A M L   `   `   `  ����E  AVereinsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:VereinsApp.ViewVereinsApp.View  5           VereinsApp.View.EmailSeite   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:VereinsApp.View     5        N� 
Background
  ����� N� Title$ 
EmailSeite��5	      $	��450��5
      $
��1000��6   $	��450��6!   $
��1000��61   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��60 �6   �� 5      $	��270 �6   �� 5      $��60 �6   .+�5   
   �� $(��"Rundmail an alle Mitglieder senden��6   $��18(�6=   $
��Bold"�6K   � 5   
   $��1��6   $��Center=�6!   $��20,20,10,10q�6<   .+�5      �� $��30��6   $��Betreff��6    �� 5      $	��400��6   ��6"   �� *	Subject+5      �� 5   
   $��2��6   $��20,20,20,20q�6   ��64   �� *Body+�� 5   
   $��3��6   $	��200��6   $��40��6*   $��Senden��6]   ��66   �� *SendenClickCommand+6]   5      5      