   M S B A M L   `   `   `  ����G  CMaterialMenu, Version=0.0.4.5, Culture=neutral, PublicKeyToken=null+clr-namespace:MaterialMenuMaterialMenu  5          MaterialMenu.SideMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MaterialMenu     5      -   5        $��Control��5	        � 	Resources  5
         ButtonBackground �� Color �� ElementName  ButtonHover 
 Shadow  	SolidBlue   MaterialMenu.MenuButton �� 
TargetType �� Property �� Value��%�  &	        &	 ?     &	 �     &	 �     '      �� 5   
    63   �� *ButtonHover+$ Control��6h   �� 5   
    6.   �� *ButtonBackground+$ Control��6h   �� 5   
    6)   �� *ShadowBackground+$ Control��6c   �� 5   
    6,   �� *SolidBlueBackground+$ Control��6i   �� 5   
   "  6   .�5      ��  � ��# �  6+   6Q   �� 5       �@ HoverBackground# �  60   6X   5      5      .��5      � #���  6    � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ 
MenuColumn��5      $	��400 �63   6A   �� 5      -   5        $ ShadowColumn��5      $��0 �65   6A   .+�5   
   � #���  6   .+�5      �� $��0 80 0 0q�6    �� Orientation$ Vertical=�6+   .+�5      �� $��Connect to Database��6   $��10q�68   $��20(�6D   $��SemiBold"�6R   
�������6h   �� 5      �� 5      $��10q�6   
�������$��Server Name��6;   �� 5      -   5        	 ��Name$	 txtServerName��5      
�������$��1q�6E   $
��10 0q�6Y   
 �� 	MaxLength$
 50��6g   
�������6v   �� 5      $��10q�6   
�������$��Database��6;   �� 5       -   5        $	 txtDataBase��5       
�������$��1q�6C   $
��10 0q�6W   $
 50��6e   
�������6t   �� 5!      $
��20 5q�6   
�������$��Login��6=   �� 5"      -   5        $	 txtLoginName��5"      
�������$��1q�6D   $��	25 0 10 0q�6X   $
 50��6k   
�������6z   �� 5#      $
��20 5q�6   
�������$��Password��6=   G� 5$      -   5         G�Name$ txtPassWord��5$      
�������$��1q�6H   $��	25 0 10 0q�6\    G� 	MaxLength$ 50��6o    G� PasswordChar$ *��6~    J� IsManipulationEnabled . 
�������6�   �� 5%      $��Right=�6   $��5q�67   
�������
�������
�������.��6|   Remember password6�   �� 5&      -   5         ��Name$ 
btnConnect��5&      $��Center=�6-   $
��20 0q�6J   $��Connect��6X   
�������
���E��6�   5'      5(      �� 5)   
   -	   5         ��Name$ MenuPresenter��5)      $��0��62   ��6B   �� *Menu+$ Control��6r   �� 5*   
   -
   5        $��1��5*      #���  6!   6h   5,      5-      