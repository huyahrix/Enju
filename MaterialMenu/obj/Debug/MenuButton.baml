   M S B A M L   `   `   `  ����G  CMaterialMenu, Version=0.0.4.5, Culture=neutral, PublicKeyToken=null+clr-namespace:MaterialMenuMaterialMenu  5          MaterialMenu.MenuButton   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MaterialMenu     5      -   5        .��5      � -   5          �Name$
  Grid��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��25 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��Auto �6   .+�5   
   � -   5        $  Trigger��5      $��0��6    $��0��60    5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$	 Img��5      $��0��6!   $��0��6.   $��20��6>   $��Center=�6M   $��15 10q�6h   �� 5      -   5         ��Name$	 Txt��5      $��0��6%   $��1��62   $��Center=�6X   $��Calibri)�6s   $��18(�6�   ��6B   �� *Text+6�   5      �� 5   
   -   5        $ Chevron��5      $��0��6!   $��1��6.   $��Images/Light24.png��6>   $��15��6Z   $
��Left=�6e   z�5      �� 5      -   5        ChevronRotate�� �� CenterX$	 7.5Q�5   9    �� CenterY$	 7.5Q�6G   5       �� 5!   
   -   5         ��Name$
 Chld��5$      $��1��5!      $��0��6$   $��2��64   $��0��5#      ��5"      �� ��5%      �� 5&      .R�5'         MaterialMenu.MenuButton  $��30��6U      Text 6'   �� *Text+	   Image	 6=   �� *Image+6U   5(      5*      ��5+   
   �� 5,      
 �� 
TargetType"
 �6    �� Triggers 5-      P� 5.       P� Property �@J�IsMouseOver P� Value . . �5/      ��  �� Property �@�Cursor �� Value$
 Hand��63   50      52      54      55      