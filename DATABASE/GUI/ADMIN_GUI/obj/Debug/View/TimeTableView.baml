   M S B A M L   `   `   `  ����D  @ADMIN_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ADMIN_GUI.ViewADMIN_GUI.View  5      9!clr-namespace:ADMIN_GUI.ConverterADMIN_GUI.Converter  5	      "    ADMIN_GUI.View.TimeTableView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ADMIN_GUI.View     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3databinding!clr-namespace:ADMIN_GUI.Converter  5	        N� Title$  TimeTableView��5       � 	Resources 5      &   ADMIN_GUI.Converter.DayConverter   DayConverter��%   &	          5   
   6:   5      .��5      ]� ��. .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.    � DataContext 6C   �� *SelectedTimeTable+.+�5      ��  �� 
IsReadOnly . $��Center=�6(   $	��100��6J    �� TextAlignment$ Center=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Day��6�    � Cursor$ Arrow��6�   ��6V   �� *
LESSON_DAY+ �� 	Converter# [  6�   �� 5      -   5        	 ��Name$	 Set_Time��5   8   $��Center=�6   $��80��6J   $ Center=�6�   $
 Time��6�   $ Arrow��6�   ��6U   �� 
 �� Path$
 LESSON_TIME� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5      -   5        $	 Set_Auditorium��5   8   $��Center=�6   $��80��6P   $ Center=�6�   $ 
Auditorium��6�   ��6[   �� $
 
AUDITORIUM�$ PropertyChanged=�$ TwoWay=�6�   �� 5      -   5        $	 Set_LessonType��5   8   $��Center=�6   $��80��6P   $ Center=�6�   $ Lesson type��6�   ��6[   �� $
 LESSON_TYPE�$ PropertyChanged=�$ TwoWay=�6�   �� 5      -   5         ��Name$ Subject��5       �� 
IsEditable . ��. $��Disabled=�6�   $ Subject��6�   $��80��6   $
��Left=�6     HintOpacity$	 .26Q�6&  6T  �� 5      -   5        $��	Stud_Week��5      $��5 0 0 0q�6(   ��. $��Disabled=�6^   $
 Week��6�   $��70��6�   $
��Left=�6�   $	 .26Q�6�   .@�5      �� $��First��6   �� 5      $��Second��6   5      �� 5      -   5        $ Choose_course��5      $	��5,0q�6.   $��95��6;   $ Choose course��6F   ��. $��Disabled=�6�   �� 5      -   5        $ Choose_group��5      $	��5,0q�6-   $��95��6:   $ Choose group��6E   ��. $��Disabled=�6�   �� 5      -   5        $ Choose_subgroup��5      $	��5,0q�60   $	��115��6=   $ Choose subgroup��6I   ��. $��Disabled=�6�   5      �� 5   
   -	   5        $��Lessons��5   B   $��0q�6   $��Right=�6   $
��auto��65   $��Disabled=�6�   ��. $��Disabled=�6  ��6Q   �� *
TimeTables+ �� SelectedItem 6t   �� *SelectedTimeTable+��6�   Z� ��5       �� 5!      .R�5"      �� $ 
Horizontal=�6!   $��0q�6:   $��13��6E    �� CanVerticallyScroll .   J� OpacityMask 6n   Z� .+�5#      �� $��10,0,0,0q�6%   $��80��67   $��Center=�6�   ��6B   �� $
 LESSON_TIME�$ PropertyChanged=�$ TwoWay=�6�   �� 5$      $��60��6$   $��Center=�6�   ��6/   �� $
 
AUDITORIUM�$ PropertyChanged=�$ TwoWay=�6�   �� 5%      $��40��6$   $��Center=�6�   ��6/   �� $
 LESSON_TYPE�$ PropertyChanged=�$ TwoWay=�6�   �� 5&       ��Name$ Subject_name��60   $	��310��6$   $��Center=�6�   ��6F   �� $
 SUBJECT.SUBJECT_NAME�$ PropertyChanged=�$ TwoWay=�6�   5'      5(      5*      �� 5+   
   .+�5,      �� ��. $
��Auto=�63   $
��Auto=�6c   .��5-      �� $ Vertical=�6   .+�5.      �� $	��115��6   $��Monday��6)   $��30(�6:   $��Center=�6H    J� Opacity$	 0.6Q�6l   $��Italic$�6z   $��Center=�6�   ���	#FF13B8B86�   �� 5/      $	��116��6   $��Tuesday��6)   $��30(�6;   $��Center=�6I   $	 0.6Q�6m   $��Italic$�6{   $��Center=�6�   ���	#FF42CDCD6�   �� 50      $	��116��6   $��	Wednesday��6)   $��30(�6=   $��Center=�6K   $	 0.6Q�6o   $��Italic$�6}   $��Center=�6�   ���	#FF68E0E06�   �� 51      $	��116��6   $��Thursday��6)   $��30(�6<   $��Center=�6J   $	 0.6Q�6n   $��Italic$�6|   $��Center=�6�   ���	#FF88EAEA6�   �� 52      $	��116��6   $��Friday��6)   $��30(�6:   $��Center=�6H   $	 0.6Q�6l   $��Italic$�6z   $��Center=�6�   ���	#FFC7F7F76�   �� 53      $	��117��6   $��Saturday��6)   $��30(�6<   $��Center=�6J   $	 0.6Q�6n   $��Italic$�6|   $��Center=�6�   ���	#FFE7F9F96�   54      55      56      57      58      