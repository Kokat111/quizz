   M S B A M L   `   `   `  ����  Quzz_rozwiazywanie)    #Quzz_rozwiazywanie.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Rozwiązywanie Quizu��5   	   $	��600��6%   $	��800��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   c� $��0��6   .@�5      �� $��Wczytaj Quiz��6   ��6,   �� *LoadQuizCommand+�� 5      $��
Rozpocznij��6   ��6*   �� *StartQuizCommand+{�5      �� *CanStartQuiz+�� 5      $��Zakończ��6   ��6'   �� *EndQuizCommand+{�5      �� *
CanEndQuiz+5      �� 5   
   $��1��6   $��Center=�5      $��10q�61   ��5   !   �� *RemainingTime+ �� StringFormat$% Pozostały czas: {0:hh\:mm\:ss}��5   1   � 5   
   $��2��6   $��10q�6   ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      �� 5       �� Binding 6&   �� *ShowResults+ �� Value True6F   .a�5       ��  �� Property � y� �� Value$ 	Collapsed=�6;   5!      5#       5&      �� 5'      $
��Auto �6    �� 5(      $��* �6    �� 5)      $
��Auto �6    .+�5-      �� $��0��6   $
��Wrap=�5.      $��0,0,0,10q�6,   ��5-   %   �� *CurrentQuestion.Text+5.   ,   �� 51      $��1��6   ��6(   �� *CurrentQuestion.Answers+��52      �� 53      .R�54      �� $	��0,5q�6<   ��6#   �� *Text+	 d� 	IsChecked	 55   #   �� *
IsSelected+
 �� Mode$
 TwoWay=���56   #   �� *!DataContext.SelectAnswerCommand+ �� RelativeSource ��  �� AncestorType
 Window��58   #   �� 59      5;      �� 5>      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5?      �� $��
Poprzednie��6   $��5q�5@      ��5?   .   �� *PreviousQuestionCommand+5@      �� 5A      $��	Następne��6   $��5q�5B      ��5A   ,   �� *NextQuestionCommand+5B      5C      5D      � 5G   
   $��2��6   $��10q�6   ��5H      �� 5I      " �6    5J      �� 5K       6&   �� *ShowResults+	 False6F   .a�5L      ��  � y�$ 	Collapsed=�6;   5M      5O      .+�5R      �� .+�5S      �� $��Center=�5U      $��20(�69   $��0,0,0,20q�6G   ��5S      �� *CurrentAttempt.TotalPoints+$ Zdobyte punkty: {0}/{1}��5U   G   �� 5W      ��6   �� *CurrentAttempt.Quiz.Questions+��5X      �� 5Y      .R�5Z      �� $
��0,10q�6)   .+�5[   "   �� $
��Wrap=�6B   ��6,   �� *Text+6B   �� 5\   "   $
��20,5q�6O   ��6/   �� *	Answers+��5]   &   �� 5^   *   .R�5_   .   �� $ 
Horizontal=�69   .+�5`   2   �� ��6<   �� *Text+�� 5a   2   $	��✓��6<   
��� � �y�5b   :   �� *	IsCorrect+    BooleanToVisibilityConverter �� 	Converter# [  �� 5d   2   $	��✗��6<   
���  ��y�5e   :   �� *
IsSelected+# [  5g   /   5h   +   5j   #   5k      5l      5n      5o      5p      5q      5r      