   M S B A M L   `   `   `  ����F  BSTUDENT_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:STUDENT_GUI.ViewSTUDENT_GUI.View  5          STUDENT_GUI.View.AdsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:STUDENT_GUI.View     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  AdsView��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��80 �6    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ Delete_Message��5      $��1��6)   $��1��66   $��60��6F   $	��Top=�6Q   $��Right=�6i   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�6&   $��27��64   $��27��6@   6M   5      �� 5   
   -   5         ��Name$ Messages��5   }   $��1q�6   $	��575��6&   $	��700��6T   $��1��6`   $��1��6m   $��Center=�6�   
������ ��. $��Disabled=�6�   ���	#FFB2B2B2��63   �� *
Messages+��5      �� 5      .R�5      ]� ��. $��Center=�65   .+�5      �� $��Bottom=�6"    *  &MaterialDesignOutlinedTextFieldTextBox#��[  6:   $��Center=�6z    �� 
IsReadOnly . $��17(�6�   $��	ComicSans)�6�    �� TextWrapping$
 Wrap=�6�   $	��680��6  ��6�   ��  �� Path$ CONTENT�.��6  5      ]� 5      $��0 0 0 5q�6$   .+�5       �� $
��Left=�6(   
������ $
��Auto��6W   ���	#FF00BCD4��6d   �� $ STUDENT.STUDENT_NAME�6�   �� 5!      $��Right=�6(   
������ $
��Auto��6]   ���	#FF00BCD4��6j   �� $ DATE_OF_CREATE�6�   5"      5#      5$      5&      � 5'   
   $��3��6   $��1��6   .+�5(      �� -   5        	 ��Name$	 Message_Content��5(      $!��Press Enter to send message��6/   #��[  6�   $��70��6�   $	��Top=�6  $	��550��6  
 �� AcceptsReturn
 . $
 Wrap=�6=  " �� VerticalScrollBarVisibility$
 Auto=�6Q  5*      5+      5,      