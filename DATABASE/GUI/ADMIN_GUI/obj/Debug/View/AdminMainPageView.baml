   M S B A M L   `   `   `  ����D  @ADMIN_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ADMIN_GUI.ViewADMIN_GUI.View  5   	   &     ADMIN_GUI.View.AdminMainPageView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:ADMIN_GUI.View  5   	     � Title$  AdminMainPageView��5	   	   $	��760��6#   $	��910��60    � WindowStyle$
 None=�6<    � WindowStartupLocation$ CenterScreen=�6O    � 
ResizeMode$ NoResize=�6�    � AllowsTransparency .  
  Window#���   6�   ��6t   Z�  � Triggers 5
      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      ��   OpenMenu#��[ 6   5      :� 5   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5      ��   	CloseMenu#��[ 6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      .+�5   
   � $��1��6   	 � ColumnDefinitions	 5      �� 5      $
��Auto �6#   �� 5      .+�5      � $��1��6   $��3��6#    5      �� 5       $
��147* �6$   .+�5"       � -   5        
  �Name$
 MainPage��5"        � NavigationUIVisibility$ Hidden=�6*   $��2��6J   5#      5$      � 5%      -   5         �Name$ GridMenu��5%      $��67��6%   .+�5&      �� -   5         ��Name$ 
stackPanel��5&        Menu#���  62   .+�5'      � $��48��6    	 Grid1#���  6'   .+�5(      �� -   5         ��Name$ ButtonCloseMenu��5(   !   $��60��6:   $��50��6E   $	��Top=�6~   $��Right=�6�   $y�	Collapsed=�6�   ��6Q   Z� ��6g   Z� .��5)      '  !MaterialDesignThemes.Wpf.PackIcon    Icon#���  66      Kind$ 	ArrowLeft=�6V   $��30��6g   $��30��6r   5*      �� 5+      -   5        $ ButtonOpenMenu��5+   !   $��60��69   $��50��6D   $	��Top=�6}   $��Right=�6�   ��6P   Z� ��6f   Z� .��5,        #���  66   $
 Menu=�6U   $��Center=�6a   $	��-20q�6|   $��27��6�   $��27��6�   5-      5.      �� 5/      $��Disabled=�6   .@�50      �� -   5         ��Name$ Add_info_List��50   '   $��70��6>   .��51      ��  �� Orientation$ 
Horizontal=�6)   .+�52   "     #���  6:   $	 Add=�6Z   $��27��6e   $��27��6p   $��8q�6|   $��Center=�6�   �� 53   "   $��Add info��6,     Text#���  6<   $��Center=�6\   $��20 10q�6w   54      55      �� 56      -   5        $ TimeTable_List��56   3   $��70��6'   .��57      �� $ 
Horizontal=�6)   .+�58   "     #���  6:   $ 	EventNote=�6Y   $��27��6j   $��27��6u   $��8q�6�   $��Center=�6�   �� 59   "   $��	Timetable��6,   #���  6=   $��Center=�6\   $��20 10q�6w   5:      5;      �� 5<      -   5        $ 
Group_list��5<   '   $��70��6;   .��5=      �� $ 
Horizontal=�6)   .+�5>   "     #���  6:   $ People=�6Y   $��27��6g   $��27��6r   $��8q�6~   $��Center=�6�   �� 5?   "   $��
Group list��6,   #���  6>   $��Center=�6]   $��20 10q�6x   5@      5A      5B      5C      5D      5F      � 5H   
   -	   5          Grad#���  5H   *   .+�5I      �� $��0��6   $	��150��6&   $
��Left=�62   $ 
Horizontal=�6N   .+�5J      �� -
   5        $
��Left=�5J      $��12��64   $	��Top=�6@   $��12��6X   $��	10 11 0 0q�6c     ButtonStyle1#���  6v   ���	#FFFF2E00���	#FFFF2E006�   �� 5K      -   5        $ Roll_Up��5K      $
��Left=�6*   $��12��6E   $	��Top=�6Q   $��12��6i   $��7 11 0 0q�6t   #���  6�   ���	#FFFFC500���	#FFFFC5006�   �� 5L      -   5        $ maxsizeButton��5L      {�.  $
��Left=�6B   $��12��6]   $	��Top=�6i   $��12��6�   $��7 11 0 0q�6�   #���  6�   ���	#FF59D114���	#FF59D1146�   5M      d� 5N      -   5         d�Name$ Choose_Theme��5N   p    d� 	IsChecked$ FalseY�6   $��0 0 40 0q�6�   $��Right=�6�    $	  MaterialDesignSwitchToggleButton#��[	 6�    � ToolTip$T NMaterialDesignSwitchToggleButton with Content and ToggleButtonAssist.OnContent��5O      .��5P        $ WhiteBalanceSunny=�6*   1  +MaterialDesignThemes.Wpf.ToggleButtonAssist   	OnContent 5Q        5R      $ 
PowerSleep=�6.   5T        5U      -   5          Name$
 Exit��5U   &   $��Right=�6^   $ 	ExitToApp=�6z   $��30��6�   $��Center=�6�   $��30��6�   #���  6�   6�   5V      5W      5X      