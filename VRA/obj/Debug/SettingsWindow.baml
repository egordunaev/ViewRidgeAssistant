   M S B A M L   `   `   `  ����>  :VRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VRAVRA  5   	       VRA.SettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:VRA     5   	   -   5          � Title$  SettingsWindow��5   	   $��202.79��6    $��323.699��60    � 
ResizeMode$ NoResize=�6@   .��5	      � $��2q�6   $��Stretch=�6   $��Stretch=�64    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��150 �6   .+�5   
   �� $��Сервер��6   $��0��6"   $��0��6/   �� 5   
   $��База данных��6   $��1��6'   $��0��64   �� 5   
   $��Пользователь��6   $��2��6(   $��0��65   �� 5   
   $��Пароль��6   $��3��6"   $��0��6/   �� 5   
   $*��$Аутентификация Windows��6   $��4��62   $��0��6?   �� 5   
   -   5        $��tbServer��5      $��0��6"   $��1��6/   $��3q�6?   �� 5   
   -   5        $��
tbDataBase��5      $��1��6$   $��1��61   $��3q�6A   �� 5   
   -   5        $��tbUser��5      $��2��6    $��1��6-   $��3q�6=   �� 5   
   -   5        $��
tbPassword��5      $��3��6$   $��1��61   $��3q�6A   �� 5!   
   -   5        $��btnSave��5!      $��5��6    $��0��6-   $��Сохранить��6=   $��3q�6Q   6\   �� 5"   
   -   5        $��	btnCancel��5"      $��5��6"   $��1��6/   $��Закрыть��6?   $��3q�6Q   6\   �� 5$   
   -   5        $��cbAuth��5$      $��4��6!   $��1��6.   $��3q�6>   6b   5%      5&      