   M S B A M L   `   `   `  ���� E  AVereinsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:VereinsApp.ViewVereinsApp.View  $    VereinsApp.View.StatistikSeite   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:VereinsApp.View       N� Title$  StatistikSeite�� N� 
Background
 �����.���  � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$
��Left=�$��50,50,50,50q�.+��� $��Mitglieder Statistik��$��20(�$
��Bold"� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$	 0.3Q��� $��Mitgliederanzahl:��$
��Left=�$	��Top=��� $	��200�� �� 
IsReadOnly$
 True������  �� Path$ Mitgliederanzahl��� $ ��Mitgliederanzahl Weiblich:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ Mitgliederanzahl_w��� $!��Mitgliederanzahl Männlich:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ Mitgliederanzahl_m��� $��Mittleres Alter:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ MittleresAlter��� $(��"Anzahl minderjähriger Mitglieder:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ Mitgliederanzahl_minderj��� $'��!Anzahl volljähriger Mitglieder::��$
��Left=�$	��Top=��� $	��200������ $ Mitgliederanzahl_vollj��� $��1��$
��Left=�$��50,50,50,50q�.+��� $��Jüngstes Mitglied:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ JüngstesMitglied��� $��Ältestes Mitglied:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ ÄltestesMitglied��� $��Neuestes Mitglied:��$
��Left=�$	��Top=��� $	��200��$
 True������ $ NeustesMitglied�