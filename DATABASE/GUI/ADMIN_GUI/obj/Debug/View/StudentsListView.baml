   M S B A M L   `   `   `  ����D  @ADMIN_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ADMIN_GUI.ViewADMIN_GUI.View  5      %    ADMIN_GUI.View.StudentsListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ADMIN_GUI.View     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  StudentsListView��5
       N� 
Background 6    Z� .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Students_Grid��5         AutoGenerateColumns .  $��Disabled=�6�      CanUserAddRows .  ��6F   �� *
Students+ �� SelectedItem 6g   �� *SelectedItem+��6  Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��6N   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 90 6Z   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *ID+6Z     5      $
 Name��6F    . $	 90 6f   
 6%   �� *STUDENT_NAME+6f     5      $
 Role��6C   $	 85 6Q   
 6%   �� *	ROLE.TYPE+6Q     5       . $ Faculty��6f   $	 90 6w   
 6%   �� *GROUP.FACULTY.FACULTY_NAME+6w     5       . $ 
Profession��6l   $	 90 6�   
 6%   �� *" GROUP.PROFESSION.PROFESSION_NAME+6�     5       . $ Course��6X   $	 70 6h   
 6%   �� *GROUP.COURSE+6h     5       . $ Group��6^   $	 70 6m   
 6%   �� *GROUP.GROUP_NUMBER+6m     5       . $ Subgroup��6d   $	 90 6v   
 6%   �� *SUBGROUP.SUBGROUP_NUMBER+6v   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Delete��6)      CellTemplate 5      �� 5      .R�5      ��  ��Name$ Delete��6%   -   5        .��5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeleteForever=�6:   $��20��6O   $��20��6[   5      5      5        5       $ Set Role��6)    5!      �� 5"      .R�5#      �� $	 Set��6%   -   5        .��5$   "     $
 Edit=�6:   $��20��6G   $��20��6S   5%      5&      5(      5*      5+      5,      