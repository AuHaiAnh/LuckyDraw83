   M S B A M L   `   `   `  ����G  CSMELuckyDraw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SMELuckyDraw.UCSMELuckyDraw.UC  5   	       SMELuckyDraw.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,myclr-namespace:SMELuckyDraw.UC     5   	   -   5          � Title$  RVSC Lucky Draw��5   	   $	��740��6!   $
��1024��6.    � WindowStyle$ SingleBorderWindow=�6;    � WindowStartupLocation$ CenterScreen=�6\    � Icon$ image/monkey.ico��6�   ��5      �� 5   
    �� ImageSource$ image/bg03.png��6   .��5	      �  � RowDefinitions 5
   
   �� 5      $��5 �6   �� 5      $��82 �6   �� 5      $	��20* �6   �� 5      $
��100* �6   �� 5      $
��360* �6   �� 5      $	��50* �6   �� 5      $	��40* �6   �� 5      $	��15* �6   .+�5   
   �� $��0��6   ���	#FFF0AB0066   �� 5   
   -   5         ��Name$ buttonStart��5   j   $��5��6   $��Start��6   $��50��6.   $��Center=�6:   $��	0,0,140,0q�6W   $��Center=�6   $��90��6�   $��16(�6�   $
��Bold"�6�   ��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      � 	 � Color$	 	#FFF3F3F3��6#   
 � Offset$
 0Q�65   � 5      $	 	#FFEBEBEB��6#   $	
 0.5Q�65   � 5      $	 	#FFDDDDDD��6#   $	
 0.5Q�65   � 5      $	 	#FFF9E1C3��6#   $
 1Q�65   5      5      �� 5   
   -   5        $ 
buttonStop��5   i   $��5��6   $
��Stop��6   $��50��6-   $��Center=�69   $��	150,0,0,0q�6V   $��Center=�6}   $��90��6�   {�.  $��16(�6�   $
��Bold"�6�   ��5       �� 5!      $	 0,1&�6&   $	 0,0&�65   .��5"      � $	 	#FFF3F3F3��6#   $
 0Q�65   � 5#      $	 	#FFEBEBEB��6#   $	
 0.5Q�65   � 5$      $	 	#FFDDDDDD��6#   $	
 0.5Q�65   � 5%      $	 	#FFF9E1C3��6#   $
 1Q�65   5&      5(      �� 5)   
   -   5        $��lbMsg��5)      $��6��6   $"��Please press ENTER to start!��6*   $��Center=�6Q   $��Center=�6n   $��0q�6�    K� ZIndex$
 1001��6�   
���  ����. $��1��6�   ���	#660000006�   !   SMELuckyDraw.UC.NumberGroup  5*   
   -   5          Name$ numberGroupMain��5*   P   $��4��6   $	��311��6&   $��Center=�63   $	��900��6i   $��Center=�6u   $	��Top=�6�   $��
58,10,58,0q�6�   $��1��6�   �� 5+   
   -   5        $��lbWinner��5+      $�� ��6    $��Center=�6+   $��0q�6H   $��3��6S   $��Center=�6`   $��48(�6{   $
��Bold"�6�   
���  �����	#660000006�   �� 5,   
   $
��Left=�6   $��71��6+   $��5,5,0,0q�67   $��1��6H   $	��Top=�6U   $	��144��6m   $��image/LogoCty.png��6y   $
��None=�6�   5-      �� 5.   
   -   5        $��lblSubContent��5.      $�� ��6%   $
��Left=�60   $��	148,4,0,4q�6K   $��1��6^   $��Center=�6k   $��46(�6�   $��Segoe UI)�6�   $
��Bold"�6�   ���	#FFFF5252���	#660000006�   �� 5/   
   -   5        $��btnRest��5/      $��Reset��6    $��Right=�60   $��0,0,10,4q�6L   $��6��6^   $��Bottom=�6k   $��60��6�   $��35��6�   $��16(�6�   ��.  $��0q�6�   $
��Bold"�6�   ���	#FF004D00��50      �� 51      $	 0,1&�6&   $	 0,0&�65   .��52      � $	 	#FFF3F3F3��6#   $
 0Q�65   � 53      $	 	#FFEBEBEB��6#   $	
 0.5Q�65   � 54      $	 	#FFDDDDDD��6#   $	
 0.5Q�65   � 55      $	 	#FFF9E1C3��6#   $
 1Q�65   56      58      �� 5:   
   -	   5        $��	chkIsAuto��5:      $
��Auto��6$   $��Center=�63   $��
0,0,900,25q�6P   $��5,-3,0,0q�6d   $��6��6w   $��Center=�6�   $��80��6�   $��25��6�   $��16(�6�   ��.  $��2��6�   �� 5;   
   -
   5        $��chkMute��5;      $
��Mute��6"   $��Center=�61   $��11,28,911,12q�6N   $��5,-3,0,0q�6d   $��6��6w   $��Center=�6�   $��80��6�   $��25��6�   $��16(�6�   ��.  $��2��6�   �� 5<   
   -   5        $��cbBackground��5<      $��Center=�6'   $��84,17,878,0q�6D   $��5,-3,0,0q�6Y   $��6��6l   $��Center=�6y   $��40��6�   $��25��6�   $��16(�6�   ��.  6�   �� 5>   
   -   5        $ btnSunny��5>      $��Members��6#   $��Right=�65   $��0,0,80,4q�6Q   $��6��6c   $��Bottom=�6p   $	��110��6�   $��35��6�   $��16(�6�   ��.  $��0q�6�   $
��Bold"�6  ���	#FF004D40��5?      �� 5@      $	 0,1&�6&   $	 0,0&�65   .��5A      � $	 	#FFF3F3F3��6#   $
 0Q�65   � 5B      $	 	#FFEBEBEB��6#   $	
 0.5Q�65   � 5C      $	 	#FFDDDDDD��6#   $	
 0.5Q�65   � 5D      $	 	#FFF9E1C3��6#   $
 1Q�65   5E      5G      �� 5H   
   -   5        $ btnBlank��5H      $��Button��6#   $��Right=�64   $��0q�6P   $��6��6[   $��1��6h   ���	#000000006�   5I      5J      