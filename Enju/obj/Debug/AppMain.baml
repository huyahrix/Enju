   M S B A M L   `   `   `  ����G  CMaterialMenu, Version=0.0.4.5, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MaterialMenu;assembly=MaterialMenuMaterialMenu  5   	    Enju   Enju.AppMain   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   CmaterialMenu0clr-namespace:MaterialMenu;assembly=MaterialMenu  5   	   -   5          � Title$  DFT STUDIO UTILITY��5   
   $	��680��6%   $
��1024��62    � WindowStyle$
 None=�6?    � WindowStartupLocation$ CenterScreen=�6R    � 
ResizeMode$ 	CanResize=�6w    � WindowState$ Normal=�6�   $��0q�6�   ��6�   Z� .��5      � .+�5	   
   � .+�5
      �� $��80��6   $	��Top=�6%   .+�5      �� -   5        $��40��5      ���	#FF7995C9.+�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   $	��top=�6[   $��30��6s   .+�5      �� -   5         ��Name$
 User��5   %   $��30��63   $��30��6>   $��0q�6J   
�������$��0q�6�   ��6V   Z� ��6m   Z� .��5   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountSettingsVariant=�6:   5      �� 5      -   5        $ minimize��5   %   $��30��67   $��30��6B   $��0q�6N   
�������$��0q�6�   ��6Z   Z� ��6q   Z� .��5   "     $ WindowMinimize=�6:   5      �� 5      -   5        $ normal��5   %   $��30��65   $��30��6@   $��0q�6L   
�������$��0q�6�   ��6X   Z� ��6o   Z� .��5   "     $ WindowRestore=�6:   5      �� 5      -   5        $ Maximize��5   %   $��30��67   $��30��6B   $��0q�6N   
�������$��0q�6�   ��6Z   Z� ��6q   Z� .��5   "     $ WindowMaximize=�6:   5      �� 5      -   5        $ power��5   %   $��30��64   $��30��6?   $��0q�6K   
�������$��0q�6�   ��6W   Z� ��6n   Z� .��5   "     $ Power=�6:   5      5      �� 5      $��20��6%    �� Padding$ 0q�61   
�������$��DFT STUDIO UTILITY��6h   $��Center=�6�   $	��Top=�6�   $��15(�6�   ��6>   Z� 6�   5      5       � 5!      $��25��6   ���	#FFA0B2D4	 � ColumnDefinitions	 5"      �� 5#      $
��253* �6+   �� 5$      $
��255* �6+   .+�5&      �� $ 
Horizontal=�6!   $��2��6:   .+�5'      �� -   5        $ btnShowConnect��5'   !   $��0q�69   $	��5 0q�6E   $��Center=�6h   ��6R   Z� ��6�   Z� .��5(        $ 
LanConnect=�66   
�������$��20��6\   $��20��6g   5)      �� 5*      -	   5        $ btnDisConnect��5*   !   $��0q�68   $	��5 0q�6D   $��Center=�6   ��6Q   Z� ��6h   Z� .��5+        $ 	ServerOff=�66   
�������$��20��6[   $��20��6f   5,      �� 5-      -
   5        $ btnExportExcel��5-   !   $��0q�6:   $	��5 0q�6�   $��Center=�6�   ��6F   Z� ��6^   Z� ��6t   Z� .��5.        $ 
FileExport=�66   $��20��6H   $��20��6S   
�������6_   5/      �� 50      -   5        
 ��Name$
 cbxDataBase��50   #    �� DisplayMemberPath$ DATABASE_NAME��68    �� SelectedValuePath$ DATABASE_NAME��6\   $��5 0 0 0q�6�   $	��140��6�   $��12(�6�   
���   �$��Center=�6�   
����������	#FFA0B2D451      �� 52      -   5        $ 
btnExecute��52   !   $��Center=�65   ���	#FF528EFF$��1q�6g   
������� K� ZIndex$ 1��6�   $��0q�6�   $��0q�6�   .��53      �� $ 
Horizontal=�6)   $ 0��6C   $��Center=�6j   $��0q�6�   ��6T   Z� .+�54   "     $ StepForward=�6:   $��20��6M   $��20��6X   ���	#FF4EF000$	��5 0q�6�   $��Center=�6�   ��6d   Z� 6�   �� 55   "   $��5 0 10 0q�6,   $��Center=�6>   
�������$��12(�6l   	Execute6�   56      57      58      59      5:      � 5;      $��0 65 0 0q�6   .+�5<      � .+�5=      �� -   5        $��
tabDynamic��5=   -   $��0q�6!   $��0q�6�   $��Stretch=�6�   
�������
����������	#FFA0B2D4$��Stretch=�6�   ��6?   ��  � 	Resources 5>         	TabHeader �� DataType �� RelativeSource �� AncestorType �� Path��%1  &	        �� 5?      $ TabItem��6=   .R�5@   "   �� $ 
Horizontal=�6-   .+�5A   &   �� 
���   ���6D   Z� ��6[   ��  �� $ TabItemL�$ Header��� 5B   &   $��	btnDelete��6-   -   5        $��
0 -4 -10 0q�5B   >   $��15��6R   $��15��6^   $��Right=�6k   $	��Top=�6�   $��0q�6�   ��6�   Z� ��6�   Z� ��6�   Z� ��6  ��  �� " ��$
 Name�.��5C   *     $��Stretch=�6B   $��Stretch=�6`   $ CloseBox=�6|   
����������	#FFA0B2D4$��15��6�   $��15��6�   5D   '   5E   #   5F      5G      5H      5I      5J      5L         MaterialMenu.SideMenu  5M   
   -   5          Name$
 Menu��5M   ;   $
��Left=�6       	MenuWidth$	 300Q�5N          Theme$ Default=�5O   !      State$ Hidden=�5P       5U      5V      5W      