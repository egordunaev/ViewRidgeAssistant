   M S B A M L   `   `   `  ����>  :VRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VRAVRA  5   	       VRA.AddWorkWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:VRA     5   	     � Title$  Работы��5   	   $��254.968��6   $��327.294��6)    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � .+�5
   
   �� $��
Автор��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N   $	��115��6f   �� 5   
   -   5        $��cbArtist��5      $
��Left=�6#   $��23��6>   $��
150,10,0,0q�6J   $	��Top=�6^   $	��157��6v    �� DisplayMemberPath$
 Name��6�   ��6�   �� 6�   �� 5   
   $��Название��6   $
��Left=�6#   $��	10,40,0,0q�6>   $	��Top=�6Q   $	��115��6i   �� 5   
   -   5        $��tbTitle��5      $
��Left=�6!   $��23��6<   $��
150,40,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��157��6�   �� 5   
   $��
Копия��6   $
��Left=�6    $��	10,70,0,0q�6;   $	��Top=�6N   $	��115��6f   �� 5   
   -   5        $��tbCopy��5      $
��Left=�6    $��23��6;   $��
150,70,0,0q�6G   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��157��6�   �� 5   
   $��Описание��6   $
��Left=�6#   $��
10,100,0,0q�6>   $	��Top=�6R   $	��115��6j   �� 5   
   -   5        $��tbDescription��5      $
��Left=�6'   $��23��6B   $��150,100,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��157��6�   �� 5   
   $'��!Дата приобретения��6   $
��Left=�6,   $��
10,130,0,0q�6G   $	��Top=�6[   $	��125��6s   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	dpAquired��5      $��150,130,0,0q�6(   $
��Left=�6=   $	��Top=�6X   $	��157��6p   �� 5   
   $'��!Цена приобретения��6   $
��Left=�6,   $��
10,160,0,0q�6G   $	��Top=�6[   $	��125��6s   �� 5   
   -   5        $��tbAcquisitionPrice��5      $
��Left=�6,   $��23��6G   $��150,100,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��157��6�   �� 5   
   -   5        $��btnSave��5      $��Сохранить��6    $
��Left=�64   $��
30,190,0,0q�6O   $	��Top=�6c   $	��120��6{   6�   �� 5   
   -   5        $��	btnCancel��5      $��Отмена��6"   $
��Left=�63   $��170,190,0,0q�6N   $	��Top=�6c   $	��120��6{   6�   5      5      