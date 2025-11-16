using System;

namespace ExpenseManager.App.Views.User.UC
{
    internal interface ICreateTicketView
    {
        string UserId { get; }
        string Description { get; }
        string QuestionType { get; }
        int SelectedQuestionTypeIndex { get; }
        void ShowSuccess(string message);
        void ShowError(string message);
        void SetLoading(bool isLoading);
        void NavigateBackToList();
        event EventHandler SubmitTicketClicked;
        event EventHandler CancelClicked;
    }
}