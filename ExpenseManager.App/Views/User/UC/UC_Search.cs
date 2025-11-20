using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_Search : UserControl, ISearchView
    {
        private readonly SearchPresenter _presenter;
        private bool _isSearching = false;

        // ISearchView Properties
        public string Keyword
        {
            get => txtKeyword.Text;
            set
            {
                if (txtKeyword.InvokeRequired)
                    txtKeyword.Invoke(new Action(() => txtKeyword.Text = value));
                else
                    txtKeyword.Text = value;
            }
        }

        public string SelectedType
        {
            get
            {
                if (cboType.SelectedItem == null)
                    return "Tất cả";

                var selected = cboType.SelectedItem.ToString();
                // Map UI to Database values
                if (selected == "Thu nhập") return "Income";
                if (selected == "Chi tiêu") return "Expense";
                return "Tất cả";
            }
            set
            {
                if (cboType.InvokeRequired)
                    cboType.Invoke(new Action(() => SetTypeComboBox(value)));
                else
                    SetTypeComboBox(value);
            }
        }

        private void SetTypeComboBox(string value)
        {
            // Map Database to UI values
            if (value == "Income")
                cboType.SelectedItem = "Thu nhập";
            else if (value == "Expense")
                cboType.SelectedItem = "Chi tiêu";
            else
                cboType.SelectedIndex = 0; // Tất cả
        }

        public int? SelectedCategoryId
        {
            get
            {
                if (cboCategory.SelectedItem == null)
                    return null;

                if (cboCategory.SelectedItem is Category category)
                {
                    return category.CategoryId > 0 ? category.CategoryId : (int?)null;
                }
                return null;
            }
            set
            {
                Action setCategory = () =>
                {
                    if (value.HasValue && value.Value > 0)
                    {
                        foreach (var item in cboCategory.Items)
                        {
                            if (item is Category cat && cat.CategoryId == value.Value)
                            {
                                cboCategory.SelectedItem = item;
                                return;
                            }
                        }
                    }
                    cboCategory.SelectedIndex = 0;
                };

                if (cboCategory.InvokeRequired)
                    cboCategory.Invoke(setCategory);
                else
                    setCategory();
            }
        }

        public DateTime FromDate
        {
            get => dtpFromDate.Value;
            set
            {
                if (dtpFromDate.InvokeRequired)
                    dtpFromDate.Invoke(new Action(() => dtpFromDate.Value = value));
                else
                    dtpFromDate.Value = value;
            }
        }

        public DateTime ToDate
        {
            get => dtpToDate.Value;
            set
            {
                if (dtpToDate.InvokeRequired)
                    dtpToDate.Invoke(new Action(() => dtpToDate.Value = value));
                else
                    dtpToDate.Value = value;
            }
        }

        public string ResultCount
        {
            get => lblResultCount.Text;
            set
            {
                if (lblResultCount.InvokeRequired)
                    lblResultCount.Invoke(new Action(() => lblResultCount.Text = value));
                else
                    lblResultCount.Text = value;
            }
        }

        private List<Transaction> _transactions;
        public List<Transaction> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => DisplayTransactions()));
                else
                    DisplayTransactions();
            }
        }

        public void ExecuteSearch(string keyword, bool immediateSearch = false)
        {
            this.Keyword = keyword;

            if (!string.IsNullOrWhiteSpace(keyword) || immediateSearch)
            {
                _presenter.SearchTransactions();
            }
            else
            {
                _presenter.ResetFilters();
            }
        }

        public UC_Search()
        {
            InitializeComponent();

            // Initialize Presenter with DI
            var searchService = Program.ServiceProvider.GetRequiredService<ISearchServices>();
            _presenter = new SearchPresenter(this, searchService);

            InitializeDataGridView();
            InitializeFilters();
            _presenter.LoadInitialData();
        }

        public void InitializeFilters()
        {
            InitializeTypeComboBox();
            InitializeDatePickers();
            _presenter.LoadCategories();
        }

        private void InitializeTypeComboBox()
        {
            // Only initialize if empty
            if (cboType.Items.Count == 0)
            {
                cboType.Items.Clear();
                cboType.Items.Add("Tất cả");
                cboType.Items.Add("Thu nhập");
                cboType.Items.Add("Chi tiêu");
            }
            cboType.SelectedIndex = 0;
        }

        private void InitializeDatePickers()
        {
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
        }

        public void ResetFiltersUI()
        {
            // Reset without reloading categories
            txtKeyword.Text = string.Empty;
            InitializeTypeComboBox();
            InitializeDatePickers();

            // Reset category to "Tất cả" without reloading
            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
        }

        public void LoadCategories(List<Category> categories)
        {
            Action loadAction = () =>
            {
                System.Diagnostics.Debug.WriteLine($"=== LoadCategories called with {categories?.Count ?? 0} categories ===");

                cboCategory.Items.Clear();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";

                // Add "Tất cả" option
                var allCategory = new Category { CategoryId = 0, CategoryName = "Tất cả" };
                cboCategory.Items.Add(allCategory);

                // Add all categories
                if (categories != null)
                {
                    foreach (var category in categories)
                    {
                        cboCategory.Items.Add(category);
                        System.Diagnostics.Debug.WriteLine($"  Added: {category.CategoryId} - {category.CategoryName}");
                    }
                }

                cboCategory.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine($"Category ComboBox Items Count: {cboCategory.Items.Count}");
            };

            if (cboCategory.InvokeRequired)
                cboCategory.Invoke(loadAction);
            else
                loadAction();
        }

        private void InitializeDataGridView()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.EnableHeadersVisualStyles = false;

            // Header styling
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 31, 224);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

            // Row styling
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvTransactions.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvTransactions.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);

            // Add columns
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TransactionDate",
                HeaderText = "Ngày",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Mô tả",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Danh mục",
                Width = 150
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TypeColumn",
                HeaderText = "Loại",
                Width = 120
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Số tiền (VNĐ)",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _transactions.Count)
            {
                var transaction = _transactions[e.RowIndex];

                // Format Category Name
                if (dgvTransactions.Columns[e.ColumnIndex].Name == "CategoryName")
                {
                    e.Value = transaction.Category?.CategoryName ?? "N/A";
                }

                // Format Type column - Convert to Vietnamese
                if (dgvTransactions.Columns[e.ColumnIndex].Name == "TypeColumn")
                {
                    if (transaction.Type == "Income")
                        e.Value = "Thu nhập";
                    else if (transaction.Type == "Expense")
                        e.Value = "Chi tiêu";
                    else
                        e.Value = transaction.Type;
                }

                // Color Amount column based on Type
                if (dgvTransactions.Columns[e.ColumnIndex].HeaderText == "Số tiền (VNĐ)")
                {
                    // Check both English and Vietnamese
                    bool isIncome = transaction.Type == "Income" || transaction.Type == "Thu nhập";

                    e.CellStyle.ForeColor = isIncome
                        ? System.Drawing.Color.FromArgb(40, 167, 69)   // Green for Income
                        : System.Drawing.Color.FromArgb(220, 53, 69);  // Red for Expense
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }
        }

        private void DisplayTransactions()
        {
            if (_transactions == null || _transactions.Count == 0)
            {
                dgvTransactions.DataSource = null;
                dgvTransactions.Refresh();
                return;
            }

            // Bind to BindingSource for better performance
            var bindingSource = new BindingSource
            {
                DataSource = _transactions
            };
            dgvTransactions.DataSource = bindingSource;
            dgvTransactions.Refresh();
        }

        public void ShowMessage(string message, string title, bool isError = false)
        {
            Action showAction = () =>
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK,
                    isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            };

            if (this.InvokeRequired)
                this.Invoke(showAction);
            else
                showAction();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (_isSearching)
                return;

            _isSearching = true;
            btnSearch.Enabled = false;

            try
            {
                _presenter.SearchTransactions();
            }
            finally
            {
                // Re-enable after a short delay
                System.Threading.Tasks.Task.Delay(300).ContinueWith(t =>
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() =>
                        {
                            _isSearching = false;
                            btnSearch.Enabled = true;
                        }));
                    else
                    {
                        _isSearching = false;
                        btnSearch.Enabled = true;
                    }
                });
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (_isSearching)
                return;

            _isSearching = true;
            btnReset.Enabled = false;

            try
            {
                _presenter.ResetFilters();
            }
            finally
            {
                System.Threading.Tasks.Task.Delay(300).ContinueWith(t =>
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() =>
                        {
                            _isSearching = false;
                            btnReset.Enabled = true;
                        }));
                    else
                    {
                        _isSearching = false;
                        btnReset.Enabled = true;
                    }
                });
            }
        }
    }
}