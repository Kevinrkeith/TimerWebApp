   M S B A M L   `   `   `  ����S  OTimerWebApplicationKevin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TimerWebApplicationKevin.ViewsTimerWebApplicationKevin.Views  5      0    *TimerWebApplicationKevin.Views.ShowResults   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TimerWebApplicationKevin.Views     5      .��5	      � ���#0BB7FF.+�5
   
   � $
��1180��6   $	��680��6   
�������  � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $�� ��6   $��1��6!   �� 5      $��2��6    �� Orientation$ 
Horizontal=�6&   �� 5      $��2��6D   $
��1100��6Q   $	��600��6^   $��Center=�6k   $��Center=�6�   ��6   ��  �� Path$ UserCollection���5      �� 5      .R�5      �� .+�5      �� ��6(   �� *_currentName+�� 5      $ 
Horizontal=�6)   .+�5   "   �� $��30��6@   $
��Left=�6K   ��6,   �� *Id+6K   �� 5   "   $
��Auto��6I   $
��Auto��6V   ��6)   �� *startButton+��5      �� *startCommand+��5      �� *Id+�� 5   "   $��Interval��6)   $
��Auto��6<   $
��Auto��6I   ��5      ��  �� RelativeSource ��  �� AncestorType$ ListBoxL�$ DataContext.Interval���5       ��  �� $ ListBoxItemL�$ Content��� 5!   "   $
��Auto��6)   $
��Auto��66   $��Delete��6D   �� 5"   "   $��
Start Time��6,   $
��Auto��6>   �� 5#   "    �� 
IsReadOnly . $
��Auto��6W   ��6*   �� *	startTime+6W   �� 5$   "   $��End Time��6,   $
��Auto��6<   �� 5%   "   $	��100��6D   ��6*   �� *	endTime+6D   �� 5&   "   $��
Total Time��6,   $��70��6>   �� 5'   "   $	��100��6F   ��6*   �� *	totalTime+6F   �� 5(   "   5)      5*      5+      5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� $
��Name��6   $
��Auto��6(   $
��Auto��65    �� TextAlignment$ Center=�6C   $��Center=�6Z   $
��Left=�6u   $��20(�6�   �� 50      $	��150��67   $��30��6C   $
��Left=�6O   ��6   �� *currentName+6O   �� 51      $��Submit��6   $	��100��6+   $��30��67   $��Right=�6C   ��6_   �� *AddUserCommand+�� 52      $
��Back��6   $	��100��6)   $��30��65   $
��Left=�6A   $��0��6\   ��6i   �� *NavigateLoginCommand+�� 53      $��	Clear All��6   $	��100��6.   $��30��6:   $��Right=�6F   ��6b   �� *clearAllCommand+�� 54      $��	Start All��6=   $	��100��6Q   $��30��6]   ��6   �� *StartAllCommand+6]   �� 55      $��Export��6;   $	��100��6L   $��30��6X   ��6   �� *exportCommand+6X   �� 56      $��Reload��6<   $	��100��6M   $��30��6Y   ��6   �� *ConnectCommand+6Y   57      58      59      5:      