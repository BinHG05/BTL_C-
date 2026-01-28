using System;
using System.Threading.Tasks;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.User.UC;

namespace ExpenseManager.App.Presenters
{
    internal class CreateTicketPresenter
    {
        private readonly ICreateTicketView _view;
        private readonly ITicketUserServices _service;

        public CreateTicketPresenter(ICreateTicketView view, ITicketUserServices service)
        {
            _view = view;
            _service = service;

            _view.SubmitTicketClicked += OnSubmitTicketClicked;
            _view.CancelClicked += OnCancelClicked;
        }

        private async void OnSubmitTicketClicked(object sender, EventArgs e)
        {
            await CreateTicketAsync();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            _view.NavigateBackToList();
        }

        private async Task CreateTicketAsync()
        {
            try
            {
                _view.SetLoading(true);

                var description = _view.Description;
                var questionType = _view.QuestionType;
                var userId = _view.UserId;

                if (_view.SelectedQuestionTypeIndex == 0)
                {
                    _view.ShowError("Vui lòng chọn loại yêu cầu!");
                    return;
                }

                var (success, errorMessage) = await _service.CreateTicketAsync(description, questionType, userId);

                if (success)
                {
                    _view.ShowSuccess("Yêu cầu đã được tạo thành công!");
                    _view.NavigateBackToList();
                }
                else
                {
                    _view.ShowError(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Có lỗi xảy ra: {ex.Message}");
            }
            finally
            {
                _view.SetLoading(false);
            }
        }
    }
}