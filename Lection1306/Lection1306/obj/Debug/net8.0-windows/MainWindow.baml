   M S B A M L   `   `   `  ����F  BLection1306, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Lection1306Lection1306  5   	       Lection1306.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Lection1306     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5         Lection1306.User  5   
    � 	Resources 5         
WindowFont!   Lection1306.SalaryConverter  salaryConverter��%J   &	        &	 #     *�5   
   Arial Black)�65     5   
   6    5      .��5      �� -   5         ��Name$ panel��5      .+�5   
   �� ��6   ��  �� Source# [   �� Path$ Source���5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �$ 
FontFamily�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5    
   -   5         ��Name$ loginTextBox��5       ��6(   �� *Login+�� 5!   
   -   5        $ passwordTextBox��5!      ��6+   �� *
Password+�� 5#   
   -   5         ��Name$ userListView��5#      $	��200��6)   ��5$      �� 5%       �� DataType$ 
local:User��6   .R�5&      � .+�5'      �� 
����  ���6$   �� *Login+6;   �� 5(      $��10, 0q�6>   ��6$   �� *
Password+6>   �� 5)      $��10, 0q�6]   ��6$   �� *
Birthday+ �� StringFormat$ {0:dd.MM.yyyy}��6]   �� 5*      ��6$   �� *Salary+$ {0:C}�� �� ConverterCulture$ ru-ru���� 5+      $��10, 0q�6@   ��6$   �� *
UserSalary+6@   �� 5,      ��6$   �� *Salary+ �� 	Converter# [ 5-      5.      50      �� 52   
   -   5        $ colorTextBox��52      ��53      ��  �� $
 Self=�$ 
Background�$	 TwoWay=�$
 PropertyChanged=��� 58   
   -   5        $ color2TextBox��58      ��59      ��  �� $ FindAncestor=�" ��$ 
Background�$	 TwoWay=�$
 PropertyChanged=� �� TargetNullValue$ 	#FF00FFFF���� 5@   
   -   5        $ dataTextBox��5@      ��6'   �� *.+�� 5A   
   -	   5        $ login2TextBox��5A      ��6)   �� *.+5D      5E      