// ViewModels/QuizSolverViewModel.cs
using System;
using System.ComponentModel;
using System.Windows.Input;
using Quzz_rozwiazywanie.Models;
using Quzz_rozwiazywanie.Services;

namespace Quzz_rozwiazywanie.ViewModels
{
    public class QuizSolverViewModel : INotifyPropertyChanged
    {
        private readonly FileService _fileService;
        private readonly IDialogService _dialogService;
        private QuizAttempt _currentAttempt;
        private Question _currentQuestion;
        private TimeSpan _remainingTime;
        private bool _isQuizActive;
        private bool _showResults;
        private int _currentQuestionIndex;

        public QuizAttempt CurrentAttempt
        {
            get => _currentAttempt;
            set
            {
                _currentAttempt = value;
                OnPropertyChanged(nameof(CurrentAttempt));
            }
        }

        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        public TimeSpan RemainingTime
        {
            get => _remainingTime;
            set
            {
                _remainingTime = value;
                OnPropertyChanged(nameof(RemainingTime));
            }
        }

        public bool IsQuizActive
        {
            get => _isQuizActive;
            set
            {
                _isQuizActive = value;
                OnPropertyChanged(nameof(IsQuizActive));
                OnPropertyChanged(nameof(CanStartQuiz));
                OnPropertyChanged(nameof(CanEndQuiz));
            }
        }

        public bool ShowResults
        {
            get => _showResults;
            set
            {
                _showResults = value;
                OnPropertyChanged(nameof(ShowResults));
            }
        }

        public bool CanStartQuiz => !IsQuizActive && CurrentAttempt != null;
        public bool CanEndQuiz => IsQuizActive;

        public ICommand StartQuizCommand { get; }
        public ICommand EndQuizCommand { get; }
        public ICommand LoadQuizCommand { get; }
        public ICommand SelectAnswerCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public ICommand PreviousQuestionCommand { get; }

        private System.Timers.Timer _timer;

        public QuizSolverViewModel(FileService fileService, IDialogService dialogService)
        {
            _fileService = fileService;
            _dialogService = dialogService;

            StartQuizCommand = new RelayCommand(StartQuiz, () => CanStartQuiz);
            EndQuizCommand = new RelayCommand(EndQuiz, () => CanEndQuiz);
            LoadQuizCommand = new RelayCommand(LoadQuiz);
            SelectAnswerCommand = new RelayCommand<Answer>(SelectAnswer);
            NextQuestionCommand = new RelayCommand(NextQuestion, () => IsQuizActive);
            PreviousQuestionCommand = new RelayCommand(PreviousQuestion, () => IsQuizActive);

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (RemainingTime.TotalSeconds > 0)
            {
                RemainingTime = RemainingTime.Subtract(TimeSpan.FromSeconds(1));
            }
            else
            {
                EndQuiz();
            }
        }

        private async void LoadQuiz()
        {
            try
            {
                string filePath = _dialogService.ShowOpenFileDialog("Quiz files (*.quiz)|*.quiz");
                if (string.IsNullOrEmpty(filePath)) return;

                var quiz = await _fileService.LoadQuizAsync(filePath);
                CurrentAttempt = new QuizAttempt(quiz);
                _currentQuestionIndex = 0;
                CurrentQuestion = quiz.Questions[_currentQuestionIndex];
                _dialogService.ShowMessage("Quiz został wczytany pomyślnie.");
            }
            catch (Exception ex)
            {
                _dialogService.ShowError($"Błąd podczas wczytywania quizu: {ex.Message}");
            }
        }

        private void StartQuiz()
        {
            if (CurrentAttempt == null)
            {
                _dialogService.ShowError("Najpierw wczytaj quiz!");
                return;
            }

            IsQuizActive = true;
            ShowResults = false;
            RemainingTime = TimeSpan.FromMinutes(30);
            _timer.Start();
        }

        private void EndQuiz()
        {
            if (!IsQuizActive) return;

            _timer.Stop();
            IsQuizActive = false;
            CurrentAttempt.EndAttempt();
            ShowResults = true;
        }

        private void SelectAnswer(Answer answer)
        {
            if (!IsQuizActive || CurrentQuestion == null) return;

            CurrentAttempt.AddAnswer(CurrentQuestion, answer);
        }

        private void NextQuestion()
        {
            if (!IsQuizActive || CurrentAttempt == null) return;

            if (_currentQuestionIndex < CurrentAttempt.Quiz.Questions.Count - 1)
            {
                _currentQuestionIndex++;
                CurrentQuestion = CurrentAttempt.Quiz.Questions[_currentQuestionIndex];
            }
        }

        private void PreviousQuestion()
        {
            if (!IsQuizActive || CurrentAttempt == null) return;

            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                CurrentQuestion = CurrentAttempt.Quiz.Questions[_currentQuestionIndex];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}