   M S B A M L   `   `   `  ����F  BSTUDENT_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:STUDENT_GUI.ViewSTUDENT_GUI.View  5          STUDENT_GUI.View.TaskView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:STUDENT_GUI.View     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  TaskView��5
       N� 
Background 6   Z�  � 	Resources 5       �� 
TargetType   Txt �� Triggers �� Binding �� Value �� Property �� Value��%�   &	        �� 5   
   " ��6    5      �� 5       6   �� *IS_COMPLITE+ True6>   .a�5      ��  � ��$ Strikethrough{�69   �� 5       �@J�Opacity$ .5Q�61   5      5      5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5      $��* �6   �� 5      $��* �6   
 � RowDefinitions
 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5    
   � $��0��6   $��0��6   	 5!      �� 5"      $��30 �6#   �� 5#      $��* �6#   �� 5$      $��* �6#   �� 5%      $��60 �6#   .+�5'      �� -   5         ��Name$ FilterBySubject��5'   '   $��1��6    �� 
IsEditable . ��. $��Disabled=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Filter by��6�   $	��100��6*  $
��Left=�66     HintOpacity$	 .26Q�6Q  6  �� 5(      -   5        $ TaskComplite��5(   '   $��2��6    �� SelectedIndex$ 0��6n   $ Tasks��6�   $	��100��6�   $
��Left=�6�   $	 .26Q�6�   .@�5)      �� $��Current��6    �� 
IsSelected . 61   �� 5*      $
��Past��6   5+      5,      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ TaskList��5-   )   $��0��6�   $��1��6�      HeadersVisibility$
 None=�6�      CanUserAddRows .     AutoGenerateColumns .  $��Disabled=�6�   ��. ��6   Z� ��6;   �� *
AllTasks+ �� SelectedItem 6\   �� *SelectedTask+   Columns 5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      CellTemplate 50      �� 51      .R�52      ��  ��Name$ Border��6%    �� Padding$ 8q�65   ._�53   "   � 	 54   &   �� 55   *    z� SharedSizeGroup$ Checkerz��6;   $��30 �6V   �� 56   *   $	��260 �6;   �� 57   *   $��50 �6;   .+�59   &   ��  ��Name$ is_complite��6J   -   5        $��Center=�59   /   $��0��6�    d� 	IsChecked 6_   �� *IS_COMPLITE+6�   �� 5:   &   $��8 5 0 0q�61   $��1��6B   .+�5<   *   �� #���   6M   $
��Wrap=�6k   $��2 2 2 2q�6   ��64   �� *	CONTENT+6   5=   '   5>   #   5?      5@      5B      0  *System.Windows.Controls.DataGridTextColumn  5C         FontSize$ 9Q�6N      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn    Binding  6%   �� *SUBJECT.SUBJECT_NAME+6[     5D      $ 50 6)    5E      �� 5F      .R�5G      �� .+�5H   "   �� $��9(�6B   ��6,   �� *DATE+6B   '  !MaterialDesignThemes.Wpf.PackIcon  5I   "   !  Name$! Delete��6�   -   5        "   Kind$" DeleteCircle=�5I   :   $��	20 10 0 0q�6y   $��20��6�   $��20��6�   6�   5J      5K      5M      #   	CellStyle# 5O      �� 5P      *	  $System.Windows.Controls.DataGridCell" 	 6    5Q      P� 5R      $ P� Property$ �@	 
IsSelected% P� Value% . . �5S      ��  � ��
 ���� 6;   �� 5T       � ��
 �   �6;   �� 5U       � ��$ 0q�6@   5V      5X      5Z      � 5\   
   $��1��6   $��2��6   ���	#FFEAF1F1& J� Opacity$	& 0.7Q�6G   � 5^   
   $��1��6   $��1��6   	 5_      �� 5`      $��40 �6#   �� 5a      $��* �6#   �� 5b      $��40 �6#   
 5d      �� 5e      $��40 �6    �� 5f      $��* �6    �� 5g      $��40 �6    .+�5i      �� -   5        ' ��Name$' 	ToNewTask��5i      $��New Task��6(   $��Center=�6<   $	��100��6W   $��1��6c   $��1��6p   6�   �� 5j      -   5        ( ��Name$( NewTask��5j      $y�Hidden=�6(   $��NewTask��6<   
�������$	& 0.6Q�6`   $��Center=�6n   $��1��6�   $��1��6�   .��5k      � .+�5l      �� -   5        $ 
LessonsBox��5l   H   $ Subject��6    . ��. $��Disabled=�5n   D   $	 .26Q�5o      $��Center=�5p      $	��100��5q      $��30��6'   $��	20 15 0 0q�5r      5s      (
  "System.Windows.Controls.DatePicker
  5t      -	   5        ) 
 Name$) Deadline��5t   !   $��Center=�5u      $��	20 10 0 0q�5v      $	��110��5w      $ 	Pick Date��5x       ( $MaterialDesignFloatingHintDatePicker#��[ 5y      �� 5�      -
   5        * ��Name$* Content��5�       * &MaterialDesignOutlinedTextFieldTextBox#��[ 5�      $��	20 15 0 0q�5�      $	��Top=�5�      $	��120��5�      $	��230��6'   + �� AcceptsReturn+ . , �� TextWrapping$
, Wrap=�5�      $ Details��5�      �� 5�      -   5        $' Cancel��5�       # MaterialDesignRaisedLightButton#��[ 5�      $��80��5�      $��27��6!   $��
170 15 0 0q�6-   - � ToolTip$4- .Resource name: MaterialDesignRaisedLightButton��5�      .��6O   Cancel5�      �� 5�      -   5        $
' Save��5�        MaterialDesignRaisedButton#��[ 5�      $��80��5�      $��27��6    $��
80 -27 0 0q�6,   $/- )Resource name: MaterialDesignRaisedButton��5�      .��6I   Save5�      5�      5�      5�      5�      5�      