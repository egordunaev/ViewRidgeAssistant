   M S B A M L   `   `   `  ����m  iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting  5   	   > :VRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VRAVRA 5   	      VRA.ReportWindow   5   	   twfmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:VRA     5   	     � Title$  ReportWindow��5	   	   $	��450��6   $	��800��6+   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  $
��Left=�6   $��93��6.   $��	89,29,0,0q�6:   $	��Top=�6M   $	��376��6e   	� 5   
   -   5        $��	radioGist��5   ,   $��Гистограмма��6   $��640,16,-634,375q�6=    d� 	IsChecked$
 TrueY�6V   	� 5   
   -   5        $��radioSpline��5   )   $��Линейный��6   $��640,50,-634,341q�6<   �� 5   
   -   5        $��
radioSales��5   -   $#��Сумма проданных��6   $
 TrueY�6?   $��640,93,-634,298q�6P   �� 5   
   -   5        $��radioPurchase��5   -   $#��Сумма купленных��6   $��640,127,-634,260q�6B   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   Q   $��25��6   $
��Left=�6!   $��667,182,0,0q�6<   $	��Top=�6d   $	��115��6|     5   
   -   5        $��datePicker2��5   Q   $��25��6   $
��Left=�6!   $��667,221,0,0q�6<   $	��Top=�6d   $	��115��6|    J� RenderTransformOrigin$ 0.4,0&�6�   	� 5   
   -   5        $��radioDay��5   %   $��День��6   $��640,264,-634,132q�65   	� 5   
   -   5        $��radioMounth��5   &   $��
Месяц��6   $��640,293,-634,83q�69   	� 5   
   -	   5        $��	radioYear��5   $   $��Год��6   $��640,323,-634,67q�65   $
 TrueY�6N   �� 5   
   -
   5        $��
btn_accept��5   /   $��Принять��6   $��23��6#   $��75��6A   $��LeftToRight=�6L   $��696,358,21,39q�6�   7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   $��0��6   $��0��6(   $��10,10,168,26q�68      Child. 5      ;   5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        	chart��5      5      5      5      