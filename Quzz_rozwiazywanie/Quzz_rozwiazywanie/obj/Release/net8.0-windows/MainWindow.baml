   M S B A M L   `   `   `  ����   Quzz_rozwiazywanie)    #Quzz_rozwiazywanie.Views.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Rozwiązywanie Quizu��$	��600��$	��800��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�c� $��0��.@��� $��Wczytaj Quiz������ *LoadQuizCommand+�� $��
Rozpocznij������ *StartQuizCommand+{��� *CanStartQuiz+�� $��Zakończ������ *EndQuizCommand+{��� *
CanEndQuiz+�� $��1��$��Center=�$��10q����� *RemainingTime+ �� StringFormat$% Pozostały czas: {0:hh\:mm\:ss}��� $��2��$��10q�����  �� 
TargetType" � �� Triggers ��  �� Binding �� *ShowResults+ �� Value True.a���  �� Property � y� �� Value$ 	Collapsed=� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$
��Wrap=�$��0,0,0,10q����� *CurrentQuestion.Text+�� $��1������ *CurrentQuestion.Answers+���� .R��� $	��0,5q����� *Text+	 d� 	IsChecked	 �� *
IsSelected+
 �� Mode$
 TwoWay=����� *!DataContext.SelectAnswerCommand+ �� RelativeSource ��  �� AncestorType
 Window���� �� $��2�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��
Poprzednie��$��5q����� *PreviousQuestionCommand+�� $��	Następne��$��5q����� *NextQuestionCommand+� $��2��$��10q����� " � ��  �� *ShowResults+	 False.a���  � y�$ 	Collapsed=�.+��� .+��� $��Center=�$��20(�$��0,0,0,20q����� *CurrentAttempt.TotalPoints+$ Zdobyte punkty: {0}/{1}���� ���� *CurrentAttempt.Quiz.Questions+���� .R��� $
��0,10q�.+��� $
��Wrap=����� *Text+�� $
��20,5q����� *	Answers+���� .R��� $ 
Horizontal=�.+��� ���� *Text+�� $	��✓��
��� � �y��� *	IsCorrect+    BooleanToVisibilityConverter �� 	Converter# [  �� $	��✗��
���  ��y��� *
IsSelected+# [  