using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TextProcess.Wpf.Commands;
using TextProcess.Wpf.Configuration;
using TextProcess.Wpf.Core.Contracts.Models;
using TextProcess.Wpf.Core.Contracts.Services;
using TextProcess.Wpf.Models;

namespace TextProcess.Wpf.ViewModels
{
    /// <summary>
    /// ViewModel for the main window of the application. Manages the user interface, properties, and commands.
    /// </summary>
    public class MainWindowsViewModel : INotifyPropertyChanged
    {
        #region Fields

        // Locks
        private readonly object _lockText = new();

        // Services
        private readonly IOrderService? _orderService;
        private readonly ITextStatisticsService? _textStatisticsService;

        // Fields for chare information.
        private readonly List<OrderOption> _ordersOptions = new();

        // Messages dicctionarie
        private readonly Dictionary<int, string> _messagesDictionarie = new()
        {
            { 1, string.Empty },
            { 2, $"Tarea realizada." },
            { 3, $"Ha ocurrido un problema." },
        };

        // Fields for various properties
        private string _tittle = string.Empty;
        private string _closeButtonContent = string.Empty;
        private ulong _numberOfHyphen = ulong.MinValue;
        private ulong _numberOfWords = ulong.MinValue;
        private ulong _numberOfWhiteSpaces = ulong.MinValue;
        private string _numberOfHyphenTittle = string.Empty;
        private string _numberOfWordsTittle = string.Empty;
        private string _numberOfWhiteSpacesTittle = string.Empty;
        private string _textToProcess = string.Empty;
        private string _insertTextTittle = string.Empty;
        private string _orderTittle = string.Empty;
        private string _analyzeTittle = string.Empty;
        private List<ComboBoxItem> _orders = new();
        private ComboBoxItem _selectedOrder = new();
        private List<ListViewItem> _lines = new();
        private Visibility _progressBarVisibiliTy = Visibility.Visible;
        private string _message = string.Empty;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowsViewModel"/> class.
        /// </summary>
        public MainWindowsViewModel()
        {
            TitleInitializer();

            Orders = new List<ComboBoxItem>();
            Lines = new List<ListViewItem>();

            // Initializes commands.
            CloseAppCommand = new RelayCommand<object>(CanExecuteCloseAppCommand, ExecuteCloseAppCommand);
            TextAnalyzeAppCommand = new RelayCommand<object>(CanExecuteTextAnalyzeAppCommand, ExecuteTextAnalyzeAppCommand);

            // Dependencies
            if (!ConfigurationService.IsInDesignMode)
            {
                _orderService = ConfigurationService.Current.Host!.Services.GetRequiredService<IOrderService>();
                _textStatisticsService = ConfigurationService.Current.Host!.Services.GetRequiredService<ITextStatisticsService>();
                _ = UpdateOrdersAsync();
            }
        }

        /// <summary>
        /// Subscribe for property changed events.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets a text value of app tittle.
        /// </summary>
        public string Tittle
        {
            get => _tittle;
            set
            {
                if (_tittle != value)
                {
                    _tittle = value;
                    NotifyPropertyChanged(nameof(Tittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets a text to process.
        /// </summary>
        public string TextToProcess
        {
            get => _textToProcess;
            set
            {
                if (_textToProcess != value)
                {
                    _textToProcess = value;
                    NotifyPropertyChanged(nameof(TextToProcess));
                }
            }
        }

        /// <summary>
        /// Gets or sets a insert text tittle.
        /// </summary>
        public string InsertTextTittle
        {
            get => _insertTextTittle;
            set
            {
                if (_insertTextTittle != value)
                {
                    _insertTextTittle = value;
                    NotifyPropertyChanged(nameof(InsertTextTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets a text value of number of hyphen tittle.
        /// </summary>
        public string NumberOfHyphenTittle
        {
            get => _numberOfHyphenTittle;
            set
            {
                if (_numberOfHyphenTittle != value)
                {
                    _numberOfHyphenTittle = value;
                    NotifyPropertyChanged(nameof(NumberOfHyphenTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of words tittle.
        /// </summary>
        public string NumberOfWordsTittle
        {
            get => _numberOfWordsTittle;
            set
            {
                if (_numberOfWordsTittle != value)
                {
                    _numberOfWordsTittle = value;
                    NotifyPropertyChanged(nameof(NumberOfWordsTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of white spaces tittle.
        /// </summary>
        public string NumberOfWhiteSpacesTittle
        {
            get => _numberOfWhiteSpacesTittle;
            set
            {
                if (_numberOfWhiteSpacesTittle != value)
                {
                    _numberOfWhiteSpacesTittle = value;
                    NotifyPropertyChanged(nameof(NumberOfWhiteSpacesTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets order tittle.
        /// </summary>
        public string OrderTittle
        {
            get => _orderTittle;
            set
            {
                if (_orderTittle != value)
                {
                    _orderTittle = value;
                    NotifyPropertyChanged(nameof(OrderTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets analyze button tittle.
        /// </summary>
        public string AnalyzeTittle
        {
            get => _analyzeTittle;
            set
            {
                if (_analyzeTittle != value)
                {
                    _analyzeTittle = value;
                    NotifyPropertyChanged(nameof(AnalyzeTittle));
                }
            }
        }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    NotifyPropertyChanged(nameof(Message));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of hyphen type characters.
        /// </summary>
        public ulong NumberOfHyphen
        {
            get => _numberOfHyphen;
            set
            {
                if (_numberOfHyphen != value)
                {
                    _numberOfHyphen = value;
                    NotifyPropertyChanged(nameof(NumberOfHyphen));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of words.
        /// </summary>
        public ulong NumberOfWords
        {
            get => _numberOfWords;
            set
            {
                if (_numberOfWords != value)
                {
                    _numberOfWords = value;
                    NotifyPropertyChanged(nameof(NumberOfWords));
                }
            }
        }

        /// <summary>
        /// Gets or sets number of white spaces.
        /// </summary>
        public ulong NumberOfWhiteSpaces
        {
            get => _numberOfWhiteSpaces;
            set
            {
                if (_numberOfWhiteSpaces != value)
                {
                    _numberOfWhiteSpaces = value;
                    NotifyPropertyChanged(nameof(NumberOfWhiteSpaces));
                }
            }
        }

        /// <summary>
        /// Gets or sets a text value of close button.
        /// </summary>
        public string CloseButtonContent
        {
            get => _closeButtonContent;
            set
            {
                if (_closeButtonContent != value)
                {
                    _closeButtonContent = value;
                    NotifyPropertyChanged(nameof(CloseButtonContent));
                }
            }
        }

        /// <summary>
        /// Gets or sets orders.
        /// </summary>
        public List<ComboBoxItem> Orders
        {
            get => _orders;
            set
            {
                if (_orders != value)
                {
                    _orders = value;
                    NotifyPropertyChanged(nameof(Orders));
                }
            }
        }

        /// <summary>
        /// Gets or sets lines.
        /// </summary>
        public List<ListViewItem> Lines
        {
            get => _lines;
            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    NotifyPropertyChanged(nameof(Lines));
                }
            }
        }

        /// <summary>
        /// Gets or sets selected order.
        /// </summary>
        public ComboBoxItem SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (_selectedOrder != value)
                {
                    _selectedOrder = value;
                    NotifyPropertyChanged(nameof(SelectedOrder));
                }
            }
        }

        /// <summary>
        /// Gets or sets progress bar visibility.
        /// </summary>
        public Visibility ProgressBarVisibility
        {
            get => _progressBarVisibiliTy;
            set
            {
                if (_progressBarVisibiliTy != value)
                {
                    _progressBarVisibiliTy = value;
                    NotifyPropertyChanged(nameof(ProgressBarVisibility));
                }
            }
        }

        /// <summary>
        /// Gets or sets close app command.
        /// </summary>
        public RelayCommand<object> CloseAppCommand { get; set; }

        /// <summary>
        /// Gets or sets text analyze.
        /// </summary>
        public RelayCommand<object> TextAnalyzeAppCommand { get; set; }

        private void TitleInitializer()
        {
            Tittle = $"Process Text App";
            CloseButtonContent = $"Cerrar";
            InsertTextTittle = $"Insertar texto en el cuadro inferior";
            NumberOfHyphenTittle = $"Cantidad de guiones";
            NumberOfWordsTittle = $"Cantidad de palabras";
            NumberOfWhiteSpacesTittle = $"Cantidad de espacios";
            OrderTittle = $"Orden";
            AnalyzeTittle = $"Analizar";
        }

        /// <summary>
        /// Updates statistics based on the processed text and selected order.
        /// </summary>
        private async Task UpdateStatisticsAsync()
        {
            try
            {
                var statistics = await _textStatisticsService!.TextAnalyzeAsync(TextToProcess);

                // Update statistics properties
                NumberOfHyphen = statistics.HyphenCount;
                NumberOfWords = statistics.WordCount;
                NumberOfWhiteSpaces = statistics.SpaceCount;

                AnalysisSuccess();
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Fatal(ex, $"An unhandled exception has occurred processing the text: {TextToProcess} with order {SelectedOrder.Name}.");

                AnalysisFailure();
            }
        }

        /// <summary>
        /// Updates the UI with the provided lines after processing.
        /// </summary>
        private async Task UpdateLines()
        {
            // Cast selected ordet to OrderText
            OrderText orderText = new(TextToProcess, _ordersOptions.First(x => x.Name.Equals(SelectedOrder.Name)).Id);
            IEnumerable<string> lines = new List<string>();

            try
            {
                Lines.Clear();

                // Transform text to a enumerable of strigs.
                lines = await _orderService!.OrderAsync(orderText);

                foreach (string line in lines)
                {
                    Lines.Add(new ListViewItem()
                    {
                        Content = line,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 25,
                    });
                }

                NotifyPropertyChanged(nameof(Lines));

                AnalysisSuccess();
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Fatal(ex, $"An unhandled exception has occurred processing the text: {UpdateLines} with order {SelectedOrder.Name}. {nameof(orderText)} = {orderText?.ToString()} , {nameof(lines)} = {string.Join(", ", lines)} .");

                AnalysisFailure();
            }
        }

        /// <summary>
        /// Updates the Orders collection based on the available order options.
        /// </summary>
        private async Task UpdateOrdersAsync()
        {
            try
            {
                ProgressBarVisibility = Visibility.Visible;

                // // Get the order options from the service
                var orders = await _orderService!.GetOrderOptionsAsync();

                // Clear the existing Orders collection
                Orders.Clear();

                // Add new items to the collection
                foreach (IOrderOption option in orders)
                {
                    AddComboBoxItem(option);
                    _ordersOptions.Add(new(option.Id, option.Name, option.Description));
                }

                AnalysisSuccess();
            }
            catch (Exception ex)
            {
                // Handle the exception as needed (e.g., log or display an error message)
                ConfigurationService.Current.Logger.Error($"Error updating orders: {ex.Message}");

                AnalysisFailure();
            }
        }

        /// <summary>
        /// Adds a ComboBoxItem to the Orders collection based on the provided order option.
        /// </summary>
        /// <param name="orderOption">The order option to add to the collection.</param>
        private void AddComboBoxItem(IOrderOption orderOption)
        {
            // Add a new ComboBoxItem to the Orders collection
            Orders.Add(new ComboBoxItem()
            {
                Content = orderOption.Description,
                Name = orderOption.Name,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 20,
            });
        }

        /// <summary>
        /// Called by Set accessor of each property that needs to notify it's value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property it's value changed.</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Determines whether the Close App command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        /// <returns>True if the command can be executed; otherwise, false.</returns>
        private bool CanExecuteCloseAppCommand(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the Close App command, shutting down the application.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        private void ExecuteCloseAppCommand(object parameter)
        {
            try
            {
                // Shuts down the application.
                ConfigurationService.Current.Logger.Fatal($"Execute close application.");
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                // Logs any unhandled exceptions.
                ConfigurationService.Current.Logger.Error($"An unhandled exception has occurred in {nameof(ExecuteCloseAppCommand)} and the message is: {ex.Message}");
            }
        }

        /// <summary>
        /// Executes the Text Analyze App command asynchronously.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        private void ExecuteTextAnalyzeAppCommand(object parameter)
        {
            try
            {
                AnalysisInitialization();

                // Do process text.
                _ = Application.Current.Dispatcher.Invoke(async () =>
                {
                    // Show progress bar
                    ProgressBarVisibility = Visibility.Visible;

                    // Validate selected order and text to process.
                    if (SelectedOrder.Content == null || string.IsNullOrEmpty(TextToProcess))
                    {
                        // Hidden progess bar
                        ProgressBarVisibility = Visibility.Hidden;
                        Message = GetMessage(1);
                        return;
                    }

                    // Update statistics.
                    // Update lines.
                    await Task.WhenAll(UpdateStatisticsAsync(), UpdateLines());
                });
            }
            catch (Exception ex)
            {
                // Logs any unhandled exceptions.
                ConfigurationService.Current.Logger.Fatal(ex, $"An unhandled exception has occurred in {nameof(ExecuteTextAnalyzeAppCommand)} .");

                AnalysisFailure();
            }
        }

        private void AnalysisInitialization()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Show progress bar
                ProgressBarVisibility = Visibility.Visible;

                // Show fail mesagge
                Message = GetMessage(1);
            });
        }

        private void AnalysisSuccess()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Hidden progess bar
                ProgressBarVisibility = Visibility.Hidden;

                // Show fail mesagge
                Message = GetMessage(2);
            });
        }

        private void AnalysisFailure()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Hidden progess bar
                ProgressBarVisibility = Visibility.Hidden;

                // Show fail mesagge
                Message = GetMessage(3);
            });
        }

        /// <summary>
        /// Determines whether the Text Analyze App command can be executed.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns><c>true</c> if the command can be executed; otherwise, <c>false</c>.</returns>
        private bool CanExecuteTextAnalyzeAppCommand(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Gets the message for the specified key.
        /// </summary>
        /// <param name="key">The key of the message.</param>
        /// <returns>The message corresponding to the key, or an empty string if not found.</returns>
        private string GetMessage(int key)
        {
            if (_messagesDictionarie.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}